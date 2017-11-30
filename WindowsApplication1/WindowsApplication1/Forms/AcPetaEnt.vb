Public Class AcPetaEnt
    Dim ROW01 As Integer, STR01 As String
    Private Sub PartyGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call updcall(Me)
        Call UPDGRID(DGAC, Language.Gujarati, Language.Gujarati)
        Call UPDGRID(DGV1, Language.English, Language.Gujarati)
        Call UPDGRID(DgPeta, Language.English, Language.Gujarati)
        Call SetGroupbox(GroupBox1)
    End Sub
    Private Sub TB1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB1.GotFocus
        TB1.Select(0, Len(Trim(TB1.Text)))
        DGAC.Visible = False
    End Sub
    Private Sub TB1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB1.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Down Then
            If DGAC.Visible = True Then
                DGAC.Focus()
            End If
        End If
    End Sub
    Private Sub TB1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB1.TextChanged
        Call opencn(dbnam01)
        Call fillhelprs("Select Name,ACCODE From " & MSMST & " WHERE NAME >='" & TB1.Text & "' Order By Name")
        DGAC.DataSource = helprs.Tables(0)
        ' ''DGAC.Columns(0).HeaderText = "lttbt"
        ' ''DGAC.Columns(1).HeaderText = "yuftQlx ftuz"
        DGAC.Visible = True
        DGAC.Columns(0).Width = 400
        DGAC.Columns(1).Width = 75
        cn.Close()
    End Sub
    Private Sub TB1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TB1.Validating
        If DGAC.Visible = True Then
            TextBox1.Text = DGAC.CurrentRow.Cells(1).Value
            TB1.Text = DGAC.CurrentRow.Cells(0).Value
        Else
            If Len(Trim(TB1.Text)) = 0 Then
                CmdSave.Focus()
            End If
        End If
    End Sub
    Private Sub DGAC_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGAC.CellDoubleClick
        TB1.Text = DGAC.CurrentRow.Cells(0).Value
        TextBox1.Text = DGAC.CurrentRow.Cells(1).Value
        DGAC.Visible = False
        TB1.Focus()
    End Sub
    Private Sub DGAC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGAC.KeyDown
        If e.KeyCode = Keys.Enter Then
            TB1.Text = DGAC.CurrentRow.Cells(0).Value
            TextBox1.Text = DGAC.CurrentRow.Cells(1).Value
            DGAC.Visible = False
            TB1.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub DgPeta_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPeta.CellDoubleClick
        txtPetaName.Text = DgPeta.CurrentRow.Cells(0).Value
        txtPetaCode.Text = DgPeta.CurrentRow.Cells(1).Value
        DgPeta.Visible = False
        txtPetaName.Focus()
    End Sub
    Private Sub DgPeta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgPeta.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPetaName.Text = DgPeta.CurrentRow.Cells(0).Value
            txtPetaCode.Text = DgPeta.CurrentRow.Cells(1).Value
            DgPeta.Visible = False
            txtPetaName.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub TextBox7_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPetaName.GotFocus
        DGAC.Visible = False
        txtPetaName.Select(0, Len(Trim(txtPetaName.Text)))
        DgPeta.Visible = False
    End Sub
    Private Sub TextBox7_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPetaName.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Down Then
            If DgPeta.Visible = True Then
                DgPeta.Focus()
            End If
        End If
    End Sub
    Private Sub txtPetaName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPetaName.TextChanged
        Call opencn(dbnam01)
        Call fillhelprs("Select PetaName, PetaCODE From " & REMMST & " WHERE PetaName >='" & txtPetaName.Text & "' Order By PetaName")
        DgPeta.DataSource = helprs.Tables(0)
        DgPeta.Visible = True
        DgPeta.Columns(0).Width = 400
        DgPeta.Columns(1).Width = 75
        cn.Close()
    End Sub
    Private Sub txtPetaName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPetaName.Validating
        If DgPeta.RowCount <> 0 Then
            If DgPeta.Visible = True Then
                txtPetaCode.Text = DgPeta.CurrentRow.Cells(1).Value
                txtPetaName.Text = DgPeta.CurrentRow.Cells(0).Value
            Else
                If Len(Trim(txtPetaName.Text)) = 0 Then
                    CmdSave.Focus()
                End If
            End If
        Else
            If Len(Trim(txtPetaName.Text)) = 0 Then
                CmdSave.Focus()
            End If
        End If
    End Sub
    Private Sub DGV1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV1.DoubleClick
        ROW01 = DGV1.CurrentRow.Index + 1
        txtPetaName.Text = Convert.ToString(DGV1.CurrentRow.Cells(0).Value)
        txtPetaCode.Text = DGV1.CurrentRow.Cells(1).Value
        txtPetaName.Focus()
    End Sub
    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        Dim I As Integer
        Call opencn(dbnam01)
        Call CommExe("DELETE FROM " & AIMST & " WHERE ACCODE=" & Val(TextBox1.Text))

        If DGV1.Rows.Count > 1 Then
            For I = 0 To DGV1.Rows.Count - 1
                If DGV1.Rows(I).Cells(1).Value <> 0 Then
                    STR01 = "INSERT INTO " & AIMST & "(ACCODE, PetaCode)"
                    STR01 = STR01 & " VALUES(" & Val(TextBox1.Text) & ","
                    STR01 = STR01 & Convert.ToDouble(DGV1.Rows(I).Cells(1).Value) & ")"
                    Call CommExe(STR01)
                End If
            Next
        End If
        cn.Close()
        Call clearform()
        MsgBox("Record Inserted '", MsgBoxStyle.OkOnly, DEVLOP01)
    End Sub
    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        DGAC.Visible = False
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub TextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        Dim R As MsgBoxResult
        Call opencn(dbnam01)
        STR01 = " SELECT Ai.AcCODE, Ai.PetaCODE, a.name, p.PetaName  " & _
                " FROM " & AIMST & " AS Ai," & MSMST & " AS a," & _
                " " & REMMST & " AS p" & _
                " WHERE Ai.ACCODE = " & Val(TextBox1.Text) & "" & _
                " AND Ai.PetaCODE = p.PetaCode " & _
                " AND Ai.acCODE = a.acCODE " & _
                " Order by ai.UniqNo "

        Call fillReader(STR01)
        If dr.HasRows = True Then
            R = MsgBox("Do You Want To Edit This ? ", MsgBoxStyle.YesNo, DEVLOP01)
            If R = MsgBoxResult.No Then
                cn.Close()
                e.Cancel = True
                Exit Sub
            End If
            DGV1.RowCount = 0
            Do While (dr.Read())
                If dr.Item(0) <> dr.Item(1) Then
                    DGV1.Rows.Add(New Object() {Convert.ToString(dr.Item("PetaName")), Convert.ToDouble(dr.Item("PetaCode"))})
                End If
            Loop
        End If
        cn.Close()
    End Sub
    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        Call clearform()
    End Sub
    Private Sub clearform()
        TB1.Text = ""
        TextBox1.Text = ""
        txtPetaName.Text = ""
        txtPetaCode.Text = ""
        DGV1.RowCount = 0
        TB1.Focus()
    End Sub

    Private Sub TextBox8_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPetaCode.GotFocus
        DgPeta.Visible = False

    End Sub

    Private Sub TextBox8_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPetaCode.Validating
        If ROW01 <> 0 Then
            ROW01 = ROW01 - 1
            DGV1.Rows(ROW01).Cells(0).Value = txtPetaName.Text
            DGV1.Rows(ROW01).Cells(1).Value = txtPetaCode.Text
            ROW01 = 0
        Else
            DGV1.Rows.Add(New Object() {txtPetaName.Text, txtPetaCode.Text})
        End If
        txtPetaName.Text = ""
        txtPetaCode.Text = ""
        txtPetaName.Focus()
        DGAC.Visible = False
        DgPeta.Visible = False
    End Sub
    Private Sub TextBox8_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPetaCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
            e.SuppressKeyPress = True
        End If
    End Sub
End Class