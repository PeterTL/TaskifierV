Imports System.Data.Linq.SqlClient

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
    ''' </summary>
    ''' <param name="strLogName">Log name, e.g. "Backlog".</param>
    ''' <returns>Data table with tags (id and name).</returns>
    ''' <remarks></remarks>
    Public Function GetTagsForLog(ByVal strLogName As String) As DataTable
        'Debug method parameters
        Debug.Print("")
        Debug.Print("Function GetTagsForLog started. Messages:")
        Debug.Print("Log Name: " & strLogName)

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
        Dim v = (From t In DB.Tags
                       Join lett In DB.LogEntriesToTags
                       On lett.TagId Equals t.Id
                       Join le In DB.LogEntries
                       On le.Id Equals lett.LogEntryId
                       Where le.LogType = strLogName
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
    ''' <param name="iTagId">Tag identifier.</param>
    ''' <param name="strLogName">Log name, e.g. "Backlog".</param>
    ''' <returns>Data table with tasks (id and name).</returns>
    ''' <remarks></remarks>
    Public Function GetTasksForTag(ByVal iTagId As Integer, ByVal strLogName As String) As DataTable
        'Debug method parameters
        Debug.Print("")
        Debug.Print("Function GetTasksForTag started. Messages:")
        Debug.Print("Tag ID: " & iTagId.ToString)
        Debug.Print("Log Name: " & strLogName)

        'Create (empty) table and column objects
        Dim dt As New DataTable("TasksForTagsAndLog")
        Dim dcId As New DataColumn("Id")
        Dim dcName As New DataColumn("Name")

        'Add columns to table
        dt.Columns.Add(dcId)
        dt.Columns.Add(dcName)

        'Create row and DB objects
        Dim dr As DataRow
        Dim DB As New TaskifierDB("Data/TaskifierDB.sdf")

        'Check if tag identifier is set
        Dim v
        If iTagId > -1 Then
            'Query DB for tasks, filter is tag and log type
            v = (From le In DB.LogEntries
                            Join lett In DB.LogEntriesToTags
                            On le.Id Equals lett.LogEntryId
                            Join t In DB.Tags
                            On lett.TagId Equals t.Id
                            Where le.LogType = strLogName
                            Where le.Active = True
                            Where t.Id = iTagId
                            Order By le.Name
                            Select le.Id, le.Name).Distinct
        Else
            'Query DB for tasks, filter is log type (NOT tag!)
            v = (From le In DB.LogEntries
                            Join lett In DB.LogEntriesToTags
                            On le.Id Equals lett.LogEntryId
                            Join t In DB.Tags
                            On lett.TagId Equals t.Id
                            Where le.LogType = strLogName
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

    Public Function GetTaskDetails(ByVal iTaskId As Integer) As DataTable
        'Debug method parameters
        Debug.Print("")
        Debug.Print("Function GetTaskDetails started. Messages:")
        Debug.Print("Tag ID: " & iTaskId.ToString)
        Return Nothing
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