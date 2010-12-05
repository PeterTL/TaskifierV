<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUiMockup
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.sc1forTabsAndMain = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.sc2forTagsAndTasks = New System.Windows.Forms.SplitContainer()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.sc3forTasksAndDetails = New System.Windows.Forms.SplitContainer()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        CType(Me.sc1forTabsAndMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sc1forTabsAndMain.Panel1.SuspendLayout()
        Me.sc1forTabsAndMain.Panel2.SuspendLayout()
        Me.sc1forTabsAndMain.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        CType(Me.sc2forTagsAndTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sc2forTagsAndTasks.Panel1.SuspendLayout()
        Me.sc2forTagsAndTasks.Panel2.SuspendLayout()
        Me.sc2forTagsAndTasks.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sc3forTasksAndDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sc3forTasksAndDetails.Panel1.SuspendLayout()
        Me.sc3forTasksAndDetails.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sc1forTabsAndMain
        '
        Me.sc1forTabsAndMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sc1forTabsAndMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sc1forTabsAndMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.sc1forTabsAndMain.IsSplitterFixed = True
        Me.sc1forTabsAndMain.Location = New System.Drawing.Point(0, 0)
        Me.sc1forTabsAndMain.Name = "sc1forTabsAndMain"
        '
        'sc1forTabsAndMain.Panel1
        '
        Me.sc1forTabsAndMain.Panel1.Controls.Add(Me.TabControl1)
        '
        'sc1forTabsAndMain.Panel2
        '
        Me.sc1forTabsAndMain.Panel2.Controls.Add(Me.sc2forTagsAndTasks)
        Me.sc1forTabsAndMain.Size = New System.Drawing.Size(717, 273)
        Me.sc1forTabsAndMain.SplitterDistance = 89
        Me.sc1forTabsAndMain.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.ItemSize = New System.Drawing.Size(30, 80)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(83, 256)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(100, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(0, 248)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Backlog"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(100, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(0, 248)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Worklog"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(100, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(0, 248)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Donelog"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'sc2forTagsAndTasks
        '
        Me.sc2forTagsAndTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sc2forTagsAndTasks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sc2forTagsAndTasks.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.sc2forTagsAndTasks.IsSplitterFixed = True
        Me.sc2forTagsAndTasks.Location = New System.Drawing.Point(0, 0)
        Me.sc2forTagsAndTasks.Name = "sc2forTagsAndTasks"
        '
        'sc2forTagsAndTasks.Panel1
        '
        Me.sc2forTagsAndTasks.Panel1.Controls.Add(Me.DataGridView1)
        '
        'sc2forTagsAndTasks.Panel2
        '
        Me.sc2forTagsAndTasks.Panel2.Controls.Add(Me.sc3forTasksAndDetails)
        Me.sc2forTagsAndTasks.Size = New System.Drawing.Size(624, 273)
        Me.sc2forTagsAndTasks.SplitterDistance = 144
        Me.sc2forTagsAndTasks.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ColumnHeadersVisible = False
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.Size = New System.Drawing.Size(142, 271)
        Me.DataGridView1.TabIndex = 0
        '
        'sc3forTasksAndDetails
        '
        Me.sc3forTasksAndDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sc3forTasksAndDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sc3forTasksAndDetails.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.sc3forTasksAndDetails.IsSplitterFixed = True
        Me.sc3forTasksAndDetails.Location = New System.Drawing.Point(0, 0)
        Me.sc3forTasksAndDetails.Name = "sc3forTasksAndDetails"
        '
        'sc3forTasksAndDetails.Panel1
        '
        Me.sc3forTasksAndDetails.Panel1.Controls.Add(Me.DataGridView2)
        Me.sc3forTasksAndDetails.Size = New System.Drawing.Size(476, 273)
        Me.sc3forTasksAndDetails.SplitterDistance = 188
        Me.sc3forTasksAndDetails.TabIndex = 0
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToOrderColumns = True
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.ColumnHeadersVisible = False
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView2.Size = New System.Drawing.Size(186, 271)
        Me.DataGridView2.TabIndex = 1
        '
        'frmUiMockup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 273)
        Me.Controls.Add(Me.sc1forTabsAndMain)
        Me.MinimumSize = New System.Drawing.Size(725, 300)
        Me.Name = "frmUiMockup"
        Me.Text = "frmUiMockup"
        Me.sc1forTabsAndMain.Panel1.ResumeLayout(False)
        Me.sc1forTabsAndMain.Panel2.ResumeLayout(False)
        CType(Me.sc1forTabsAndMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sc1forTabsAndMain.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.sc2forTagsAndTasks.Panel1.ResumeLayout(False)
        Me.sc2forTagsAndTasks.Panel2.ResumeLayout(False)
        CType(Me.sc2forTagsAndTasks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sc2forTagsAndTasks.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sc3forTasksAndDetails.Panel1.ResumeLayout(False)
        CType(Me.sc3forTasksAndDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sc3forTasksAndDetails.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sc1forTabsAndMain As System.Windows.Forms.SplitContainer
    Friend WithEvents sc2forTagsAndTasks As System.Windows.Forms.SplitContainer
    Friend WithEvents sc3forTasksAndDetails As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
End Class
