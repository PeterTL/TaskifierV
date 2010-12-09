Public Class frmUiMockup

    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles tcMain.DrawItem
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
            Dim tags As DataTable = tatControl.GetTagsForLog("Backlog", True)
            dgvTags.DataSource = tags

            'Get tasks and fill second grid with Backlog tasks
            Dim logEntries As DataTable = tatControl.GetTasksForTag(-1, "Backlog")
            dgvLogEntries.DataSource = logEntries

            'Hide system (id) columns
            dgvTags.Columns("Id").Visible = False
            dgvLogEntries.Columns("Id").Visible = False
        Catch ex As Exception
            'Debug output
            Debug.Print("")
            Debug.Print("Handler frmUiMockup_Load exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcMain.SelectedIndexChanged
        'Create tag and task object
        Dim tatControl As New TagAndTaskControl

        Try
            'Get tags and fill first grid with tags according to selected log
            'Get all tags when log is Backlog
            Dim getAll As Boolean = False
            If tcMain.SelectedTab.Text = "Backlog" Then getAll = True
            Dim tags As DataTable = tatControl.GetTagsForLog(tcMain.SelectedTab.Text, getAll)
            dgvTags.DataSource = tags

            'Get tasks and fill second grid with tags according to selected log
            Dim logEntries As DataTable = tatControl.GetTasksForTag(-1, tcMain.SelectedTab.Text)
            dgvLogEntries.DataSource = logEntries
        Catch ex As Exception
            'Debug output
            Debug.Print("")
            Debug.Print("Handler TabControl1_SelectedIndexChanged exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub dgvTags_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTags.CellClick
        'Create tag and task object
        Dim tatControl As New TagAndTaskControl

        Try
            'Get tasks and fill second grid with tags according to selected tag and log
            Dim logEntries As DataTable = tatControl.GetTasksForTag(dgvTags.CurrentRow.Cells(0).Value, tcMain.SelectedTab.Text)
            dgvLogEntries.DataSource = logEntries
        Catch ex As Exception
            'Debug output
            Debug.Print("")
            Debug.Print("Handler dgvTags_CellClick exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub dgvLogEntries_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLogEntries.CellClick
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
            'Debug output
            Debug.Print("")
            Debug.Print("Handler dgvLogEntries_CellClick exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

    'Drag and drop magic

    Private Sub dgvLogEntries_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvLogEntries.MouseDown
        'Only enable task drag and drop within the Backlog
        If tcMain.SelectedTab.Text = "Backlog" Then
            'Variable for source element index
            Dim index As Integer

            Try
                'Get index of source element
                index = dgvLogEntries.HitTest(e.X, e.Y).RowIndex

                If index > -1 Then
                    'Highlight selected item an start d&d
                    dgvLogEntries.Rows(index).Selected = True
                    dgvLogEntries.DoDragDrop(index, DragDropEffects.Copy)
                End If
            Catch ex As Exception
                'Debug output
                Debug.Print("")
                Debug.Print("Handler dgvLogEntries_MouseDown exited with error:")
                Debug.Print(ex.Message)
            End Try

            'Debug output
            Debug.Print("")
            Debug.Print("D&D start position")
            Debug.Print("X: " & e.X)
            Debug.Print("Y: " & e.Y)
        End If

    End Sub

    Private Sub dgvTags_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvTags.DragOver
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub dgvTags_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvTags.DragDrop
        'Variables for source row
        Dim sourceIndex As Integer
        Dim sourceId As String

        Try
            'Get identifier of source row
            sourceIndex = Convert.ToInt32(e.Data.GetData(Type.GetType("System.Int32")))
            sourceId = dgvLogEntries.Rows(sourceIndex).Cells("Id").Value.ToString

            'Variables for destination row
            Dim clientPoint As Point
            Dim destIndex As Integer
            Dim destId As String

            'Get identifier of destination row
            clientPoint = dgvTags.PointToClient(New Point(e.X, e.Y))
            destIndex = dgvTags.HitTest(clientPoint.X, clientPoint.Y).RowIndex
            destId = dgvTags.Rows(destIndex).Cells("Id").Value.ToString

            'Debug output
            Debug.Print("")
            Debug.Print("D&D end position")
            Debug.Print("X: " & clientPoint.X)
            Debug.Print("Y: " & clientPoint.Y)

            'Debug output
            Debug.Print("")
            Debug.Print("Source ID: " & sourceId)
            Debug.Print("Dest ID: " & destId)
        Catch ex As Exception
            'Debug output
            Debug.Print("")
            Debug.Print("Handler dgvTags_DragDrop exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

End Class