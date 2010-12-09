﻿Imports System.Data.Linq.SqlClient

Public Class TagAndTaskControl

    ''' <summary>
    ''' Returns a table with tags and their identifiers from the DB.
    ''' </summary>
    ''' <param name="logName">Log name, e.g. "Backlog".</param>
    ''' <returns>Data table with tags (id and name).</returns>
    ''' <remarks></remarks>
    Public Function GetTagsForLog(ByVal logName As String) As DataTable
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
        Dim DB As New TaskifierDB("Data/TaskifierDB.sdf")

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
        Dim DB As New TaskifierDB("Data/TaskifierDB.sdf")

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
                            Join lett In DB.LogEntriesToTags
                            On le.Id Equals lett.LogEntryId
                            Join t In DB.Tags
                            On lett.TagId Equals t.Id
                            Where le.LogType = logName
                            Where le.Active = True
                            Order By le.Name
                            Select le.Id, le.Name).Distinct
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
    ''' Returns a LogEntryDataObject with one single log entry.
    ''' </summary>
    ''' <param name="logEntryId">Log entry identifier.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTaskDetails(ByVal logEntryId As Integer) As LogEntryData
        'Debug method parameters
        Debug.Print("")
        Debug.Print("Function GetTaskDetails started. Messages:")
        Debug.Print("Tag ID: " & logEntryId.ToString)

        'Create (empty) data object for log entry
        Dim ledat As New LogEntryData

        'Create row and DB objects
        Dim dr As DataRow
        Dim v
        Dim DB As New TaskifierDB("Data/TaskifierDB.sdf")

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
        dr = Nothing

        Return ledat
    End Function

    Public Function InsertTagList(ByRef tagList As List(Of String))
        'TODO
        Return Nothing
    End Function

End Class