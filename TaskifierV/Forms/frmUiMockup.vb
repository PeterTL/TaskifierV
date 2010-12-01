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
        'Reset tag grid
        DataGridView1.Columns.Clear()
        'Build up tag grid
        DataGridView1.Columns.Add("Tags", "Tags")
        'Display default tag (all)
        DataGridView1.Rows.Add("All")
        'Display all tags
        Dim tc As New TagAndTaskControl
        Dim tags As List(Of String)
        tags = tc.GetTagsForLog("Backlog")

        For Each element In tags
            DataGridView1.Rows.Add(element.ToString)
            'MsgBox(element.ToString)
        Next

        'TODO: implement initial task grid
        'Reset task grid
        DataGridView2.Columns.Clear()
        'Build up task grid
        DataGridView2.Columns.Add("Tasks", "Tasks")
        'Display tasks
        Dim tatc As New TagAndTaskControl
        Dim tasks As List(Of String)
        tasks = tatc.GetTasksForTag("%", "Donelog")
        For Each element In tasks
            DataGridView2.Rows.Add(element.ToString)
        Next
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        'Reset tag grid
        DataGridView1.Columns.Clear()
        'Build up tag grid
        DataGridView1.Columns.Add("Tags", "Tags")
        'Display default tag (all)
        DataGridView1.Rows.Add("All")
        'Display all tags
        Dim tc As New TagAndTaskControl
        Dim tags As List(Of String)
        tags = tc.GetTagsForLog(TabControl1.SelectedTab.Text)
        For Each element In tags
            DataGridView1.Rows.Add(element.ToString)
            'MsgBox(element.ToString)
        Next

        'Reset task grid
        DataGridView2.Columns.Clear()
        'Build up task grid
        DataGridView2.Columns.Add("Tasks", "Tasks")
        'Display tasks
        Dim tatc As New TagAndTaskControl
        Dim tasks As List(Of String)
        tasks = tatc.GetTasksForTag("%", TabControl1.SelectedTab.Text)
        For Each element In tasks
            DataGridView2.Rows.Add(element.ToString)
        Next
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Reset task grid
        DataGridView2.Columns.Clear()
        'Build up task grid
        DataGridView2.Columns.Add("Tasks", "Tasks")
        'Build filter for tasks
        Dim strFilter As String
        If DataGridView1.SelectedCells(0).Value = "All" Then
            strFilter = "%"
        Else
            strFilter = DataGridView1.SelectedCells(0).Value
        End If
        'Display tasks
        Dim tatc As New TagAndTaskControl
        Dim tasks As List(Of String)
        tasks = tatc.GetTasksForTag(strFilter, TabControl1.SelectedTab.Text)
        For Each element In tasks
            DataGridView2.Rows.Add(element.ToString)
        Next
    End Sub
End Class