Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting

''' <summary>
''' 温度表示校正フォーム。装置制御との接続は呼び出し側で実装する。
''' </summary>
Public Class frmTempDisplayCalib
    Private Const TEMP_MIN As Decimal = 30D
    Private Const TEMP_MAX As Decimal = 240D
    Private Const TEMP_STEP As Decimal = 0.1D
    Private Const CSV_VERSION As String = "TEMP_CALIB_V1"
    Private m_sInstrumentNo As String = "SZK014"
    Private m_bLoading As Boolean
    Private m_bDirty As Boolean = True
    Private m_bSaved As Boolean
    Private m_dHP_Gain As Double = Double.NaN
    Private m_dHP_Bias As Double = Double.NaN
    Private m_dPB_Gain As Double = Double.NaN
    Private m_dPB_Bias As Double = Double.NaN
	Private m_bUpdatingStdCalibList As Boolean = False
	Private m_sLoadedCalibPath As String = ""

    Public Property InstrumentNo As String
        Get
            Return m_sInstrumentNo
        End Get
        Set(value As String)
            Try
                If String.IsNullOrWhiteSpace(value) Then
                    Throw New ArgumentException("装置番号が未設定です。")
                End If
                m_sInstrumentNo = value.Trim()
                If txtInstrument IsNot Nothing Then txtInstrument.Text = m_sInstrumentNo
                MarkDirty()
            Catch ex As Exception
                WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
                Throw
            End Try
        End Set
    End Property

    ''' <summary>保存済みで未変更のHP/PB校正係数を取得する。</summary>
    Public Function TryGetCalibrationResult(ByRef hpGain As Double, ByRef hpBias As Double, ByRef pbGain As Double, ByRef pbBias As Double) As Boolean
        Try
            hpGain = 0
            hpBias = 0
            pbGain = 0
            pbBias = 0
            If Not m_bSaved OrElse m_bDirty Then Return False
            If Not RegressionAvailable(dgvHP) OrElse Not RegressionAvailable(dgvPB) Then Return False
            hpGain = m_dHP_Gain
            hpBias = m_dHP_Bias
            pbGain = m_dPB_Gain
            pbBias = m_dPB_Bias
            Return True
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            Return False
        End Try
    End Function

    Public Sub New()
        Try
            InitializeComponent()
            If LicenseManager.UsageMode = LicenseUsageMode.Designtime OrElse Me.DesignMode Then Return
            WireEvents()
            LoadLatestCsv()
            RecalculateAll()
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            MessageBox.Show("校正フォームの初期化に失敗しました。" & Environment.NewLine & ex.Message, "温度表示校正", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub WireEvents()
        Try
 			'DGVのカーソル選択
			dgvRef.SelectionMode = DataGridViewSelectionMode.CellSelect
			dgvHP.SelectionMode = DataGridViewSelectionMode.CellSelect
			dgvPB.SelectionMode = DataGridViewSelectionMode.CellSelect
	        AddHandler btnSave.Click, AddressOf SaveButtonClick
            'AddHandler btnReload.Click, AddressOf ReloadButtonClick
            AddHandler btnAddReference.Click, AddressOf AddReferenceClick
            AddHandler btnDeleteReference.Click, AddressOf DeleteReferenceClick
            AddHandler btnAddHP.Click, AddressOf AddHPClick
            AddHandler btnDeleteHP.Click, AddressOf DeleteHPClick
            AddHandler btnAddPB.Click, AddressOf AddPBClick
            AddHandler btnDeletePB.Click, AddressOf DeletePBClick
            AddHandler txtInstrument.TextChanged, AddressOf HeaderChanged
            AddHandler txtManagement.TextChanged, AddressOf HeaderChanged
            AddHandler nudTolerance.ValueChanged, AddressOf NumericChanged
            AddHandler nudCheckHP.ValueChanged, AddressOf NumericChanged
            AddHandler nudCheckPB.ValueChanged, AddressOf NumericChanged
            AddHandler dgvRef.CellEndEdit, AddressOf ReferenceCellEndEdit
            AddHandler dgvRef.CellValueChanged, AddressOf ReferenceChanged
            AddHandler dgvRef.CurrentCellDirtyStateChanged, AddressOf GridDirtyStateChanged
            AddHandler dgvRef.RowsRemoved, AddressOf ReferenceRowsRemoved
            AddHandler dgvHP.CellEndEdit, AddressOf MeasurementCellEndEdit
            AddHandler dgvPB.CellEndEdit, AddressOf MeasurementCellEndEdit
            AddHandler dgvHP.CellValueChanged, AddressOf MeasurementChanged
            AddHandler dgvPB.CellValueChanged, AddressOf MeasurementChanged
            AddHandler dgvHP.CurrentCellDirtyStateChanged, AddressOf GridDirtyStateChanged
            AddHandler dgvPB.CurrentCellDirtyStateChanged, AddressOf GridDirtyStateChanged
            AddHandler dgvHP.RowsRemoved, AddressOf MeasurementRowsRemoved
            AddHandler dgvPB.RowsRemoved, AddressOf MeasurementRowsRemoved

			cbxStdCalib.DropDownStyle = ComboBoxStyle.DropDownList
			AddHandler cbxStdCalib.SelectedIndexChanged, AddressOf StdCalibSelectedIndexChanged

			ApplyGridAlignment()
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            Throw
        End Try
    End Sub
''' <summary>
''' 数値表の文字揃えを設定
''' </summary>
Private Sub ApplyGridAlignment()
Try
    For Each col As DataGridViewColumn In dgvRef.Columns
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    Next
    For Each col As DataGridViewColumn In dgvHP.Columns
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    Next
    For Each col As DataGridViewColumn In dgvPB.Columns
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    Next
    dgvHP.Columns(GetDataColumnName(dgvHP, "Valid")).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    dgvPB.Columns(GetDataColumnName(dgvPB, "Valid")).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    dgvHP.Columns(GetDataColumnName(dgvHP, "MeasuredAt")).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    dgvPB.Columns(GetDataColumnName(dgvPB, "MeasuredAt")).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
Catch ex As Exception
    WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
End Try
End Sub
''' <summary>
''' 入力値を指定範囲内に制限する
''' </summary>
''' <param name="cell">対象セル</param>
''' <param name="minimum">最小値</param>
''' <param name="maximum">最大値</param>
Private Sub ClampCellValue(ByVal cell As DataGridViewCell, ByVal minimum As Double, ByVal maximum As Double)
Try
    If cell Is Nothing OrElse cell.ReadOnly Then Return
    Dim value As Double
    If Not ParseCell(cell.Value, value) Then Return
    If value < minimum Then
        cell.Value = minimum.ToString("0.0", CultureInfo.InvariantCulture)
    ElseIf value > maximum Then
        cell.Value = maximum.ToString("0.0", CultureInfo.InvariantCulture)
    End If
Catch ex As Exception
    WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
End Try
End Sub

    Private Sub AddReferenceClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim i As Integer = dgvRef.Rows.Add()
            For Each cell As DataGridViewCell In dgvRef.Rows(i).Cells
                cell.Value = ""
            Next
            dgvRef.CurrentCell = dgvRef.Rows(i).Cells("RefTemp")
            dgvRef.BeginEdit(True)
            MarkDirty()
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            ShowError(ex)
        End Try
    End Sub

    Private Sub DeleteReferenceClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            DeleteSelectedRow(dgvRef, "選択した基準点を削除しますか？")
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            ShowError(ex)
        End Try
    End Sub

    Private Sub AddHPClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            AddMeasurementRow(dgvHP)
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            ShowError(ex)
        End Try
    End Sub

    Private Sub AddPBClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            AddMeasurementRow(dgvPB)
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            ShowError(ex)
        End Try
    End Sub

    Private Sub AddMeasurementRow(ByVal dgv As DataGridView)
        Try
            Dim i As Integer = dgv.Rows.Add()
            dgv.Rows(i).Cells(GetDataColumnName(dgv, "Valid")).Value = True
            dgv.CurrentCell = dgv.Rows(i).Cells(GetDataColumnName(dgv, "SetTemp"))
            dgv.BeginEdit(True)
            MarkDirty()
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            ShowError(ex)
        End Try
    End Sub

    Private Sub DeleteHPClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            DeleteSelectedRow(dgvHP, "選択したHP測定行を削除しますか？")
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            ShowError(ex)
        End Try
    End Sub

    Private Sub DeletePBClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            DeleteSelectedRow(dgvPB, "選択したPB測定行を削除しますか？")
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            ShowError(ex)
        End Try
    End Sub

    Private Sub DeleteSelectedRow(ByVal dgv As DataGridView, ByVal prompt As String)
        Try
            If dgv.CurrentRow Is Nothing Then Return
            If MessageBox.Show(prompt, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
            dgv.Rows.Remove(dgv.CurrentRow)
            RecalculateAll()
            MarkDirty()
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            ShowError(ex)
        End Try
    End Sub

    Private Sub GridDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)
            If dgv.IsCurrentCellDirty Then dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
        End Try
    End Sub

    Private Sub ReferenceCellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        Try
			If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
				Dim columnName As String = dgvRef.Columns(e.ColumnIndex).Name
				Select Case columnName
			Case "RefTemp", "CH1Measured", "CH2Measured"
					ClampCellValue(dgvRef.Rows(e.RowIndex).Cells(e.ColumnIndex), CDbl(TEMP_MIN), CDbl(TEMP_MAX))
			Case "CH1Error", "CH2Error"
					ClampCellValue(dgvRef.Rows(e.RowIndex).Cells(e.ColumnIndex), -10.0R, 10.0R)
				End Select
			End If
            If e.RowIndex >= 0 Then
                Dim value As Double
                If ParseCell(dgvRef.Rows(e.RowIndex).Cells("RefTemp").Value, value) Then
                    For i As Integer = 0 To dgvRef.Rows.Count - 1
                        If i <> e.RowIndex Then
                            Dim other As Double
                            If ParseCell(dgvRef.Rows(i).Cells("RefTemp").Value, other) AndAlso Math.Abs(value - other) < 0.0000001R Then
                                MessageBox.Show("基準温度が重複しています。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                dgvRef.Rows(e.RowIndex).Cells("RefTemp").Value = ""
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
            RecalculateAll()
            MarkDirty()
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            ShowError(ex)
        End Try
    End Sub

    Private Sub MeasurementCellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        Try
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = dgv.Rows(e.RowIndex)

If e.ColumnIndex >= 0 Then
    Dim columnName As String = dgv.Columns(e.ColumnIndex).Name
    If columnName = GetDataColumnName(dgv, "SetTemp") OrElse
       columnName = GetDataColumnName(dgv, "DisplayTemp") OrElse
       columnName = GetDataColumnName(dgv, "RefMeasured") Then
        ClampCellValue(row.Cells(e.ColumnIndex), CDbl(TEMP_MIN), CDbl(TEMP_MAX))
    End If
End If

                If String.IsNullOrWhiteSpace(Convert.ToString(row.Cells(GetDataColumnName(row.DataGridView, "MeasuredAt")).Value)) AndAlso MeasurementValuesComplete(row) Then
                    row.Cells(GetDataColumnName(row.DataGridView, "MeasuredAt")).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                End If
            End If
            RecalculateAll()
            MarkDirty()
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            ShowError(ex)
        End Try
    End Sub

    Private Function MeasurementValuesComplete(ByVal row As DataGridViewRow) As Boolean
        Try
            Dim a As Double
            Dim b As Double
            Dim c As Double
            Return ParseCell(row.Cells(GetDataColumnName(row.DataGridView, "SetTemp")).Value, a) AndAlso ParseCell(row.Cells(GetDataColumnName(row.DataGridView, "DisplayTemp")).Value, b) AndAlso ParseCell(row.Cells(GetDataColumnName(row.DataGridView, "RefMeasured")).Value, c)
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub ReferenceChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        Try
            If Not m_bLoading Then
                RecalculateAll()
                MarkDirty()
            End If
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
        End Try
    End Sub

    Private Sub ReferenceRowsRemoved(ByVal sender As Object, ByVal e As DataGridViewRowsRemovedEventArgs)
        Try
            If Not m_bLoading Then
                RecalculateAll()
                MarkDirty()
            End If
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
        End Try
    End Sub

    Private Sub MeasurementChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        Try
            If Not m_bLoading Then
                RecalculateAll()
                MarkDirty()
            End If
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
        End Try
    End Sub

    Private Sub MeasurementRowsRemoved(ByVal sender As Object, ByVal e As DataGridViewRowsRemovedEventArgs)
        Try
            If Not m_bLoading Then
                RecalculateAll()
                MarkDirty()
            End If
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
        End Try
    End Sub

    Private Sub HeaderChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Not m_bLoading Then
                m_sInstrumentNo = txtInstrument.Text.Trim()
                MarkDirty()
            End If
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
        End Try
    End Sub

    Private Sub NumericChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Not m_bLoading Then
                RecalculateAll()
                MarkDirty()
            End If
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
        End Try
    End Sub

    Private Sub RecalculateAll()
        Try
            If m_bLoading OrElse dgvRef Is Nothing OrElse dgvHP Is Nothing OrElse dgvPB Is Nothing Then Return
            RecalculateMeasurements(dgvHP, True)
            RecalculateMeasurements(dgvPB, False)
            RecalculateRegression(dgvHP, chartHP, lblHPGain, lblHPBias, True)
            RecalculateRegression(dgvPB, chartPB, lblPBGain, lblPBBias, False)
            lblHPResult.Text = CheckResult(CDbl(nudCheckHP.Value), m_dHP_Gain, m_dHP_Bias, nudTolerance.Value)
            lblPBResult.Text = CheckResult(CDbl(nudCheckPB.Value), m_dPB_Gain, m_dPB_Bias, nudTolerance.Value)
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
        End Try
    End Sub

    Private Sub RecalculateMeasurements(ByVal dgv As DataGridView, ByVal isHP As Boolean)
        Try
            For Each row As DataGridViewRow In dgv.Rows
                Dim refTemp As Double
                Dim errorValue As Double
                If ParseCell(row.Cells(GetDataColumnName(row.DataGridView, "RefMeasured")).Value, refTemp) AndAlso TryInterpolateError(refTemp, isHP, errorValue) Then
                    row.Cells(GetDataColumnName(row.DataGridView, "Error")).Value = errorValue.ToString("0.0000", CultureInfo.InvariantCulture)
                    row.Cells(GetDataColumnName(row.DataGridView, "Calibrated")).Value = (refTemp - errorValue).ToString("0.0000", CultureInfo.InvariantCulture)
                Else
                    row.Cells(GetDataColumnName(row.DataGridView, "Error")).Value = ""
                    row.Cells(GetDataColumnName(row.DataGridView, "Calibrated")).Value = ""
                End If
            Next
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
        End Try
    End Sub

    Private Function TryInterpolateError(ByVal temp As Double, ByVal isHP As Boolean, ByRef errorValue As Double) As Boolean
        Try
            errorValue = 0
            If temp < CDbl(TEMP_MIN) OrElse temp > CDbl(TEMP_MAX) Then Return False
            Dim pts As New List(Of KeyValuePair(Of Double, Double))
            For Each row As DataGridViewRow In dgvRef.Rows
                Dim x As Double
                Dim y As Double
                If ParseCell(row.Cells(GetDataColumnName(row.DataGridView, "RefTemp")).Value, x) AndAlso ParseCell(row.Cells(If(isHP, "CH1Error", "CH2Error")).Value, y) Then
                    If pts.Any(Function(p) Math.Abs(p.Key - x) < 0.0000001R) Then Return False
                    pts.Add(New KeyValuePair(Of Double, Double)(x, y))
                End If
            Next
            If pts.Count < 2 Then Return False
            pts = pts.OrderBy(Function(p) p.Key).ToList()
            Dim p1 As KeyValuePair(Of Double, Double) = pts(0)
            Dim p2 As KeyValuePair(Of Double, Double) = pts(1)
            If temp >= pts(pts.Count - 1).Key Then
                p1 = pts(pts.Count - 2)
                p2 = pts(pts.Count - 1)
            ElseIf temp > pts(0).Key Then
                For i As Integer = 0 To pts.Count - 2
                    If temp >= pts(i).Key AndAlso temp <= pts(i + 1).Key Then
                        p1 = pts(i)
                        p2 = pts(i + 1)
                        Exit For
                    End If
                Next
            End If
            If Math.Abs(p2.Key - p1.Key) < 0.0000001R Then Return False
            errorValue = p1.Value + (temp - p1.Key) * (p2.Value - p1.Value) / (p2.Key - p1.Key)
            Return Not Double.IsNaN(errorValue) AndAlso Not Double.IsInfinity(errorValue)
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub RecalculateRegression(ByVal dgv As DataGridView, ByVal ch As Chart, ByVal gainLabel As Label, ByVal biasLabel As Label, ByVal isHP As Boolean)
        Try
            Dim pts As New List(Of KeyValuePair(Of Double, Double))
            For Each row As DataGridViewRow In dgv.Rows
                Dim valid As Boolean = False
                If row.Cells(GetDataColumnName(row.DataGridView, "Valid")).Value IsNot Nothing Then Boolean.TryParse(Convert.ToString(row.Cells(GetDataColumnName(row.DataGridView, "Valid")).Value), valid)
                Dim x As Double
                Dim y As Double
                If valid AndAlso ParseCell(row.Cells(GetDataColumnName(row.DataGridView, "SetTemp")).Value, x) AndAlso ParseCell(row.Cells(GetDataColumnName(row.DataGridView, "Calibrated")).Value, y) Then
                    If x >= CDbl(TEMP_MIN) AndAlso x <= CDbl(TEMP_MAX) Then pts.Add(New KeyValuePair(Of Double, Double)(x, y))
                End If
            Next
            ch.Series("MeasuredPoints").Points.Clear()
            ch.Series("RegressionLine").Points.Clear()
            For Each p In pts
                ch.Series("MeasuredPoints").Points.AddXY(p.Key, p.Value)
            Next
            If pts.Count < 2 Then
                SetRegressionInvalid(isHP)
                gainLabel.Text = "Gain: --"
                biasLabel.Text = "Bias: --"
                Return
            End If
            Dim meanX As Double = pts.Average(Function(p) p.Key)
            Dim meanY As Double = pts.Average(Function(p) p.Value)
            Dim sxx As Double = pts.Sum(Function(p) (p.Key - meanX) * (p.Key - meanX))
            Dim sxy As Double = pts.Sum(Function(p) (p.Key - meanX) * (p.Value - meanY))
            If sxx <= 0.0000000001R Then
                SetRegressionInvalid(isHP)
                gainLabel.Text = "Gain: --"
                biasLabel.Text = "Bias: --"
                Return
            End If
            Dim gain As Double = sxy / sxx
            Dim bias As Double = meanY - gain * meanX
            If Double.IsNaN(gain) OrElse Double.IsInfinity(gain) OrElse Double.IsNaN(bias) OrElse Double.IsInfinity(bias) Then
                SetRegressionInvalid(isHP)
                Return
            End If
            If isHP Then
                m_dHP_Gain = gain
                m_dHP_Bias = bias
            Else
                m_dPB_Gain = gain
                m_dPB_Bias = bias
            End If
            gainLabel.Text = "Gain: " & gain.ToString("0.0000", CultureInfo.InvariantCulture)
            biasLabel.Text = "Bias: " & bias.ToString("0.0", CultureInfo.InvariantCulture)
            Dim minX As Double = pts.Min(Function(p) p.Key)
            Dim maxX As Double = pts.Max(Function(p) p.Key)
            ch.Series("RegressionLine").Points.AddXY(minX, gain * minX + bias)
            ch.Series("RegressionLine").Points.AddXY(maxX, gain * maxX + bias)
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
        End Try
    End Sub

    Private Sub SetRegressionInvalid(ByVal isHP As Boolean)
        Try
            If isHP Then
                m_dHP_Gain = Double.NaN
                m_dHP_Bias = Double.NaN
            Else
                m_dPB_Gain = Double.NaN
                m_dPB_Bias = Double.NaN
            End If
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
        End Try
    End Sub

    Private Function RegressionAvailable(ByVal dgv As DataGridView) As Boolean
        Try
            Dim pts As New List(Of Double)
            For Each row As DataGridViewRow In dgv.Rows
                Dim valid As Boolean = False
                If row.Cells(GetDataColumnName(row.DataGridView, "Valid")).Value IsNot Nothing Then Boolean.TryParse(Convert.ToString(row.Cells(GetDataColumnName(row.DataGridView, "Valid")).Value), valid)
                Dim x As Double
                Dim y As Double
                If valid AndAlso ParseCell(row.Cells(GetDataColumnName(row.DataGridView, "SetTemp")).Value, x) AndAlso ParseCell(row.Cells(GetDataColumnName(row.DataGridView, "Calibrated")).Value, y) Then pts.Add(x)
            Next
            Return pts.Count >= 2 AndAlso pts.Max() - pts.Min() > 0.0000001R
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            Return False
        End Try
    End Function

    Private Function CheckResult(ByVal setTemp As Double, ByVal gain As Double, ByVal bias As Double, ByVal tolerance As Decimal) As String
        Try
            If Double.IsNaN(gain) OrElse Double.IsNaN(bias) OrElse Double.IsInfinity(gain) OrElse Double.IsInfinity(bias) Then Return "結果: --"
            Dim delta As Double = gain * setTemp + bias - setTemp
            Return If(Math.Abs(delta) <= CDbl(tolerance), "PASS", "FAIL") & " (ΔT=" & delta.ToString("+0.000;-0.000;0.000", CultureInfo.InvariantCulture) & "℃)"
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            Return "結果: --"
        End Try
    End Function

    Private Function ParseCell(ByVal value As Object, ByRef result As Double) As Boolean
        Try
            result = 0
            If value Is Nothing OrElse value Is DBNull.Value Then Return False
            Dim s As String = Convert.ToString(value, CultureInfo.InvariantCulture).Trim()
            If s = "" Then Return False
            Return Double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, result) AndAlso Not Double.IsNaN(result) AndAlso Not Double.IsInfinity(result)
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub MarkDirty()
        Try
            If m_bLoading Then Return
            m_bDirty = True
            m_bSaved = False
            If lblStatus IsNot Nothing Then lblStatus.Text = "未保存（保存後に結果取得可能）"
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
        End Try
    End Sub

    Private Sub SaveButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If String.IsNullOrWhiteSpace(txtInstrument.Text) OrElse String.IsNullOrWhiteSpace(txtManagement.Text) Then
                MessageBox.Show("装置番号と管理番号を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If dgvRef.Rows.Count < 2 
                MessageBox.Show("基準点を2点以上、HP/PBそれぞれに異なる設定温度の有効測定点を2点以上入力してください。", "保存不可", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            m_sInstrumentNo = txtInstrument.Text.Trim()
            Dim folder As String = Path.Combine("C:\SZKTool", m_sInstrumentNo, "CalibSet")
            Directory.CreateDirectory(folder)
            Dim filePath As String = Path.Combine(folder, DateTime.Now.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "_" & txtManagement.Text.Trim() & ".csv")
            If File.Exists(filePath) AndAlso MessageBox.Show("同名ファイルを上書きしますか？" & Environment.NewLine & filePath, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
            If Not SaveCsv(filePath) Then Return
			m_sLoadedCalibPath = filePath
			Call PopulateCalibrationList(Path.GetFileNameWithoutExtension(filePath))
            m_bDirty = False
            m_bSaved = True
            lblStatus.Text = "保存済み: " & Path.GetFileName(filePath)
            MessageBox.Show("校正データを保存しました。", "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            ShowError(ex)
        End Try
    End Sub

    Private Function SaveCsv(ByVal filePath As String) As Boolean
        Try
            Dim lines As New List(Of String)
            lines.Add(CsvLine(CSV_VERSION, m_sInstrumentNo, txtManagement.Text.Trim(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture), nudTolerance.Value.ToString(CultureInfo.InvariantCulture), nudCheckHP.Value.ToString(CultureInfo.InvariantCulture), nudCheckPB.Value.ToString(CultureInfo.InvariantCulture)))
            lines.Add(CsvLine("REFERENCE", "RefTemp", "CH1Measured", "CH1Error", "CH2Measured", "CH2Error"))
            For Each row As DataGridViewRow In dgvRef.Rows
                lines.Add(CsvLine("R", CellText(row, "RefTemp"), CellText(row, "CH1Measured"), CellText(row, "CH1Error"), CellText(row, "CH2Measured"), CellText(row, "CH2Error")))
            Next
            lines.Add(CsvLine("HP", "Valid", "SetTemp", "DisplayTemp", "RefMeasured", "Error", "Calibrated", "MeasuredAt"))
            For Each row As DataGridViewRow In dgvHP.Rows
                lines.Add(CsvLine("H", CellText(row, "Valid"), CellText(row, "SetTemp"), CellText(row, "DisplayTemp"), CellText(row, "RefMeasured"), CellText(row, "Error"), CellText(row, "Calibrated"), CellText(row, "MeasuredAt")))
            Next
            lines.Add(CsvLine("PB", "Valid", "SetTemp", "DisplayTemp", "RefMeasured", "Error", "Calibrated", "MeasuredAt"))
            For Each row As DataGridViewRow In dgvPB.Rows
                lines.Add(CsvLine("P", CellText(row, "Valid"), CellText(row, "SetTemp"), CellText(row, "DisplayTemp"), CellText(row, "RefMeasured"), CellText(row, "Error"), CellText(row, "Calibrated"), CellText(row, "MeasuredAt")))
            Next
            File.WriteAllLines(filePath, lines, New UTF8Encoding(True))
            Return True
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            MessageBox.Show("CSV保存に失敗しました。" & Environment.NewLine & ex.Message, "保存エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' デザイナー上で一意にした測定テーブル列名を取得する。
    ''' </summary>
    Private Function GetDataColumnName(ByVal dgv As DataGridView, ByVal columnName As String) As String
    Try
        If dgv Is dgvHP Then Return "HP" & columnName
        If dgv Is dgvPB Then Return "PB" & columnName
        Return columnName
    Catch ex As Exception
        WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
        Return columnName
    End Try
    End Function

    Private Function CellText(ByVal row As DataGridViewRow, ByVal column As String) As String
        Try
            If row.Cells(column).Value Is Nothing OrElse row.Cells(column).Value Is DBNull.Value Then Return ""
            Return Convert.ToString(row.Cells(column).Value, CultureInfo.InvariantCulture)
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            Return ""
        End Try
    End Function

    Private Function CsvLine(ParamArray values() As String) As String
        Try
            Return String.Join(",", values.Select(Function(v) CsvField(If(v, ""))).ToArray())
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            Throw
        End Try
    End Function

    Private Function CsvField(ByVal value As String) As String
        Try
            Dim q As String = ChrW(34)
            Return q & value.Replace(q, q & q) & q
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            Throw
        End Try
    End Function

    Private Function ParseCsvLine(ByVal line As String) As List(Of String)
        Try
            Dim values As New List(Of String)
            Dim sb As New StringBuilder
            Dim quoted As Boolean
            Dim q As Char = ChrW(34)
            Dim i As Integer = 0
            While i < line.Length
                If line(i) = q Then
                    If quoted AndAlso i + 1 < line.Length AndAlso line(i + 1) = q Then
                        sb.Append(q)
                        i += 1
                    Else
                        quoted = Not quoted
                    End If
                ElseIf line(i) = ","c AndAlso Not quoted Then
                    values.Add(sb.ToString())
                    sb.Length = 0
                Else
                    sb.Append(line(i))
                End If
                i += 1
            End While
            values.Add(sb.ToString())
            Return values
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            Throw
        End Try
    End Function

    Private Sub ReloadButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If m_bDirty AndAlso MessageBox.Show("未保存の変更を破棄して最新CSVを読み込みますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
            ClearData()
            LoadLatestCsv()
            RecalculateAll()
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            ShowError(ex)
        End Try
    End Sub

    Private Sub ClearData()
        Try
            dgvRef.Rows.Clear()
            dgvHP.Rows.Clear()
            dgvPB.Rows.Clear()
            txtManagement.Text = ""
            nudTolerance.Value = 0.5D
            nudCheckHP.Value = 100D
            nudCheckPB.Value = 100D
            SetRegressionInvalid(True)
            SetRegressionInvalid(False)
            m_bSaved = False
            m_bDirty = True
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
        End Try
    End Sub

Private Sub LoadLatestCsv()
Try
    If Not PopulateCalibrationList() Then
        m_sLoadedCalibPath = ""
        m_bSaved = False
        lblStatus.Text = "新規データ"
        Return
    End If
    Dim folder As String = Path.Combine("C:\SZKTool", m_sInstrumentNo, "CalibSet")
    Dim fileName As String = Convert.ToString(cbxStdCalib.SelectedItem)
    Dim filePath As String = Path.Combine(folder, fileName & ".csv")
    Call LoadCalibrationCsv(filePath)
Catch ex As Exception
    WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
    ShowError(ex)
End Try
End Sub

Private Function PopulateCalibrationList(Optional ByVal selectFileName As String = "") As Boolean
Try
    m_bUpdatingStdCalibList = True
    cbxStdCalib.Items.Clear()
    Dim folder As String = Path.Combine("C:\SZKTool", m_sInstrumentNo, "CalibSet")
    Dim candidates As New List(Of Tuple(Of String, String, String, String))
    If Directory.Exists(folder) Then
        For Each filePath As String In Directory.GetFiles(folder, "*_*.csv")
            Dim name As String = Path.GetFileNameWithoutExtension(filePath)
            Dim pos As Integer = name.IndexOf("_"c)
            Dim parsed As DateTime
            If pos = 8 AndAlso DateTime.TryParseExact(name.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, parsed) Then
                candidates.Add(Tuple.Create(name, filePath, name.Substring(0, 8), name.Substring(9)))
            End If
        Next
    End If
    For Each item In candidates.OrderByDescending(Function(x) x.Item3, StringComparer.Ordinal).ThenByDescending(Function(x) x.Item4, StringComparer.Ordinal)
        cbxStdCalib.Items.Add(item.Item1)
    Next
    If cbxStdCalib.Items.Count = 0 Then Return False
    Dim selectedIndex As Integer = 0
    If selectFileName <> "" Then
        For i As Integer = 0 To cbxStdCalib.Items.Count - 1
            If String.Equals(Convert.ToString(cbxStdCalib.Items(i)), selectFileName, StringComparison.OrdinalIgnoreCase) Then
                selectedIndex = i
                Exit For
            End If
        Next
    End If
    cbxStdCalib.SelectedIndex = selectedIndex
    Return True
Catch ex As Exception
    WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
    Return False
Finally
    m_bUpdatingStdCalibList = False
End Try
End Function

Private Sub StdCalibSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
Try
    If m_bUpdatingStdCalibList OrElse cbxStdCalib.SelectedIndex < 0 Then Return
    Dim folder As String = Path.Combine("C:\SZKTool", m_sInstrumentNo, "CalibSet")
    Dim fileName As String = Convert.ToString(cbxStdCalib.SelectedItem)
    Dim filePath As String = Path.Combine(folder, fileName & ".csv")
    If String.Equals(filePath, m_sLoadedCalibPath, StringComparison.OrdinalIgnoreCase) Then Return
    If m_bDirty Then
        If MessageBox.Show("未保存の変更があります。破棄して選択したCSVを読み込みますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            RestoreCalibrationSelection()
            Return
        End If
    End If
    If Not LoadCalibrationCsv(filePath) Then
        RestoreCalibrationSelection()
    End If
Catch ex As Exception
    WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
    ShowError(ex)
End Try
End Sub

Private Function LoadCalibrationCsv(ByVal filePath As String) As Boolean
Try
    LoadCsv(filePath)
    RecalculateAll()
    m_sLoadedCalibPath = filePath
    m_bDirty = False
    m_bSaved = RegressionAvailable(dgvHP) AndAlso RegressionAvailable(dgvPB)
    lblStatus.Text = "読込済み: " & Path.GetFileName(filePath)
    Return True
Catch ex As Exception
    WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
    m_bSaved = False
    m_bDirty = True
    MessageBox.Show("CSVの読み込みに失敗しました。" & Environment.NewLine & ex.Message, "読込エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
    Return False
End Try
End Function

Private Sub RestoreCalibrationSelection()
Try
    m_bUpdatingStdCalibList = True
    If String.IsNullOrEmpty(m_sLoadedCalibPath) Then
        cbxStdCalib.SelectedIndex = -1
    Else
        Dim loadedName As String = Path.GetFileNameWithoutExtension(m_sLoadedCalibPath)
        cbxStdCalib.SelectedIndex = -1
        For i As Integer = 0 To cbxStdCalib.Items.Count - 1
            If String.Equals(Convert.ToString(cbxStdCalib.Items(i)), loadedName, StringComparison.OrdinalIgnoreCase) Then
                cbxStdCalib.SelectedIndex = i
                Exit For
            End If
        Next
    End If
Catch ex As Exception
    WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
Finally
    m_bUpdatingStdCalibList = False
End Try
End Sub
    Private Sub LoadCsv(ByVal filePath As String)
        Try
            Dim lines As String() = File.ReadAllLines(filePath, Encoding.UTF8)
            If lines.Length = 0 Then Throw New InvalidDataException("CSVファイルが空です。")
            Dim header As List(Of String) = ParseCsvLine(lines(0))
            If header.Count < 7 OrElse header(0) <> CSV_VERSION Then Throw New InvalidDataException("CSV形式またはバージョンが不正です。")
            m_bLoading = True
            ClearData()
            m_sInstrumentNo = header(1)
            txtInstrument.Text = m_sInstrumentNo
            txtManagement.Text = header(2)
            Dim d As Decimal
            If Decimal.TryParse(header(4), NumberStyles.Float, CultureInfo.InvariantCulture, d) Then nudTolerance.Value = Math.Max(nudTolerance.Minimum, Math.Min(nudTolerance.Maximum, d))
            If Decimal.TryParse(header(5), NumberStyles.Float, CultureInfo.InvariantCulture, d) Then nudCheckHP.Value = Math.Max(nudCheckHP.Minimum, Math.Min(nudCheckHP.Maximum, d))
            If Decimal.TryParse(header(6), NumberStyles.Float, CultureInfo.InvariantCulture, d) Then nudCheckPB.Value = Math.Max(nudCheckPB.Minimum, Math.Min(nudCheckPB.Maximum, d))
            For i As Integer = 1 To lines.Length - 1
                If String.IsNullOrWhiteSpace(lines(i)) Then Continue For
                Dim f As List(Of String) = ParseCsvLine(lines(i))
                If f.Count = 0 Then Continue For
                Select Case f(0)
                Case "R"
                    If f.Count >= 6 Then
                        Dim rowIndex As Integer = dgvRef.Rows.Add()
                        For j As Integer = 0 To 4
                            dgvRef.Rows(rowIndex).Cells(j).Value = f(j + 1)
                        Next
                    End If
                Case "H"
                    If f.Count >= 8 Then AddLoadedMeasurement(dgvHP, f)
                Case "P"
                    If f.Count >= 8 Then AddLoadedMeasurement(dgvPB, f)
                Case Else
                    'CSV内の見出し行は読み飛ばす
                End Select
            Next
            RecalculateAll()
            m_bDirty = False
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            Throw
        Finally
            m_bLoading = False
        End Try
    End Sub

    Private Sub AddLoadedMeasurement(ByVal dgv As DataGridView, ByVal f As List(Of String))
        Try
            Dim i As Integer = dgv.Rows.Add()
            dgv.Rows(i).Cells(GetDataColumnName(dgv, "Valid")).Value = (f(1).ToLowerInvariant() = "true" OrElse f(1) = "1")
            dgv.Rows(i).Cells(GetDataColumnName(dgv, "SetTemp")).Value = f(2)
            dgv.Rows(i).Cells(GetDataColumnName(dgv, "DisplayTemp")).Value = f(3)
            dgv.Rows(i).Cells(GetDataColumnName(dgv, "RefMeasured")).Value = f(4)
            dgv.Rows(i).Cells(GetDataColumnName(dgv, "Error")).Value = f(5)
            dgv.Rows(i).Cells(GetDataColumnName(dgv, "Calibrated")).Value = f(6)
            dgv.Rows(i).Cells(GetDataColumnName(dgv, "MeasuredAt")).Value = f(7)
        Catch ex As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & ex.Message)
            Throw
        End Try
    End Sub

    Private Sub ShowError(ByVal ex As Exception)
        Try
            MessageBox.Show(ex.Message, "温度表示校正", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch logEx As Exception
            WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name & " : " & logEx.Message)
        End Try
    End Sub

    Private Sub WriteLog(ByVal message As String)
        Try
            Dim folder As String = "C:\SZKTool\Log"
            If Not Directory.Exists(folder) Then Directory.CreateDirectory(folder)
            File.AppendAllText(Path.Combine(folder, "TempDisplayCalib.log"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) & " " & message & Environment.NewLine, Encoding.UTF8)
        Catch
            'ログ出力失敗で本処理を停止させない
        End Try
    End Sub
End Class


