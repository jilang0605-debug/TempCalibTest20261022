





<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTempDisplayCalib
    Inherits System.Windows.Forms.Form
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Private components As System.ComponentModel.IContainer
    Friend WithEvents rootLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents topPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblInstrumentTitle As System.Windows.Forms.Label
    Friend WithEvents txtInstrument As System.Windows.Forms.TextBox
    Friend WithEvents lblManagementTitle As System.Windows.Forms.Label
    Friend WithEvents txtManagement As System.Windows.Forms.TextBox
    Friend WithEvents lblToleranceTitle As System.Windows.Forms.Label
    Friend WithEvents nudTolerance As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblToleranceUnit As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnReload As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents grpReference As System.Windows.Forms.GroupBox
    Friend WithEvents referenceLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvRef As System.Windows.Forms.DataGridView
    Friend WithEvents colRefTemp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCH1Measured As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCH1Error As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCH2Measured As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCH2Error As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents referenceButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAddReference As System.Windows.Forms.Button
    Friend WithEvents btnDeleteReference As System.Windows.Forms.Button
    Friend WithEvents sidesLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpHP As System.Windows.Forms.GroupBox
    Friend WithEvents hpLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvHP As System.Windows.Forms.DataGridView
    Friend WithEvents colHPValid As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colHPSetTemp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHPRefMeasured As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHPCalibrated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHPMeasuredAt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chartHP As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend chartAreaHP As System.Windows.Forms.DataVisualization.Charting.ChartArea
    Friend seriesHPMeasuredPoints As System.Windows.Forms.DataVisualization.Charting.Series
    Friend seriesHPRegressionLine As System.Windows.Forms.DataVisualization.Charting.Series
    Friend WithEvents hpBottomPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAddHP As System.Windows.Forms.Button
    Friend WithEvents btnDeleteHP As System.Windows.Forms.Button
    Friend WithEvents lblHPGain As System.Windows.Forms.Label
    Friend WithEvents lblHPBias As System.Windows.Forms.Label
    Friend WithEvents grpPB As System.Windows.Forms.GroupBox
    Friend WithEvents pbLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvPB As System.Windows.Forms.DataGridView
    Friend WithEvents colPBValid As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colPBSetTemp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPBRefMeasured As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPBCalibrated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPBMeasuredAt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chartPB As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend chartAreaPB As System.Windows.Forms.DataVisualization.Charting.ChartArea
    Friend seriesPBMeasuredPoints As System.Windows.Forms.DataVisualization.Charting.Series
    Friend seriesPBRegressionLine As System.Windows.Forms.DataVisualization.Charting.Series
    Friend WithEvents pbBottomPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAddPB As System.Windows.Forms.Button
    Friend WithEvents btnDeletePB As System.Windows.Forms.Button
    Friend WithEvents lblPBGain As System.Windows.Forms.Label
    Friend WithEvents lblPBBias As System.Windows.Forms.Label
    Friend WithEvents checkPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblCheckTitle As System.Windows.Forms.Label
    Friend WithEvents lblCheckHPTitle As System.Windows.Forms.Label
    Friend WithEvents nudCheckHP As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblCheckHPSetTempTitle As System.Windows.Forms.Label
    Friend WithEvents nudCheckHPSetTemp As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblHPResult As System.Windows.Forms.Label
    Friend WithEvents lblCheckPBTitle As System.Windows.Forms.Label
    Friend WithEvents nudCheckPB As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblCheckPBSetTempTitle As System.Windows.Forms.Label
    Friend WithEvents nudCheckPBSetTemp As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPBResult As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
		Dim ChartArea5 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
		Dim Series9 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
		Dim Series10 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
		Dim ChartArea6 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
		Dim Series11 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
		Dim Series12 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
		Me.rootLayout = New System.Windows.Forms.TableLayoutPanel()
		Me.topPanel = New System.Windows.Forms.FlowLayoutPanel()
		Me.lblInstrumentTitle = New System.Windows.Forms.Label()
		Me.txtInstrument = New System.Windows.Forms.TextBox()
		Me.lblManagementTitle = New System.Windows.Forms.Label()
		Me.txtManagement = New System.Windows.Forms.TextBox()
		Me.lblToleranceTitle = New System.Windows.Forms.Label()
		Me.nudTolerance = New System.Windows.Forms.NumericUpDown()
		Me.lblToleranceUnit = New System.Windows.Forms.Label()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.btnReload = New System.Windows.Forms.Button()
		Me.lblStatus = New System.Windows.Forms.Label()
		Me.cbxStdCalib = New System.Windows.Forms.ComboBox()
		Me.grpReference = New System.Windows.Forms.GroupBox()
		Me.referenceLayout = New System.Windows.Forms.TableLayoutPanel()
		Me.dgvRef = New System.Windows.Forms.DataGridView()
		Me.RefTemp = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.CH1Measured = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.CH1Error = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.CH2Measured = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.CH2Error = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.referenceButtons = New System.Windows.Forms.FlowLayoutPanel()
		Me.btnAddReference = New System.Windows.Forms.Button()
		Me.btnDeleteReference = New System.Windows.Forms.Button()
		Me.sidesLayout = New System.Windows.Forms.TableLayoutPanel()
		Me.grpHP = New System.Windows.Forms.GroupBox()
		Me.hpLayout = New System.Windows.Forms.TableLayoutPanel()
		Me.dgvHP = New System.Windows.Forms.DataGridView()
		Me.HPValid = New System.Windows.Forms.DataGridViewCheckBoxColumn()
		Me.HPSetTemp = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.HPRefMeasured = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.HPCalibrated = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.HPMeasuredAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.chartHP = New System.Windows.Forms.DataVisualization.Charting.Chart()
		Me.hpBottomPanel = New System.Windows.Forms.FlowLayoutPanel()
		Me.btnAddHP = New System.Windows.Forms.Button()
		Me.btnDeleteHP = New System.Windows.Forms.Button()
		Me.lblHPGain = New System.Windows.Forms.Label()
		Me.lblHPBias = New System.Windows.Forms.Label()
		Me.grpPB = New System.Windows.Forms.GroupBox()
		Me.pbLayout = New System.Windows.Forms.TableLayoutPanel()
		Me.dgvPB = New System.Windows.Forms.DataGridView()
		Me.PBValid = New System.Windows.Forms.DataGridViewCheckBoxColumn()
		Me.PBSetTemp = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.PBRefMeasured = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.PBCalibrated = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.PBMeasuredAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.chartPB = New System.Windows.Forms.DataVisualization.Charting.Chart()
		Me.pbBottomPanel = New System.Windows.Forms.FlowLayoutPanel()
		Me.btnAddPB = New System.Windows.Forms.Button()
		Me.btnDeletePB = New System.Windows.Forms.Button()
		Me.lblPBGain = New System.Windows.Forms.Label()
		Me.lblPBBias = New System.Windows.Forms.Label()
		Me.checkPanel = New System.Windows.Forms.FlowLayoutPanel()
		Me.lblCheckTitle = New System.Windows.Forms.Label()
		Me.lblCheckHPTitle = New System.Windows.Forms.Label()
		Me.nudCheckHP = New System.Windows.Forms.NumericUpDown()
		Me.lblCheckHPSetTempTitle = New System.Windows.Forms.Label()
		Me.nudCheckHPSetTemp = New System.Windows.Forms.NumericUpDown()
		Me.lblHPResult = New System.Windows.Forms.Label()
		Me.lblCheckPBTitle = New System.Windows.Forms.Label()
		Me.nudCheckPB = New System.Windows.Forms.NumericUpDown()
		Me.lblCheckPBSetTempTitle = New System.Windows.Forms.Label()
		Me.nudCheckPBSetTemp = New System.Windows.Forms.NumericUpDown()
		Me.lblPBResult = New System.Windows.Forms.Label()
		Me.rootLayout.SuspendLayout
		Me.topPanel.SuspendLayout
		CType(Me.nudTolerance,System.ComponentModel.ISupportInitialize).BeginInit
		Me.grpReference.SuspendLayout
		Me.referenceLayout.SuspendLayout
		CType(Me.dgvRef,System.ComponentModel.ISupportInitialize).BeginInit
		Me.referenceButtons.SuspendLayout
		Me.sidesLayout.SuspendLayout
		Me.grpHP.SuspendLayout
		Me.hpLayout.SuspendLayout
		CType(Me.dgvHP,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.chartHP,System.ComponentModel.ISupportInitialize).BeginInit
		Me.hpBottomPanel.SuspendLayout
		Me.grpPB.SuspendLayout
		Me.pbLayout.SuspendLayout
		CType(Me.dgvPB,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.chartPB,System.ComponentModel.ISupportInitialize).BeginInit
		Me.pbBottomPanel.SuspendLayout
		Me.checkPanel.SuspendLayout
		CType(Me.nudCheckHP,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.nudCheckHPSetTemp,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.nudCheckPB,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.nudCheckPBSetTemp,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'rootLayout
		'
		Me.rootLayout.ColumnCount = 1
		Me.rootLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
		Me.rootLayout.Controls.Add(Me.topPanel, 0, 0)
		Me.rootLayout.Controls.Add(Me.grpReference, 0, 1)
		Me.rootLayout.Controls.Add(Me.sidesLayout, 0, 2)
		Me.rootLayout.Controls.Add(Me.checkPanel, 0, 3)
		Me.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill
		Me.rootLayout.Location = New System.Drawing.Point(0, 0)
		Me.rootLayout.Name = "rootLayout"
		Me.rootLayout.Padding = New System.Windows.Forms.Padding(5)
		Me.rootLayout.RowCount = 4
		Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58!))
		Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30!))
		Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55!))
		Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65!))
		Me.rootLayout.Size = New System.Drawing.Size(1784, 1025)
		Me.rootLayout.TabIndex = 0
		'
		'topPanel
		'
		Me.topPanel.Controls.Add(Me.lblInstrumentTitle)
		Me.topPanel.Controls.Add(Me.txtInstrument)
		Me.topPanel.Controls.Add(Me.lblManagementTitle)
		Me.topPanel.Controls.Add(Me.txtManagement)
		Me.topPanel.Controls.Add(Me.lblToleranceTitle)
		Me.topPanel.Controls.Add(Me.nudTolerance)
		Me.topPanel.Controls.Add(Me.lblToleranceUnit)
		Me.topPanel.Controls.Add(Me.btnSave)
		Me.topPanel.Controls.Add(Me.cbxStdCalib)
		Me.topPanel.Controls.Add(Me.lblStatus)
		Me.topPanel.Controls.Add(Me.btnReload)
		Me.topPanel.Dock = System.Windows.Forms.DockStyle.Fill
		Me.topPanel.Location = New System.Drawing.Point(8, 8)
		Me.topPanel.Name = "topPanel"
		Me.topPanel.Padding = New System.Windows.Forms.Padding(5)
		Me.topPanel.Size = New System.Drawing.Size(1768, 52)
		Me.topPanel.TabIndex = 0
		Me.topPanel.WrapContents = false
		'
		'lblInstrumentTitle
		'
		Me.lblInstrumentTitle.AutoSize = true
		Me.lblInstrumentTitle.Location = New System.Drawing.Point(8, 13)
		Me.lblInstrumentTitle.Margin = New System.Windows.Forms.Padding(3, 8, 3, 3)
		Me.lblInstrumentTitle.Name = "lblInstrumentTitle"
		Me.lblInstrumentTitle.Size = New System.Drawing.Size(64, 18)
		Me.lblInstrumentTitle.TabIndex = 0
		Me.lblInstrumentTitle.Text = "装置番号"
		'
		'txtInstrument
		'
		Me.txtInstrument.Location = New System.Drawing.Point(78, 9)
		Me.txtInstrument.Margin = New System.Windows.Forms.Padding(3, 4, 3, 3)
		Me.txtInstrument.Name = "txtInstrument"
		Me.txtInstrument.Size = New System.Drawing.Size(100, 24)
		Me.txtInstrument.TabIndex = 1
		Me.txtInstrument.Text = "SZK014"
		'
		'lblManagementTitle
		'
		Me.lblManagementTitle.AutoSize = true
		Me.lblManagementTitle.Location = New System.Drawing.Point(191, 13)
		Me.lblManagementTitle.Margin = New System.Windows.Forms.Padding(10, 8, 3, 3)
		Me.lblManagementTitle.Name = "lblManagementTitle"
		Me.lblManagementTitle.Size = New System.Drawing.Size(64, 18)
		Me.lblManagementTitle.TabIndex = 2
		Me.lblManagementTitle.Text = "管理番号"
		'
		'txtManagement
		'
		Me.txtManagement.Location = New System.Drawing.Point(261, 9)
		Me.txtManagement.Margin = New System.Windows.Forms.Padding(3, 4, 3, 3)
		Me.txtManagement.Name = "txtManagement"
		Me.txtManagement.Size = New System.Drawing.Size(140, 24)
		Me.txtManagement.TabIndex = 3
		'
		'lblToleranceTitle
		'
		Me.lblToleranceTitle.AutoSize = true
		Me.lblToleranceTitle.Location = New System.Drawing.Point(414, 13)
		Me.lblToleranceTitle.Margin = New System.Windows.Forms.Padding(10, 8, 3, 3)
		Me.lblToleranceTitle.Name = "lblToleranceTitle"
		Me.lblToleranceTitle.Size = New System.Drawing.Size(94, 18)
		Me.lblToleranceTitle.TabIndex = 4
		Me.lblToleranceTitle.Text = "判定許容差 ±"
		'
		'nudTolerance
		'
		Me.nudTolerance.DecimalPlaces = 1
		Me.nudTolerance.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
		Me.nudTolerance.Location = New System.Drawing.Point(514, 9)
		Me.nudTolerance.Margin = New System.Windows.Forms.Padding(3, 4, 3, 3)
		Me.nudTolerance.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
		Me.nudTolerance.Name = "nudTolerance"
		Me.nudTolerance.Size = New System.Drawing.Size(75, 24)
		Me.nudTolerance.TabIndex = 5
		Me.nudTolerance.Value = New Decimal(New Integer() {5, 0, 0, 65536})
		'
		'lblToleranceUnit
		'
		Me.lblToleranceUnit.AutoSize = true
		Me.lblToleranceUnit.Location = New System.Drawing.Point(594, 13)
		Me.lblToleranceUnit.Margin = New System.Windows.Forms.Padding(2, 8, 3, 3)
		Me.lblToleranceUnit.Name = "lblToleranceUnit"
		Me.lblToleranceUnit.Size = New System.Drawing.Size(22, 18)
		Me.lblToleranceUnit.TabIndex = 6
		Me.lblToleranceUnit.Text = "℃"
		'
		'btnSave
		'
		Me.btnSave.Location = New System.Drawing.Point(634, 7)
		Me.btnSave.Margin = New System.Windows.Forms.Padding(15, 2, 3, 3)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(85, 30)
		Me.btnSave.TabIndex = 7
		Me.btnSave.Text = "保存"
		Me.btnSave.UseVisualStyleBackColor = true
		'
		'btnReload
		'
		Me.btnReload.Location = New System.Drawing.Point(1014, 7)
		Me.btnReload.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
		Me.btnReload.Name = "btnReload"
		Me.btnReload.Size = New System.Drawing.Size(125, 30)
		Me.btnReload.TabIndex = 8
		Me.btnReload.Text = "最新CSV再読込"
		Me.btnReload.UseVisualStyleBackColor = true
		Me.btnReload.Visible = false
		'
		'lblStatus
		'
		Me.lblStatus.AutoSize = true
		Me.lblStatus.Location = New System.Drawing.Point(940, 13)
		Me.lblStatus.Margin = New System.Windows.Forms.Padding(10, 8, 3, 3)
		Me.lblStatus.Name = "lblStatus"
		Me.lblStatus.Size = New System.Drawing.Size(68, 18)
		Me.lblStatus.TabIndex = 9
		Me.lblStatus.Text = "新規データ"
		'
		'cbxStdCalib
		'
		Me.cbxStdCalib.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbxStdCalib.Font = New System.Drawing.Font("Meiryo UI", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cbxStdCalib.FormattingEnabled = true
		Me.cbxStdCalib.Location = New System.Drawing.Point(725, 8)
		Me.cbxStdCalib.Name = "cbxStdCalib"
		Me.cbxStdCalib.Size = New System.Drawing.Size(202, 28)
		Me.cbxStdCalib.TabIndex = 10
		'
		'grpReference
		'
		Me.grpReference.Controls.Add(Me.referenceLayout)
		Me.grpReference.Dock = System.Windows.Forms.DockStyle.Fill
		Me.grpReference.Location = New System.Drawing.Point(8, 66)
		Me.grpReference.Name = "grpReference"
		Me.grpReference.Padding = New System.Windows.Forms.Padding(5)
		Me.grpReference.Size = New System.Drawing.Size(1768, 308)
		Me.grpReference.TabIndex = 1
		Me.grpReference.TabStop = false
		Me.grpReference.Text = "基準温度計 校正証明書データ（誤差は証明書記載値）"
		'
		'referenceLayout
		'
		Me.referenceLayout.ColumnCount = 1
		Me.referenceLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
		Me.referenceLayout.Controls.Add(Me.dgvRef, 0, 0)
		Me.referenceLayout.Controls.Add(Me.referenceButtons, 0, 1)
		Me.referenceLayout.Dock = System.Windows.Forms.DockStyle.Fill
		Me.referenceLayout.Location = New System.Drawing.Point(5, 22)
		Me.referenceLayout.Name = "referenceLayout"
		Me.referenceLayout.RowCount = 2
		Me.referenceLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
		Me.referenceLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38!))
		Me.referenceLayout.Size = New System.Drawing.Size(1758, 281)
		Me.referenceLayout.TabIndex = 0
		'
		'dgvRef
		'
		Me.dgvRef.AllowUserToAddRows = false
		Me.dgvRef.AllowUserToDeleteRows = false
		Me.dgvRef.BackgroundColor = System.Drawing.SystemColors.Window
		Me.dgvRef.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvRef.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RefTemp, Me.CH1Measured, Me.CH1Error, Me.CH2Measured, Me.CH2Error})
		Me.dgvRef.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvRef.Location = New System.Drawing.Point(3, 3)
		Me.dgvRef.MultiSelect = false
		Me.dgvRef.Name = "dgvRef"
		Me.dgvRef.RowHeadersVisible = false
		Me.dgvRef.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvRef.Size = New System.Drawing.Size(1752, 237)
		Me.dgvRef.TabIndex = 0
		'
		'RefTemp
		'
		Me.RefTemp.HeaderText = "基準温度"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"(℃)"
		Me.RefTemp.Name = "RefTemp"
		Me.RefTemp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.RefTemp.Width = 110
		'
		'CH1Measured
		'
		Me.CH1Measured.HeaderText = "CH1測定値"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"(℃)"
		Me.CH1Measured.Name = "CH1Measured"
		Me.CH1Measured.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.CH1Measured.Width = 115
		'
		'CH1Error
		'
		Me.CH1Error.HeaderText = "CH1誤差"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"(℃)"
		Me.CH1Error.Name = "CH1Error"
		Me.CH1Error.ReadOnly = true
		Me.CH1Error.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.CH1Error.Width = 105
		'
		'CH2Measured
		'
		Me.CH2Measured.HeaderText = "CH2測定値"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"(℃)"
		Me.CH2Measured.Name = "CH2Measured"
		Me.CH2Measured.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.CH2Measured.Width = 115
		'
		'CH2Error
		'
		Me.CH2Error.HeaderText = "CH2誤差"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"(℃)"
		Me.CH2Error.Name = "CH2Error"
		Me.CH2Error.ReadOnly = true
		Me.CH2Error.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.CH2Error.Width = 105
		'
		'referenceButtons
		'
		Me.referenceButtons.Controls.Add(Me.btnAddReference)
		Me.referenceButtons.Controls.Add(Me.btnDeleteReference)
		Me.referenceButtons.Dock = System.Windows.Forms.DockStyle.Fill
		Me.referenceButtons.Location = New System.Drawing.Point(3, 246)
		Me.referenceButtons.Name = "referenceButtons"
		Me.referenceButtons.Size = New System.Drawing.Size(1752, 32)
		Me.referenceButtons.TabIndex = 1
		Me.referenceButtons.WrapContents = false
		'
		'btnAddReference
		'
		Me.btnAddReference.Location = New System.Drawing.Point(3, 3)
		Me.btnAddReference.Name = "btnAddReference"
		Me.btnAddReference.Size = New System.Drawing.Size(100, 28)
		Me.btnAddReference.TabIndex = 0
		Me.btnAddReference.Text = "基準点追加"
		Me.btnAddReference.UseVisualStyleBackColor = true
		'
		'btnDeleteReference
		'
		Me.btnDeleteReference.Location = New System.Drawing.Point(109, 3)
		Me.btnDeleteReference.Name = "btnDeleteReference"
		Me.btnDeleteReference.Size = New System.Drawing.Size(100, 28)
		Me.btnDeleteReference.TabIndex = 1
		Me.btnDeleteReference.Text = "選択点削除"
		Me.btnDeleteReference.UseVisualStyleBackColor = true
		'
		'sidesLayout
		'
		Me.sidesLayout.ColumnCount = 2
		Me.sidesLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
		Me.sidesLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
		Me.sidesLayout.Controls.Add(Me.grpHP, 0, 0)
		Me.sidesLayout.Controls.Add(Me.grpPB, 1, 0)
		Me.sidesLayout.Dock = System.Windows.Forms.DockStyle.Fill
		Me.sidesLayout.Location = New System.Drawing.Point(8, 380)
		Me.sidesLayout.Name = "sidesLayout"
		Me.sidesLayout.RowCount = 1
		Me.sidesLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
		Me.sidesLayout.Size = New System.Drawing.Size(1768, 571)
		Me.sidesLayout.TabIndex = 2
		'
		'grpHP
		'
		Me.grpHP.Controls.Add(Me.hpLayout)
		Me.grpHP.Dock = System.Windows.Forms.DockStyle.Fill
		Me.grpHP.Location = New System.Drawing.Point(3, 3)
		Me.grpHP.Name = "grpHP"
		Me.grpHP.Padding = New System.Windows.Forms.Padding(5)
		Me.grpHP.Size = New System.Drawing.Size(878, 565)
		Me.grpHP.TabIndex = 0
		Me.grpHP.TabStop = false
		Me.grpHP.Text = "HP（CH1誤差）"
		'
		'hpLayout
		'
		Me.hpLayout.ColumnCount = 1
		Me.hpLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
		Me.hpLayout.Controls.Add(Me.dgvHP, 0, 0)
		Me.hpLayout.Controls.Add(Me.chartHP, 0, 1)
		Me.hpLayout.Controls.Add(Me.hpBottomPanel, 0, 2)
		Me.hpLayout.Dock = System.Windows.Forms.DockStyle.Fill
		Me.hpLayout.Location = New System.Drawing.Point(5, 22)
		Me.hpLayout.Name = "hpLayout"
		Me.hpLayout.RowCount = 3
		Me.hpLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48!))
		Me.hpLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42!))
		Me.hpLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40!))
		Me.hpLayout.Size = New System.Drawing.Size(868, 538)
		Me.hpLayout.TabIndex = 0
		'
		'dgvHP
		'
		Me.dgvHP.AllowUserToAddRows = false
		Me.dgvHP.AllowUserToDeleteRows = false
		Me.dgvHP.BackgroundColor = System.Drawing.SystemColors.Window
		Me.dgvHP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvHP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.HPValid, Me.HPSetTemp, Me.HPRefMeasured, Me.HPCalibrated, Me.HPMeasuredAt})
		Me.dgvHP.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvHP.Location = New System.Drawing.Point(3, 3)
		Me.dgvHP.MultiSelect = false
		Me.dgvHP.Name = "dgvHP"
		Me.dgvHP.RowHeadersVisible = false
		Me.dgvHP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvHP.Size = New System.Drawing.Size(862, 259)
		Me.dgvHP.TabIndex = 0
		'
		'HPValid
		'
		Me.HPValid.HeaderText = "有効"
		Me.HPValid.Name = "HPValid"
		Me.HPValid.Width = 50
		'
		'HPSetTemp
		'
		Me.HPSetTemp.HeaderText = "設定温度"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"(℃)"
		Me.HPSetTemp.Name = "HPSetTemp"
		Me.HPSetTemp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.HPSetTemp.Width = 90
		'
		'
		'HPRefMeasured
		'
		Me.HPRefMeasured.HeaderText = "基準温度計"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"(℃)"
		Me.HPRefMeasured.Name = "HPRefMeasured"
		Me.HPRefMeasured.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.HPRefMeasured.Width = 110
		'
		'
		'HPCalibrated
		'
		Me.HPCalibrated.HeaderText = "校正後温度"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"(℃)"
		Me.HPCalibrated.Name = "HPCalibrated"
		Me.HPCalibrated.ReadOnly = true
		Me.HPCalibrated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.HPCalibrated.Width = 105
		'
		'HPMeasuredAt
		'
		Me.HPMeasuredAt.HeaderText = "測定日時"
		Me.HPMeasuredAt.Name = "HPMeasuredAt"
		Me.HPMeasuredAt.ReadOnly = true
		Me.HPMeasuredAt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.HPMeasuredAt.Width = 135
		'
		'chartHP
		'
		ChartArea5.AxisX.Interval = 20R
		ChartArea5.AxisX.LabelStyle.Font = New System.Drawing.Font("Meiryo UI", 10!)
		ChartArea5.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray
		ChartArea5.AxisX.Maximum = 240R
		ChartArea5.AxisX.Minimum = 30R
		ChartArea5.AxisX.Title = "設定温度 (℃)"
		ChartArea5.AxisX.TitleFont = New System.Drawing.Font("Meiryo UI", 10!)
		ChartArea5.AxisY.Interval = 20R
		ChartArea5.AxisY.LabelStyle.Font = New System.Drawing.Font("Meiryo UI", 10!)
		ChartArea5.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray
		ChartArea5.AxisY.Maximum = 240R
		ChartArea5.AxisY.Minimum = 30R
		ChartArea5.AxisY.Title = "校正後温度 (℃)"
		ChartArea5.AxisY.TitleFont = New System.Drawing.Font("Meiryo UI", 10!)
		ChartArea5.Name = "Main"
		Me.chartHP.ChartAreas.Add(ChartArea5)
		Me.chartHP.Dock = System.Windows.Forms.DockStyle.Fill
		Me.chartHP.Location = New System.Drawing.Point(3, 268)
		Me.chartHP.Name = "chartHP"
		Series9.ChartArea = "Main"
		Series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
		Series9.MarkerSize = 7
		Series9.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
		Series9.Name = "MeasuredPoints"
		Series10.BorderWidth = 2
		Series10.ChartArea = "Main"
		Series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
		Series10.Name = "RegressionLine"
		Me.chartHP.Series.Add(Series9)
		Me.chartHP.Series.Add(Series10)
		Me.chartHP.Size = New System.Drawing.Size(862, 226)
		Me.chartHP.TabIndex = 1
		'
		'hpBottomPanel
		'
		Me.hpBottomPanel.Controls.Add(Me.btnAddHP)
		Me.hpBottomPanel.Controls.Add(Me.btnDeleteHP)
		Me.hpBottomPanel.Controls.Add(Me.lblHPGain)
		Me.hpBottomPanel.Controls.Add(Me.lblHPBias)
		Me.hpBottomPanel.Dock = System.Windows.Forms.DockStyle.Fill
		Me.hpBottomPanel.Location = New System.Drawing.Point(3, 500)
		Me.hpBottomPanel.Name = "hpBottomPanel"
		Me.hpBottomPanel.Size = New System.Drawing.Size(862, 35)
		Me.hpBottomPanel.TabIndex = 2
		Me.hpBottomPanel.WrapContents = false
		'
		'btnAddHP
		'
		Me.btnAddHP.Location = New System.Drawing.Point(3, 3)
		Me.btnAddHP.Name = "btnAddHP"
		Me.btnAddHP.Size = New System.Drawing.Size(95, 28)
		Me.btnAddHP.TabIndex = 0
		Me.btnAddHP.Text = "測定行追加"
		Me.btnAddHP.UseVisualStyleBackColor = true
		'
		'btnDeleteHP
		'
		Me.btnDeleteHP.Location = New System.Drawing.Point(104, 3)
		Me.btnDeleteHP.Name = "btnDeleteHP"
		Me.btnDeleteHP.Size = New System.Drawing.Size(95, 28)
		Me.btnDeleteHP.TabIndex = 1
		Me.btnDeleteHP.Text = "選択行削除"
		Me.btnDeleteHP.UseVisualStyleBackColor = true
		'
		'lblHPGain
		'
		Me.lblHPGain.AutoSize = true
		Me.lblHPGain.Location = New System.Drawing.Point(210, 8)
		Me.lblHPGain.Margin = New System.Windows.Forms.Padding(8, 8, 2, 2)
		Me.lblHPGain.Name = "lblHPGain"
		Me.lblHPGain.Size = New System.Drawing.Size(62, 18)
		Me.lblHPGain.TabIndex = 2
		Me.lblHPGain.Text = "Gain: --"
		'
		'lblHPBias
		'
		Me.lblHPBias.AutoSize = true
		Me.lblHPBias.Location = New System.Drawing.Point(282, 8)
		Me.lblHPBias.Margin = New System.Windows.Forms.Padding(8, 8, 2, 2)
		Me.lblHPBias.Name = "lblHPBias"
		Me.lblHPBias.Size = New System.Drawing.Size(59, 18)
		Me.lblHPBias.TabIndex = 3
		Me.lblHPBias.Text = "Bias: --"
		'
		'grpPB
		'
		Me.grpPB.Controls.Add(Me.pbLayout)
		Me.grpPB.Dock = System.Windows.Forms.DockStyle.Fill
		Me.grpPB.Location = New System.Drawing.Point(887, 3)
		Me.grpPB.Name = "grpPB"
		Me.grpPB.Padding = New System.Windows.Forms.Padding(5)
		Me.grpPB.Size = New System.Drawing.Size(878, 565)
		Me.grpPB.TabIndex = 1
		Me.grpPB.TabStop = false
		Me.grpPB.Text = "PB（CH2誤差）"
		'
		'pbLayout
		'
		Me.pbLayout.ColumnCount = 1
		Me.pbLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
		Me.pbLayout.Controls.Add(Me.dgvPB, 0, 0)
		Me.pbLayout.Controls.Add(Me.chartPB, 0, 1)
		Me.pbLayout.Controls.Add(Me.pbBottomPanel, 0, 2)
		Me.pbLayout.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pbLayout.Location = New System.Drawing.Point(5, 22)
		Me.pbLayout.Name = "pbLayout"
		Me.pbLayout.RowCount = 3
		Me.pbLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48!))
		Me.pbLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42!))
		Me.pbLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40!))
		Me.pbLayout.Size = New System.Drawing.Size(868, 538)
		Me.pbLayout.TabIndex = 0
		'
		'dgvPB
		'
		Me.dgvPB.AllowUserToAddRows = false
		Me.dgvPB.AllowUserToDeleteRows = false
		Me.dgvPB.BackgroundColor = System.Drawing.SystemColors.Window
		Me.dgvPB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvPB.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PBValid, Me.PBSetTemp, Me.PBRefMeasured, Me.PBCalibrated, Me.PBMeasuredAt})
		Me.dgvPB.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvPB.Location = New System.Drawing.Point(3, 3)
		Me.dgvPB.MultiSelect = false
		Me.dgvPB.Name = "dgvPB"
		Me.dgvPB.RowHeadersVisible = false
		Me.dgvPB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvPB.Size = New System.Drawing.Size(862, 259)
		Me.dgvPB.TabIndex = 0
		'
		'PBValid
		'
		Me.PBValid.HeaderText = "有効"
		Me.PBValid.Name = "PBValid"
		Me.PBValid.Width = 50
		'
		'PBSetTemp
		'
		Me.PBSetTemp.HeaderText = "設定温度"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"(℃)"
		Me.PBSetTemp.Name = "PBSetTemp"
		Me.PBSetTemp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.PBSetTemp.Width = 90
		'
		'
		'PBRefMeasured
		'
		Me.PBRefMeasured.HeaderText = "基準温度計"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"(℃)"
		Me.PBRefMeasured.Name = "PBRefMeasured"
		Me.PBRefMeasured.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.PBRefMeasured.Width = 110
		'
		'
		'PBCalibrated
		'
		Me.PBCalibrated.HeaderText = "校正後温度"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"(℃)"
		Me.PBCalibrated.Name = "PBCalibrated"
		Me.PBCalibrated.ReadOnly = true
		Me.PBCalibrated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.PBCalibrated.Width = 105
		'
		'PBMeasuredAt
		'
		Me.PBMeasuredAt.HeaderText = "測定日時"
		Me.PBMeasuredAt.Name = "PBMeasuredAt"
		Me.PBMeasuredAt.ReadOnly = true
		Me.PBMeasuredAt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.PBMeasuredAt.Width = 135
		'
		'chartPB
		'
		ChartArea6.AxisX.Interval = 20R
		ChartArea6.AxisX.LabelStyle.Font = New System.Drawing.Font("Meiryo UI", 10!)
		ChartArea6.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray
		ChartArea6.AxisX.Maximum = 240R
		ChartArea6.AxisX.Minimum = 30R
		ChartArea6.AxisX.Title = "設定温度 (℃)"
		ChartArea6.AxisX.TitleFont = New System.Drawing.Font("Meiryo UI", 10!)
		ChartArea6.AxisY.Interval = 20R
		ChartArea6.AxisY.LabelStyle.Font = New System.Drawing.Font("Meiryo UI", 10!)
		ChartArea6.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray
		ChartArea6.AxisY.Maximum = 240R
		ChartArea6.AxisY.Minimum = 30R
		ChartArea6.AxisY.Title = "校正後温度 (℃)"
		ChartArea6.AxisY.TitleFont = New System.Drawing.Font("Meiryo UI", 10!)
		ChartArea6.Name = "Main"
		Me.chartPB.ChartAreas.Add(ChartArea6)
		Me.chartPB.Dock = System.Windows.Forms.DockStyle.Fill
		Me.chartPB.Location = New System.Drawing.Point(3, 268)
		Me.chartPB.Name = "chartPB"
		Series11.ChartArea = "Main"
		Series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
		Series11.MarkerSize = 7
		Series11.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
		Series11.Name = "MeasuredPoints"
		Series12.BorderWidth = 2
		Series12.ChartArea = "Main"
		Series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
		Series12.Name = "RegressionLine"
		Me.chartPB.Series.Add(Series11)
		Me.chartPB.Series.Add(Series12)
		Me.chartPB.Size = New System.Drawing.Size(862, 226)
		Me.chartPB.TabIndex = 1
		'
		'pbBottomPanel
		'
		Me.pbBottomPanel.Controls.Add(Me.btnAddPB)
		Me.pbBottomPanel.Controls.Add(Me.btnDeletePB)
		Me.pbBottomPanel.Controls.Add(Me.lblPBGain)
		Me.pbBottomPanel.Controls.Add(Me.lblPBBias)
		Me.pbBottomPanel.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pbBottomPanel.Location = New System.Drawing.Point(3, 500)
		Me.pbBottomPanel.Name = "pbBottomPanel"
		Me.pbBottomPanel.Size = New System.Drawing.Size(862, 35)
		Me.pbBottomPanel.TabIndex = 2
		Me.pbBottomPanel.WrapContents = false
		'
		'btnAddPB
		'
		Me.btnAddPB.Location = New System.Drawing.Point(3, 3)
		Me.btnAddPB.Name = "btnAddPB"
		Me.btnAddPB.Size = New System.Drawing.Size(95, 28)
		Me.btnAddPB.TabIndex = 0
		Me.btnAddPB.Text = "測定行追加"
		Me.btnAddPB.UseVisualStyleBackColor = true
		'
		'btnDeletePB
		'
		Me.btnDeletePB.Location = New System.Drawing.Point(104, 3)
		Me.btnDeletePB.Name = "btnDeletePB"
		Me.btnDeletePB.Size = New System.Drawing.Size(95, 28)
		Me.btnDeletePB.TabIndex = 1
		Me.btnDeletePB.Text = "選択行削除"
		Me.btnDeletePB.UseVisualStyleBackColor = true
		'
		'lblPBGain
		'
		Me.lblPBGain.AutoSize = true
		Me.lblPBGain.Location = New System.Drawing.Point(210, 8)
		Me.lblPBGain.Margin = New System.Windows.Forms.Padding(8, 8, 2, 2)
		Me.lblPBGain.Name = "lblPBGain"
		Me.lblPBGain.Size = New System.Drawing.Size(62, 18)
		Me.lblPBGain.TabIndex = 2
		Me.lblPBGain.Text = "Gain: --"
		'
		'lblPBBias
		'
		Me.lblPBBias.AutoSize = true
		Me.lblPBBias.Location = New System.Drawing.Point(282, 8)
		Me.lblPBBias.Margin = New System.Windows.Forms.Padding(8, 8, 2, 2)
		Me.lblPBBias.Name = "lblPBBias"
		Me.lblPBBias.Size = New System.Drawing.Size(59, 18)
		Me.lblPBBias.TabIndex = 3
		Me.lblPBBias.Text = "Bias: --"
		'
		'checkPanel
		'
		Me.checkPanel.Controls.Add(Me.lblCheckTitle)
		Me.checkPanel.Controls.Add(Me.lblCheckHPTitle)
		Me.checkPanel.Controls.Add(Me.nudCheckHP)
		Me.checkPanel.Controls.Add(Me.lblCheckHPSetTempTitle)
		Me.checkPanel.Controls.Add(Me.nudCheckHPSetTemp)
		Me.checkPanel.Controls.Add(Me.lblHPResult)
		Me.checkPanel.Controls.Add(Me.lblCheckPBTitle)
		Me.checkPanel.Controls.Add(Me.nudCheckPB)
		Me.checkPanel.Controls.Add(Me.lblCheckPBSetTempTitle)
		Me.checkPanel.Controls.Add(Me.nudCheckPBSetTemp)
		Me.checkPanel.Controls.Add(Me.lblPBResult)
		Me.checkPanel.Dock = System.Windows.Forms.DockStyle.Fill
		Me.checkPanel.Location = New System.Drawing.Point(8, 957)
		Me.checkPanel.Name = "checkPanel"
		Me.checkPanel.Padding = New System.Windows.Forms.Padding(5)
		Me.checkPanel.Size = New System.Drawing.Size(1768, 60)
		Me.checkPanel.TabIndex = 3
		Me.checkPanel.AutoScroll = true
		Me.checkPanel.WrapContents = false
		'
		'lblCheckTitle
		'
		Me.lblCheckTitle.AutoSize = true
		Me.lblCheckTitle.Location = New System.Drawing.Point(8, 13)
		Me.lblCheckTitle.Margin = New System.Windows.Forms.Padding(3, 8, 8, 3)
		Me.lblCheckTitle.Name = "lblCheckTitle"
		Me.lblCheckTitle.Size = New System.Drawing.Size(92, 18)
		Me.lblCheckTitle.TabIndex = 0
		Me.lblCheckTitle.Text = "任意温度判定"
		'
		'lblCheckHPTitle
		'
		Me.lblCheckHPTitle.AutoSize = true
		Me.lblCheckHPTitle.Location = New System.Drawing.Point(111, 13)
		Me.lblCheckHPTitle.Margin = New System.Windows.Forms.Padding(3, 8, 3, 3)
		Me.lblCheckHPTitle.Name = "lblCheckHPTitle"
		Me.lblCheckHPTitle.Size = New System.Drawing.Size(82, 18)
		Me.lblCheckHPTitle.TabIndex = 1
		Me.lblCheckHPTitle.Text = "HP温度計読値 (℃)"
		'
		'nudCheckHP
		'
		Me.nudCheckHP.DecimalPlaces = 1
		Me.nudCheckHP.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
		Me.nudCheckHP.Location = New System.Drawing.Point(199, 9)
		Me.nudCheckHP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 3)
		Me.nudCheckHP.Maximum = New Decimal(New Integer() {240, 0, 0, 0})
		Me.nudCheckHP.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
		Me.nudCheckHP.Name = "nudCheckHP"
		Me.nudCheckHP.Size = New System.Drawing.Size(85, 24)
		Me.nudCheckHP.TabIndex = 2
		Me.nudCheckHP.Value = New Decimal(New Integer() {100, 0, 0, 0})
		'
		Me.lblCheckHPSetTempTitle.AutoSize = true
		Me.lblCheckHPSetTempTitle.Margin = New System.Windows.Forms.Padding(3, 8, 3, 3)
		Me.lblCheckHPSetTempTitle.Name = "lblCheckHPSetTempTitle"
		Me.lblCheckHPSetTempTitle.TabIndex = 3
		Me.lblCheckHPSetTempTitle.Text = "設定温度 (℃)"
		Me.nudCheckHPSetTemp.DecimalPlaces = 1
		Me.nudCheckHPSetTemp.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
		Me.nudCheckHPSetTemp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 3)
		Me.nudCheckHPSetTemp.Maximum = New Decimal(New Integer() {240, 0, 0, 0})
		Me.nudCheckHPSetTemp.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
		Me.nudCheckHPSetTemp.Name = "nudCheckHPSetTemp"
		Me.nudCheckHPSetTemp.TabIndex = 4
		Me.nudCheckHPSetTemp.Size = New System.Drawing.Size(85, 24)
		Me.nudCheckHPSetTemp.Value = New Decimal(New Integer() {100, 0, 0, 0})
		'lblHPResult
		'
		Me.lblHPResult.AutoSize = true
		Me.lblHPResult.Location = New System.Drawing.Point(292, 13)
		Me.lblHPResult.Margin = New System.Windows.Forms.Padding(5, 8, 15, 3)
		Me.lblHPResult.Name = "lblHPResult"
		Me.lblHPResult.Size = New System.Drawing.Size(49, 18)
		Me.lblHPResult.TabIndex = 5
		Me.lblHPResult.Text = "HP: --"
		'
		'lblCheckPBTitle
		'
		Me.lblCheckPBTitle.AutoSize = true
		Me.lblCheckPBTitle.Location = New System.Drawing.Point(359, 13)
		Me.lblCheckPBTitle.Margin = New System.Windows.Forms.Padding(3, 8, 3, 3)
		Me.lblCheckPBTitle.Name = "lblCheckPBTitle"
		Me.lblCheckPBTitle.Size = New System.Drawing.Size(81, 18)
		Me.lblCheckPBTitle.TabIndex = 6
		Me.lblCheckPBTitle.Text = "PB温度計読値 (℃)"
		'
		'nudCheckPB
		'
		Me.nudCheckPB.DecimalPlaces = 1
		Me.nudCheckPB.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
		Me.nudCheckPB.Location = New System.Drawing.Point(446, 9)
		Me.nudCheckPB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 3)
		Me.nudCheckPB.Maximum = New Decimal(New Integer() {240, 0, 0, 0})
		Me.nudCheckPB.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
		Me.nudCheckPB.Name = "nudCheckPB"
		Me.nudCheckPB.Size = New System.Drawing.Size(85, 24)
		Me.nudCheckPB.TabIndex = 7
		Me.nudCheckPB.Value = New Decimal(New Integer() {100, 0, 0, 0})
		'
		Me.lblCheckPBSetTempTitle.AutoSize = true
		Me.lblCheckPBSetTempTitle.Margin = New System.Windows.Forms.Padding(3, 8, 3, 3)
		Me.lblCheckPBSetTempTitle.Name = "lblCheckPBSetTempTitle"
		Me.lblCheckPBSetTempTitle.TabIndex = 8
		Me.lblCheckPBSetTempTitle.Text = "設定温度 (℃)"
		Me.nudCheckPBSetTemp.DecimalPlaces = 1
		Me.nudCheckPBSetTemp.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
		Me.nudCheckPBSetTemp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 3)
		Me.nudCheckPBSetTemp.Maximum = New Decimal(New Integer() {240, 0, 0, 0})
		Me.nudCheckPBSetTemp.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
		Me.nudCheckPBSetTemp.Name = "nudCheckPBSetTemp"
		Me.nudCheckPBSetTemp.TabIndex = 9
		Me.nudCheckPBSetTemp.Size = New System.Drawing.Size(85, 24)
		Me.nudCheckPBSetTemp.Value = New Decimal(New Integer() {100, 0, 0, 0})
		'lblPBResult
		'
		Me.lblPBResult.AutoSize = true
		Me.lblPBResult.Location = New System.Drawing.Point(539, 13)
		Me.lblPBResult.Margin = New System.Windows.Forms.Padding(5, 8, 3, 3)
		Me.lblPBResult.Name = "lblPBResult"
		Me.lblPBResult.Size = New System.Drawing.Size(48, 18)
		Me.lblPBResult.TabIndex = 10
		Me.lblPBResult.Text = "PB: --"
		'
		'frmTempDisplayCalib
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 17!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1784, 1025)
		Me.Controls.Add(Me.rootLayout)
		Me.Font = New System.Drawing.Font("Meiryo UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.MinimumSize = New System.Drawing.Size(1200, 750)
		Me.Name = "frmTempDisplayCalib"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "温度表示校正"
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.rootLayout.ResumeLayout(false)
		Me.topPanel.ResumeLayout(false)
		Me.topPanel.PerformLayout
		CType(Me.nudTolerance,System.ComponentModel.ISupportInitialize).EndInit
		Me.grpReference.ResumeLayout(false)
		Me.referenceLayout.ResumeLayout(false)
		CType(Me.dgvRef,System.ComponentModel.ISupportInitialize).EndInit
		Me.referenceButtons.ResumeLayout(false)
		Me.sidesLayout.ResumeLayout(false)
		Me.grpHP.ResumeLayout(false)
		Me.hpLayout.ResumeLayout(false)
		CType(Me.dgvHP,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.chartHP,System.ComponentModel.ISupportInitialize).EndInit
		Me.hpBottomPanel.ResumeLayout(false)
		Me.hpBottomPanel.PerformLayout
		Me.grpPB.ResumeLayout(false)
		Me.pbLayout.ResumeLayout(false)
		CType(Me.dgvPB,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.chartPB,System.ComponentModel.ISupportInitialize).EndInit
		Me.pbBottomPanel.ResumeLayout(false)
		Me.pbBottomPanel.PerformLayout
		Me.checkPanel.ResumeLayout(false)
		Me.checkPanel.PerformLayout
		CType(Me.nudCheckHP,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.nudCheckHPSetTemp,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.nudCheckPB,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.nudCheckPBSetTemp,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)

End Sub

	Friend WithEvents cbxStdCalib As ComboBox
	Friend WithEvents RefTemp As DataGridViewTextBoxColumn
	Friend WithEvents CH1Measured As DataGridViewTextBoxColumn
	Friend WithEvents CH1Error As DataGridViewTextBoxColumn
	Friend WithEvents CH2Measured As DataGridViewTextBoxColumn
	Friend WithEvents CH2Error As DataGridViewTextBoxColumn
	Friend WithEvents HPValid As DataGridViewCheckBoxColumn
	Friend WithEvents HPSetTemp As DataGridViewTextBoxColumn
	Friend WithEvents HPRefMeasured As DataGridViewTextBoxColumn
	Friend WithEvents HPCalibrated As DataGridViewTextBoxColumn
	Friend WithEvents HPMeasuredAt As DataGridViewTextBoxColumn
	Friend WithEvents PBValid As DataGridViewCheckBoxColumn
	Friend WithEvents PBSetTemp As DataGridViewTextBoxColumn
	Friend WithEvents PBRefMeasured As DataGridViewTextBoxColumn
	Friend WithEvents PBCalibrated As DataGridViewTextBoxColumn
	Friend WithEvents PBMeasuredAt As DataGridViewTextBoxColumn
End Class


