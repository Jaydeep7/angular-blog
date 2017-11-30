<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BankEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtsubcode = New System.Windows.Forms.TextBox
        Me.txtsubname = New System.Windows.Forms.TextBox
        Me.TxtVnoSeq = New System.Windows.Forms.TextBox
        Me.LblDay = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.OptDeb = New System.Windows.Forms.RadioButton
        Me.OptCre = New System.Windows.Forms.RadioButton
        Me.OptPay = New System.Windows.Forms.RadioButton
        Me.OptRec = New System.Windows.Forms.RadioButton
        Me.tbal = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtMemNm = New System.Windows.Forms.TextBox
        Me.TxtMem = New System.Windows.Forms.TextBox
        Me.TxtNar = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtTot = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Mskdt = New System.Windows.Forms.MaskedTextBox
        Me.TxtAccode = New System.Windows.Forms.TextBox
        Me.TxtAcName = New System.Windows.Forms.TextBox
        Me.TxtVouNo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.CmbBook = New System.Windows.Forms.ComboBox
        Me.CmdSave = New System.Windows.Forms.Button
        Me.CmdExit = New System.Windows.Forms.Button
        Me.CmdCancel = New System.Windows.Forms.Button
        Me.CmdPrint = New System.Windows.Forms.Button
        Me.CmdDelete = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSalmon
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("MMS-CHITRA", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkRed
        Me.Label1.Location = New System.Drawing.Point(-2, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(739, 40)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ctukf yurzx "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DGV1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtsubcode)
        Me.GroupBox1.Controls.Add(Me.txtsubname)
        Me.GroupBox1.Controls.Add(Me.TxtVnoSeq)
        Me.GroupBox1.Controls.Add(Me.LblDay)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.tbal)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.TxtMemNm)
        Me.GroupBox1.Controls.Add(Me.TxtMem)
        Me.GroupBox1.Controls.Add(Me.TxtNar)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TxtTot)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Mskdt)
        Me.GroupBox1.Controls.Add(Me.TxtAccode)
        Me.GroupBox1.Controls.Add(Me.TxtAcName)
        Me.GroupBox1.Controls.Add(Me.TxtVouNo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.CmbBook)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(716, 303)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.AllowUserToOrderColumns = True
        Me.DGV1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.DGV1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Thistle
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PeachPuff
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Cursor = System.Windows.Forms.Cursors.Default
        Me.DGV1.GridColor = System.Drawing.Color.Red
        Me.DGV1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DGV1.Location = New System.Drawing.Point(591, 232)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Thistle
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.NullValue = "+1"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PeachPuff
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV1.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        Me.DGV1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PeachPuff
        Me.DGV1.Size = New System.Drawing.Size(94, 38)
        Me.DGV1.TabIndex = 72
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(15, 180)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 18)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "mtctftuz"
        '
        'txtsubcode
        '
        Me.txtsubcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsubcode.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsubcode.Location = New System.Drawing.Point(120, 176)
        Me.txtsubcode.Name = "txtsubcode"
        Me.txtsubcode.Size = New System.Drawing.Size(103, 27)
        Me.txtsubcode.TabIndex = 6
        '
        'txtsubname
        '
        Me.txtsubname.BackColor = System.Drawing.SystemColors.Window
        Me.txtsubname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsubname.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsubname.Location = New System.Drawing.Point(230, 176)
        Me.txtsubname.MaxLength = 40
        Me.txtsubname.Name = "txtsubname"
        Me.txtsubname.ReadOnly = True
        Me.txtsubname.Size = New System.Drawing.Size(303, 27)
        Me.txtsubname.TabIndex = 78
        Me.txtsubname.TabStop = False
        '
        'TxtVnoSeq
        '
        Me.TxtVnoSeq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVnoSeq.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVnoSeq.Location = New System.Drawing.Point(120, 114)
        Me.TxtVnoSeq.MaxLength = 2
        Me.TxtVnoSeq.Name = "TxtVnoSeq"
        Me.TxtVnoSeq.Size = New System.Drawing.Size(22, 27)
        Me.TxtVnoSeq.TabIndex = 3
        Me.TxtVnoSeq.TabStop = False
        Me.TxtVnoSeq.Text = "1"
        '
        'LblDay
        '
        Me.LblDay.AutoSize = True
        Me.LblDay.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDay.ForeColor = System.Drawing.Color.Red
        Me.LblDay.Location = New System.Drawing.Point(287, 90)
        Me.LblDay.Name = "LblDay"
        Me.LblDay.Size = New System.Drawing.Size(0, 18)
        Me.LblDay.TabIndex = 71
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.OptDeb)
        Me.GroupBox2.Controls.Add(Me.OptCre)
        Me.GroupBox2.Controls.Add(Me.OptPay)
        Me.GroupBox2.Controls.Add(Me.OptRec)
        Me.GroupBox2.Location = New System.Drawing.Point(117, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(508, 38)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'OptDeb
        '
        Me.OptDeb.AutoSize = True
        Me.OptDeb.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptDeb.Location = New System.Drawing.Point(403, 10)
        Me.OptDeb.Name = "OptDeb"
        Me.OptDeb.Size = New System.Drawing.Size(61, 22)
        Me.OptDeb.TabIndex = 3
        Me.OptDeb.TabStop = True
        Me.OptDeb.Text = "zuctex"
        Me.OptDeb.UseVisualStyleBackColor = True
        '
        'OptCre
        '
        Me.OptCre.AutoSize = True
        Me.OptCre.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptCre.Location = New System.Drawing.Point(285, 10)
        Me.OptCre.Name = "OptCre"
        Me.OptCre.Size = New System.Drawing.Size(61, 22)
        Me.OptCre.TabIndex = 2
        Me.OptCre.TabStop = True
        Me.OptCre.Text = "f{urzx "
        Me.OptCre.UseVisualStyleBackColor = True
        '
        'OptPay
        '
        Me.OptPay.AutoSize = True
        Me.OptPay.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptPay.Location = New System.Drawing.Point(152, 10)
        Me.OptPay.Name = "OptPay"
        Me.OptPay.Size = New System.Drawing.Size(61, 22)
        Me.OptPay.TabIndex = 1
        Me.OptPay.TabStop = True
        Me.OptPay.Text = "vtubtulx"
        Me.OptPay.UseVisualStyleBackColor = True
        '
        'OptRec
        '
        Me.OptRec.AutoSize = True
        Me.OptRec.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptRec.Location = New System.Drawing.Point(24, 10)
        Me.OptRec.Name = "OptRec"
        Me.OptRec.Size = New System.Drawing.Size(70, 22)
        Me.OptRec.TabIndex = 0
        Me.OptRec.TabStop = True
        Me.OptRec.Text = "hemtevx"
        Me.OptRec.UseVisualStyleBackColor = True
        '
        'tbal
        '
        Me.tbal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbal.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbal.Location = New System.Drawing.Point(440, 83)
        Me.tbal.Name = "tbal"
        Me.tbal.Size = New System.Drawing.Size(88, 27)
        Me.tbal.TabIndex = 7
        Me.tbal.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("MMS-CHITRA", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(540, 274)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 27)
        Me.Button1.TabIndex = 15
        Me.Button1.TabStop = False
        Me.Button1.Text = "yuz fhJtt"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TxtMemNm
        '
        Me.TxtMemNm.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMemNm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMemNm.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemNm.Location = New System.Drawing.Point(230, 207)
        Me.TxtMemNm.Name = "TxtMemNm"
        Me.TxtMemNm.Size = New System.Drawing.Size(303, 27)
        Me.TxtMemNm.TabIndex = 12
        Me.TxtMemNm.TabStop = False
        '
        'TxtMem
        '
        Me.TxtMem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMem.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMem.Location = New System.Drawing.Point(120, 207)
        Me.TxtMem.Name = "TxtMem"
        Me.TxtMem.Size = New System.Drawing.Size(103, 27)
        Me.TxtMem.TabIndex = 7
        Me.TxtMem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtNar
        '
        Me.TxtNar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNar.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNar.Location = New System.Drawing.Point(120, 269)
        Me.TxtNar.MaxLength = 200
        Me.TxtNar.Name = "TxtNar"
        Me.TxtNar.Size = New System.Drawing.Size(414, 27)
        Me.TxtNar.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 211)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 18)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "mtCttmt' ltk."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 273)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 18)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "rJtdt;t"
        '
        'TxtTot
        '
        Me.TxtTot.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot.Location = New System.Drawing.Point(120, 238)
        Me.TxtTot.MaxLength = 20
        Me.TxtTot.Name = "TxtTot"
        Me.TxtTot.Size = New System.Drawing.Size(103, 27)
        Me.TxtTot.TabIndex = 8
        Me.TxtTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 242)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 18)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "hfbt"
        '
        'Mskdt
        '
        Me.Mskdt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Mskdt.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mskdt.Location = New System.Drawing.Point(120, 83)
        Me.Mskdt.Mask = "00/00/0000"
        Me.Mskdt.Name = "Mskdt"
        Me.Mskdt.Size = New System.Drawing.Size(103, 27)
        Me.Mskdt.TabIndex = 2
        Me.Mskdt.ValidatingType = GetType(Date)
        '
        'TxtAccode
        '
        Me.TxtAccode.BackColor = System.Drawing.SystemColors.Window
        Me.TxtAccode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAccode.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAccode.Location = New System.Drawing.Point(120, 145)
        Me.TxtAccode.Name = "TxtAccode"
        Me.TxtAccode.Size = New System.Drawing.Size(103, 27)
        Me.TxtAccode.TabIndex = 5
        '
        'TxtAcName
        '
        Me.TxtAcName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAcName.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAcName.Location = New System.Drawing.Point(230, 145)
        Me.TxtAcName.MaxLength = 40
        Me.TxtAcName.Name = "TxtAcName"
        Me.TxtAcName.ReadOnly = True
        Me.TxtAcName.Size = New System.Drawing.Size(303, 27)
        Me.TxtAcName.TabIndex = 5
        Me.TxtAcName.TabStop = False
        '
        'TxtVouNo
        '
        Me.TxtVouNo.BackColor = System.Drawing.SystemColors.Window
        Me.TxtVouNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVouNo.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVouNo.Location = New System.Drawing.Point(148, 114)
        Me.TxtVouNo.MaxLength = 10
        Me.TxtVouNo.Name = "TxtVouNo"
        Me.TxtVouNo.ReadOnly = True
        Me.TxtVouNo.Size = New System.Drawing.Size(88, 27)
        Me.TxtVouNo.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 18)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "yuftWlx ftuz "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 18)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "JttWath ltk."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 18)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = ";ttheFt"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(15, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 18)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "ctwf ftuz"
        '
        'CmbBook
        '
        Me.CmbBook.BackColor = System.Drawing.Color.LightSalmon
        Me.CmbBook.Font = New System.Drawing.Font("MMS-CHITRA  BOLD", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBook.FormattingEnabled = True
        Me.CmbBook.Location = New System.Drawing.Point(117, 17)
        Me.CmbBook.Name = "CmbBook"
        Me.CmbBook.Size = New System.Drawing.Size(372, 26)
        Me.CmbBook.TabIndex = 0
        '
        'CmdSave
        '
        Me.CmdSave.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.CmdSave.FlatAppearance.BorderSize = 2
        Me.CmdSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CmdSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdSave.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdSave.Image = Global.ACCOUNT.My.Resources.Resources.save_as
        Me.CmdSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdSave.Location = New System.Drawing.Point(65, 359)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(106, 44)
        Me.CmdSave.TabIndex = 2
        Me.CmdSave.Text = "mtuJt"
        Me.CmdSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdSave.UseVisualStyleBackColor = True
        '
        'CmdExit
        '
        Me.CmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdExit.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.CmdExit.FlatAppearance.BorderSize = 2
        Me.CmdExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CmdExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdExit.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExit.ForeColor = System.Drawing.Color.Black
        Me.CmdExit.Image = Global.ACCOUNT.My.Resources.Resources.exit1
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdExit.Location = New System.Drawing.Point(441, 359)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(106, 44)
        Me.CmdExit.TabIndex = 5
        Me.CmdExit.Text = "yuHtex "
        Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CmdCancel
        '
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.CmdCancel.FlatAppearance.BorderSize = 2
        Me.CmdCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.CmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCancel.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdCancel.Image = Global.ACCOUNT.My.Resources.Resources.Delete
        Me.CmdCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdCancel.Location = New System.Drawing.Point(315, 359)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(106, 44)
        Me.CmdCancel.TabIndex = 4
        Me.CmdCancel.Text = "fulmtjt"
        Me.CmdCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'CmdPrint
        '
        Me.CmdPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdPrint.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.CmdPrint.FlatAppearance.BorderSize = 2
        Me.CmdPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CmdPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.CmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdPrint.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdPrint.Image = Global.ACCOUNT.My.Resources.Resources.Print
        Me.CmdPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdPrint.Location = New System.Drawing.Point(189, 359)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(106, 44)
        Me.CmdPrint.TabIndex = 3
        Me.CmdPrint.Text = "vt{elx"
        Me.CmdPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdPrint.UseVisualStyleBackColor = True
        '
        'CmdDelete
        '
        Me.CmdDelete.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.CmdDelete.FlatAppearance.BorderSize = 2
        Me.CmdDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CmdDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.CmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdDelete.Font = New System.Drawing.Font("MMS-CHITRA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdDelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdDelete.Image = Global.ACCOUNT.My.Resources.Resources.Trash1
        Me.CmdDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdDelete.Location = New System.Drawing.Point(562, 359)
        Me.CmdDelete.Name = "CmdDelete"
        Me.CmdDelete.Size = New System.Drawing.Size(106, 44)
        Me.CmdDelete.TabIndex = 6
        Me.CmdDelete.Text = "zejtex "
        Me.CmdDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdDelete.UseVisualStyleBackColor = True
        '
        'BankEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.CmdExit
        Me.ClientSize = New System.Drawing.Size(732, 408)
        Me.Controls.Add(Me.CmdDelete)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.CmdExit)
        Me.Controls.Add(Me.CmdCancel)
        Me.Controls.Add(Me.CmdPrint)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "BankEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bank Edit"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CmbBook As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtAccode As System.Windows.Forms.TextBox
    Friend WithEvents TxtAcName As System.Windows.Forms.TextBox
    Friend WithEvents TxtVouNo As System.Windows.Forms.TextBox
    Friend WithEvents Mskdt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtNar As System.Windows.Forms.TextBox
    Friend WithEvents TxtMemNm As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents tbal As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OptDeb As System.Windows.Forms.RadioButton
    Friend WithEvents OptCre As System.Windows.Forms.RadioButton
    Friend WithEvents OptPay As System.Windows.Forms.RadioButton
    Friend WithEvents OptRec As System.Windows.Forms.RadioButton
    Friend WithEvents TxtMem As System.Windows.Forms.TextBox
    Friend WithEvents LblDay As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents TxtTot As System.Windows.Forms.TextBox
    Friend WithEvents CmdDelete As System.Windows.Forms.Button
    Friend WithEvents TxtVnoSeq As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtsubcode As System.Windows.Forms.TextBox
    Friend WithEvents txtsubname As System.Windows.Forms.TextBox
End Class
