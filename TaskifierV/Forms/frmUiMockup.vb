Public Class frmUiMockup

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

    Private Sub frmUiMockup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Columns.Add("Tags", "Tags")
        'Display default tag (all)
        DataGridView1.Rows.Add("All")
        'Display all tags
        'Dim tags_ = From Tags__ In Tags
        'Select Tags__.Name
        'Dim v = From k In LogEntries Select k

        Dim v = From k In LogEntries Select k.Id

        

        DataGridView1.Rows.Add("Tag 2")
        DataGridView1.Rows.Add("Tag 3")
        DataGridView1.Rows.Add("Tag 4")
        DataGridView1.Rows.Add("Tag 5")
        DataGridView1.Rows.Add("Tag 6")
    End Sub

End Class