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

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Drag and drop magic
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Impelement context menu for tag list (WIP)
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    'Hightlight the right-clicked record
    Private Sub dgvTags_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvTags.MouseDown
        'Variables for right-clicked row
        Dim index As Integer
        Dim id As String 'You never know when you need it...

        Try
            'Only do this when the right (sided) button is used
            If e.Button = MouseButtons.Right Then
                'New tags can only be created inside the Backlog
                If tcMain.SelectedTab.Text = "Backlog" Then
                    tsmiNewTag.Enabled = True
                Else
                    tsmiNewTag.Enabled = False
                End If

                'Get identifier of right-clicked row
                index = dgvTags.HitTest(e.X, e.Y).RowIndex
                id = dgvTags.Rows(index).Cells("Id").Value.ToString 'You never know when you need it...

                'Highlight and set (!) right-clicked row
                dgvTags.Rows(index).Selected = True
                dgvTags.CurrentCell = dgvTags.Item(1, index)
            End If
        Catch ex As Exception
            'Debug output
            Debug.Print("")
            Debug.Print("Handler dgvTags_MouseDown exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

    'Add new item to tag list via context menu
    Private Sub tsmiNewTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiNewTag.Click
        'Please keep in mind when a new item is added...
        '1. Add the item to the list
        '2. Keep in "mind" which tag and task were selected
        '3. Refresh the grid
        '4. Re-select tag and task remembered under no. 2
    End Sub

    'Rename existing item of tag list via context menu
    Private Sub tsmiRenameTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiRenameTag.Click

    End Sub

    'Delete existing item from tag list via context menu
    Private Sub tsmiDeleteTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiDeleteTag.Click
        'Variables for row to be deleted
        Dim index As Integer
        Dim id As String

        Try
            'Get identifier row to be deleted
            index = dgvTags.CurrentRow.Index
            id = dgvTags.Rows(index).Cells("Id").Value.ToString

            'Only do this if the index is not -1 (which is default)
            If id <> -1 Then
                'TODO: Delete record

            End If
        Catch ex As Exception
            'Debug output
            Debug.Print("")
            Debug.Print("Handler tsmiRenameTag_Click exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

End Class