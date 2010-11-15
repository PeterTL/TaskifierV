Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class TaskifierV

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

        Dim tbTag As New TagTextBox
        tbTag.Controls.Add(lbl.CreateTagLabel("Doofi", 0))
        Me.Controls.Add(tbTag)
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim lst As New List(Of String)
        lst.Add("Zeile 1")
        lst.Add("Zeile 2")
        lst.Add("Zeile 3")

        Dim tag As New TagControl()
        tag.DoIt(lst)

        'For Each item As String In lst
        '    Debug.Print(item)
        'Next
    End Sub
End Class


