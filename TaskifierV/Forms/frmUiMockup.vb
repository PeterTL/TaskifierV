Public Class frmUiMockup

    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        'Draw tabs
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
        'Create tag and task object
        Dim tc As New TagAndTaskControl

        Try
            'Get tags and fill first grid with Backlog tags
            Dim tags As DataTable = tc.GetTagsForLog("Backlog")
            DataGridView1.DataSource = tags

            'Get tasks and fill second grid with Backlog tasks
            Dim tasks As DataTable = tc.GetTasksForTag(-1, "Backlog")
            DataGridView2.DataSource = tasks

            'Hide system (id) columns
            DataGridView1.Columns("Id").Visible = False
            DataGridView2.Columns("Id").Visible = False
        Catch ex As Exception
            Debug.Print("")
            Debug.Print("Handler frmUiMockup_Load exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        'Create tag and task object
        Dim tc As New TagAndTaskControl

        Try
            'Get tags and fill first grid with tags according to selected log
            Dim tags As DataTable = tc.GetTagsForLog(TabControl1.SelectedTab.Text)
            DataGridView1.DataSource = tags

            'Get tasks and fill second grid with tags according to selected log
            Dim tasks As DataTable = tc.GetTasksForTag(-1, TabControl1.SelectedTab.Text)
            DataGridView2.DataSource = tasks
        Catch ex As Exception
            Debug.Print("")
            Debug.Print("Handler TabControl1_SelectedIndexChanged exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Create tag and task object
        Dim tc As New TagAndTaskControl

        Try
            'Get tasks and fill second grid with tags according to selected tag and log
            Dim tasks As DataTable = tc.GetTasksForTag(DataGridView1.CurrentRow.Cells(0).Value, TabControl1.SelectedTab.Text)
            DataGridView2.DataSource = tasks
        Catch ex As Exception
            Debug.Print("")
            Debug.Print("Handler DataGridView1_CellClick exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        'Create tag and task object
        Dim tc As New TagAndTaskControl

        Try
            'Get task details
            Dim task As LogEntryData = tc.GetTaskDetails(DataGridView2.CurrentRow.Cells(0).Value)

            'Fill text boxes
            txtId.Text = task.Id.ToString
            txtLogType.Text = task.LogType
            txtName.Text = task.Name
            txtDescription.Text = task.Description
            txtPriority.Text = task.Priority
            txtStartDate.Text = task.StartDate
            txtEndDate.Text = task.EndDate
            txtActive.Text = task.Active
            txtInProgress.Text = task.InProgress
            txtFinished.Text = task.Finished
        Catch ex As Exception
            Debug.Print("")
            Debug.Print("Handler DataGridView2_CellClick exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub
End Class