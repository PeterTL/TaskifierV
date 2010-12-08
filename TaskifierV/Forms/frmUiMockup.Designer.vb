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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtPriority = New System.Windows.Forms.TextBox()
        Me.txtStartDate = New System.Windows.Forms.TextBox()
        Me.txtEndDate = New System.Windows.Forms.TextBox()
        Me.txtInProgress = New System.Windows.Forms.TextBox()
        Me.txtFinished = New System.Windows.Forms.TextBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtActive = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtLogType = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
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
        Me.sc3forTasksAndDetails.Panel2.SuspendLayout()
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
        Me.sc1forTabsAndMain.Size = New System.Drawing.Size(717, 280)
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
        Me.sc2forTagsAndTasks.Size = New System.Drawing.Size(624, 280)
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
        Me.DataGridView1.Size = New System.Drawing.Size(142, 278)
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
        '
        'sc3forTasksAndDetails.Panel2
        '
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.Label10)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.Label9)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.txtLogType)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.Label8)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.txtActive)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.txtId)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.txtFinished)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.txtInProgress)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.txtEndDate)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.txtStartDate)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.txtPriority)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.txtDescription)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.txtName)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.Label7)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.Label6)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.Label5)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.Label4)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.Label3)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.Label2)
        Me.sc3forTasksAndDetails.Panel2.Controls.Add(Me.Label1)
        Me.sc3forTasksAndDetails.Size = New System.Drawing.Size(476, 280)
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
        Me.DataGridView2.Size = New System.Drawing.Size(186, 278)
        Me.DataGridView2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Description:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Priority:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Start Date:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "End Date:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 222)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "In Progress:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 248)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Finished:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(86, 63)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(185, 20)
        Me.txtName.TabIndex = 7
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(86, 89)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(185, 20)
        Me.txtDescription.TabIndex = 8
        '
        'txtPriority
        '
        Me.txtPriority.Location = New System.Drawing.Point(86, 115)
        Me.txtPriority.Name = "txtPriority"
        Me.txtPriority.Size = New System.Drawing.Size(185, 20)
        Me.txtPriority.TabIndex = 9
        '
        'txtStartDate
        '
        Me.txtStartDate.Location = New System.Drawing.Point(86, 141)
        Me.txtStartDate.Name = "txtStartDate"
        Me.txtStartDate.Size = New System.Drawing.Size(185, 20)
        Me.txtStartDate.TabIndex = 10
        '
        'txtEndDate
        '
        Me.txtEndDate.Location = New System.Drawing.Point(86, 167)
        Me.txtEndDate.Name = "txtEndDate"
        Me.txtEndDate.Size = New System.Drawing.Size(185, 20)
        Me.txtEndDate.TabIndex = 11
        '
        'txtInProgress
        '
        Me.txtInProgress.Location = New System.Drawing.Point(86, 219)
        Me.txtInProgress.Name = "txtInProgress"
        Me.txtInProgress.Size = New System.Drawing.Size(185, 20)
        Me.txtInProgress.TabIndex = 12
        '
        'txtFinished
        '
        Me.txtFinished.Location = New System.Drawing.Point(86, 245)
        Me.txtFinished.Name = "txtFinished"
        Me.txtFinished.Size = New System.Drawing.Size(185, 20)
        Me.txtFinished.TabIndex = 13
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(86, 11)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(185, 20)
        Me.txtId.TabIndex = 14
        '
        'txtActive
        '
        Me.txtActive.Location = New System.Drawing.Point(86, 193)
        Me.txtActive.Name = "txtActive"
        Me.txtActive.Size = New System.Drawing.Size(185, 20)
        Me.txtActive.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(61, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Id:"
        '
        'txtLogType
        '
        Me.txtLogType.Location = New System.Drawing.Point(86, 37)
        Me.txtLogType.Name = "txtLogType"
        Me.txtLogType.Size = New System.Drawing.Size(185, 20)
        Me.txtLogType.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(25, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Log Type:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(39, 196)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Active:"
        '
        'frmUiMockup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 280)
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
        Me.sc3forTasksAndDetails.Panel2.ResumeLayout(False)
        Me.sc3forTasksAndDetails.Panel2.PerformLayout()
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
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtLogType As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtActive As System.Windows.Forms.TextBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents txtFinished As System.Windows.Forms.TextBox
    Friend WithEvents txtInProgress As System.Windows.Forms.TextBox
    Friend WithEvents txtEndDate As System.Windows.Forms.TextBox
    Friend WithEvents txtStartDate As System.Windows.Forms.TextBox
    Friend WithEvents txtPriority As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
