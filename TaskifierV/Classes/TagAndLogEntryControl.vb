Imports System.Data.Linq.SqlClient

Public Class TagAndLogEntryControl

    Private _dbPath As String
    Private _logName As String

    ''' <summary>
    ''' Class constructor. Initializes DB path and log name
    ''' </summary>
    ''' <param name="dbPath">Path to local DB</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef dbPath As String, ByRef logName As String)
        _dbPath = dbPath
        _logName = logName
    End Sub

    ''' <summary>
    ''' Returns a table with tags and their identifiers from the DB
    ''' </summary>
    ''' <param name="logName">Log name, e.g. "Backlog"</param>
    ''' <returns>Data table with tags (id and name)</returns>
    ''' <remarks></remarks>
    Public Function GetTagsForLog(ByVal logName As String, ByRef getAllTags As Boolean) As DataTable
        'Debug method parameters
        Debug.Print("")
        Debug.Print("Function GetTagsForLog started. Messages:")
        Debug.Print("Log Name: " & logName)

        'Create (empty) table and column objects
        Dim dt As New DataTable("TagsForLog")
        Dim dcId As New DataColumn("Id")
        Dim dcName As New DataColumn("Name")

        'Add columns to table
        dt.Columns.Add(dcId)
        dt.Columns.Add(dcName)

        'Create row and DB objects
        Dim dr As DataRow
        Dim v
        Dim DB As New TaskifierDB(_dbPath)

        'Check if tags need to be filtered
        If getAllTags = True Then
            'Query DB for all tags (NO filter!)
            v = (From t In DB.Tags
                 Where t.Active = True
                 Order By t.Name
                 Select t.Id, t.Name).Distinct
        Else
            'Query DB for tags, filter is log type
            v = (From t In DB.Tags
                 Join lett In DB.LogEntriesToTags
                 On lett.TagId Equals t.Id
                 Join le In DB.LogEntries
                 On le.Id Equals lett.LogEntryId
                 Where le.LogType = logName
                 Where le.Active = True
                 Order By t.Name
                 Select t.Id, t.Name).Distinct
        End If

        'Add default row
        dr = dt.NewRow()
        dr("Id") = "-1"
        dr("Name") = "All"
        dt.Rows.Add(dr)

        'Add rows returned from DB
        For Each element In v
            dr = dt.NewRow()
            dr("Id") = element.Id
            dr("Name") = element.Name
            dt.Rows.Add(dr)
        Next

        'Destroy objects
        DB = Nothing
        dr = Nothing
        dcName = Nothing
        dcId = Nothing

        'Return table
        Return dt
    End Function

    ''' <summary>
    ''' Returns a table with log entries and their identifiers from the DB
    ''' </summary>
    ''' <param name="tagId">Tag identifier</param>
    ''' <param name="logName">Log name, e.g. "Backlog"</param>
    ''' <returns>Data table with log entries (id and name)</returns>
    ''' <remarks></remarks>
    Public Function GetLogEntriesForTag(ByVal tagId As Integer, ByVal logName As String) As DataTable
        'Debug method parameters
        Debug.Print("")
        Debug.Print("Function GetLogEntriesForTag started. Messages:")
        Debug.Print("Log Name: " & logName)
        Debug.Print("Tag ID: " & tagId.ToString)

        'Create (empty) table and column objects
        Dim dt As New DataTable("LogEntriesForTagsAndLog")
        Dim dcId As New DataColumn("Id")
        Dim dcName As New DataColumn("Name")

        'Add columns to table
        dt.Columns.Add(dcId)
        dt.Columns.Add(dcName)

        'Create row and DB objects
        Dim dr As DataRow
        Dim v
        Dim DB As New TaskifierDB(_dbPath)

        'Check if tag identifier is set
        If tagId > -1 Then
            'Query DB for log entries, filter is tag and log type
            v = (From le In DB.LogEntries
                 Join lett In DB.LogEntriesToTags
                 On le.Id Equals lett.LogEntryId
                 Join t In DB.Tags
                 On lett.TagId Equals t.Id
                 Where le.LogType = logName
                 Where le.Active = True
                 Where t.Id = tagId
                 Order By le.Name
                 Select le.Id, le.Name).Distinct
        Else
            'Query DB for log entries, filter is log type (NOT tag!)
            v = (From le In DB.LogEntries
                 Where le.LogType = logName
                 Where le.Active = True
                 Order By le.Name
                 Select le.Id, le.Name).Distinct
        End If

        'Add rows returned from DB
        For Each element In v
            dr = dt.NewRow()
            dr("Id") = element.Id
            dr("Name") = element.Name
            dt.Rows.Add(dr)
        Next

        'Destroy objects
        DB = Nothing
        dr = Nothing
        dcName = Nothing
        dcId = Nothing

        'Return table
        Return dt
    End Function

    ''' <summary>
    ''' Returns a LogEntryData object with one single log entry
    ''' </summary>
    ''' <param name="logEntryId">Log entry identifier</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLogEntryDetails(ByVal logEntryId As Integer) As LogEntryData
        'Debug method parameters
        Debug.Print("")
        Debug.Print("Function GetLogEntryDetails started. Messages:")
        Debug.Print("Log Entry ID: " & logEntryId.ToString)

        'Create (empty) data object for log entry
        Dim ledat As New LogEntryData

        'Create row and DB objects
        Dim v
        Dim DB As New TaskifierDB(_dbPath)

        'Query DB for tags, filter is log type
        v = (From le In DB.LogEntries
             Where le.Id = logEntryId
             Select le.Id, le.LogType, le.Name, le.Description, le.Priority, le.StartDate, _
                    le.EndDate, le.Active, le.InProgress, le.Finished).First

        'Add row returned from DB
        ledat.Id = v.Id
        ledat.LogType = v.LogType
        ledat.Name = v.Name
        ledat.Description = v.Description
        ledat.Priority = v.Priority
        ledat.StartDate = v.StartDate
        ledat.EndDate = v.EndDate
        ledat.Active = v.Active
        ledat.InProgress = v.InProgress
        ledat.Finished = v.Finished

        'Destroy objects
        DB = Nothing

        Return ledat
    End Function

    ''' <summary>
    ''' Adds a log entry to a tag
    ''' </summary>
    ''' <param name="tagId">Tag identifier</param>
    ''' <param name="logEntryId">Log entry identifier</param>
    ''' <remarks></remarks>
    Public Sub AddLogEntryToTag(ByVal tagId As Integer, ByVal logEntryId As Integer)
        'Debug method parameters
        Debug.Print("")
        Debug.Print("Function AddLogEntryToTag started. Messages:")
        Debug.Print("Log Entry ID: " & logEntryId.ToString)
        Debug.Print("Tag ID: " & tagId.ToString)

        'Create row and DB objects
        Dim v
        Dim DB As New TaskifierDB(_dbPath)

        'Check if log entry/tag combination already exists
        v = (From lett In DB.LogEntriesToTags
             Where lett.LogEntryId = logEntryId
             Where lett.TagId = tagId
             Select lett.Id).Count

        If v = 0 Then
            'Assign log entry to tag
            Dim newLogEntryToTag As New LogEntriesToTags With {.LogEntryId = logEntryId,
                                                                .TagId = tagId,
                                                                .Active = True,
                                                                .Comment = "Created by software not by mankind."}

            DB.LogEntriesToTags.InsertOnSubmit(newLogEntryToTag)
            DB.SubmitChanges()
        End If
    End Sub

    ''' <summary>
    ''' Removes a log entry from a tag
    ''' </summary>
    ''' <param name="tagId">Tag identifier</param>
    ''' <param name="logEntryId">Log entry identifier</param>
    ''' <remarks></remarks>
    Public Sub RemoveLogEntryFromTag(ByVal tagId As Integer, ByVal logEntryId As Integer)
        'Debug method parameters
        Debug.Print("")
        Debug.Print("Function RemoveLogEntryFromTag started. Messages:")
        Debug.Print("Log Entry ID: " & logEntryId.ToString)
        Debug.Print("Tag ID: " & tagId.ToString)

        'Create row and DB objects
        Dim lettToDelete
        Dim DB As New TaskifierDB(_dbPath)

        'Remove log entry from tag
        lettToDelete =
            (From lett In DB.LogEntriesToTags
             Where lett.TagId = tagId
             Where lett.LogEntryId = logEntryId
             Select lett).First

        DB.LogEntriesToTags.DeleteOnSubmit(lettToDelete)
        DB.SubmitChanges()
    End Sub

    ''' <summary>
    ''' Adds a new tag to the DB if it is not yet there
    ''' </summary>
    ''' <param name="tagName">Name of the tag to be added</param>
    ''' <remarks></remarks>
    Public Sub AddNewTag(ByVal tagName As String)
        'Debug method parameters
        Debug.Print("")
        Debug.Print("Function AddNewTag started. Messages:")
        Debug.Print("Tag Name: " & tagName)

        'Tag variable and DB object
        Dim tagCount As Integer
        Dim DB As New TaskifierDB(_dbPath)

        'Only do this if no standard tag (All) is used
        If tagName.Trim <> "All" Then
            'Check if tag is already in the DB
            tagCount =
                (From t In DB.Tags
                 Where t.Name = tagName.Trim
                 Select t).Count

            If tagCount = 0 Then
                'Write new tag into the DB
                Dim newTag As New Tags With {.Name = tagName,
                                             .Active = True,
                                             .Comment = "Created by software not by mankind."}

                DB.Tags.InsertOnSubmit(newTag)
                DB.SubmitChanges()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Removes a tag from the database, not caring if there are log entries assigned to it
    ''' </summary>
    ''' <param name="tagId">Identifier of the tag to be removed</param>
    ''' <remarks></remarks>
    Public Sub RemoveTag(ByVal tagId As Integer)
        'Debug method parameters
        Debug.Print("")
        Debug.Print("Function RemoveTag started. Messages:")
        Debug.Print("Tag Name: " & tagId)

        'Create row and DB objects
        Dim tagToDelete
        Dim DB As New TaskifierDB(_dbPath)

        'Remove tag
        tagToDelete =
            (From t In DB.Tags
             Where t.Id = tagId
             Select t).First

        DB.Tags.DeleteOnSubmit(tagToDelete)
        DB.SubmitChanges()
    End Sub

    ''' <summary>
    ''' Fills the data grid views for tags, selects the specified tag item
    ''' If no tag identifier is given, all tags are displayed
    ''' </summary>
    ''' <param name="grid">Tag grid object to fill</param>
    ''' <param name="indexToSelect">Tag identifier to highlight and select</param>
    ''' <param name="getAllTags">Specifies if all tags should be selected</param>
    ''' <remarks></remarks>
    Public Sub FillTagGrid(ByRef grid As DataGridView, _
                           ByVal indexToSelect As Integer, _
                           ByRef getAllTags As Boolean)

        'Create table object for tag list and fill it
        Dim tags As DataTable = Me.GetTagsForLog(_logName, getAllTags)

        'Only do this if there are tags
        If tags.Rows.Count > 0 Then
            'Put tags into grid if grid is specified
            If Not grid Is Nothing Then grid.DataSource = tags

            'Highlight and select specified row
            grid.Rows(indexToSelect).Selected = True
            grid.CurrentCell = grid.Item(1, indexToSelect)
        End If
    End Sub

    ''' <summary>
    ''' Fills the data grid views for log entries, selects the specified log entry item
    ''' If log entry identifier is -1, all log entries for the specified log are displayed
    ''' </summary>
    ''' <param name="grid">Log entry grid object to fill</param>
    ''' <param name="indexToSelect">Log entry identifier to highlight and select</param>
    ''' <remarks></remarks>
    Public Sub FillLogEntryGrid(ByRef grid As DataGridView, _
                                ByVal indexToSelect As Integer, _
                                ByVal tagIdToFilter As Integer, _
                                ByRef fillDetails As Boolean)

        'Create table object for log entry list and fill it
        Dim logEntries As DataTable = Me.GetLogEntriesForTag(tagIdToFilter, _logName)

        'Only do this if there are log entries
        If logEntries.Rows.Count > 0 Then
            'Put tags into grid if grid is specified
            If Not grid Is Nothing Then grid.DataSource = logEntries

            'Highlight and select specified row
            grid.Rows(indexToSelect).Selected = True
            grid.CurrentCell = grid.Item(1, indexToSelect)

            'Fill log entry details
            Dim logEntry As LogEntryData = Me.GetLogEntryDetails(logEntries.Rows.Item(0).Item(0))
            Me.FillBoxesWithLogEntryDetails(logEntry)
        End If
    End Sub

    ''' <summary>
    ''' Fills text boxes/date pickers/... with a LogEntryData object
    ''' </summary>
    ''' <param name="logEntryDetails">LogEntryData data object</param>
    ''' <remarks></remarks>
    Public Sub FillBoxesWithLogEntryDetails(ByRef logEntryDetails As LogEntryData)
        'Fill text boxes
        frmUiMockup.txtId.Text = logEntryDetails.Id.ToString
        frmUiMockup.txtLogType.Text = logEntryDetails.LogType
        frmUiMockup.txtName.Text = logEntryDetails.Name
        frmUiMockup.txtDescription.Text = logEntryDetails.Description
        frmUiMockup.txtPriority.Text = logEntryDetails.Priority
        frmUiMockup.txtStartDate.Text = logEntryDetails.StartDate
        frmUiMockup.txtEndDate.Text = logEntryDetails.EndDate
        frmUiMockup.txtActive.Text = logEntryDetails.Active
        frmUiMockup.txtInProgress.Text = logEntryDetails.InProgress
        frmUiMockup.txtFinished.Text = logEntryDetails.Finished
    End Sub

    Public Function InsertTagList(ByRef tagList As List(Of String))
        'TODO
        Return Nothing
    End Function

End Class
