Public Class TagControl

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

    Public Function GetTagsForLog(ByVal strLog As String) As List(Of String)
        Dim lstTags As New List(Of String)
        Dim DB As New TaskifierDB("Data/TaskifierDB.sdf")
        Dim v = From t In DB.Tags
                       Join lett In DB.LogEntriesToTags
                       On lett.TagId Equals t.Id
                       Join le In DB.LogEntries
                       On le.Id Equals lett.LogEntryId
                       Where le.LogType = strLog
                       Where le.Active = True
                       Order By t.Name
                       Select t.Name
        For Each element In v
            lstTags.Add(element.ToString)
        Next
        DB = Nothing
        Return lstTags
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