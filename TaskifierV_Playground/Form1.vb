Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Label in TextBox
        Dim str As String
        str = "Hallo"
        Dim lbl As New TagLabel
        'lbl.Height = 16
        'lbl.Width = str.Length * 7
        'lbl.TextAlign = ContentAlignment.MiddleCenter
        'lbl.BackColor = Color.AliceBlue
        'lbl.Text = str
        'str.ToUpper()
        'Me.TextBox1.Controls.Add(lbl)
        Me.TextBox1.Controls.Add(lbl.CreateTagLabel("Doofi", 0))
        Me.TextBox1.Controls.Add(lbl.CreateTagLabel("ist", 41))
        Me.TextBox1.Controls.Add(lbl.CreateTagLabel("liiiiiieb", 66))
    End Sub

    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim g As Graphics
        Dim sText As String
        Dim iX As Integer
        Dim iY As Integer
        Dim sizeText As SizeF
        Dim ctlTab As TabControl

        ctlTab = CType(sender, TabControl)

        g = e.Graphics

        sText = ctlTab.TabPages(e.Index).Text
        sizeText = g.MeasureString(sText, ctlTab.Font)
        iX = e.Bounds.Left + 6
        iY = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2
        g.DrawString(sText, ctlTab.Font, Brushes.Black, iX, iY)
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
        'lbl.Padding = New Padding(100, 0, 0, 0)
        'lbl.Margin = New Padding(100, 0, 0, 0)
        'lbl.Location = New Point(strCaption.Length * 8 + 2, 0)
        lbl.Location = New Point(iPosX + 2, 2)

        AddHandler lbl.MouseDoubleClick, AddressOf TagLabel_OnDoubleClick

        Return (lbl)
    End Function

    Private Sub TagLabel_OnDoubleClick()
        MsgBox("I was doubleclicked.")
    End Sub
End Class
