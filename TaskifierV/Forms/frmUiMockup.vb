Public Class frmUiMockup

    Public dbPath As String

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
        'Take DB path from settings and overwrite it with command line value if given
        dbPath = My.Settings("DbPath").ToString

        Dim cmdLineArgs As Array = Environment.GetCommandLineArgs

        For Each cmdLineArg As String In cmdLineArgs
            If cmdLineArg.Substring(cmdLineArg.Length - 3) = "sdf" Then
                dbPath = cmdLineArg
                Exit For
            End If
        Next

        'Create tag and task object
        Dim tatControl As New TagAndTaskControl(dbPath)

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
        Dim tatControl As New TagAndTaskControl(dbPath)

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

    'Fills details of first tasks and enables drag-and-drop source
    Private Sub dgvLogEntries_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvLogEntries.MouseDown
        'Variable for source element index
        Dim index As Integer
        Dim id As Integer
        'Create tag and task object
        Dim tatControl As New TagAndTaskControl(dbPath)

        'Debug output
        Debug.Print("")
        Debug.Print("D&D start position")
        Debug.Print("X: " & e.X)
        Debug.Print("Y: " & e.Y)

        Try
            'Get index of source element
            index = dgvLogEntries.HitTest(e.X, e.Y).RowIndex

            'Only enable context menu strip for new items within Backlog
            If tcMain.SelectedTab.Text = "Backlog" Then
                tsmiNewLogEntry.Enabled = True
            Else
                tsmiNewLogEntry.Enabled = False
            End If

            'Check if the "white"space or the row were clicked
            If index > -1 Then
                'Row was clicked, enable context menu items for delete and rename
                tsmiDeleteLogEntry.Enabled = True
                tsmiRenameLogEntry.Enabled = True

                'Get identifier of right-clicked row
                id = dgvLogEntries.Rows(index).Cells("Id").Value

                'Get task details and fill text boxes
                Dim logEntry As LogEntryData = tatControl.GetLogEntryDetails(id)
                tatControl.FillBoxesWithLogEntryDetails(logEntry)

                'Highlight and set (!) selected item
                dgvLogEntries.Rows(index).Selected = True
                dgvLogEntries.CurrentCell = dgvLogEntries.Item(1, index)

                'Only do this if item was left-clicked (only in Backlog)
                If e.Button = MouseButtons.Left Then
                    'Only enable task drag and drop within the Backlog
                    If tcMain.SelectedTab.Text = "Backlog" Then
                        'Start d&d
                        dgvLogEntries.DoDragDrop(index, DragDropEffects.Copy)
                    End If
                End If
            Else
                '"White"space was clicked, disablecontext menu items for delete and rename
                tsmiDeleteLogEntry.Enabled = False
                tsmiRenameLogEntry.Enabled = False
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
        'Variables and objects
        Dim sourceIndex As Integer
        Dim sourceId As String
        Dim tatControl As New TagAndTaskControl(dbPath)

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

            'Highlight and set (!) destination row
            dgvTags.Rows(destIndex).Selected = True
            dgvTags.CurrentCell = dgvTags.Item(1, destIndex)

            'Assign task to log entry
            tatControl.AddLogEntryToTask(destId, sourceId)

            'Select log items according to (newly) selected tag
            Dim logEntries As DataTable = tatControl.GetTasksForTag(destId, "Backlog")
            dgvLogEntries.DataSource = logEntries

            'Get details for first task and fill text boxes
            'TODO: Newly added task should be highlighted and displayed
            'OLD: Dim logEntry As LogEntryData = tatControl.GetLogEntryDetails(logEntries.Rows.Item(0).Item(0))
            'Dim logEntry As LogEntryData = tatControl.GetLogEntryDetails(sourceId)
            'tatControl.FillBoxesWithLogEntryDetails(logEntry)

            'Debug output
            Debug.Print("")
            Debug.Print("D&D end position")
            Debug.Print("X: " & clientPoint.X)
            Debug.Print("Y: " & clientPoint.Y)

            'Debug output
            Debug.Print("")
            Debug.Print("Source (Log Entry) ID: " & sourceId)
            Debug.Print("Source (Log Entry) Index: " & sourceIndex)
            Debug.Print("Dest (Tag) ID: " & destId)
            Debug.Print("Dest (Tag) Index: " & destIndex)
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
        'Create tag and task object
        Dim tatControl As New TagAndTaskControl(dbPath)

        Try
            'Get index of right-clicked row
            index = dgvTags.HitTest(e.X, e.Y).RowIndex

            'Only enable context menu strip for new items within Backlog
            If tcMain.SelectedTab.Text = "Backlog" Then
                tsmiNewTag.Enabled = True
            Else
                tsmiNewTag.Enabled = False
            End If

            'Check if the "white"space or the row were clicked
            If index > -1 Then
                'Get index of clicked row
                id = dgvTags.Rows(index).Cells("Id").Value.ToString

                'If another tag than the default tag was selected
                If id > -1 Then
                    'Another tag was clicked, enable context menu strips
                    tsmiDeleteTag.Enabled = True
                    tsmiRenameTag.Enabled = True
                Else
                    'Default tag was clicked, disable context menu strips
                    tsmiDeleteTag.Enabled = False
                    tsmiRenameTag.Enabled = False
                End If

                'Get index of right-clicked row
                index = dgvTags.HitTest(e.X, e.Y).RowIndex

                'Get tasks and fill second grid with tags according to selected tag and log
                Dim logEntries As DataTable = tatControl.GetTasksForTag(id, tcMain.SelectedTab.Text)
                dgvLogEntries.DataSource = logEntries

                'Get details for first task and fill text boxes
                Dim logEntry As LogEntryData = tatControl.GetLogEntryDetails(logEntries.Rows.Item(0).Item(0))
                tatControl.FillBoxesWithLogEntryDetails(logEntry)

                'Highlight and set (!) right-clicked row
                dgvTags.Rows(index).Selected = True
                dgvTags.CurrentCell = dgvTags.Item(1, index)
            Else
                '"White"space was clicked, disablecontext menu items for delete and rename
                tsmiDeleteTag.Enabled = False
                tsmiRenameTag.Enabled = False
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
        'Please keep in mind when an item is to be renamed...
        '1. Keep in "mind" which tag and task were selected
        '2. Rename the item in the database
        '3. Refresh the grid
        '4. Re-select tag and task remembered under no. 1
    End Sub

    'Delete existing item from tag list via context menu
    Private Sub tsmiDeleteTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiDeleteTag.Click
        'Variables and objects
        Dim index As Integer
        Dim id As String
        Dim tatControl As New TagAndTaskControl(dbPath)

        Try
            'Get identifier row to be deleted
            index = dgvTags.CurrentRow.Index
            id = dgvTags.Rows(index).Cells("Id").Value.ToString

            'Only do this if the index is not -1 (which is default)
            If id <> -1 Then
                'Give the chance to cancel the action
                Dim dres As DialogResult = MessageBox.Show("Do you want to delete the selected tag?", _
                                                            "The Question", _
                                                            MessageBoxButtons.YesNoCancel, _
                                                            MessageBoxIcon.Question, _
                                                            MessageBoxDefaultButton.Button2)
                If dres = DialogResult.Yes Then
                    'TODO: Delete record
                    'Please keep in mind when an item is to be deleted...
                    '1. Check if item is in use within other tags
                    '2. If yes, maybe ask again?
                    '3. If yes, delete from tag and tag-to-log-entries tables
                    '4. Keep in mind the position(s) in the list
                End If
            End If
        Catch ex As Exception
            'Debug output
            Debug.Print("")
            Debug.Print("Handler tsmiRenameTag_Click exited with error:")
            Debug.Print(ex.Message)
        End Try
    End Sub

End Class