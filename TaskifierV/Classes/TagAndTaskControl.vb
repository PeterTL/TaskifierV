Imports System.Data.Linq.SqlClient

Public Class TagAndTaskControl

    Private _dbPath As String

    ''' <summary>
    ''' Class constructor. Initializes the DB path.
    ''' </summary>
    ''' <param name="dbPath">Path to local DB.</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef dbPath As String)
        _dbPath = dbPath
    End Sub

    ''' <summary>
    ''' Returns a table with tags and their identifiers from the DB.
    ''' </summary>
    ''' <param name="logName">Log name, e.g. "Backlog".</param>
    ''' <returns>Data table with tags (id and name).</returns>
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
    ''' Returns a table with tasks and their identifiers from the DB.
    ''' </summary>
    ''' <param name="tagId">Tag identifier.</param>
    ''' <param name="logName">Log name, e.g. "Backlog".</param>
    ''' <returns>Data table with tasks (id and name).</returns>
    ''' <remarks></remarks>
    Public Function GetTasksForTag(ByVal tagId As Integer, ByVal logName As String) As DataTable
        'Debug method parameters
        Debug.Print("")
        Debug.Print("Function GetTasksForTag started. Messages:")
        Debug.Print("Log Name: " & logName)
        Debug.Print("Tag ID: " & tagId.ToString)

        'Create (empty) table and column objects
        Dim dt As New DataTable("TasksForTagsAndLog")
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
            'Query DB for tasks, filter is tag and log type
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
            'Query DB for tasks, filter is log type (NOT tag!)
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
    ''' Returns a LogEntryDataObject with one single log entry.
    ''' </summary>
    ''' <param name="logEntryId">Log entry identifier.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLogEntryDetails(ByVal logEntryId As Integer) As LogEntryData
        'Debug method parameters
        Debug.Print("")
        Debug.Print("Function GetTaskDetails started. Messages:")
        Debug.Print("Task ID: " & logEntryId.ToString)

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

    'TODO: Documentation
    Public Sub AddLogEntryToTag(ByVal tagId As Integer, ByVal logEntryId As Integer)
        'Debug method parameters
        Debug.Print("")
        Debug.Print("Function AddLogEntryToTask started. Messages:")
        Debug.Print("Log Entry ID: " & logEntryId.ToString)
        Debug.Print("Tag ID: " & tagId.ToString)

        'Create row and DB objects
        Dim v
        Dim DB As New TaskifierDB(_dbPath)

        'Check if task/tag combination already exists
        v = (From lett In DB.LogEntriesToTags
             Where lett.LogEntryId = logEntryId
             Where lett.TagId = tagId
             Select lett.Id).Count

        If v = 0 Then
            'Assign log entry to tag
            Dim newLogEntryToTask As New LogEntriesToTags With {.LogEntryId = logEntryId,
                                                                .TagId = tagId,
                                                                .Active = True,
                                                                .Comment = "Created by software not by mankind."}

            DB.LogEntriesToTags.InsertOnSubmit(newLogEntryToTask)
            DB.SubmitChanges()
        End If
    End Sub

    'TODO: Documentation
    Public Sub RemoveLogEntryFromTag(ByVal tagId As Integer, ByVal logEntryId As Integer)
        'Debug method parameters
        Debug.Print("")
        Debug.Print("Function RemoveLogEntryFromTask started. Messages:")
        Debug.Print("Log Entry ID: " & logEntryId.ToString)
        Debug.Print("Tag ID: " & tagId.ToString)

        'Create row and DB objects
        Dim v
        Dim DB As New TaskifierDB(_dbPath)

        'Remove log entry from tag
        Dim lettToDelete =
            (From lett In DB.LogEntriesToTags
             Where lett.TagId = tagId
             Where lett.LogEntryId = logEntryId
             Select lett).First

        DB.LogEntriesToTags.DeleteOnSubmit(lettToDelete)
        DB.SubmitChanges()

        'TODO: Implementation
        Debug.Print("Removing log entry #" & logEntryId & " from tag #" & tagId)

    End Sub

    Public Sub FillBoxesWithLogEntryDetails(ByRef taskDetails As LogEntryData)
        'Fill text boxes
        frmUiMockup.txtId.Text = taskDetails.Id.ToString
        frmUiMockup.txtLogType.Text = taskDetails.LogType
        frmUiMockup.txtName.Text = taskDetails.Name
        frmUiMockup.txtDescription.Text = taskDetails.Description
        frmUiMockup.txtPriority.Text = taskDetails.Priority
        frmUiMockup.txtStartDate.Text = taskDetails.StartDate
        frmUiMockup.txtEndDate.Text = taskDetails.EndDate
        frmUiMockup.txtActive.Text = taskDetails.Active
        frmUiMockup.txtInProgress.Text = taskDetails.InProgress
        frmUiMockup.txtFinished.Text = taskDetails.Finished
    End Sub

    Public Function InsertTagList(ByRef tagList As List(Of String))
        'TODO
        Return Nothing
    End Function

End Class
