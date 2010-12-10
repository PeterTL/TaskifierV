Public Class frmUiMockup

    'Draws the tabs in a non-standard way
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

    'Fill grid and details with first task values
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

            'Get details for first task and fill text boxes
            Dim logEntry As LogEntryData = tatControl.GetLogEntryDetails(logEntries.Rows.Item(0).Item(0))
            tatControl.FillBoxesWithLogEntryDetails(logEntry)

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

    'Changes log and fills grid and details with first task values
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

            'Get details for first task and fill text boxes
            Dim logEntry As LogEntryData = tatControl.GetLogEntryDetails(logEntries.Rows.Item(0).Item(0))
            tatControl.FillBoxesWithLogEntryDetails(logEntry)
        Catch ex As Exception
            'Debug output
            Debug.Print("")
            Debug.Print("Handler TabControl1_SelectedIndexChanged exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

    'Fill grid with tasks according to selected tag/log and details with first task details
    Private Sub dgvTags_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTags.CellClick
        'Create tag and task object
        Dim tatControl As New TagAndTaskControl

        Try
            'Get tasks and fill second grid with tags according to selected tag and log
            Dim logEntries As DataTable = tatControl.GetTasksForTag(dgvTags.CurrentRow.Cells(0).Value, tcMain.SelectedTab.Text)
            dgvLogEntries.DataSource = logEntries

            'Get details for first task and fill text boxes
            Dim logEntry As LogEntryData = tatControl.GetLogEntryDetails(logEntries.Rows.Item(0).Item(0))
            tatControl.FillBoxesWithLogEntryDetails(logEntry)
        Catch ex As Exception
            'Debug output
            Debug.Print("")
            Debug.Print("Handler dgvTags_CellClick exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

    'Fills details of first tasks and enables drag-and-drop source
    Private Sub dgvLogEntries_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvLogEntries.MouseDown
        'Variable for source element index
        Dim index As Integer
        Dim id As Integer

        'Debug output
        Debug.Print("")
        Debug.Print("D&D start position")
        Debug.Print("X: " & e.X)
        Debug.Print("Y: " & e.Y)

        Try
            'Get index and id of source element
            index = dgvLogEntries.HitTest(e.X, e.Y).RowIndex
            id = dgvLogEntries.Rows(index).Cells("Id").Value

            'Create tag and task object
            Dim tatControl As New TagAndTaskControl

            'Get task details and fill text boxes
            Dim logEntry As LogEntryData = tatControl.GetLogEntryDetails(id)
            tatControl.FillBoxesWithLogEntryDetails(logEntry)

            'Only enable task drag and drop within the Backlog
            If tcMain.SelectedTab.Text = "Backlog" Then
                If index > -1 Then
                    'Highlight selected item an start d&d
                    dgvLogEntries.Rows(index).Selected = True
                    dgvLogEntries.DoDragDrop(index, DragDropEffects.Copy)
                End If
            End If
        Catch ex As Exception
            'Debug output
            Debug.Print("")
            Debug.Print("Handler dgvLogEntries_MouseDown exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

    'Sets drag-over effect for first grid
    Private Sub dgvTags_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvTags.DragOver
        e.Effect = DragDropEffects.Copy
    End Sub

    'Contains the drop part, reads source and destination identifiers and indexes
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

            'Highlight destination row
            dgvTags.Rows(destIndex).Selected = True

            'Debug output
            Debug.Print("")
            Debug.Print("D&D end position")
            Debug.Print("X: " & clientPoint.X)
            Debug.Print("Y: " & clientPoint.Y)

            'Debug output
            Debug.Print("")
            Debug.Print("Source ID: " & sourceId)
            Debug.Print("Source Index: " & sourceIndex)
            Debug.Print("Dest ID: " & destId)
            Debug.Print("Dest Index: " & destIndex)
        Catch ex As Exception
            'Debug output
            Debug.Print("")
            Debug.Print("Handler dgvTags_DragDrop exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

End Class