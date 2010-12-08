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
        Dim tatControl As New TagAndTaskControl

        Try
            'Get tags and fill first grid with Backlog tags
            Dim tags As DataTable = tatControl.GetTagsForLog("Backlog")
            dgvTags.DataSource = tags

            'Get tasks and fill second grid with Backlog tasks
            Dim logEntries As DataTable = tatControl.GetTasksForTag(-1, "Backlog")
            dgvLogEntries.DataSource = logEntries

            'Hide system (id) columns
            dgvTags.Columns("Id").Visible = False
            dgvLogEntries.Columns("Id").Visible = False
        Catch ex As Exception
            Debug.Print("")
            Debug.Print("Handler frmUiMockup_Load exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        'Create tag and task object
        Dim tatControl As New TagAndTaskControl

        Try
            'Get tags and fill first grid with tags according to selected log
            Dim tags As DataTable = tatControl.GetTagsForLog(TabControl1.SelectedTab.Text)
            dgvTags.DataSource = tags

            'Get tasks and fill second grid with tags according to selected log
            Dim logEntries As DataTable = tatControl.GetTasksForTag(-1, TabControl1.SelectedTab.Text)
            dgvLogEntries.DataSource = logEntries
        Catch ex As Exception
            Debug.Print("")
            Debug.Print("Handler TabControl1_SelectedIndexChanged exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTags.CellClick
        'Create tag and task object
        Dim tatControl As New TagAndTaskControl

        Try
            'Get tasks and fill second grid with tags according to selected tag and log
            Dim logEntries As DataTable = tatControl.GetTasksForTag(dgvTags.CurrentRow.Cells(0).Value, TabControl1.SelectedTab.Text)
            dgvLogEntries.DataSource = logEntries
        Catch ex As Exception
            Debug.Print("")
            Debug.Print("Handler DataGridView1_CellClick exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLogEntries.CellClick
        'Create tag and task object
        Dim tatControl As New TagAndTaskControl

        Try
            'Get task details
            Dim logEntry As LogEntryData = tatControl.GetTaskDetails(dgvLogEntries.CurrentRow.Cells(0).Value)

            'Fill text boxes
            txtId.Text = logEntry.Id.ToString
            txtLogType.Text = logEntry.LogType
            txtName.Text = logEntry.Name
            txtDescription.Text = logEntry.Description
            txtPriority.Text = logEntry.Priority
            txtStartDate.Text = logEntry.StartDate
            txtEndDate.Text = logEntry.EndDate
            txtActive.Text = logEntry.Active
            txtInProgress.Text = logEntry.InProgress
            txtFinished.Text = logEntry.Finished
        Catch ex As Exception
            Debug.Print("")
            Debug.Print("Handler DataGridView2_CellClick exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

End Class