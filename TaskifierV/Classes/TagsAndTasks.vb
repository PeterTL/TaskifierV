﻿Imports System.Data.Linq.SqlClient

Public Class TagAndTaskControl

    'TODO: CreateTagBox: Method documentation
    Public Function CreateTagBox(ByRef loStrTags As List(Of String)) As TagTextBox
        'Step 1: Create TagTextBox
        Dim tb As New TagTextBox
        'Step 2: Create TagLabels
        Dim tl As New TagLabel
        Dim position As Integer = 0
        For Each strTag As String In loStrTags
            tl = tl.CreateTagLabel(strTag, position)
            tb.Controls.Add(tl)
            position += tl.Width + 4
        Next
        tb.Width = position + 4
        Return tb
    End Function

    ''' <summary>
    ''' Returns a table with tags and their identifiers from the DB.
    ''' The recoeds are filtered according to the given log string.
    ''' </summary>
    ''' <param name="strLogName">Log name, e.g. "Backlog".</param>
    ''' <returns>Data table with tags (id and name as strings).</returns>
    ''' <remarks></remarks>
    Public Function GetTagsForLog(ByVal strLogName As String) As DataTable
        'Create (empty) table and column objects
        Dim dt As New DataTable("TagsForLog")
        Dim dcId As New DataColumn("Id")
        Dim dcName As New DataColumn("Name")

        'Add columns to table
        dt.Columns.Add(dcId)
        dt.Columns.Add(dcName)

        'Create row and DB objects
        Dim dr As DataRow
        Dim DB As New TaskifierDB("Data/TaskifierDB.sdf")

        'Query DB for tags, filter is log type
        Dim v = From t In DB.Tags
                       Join lett In DB.LogEntriesToTags
                       On lett.TagId Equals t.Id
                       Join le In DB.LogEntries
                       On le.Id Equals lett.LogEntryId
                       Where le.LogType = strLogName
                       Where le.Active = True
                       Order By t.Name
                       Select t.Id, t.Name

        'Add default row
        dr = dt.NewRow()
        dr("Id") = "%"
        dr("Name") = "All"
        dt.Rows.Add(dr)

        'Add rows returned fro DB
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

    'This function is deprecated if everything works as I plan it to be
    ''''''''''''''''''
    'Public Function GetTagsForLog(ByVal strLog As String) As List(Of String)
    '    Dim lstTags As New List(Of String)
    '    Dim DB As New TaskifierDB("Data/TaskifierDB.sdf")
    '    Dim v = From t In DB.Tags
    '                   Join lett In DB.LogEntriesToTags
    '                   On lett.TagId Equals t.Id
    '                   Join le In DB.LogEntries
    '                   On le.Id Equals lett.LogEntryId
    '                   Where le.LogType = strLog
    '                   Where le.Active = True
    '                   Order By t.Name
    '                   Select t.Name
    '    For Each element In v
    '        lstTags.Add(element.ToString)
    '    Next
    '    DB = Nothing
    '    Return lstTags
    'End Function

    'TODO: GetTasksForTag: Switch from List(Of String) To DataTable
    'TODO: GetTasksForTag: Method documentation
    Public Function GetTasksForTag(ByVal strTag As String, ByVal strLogType As String) As List(Of String)
        Dim lstTasks As New List(Of String)
        Dim DB As New TaskifierDB("Data/TaskifierDB.sdf")
        Dim v = (From le In DB.LogEntries
                        Join lett In DB.LogEntriesToTags
                        On le.Id Equals lett.LogEntryId
                        Join t In DB.Tags
                        On lett.TagId Equals t.Id
                        Where le.LogType = strLogType
                        Where le.Active = True
                        Where SqlMethods.Like(t.Name, strTag)
                        Order By le.Name
                        Select le.Name).Distinct
        For Each element In v
            Console.WriteLine(element)
            lstTasks.Add(element.ToString)
        Next
        DB = Nothing
        Return lstTasks
    End Function


    Public Function InsertTagList(ByRef lstStrTags As List(Of String))
        'TODO
        Return Nothing
    End Function

End Class

Public Class TagTextBox
    Inherits TextBox

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.LightGray, 1, _
        ButtonBorderStyle.Solid, Color.LightGray, 1, ButtonBorderStyle.Solid, Color.LightGray, 1, _
        ButtonBorderStyle.Solid, Color.LightGray, 1, ButtonBorderStyle.Solid)
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Multiline = True
        Me.Height = 24
        'Me.Width = 300
        Me.Padding = New Padding(0, 0, 0, 0)
        Me.Margin = New Padding(0, 0, 0, 0)
    End Sub
End Class

Public Class TagLabel
    Inherits Label

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.LightGray, 1, _
        ButtonBorderStyle.Solid, Color.LightGray, 1, ButtonBorderStyle.Solid, Color.LightGray, 1, _
        ButtonBorderStyle.Solid, Color.LightGray, 1, ButtonBorderStyle.Solid)
    End Sub

    Public Function CreateTagLabel(ByRef strCaption As String, ByVal iPosX As Integer) As TagLabel
        Dim lbl As New TagLabel
        lbl.Height = 16
        lbl.Width = strCaption.Length * 8
        lbl.TextAlign = ContentAlignment.MiddleCenter
        lbl.BackColor = Color.AliceBlue
        lbl.Font = New Font("Lucida Console", 7, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        lbl.Text = strCaption
        'lbl.Padding = New Padding(0, 0, 0, 0)
        'lbl.Margin = New Padding(0, 0, 0, 0)
        'lbl.Location = New Point(strCaption.Length * 8 + 2, 0)
        lbl.Location = New Point(iPosX + 2, 2)
        lbl.Cursor = Cursors.Hand
        AddHandler lbl.MouseClick, AddressOf TagLabel_MouseClick

        Return (lbl)
    End Function

    Private Sub TagLabel_MouseClick()
        MsgBox("I was clicked.")
    End Sub
End Class