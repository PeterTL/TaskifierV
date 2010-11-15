Public Class TagControl

    Public Sub DoIt(ByRef loStrTags As List(Of String))
        For Each strTag As String In loStrTags
            Debug.Print(strTag)
        Next
    End Sub
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

    Public Function CreateTagLabel(ByRef strCaption As String, ByVal iPosX As Integer) As Label
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
        MsgBox("I was doubleclicked.")
    End Sub
End Class