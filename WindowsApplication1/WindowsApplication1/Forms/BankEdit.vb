Public Class BankEdit

#Region "Variable"
    Dim Bok01 As Double, Rpt01 As String, i As Integer, ROW01 As Integer = 0, STR01 As String, Paid01 As Double
    Dim PAM01 As Double, dtx As Date, tchan As Boolean = True, EDIT01 As Boolean = False
    Dim DES01 As String = "", DES02 As String = "", DES03 As String = "", DES04 As String = ""
    Dim BnkNo As String = "", BnkName As String = "", BokS01 As Double
    Dim DTX2 As Date
    Dim crr_cashent As New crr, TrnType01 As Integer = 0, MemNo01 As Double
#End Region

    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub BankEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{Tab}")
        End If
    End Sub

    Private Sub CashEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        updcall(Me)
        Me.KeyPreview = True
        Call SetGroupbox(GroupBox1)
        Call SetGroupbox(GroupBox2)
        Call fillcmb()
        OptRec.Checked = True
        DesAuto()
        pLoad()
    End Sub

    Public Sub pLoad()
        Label1.Text = "ctukf yurzx "
        clearform()
        Mskdt.Text = IIf(Date.Now < Dt001, Dt001, Date.Now)
        Mskdt.Text = IIf(Date.Now > Dt002, Dt002, Date.Now)
        TxtVnoSeq.Text = 1
    End Sub

    Private Sub fillcmb()
        Call opencn(dbnam01)
        Call fillReader("Select Nameg From " & MSMST & " where trntype = 2")
        If dr.HasRows = True Then
            With dr
                While (.Read())
                    CmbBook.Items.Add(Convert.ToString(.Item(0)))
                End While
            End With
            CmbBook.Text = CmbBook.Items(0)
        Else
            MsgBox("Please Create Cash Book ", MsgBoxStyle.OkOnly, DEVLOP01)
            '            Me.Close()
            CmdExit.Focus()
        End If
        cn.Close()
    End Sub

    Sub DesAuto()
        opencn(dbnam01)
        Call fillReader("SELECT des1 FROM " & DSMST)
        If dr.HasRows = True Then
            TxtNar.AutoCompleteCustomSource.Clear()
            While (dr.Read())
                TxtNar.AutoCompleteCustomSource.Add(dr.Item(0))
            End While
        End If
        cn.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Len(TxtNar.Text) <> 0 Then
            STR01 = "insert into " & DSMST & " (bookcode,des1) values(" & Bok01 & ",'" & TxtNar.Text & "')"
            Call CommExe(STR01)
            cn.Close()
            MsgBox("Record Inseted", MsgBoxStyle.Information, DEVLOP01)
            DesAuto()
        End If
    End Sub


    Private Sub CmbBook_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CmbBook.Validating
        Call opencn(dbnam01)
        Call fillReader("Select accode,SubCode,Nameg, bankno, bankname From " & MSMST & " where nameg='" & CmbBook.Text & "' AND TRNTYPE = 2")
        If dr.HasRows = True Then
            dr.Read()
            Bok01 = Convert.ToDouble(dr.Item("accode"))
            BnkNo = Convert.ToString(dr.Item("bankno"))
            BokS01 = Convert.ToString(dr.Item("SubCode"))
            BnkName = Convert.ToString(dr.Item("bankname"))
        Else
            MsgBox("Please Create Book in Book Setup Entry Form", MsgBoxStyle.Information, DEVLOP01)
            CmdExit.Focus()
            Exit Sub
        End If
        cn.Close()
    End Sub

    Private Sub TxtVouNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVouNo.GotFocus
        TxtVouNo.Select(0, Len(Trim(TxtVouNo.Text)))

    End Sub

    Private Sub TxtAcName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAcName.GotFocus
        TxtAcName.Select(0, Len(Trim(TxtAcName.Text)))
    End Sub

    Private Sub TxtTot_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTot.GotFocus
        TxtTot.Select(0, Len(Trim(TxtTot.Text)))
    End Sub

    Private Sub TxtTot_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtTot.Validating
        If Not IsNumeric(TxtTot.Text) Then
            MsgBox("Pl. Insert Numeric Value.....!", MsgBoxStyle.OkOnly, DEVLOP01)
            TxtTot.Select(0, Len(Trim(TxtTot.Text)))
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub TxtNar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNar.GotFocus
        TxtNar.Select(0, Len(Trim(TxtNar.Text)))
    End Sub


    Private Sub TxtNar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNar.TextChanged
        If Trim(TxtNar.Text) = "/" Or Trim(TxtNar.Text) = "\" Then
            Dim achelp As New HelpAll
            achelp.DgvHelp.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
            achelp.Text = "Main Account Master"
            achelp.DataName = dbnam01
            achelp.TableName = DSMST
            achelp.Condition = "des1"
            achelp.FieldList = "des1"
            achelp.FormName = Me
            achelp.TextBoxName = TxtNar
            achelp.GetField = "des1"
            achelp.LabelText1 = "des1"
            achelp.LabelText2 = "des1"
            achelp.Show(Me)
        End If
    End Sub

    Private Sub clearform()
        EDIT01 = False
        If zoomedit = True Then
            zoomedit = False
            zoomrefresh = True
            Me.Close()
        End If
        ROW01 = 0
        TxtAcName.Text = ""
        TxtAccode.Text = ""
        TxtNar.Text = ""
        TxtTot.Text = 0
        TxtMem.Text = 0
        TxtMemNm.Text = ""
        TxtVouNo.Text = ""
        txtsubcode.Text = ""
        txtsubname.Text = ""

        tbal.Text = 0

        GroupBox2.Enabled = True
        OptRec.Focus()
    End Sub

    Private Sub Mskdt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mskdt.GotFocus
        Mskdt.Select(0, Len(Trim(Mskdt.Text)))

    End Sub

    Private Sub Mskdt_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles Mskdt.TypeValidationCompleted
        If e.IsValidInput = False Then
            MsgBox(e.Message, MsgBoxStyle.Information, DEVLOP01)
            e.Cancel = True
        End If
    End Sub

    Private Sub Mskdt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Mskdt.Validating
        If IsDate(Mskdt.Text) = True Then
            If DateChk(Convert.ToDateTime(Mskdt.Text)) = False Then
                e.Cancel = True
            Else
                dtx = Convert.ToDateTime(Mskdt.Text)
                LblDay.Text = Format(dtx, "dddd")
            End If

            If EDIT01 = False Then
                Call opencn(dbnam01)
                If zoomedit = False Then
                    STR01 = "Select a.Vno, a.AcCode, b.Nameg, a.Credit as Receipt,"
                    STR01 = STR01 & " a.Debit as Payment, a.Description, a.DES1, a.DES2, a.DES3," & _
                                    " a.uniqno, a.yearno, a.MemNo, a.memName, " & _
                                    " a.cash, a.bank, a.Seqno, a.CrDb, a.TrnType ,a.subcode " & _
                                    " from " & TRMST & " as a," & MSMST & " as b " & _
                                    " Where Yearno = '" & yrnoxx & "'" & _
                                    " and contracode = '" & Bok01 & "'" & _
                                    " and rptype = '" & Rpt01 & "'" & _
                                    " and billdate = '" & Format(dtx, "MM/dd/yyyy") & "'" & _
                                    " and crdb =1 and a.trntype = 2 " & _
                                    " and a.accode = b.accode " & _
                                    " order by rptype,vno,seqno"
                Else
                    STR01 = "Select a.VNo, a.Accode, b.Name, a.Credit as Receipt,"
                    STR01 = STR01 & " a.Debit as Payment, a.Description, a.DES1, a.DES2," & _
                                    " a.DES3, a.uniqno, a.yearno, a.MemNo, a.MemName," & _
                                    " a.cash, a.Bank, a.seqno, a.crdb, a.TrnType,a.subcode " & _
                                    " From " & TRMST & " as a," & MSMST & " as b " & _
                                    " where a.accode=b.accode " & _
                                    " order by rptype,vno,seqno"
                End If
                Call fillrs(STR01)
                DGV1.DataSource = rs.Tables(0)

                If DGV1.RowCount <> 0 Then
                    DGV1.Columns("Vno").Width = 80
                    DGV1.Columns("MemNo").Width = 80
                    DGV1.Columns("Accode").Width = 80
                    DGV1.Columns("Nameg").Width = 150
                    DGV1.Columns("MemName").Width = 150
                    DGV1.Columns("Description").Width = 150
                    DGV1.Columns("Receipt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV1.Columns("Payment").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV1.Columns("MemNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV1.Columns("MemName").DefaultCellStyle.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
                    DGV1.Columns("NAMEG").DefaultCellStyle.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
                    DGV1.Columns("subcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Else
                    MsgBox("No Transaction betweet these Date", MsgBoxStyle.Information, DEVLOP01)
                    CmdCancel.Focus()
                    cn.Close()
                End If
                DGV1.Visible = True
                DGV1.Focus()
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub DGV1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV1.DoubleClick
        HelpDgv1Grid()
    End Sub

    Public Sub HelpDgv1Grid()
        If DGV1.RowCount > 0 Then
            EDIT01 = True
            ' row011 = DGV1.CurrentRow.Index
            ROW01 = DGV1.CurrentRow.Index

            TxtVouNo.Text = DGV1.CurrentRow.Cells("Vno").Value
            TxtVnoSeq.Text = DGV1.CurrentRow.Cells("Seqno").Value
            TxtAcName.Text = DGV1.CurrentRow.Cells("Nameg").Value
            TxtAccode.Text = DGV1.CurrentRow.Cells("AcCode").Value
            txtsubcode.Text = DGV1.CurrentRow.Cells("subcode").Value

            TxtNar.Text = DGV1.CurrentRow.Cells("Description").Value & DGV1.CurrentRow.Cells("DES1").Value & DGV1.CurrentRow.Cells("DES2").Value & DGV1.CurrentRow.Cells("DES3").Value
            If Rpt01 = "BR" Or Rpt01 = "BC" Then
                TxtTot.Text = DGV1.CurrentRow.Cells("Receipt").Value
            Else
                TxtTot.Text = DGV1.CurrentRow.Cells("Payment").Value
            End If
            TxtMem.Text = DGV1.CurrentRow.Cells("MemNo").Value
            MemNo01 = DGV1.CurrentRow.Cells("MemNo").Value
            TxtMemNm.Text = IIf(IsDBNull(DGV1.CurrentRow.Cells("MemName").Value), "", DGV1.CurrentRow.Cells("MemName").Value)
            TrnType01 = FindTrntype(TxtAccode.Text)

            DGV1.Visible = False
            GroupBox2.Enabled = False
            'tBal.Text = GetBal(TextBox1.Text)

            Mskdt.Focus()
        End If
        'TB1.Focus()
    End Sub

    Private Sub TxtMem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMem.GotFocus
        TxtMem.Select(0, Len(Trim(TxtMem.Text)))

    End Sub

    Private Sub TxtMem_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMem.Validating
        If Val(TxtMem.Text) <> 0 Then
            If IsNumeric(TxtMem.Text) = True Then
                If Val(TxtMem.Text) = MemNo01 Then
                    Exit Sub
                End If
                MemNo01 = 0

                opencn(dbnam01)
                STR01 = "Select MEMNameg  From " & MMMST & " WHERE memno = " & TxtMem.Text & ""
                fillReader(STR01)
                If dr.HasRows = False Then
                    MsgBox("Member No. does not present", MsgBoxStyle.OkOnly, DEVLOP01)
                    e.Cancel = True
                    Exit Sub
                Else
                    While dr.Read
                        TxtMemNm.Text = Convert.ToString(dr.Item("memNameg"))
                        'tbal.Text = GetBal(TextBox1.Text)
                    End While
                End If
                dr.Close()
                cn.Close()
            Else
                MsgBox("Pl. Insert Numeric Value.....!", MsgBoxStyle.OkOnly, DEVLOP01)
                TxtMem.Text = 0
            End If
        Else
            CmdSave.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub OptPay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptPay.Click
        Rpt01 = "BP"
        OptPay.Select()
        OptPay.ForeColor = Color.Red
        OptRec.ForeColor = Color.Black
        OptCre.ForeColor = Color.Black
        OptDeb.ForeColor = Color.Black
    End Sub

    Private Sub OptRec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptRec.Click
        Rpt01 = "BR"
        OptRec.Select()
        OptRec.ForeColor = Color.Red
        OptPay.ForeColor = Color.Black
        OptCre.ForeColor = Color.Black
        OptDeb.ForeColor = Color.Black
    End Sub

    Private Sub OptCre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptCre.Click
        Rpt01 = "BC"
        OptCre.Select()
        OptCre.ForeColor = Color.Red
        OptRec.ForeColor = Color.Black
        OptPay.ForeColor = Color.Black
        OptDeb.ForeColor = Color.Black
    End Sub

    Private Sub OptDeb_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptDeb.Click
        Rpt01 = "BD"
        OptDeb.Select()
        OptDeb.ForeColor = Color.Red
        OptRec.ForeColor = Color.Black
        OptCre.ForeColor = Color.Black
        OptPay.ForeColor = Color.Black
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        Dim amt01c As Double, amt01d As Double, Bank01 As Double = 0
        If Len(Trim(TxtAcName.Text)) = 0 Then
            MsgBox("Insert Party Name", MsgBoxStyle.Information, DEVLOP01)
            TxtAcName.Focus()
            Exit Sub
        End If

        If Val(TxtTot.Text) = 0 Then
            MsgBox("Insert Amount ", MsgBoxStyle.Information, DEVLOP01)
            TxtTot.Focus()
            Exit Sub
        End If

        If Rpt01 = "BR" Then
            Bank01 = Val(TxtTot.Text)
            amt01c = Val(TxtTot.Text)
            amt01d = 0
        ElseIf Rpt01 = "BP" Then
            amt01c = 0
            amt01d = Val(TxtTot.Text)
            Bank01 = Val(TxtTot.Text) * -1
        ElseIf Rpt01 = "BC" Then
            Bank01 = Val(TxtTot.Text)
            amt01c = Val(TxtTot.Text)
            amt01d = 0
        ElseIf Rpt01 = "BD" Then
            amt01c = 0
            amt01d = Val(TxtTot.Text)
            Bank01 = Val(TxtTot.Text) * -1
        End If

        If Len(Trim(Mskdt.Text)) = 10 Then
            dtx = Convert.ToDateTime(Mskdt.Text)
        End If

        STR01 = "delete from " & TRMST & " where yearno='" & yrnoxx & "' and"
        STR01 = STR01 & " rptype='" & Rpt01 & "' and"
        STR01 = STR01 & " vno=" & Val(TxtVouNo.Text) & " and"
        STR01 = STR01 & " seqno = " & Val(TxtVnoSeq.Text) & " and trntype = 2 and BookCode = " & Bok01 & ""
        Call CommExe(STR01)

        opencn(dbnam01)
        STR01 = "INSERT INTO " & TRMST & " (yearno, contracode, rptype, vno, billdate, AcCode," & _
                " petaCode, cash, bank, credit, debit, trntype, seqno, CrDb," & _
                " DESCRIPTION,DES1,DES2,DES3, year, " & _
                " memno, MemName, BookCode, EtDate, Editby,subcode,CONTRASUBCODE)" & _
                " VALUES(" & yrnoxx & ", " & _
                " " & Bok01 & ", " & _
                " '" & Rpt01 & "'," & _
                " " & Val(TxtVouNo.Text) & ", " & _
                " '" & Format(dtx, "MM/dd/yyyy") & "', " & _
                " " & Val(TxtAccode.Text) & ", "
        STR01 = STR01 & " 0,"
        If TrnType01 = 1 Then
            STR01 = STR01 & " " & Bank01 & ",0,"
        Else
            STR01 = STR01 & " 0," & Bank01 & ","
        End If

        STR01 = STR01 & " " & amt01c & "," & _
                " " & amt01d & ", 2," & Val(TxtVnoSeq.Text) & ", 1, " & _
                " '" & Mid(TxtNar.Text, 1, 50) & "', " & _
                " '" & Mid(TxtNar.Text, 51, 50) & "', " & _
                " '" & Mid(TxtNar.Text, 101, 50) & "', " & _
                " '" & Mid(TxtNar.Text, 151, 50) & "', " & _
                " '" & YERXX & "', " & _
                " " & Val(TxtMem.Text) & "," & _
                " @MName, " & _
                " " & Bok01 & "," & _
                " '" & Format(Date.Now, "MM-dd-yyyy") & "'," & _
                " '" & USERXX & "'," & Val(txtsubcode.Text) & "," & BokS01 & ")"
        cn.Open()
        cm = New SqlClient.SqlCommand(STR01, cn)
        cm.Parameters.Add("@MName", SqlDbType.NVarChar, 100).Value = Trim(TxtMemNm.Text)
        cm.ExecuteNonQuery()
        cn.Close()

        opencn(dbnam01)
        STR01 = "INSERT INTO " & TRMST & " (yearno, contracode, rptype, vno, billdate, AcCode," & _
                " petaCode, cash, bank, credit, debit, trntype, seqno, CrDb, " & _
                " DESCRIPTION,DES1,DES2,DES3, year, " & _
                " memno, MemName, BookCode, Etdate, Editby,subcode,CONTRASUBCODE)" & _
                " VALUES(" & yrnoxx & ", " & _
                " " & Val(TxtAccode.Text) & ", " & _
                " '" & Rpt01 & "'," & _
                " " & Val(TxtVouNo.Text) & ", " & _
                " '" & Format(dtx, "MM/dd/yyyy") & "', " & _
                " " & Bok01 & ", "
        STR01 = STR01 & " 0,"
        If TrnType01 = 1 Then
            STR01 = STR01 & " " & Bank01 * -1 & ",0,"
        Else
            STR01 = STR01 & " 0," & Bank01 * -1 & ","
        End If
        STR01 = STR01 & " " & amt01d & "," & _
                    " " & amt01c & ", 2," & Val(TxtVnoSeq.Text) & ", 2," & _
                " '" & Mid(TxtNar.Text, 1, 50) & "', " & _
                " '" & Mid(TxtNar.Text, 51, 50) & "', " & _
                " '" & Mid(TxtNar.Text, 101, 50) & "', " & _
                " '" & Mid(TxtNar.Text, 151, 50) & "', " & _
                " '" & YERXX & "'," & _
                " " & Val(TxtMem.Text) & ", " & _
                 " @MName, " & _
                " " & Bok01 & "," & _
                " '" & Format(Date.Now, "MM-dd-yyyy") & "'," & _
                "'" & USERXX & "'," & BokS01 & "," & Val(txtsubcode.Text) & ")"
        cn.Open()
        cm = New SqlClient.SqlCommand(STR01, cn)
        cm.Parameters.Add("@MName", SqlDbType.NVarChar, 100).Value = Trim(TxtMemNm.Text)
        cm.ExecuteNonQuery()
        cn.Close()
        MsgBox("Record Updated '" & TxtVouNo.Text & "'", MsgBoxStyle.OkOnly, DEVLOP01)
        pLoad()
        Exit Sub
    End Sub

    Private Sub TxtAccode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtAccode.Validating
        If Val(TxtAccode.Text) <> 0 Then
            opencn(dbnam01)
            cn.Open()
            fillReader("Select Nameg,ACCODE,add3,add2,add1, ISNULL(TrnType,0) AS TrnType  From " & MSMST & " WHERE accode = " & Val(TxtAccode.Text) & " AND SUBCODEYN = 'M' ")
            If dr.HasRows = True Then
                dr.Read()
                TxtAcName.Text = Trim(dr.Item("nameg"))
                TrnType01 = Val(dr.Item("TRNTYPE"))
            Else
                MsgBox("Account Code Not Found...!!!", MsgBoxStyle.Critical, DEVLOP01)
                e.Cancel = True
                dr.Close()
                cn.Dispose()
            End If
            dr.Close()
            cn.Dispose()

        Else
            MsgBox("Enter Account Code...!!!", MsgBoxStyle.Critical, DEVLOP01)
            e.Cancel = True
            Exit Sub
        End If

        tchan = True
    End Sub

    Private Sub OptRec_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptRec.GotFocus
        Rpt01 = "BR"
        OptRec.Select()
        OptRec.ForeColor = Color.Red
        OptPay.ForeColor = Color.Black
        OptCre.ForeColor = Color.Black
        OptDeb.ForeColor = Color.Black

    End Sub

    Private Sub OptPay_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptPay.GotFocus
        Rpt01 = "BP"
        OptPay.Select()
        OptPay.ForeColor = Color.Red
        OptRec.ForeColor = Color.Black
        OptCre.ForeColor = Color.Black
        OptDeb.ForeColor = Color.Black

    End Sub

    Private Sub OptCre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptCre.GotFocus
        Rpt01 = "BC"
        OptCre.Select()
        OptCre.ForeColor = Color.Red
        OptRec.ForeColor = Color.Black
        OptPay.ForeColor = Color.Black
        OptDeb.ForeColor = Color.Black

    End Sub

    Private Sub OptDeb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptDeb.GotFocus
        Rpt01 = "BD"
        OptDeb.Select()
        OptDeb.ForeColor = Color.Red
        OptRec.ForeColor = Color.Black
        OptCre.ForeColor = Color.Black
        OptPay.ForeColor = Color.Black

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        'Dim KeyCode As Integer = CType(keyData, Integer)
        'Dim Key As Keys = CType(KeyCode, Keys)

        'If Me.ActiveControl Is TextBox Then
        '    Dim dg As DataGridView = Nothing

        '    If ActiveControl.GetType Is GetType(DataGridViewTextBoxEditingControl) Then
        '        Dim txtbk As TextBox = CType(Me.ActiveControl, TextBox)
        '        dg = CType(txtbk.textchange, TextBox)
        '    Else
        '        dg = CType(Me.ActiveControl, TextBox)
        '    End If

        '    Dim dgc As TextBox = dg.KeyDown
        '    If IsNothing(dgc) Then Return MyBase.ProcessCmdKey(msg, keyData)
        '    If Key = Keys.Return OrElse Key = Keys.Enter Then
        '        SendKeys.SendWait("{TAB}") 'tab automatically.
        '    End If
        '    Return True
        'ElseIf Key = Keys.Add Then
        '    SendKeys.SendWait("+{TAB}")
        'End If
        'Return True
        'Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        pLoad()
    End Sub
    Private Sub DGV1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV1.KeyDown
        If e.KeyCode = Keys.Enter Then
            HelpDgv1Grid()
        End If
    End Sub

    Private Sub DGV1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV1.VisibleChanged
        If DGV1.Visible = True Then
            With DGV1
                .Width = 655
                .Height = 192
                .Top = 114
                .Left = 18
            End With
        End If
    End Sub

    Private Sub CmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDelete.Click
        Dim r As MsgBoxResult
        r = MsgBox("Are You Sure Do You Want to Delete ? ", MsgBoxStyle.YesNo, DEVLOP01)
        If r = MsgBoxResult.Yes Then
            STR01 = "delete from " & TRMST & " where yearno='" & yrnoxx & "' and"
            STR01 = STR01 & " rptype='" & Rpt01 & "' and"
            STR01 = STR01 & " vno=" & Val(TxtVouNo.Text) & " and"
            STR01 = STR01 & " seqno = " & Val(TxtVnoSeq.Text) & " and trntype = 2 and BookCode = " & Bok01 & ""
            Call CommExe(STR01)
            Call clearform()
        End If
    End Sub

    Private Sub TxtAccode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAccode.TextChanged
        If Trim(TxtAccode.Text) = "/" Or Trim(TxtAccode.Text) = "\" Then
            Dim achelp As New HelpAll
            achelp.DgvHelp.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
            achelp.Text = "Main Account Master"
            achelp.DataName = dbnam01
            achelp.TableName = MSMST & " WHERE SUBCODEYN = 'M'"
            achelp.Condition = "NAMEg"
            achelp.FieldList = "Nameg,AcCODE"
            achelp.FormName = Me
            achelp.TextBoxName = TxtAccode
            achelp.GetField = "AcCODE"
            achelp.LabelText1 = "AcCODE"
            achelp.LabelText2 = "Nameg"
            achelp.Show(Me)
        End If
    End Sub

    Private Sub txtsubcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsubcode.TextChanged
        If Trim(txtsubcode.Text) = "/" Or Trim(txtsubcode.Text) = "\" Then
            Dim achelp As New HelpAll
            achelp.DgvHelp.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
            achelp.Text = "Sub Account Master"
            achelp.DataName = dbnam01
            achelp.TableName = MSMST & " where accode = " & Val(TxtAccode.Text) & " and subcodeyn= 'S' "
            achelp.Condition = "subcode"
            achelp.FieldList = "Subcode,Nameg"
            achelp.FormName = Me
            achelp.TextBoxName = txtsubcode
            achelp.GetField = "subcode"
            achelp.LabelText1 = "subCode"
            achelp.LabelText2 = "Nameg"
            achelp.Show(Me)
        End If
    End Sub

    Private Sub txtsubcode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtsubcode.Validating
        If Val(txtsubcode.Text) <> 0 Then
            opencn(dbnam01)
            cn.Open()
            fillReader("Select Nameg  From " & MSMST & " WHERE accode = " & Val(TxtAccode.Text) & " AND SUBCODEYN = 'S' and subcode= " & Val(txtsubcode.Text) & "  ")
            If dr.HasRows = True Then
                dr.Read()
                txtsubname.Text = Trim(dr.Item("nameg"))
            Else
                MsgBox("subCode Not Found...!!!", MsgBoxStyle.Critical, DEVLOP01)
                TxtAccode.Select(0, Len(TxtAccode.Text))
                TxtAccode.Focus()
                Exit Sub
                e.Cancel = True
                dr.Close()
                cn.Dispose()
            End If
            dr.Close()
            cn.Dispose()
        Else
            Call opencn(dbnam01)
            Call fillReader("Select * From " & MSMST & " Where " & _
                            " AcCode = " & Val(TxtAccode.Text) & " and " & _
                            " subcodeyn = 'S'")
            If dr.HasRows = True Then
                MsgBox("Enter Sub Code...!!!", MsgBoxStyle.Critical, DEVLOP01)
                dr.Close()
                cn.Close()
                TxtAccode.Select(0, Len(TxtAccode.Text))
                TxtAccode.Focus()
                Exit Sub
                e.Cancel = True
            End If
            dr.Close()
            cn.Close()
        End If
    End Sub
  
    Private Sub TxtMem_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMem.TextChanged
        If Trim(TxtMem.Text) = "/" Or Trim(TxtMem.Text) = "\" Then
            Dim achelp As New HelpAll
            achelp.DgvHelp.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
            achelp.Text = "Member Master"
            achelp.DataName = dbnam01
            achelp.TableName = MMMST
            achelp.Condition = "Memno"
            achelp.FieldList = "Memno,MemNameg"
            achelp.FormName = Me
            achelp.TextBoxName = TxtMem
            achelp.GetField = "Memno"
            achelp.LabelText1 = "Memno"
            achelp.LabelText2 = "MemNameg"
            achelp.Show(Me)
        End If
    End Sub

End Class
