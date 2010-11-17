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
        'Reset the grid
        DataGridView1.Columns.Clear()
        'Build up grid
        DataGridView1.Columns.Add("Tags", "Tags")
        'Display default tag (all)
        DataGridView1.Rows.Add("All")
        'Display all tags
        Dim tc As New TagControl
        Dim tags As List(Of String)
        tags = tc.GetTagsForLog("Backlog")

        For Each element In tags
            DataGridView1.Rows.Add(element.ToString)
            'MsgBox(element.ToString)
        Next
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        'Reset the grid
        DataGridView1.Columns.Clear()
        'Build up grid
        DataGridView1.Columns.Add("Tags", "Tags")
        'Display default tag (all)
        DataGridView1.Rows.Add("All")
        'Display all tags
        Dim tc As New TagControl
        Dim tags As List(Of String)
        tags = tc.GetTagsForLog(TabControl1.SelectedTab.Text)

        For Each element In tags
            DataGridView1.Rows.Add(element.ToString)
            'MsgBox(element.ToString)
        Next
    End Sub
End Class