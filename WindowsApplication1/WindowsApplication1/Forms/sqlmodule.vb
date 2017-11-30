Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module sqlmodule

#Region "Connection"
    Public zoomedit As Boolean = False
    Public zoomrefresh As Boolean = False

    Public cn As SqlClient.SqlConnection
    Public cn_Sug As SqlClient.SqlConnection
    Public cn1 As SqlClient.SqlConnection
    Public cn2 As SqlClient.SqlConnection
    Public helpcn As SqlClient.SqlConnection

    Public cm As SqlClient.SqlCommand
    Public cm1 As SqlClient.SqlCommand
    Public cm2 As SqlClient.SqlCommand
    Public helpcm As SqlClient.SqlCommand

    Public da As SqlClient.SqlDataAdapter
    Public helpda As SqlClient.SqlDataAdapter

    Public rs As DataSet
    Public helprs As DataSet
    Public helprs1 As DataSet

    Public dr As SqlClient.SqlDataReader
    Public dr1 As SqlClient.SqlDataReader
    Public dr2 As SqlClient.SqlDataReader
    Public helpdr As SqlClient.SqlDataReader

    Public dt As DataTable

    Public cna As OleDb.OleDbConnection
    Public cmda As OleDb.OleDbCommand
    Public dra As OleDb.OleDbDataReader
    Public daa As OleDb.OleDbDataAdapter

    Public cnaa As Odbc.OdbcConnection
    Public cmdaa As Odbc.OdbcCommand
    Public draa As Odbc.OdbcDataReader
    Public daaa As Odbc.OdbcDataAdapter

#End Region

    Public stringtype As String
    Public Modetype As String
    Public DEVLOP01 As String = "DataWorld"

    Public server01 As String = "main\server"
    Public passxx As String = "123456"

    Public Server01_Sug As String = "192.168.101.1"
    Public Passxx_Sug As String = "Infra@123"
    'Public Server01_Sug As String = "Server"
    'Public Passxx_Sug As String = "DATA@123"


    Public USERXX As String = "sa"
    Public HDDSerial As String = ""
    Public Counterxx As Int16 = 0
    Public S_CashChange As String = "N"

    Public WindowsDirectoryPath As String = Environment.GetEnvironmentVariable("windir")
    Public CurrentDirectoryPath As String = Environment.CurrentDirectory
    Public XMLNAME As String = CurrentDirectoryPath & "\DATAWORLD.XML"
    Public XMLNAME_SUG As String = CurrentDirectoryPath & "\DATAWORLDSUG.XML"

    Public dbname As String = "account_om"
    Public dbnam01 As String = ""
    Public dbUrban As String = "financedata"

    Public FontNamexx As String = "MMS-CHITRA"
    Public FontSizexx As Integer = 12

    Public E_FontNamexx As String = "Verdana"
    Public E_FontSizexx As Integer = 8

    'Public CaneSeason01 As String = "SUGAR1415"
    Public CaneSeason01 As String = "SUGAR1516"
    Public MASTER01 As String = "SUGARMASTER"
    Public FARMST As String = "FARMERMST"
    Public PAVATIMST As String = "PAVATIMST"
    Public REGMST As String = "REGMST"
    Public FAMSTR As String = "FAMSTSTR"
    Public ROPMST As String = "ROPMST"
    Public VILLMST As String = "VILLAGEMST"

#Region "Report"

    Public reppath01 As String = ""
    Public REP00 As String = "REP002"
    Public REP00T As String = System.Environment.CurrentDirectory & "\REP002.TXT"

    Public param1Fileds As New CrystalDecisions.Shared.ParameterFields()
    Public param1Field As New CrystalDecisions.Shared.ParameterField()
    Public param1Range As New CrystalDecisions.Shared.ParameterDiscreteValue()

    Public param2Field As New CrystalDecisions.Shared.ParameterField()
    Public param2Range As New CrystalDecisions.Shared.ParameterDiscreteValue()

    Public param3Field As New CrystalDecisions.Shared.ParameterField()
    Public param3Range As New CrystalDecisions.Shared.ParameterDiscreteValue()

    Public param4Field As New CrystalDecisions.Shared.ParameterField()
    Public param4Range As New CrystalDecisions.Shared.ParameterDiscreteValue()

    Public param5Field As New CrystalDecisions.Shared.ParameterField()
    Public param5Range As New CrystalDecisions.Shared.ParameterDiscreteValue()

    Public param6Field As New CrystalDecisions.Shared.ParameterField()
    Public param6Range As New CrystalDecisions.Shared.ParameterDiscreteValue()

    Public param7Field As New CrystalDecisions.Shared.ParameterField()
    Public param7Range As New CrystalDecisions.Shared.ParameterDiscreteValue()

    Public param8Field As New CrystalDecisions.Shared.ParameterField()
    Public param8Range As New CrystalDecisions.Shared.ParameterDiscreteValue()

    Public param9Field As New CrystalDecisions.Shared.ParameterField()
    Public param9Range As New CrystalDecisions.Shared.ParameterDiscreteValue()

    Public param10Field As New CrystalDecisions.Shared.ParameterField()
    Public param10Range As New CrystalDecisions.Shared.ParameterDiscreteValue()

    Public param11Field As New CrystalDecisions.Shared.ParameterField()
    Public param11Range As New CrystalDecisions.Shared.ParameterDiscreteValue()

    Public param12Field As New CrystalDecisions.Shared.ParameterField()
    Public param12Range As New CrystalDecisions.Shared.ParameterDiscreteValue()

    Public param13Field As New CrystalDecisions.Shared.ParameterField()
    Public param13Range As New CrystalDecisions.Shared.ParameterDiscreteValue()

    Public param14Field As New CrystalDecisions.Shared.ParameterField()
    Public param14Range As New CrystalDecisions.Shared.ParameterDiscreteValue()
#End Region

    Enum Language
        English
        Gujarati
    End Enum

    ' Variable Define For Master Files 
#Region "DataBase Variable "
    Public MSMST As String = "ACMASTER"
    Public ITMST As String = "QUALITYMST"
    Public MMMST As String = "MEMBERMST"
    Public ITGMST As String = "ITGROUPMST"
    Public GRMST As String = "GROUPMST"
    Public DSMST As String = "DESCMST"
    Public YRMST As String = "YEARMST"
    Public BOMST As String = "BOKSETUP"
    Public AIMST As String = "ACPETA"
    Public MItgRel As String = "MainItgRel"
    Public MITGMST As String = "MainItGroup"
    Public REMMST As String = "PETACODEMST"
    Public SCHMST As String = "SCHEDULEMST"
    Public UNITMST As String = "UNITMST"
    Public DEPTMST As String = "DEPTMST"
    Public CERTIMST As String = "CERTIMST"
    'Public MemMst As String = "MemberMaster"

    Public BRMST As String = "BRMST"
    Public DCMST As String = "DCMST"
    Public CHMST As String = "CHMST"
    Public COAB As String = ""
    Public com01 As String = ""

    ' Variable Define For Transaction Files 
    Public TRMST As String = "TR" + COAB
    Public FMMST As String = "FM" + COAB
    Public PLMST As String = "PR" + COAB
    Public BIMST As String = "BI" + COAB
    ' Public MMMST As String = "MEM" + COAB
    Public CRMST As String = "CR" + COAB
    Public SodaMSt As String = "Soda" + COAB
    Public SBalMst As String = "SBal" + COAB
    Public EmiMst As String = "EMI" + COAB
    Public QTMST As String = "QT" + COAB

    Public ITBAL As String = "ITBAL" + COAB
    Public ACBAL As String = "ACBAL" + COAB
    Public MEMBAL As String = "MEMBAL" + COAB

    Public STKMST As String = "STK" + COAB
    Public BALMST As String = "BAL" + COAB
    Public GBALMST As String = "GBAL" + COAB
    Public SYSMST As String = "SYS" + COAB

    Public itemBalFunc As String = "itemBal" + COAB
    Public itemBalDateFunc As String = "itemBalDate" + COAB
#End Region

#Region "Printer Option"
    Public S_TaxPaperSize As String = "A4"
    Public S_RetPaperSize As String = "A4"
    Public S_PageOrientation As Integer = 1
#End Region

    ' System Confi Variable Company wise
#Region "System_Config"



    Public S_ShipYn As String = "Y"
    Public S_ChallanYn As String = "N"
    Public S_SalesRound As String = "N"
    Public S_PurchRound As String = "N"
    Public S_SodaPurch As String = "N"

    Public S_DraftYn As String = "Y"
    Public S_BankEntrySM As String = "S"
    Public S_CashEntrySM As String = "S"
    Public S_OnLineAdjus As String = "Y"
    Public S_OnlineBillinfo As String = "N"
    Public S_SpecIssueRec As String = "Y"
    Public S_ScheMstEnt As String = "N"
    Public S_MultiItem As String = "N"
    Public S_LrDetail As String = "N"
    Public S_SaleRateTiger As String = "Y"
    Public S_SaleBillRpt As String = "M"
    Public S_SaleDiscount As String = "N"
    Public S_SaleFromChallan As String = "Y"
    Public S_CalPackOnItem As String = "Y"
    Public S_CashEditBy As String = "N"
    Public S_SalesGroup As String = "041"
    Public S_ClosingStock As String = "D"
    Public S_ClStockOnPackQty As String = "P"

    Public A_Rajusukla As String = "N"
#End Region

    ' FOR HELP
    ' Variable Define For Dos Reports
    Public Ln As Integer = 0  'Line
    Public Lne As Integer = 0
    Public Pg As Integer = 0
    Public Rpg As Integer = 0
    Public Ln01 As Integer, Pgxx As String = ""
    Public Rpl As Integer = 0

    Public DAXX As String = ""
    Public REXX As String = ""
    Public CONXX As String = ""
    Public FLDXX As String = ""
    Public LBXX1 As String = ""
    Public LBXX2 As String = ""
    Public RTXX As String = ""
    Public gstxx As String = ""
    Public cstxx As String = ""
    Public phonxx As String = ""
    Public panxx As String = ""
    Public Trm1xx As String = ""
    Public Trm2xx As String = ""
    Public Trm3xx As String = ""
    Public Trm4xx As String = ""
    Public Trm5xx As String = ""
    Public Bnk1xx As String = ""
    Public Bnk2xx As String = ""
    Public Bnk3xx As String = ""
    Public Bnk4xx As String = ""
    Public CommMastxx As String = ""
    Public ccodxx As Integer = 0

    Public I01 As Integer = 0
    Public Dt001 As Date
    Public Dt002 As Date
    Public KhandSaleStartDt001 As Date
    Public YERXX As String = ""  'year name
    Public yrnoxx As Integer = 0 'year no
    Public YearNamexx As String
    Public conmxx As String = "" ' company name
    Public add1xx As String = "" ' company address
    Public add2xx As String = "" ' company address
    Public add3xx As String = "" ' company address
    Public add4xx As String = "" ' company address
    Public nat1xx As String = "" ' Nature of Bussiness
    Public LICXX As String = "" ' Licence No
    Public EMAILXX As String = "" ' Licence No
    Public SelectMode As String = "AcGroup"
    Public BookClose01 As String = "N"

    Public Sub SystemConf()
        Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
        opencn(dbnam01)
        fillReader("select * from " & SYSMST)
        If dr.HasRows = True Then
            dr.Read()
            S_ShipYn = dr.Item("ShipingAdd")
            S_ChallanYn = dr.Item("ChallInfo")
            S_SalesRound = dr.Item("SalesRound")
            S_PurchRound = dr.Item("PurchRound")
            S_SodaPurch = dr.Item("SodaPurch")

            S_DraftYn = dr.Item("DraftVou")
            S_BankEntrySM = dr.Item("BankEntrySM")
            S_CashEntrySM = dr.Item("CashEntrySM")
            S_OnLineAdjus = dr.Item("Adjusted")
            S_OnlineBillinfo = IIf(IsDBNull(dr.Item("OnLineBillInfo")), "N", dr.Item("OnLineBillInfo"))

            S_SpecIssueRec = IIf(IsDBNull(dr.Item("SpecIssueRec")), "N", dr.Item("SpecIssueRec"))
            S_ScheMstEnt = IIf(IsDBNull(dr.Item("SchemeMstEnt")), "N", dr.Item("SchemeMstEnt"))
            S_MultiItem = IIf(IsDBNull(dr.Item("MultiItmMstEnt")), "N", dr.Item("MultiItmMstEnt"))
            S_LrDetail = IIf(IsDBNull(dr.Item("LrDetail")), "N", dr.Item("LrDetail"))
            S_SaleRateTiger = IIf(IsDBNull(dr.Item("SaleRateTiger")), "N", dr.Item("SaleRateTiger"))
            S_SaleBillRpt = IIf(IsDBNull(dr.Item("SaleBillRpt")), "M", dr.Item("SaleBillRpt"))
            S_SaleDiscount = IIf(IsDBNull(dr.Item("SaleDiscount")), "N", dr.Item("SaleDiscount"))
            S_SaleFromChallan = IIf(IsDBNull(dr.Item("SaleFromChallan")), "N", dr.Item("SaleFromChallan"))
            S_CalPackOnItem = IIf(IsDBNull(dr.Item("CalPackAsItMst")), "N", dr.Item("CalPackAsItMst"))
            S_CashEditBy = IIf(IsDBNull(dr.Item("EditByVouNo")), "N", dr.Item("EditByVouNo"))
            S_SalesGroup = IIf(IsDBNull(dr.Item("SalesGroup")), "041", dr.Item("SalesGroup"))
            S_ClosingStock = IIf(IsDBNull(dr.Item("CLOSINGSTOCK")), "D", dr.Item("CLOSINGSTOCK"))
            S_ClStockOnPackQty = IIf(IsDBNull(dr.Item("CLSTOCKONPACKQTY")), "P", dr.Item("CLSTOCKONPACKQTY"))

        End If
        cn.Close()
    End Sub

    Public Function opencn(ByVal dbnmxx As String)
        Dim STR01 As String = ""
        If stringtype = "SQL" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnmxx & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnmxx & ";User ID=" & USERXX & "; pwd=" & passxx
            End If
        ElseIf stringtype = "EXP" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnmxx & "';Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnmxx & "';User ID=" & USERXX & "; pwd=" & passxx
            End If
        End If
        cn = New SqlClient.SqlConnection(STR01)
        Return cn
    End Function

    Public Function opencn1(ByVal dbnmxx As String)
        Dim STR01 As String = ""

        If stringtype = "SQL" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnmxx & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnmxx & ";User ID=" & USERXX & "; pwd=" & passxx
            End If
        ElseIf stringtype = "EXP" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnmxx & "';Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnmxx & "';User ID=" & USERXX & "; pwd=" & passxx
            End If
        End If
        cn1 = New SqlClient.SqlConnection(STR01)
        Return cn1
    End Function

    Public Function opencn2(ByVal dbnmxx As String)
        Dim STR01 As String = ""

        If stringtype = "SQL" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnmxx & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnmxx & ";User ID=" & USERXX & "; pwd=" & passxx
            End If
        ElseIf stringtype = "EXP" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnmxx & "';Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnmxx & "';User ID=" & USERXX & "; pwd=" & passxx
            End If
        End If
        cn2 = New SqlClient.SqlConnection(STR01)
        '      cn.Open()
        Return cn2
    End Function

    Public Function dbset(ByVal tblxx As String, ByVal rsxx As DataSet) As DataSet
        Dim cm As New SqlClient.SqlCommand(tblxx, cn)
        Dim da As New SqlClient.SqlDataAdapter(cm)
        da.Fill(rsxx)
        Return rsxx
    End Function

    Public Function drset(ByVal tblxx As String, ByVal DBNMXX As String) As SqlClient.SqlCommand

        Dim STR01 As String = ""
        If stringtype = "SQL" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & DBNMXX & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & DBNMXX & ";User ID=" & USERXX & "; pwd=" & passxx
            End If
        ElseIf stringtype = "EXP" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & DBNMXX & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & DBNMXX & "';User ID=" & USERXX & "; pwd=" & passxx
            End If
        End If

        Dim cn As New SqlClient.SqlConnection(STR01)
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim cm As New SqlClient.SqlCommand(tblxx, cn)

        Return cm
    End Function

    Public Function fillReader(ByVal str As String)
        cn.ClearAllPools()
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        cm = New SqlClient.SqlCommand(str, cn)
        cm.CommandTimeout = 450000
        If Not dr Is Nothing Then
            If dr.IsClosed = False Then
                dr.Close()
            End If
        End If
        dr = cm.ExecuteReader()
        Return dr
    End Function

    Public Function fillReader1(ByVal str As String)
        cn1.ClearAllPools()
        If cn1.State <> ConnectionState.Open Then
            cn1.Open()
        Else
            cn1.Close()
            cn1.Open()
        End If
        cm1 = New SqlClient.SqlCommand(str, cn1)
        cm1.CommandTimeout = 450000
        dr1 = cm1.ExecuteReader()
        Return dr1
    End Function

    Public Function fillReader2(ByVal str As String)
        If cn2.State = ConnectionState.Closed Then
            cn2.Open()
        End If
        cm2 = New SqlClient.SqlCommand(str, cn2)
        dr2 = cm2.ExecuteReader()
        Return dr2
    End Function

    Public Function fillDataset(ByVal str1 As String)
        da = New SqlClient.SqlDataAdapter(str1, cn)
        dt = New DataTable()
        da.Fill(dt)
        Return dt
    End Function

    Public Function fillrs(ByVal str1 As String)
        da = New SqlClient.SqlDataAdapter(str1, cn)
        rs = New DataSet
        da.Fill(rs)
        Return rs
    End Function

    Public Function fillhelprs(ByVal str1 As String)
        Dim STR01 As String = ""

        If stringtype = "SQL" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnam01 & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnam01 & ";User ID=" & USERXX & "; pwd=" & passxx
            End If
        ElseIf stringtype = "EXP" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnam01 & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnam01 & "';User ID=" & USERXX & "; pwd=" & passxx
            End If
        End If

        helpcn = New SqlClient.SqlConnection(STR01)
        '      cn.Open()
        helpda = New SqlClient.SqlDataAdapter(str1, helpcn)
        helprs = New DataSet

        helpda.Fill(helprs)
        Return helprs
    End Function

    Public Function fillhelpdr(ByVal str As String)
        On Error GoTo errhandel
        On Error GoTo -1

        If helpcn.State = ConnectionState.Closed Then
            helpcn.Open()
        Else
            helpcn.Close()
            helpcn.Open()
        End If
        helpcm.CommandTimeout = 4500
        helpcm = New SqlClient.SqlCommand(str, helpcn)
        helpdr = helpcm.ExecuteReader()
        Return helpdr
        Exit Function
errhandel:
        If Err.Number = 5 Then
            MsgBox("error # " & Err.Number & " " & Err.Description & " " & Err.LastDllError)
            helpcn.Close()
            helpcn.Open()
            '      MsgBox(str1)
            Resume Next
        Else
            MsgBox("error # " & Err.Number & " " & Err.Description & " " & Err.LastDllError)
            Resume Next
        End If

    End Function

    Public Function openreport(ByVal dbnmxx As String)
        Dim STR01 As String = ""

        If stringtype = "SQL" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnmxx & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnmxx & ";User ID=" & USERXX & "; pwd=" & passxx
            End If
        ElseIf stringtype = "EXP" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnmxx & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnmxx & "';User ID=" & USERXX & "; pwd=" & passxx
            End If
        End If
        helpcn = New SqlClient.SqlConnection(STR01)
        Return cn
    End Function

    Public Function CommandReport(ByVal str1 As String)
        Try
            If helpcn.State = ConnectionState.Closed Then
                helpcn.Open()
            End If
            helpcm = New SqlClient.SqlCommand(str1, helpcn)
            CommandReport = helpcm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            CommandReport = False
            Exit Function
        End Try
    End Function

    Public Function fillReportrs(ByVal str1 As String)
        Dim STR01 As String = ""

        If stringtype = "SQL" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & REP00 & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & REP00 & ";User ID=" & USERXX & "; pwd=" & passxx
            End If
        ElseIf stringtype = "EXP" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & REP00 & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & REP00 & "';User ID=" & USERXX & "; pwd=" & passxx
            End If
        End If

        helpcn = New SqlClient.SqlConnection(STR01)
        helpda = New SqlClient.SqlDataAdapter(str1, helpcn)
        helpda.SelectCommand.CommandTimeout = 500000
        helprs = New DataSet
        helpda.Fill(helprs)
        Return helprs
    End Function

    Public Function fillReportrs1(ByVal str1 As String)
        'Dim str01 As String = "Data Source=SERVER;Initial Catalog=" & dbnam01 & ";Integrated Security=True"

        Dim STR01 As String = ""

        If stringtype = "SQL" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & REP00 & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & REP00 & ";User ID=" & USERXX & "; pwd=" & passxx
            End If
        ElseIf stringtype = "EXP" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & REP00 & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & REP00 & "';User ID=" & USERXX & "; pwd=" & passxx
            End If
        End If

        helpcn = New SqlClient.SqlConnection(STR01)
        '      cn.Open()
        helpda = New SqlClient.SqlDataAdapter(str1, helpcn)
        helprs1 = New DataSet
        helpda.Fill(helprs1)
        Return helprs1
    End Function

    Public Sub setdblogonforreport(ByVal myconnectioninfo As ConnectionInfo, ByVal crrfrm As CrystalDecisions.Windows.Forms.CrystalReportViewer)

        Dim mytablelogoninfos As TableLogOnInfos = crrfrm.LogOnInfo
        Dim mytablelogoninfo As TableLogOnInfo = New TableLogOnInfo
        For Each mytablelogoninfo In mytablelogoninfos
            mytablelogoninfo.ConnectionInfo = myconnectioninfo
        Next
    End Sub

    Public Function CommandExe(ByVal str1 As String)
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            '        opencn(dbnam01)
            cm = New SqlClient.SqlCommand(str1, cn)
            CommandExe = cm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            CommandExe = False
            Exit Function
        End Try
        '  commandexe = cm.ExecuteNonQuery()
    End Function

    Public Function CommExe(ByVal str1 As String, Optional ByVal dbnamxx As String = "") As Integer

        If dbnamxx = "" Then
            dbnamxx = dbnam01
        End If
        CommExe = 0
        On Error GoTo errhandel
        On Error GoTo -1

        Dim STR01 As String = ""

        If stringtype = "SQL" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnamxx & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnamxx & ";User ID=" & USERXX & "; pwd=" & passxx
            End If
        ElseIf stringtype = "EXP" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnamxx & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnamxx & "';User ID=" & USERXX & "; pwd=" & passxx
            End If
        End If
        cn = New SqlClient.SqlConnection(STR01)
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        Else
            cn.Close()
            cn.Open()
        End If
        cm = New SqlClient.SqlCommand(str1, cn)
        CommExe = cm.ExecuteNonQuery()
        Return CommExe
        Exit Function
errhandel:
        If Err.Number = 5 Then
            MsgBox("error # " & Err.Number & " " & Err.Description & " " & Err.LastDllError)
            '      MsgBox(str1)
            CommExe = Err.Number
            Resume Next
        Else
            MsgBox("error # " & Err.Number & " " & Err.Description & " " & Err.LastDllError)
            MsgBox(str1)
            CommExe = Err.Number
            Resume Next
        End If
    End Function

    Public Function CommExe1(ByVal str1 As String) As Integer
        'opencn(dbnam01)
        CommExe1 = 0
        On Error GoTo errhandel
        On Error GoTo -1
        'On Error Resume Next

        Dim STR01 As String = ""

        If stringtype = "SQL" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnam01 & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnam01 & ";User ID=" & USERXX & "; pwd=" & passxx
            End If
        ElseIf stringtype = "EXP" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnam01 & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnam01 & "';User ID=" & USERXX & "; pwd=" & passxx
            End If
        End If
        cn1 = New SqlClient.SqlConnection(STR01)
        If cn1.State = ConnectionState.Closed Then
            cn1.Open()
        Else
            cn1.Close()
            cn1.Open()
        End If
        cm1 = New SqlClient.SqlCommand(str1, cn1)
        CommExe1 = cm1.ExecuteNonQuery()
        Return CommExe1
        Exit Function
errhandel:
        If Err.Number = 5 Then
            MsgBox("error # " & Err.Number & " " & Err.Description & " " & Err.LastDllError)
            '      MsgBox(str1)
            CommExe1 = Err.Number
            Resume Next
        Else
            MsgBox("error # " & Err.Number & " " & Err.Description & " " & Err.LastDllError)
            MsgBox(str1)
            CommExe1 = Err.Number
            Resume Next
        End If
    End Function

    Public Function CommExe2(ByVal str1 As String, ByVal dbnxx As String) As Integer
        'opencn(dbnam01)
        CommExe2 = 0
        On Error GoTo errhandel
        On Error GoTo -1
        'On Error Resume Next
        cn2.Dispose()
        Dim STR01 As String = ""

        If stringtype = "SQL" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnxx & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnxx & ";User ID=" & USERXX & "; pwd=" & passxx
            End If
        ElseIf stringtype = "EXP" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnxx & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnxx & "';User ID=" & USERXX & "; pwd=" & passxx
            End If
        End If
        cn2 = New SqlClient.SqlConnection(STR01)
        If cn2.State = ConnectionState.Closed Then
            cn2.Open()
        Else
            cn2.Close()
            cn2.Open()
        End If
        cm2 = New SqlClient.SqlCommand(str1, cn2)
        CommExe2 = cm2.ExecuteNonQuery()
        Return CommExe2
        Exit Function
errhandel:
        If Err.Number = 5 Then
            MsgBox("error # " & Err.Number & " " & Err.Description & " " & Err.LastDllError)
            '      MsgBox(str1)
            CommExe2 = Err.Number
            Resume Next
        Else
            MsgBox("error # " & Err.Number & " " & Err.Description & " " & Err.LastDllError)
            MsgBox(str1)
            CommExe2 = Err.Number
            Resume Next
        End If
    End Function

    Public Function SetGroupbox(ByVal GRBoxxx As GroupBox)
        Dim x As Control
        GRBoxxx.BackColor = Color.Bisque
        For Each x In GRBoxxx.Controls
            x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)

            If TypeOf x Is Form Or TypeOf x Is GroupBox Or TypeOf x Is Label Or TypeOf x Is RadioButton Then
                x.ForeColor = Color.Blue
                x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)
            End If

            If TypeOf x Is GroupBox Then
                x.BackColor = Color.Bisque
                If UCase(x.Name) = "GRPBUTT" Then
                    x.BackColor = Color.Thistle
                End If
                x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
                'x.BackColor = Color.PaleTurquoise
            End If


            If TypeOf x Is CheckBox Then
                x.BackColor = Color.Bisque
                x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)

                '                x.BackColor = Color.White
            End If
            If TypeOf x Is RadioButton Then
                x.BackColor = Color.Bisque
                x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
                '                x.BackColor = Color.White
            End If
            If TypeOf x Is ComboBox Then
                x.BackColor = Color.Bisque
                'x.BackColor = Color.White
            End If
            If TypeOf x Is Button Then
                If UCase(x.Name) = "CMDSAVE" Then
                    x.BackColor = Color.Tan
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
                ElseIf UCase(x.Name) = "CMDCANCEL" Then
                    x.BackColor = Color.Moccasin
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
                ElseIf UCase(x.Name) = "CMDEXIT" Then
                    x.BackColor = Color.Goldenrod
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
                ElseIf UCase(x.Name) = "CMDQUIT" Then
                    x.BackColor = Color.BurlyWood
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
                ElseIf UCase(x.Name) = "CMDDELETE" Then
                    x.BackColor = Color.Olive
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
                ElseIf UCase(x.Name) = "CMDVIEW" Then
                    x.BackColor = Color.Aquamarine
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
                ElseIf UCase(x.Name) = "CMDPRINT" Then
                    x.BackColor = Color.Azure
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
                ElseIf UCase(x.Name) = "CMDPREVIOUS" Then
                    x.BackColor = Color.Azure
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
                ElseIf UCase(x.Name) = "CMDNEXT" Then
                    x.BackColor = Color.Aquamarine
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
                End If
            End If
            If TypeOf x Is TextBox Then
                x.BackColor = Color.White
                x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
            End If
        Next
        Return GRBoxxx
    End Function

    Public Function UPDGRID(ByRef GRID As System.Windows.Forms.DataGridView, Optional ByVal HeadGuj_Eng As Language = Language.English, Optional ByVal RowGuj_Eng As Language = Language.English) As System.Windows.Forms.DataGridView
        If HeadGuj_Eng = Language.English Then
            GRID.ColumnHeadersDefaultCellStyle.Font = New Font(E_FontNamexx, E_FontSizexx, FontStyle.Regular)
        Else
            GRID.ColumnHeadersDefaultCellStyle.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
        End If
        If RowGuj_Eng = Language.English Then
            GRID.RowTemplate.DefaultCellStyle.Font = New Font(E_FontNamexx, E_FontSizexx, FontStyle.Regular)
        Else
            GRID.RowTemplate.DefaultCellStyle.Font = New Font(FontNamexx, FontSizexx, FontStyle.Regular)
        End If
        Return GRID
    End Function

    Public Function updcall(ByVal frxx As Form)
        Dim x As Control
        frxx.BackColor = Color.Bisque
        For Each x In frxx.Controls
            x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)

            If TypeOf x Is Form Or TypeOf x Is GroupBox Or TypeOf x Is Label Or TypeOf x Is RadioButton Then
                x.ForeColor = Color.Blue
                x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)
            End If

            If TypeOf x Is GroupBox Then
                x.BackColor = Color.Bisque
                If UCase(x.Name) = "GRPBUTT" Then
                    x.BackColor = Color.Thistle
                End If
                x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)
                'x.BackColor = Color.PaleTurquoise
            End If


            If TypeOf x Is CheckBox Then
                x.BackColor = Color.Bisque
                x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)
            End If
            If TypeOf x Is RadioButton Then
                x.BackColor = Color.Bisque
                x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)
                '                x.BackColor = Color.White
            End If
            If TypeOf x Is ComboBox Then
                x.BackColor = Color.Bisque
                'x.BackColor = Color.White
            End If
            If TypeOf x Is Button Then
                If UCase(x.Name) = "CMDSAVE" Then
                    x.BackColor = Color.Tan
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)
                ElseIf UCase(x.Name) = "CMDCANCEL" Then
                    x.BackColor = Color.Moccasin
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)
                ElseIf UCase(x.Name) = "CMDEXIT" Then
                    x.BackColor = Color.Goldenrod
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)
                ElseIf UCase(x.Name) = "CMDQUIT" Then
                    x.BackColor = Color.BurlyWood
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)
                ElseIf UCase(x.Name) = "CMDDELETE" Then
                    x.BackColor = Color.Olive
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)
                ElseIf UCase(x.Name) = "CMDVIEW" Then
                    x.BackColor = Color.Aquamarine
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)
                ElseIf UCase(x.Name) = "CMDPRINT" Then
                    x.BackColor = Color.Azure
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)
                ElseIf UCase(x.Name) = "CMDPREVIOUS" Then
                    x.BackColor = Color.Azure
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)
                ElseIf UCase(x.Name) = "CMDNEXT" Then
                    x.BackColor = Color.Aquamarine
                    x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)
                End If
            End If
            If TypeOf x Is TextBox Then
                x.BackColor = Color.White
                x.Font = New Font(FontNamexx, FontSizexx, FontStyle.Bold)
            End If
        Next
        Return frxx
    End Function

    Public Function MaxOf(ByVal strxx As String)
        opencn(dbnam01)
        fillReader(strxx)
        With dr
            .Read()
            If .HasRows = True Then
                If Convert.ToString(.Item(0)) = "" Then
                    MaxOf = 1
                Else
                    MaxOf = Val(Convert.ToString(.Item(0))) + 1
                End If
            Else
                MaxOf = 1
            End If
        End With
        cn.Close()
        Return MaxOf
    End Function

    Public Function findconindex(ByVal frxx As Form, ByVal strxx As String) As Integer
        Dim x As Control
        For Each x In frxx.Controls
            If x.Name = strxx Then
                findconindex = frxx.Controls.IndexOf(x)
            End If
        Next
        Return findconindex
    End Function

    Public Function mview()
        mview = RTXX
        RTXX = ""
        Return mview
    End Function

    Public Function CodCnv(ByVal Cod_ As String, ByVal Len_ As Integer) As String
        Dim i As Integer
        Dim CH As String
        Dim st1 As String, st2 As String
        st1 = ""
        st2 = ""
        i = 1
        Do While i <= Len(Trim(Cod_))
            CH = UCase(Mid$(Trim(Cod_), i, 1))
            If CH <> " " Then
                If CH >= "0" And CH <= "9" Then
                    st2 = st2 + CH
                Else
                    st1 = st1 + CH
                End If
            End If
            i = i + 1
        Loop
        If Len_ = 0 Then
            CodCnv = st1 + st2
        Else
            CodCnv = Left(st1 + "00000000000000000000", Len_ - Len(st2)) + st2
        End If
    End Function

    Public Function Codspc(ByVal Cod As String, ByVal Len_ As Integer) As String
        Dim st1 As String
        st1 = Trim(Cod)
        If Len_ = 0 Then
            Codspc = st1
        Else
            Codspc = Space(Len_ - Len(st1)) + st1
        End If
    End Function

    Public Function numspc(ByVal cod As Double) As String
        If cod <> 0 Then
            numspc = Format(cod, "#.00")
        Else
            numspc = ""
        End If
    End Function

    Public Function atow(ByVal txx As String) As String
        Dim a(90) As String, B As Double
        a(1) = "One"
        a(2) = "Two"
        a(3) = "Three"
        a(4) = "Four"
        a(5) = "Five"
        a(6) = "Six"
        a(7) = "Seven"
        a(8) = "Eight"
        a(9) = "Nine"
        a(10) = "Ten"
        a(11) = "Eleven"
        a(12) = "Twelve"
        a(13) = "Thirteen"
        a(14) = "Fourteen"
        a(15) = "Fifteen"
        a(16) = "Sixteen"
        a(17) = "Seventeen"
        a(18) = "Eighteen"
        a(19) = "Nineteen"
        a(20) = "Twenty"
        a(30) = "Thirty"
        a(40) = "Fourty"
        a(50) = "Fifty"
        a(60) = "Sixty"
        a(70) = "Seventy"
        a(80) = "Eighty"
        a(90) = "Ninety"

        Dim wrd As String
        Dim b99 As Double
        Dim b2 As Double, b1 As Double, b3 As Double
        B = Val(txx)
        wrd = ""
        b99 = B
        If b99 > 9999999.99 Then
            b1 = FIXR(b99 / 10000000)
            b2 = b1
            If b2 > 20 Then
                b3 = FIXR(b2 / 10) * 10
                b2 = b2 - b3
                'VB = "A" + Str(B3, 2)
                wrd = wrd + a(b3) + " "
            End If '(B2>20)
            wrd = wrd + a(b2) + " "
            b99 = b99 - b1 * 10000000
            wrd = wrd + "Crore "
        End If '(B99 >9999999.99)

        If b99 > 99999.99 Then
            b1 = FIXR(b99 / 100000)
            b2 = b1
            If b2 > 20 Then
                b3 = FIXR(b2 / 10) * 10
                b2 = b2 - b3
                'VB = "A" + Str(b3, 2)
                wrd = wrd + a(b3) + " "
            End If '(B2>20)
            wrd = wrd + a(b2) + " "
            b99 = b99 - b1 * 100000
            wrd = wrd + "Lakh "
        End If '(B99 >99999.99)

        If b99 > 999.99 Then
            b1 = FIXR(b99 / 1000)
            b2 = b1
            If b2 > 20 Then
                b3 = FIXR(b2 / 10) * 10
                b2 = b2 - b3
                'VB = "A" + Str(b3, 2)
                wrd = wrd + a(b3) + " "
            End If ' (B2>20)
            wrd = wrd + a(b2) + " "
            b99 = b99 - b1 * 1000
            wrd = wrd + "Thousand "
        End If '(B99 >999.99)

        If b99 > 99.99 Then
            b1 = FIXR(b99 / 100)
            b2 = b1
            If b2 > 20 Then
                b3 = FIXR(b2 / 10) * 10
                b2 = b2 - b3
                wrd = wrd + a(b3) + " "
            End If '(B2>20)
            wrd = wrd + a(b2) + " "
            b99 = b99 - b1 * 100
            wrd = wrd + "Hundred "
        End If '(B99 >99.99)

        If b99 > 0.99 Then
            b1 = FIXR(b99)
            b2 = b1
            If b2 > 20 Then
                b3 = FIXR(b2 / 10) * 10
                b2 = b2 - b3
                wrd = wrd + a(b3) + " "
            End If '(B2>20)
            wrd = wrd + a(b2) + " "
            b99 = b99 - b1 * 1
            wrd = wrd + ""
        End If '(B99 > .99)

        If b99 > 0 Then
            If Len(Trim(wrd)) <> 0 Then
                wrd = wrd + " And "
            End If '(LEN(TRIM(WRD)) <> 0)
            wrd = wrd + " Paisa "
            b1 = b99 * 100 + 0.005
            b2 = b1
            If b2 > 20 Then
                b3 = FIXR(b2 / 10) * 10
                b2 = b2 - b3
                wrd = wrd + a(b3) + " "
            End If '(B2>20)

            If b2 <> 0 Then
                wrd = wrd + a(b2) + " "
            End If '(B2 <> 0)
            'WRD=WRD+&VB+""
            wrd = wrd + ""
        End If '(B99 > 0)
        atow = wrd + "Only"
    End Function

    Public Function FIXR(ByVal d As Double) As Double
        FIXR = Int(d)
    End Function

    Public Function DateChk(ByVal DTXX As Date) As Boolean
        If Not IsDate(DTXX) Then
            MsgBox("Pl. Enter Proper Date ", vbInformation, DEVLOP01)
            DateChk = False
        ElseIf DTXX < Dt001 Or DTXX > Dt002 Then
            MsgBox("Pl. Enter Date From " & Dt001 & " To " & Dt002, MsgBoxStyle.OkOnly, DEVLOP01)
            DateChk = False
        Else
            DateChk = True
        End If
    End Function

    Public Function chkdate(ByVal DTXX As Date) As Boolean
        If Not IsDate(DTXX) Then
            MsgBox("Pl. Enter Proper Date ", vbInformation, DEVLOP01)
            chkdate = False
        Else
            chkdate = True
        End If
    End Function

    Public Function CreateReportDatabase() As Boolean
        cn.Close()
        Dim Str01 As String
        If Not CHEKDATABASE(REP00) Then
            Str01 = "create database [" & REP00 & "]"
            opencn(dbnam01)
            CommandExe(Str01)
            cn.Close()
        End If
        opencn(REP00)

        CHECKTABEL("MoreReg")
        Str01 = "create table MoreReg ([ACCODE] [int] NULL,[name] [nvarchar](40) null, [Amount] [numeric](18,2) null DEFAULT ((0)))"
        CommandExe(Str01)

        CHECKTABEL("cashrpt")
        Str01 = "create table CashRpt ([BILLDATE] [datetime] NULL ,[VNO] [numeric](10)  null ,[ACCODE] [int] NULL,[SUBCODE] [int] NULL,"
        Str01 = Str01 & "[Acname] [nvarchar](100) null,[name] [nvarchar](100) null, [CREDIT] [numeric](18,2) null DEFAULT ((0)),"
        Str01 = Str01 & "[DEBIT] [numeric](18,2) null DEFAULT ((0)), [DESCRIPTION] [nvarchar](100) NULL,"
        Str01 = Str01 & "[DES1] [nvarchar](100) NULL,[DES2] [nvarchar](100) NULL,[DES3] [nvarchar](100) NULL,"
        Str01 = Str01 & "[DES4] [nvarchar](100) NULL, [balance] [numeric](18,2) NOT NULL DEFAULT ((0)), "
        Str01 = Str01 & "[CRCASH] [numeric](18,2) NOT NULL DEFAULT ((0)), [CRTRSF] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[CRBANK] [numeric](18,2) NOT NULL DEFAULT ((0)), "
        Str01 = Str01 & "[DBCASH] [numeric](18,2) NOT NULL DEFAULT ((0)), [DBTRSF] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[DBBANK] [numeric](18,2) NOT NULL DEFAULT ((0))) "
        CommandExe(Str01)

        CHECKTABEL("Rojnishi")
        Str01 = "create table Rojnishi ([BILLDATE] [datetime] NULL ,[VNO] [numeric](10)  NOT NULL ,[ACCODE] [int] NULL, "
        Str01 = Str01 & "[name] [nvarchar](40) NOT NULL, [CREDIT] [numeric](18,2) NOT NULL DEFAULT ((0)), "
        Str01 = Str01 & "[DEBIT] [numeric](18,2) NOT NULL DEFAULT ((0)), [DESCRIPTION] [nvarchar](50) NULL, "
        Str01 = Str01 & "[DES1] [nvarchar](50) NULL,[DES2] [nvarchar](50) NULL,[DES3] [nvarchar](50) NULL, "
        Str01 = Str01 & "[DES4] [nvarchar](50) NULL, [balance] [numeric](18,2) NOT NULL DEFAULT ((0)), "
        Str01 = Str01 & "[CRCASH] [numeric](18,2) NOT NULL DEFAULT ((0)), [CRTRSF] [numeric](18,2) NOT NULL DEFAULT ((0)), "
        Str01 = Str01 & "[CRBANK] [numeric](18,2) NOT NULL DEFAULT ((0)), "
        Str01 = Str01 & "[DBCASH] [numeric](18,2) NOT NULL DEFAULT ((0)), [DBTRSF] [numeric](18,2) NOT NULL DEFAULT ((0)), "
        Str01 = Str01 & "[DBBANK] [numeric](18,2) NOT NULL DEFAULT ((0)), "
        Str01 = Str01 & "[CRDB] [smallint]  NULL, [TRNTYPE] [smallint]  NULL, "
        Str01 = Str01 & "[MEMNO] [INT], [MemName] [nvarchar](50) NULL,[RPTYPE] NVARCHAR(4),PRINTSEQ [NUMERIC](18,2)"
        Str01 = Str01 & ")"
        CommandExe(Str01)

        CHECKTABEL("bankrpt")
        Str01 = "create table BankRpt ([BILLDATE] [datetime] NULL ,[VNO] [numeric](10)  NOT NULL ,[ACCODE] [int] NULL,[SUBCODE] [int] NULL,"
        Str01 = Str01 & "[Acname] [nvarchar](40) NOT NULL,[name] [nvarchar](40) NOT NULL, [CREDIT] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[DEBIT] [numeric](18,2) NOT NULL DEFAULT ((0)), [DESCRIPTION] [nvarchar](50) NULL,"
        Str01 = Str01 & "[DES1] [nvarchar](50) NULL,	[DES2] [nvarchar](50) NULL,[DES3] [nvarchar](50) NULL,"
        Str01 = Str01 & "[DES4] [nvarchar](50) NULL, [balance] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[RPTYPE] [nvarchar](2) NOT NULL,[chequeno] [nvarchar](15) NULL)"
        CommandExe(Str01)

        CHECKTABEL("salerpt")
        Str01 = "create table SaleRpt ([BILLDATE] [datetime] NULL,[VNO] [numeric](10) NOT NULL,"
        Str01 = Str01 & "[ACCODE] [int] NULL,[name] [nvarchar](40) NOT NULL,[Amount] [numeric](18,2) "
        Str01 = Str01 & "NOT NULL DEFAULT ((0)), [ITEMCODE] [int] NULL,[ItemName] [nvarchar](60) NOT NULL,"
        Str01 = Str01 & "[PACK] [int] NOT NULL DEFAULT ((0)),[WEIGHT] [float] NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[GAmount] [float] NOT NULL DEFAULT ((0)), [vatrate] [float] NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[vatamount] [float] NOT NULL DEFAULT ((0)),[TAmount] [float] NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "Seq [int] NOT NULL DEFAULT ((0)),[st_no] [nvarchar](50) NOT NULL,[AdvVat] [float] "
        Str01 = Str01 & "NOT NULL DEFAULT ((0)),[AdvAmt] [float] NOT NULL DEFAULT ((0)),[Gname] [nvarchar](40),"
        Str01 = Str01 & "Weight1 [float] NOT NULL DEFAULT ((0)),[add1] [nvarchar] (50),[add2] [nvarchar] (50),[add3] [nvarchar] (50),[add4] [nvarchar] (50))"
        CommandExe(Str01)


        CHECKTABEL("TRIAL")
        Str01 = " CREATE TABLE TRIAL " & _
                " (GCODE [NVARCHAR](3),GNAME [NVARCHAR](100),ACCODE [INT] NOT NULL, NAME [NVARCHAR](100) NOT NULL ,CREDIT [NUMERIC](18,2)," & _
                " DEBIT [NUMERIC](18,2),ADDRESS [NVARCHAR](100))"
        CommandExe(Str01)

        CHECKTABEL("jvrpt")
        Str01 = "create table JvRpt ([BILLDATE] [datetime] NULL ,[VNO] [nvarchar](10) NOT NULL ,[ACCODE] [int] NULL,[SUBCODE] [int] NULL,"
        Str01 = Str01 & "[Acname] [nvarchar](40) NOT NULL,[SubName] [nvarchar](40) NOT NULL, [CREDIT] [numeric](18,2) ,[DEBIT] [numeric](18,2) ,"
        Str01 = Str01 & "[DESCRIPTION] [nvarchar](50) NULL,	[DES1] [nvarchar](50) NULL,	[DES2] [nvarchar](50) NULL,"
        Str01 = Str01 & "[DES3] [nvarchar](50) NULL,[DES4] [nvarchar](50) NULL, [balance] [numeric](18,2), "
        Str01 = Str01 & "pvno [numeric](10), MemNo [int] null, MemName [nvarchar] (50))"
        CommandExe(Str01)

        CHECKTABEL("Ledger")
        Str01 = "create table Ledger ([BILLDATE] [datetime] NULL ,[VNO] [numeric](10,2) NOT NULL ,[ACCODE] [int] NULL,[SUBCODE] [int] NULL,"
        Str01 = Str01 & "[Acname] [nvarchar](125) NOT NULL,[name] [nvarchar](125) NOT NULL, [CREDIT] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[DEBIT] [numeric](18,2) NOT NULL DEFAULT ((0)), [DESCRIPTION] [nvarchar](50) NULL,"
        Str01 = Str01 & "[DES1] [nvarchar](50) NULL,[DES2] [nvarchar](50) NULL,[DES3] [nvarchar](50) NULL,"
        Str01 = Str01 & "[DES4] [nvarchar](50) NULL, [balance] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[ACCODE1] [int] NULL,[SUBCODE1] [int] NULL,[Acname1] [nvarchar](125) NOT NULL,[name1] [nvarchar](125) NOT NULL, "
        Str01 = Str01 & "[add1] [nvarchar](50) NULL,[add2] [nvarchar](50) NULL,[add3] [nvarchar](50) NULL,"
        Str01 = Str01 & "[add4] [nvarchar](50) NULL,[panno] [nvarchar](40) NULL, [shortname] [nvarchar](10))"
        CommandExe(Str01)

        CHECKTABEL("Ledger")
        Str01 = "create table Ledger ([BILLDATE] [datetime] NULL ,[VNO] [numeric](10,2) NOT NULL ,[ACCODE] [int] NULL,[SUBCODE] [int] NULL,"
        Str01 = Str01 & "[Acname] [nvarchar](125) NOT NULL,[name] [nvarchar](125) NOT NULL, [CREDIT] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[DEBIT] [numeric](18,2) NOT NULL DEFAULT ((0)), [DESCRIPTION] [nvarchar](150) NULL,"
        Str01 = Str01 & "[DES1] [nvarchar](150) NULL,[DES2] [nvarchar](150) NULL,[DES3] [nvarchar](150) NULL,"
        Str01 = Str01 & "[DES4] [nvarchar](150) NULL, [balance] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[ACCODE1] [int] NULL,[SUBCODE1] [int] NULL,[Acname1] [nvarchar](125) NOT NULL,[name1] [nvarchar](125) NOT NULL, "
        Str01 = Str01 & "[add1] [nvarchar](50) NULL,[add2] [nvarchar](50) NULL,[add3] [nvarchar](50) NULL,"
        Str01 = Str01 & "[add4] [nvarchar](50) NULL,[panno] [nvarchar](40) NULL, [shortname] [nvarchar](10))"
        CommandExe(Str01)


        CHECKTABEL("bankrecon")
        Str01 = "create table bankrecon (TYPE [NVARCHAR](1),[BILLDATE] [datetime] NULL ,[VNO] [nvarchar](10) NOT NULL ,[ACCODE] [int] NULL,"
        Str01 = Str01 & "[name] [nvarchar](40) NOT NULL, [amount] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[amount1] [numeric](18,2) NOT NULL DEFAULT ((0)))"
        CommandExe(Str01)

        CHECKTABEL("bankod")
        Str01 = "create table bankod ([CLGDATE] [datetime] NULL ,[BILLDATE] [datetime] NULL ,[VNO] [nvarchar](10) NOT NULL ,"
        Str01 = Str01 & "[ACCODE] [int] NULL,[name] [nvarchar](40) NOT NULL, [Reciptes] [numeric](18,2) NULL,"
        Str01 = Str01 & "[Payments] [numeric](18,2) NULL,[BALANCE] [numeric](18,2) NULL,[DAYS] [numeric](18,2) NULL,"
        Str01 = Str01 & "[INTREST] [numeric](18,2) NULL)"
        CommandExe(Str01)


        CHECKTABEL("bankBillrpt")
        Str01 = "create table BankBillRpt ([BILLDATE] [datetime] NULL ,[VNO] [nvarchar](10) NOT NULL ,[ACCODE] [int] NULL,"
        Str01 = Str01 & "[name] [nvarchar](40) NOT NULL, [Chqno] [nvarchar](50) NULL, "
        Str01 = Str01 & "[DESCRIPTION] [nvarchar](50) NULL, [Amount] [numeric](18,2) NOT NULL DEFAULT ((0)))"
        CommandExe(Str01)


        CHECKTABEL("dtrial")
        Str01 = "create table dtrial (caccode [INT] ,cname [nvarchar](60) ,credit [numeric](18,2)" & _
                ",tcredit [numeric](18,2),crtag [nvarchar](2),daccode [int] ,dname [nvarchar](60)," & _
                "debit [numeric](18, 2),tdebit [numeric](18,2),drtag [nvarchar](2),uniqno [int] IDENTITY(1,1)"
        Str01 = Str01 + "NOT FOR REPLICATION NOT NULL )"
        CommandExe(Str01)

        CHECKTABEL("DLedger")
        Str01 = "create table DLedger ([CBILLDATE] [datetime] NULL ,[CVNO] [numeric](10,2) NOT NULL ,[CACCODE] [int] NULL,[CSUBCODE] [int] NULL,"
        Str01 = Str01 & "[CAcname] [nvarchar](100) NOT NULL,[Cname] [nvarchar](100) NOT NULL, [CREDIT] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[CDESCRIPTION] [nvarchar](65) NULL,[CDES1] [nvarchar](50) NULL,[CDES2] [nvarchar](50) NULL,"
        Str01 = Str01 & "[CDES3] [nvarchar](50) NULL,[CDES4] [nvarchar](50) NULL, "
        Str01 = Str01 & "[DBILLDATE] [datetime] NULL ,[DVNO] [numeric](10,2) NOT NULL ,[DACCODE] [int] NULL,[DSUBCODE] [int] NULL,"
        Str01 = Str01 & "[DAcname] [nvarchar](100) NOT NULL,[Dname] [nvarchar](100) NOT NULL, [DEBIT] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[DDESCRIPTION] [nvarchar](65) NULL,[DDES1] [nvarchar](50) NULL,[DDES2] [nvarchar](50) NULL,"
        Str01 = Str01 & "[DDES3] [nvarchar](50) NULL,[DDES4] [nvarchar](50) NULL,[ACCODE1] [int] NULL,"
        Str01 = Str01 & "[name1] [nvarchar](100) NOT NULL, [SubCode1] int, [SubName1] nvarchar(100), [add1] [nvarchar](50) NULL,[add2] [nvarchar](50) NULL,"
        Str01 = Str01 & "[add3] [nvarchar](50) NULL,[add4] [nvarchar](50) NULL,[panno] [nvarchar](40) NULL,"
        Str01 = Str01 & "[Cshortname] [nvarchar](10),[Dshortname] [nvarchar](10))"
        CommandExe(Str01)

        CHECKTABEL("DCashRpt")
        Str01 = "create table DCashRpt ([CBILLDATE] [datetime] NULL ,[CVNO] [numeric](10)  NOT NULL,[CACCODE] [int] NULL,[CSUBCODE] [int] NULL,"
        Str01 = Str01 & "[CAcname] [nvarchar](100) NOT NULL,[CName] [nvarchar](100) NOT NULL,[CREDIT] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[CDESCRIPTION] [nvarchar](100) NULL,[CDES1] [nvarchar](100) NULL,[CDES2] [nvarchar](100) NULL,"
        Str01 = Str01 & "[CDES3] [nvarchar](100) NULL,[CDES4] [nvarchar](100) NULL,[DBILLDATE] [datetime] NULL ,"
        Str01 = Str01 & "[DVNO] [numeric](10)  NOT NULL,[DACCODE] [int] NULL,[DSUBCODE] [int] NULL,[DAcname] [nvarchar](100) NOT NULL,[DName] [nvarchar](100) NOT NULL,"
        Str01 = Str01 & "[Debit] [numeric](18,2) NOT NULL DEFAULT ((0)),[DDESCRIPTION] [nvarchar](100) NULL,"
        Str01 = Str01 & "[DDES1] [nvarchar](100) NULL,[DDES2] [nvarchar](100) NULL,[DDES3] [nvarchar](100) NULL,"
        Str01 = Str01 & "[DDES4] [nvarchar](100) NULL,"
        Str01 = Str01 & "[CCASH] [numeric](18,2) NOT NULL DEFAULT ((0)), [CTRSF] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[CBANK] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[DCASH] [numeric](18,2) NOT NULL DEFAULT ((0)), [DTRSF] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[DBANK] [numeric](18,2) NOT NULL DEFAULT ((0)))"
        CommandExe(Str01)


        CHECKTABEL("DateCashRpt")
        Str01 = "create table DateCashRpt ([CBILLDATE] [datetime] NULL ,[CVNO] [numeric](10)  NOT NULL,[CACCODE] [int] NULL,[CSUBCODE] [int] NULL,"
        Str01 = Str01 & "[CAcname] [nvarchar](100) NOT NULL,[CName] [nvarchar](100) NOT NULL,[CREDIT] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[CDESCRIPTION] [nvarchar](100) NULL,[CDES1] [nvarchar](100) NULL,[CDES2] [nvarchar](100) NULL,"
        Str01 = Str01 & "[CDES3] [nvarchar](100) NULL,[CDES4] [nvarchar](100) NULL,[DBILLDATE] [datetime] NULL ,"
        Str01 = Str01 & "[DVNO] [numeric](10)  NOT NULL,[DACCODE] [int] NULL,[DSUBCODE] [int] NULL,[DAcname] [nvarchar](100) NOT NULL,[DName] [nvarchar](100) NOT NULL,"
        Str01 = Str01 & "[Debit] [numeric](18,2) NOT NULL DEFAULT ((0)),[DDESCRIPTION] [nvarchar](100) NULL,"
        Str01 = Str01 & "[DDES1] [nvarchar](100) NULL,[DDES2] [nvarchar](100) NULL,[DDES3] [nvarchar](100) NULL,"
        Str01 = Str01 & "[DDES4] [nvarchar](100) NULL,[BillDate] DateTime Null, "
        Str01 = Str01 & "[CCASH] [numeric](18,2) NOT NULL DEFAULT ((0)), [CTRSF] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[CBANK] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[DCASH] [numeric](18,2) NOT NULL DEFAULT ((0)), [DTRSF] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[DBANK] [numeric](18,2) NOT NULL DEFAULT ((0)))"
        CommandExe(Str01)

        CHECKTABEL("DBankRpt")
        Str01 = "create table DBankRpt ([CBILLDATE] [datetime] NULL ,[CVNO] [numeric](10)  NOT NULL,[CACCODE] [int] NULL,"
        Str01 = Str01 & "[CName] [nvarchar](40) NOT NULL,[CREDIT] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[CDESCRIPTION] [nvarchar](50) NULL,[CDES1] [nvarchar](50) NULL,[CDES2] [nvarchar](50) NULL,"
        Str01 = Str01 & "[CDES3] [nvarchar](50) NULL,[CDES4] [nvarchar](50) NULL,[CChequeNo] [nvarchar](15) NULL,"
        Str01 = Str01 & "[DBILLDATE] [datetime] NULL ,[DVNO] [numeric](10)  NOT NULL,[DACCODE] [int] NULL,"
        Str01 = Str01 & "[DName] [nvarchar](40) NOT NULL,[Debit] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[DDESCRIPTION] [nvarchar](50) NULL,[DDES1] [nvarchar](50) NULL,[DDES2] [nvarchar](50) NULL,"
        Str01 = Str01 & "[DDES3] [nvarchar](50) NULL,[DDES4] [nvarchar](50) NULL,[DChequeNo] [nvarchar](15) NULL)"
        CommandExe(Str01)


        CHECKTABEL("DateBankRpt")
        Str01 = "create table DateBankRpt ([CBILLDATE] [datetime] NULL ,[CVNO] [numeric](10)  NOT NULL,[CACCODE] [int] NULL,"
        Str01 = Str01 & "[CName] [nvarchar](40) NOT NULL,[CREDIT] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[CDESCRIPTION] [nvarchar](50) NULL,[CDES1] [nvarchar](50) NULL,[CDES2] [nvarchar](50) NULL,"
        Str01 = Str01 & "[CDES3] [nvarchar](50) NULL,[CDES4] [nvarchar](50) NULL,[CChequeNo] [nvarchar](15) NULL,"
        Str01 = Str01 & "[DBILLDATE] [datetime] NULL,[DVNO] [numeric](10)  NOT NULL,[DACCODE] [int] NULL,"
        Str01 = Str01 & "[DName] [nvarchar](40) NOT NULL,[Debit] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[DDESCRIPTION] [nvarchar](50) NULL,[DDES1] [nvarchar](50) NULL,[DDES2] [nvarchar](50) NULL,"
        Str01 = Str01 & "[DDES3] [nvarchar](50) NULL,[DDES4] [nvarchar](50) NULL,[BillDate] DateTime Null,"
        Str01 = Str01 & "[DChequeNo] [nvarchar](15) NULL)"
        CommandExe(Str01)

        CHECKTABEL("itStockday")
        Str01 = "create table itStockday (IC [INT],IName [NVARCHAR](60),HSN [NVARCHAR](30),"
        Str01 = Str01 & "[OPQTY] [numeric](18,3), [OPPACK] [numeric](18,2), [CrQty] [numeric](18,3),[DrQty] [numeric](18,3),"
        Str01 = Str01 & "[CrPack] [numeric](18,2),[DrPack] [numeric](18,2),[clPack] [numeric](18,2), [clQty] [numeric](18,3),"
        Str01 = Str01 & "[Values] [numeric](18,2), ItgCode [INT],ItgName [NVARCHAR](60),[BILLDATE] [datetime] NULL,"
        Str01 = Str01 & "[Weight] [Numeric](18,2))"
        CommandExe(Str01)

        CHECKTABEL("itStockAll")
        Str01 = "create table itStockAll (IC [INT],IName [NVARCHAR](60),HSN [NVARCHAR](30),"
        Str01 = Str01 & "[OPQTY] [numeric](18,3), [OPPACK] [numeric](18,2), "
        Str01 = Str01 & "[pCrQty] [numeric](18,3),[sDrQty] [numeric](18,3), "
        Str01 = Str01 & "[rCrQty] [numeric](18,3),[iDrQty] [numeric](18,3), "
        Str01 = Str01 & "[pCrPack] [numeric](18,2),[sDrPack] [numeric](18,2), "
        Str01 = Str01 & "[rCrPack] [numeric](18,2),[iDrPack] [numeric](18,2), "
        Str01 = Str01 & "[clPack] [numeric](18,2), [clQty] [numeric](18,3), "
        Str01 = Str01 & "[Values] [numeric](18,2), ItgCode [INT],ItgName [NVARCHAR](60),"
        Str01 = Str01 & "[BILLDATE] [datetime] NULL,[Weight] [Numeric](18,2))"
        CommandExe(Str01)

        CHECKTABEL("itStockLed")
        Str01 = "CREATE TABLE itStockLed"
        Str01 = Str01 & "([IC] [int] NULL, [IName] [nvarchar](60), [HSN] [nvarchar](30),"
        Str01 = Str01 & " [OPQTY] [numeric](18, 3) null, [OPPACK] [numeric](18, 2) NULL,"
        Str01 = Str01 & "[CrQty] [numeric](18, 3) NULL,[DrQty] [numeric](18, 3) NULL,"
        Str01 = Str01 & "[CrPack] [numeric](18, 2) NULL, [DrPack] [numeric](18, 2) NULL,"
        Str01 = Str01 & "[clPack] [numeric](18, 2) NULL, [clQty] [numeric](18, 3) NULL,"
        Str01 = Str01 & "[Values] [numeric](18, 2) NULL, [ItgCode] [int] NULL,"
        Str01 = Str01 & "[ItgName] [nvarchar](60), [BILLDATE] [datetime] NULL,"
        Str01 = Str01 & "[ACCODE] [int] NULL, [AcName] [nvarchar](60),"
        Str01 = Str01 & "[billno] [numeric](10,0),[Weight] [Numeric](18,2))"
        CommandExe(Str01)


        CHECKTABEL("itStock")
        Str01 = "create table itStock (IC [INT],IName [NVARCHAR](60),HSN [NVARCHAR](30),"
        Str01 = Str01 & "[OPQTY] [numeric](18,3), [OPPACK] [numeric](18,2), [CrQty] [numeric](18,3), [DrQty] [numeric](18,3),"
        Str01 = Str01 & "[CrPack] [numeric](18,2),[DrPack] [numeric](18,2), [clPack] [numeric](18,2), [clQty] [numeric](18,3),"
        Str01 = Str01 & " [Values] [numeric](18,2), ItgCode [NVARCHAR](3),ItgName [NVARCHAR](60), Weight [numeric](18,2),"
        Str01 = Str01 & " [Rate] [numeric](18,2), [Amount] [numeric](18,2))"
        CommandExe(Str01)

        CHECKTABEL("LoanInterestReg")
        Str01 = "Create Table LoanInterestReg ( " & _
                " LoanNo int ," & _
                " Name nvarchar(100) ," & _
                " Balance numeric(10,2) ," & _
                " Interest numeric(10,2)  ) "
        CommandExe(Str01)


        CHECKTABEL("selegroup") ' account group
        Str01 = "create table selegroup (code [nvarchar](3),name [nvarchar](60))"
        CommandExe(Str01)

        CHECKTABEL("selegroup1") ' account group for report
        Str01 = "create table selegroup1 (code [nvarchar](3),name [nvarchar](60))"
        CommandExe(Str01)

        CHECKTABEL("seleacmst")  ' account
        Str01 = "create table seleacmst (code [INT] ,name [nvarchar](60) ,place [nvarchar](50))"
        CommandExe(Str01)

        CHECKTABEL("seleacmst1") 'account for report
        Str01 = "create table seleacmst1 (code [INT] ,name [nvarchar](60) ,place [nvarchar](50))"
        CommandExe(Str01)


        CHECKTABEL("seleitmst")    ' item master
        Str01 = "create table seleitmst (code [INT] ,name [nvarchar](60))"
        CommandExe(Str01)

        CHECKTABEL("seleitmst1")  ' item master for report
        Str01 = "create table seleitmst1 (code [INT] ,name [nvarchar](60))"
        CommandExe(Str01)

        CHECKTABEL("seleitgmst")   ' item group
        Str01 = "create table seleitgmst (code [INT] ,name [nvarchar](60))"
        CommandExe(Str01)

        CHECKTABEL("seleitgmst1")  ' item group for report
        Str01 = "create table seleitgmst1 (code [INT] ,name [nvarchar](60))"
        CommandExe(Str01)

        CHECKTABEL("broker") ' Broker
        Str01 = "create table broker (code [nvarchar](6),name [nvarchar](60))"
        CommandExe(Str01)

        CHECKTABEL("broker1") ' Broker  for report
        Str01 = "create table broker1 (code [nvarchar](6),name [nvarchar](60))"
        CommandExe(Str01)

        CHECKTABEL("selepeta")    ' peta master
        Str01 = "create table selepeta (code [INT] ,name [nvarchar](60))"
        CommandExe(Str01)

        CHECKTABEL("selepeta1")  ' peta master for report
        Str01 = "create table selepeta1 (code [INT] ,name [nvarchar](60))"
        CommandExe(Str01)

        CHECKTABEL("PetaLedger")
        Str01 = "create table PetaLedger ([BILLDATE] [datetime] NULL ,[VNO] [numeric](10,2) NOT NULL ,[ACCODE] [int] NULL,"
        Str01 = Str01 & "[name] [nvarchar](40) NOT NULL, [CREDIT] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[DEBIT] [numeric](18,2) NOT NULL DEFAULT ((0)), [DESCRIPTION] [nvarchar](50) NULL,"
        Str01 = Str01 & "[DES1] [nvarchar](50) NULL,[DES2] [nvarchar](50) NULL,[DES3] [nvarchar](50) NULL,"
        Str01 = Str01 & "[DES4] [nvarchar](50) NULL, [balance] [numeric](18,2) NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[ACCODE1] [int] NULL,[name1] [nvarchar](40) NOT NULL, "
        Str01 = Str01 & "[add1] [nvarchar](50) NULL,[add2] [nvarchar](50) NULL,[add3] [nvarchar](50) NULL,"
        Str01 = Str01 & "[add4] [nvarchar](50) NULL,[panno] [nvarchar](40) NULL, [shortname] [nvarchar](10),"
        Str01 = Str01 & "[PETACODE] [int] NULL,[Petaname] [nvarchar](40) NULL) "
        CommandExe(Str01)

        CHECKTABEL("purcrpt")
        Str01 = "create table PurcRpt ([BILLDATE] [datetime] NULL ,[VNO] [nvarchar](10) NULL ,"
        Str01 = Str01 & "[ACCODE] [int] NULL,[name] [nvarchar](100) NOT NULL, [Amount] [numeric](18,2) "
        Str01 = Str01 & " NOT NULL DEFAULT ((0)), [ITEMCODE] [int] NULL, [ItemName] [nvarchar](100) NOT NULL,"
        Str01 = Str01 & "[PACK] [int] NOT NULL DEFAULT ((0)), [WEIGHT] [float] NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[GAmount] [float] NOT NULL DEFAULT ((0)), [vatrate] [float] NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[vatamount] [float] NOT NULL DEFAULT ((0)),[TAmount] [float] NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[Seq] [int] NOT NULL DEFAULT ((0)),[st_no] [nvarchar](50) NOT NULL,[AdvVat] [float] "
        Str01 = Str01 & "NOT NULL DEFAULT ((0)),[AdvAmt] [float] NOT NULL DEFAULT ((0)),[Gname] [nvarchar](40),"
        Str01 = Str01 & "[Weight1] [float] NOT NULL DEFAULT ((0)))"
        CommandExe(Str01)
        cn.Close()

        CHECKTABEL("SBILLRPT")
        Str01 = "create table SbillRpt(" & _
                    "[BDATE] [datetime] NULL," & _
                    "[billnoa] [nvarchar](2) NULL," & _
                    "[billno] [nvarchar](10) null," & _
                    "[vno] [nvarchar](10) null," & _
                    "[ACCODE] [int] NULL," & _
                    "[name] [nvarchar](125) null," & _
                    "[Amount] [numeric](18, 2) null DEFAULT ((0))," & _
                    "[ITEMCODE] [int] NULL," & _
                    "[ItemName] [nvarchar](60) null," & _
                    "[PACK] [int] null DEFAULT ((0))," & _
                    "[WEIGHT] [float] null DEFAULT ((0))," & _
                    "[rate] [float] NULL," & _
                    "[GAmount] [float] null DEFAULT ((0))," & _
                    "[vatrate] [float] null DEFAULT ((0))," & _
                    "[vatamount] [float] null DEFAULT ((0))," & _
                    "[TAmount] [float] null DEFAULT ((0))," & _
                    "[Seq] [int] null DEFAULT ((0))," & _
                    "[ides] [nvarchar](50) NULL," & _
                    "[stno] [nvarchar](30) NULL," & _
                    "[cstno] [nvarchar](30) NULL," & _
                    "[advvat] [float] null DEFAULT ((0))," & _
                    "[advamt] [float] null DEFAULT ((0))," & _
                    "[vehical] [nvarchar](30) NULL," & _
                    "[bname] [nvarchar](40) NULL," & _
                    "[add1] [nvarchar](50) NULL," & _
                    "[add2] [nvarchar](50) NULL," & _
                    "[add3] [nvarchar](50) NULL," & _
                    "[add4] [nvarchar](50) NULL," & _
                    "[wamt] [nvarchar](250) NULL," & _
                    "[Amt] [numeric](18, 2) null DEFAULT ((0))," & _
                    "[DISRATE] [float] null DEFAULT ((0))," & _
                    "[DISCOUNT] [float] null DEFAULT ((0))," & _
                    "[LRNO] [nvarchar](20) NULL," & _
                    "[LR_DATE] [datetime] NULL," & _
                    "[MODEOFTRAN] [nvarchar](50) NULL," & _
                    "[LrFrom] [nvarchar](20) NULL," & _
                    "[LrTo] [nvarchar](20) NULL," & _
                    "[CFORM] [nvarchar](1) NULL," & _
                    "[cahllanno] [nvarchar](15) NULL," & _
                    "[chldate] [datetime] NULL," & _
                    "[Term1] [nvarchar](100) NULL," & _
                    "[Term2] [nvarchar](100) NULL," & _
                    "[Term3] [nvarchar](100) NULL," & _
                    "[Term4] [nvarchar](100) NULL," & _
                    "[Term5] [nvarchar](100) NULL," & _
                    "[BankAcNo] [nvarchar](20) NULL," & _
                    "[BankName] [nvarchar](50) NULL," & _
                    "[BankBranch] [nvarchar](50) NULL," & _
                    "[BankAddress] [nvarchar](50) NULL," & _
                    "[chldate1] [datetime] NULL," & _
                    "[chldate2] [datetime] NULL," & _
                    "[chldate3] [datetime] NULL," & _
                    "[chldate4] [datetime] NULL," & _
                    "[chldate5] [datetime] NULL," & _
                    "[itemname1] [nvarchar](30) NULL," & _
                    "[itemname2] [nvarchar](30) NULL," & _
                    "[itemname3] [nvarchar](30) NULL," & _
                    "[itemname4] [nvarchar](30) NULL," & _
                    "[itemname5] [nvarchar](30) NULL," & _
                    "[itemname6] [nvarchar](30) NULL," & _
                    "[itemname7] [nvarchar](30) NULL," & _
                    "[OGSYN] [nvarchar](30) NULL," & _
                    "[Rateper] [float] NULL," & _
                    "[Tag] [int] NULL," & _
                    "[VechType] [nvarchar](15) NULL," & _
                    "[Km] [numeric](18, 2) NULL DEFAULT ((0))," & _
                    "[Ides1] [nvarchar](50) NULL," & _
                    "[Ides2] [nvarchar](50) NULL," & _
                    "[SaleWidth] [numeric](18, 4) NULL," & _
                    "[SalesLength] [numeric](18, 4) NULL," & _
                    "[SalesQty] [numeric](18, 4) NULL," & _
                    "[Delivery] [nvarchar](40) null," & _
                    "[Flag] [nvarchar](1) null , " & _
                    " [Remark] [nvarchar](100), " & _
                    " 	[SeqNo] [int] NULL," & _
                    " 	[Qty] [numeric](15, 3) NULL," & _
                    " 	[tRate] [numeric](15, 2) NULL," & _
                    " 	[mrp] [numeric](15, 2) NULL," & _
                    " 	[BatchNo] [varchar](50) ," & _
                    " 	[Des] [varchar](100) ," & _
                    " 	[BookCode] [int] NULL," & _
                    " 	[BookName] [varchar](100) ," & _
                    " 	[Yearno] [int] NULL," & _
                    " 	[Point] [int] NULL," & _
                    " 	[Scypo_Type] [varchar](10) ," & _
                    " 	[Balance] [numeric](15, 3) NULL ) "
        CommandExe(Str01)
    End Function

    Public Function CreateAccessDatabase(ByVal DatabaseFullPath As String) As Boolean
        Dim bAns As Boolean
        Dim cat As New ADOX.Catalog()
        Dim tr As String
        Try
            'Make sure the folders
            'provided in the path exists. If file name w/o path 
            'is  specified,  the database will be created in your
            'application folder.

            Dim sCreateString As String
            sCreateString = _
              "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DatabaseFullPath
            cat.Create(sCreateString)

            bAns = True

            cna = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & REP00)
            'provider to be used when working with access database
            cna.Open()
            tr = "create table cashrpt (billdate datetime ,vno text(12) ,accode text(6) ,name text(40) ,credit double ,debit double ,des1 text(50) ,des2 text(50) ,des3 text(50) ,des4 text(50), balance double ,cbal text(2))"
            cmda = New OleDb.OleDbCommand(tr, cna)
            cmda.ExecuteNonQuery()
            cna.Close()
        Catch Excep As System.Runtime.InteropServices.COMException
            bAns = False
            'do whatever else you need to do here, log, 
            'msgbox etc.
        Finally
            cat = Nothing
        End Try


        Return bAns
    End Function

    Public Function filestart(ByVal noxx As Integer, ByVal titlxx As String) As Boolean
        ' 1 dosbase
        ' 2 window base
        PrintLine(noxx, "<html>")
        PrintLine(noxx, "<head>")
        PrintLine(noxx, "<meta http-equiv='Content-Language' content='en-us'>")
        PrintLine(noxx, "<meta name='GENERATOR' content='Microsoft FrontPage 5.0'>")
        PrintLine(noxx, "<meta name='ProgId' content='FrontPage.Editor.Document'>")
        PrintLine(noxx, "<meta http-equiv='Content-Type' content='text/html; charset=windows-1252'>")
        PrintLine(noxx, "<title>" & titlxx & "</title>")
        PrintLine(noxx, "</head>")
        PrintLine(noxx, "<body>")
    End Function

    Public Function fileend(ByVal noxx As Integer) As Boolean
        PrintLine(noxx, "</body>")
        PrintLine(noxx, "</html>")
    End Function

    Public Function printhead(ByVal noxx As Integer, ByVal strxx As String) As Boolean
        PrintLine(noxx, "<p align='center'><b><font size='7'>" & strxx & "</font></b></p>")
    End Function

    Public Function print_rphead(ByVal noxx As Integer, ByVal strxx As String) As Boolean
        PrintLine(noxx, "<p align='center'><b><font size='5'>" & strxx & "</font></b></p>")
    End Function

    Public Function println(ByVal noxx As Integer, ByVal sizxx As Integer) As Boolean
        PrintLine(noxx, "<hr color='#000000' size=" & sizxx & ">")
    End Function

    Public Function Firstrun() As Boolean
        stringtype = "SQL"
        Dim DS As DataSet = New DataSet()
        DS.Tables.Add("DATAWORLD")
        DS.Tables(0).Columns.Add("SNAME")
        DS.Tables(0).Columns.Add("USESTRING")
        DS.Tables(0).Columns.Add("DATABASE")
        DS.Tables(0).Columns.Add("reportpath")
        DS.Tables(0).Columns.Add("mode")
        DS.Tables(0).Rows.Add(New Object() {"SERVER", "SQL", "ACCOUNT", "D:\D.NET\ACCOUNT\ACCOUNT\REPORT\", "WIN"})
        DS.WriteXml(XMLNAME)
    End Function

    Public Function CHEKDATABASE(ByVal STRXX As String) As Boolean
        Dim str01 As String = ""

        If stringtype = "SQL" Then
            If Modetype = "WIN" Then
                str01 = "Data Source=" & server01 & ";Initial Catalog=master;Integrated Security=True"
            Else
                str01 = "Data Source=" & server01 & ";Initial Catalog=master;User ID=" & USERXX & "; pwd=" & passxx
            End If
        ElseIf stringtype = "EXP" Then
            If Modetype = "WIN" Then
                str01 = "Data Source=" & server01 & ";AttachDbFilename='master';Integrated Security=True"
            Else
                str01 = "Data Source=" & server01 & ";AttachDbFilename='master';User ID=" & USERXX & "; pwd=" & passxx
            End If
        End If


        cn = New SqlClient.SqlConnection(str01)
        Dim cmd As New SqlClient.SqlCommand("SELECT dbid FROM sysdatabases WHERE [name]='" & STRXX & "'", cn)

        Dim databaseID As Int32 = -1
        cn.Open()
        databaseID = CType(cmd.ExecuteScalar, Int32)
        cn.Dispose()

        cmd.Dispose()
        If databaseID > 0 Then
            CHEKDATABASE = True
            'MessageBox.Show("Database exists")
        Else
            CHEKDATABASE = False
            'MessageBox.Show("Database does not exist")
        End If
    End Function

    Public Function CHECKTABEL(ByVal STRXX As String) As Boolean
        Dim STR01 As String
        STR01 = "select table_name FROM information_schema.tables WHERE TABLE_NAME='" & STRXX & "'"
        fillReader(STR01)
        If dr.HasRows Then
            dr.Close()
            CommandExe("DROP TABLE " & STRXX)
        End If
        cn.Close()
    End Function

    Public Function conpass(ByVal X As String)
        Dim x01 As String, x02 As String
        Dim l01 As Integer, i As Integer
        x01 = X
        x02 = ""
        l01 = Len(x01)
        For i = 1 To l01
            x02 = x02 + Chr((Asc(Mid(x01, i, 1)) + 130))
        Next
        conpass = x02
    End Function

    Public Function GETpass(ByVal X As String)
        Dim x01 As String, x02 As String
        Dim l01 As Integer, i As Integer
        x01 = X
        x02 = ""
        l01 = Len(x01)
        For i = 1 To l01
            '   A01 = Asc(Mid(x01, I, 1))
            x02 = x02 + Chr((Asc(Mid(x01, i, 1)) - 130))
        Next
        GETpass = x02
    End Function

    Public Function createaccount() As Boolean
        Dim str01 As String = ""
        opencn("MASTER")
        CommandExe("create database [" & dbname & "]")
        cn.Close()
        opencn(dbname)
        str01 = "CREATE TABLE [SoftwareConfig]([Rajusukla] [nvarchar](1) NOT NULL DEFAULT (N'N')) ON [PRIMARY]"
        CHECKTABEL("SoftwareConfig")
        CommandExe(str01)
        str01 = "insert into SoftwareConfig values('N')"
        CommandExe(str01)


        str01 = "CREATE TABLE [YEARMST]([YEARNO] [smallint] NULL, "
        str01 = str01 & "[NAME] [nvarchar](40) NULL,[DATABASE] [nvarchar](10),[DATABASEE] [nvarchar](10),"
        str01 = str01 & "[STARTDATE] [datetime] NULL,[ENDDATE] [datetime] NULL,"
        str01 = str01 & "[ACTYEAR] [nvarchar](9)NULL,[OPTION] [smallint] NULL,"
        str01 = str01 & "[DEL] [nvarchar](1) NULL) ON [PRIMARY]"
        CHECKTABEL("yearmst")
        CommandExe(str01)

        str01 = "CREATE TABLE [login]([CODE] [nvarchar](25) NULL,[name] [nvarchar](40) NULL,"
        str01 = str01 & "[short_name] [nvarchar](8) NULL,[pwd] [nvarchar](25) NULL,"
        str01 = str01 & "[for_color] [nvarchar](12) NULL,"
        str01 = str01 & "[back_color] [nvarchar](12) NULL,[text_color] [nvarchar](12) NULL,"
        str01 = str01 & "[rights] [nvarchar](160) NULL,[rights_1] [nvarchar](160) NULL,"
        str01 = str01 & "[rights_2] [nvarchar](160) NULL,[text_colorb] [nvarchar](12) NULL,"
        str01 = str01 & "[Counter] [nvarchar](2) NULL,[serveruser] [nchar](20) NULL,"
        str01 = str01 & "[serverpass] [nchar](20) NULL,urtype [nchar](25)) ON [PRIMARY]"
        CHECKTABEL("login")
        CommandExe(str01)

        str01 = "insert into login values('" & conpass("Admin") & "','Administrator','Admin',"
        str01 = str01 & "'" & conpass("jignesh") & "','','','','','','','','',"
        str01 = str01 & "'" & conpass("sa") & "','" & conpass("123456") & "','Administrator')"
        opencn(dbname)
        CommandExe(str01)
        str01 = "insert into login values('" & conpass("1") & "','Administrator','VK',"
        str01 = str01 & "'" & conpass("1") & "','','','','','','','','',"
        str01 = str01 & "'" & conpass("sa") & "','" & conpass("123456") & "','Administrator')"
        CommandExe(str01)

    End Function

    Public Function createcomst(ByVal frm As String) As Boolean
        Dim str01 As String
        If UCase(frm) = "YEAR" Then
            str01 = "CREATE TABLE [comst]([CCODE] [real] NULL, [CNAME] [nvarchar](100) NULL, [NAME] [nvarchar](100) NULL,"
            str01 = str01 + "[SORTNAME] [nvarchar](10) NULL, [COADD1F] [nvarchar](50) NULL, [COADD2F] [nvarchar](50) NULL,"
            str01 = str01 + "[COADD3F] [nvarchar](50) NULL, [TELF1] [nvarchar](15) NULL, [TELF2] [nvarchar](15) NULL,"
            str01 = str01 + "[TELF3] [nvarchar](15) NULL, [COADD1O] [nvarchar](50) NULL, [COADD2O] [nvarchar](50) NULL,"
            str01 = str01 + "[COADD3O] [nvarchar](50) NULL, [TEL01] [nvarchar](15) NULL, [TEL02] [nvarchar](15) NULL,"
            str01 = str01 + "[TEL03] [nvarchar](15) NULL, [COABRV] [nvarchar](3) NULL, [COABRVP] [nvarchar](3) NULL,"
            str01 = str01 + "[QTAC] [nvarchar](1) NULL, [ONLINE] [nvarchar](1) NULL, [STARTDATE] [datetime] NULL,"
            str01 = str01 + "[ENDDATE] [datetime] NULL, [ACTYEAR] [nvarchar](10) NULL, [STNO] [nvarchar](50) NULL, "
            str01 = str01 + "[STNO1] [nvarchar](50) NULL, [CSTNO] [nvarchar](50) NULL, [INVNO] [int] NULL,"
            str01 = str01 + "[SDATE1] [datetime] NULL, [SDATE2] [datetime] NULL, [MASTERCOM] [nvarchar](1) NULL,"
            str01 = str01 + "[JURDI] [nvarchar](50) NULL, [TERM1] [nvarchar](100) NULL, [TERM2] [nvarchar](100) NULL,"
            str01 = str01 + "[TERM3] [nvarchar](100) NULL, [TERM4] [nvarchar](100) NULL, [TERM5] [nvarchar](100) NULL,"
            str01 = str01 + "[TERM6] [nvarchar](100) NULL, [TERM7] [nvarchar](100) NULL, [TERM8] [nvarchar](100) NULL,"
            str01 = str01 + "[TERM9] [nvarchar](100) NULL, [DISPABLE] [nvarchar](1) NULL, [STATUS] [nvarchar](5) NULL,"
            str01 = str01 + "[PASSWARD] [nvarchar](6) NULL, [BOOKCLOSE] [nvarchar](1) NULL, [DAYS] [real] NULL,"
            str01 = str01 + "[CEXNO] [nvarchar](40) NULL, [RANGE] [nvarchar](40) NULL, [DIVISION] [nvarchar](40) NULL,"
            str01 = str01 + "[COMM_RATE] [nvarchar](40) NULL, [ECCNO] [nvarchar](40) NULL, [PANNO] [nvarchar](40) NULL,"
            str01 = str01 + "[LOCATION] [nvarchar](15) NULL,[licno] [nvarchar](30) NULL,[BankAcNo] [nvarchar](20) NULL,"
            str01 = str01 + "[BankName] [nvarchar](50) NULL,[BankBranch] [nvarchar](50) NULL,[BankAddress] [nvarchar](50))"
            str01 = str01 + " ON [PRIMARY]"
            CommExe(str01)

            '            str01 = "CREATE TABLE [TRNTYPE]([TYPE] [smallint] NOT NULL,[NAME] [nchar](10) NOT NULL"
            '            str01 = str01 & ") ON [PRIMARY]"

            str01 = "CREATE TABLE [TRNTYPE]([TYPE] [smallint] NOT NULL,[NAME] [nchar](10) NOT NULL,"
            str01 = str01 & " CONSTRAINT [PK_TRNTYPE] PRIMARY KEY CLUSTERED ([Type]Asc )WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]"
            str01 = str01 & ")"
            CommExe(str01)

            ' trntype records
            str01 = "INSERT INTO TRNTYPE VALUES(1,'Cash')"
            CommExe(str01)
            cn.Close()
            str01 = "INSERT INTO TRNTYPE VALUES(2,'Bank')"
            CommExe(str01)
            cn.Close()
            str01 = "INSERT INTO TRNTYPE VALUES(3,'Sale')"
            CommExe(str01)
            cn.Close()
            str01 = "INSERT INTO TRNTYPE VALUES(4,'Purc')"
            CommExe(str01)
            cn.Close()
            str01 = "INSERT INTO TRNTYPE VALUES(5,'JV  ')"
            CommExe(str01)
            cn.Close()
            str01 = "INSERT INTO TRNTYPE VALUES(6,'SRtn')"
            CommExe(str01)
            cn.Close()
            str01 = "INSERT INTO TRNTYPE VALUES(7,'PRtn')"
            CommExe(str01)

            cn.Close()
            str01 = "INSERT INTO TRNTYPE VALUES(8,'Issue')"
            CommExe(str01)

            cn.Close()
            str01 = "INSERT INTO TRNTYPE VALUES(9,'Recived')"
            CommExe(str01)

            cn.Close()
            str01 = "INSERT INTO TRNTYPE VALUES(10,'Del Chall')"
            CommExe(str01)
            cn.Close()

        End If
        cn.Close()

        str01 = "CREATE TABLE [" & ITGMST & "](" & _
             "[name] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[nameG] [nvarchar] (100) null," & _
             "[AcCode] [int]   NULL," & _
             "[SubCode] [int] NULL," & _
             "[entryby] [nvarchar](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[startit] [int] NULL," & _
             "[endit] [int] NULL," & _
             "[refno] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[uniqno] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL," & _
             "[CODE] [nvarchar](6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,"
        str01 = str01 & "CONSTRAINT [PK_" & ITGMST & "] PRIMARY KEY CLUSTERED([CODE] Asc) WITH "
        str01 = str01 & "(IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]"
        CommExe(str01)
        cn.Close()


        str01 = "CREATE TABLE [" & GRMST & "]([CODE] [nvarchar](3) NOT NULL, [NAME] [nvarchar](100) NULL,[nameG] [nvarchar](100) NULL,"
        str01 = str01 + "[CRSEQ] [float] NULL, [DRSEQ] [float] NULL, [INCOME] [nvarchar](1) NULL,"
        str01 = str01 + "[CRSEQP] [float] NULL, [DRSEQP] [float] NULL, [CRSEQT] [float] NULL, "
        str01 = str01 + "[DRSEQT] [float] NULL, [ANNEX] [nvarchar](1) NULL, [uniqno] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL, "
        str01 = str01 + "startac [int] NULL,endac [int] NULL,"
        str01 = str01 + "CONSTRAINT [PK_" & GRMST & "] PRIMARY KEY CLUSTERED ([CODE] Asc) "
        str01 = str01 + "WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]"
        CommExe(str01)
        cn.Close()


        str01 = "CREATE TABLE [" & MSMST & "]([ACCODE] [int] NOT NULL,[name] [nvarchar](100) NULL,[nameG] [nvarchar](100) NULL ,"
        str01 = str01 + "[subcode] [int] null,[SubCodeYn] [nvarchar] (1) NULL , "
        str01 = str01 + "[add1] [nvarchar](40) NULL,[add2] [nvarchar](40) NULL,[add3] [nvarchar](40) NULL,"
        str01 = str01 + "[add4] [nvarchar](40) NULL,[region] [nvarchar](20) NULL,[areacode] [nvarchar](2) NULL,"
        str01 = str01 + "[telephone] [nvarchar](20) NULL,[mobile] [nvarchar](20) NULL,[fax] [nvarchar](20) NULL,"
        str01 = str01 + "[email] [nvarchar](40) NULL,[gcode] [nvarchar](3) NULL,[trntype] [int] NULL,"
        str01 = str01 + "[bookyn] [nvarchar](1) NULL,[entryby] [nvarchar](6) NULL,[entrydate] [datetime] NULL,"
        str01 = str01 + "[entrytime] [datetime] NULL,[editby] [nvarchar](6) NULL,[shortname] [nvarchar](10) NULL,"
        str01 = str01 + "[eccno] [nvarchar](50) NULL,[cexno] [nvarchar](50) NULL,[range] [nvarchar](50) NULL,"
        str01 = str01 + "[division] [nvarchar](50) NULL,[comm_rate] [nvarchar](50) NULL,[placyn] [nvarchar](1) NULL,"
        str01 = str01 + "[ptg] [nvarchar](1) NULL,[ogs] [nvarchar](1) NULL,[phone2] [nvarchar](20) NULL,"
        str01 = str01 + "[phone3] [nvarchar](20) NULL,[rg23yn] [nvarchar](1) NULL,[st_no] [nvarchar](50) NULL,"
        str01 = str01 + "[cst_no] [nvarchar](50) NULL,[BrkCode] [nvarchar](6) NULL,"
        str01 = str01 + "[panno] [nvarchar](50) NULL,[uniqno] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,"
        str01 = str01 + "[RootNo] [nvarchar](10) NULL,[BarCode] [nvarchar](20) NULL,[StopTrn] [nvarchar](1) NULL,"
        str01 = str01 + " cday [int],refno nvarchar(10),Bankname [nvarchar](30),Bankno [nvarchar](30),Audit [nchar](1) null,"
        str01 = str01 + " SHEDULE nchar(5),ROJMALESEQ  [Int] NULL,[MemNo] [int] NULL,"
        str01 = str01 + "[Jamin1] [int] NULL,"
        str01 = str01 + "[Jamin2] [int] NULL,"
        str01 = str01 + "[Jamin3] [int] NULL,"
        str01 = str01 + "[Jamin4] [int] NULL,"
        str01 = str01 + "[LoanDate] [datetime] NULL,"
        str01 = str01 + "[LoanAmt] [numeric](18, 2) NULL,"
        str01 = str01 + "[HaptaAmt] [numeric](18, 2) NULL,"
        str01 = str01 + "[Hapta] [int] NULL,"
        str01 = str01 + "[DueDate] [datetime] NULL,"
        str01 = str01 + "[IntRate] [numeric](18, 2) NULL,"
        str01 = str01 + "[MDY] [Char](1) NULL,"
        str01 = str01 + " PrintSeq int," & _
                        " SubLedgerType char(1))" & _
                        " ON [PRIMARY]"
        CommExe(str01)
        cn.Close()


        str01 = "CREATE TABLE [" & BOMST & "](" & _
                     "[Bookcode] [int] NOT NULL," & _
                     "[Booksubcode] [int] NOT NULL," & _
                     "[Accode] [int] NOT NULL," & _
                     "[subcode] [int] null," & _
                     "[CONTRASUBCODE] [int] null," & _
                     "[Heading] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," & _
                     "[Rate] [numeric](6, 2) NOT NULL," & _
                     "[AL] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," & _
                     "[Post] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," & _
                     "[Calculation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," & _
                     "[Uniqno] [smallint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL," & _
                     "[SEQNO] [smallint] NOT NULL," & _
                     "[TaxYn] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," & _
                     "[VatIncl] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL) ON [PRIMARY]"
        CommExe(str01)
        cn.Close()

        str01 = "CREATE TABLE [" & REMMST & "]([PETACODE] [numeric](18, 0) IDENTITY(1,1) NOT NULL," & _
             "[PETANAME] [nvarchar](50) NOT NULL,[nameG] [nvarchar](50) NULL) ON [PRIMARY]"
        CommExe(str01)
        cn.Close()

        str01 = "CREATE TABLE [" & DSMST & "]([bookcode] [int] NOT NULL,[des1] [varchar](200) NOT NULL,"
        str01 = str01 & " [uniqno] [smallint] IDENTITY(1,1) NOT NULL) ON [PRIMARY]"
        CommExe(str01)
        cn.Close()

        str01 = "CREATE TABLE [" & SCHMST & "]([Uniqueno] [numeric](18, 0) IDENTITY(1,1) NOT NULL," & _
             "[SheduleName] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," & _
             "[Type] [char](1) NOT NULL) ON [PRIMARY]"
        CommExe(str01)
        cn.Close()

        str01 = "CREATE TABLE [" & AIMST & "]([Accode] [int] NOT NULL,[subcode] [int],[PETACode] [NUMERIC](18) NOT NULL," & _
                "[uniqno] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL) ON [PRIMARY]"
        CommExe(str01)
        cn.Close()



        str01 = "CREATE TABLE [" & MMMST & "](" & _
                "[MemNo] [int] NOT NULL," & _
                "[Memname] [nvarchar](100) ," & _
                "[MemnameG] [nvarchar](100) ," & _
                "[Add1] [nvarchar](100)," & _
                "[Add2] [nvarchar](100)," & _
                "[Add3] [nvarchar](100)," & _
                "[add4] [nvarchar](100)," & _
                "[PhNo] [nvarchar](25) ," & _
                "[MobNo] [nvarchar](12)," & _
                "[Email] [nvarchar](50)," & _
                "[Birthdate] [datetime] NULL, " & _
                "[Joindate] [datetime] NULL," & _
                "[gender] [nvarchar](1)," & _
                "[pAdd] [nvarchar](100) ," & _
                "[Padd1] [nvarchar](100)," & _
                "[Padd2] [nvarchar](100)," & _
                "[Padd3] [nvarchar](100)," & _
                "[Resign] [nvarchar](1)," & _
                "[ResignDate] [datetime] NULL," & _
                "[ResignResone] [nvarchar](50)," & _
                "[BloodGroup] [nvarchar](5)," & _
                "[uniqe] [int] IDENTITY(1,1) NOT NULL," & _
                "[Entryby] [nvarchar](6)," & _
                "[Entrydate] [datetime] NULL," & _
                "[Editby] [nvarchar](6)," & _
                "[Editdate] [datetime] NULL," & _
                "[audit] [nchar](1)"
        str01 = str01 + " CONSTRAINT [PK_" & MMMST & "] PRIMARY KEY CLUSTERED ([MemNo] ASC)"
        str01 = str01 + "WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]"
        CommExe(str01)
        cn.Close()


        str01 = "CREATE TABLE [" & ITMST & "](" & _
             "[itemcode] [int] NOT NULL," & _
             "[nameG] [nvarchar] (100) null," & _
             "[shortname] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[gcode1] [nvarchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[k_p] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[unit] [nvarchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[measurement] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[decimal] [tinyint] NULL," & _
             "[accode] [int] NULL," & _
             "[pur_rate] [float] NULL," & _
             "[sal_rate] [float] NULL," & _
             "[uniqno] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL," & _
             "[itemname] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[GCODE] [nvarchar](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[barcode] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[mrp] [float] NULL," & _
             "[POINT] [float] NULL," & _
             "[MAXLEVEL] [float] NULL," & _
             "[MINLEVEL] [float] NULL," & _
             "[VATRATE] [float] NOT NULL DEFAULT ((0))," & _
             "[ADVVAT] [float] NOT NULL DEFAULT ((0))," & _
             "[HSN] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[WEIGHT] [numeric](18, 3) NULL," & _
             "[RATEREQ] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[CALWEIGHT] [numeric](18, 3) NULL," & _
             "[claimyn] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[Category] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[refno] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[itemname1] [nvarchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[itemname2] [nvarchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[itemname3] [nvarchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[itemname4] [nvarchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[itemname5] [nvarchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[itemname6] [nvarchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[itemname7] [nvarchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
             "[CSTRATE] [float] NOT NULL DEFAULT ((0))," & _
             "[EmiReq] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,"
        str01 = str01 & "CONSTRAINT [PK_" & ITMST & "] PRIMARY KEY CLUSTERED ([itemcode] Asc) WITH (IGNORE_DUP_KEY = OFF) ON "
        str01 = str01 & "[PRIMARY]) ON [PRIMARY]"
        CommExe(str01)
        cn.Close()

        ''''''''''''''
        str01 = "CREATE TABLE [" & UNITMST & "](" & _
                    "[code] [nvarchar](3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
                    "[name] [nvarchar](40) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
                    "[uniqno] [int] IDENTITY(1,1) NOT NULL) ON [PRIMARY]"
        CommExe(str01)
        cn.Close()
        ''''''''''''



        '********** CREATE INDEX

        'str01 = "CREATE UNIQUE INDEX ACPRIMARY ON " & MSMST & " (ACCODE)"
        'CommExe(str01)
        'cn.Close()

        str01 = "CREATE UNIQUE INDEX GRPRIMARY ON " & GRMST & " (CODE)"
        CommExe(str01)
        cn.Close()

        str01 = "CREATE UNIQUE INDEX IGRPRIMARY ON " & ITGMST & "(CODE)"
        CommExe(str01)
        cn.Close()

        str01 = "CREATE UNIQUE INDEX ITPRIMARY ON " & ITMST & " (ITEMCODE)"
        CommExe(str01)
        cn.Close()

        '********* INDEX OVER
        'str01 = "ALTER TABLE [" & MSMST & "] WITH CHECK ADD CONSTRAINT [gr_" & MSMST & "] FOREIGN KEY([gcode]) REFERENCES [" & GRMST & "]([CODE])"
        'CommExe(str01)
        'cn.Close()


        'str01 = "ALTER TABLE [" & AIMST & "] WITH CHECK ADD CONSTRAINT [FK_" & ITMST & "_REL] FOREIGN KEY([ItemCode]) REFERENCES [" & ITMST & "]([itemcode])"
        'CommExe(str01)
        'cn.Close()




        '***************  unmst insert 



        str01 = "INSERT INTO " & UNITMST & "(Code,[Name]) VALUES('001',"
        str01 = str01 & "'NOS')"
        CommExe(str01)

        str01 = "INSERT INTO " & UNITMST & "(Code,[Name]) VALUES('002',"
        str01 = str01 & "'KGS')"
        CommExe(str01)

        str01 = "INSERT INTO " & UNITMST & "(Code,[Name]) VALUES('003',"
        str01 = str01 & "'LTRS')"
        CommExe(str01)

        str01 = "INSERT INTO " & UNITMST & "(Code,[Name]) VALUES('004',"
        str01 = str01 & "'MTRS')"
        CommExe(str01)

        str01 = "INSERT INTO " & UNITMST & "(Code,[Name]) VALUES('005',"
        str01 = str01 & "'NONE')"
        CommExe(str01)





        ' group master insert 

        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC)"
        str01 = str01 + " VALUES('999','OPEINGIN AND OTHERS',"
        str01 = str01 + "999991,999999)"
        CommExe(str01)

        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('001','Capital Account',10101,10200)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('002','Reserves & Surplus',10201,10300)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('003','Sequerd Loan',10301,10400)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('004','Unsequred Loan',10401,10500)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('005','Sundary Creditors',50001,60000)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('006','Advance Payments',60001,70000)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('007','Other Liablity',70001,80000)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('008','Provisions',10801,10900)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('009','Provisions for taxation',10901,11000)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('010','Other Provisions',11001,11100)"
        CommExe(str01)


        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('021','Fixed Assets',20101,20200)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('022','Investments',20201,20300)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('023','Deposits',20301,20400)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('024','Stock',20401,20500)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('025','Sundary Debtors',100001,110000)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('026','Cash Balance',20601,20700)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('027','Bank Balance',20701,20800)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('028','Loans and Advances',20801,20900)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('029','Profit and Loass',20901,21000)"
        CommExe(str01)


        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('041','Sales',1001,1100)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('042','Direct Income',1101,1200)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('043','Indirect Income',1201,1300)"
        CommExe(str01)

        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('051','Purchase',2001,2100)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('052','Direct Expenses',2101,2200)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('053','Indirect Expenses',2201,2300)"
        CommExe(str01)
        str01 = "INSERT INTO " & GRMST & " (CODE,[NAME],STARTAC,ENDAC) VALUES('054','Misc Expenses',2301,2400)"
        CommExe(str01)

        'group master insert over

        '      cn.Close()

        str01 = "INSERT INTO " & MSMST & "(GCode,AcCode,[Name],nameG,Add1,Add2,Add3,Add4,"
        str01 = str01 & "TelePhone,Mobile,Fax,Email,BrkCode,Ptg,Ogs,St_No,Cst_No,"
        str01 = str01 & "ECCNO,CexNo,Division,Range,Comm_Rate,SubCode,SubCodeYn"
        str01 = str01 & ",[MemNo],[Jamin1],[Jamin2],[Jamin3],[Jamin4],[LoanDate],[LoanAmt],[HaptaAmt],[Hapta],[DueDate],[IntRate],[MDY]) VALUES('999',"
        str01 = str01 & "999999,'OPENING BALANCE',' ',"
        str01 = str01 & "' ',' ',' ',' ',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ','G',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ','0','M',0,0,0,0,0,null,0,0,0,null,0,'')"
        CommExe(str01)

        '       cn.Close()


        str01 = "INSERT INTO " & MSMST & "(GCode,AcCode,[Name],nameG,Add1,Add2,Add3,Add4,"
        str01 = str01 & "TelePhone,Mobile,Fax,Email,BrkCode,Ptg,Ogs,St_No,Cst_No,"
        str01 = str01 & "ECCNO,CexNo,Division,Range,Comm_Rate,TRNTYPE,BOOKYN,SubCode,SubCodeYn"
        str01 = str01 & ",[MemNo],[Jamin1],[Jamin2],[Jamin3],[Jamin4],[LoanDate],[LoanAmt],[HaptaAmt],[Hapta],[DueDate],[IntRate],[MDY]) VALUES('999',"
        str01 = str01 & "999998,'HAWALA BOOK',' ',"
        str01 = str01 & "' ',' ',' ',' ',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ','G',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ',5,'Y','0','M',0,0,0,0,0,null,0,0,0,null,0,'')"
        CommExe(str01)


        ' ADD TO MARFATIYA
        str01 = "INSERT INTO " & MSMST & "(GCode,AcCode,[Name],nameG,Add1,Add2,Add3,Add4,"
        str01 = str01 & "TelePhone,Mobile,Fax,Email,BrkCode,Ptg,Ogs,St_No,Cst_No,"
        str01 = str01 & "ECCNO,CexNo,Division,Range,Comm_Rate,SubCode,SubCodeYn"
        str01 = str01 & ",[MemNo],[Jamin1],[Jamin2],[Jamin3],[Jamin4],[LoanDate],[LoanAmt],[HaptaAmt],[Hapta],[DueDate],[IntRate],[MDY]) VALUES('999',"
        str01 = str01 & "999993,'NET PROFIT & LOSS AC.',' ',"
        str01 = str01 & "' ',' ',' ',' ',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ','P',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ','0','M',0,0,0,0,0,null,0,0,0,null,0,'')"
        CommExe(str01)

        str01 = "INSERT INTO " & MSMST & "(GCode,AcCode,[Name],nameG,Add1,Add2,Add3,Add4,"
        str01 = str01 & "TelePhone,Mobile,Fax,Email,BrkCode,Ptg,Ogs,St_No,Cst_No,"
        str01 = str01 & "ECCNO,CexNo,Division,Range,Comm_Rate,SubCode,SubCodeYn"
        str01 = str01 & ",[MemNo],[Jamin1],[Jamin2],[Jamin3],[Jamin4],[LoanDate],[LoanAmt],[HaptaAmt],[Hapta],[DueDate],[IntRate],[MDY]) VALUES('999',"
        str01 = str01 & "999991,'TRADING ACCOUNT',' ',"
        str01 = str01 & "' ',' ',' ',' ',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ','P',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ','0','M',0,0,0,0,0,null,0,0,0,null,0,'')"
        CommExe(str01)

        str01 = "INSERT INTO " & MSMST & "(GCode,AcCode,[Name],nameG,Add1,Add2,Add3,Add4,"
        str01 = str01 & "TelePhone,Mobile,Fax,Email,BrkCode,Ptg,Ogs,St_No,Cst_No,"
        str01 = str01 & "ECCNO,CexNo,Division,Range,Comm_Rate,SubCode,SubCodeYn"
        str01 = str01 & ",[MemNo],[Jamin1],[Jamin2],[Jamin3],[Jamin4],[LoanDate],[LoanAmt],[HaptaAmt],[Hapta],[DueDate],[IntRate],[MDY]) VALUES('999',"
        str01 = str01 & "999990,'PROFIT & LOASS ACCOUNT',' ',"
        str01 = str01 & "' ',' ',' ',' ',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ','B',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ','0','M',0,0,0,0,0,null,0,0,0,null,0,'')"
        CommExe(str01)

        str01 = "INSERT INTO " & MSMST & "(GCode,AcCode,[Name],nameG,Add1,Add2,Add3,Add4,"
        str01 = str01 & "TelePhone,Mobile,Fax,Email,BrkCode,Ptg,Ogs,St_No,Cst_No,"
        str01 = str01 & "ECCNO,CexNo,Division,Range,Comm_Rate,TRNTYPE,BOOKYN,SubCode,SubCodeYn"
        str01 = str01 & ",[MemNo],[Jamin1],[Jamin2],[Jamin3],[Jamin4],[LoanDate],[LoanAmt],[HaptaAmt],[Hapta],[DueDate],[IntRate],[MDY]) VALUES('999',"
        str01 = str01 & "20601,'CASH BOOK',' ',"
        str01 = str01 & "' ',' ',' ',' ',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ','G',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ',1,'Y','0','M',0,0,0,0,0,null,0,0,0,null,0,'')"
        CommExe(str01)

        str01 = "INSERT INTO " & MSMST & "(GCode,AcCode,[Name],nameG,Add1,Add2,Add3,Add4,"
        str01 = str01 & "TelePhone,Mobile,Fax,Email,BrkCode,Ptg,Ogs,St_No,Cst_No,"
        str01 = str01 & "ECCNO,CexNo,Division,Range,Comm_Rate,TRNTYPE,BOOKYN,SubCode,SubCodeYn"
        str01 = str01 & ",[MemNo],[Jamin1],[Jamin2],[Jamin3],[Jamin4],[LoanDate],[LoanAmt],[HaptaAmt],[Hapta],[DueDate],[IntRate],[MDY]) VALUES('999',"
        str01 = str01 & "20701,'BANK BOOK',' ',"
        str01 = str01 & "' ',' ',' ',' ',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ','G',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ',' ',"
        str01 = str01 & "' ',' ',2,'Y','0','M',0,0,0,0,0,null,0,0,0,null,0,'')"
        CommExe(str01)
        cn.Close()

    End Function

    Public Function SETDATE(ByVal DTXX As MaskedTextBox, Optional ByVal tagxx As String = "L") As Boolean

        'DTXX.MinDate = Dt001
        'DTXX.MaxDate = Dt002
        If tagxx = "L" Then
            DTXX.Text = IIf(Date.Now > Dt002, Dt002, Date.Now)
        Else
            DTXX.Text = Dt001
        End If
        Return True
    End Function

    Public Function backupDb() As Boolean
        Dim mysqlcomm As SqlClient.SqlCommand
        Dim strsql As String
        Dim strbak As String
        Dim backupdir As String
        Dim R As MsgBoxResult
        backupdir = "d:\jignesh\"
        R = MsgBox("Do You Want to Take Backup This Database -> " & dbnam01, MsgBoxStyle.YesNo, DEVLOP01)
        If R = MsgBoxResult.No Then
            Exit Function
        End If

        backupdir = Application.StartupPath + "\backup"
        backupdir = (InputBox("Enter Backup Path  ", DEVLOP01, backupdir))

        Try
            If backupdir <> Nothing Then
                If Not System.IO.Directory.Exists(backupdir) Then
                    System.IO.Directory.CreateDirectory(backupdir)
                End If
            Else
                If Not System.IO.Directory.Exists(Application.StartupPath + "\backup") Then
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\backup")
                End If
                backupdir = Application.StartupPath + "\backup"
            End If
            strbak = backupdir
            '            strsql = "backup database myDataBase to disk='" + strbak + "\myDataBase.bak' with name='myDataBase backup all',description='Full Backup Of myDataBase'"    'SQL statement for backup
            strsql = "backup database " & dbnam01 & " to disk='"
            strsql = strsql & strbak + "\" & dbnam01 & ".bak' with name='"
            strsql = strsql & dbnam01 & " backup all',description='Full Backup Of " & dbnam01 & "'"    'SQL statement for backup

            'strsql = "RESTORE DATABASE { database_name | @database_name_var } [ FROM < backup_device > [ ,...n ] ] " 'SQL statement for restoring

            cn.Open()
            mysqlcomm = New SqlClient.SqlCommand(strsql, cn)
            mysqlcomm.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            '            If Not cn.State.Closed = ConnectionState.Closed Then
            ' cn.Close()
            ' End If
            Throw ex
        End Try
    End Function

    Public Function restoreDb() As Boolean
        Dim mysqlcomm As SqlClient.SqlCommand
        Dim strsql As String
        Dim strbak As String
        Dim backupdir As String
        backupdir = "d:\jignesh\"
        Try
            If backupdir <> Nothing Then
                If Not System.IO.Directory.Exists(backupdir) Then
                    System.IO.Directory.CreateDirectory(backupdir)
                End If
            Else
                If Not System.IO.Directory.Exists(Application.StartupPath + "\backup") Then
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\backup")
                End If
                backupdir = Application.StartupPath + "\backup"
            End If
            strbak = backupdir
            '            strsql = "backup database myDataBase to disk='" + strbak + "\myDataBase.bak' with name='myDataBase backup all',description='Full Backup Of myDataBase'"    'SQL statement for backup
            '            strsql = "backup database " & REP00 & " to disk='"
            '           strsql = strsql & strbak + "\" & REP00 & ".bak' with name='"
            '          strsql = strsql & REP00 & " backup all',description='Full Backup Of " & REP00 & "'"    'SQL statement for backup
            '
            strsql = "RESTORE DATABASE [" & REP00 & "] FROM disk='" & strbak & REP00 & ".bak'"  'SQL statement for restoring"
            'opencn("master")
            cn.Open()
            mysqlcomm = New SqlClient.SqlCommand(strsql, cn)
            mysqlcomm.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            '   If cn.State.Open = ConnectionState.Open Then
            ' cn.Close()
            ' End If
            Throw ex
        End Try
    End Function

    Public Function Replicate(ByVal strxx As String, ByVal lenxx As Integer) As String
        Replicate = ""
        Dim i As Integer
        For i = 1 To lenxx
            Replicate = Replicate & strxx
        Next
    End Function

    Public Function Padc(ByVal strxx As String, ByVal lenxx As Integer) As String
        Dim div01 As Integer
        If Len(Trim(strxx)) <= lenxx Then
            div01 = lenxx - Len(Trim(strxx))
        Else
            div01 = 0
        End If
        div01 = div01 / 2
        Padc = Space(div01) + strxx
    End Function

    Public Function DosView() As Boolean
        Dim TR01 As String
        TR01 = System.Environment.CurrentDirectory & "\BROWSE.com " & REP00T
        Shell(TR01, AppWinStyle.MaximizedFocus, False, -1)
    End Function

    Public Function LineSet(ByVal strxx As String, ByVal lnxx As Integer, ByVal sidexx As Integer, ByVal formate As String) As String
        If formate = "D" Then
            strxx = Format(Convert.ToDateTime(strxx), "dd/MM/yy")
        ElseIf formate = "N" Then
            If Val(strxx) = 0 Then
                strxx = Space(12)
            Else
                strxx = Format(Convert.ToDouble(strxx), "#.00")
            End If
        Else
            strxx = Trim(strxx)
        End If

        Dim ln01 As Integer
        ln01 = Len(strxx)
        If sidexx = 1 Then
            If ln01 <= lnxx Then
                LineSet = Space(lnxx - ln01) & strxx
            Else
                LineSet = strxx
            End If
        Else
            If ln01 <= lnxx Then
                LineSet = strxx & Space(lnxx - ln01)
            Else
                LineSet = strxx
            End If
        End If
    End Function

    Public Function PrintDes(ByVal pValue As String, ByRef Line As Integer) As Boolean
        If Len(Trim(pValue)) <> 0 Then
            PrintLine(1, Space(16) & pValue)
            Line = Line + 1
        End If
    End Function

    Public Function opentable(ByVal DatabaseFullPath As String, ByVal dbn As String) As Boolean
        Dim bAns As Boolean
        Dim cat As New ADOX.Catalog()
        Dim tr As String = ""
        Try

            bAns = True
            'Provider=VFPOLEDB.1;Data Source=C:\My Documents\Visual FoxPro
            'Projects;Password="";Collating Sequence=MACHINE
            cnaa = New Odbc.OdbcConnection("Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277;Dbq=" & DatabaseFullPath & "\;")
            'cna = New OleDb.OleDbConnection("Provider=VFPOLEDB.1;Data Source=Password=c:\easy;Collating Sequence=MACHINE")
            'provider to be used when working with access database
            cnaa.Open()
            '            cmdaa = New Odbc.OdbcCommand(tr, cnaa)
            '            draa = cmdaa.ExecuteReader()

            daaa = New Odbc.OdbcDataAdapter(dbn, cnaa)
            rs = New DataSet
            daaa.Fill(rs)

            'cna.Close()
        Catch Excep As System.Runtime.InteropServices.COMException
            bAns = False
            'do whatever else you need to do here, log, 
            'msgbox etc.
        Finally
            cat = Nothing
        End Try

        Return bAns
    End Function

    'Public Sub report_view()
    '    MsgBox("jignesh")
    'End Sub

    Public Function GetBal(ByVal pAcCode As Integer) As String
        Dim pValue As Double
        opencn2(dbnam01)
        fillReader2("Select bal From " & BALMST & " where ac = " & pAcCode)
        GetBal = "Nil"
        If dr2.HasRows = True Then
            While dr2.Read()
                pValue = Convert.ToDouble(dr2.Item(0))
                If pValue < 0 Then
                    GetBal = Convert.ToString(pValue * -1) & " " & "Db"
                ElseIf pValue > 0 Then
                    GetBal = Convert.ToString(pValue) & " " & "Cr"
                ElseIf pValue = 0 Then
                    GetBal = "Nil"
                End If
            End While
        Else
            GetBal = "Nil"
        End If
        cn2.Close()
    End Function

    Public Function SetShort(ByVal str As String) As String
        Dim I As Integer = 0
        str = str & " "
        SetShort = Mid(str, 1, 1)
        For I = 1 To Len(str) - 1
            I = InStr(I, str, " ", CompareMethod.Text) + 1
            SetShort = SetShort & Mid(str, I, 1)
        Next
        Return Trim(SetShort)
    End Function

    Public Function gethddno() As String
        Dim moReturn As Management.ManagementObjectCollection
        Dim moSearch As Management.ManagementObjectSearcher
        Dim mo As Management.ManagementObject
        Dim strOut As String = ""
        moSearch = New Management.ManagementObjectSearcher("Select * from  Win32_LogicalDisk")
        moReturn = moSearch.Get
        For Each mo In moReturn
            Dim VolumeName As String = mo("Name")
            Dim SerialNumber As String = mo("Volumeserialnumber")
            strOut = SerialNumber
            Exit For
        Next
        Return strOut
    End Function

    Public Function serverchek(Optional ByVal sername As String = "") As Boolean
        Dim i As Integer
        Dim oNames As SQLDMO.NameList
        Dim oSQLApp As SQLDMO.Application

        oSQLApp = New SQLDMO.Application
        oNames = oSQLApp.ListAvailableSQLServers()

        serverchek = False
        For i = 1 To oNames.Count
            If server01 = oNames.Item(i) Then
                serverchek = True
            End If
        Next i
        If serverchek = False Then
            MsgBox("Server ---> " & server01 & " Not Found ", MsgBoxStyle.Information, DEVLOP01)
        End If
    End Function

    Function ApplyLogon(ByVal cr As ReportDocument, ByVal ci As ConnectionInfo) As Boolean
        Dim li As TableLogOnInfo
        Dim tbl As Table
        ' for each table apply connection info 
        For Each tbl In cr.Database.Tables
            li = tbl.LogOnInfo
            li.ConnectionInfo = ci
            tbl.ApplyLogOnInfo(li)
            ' check if logon was successful 
            ' if TestConnectivity returns false, 
            ' check logon credentials 
            If (tbl.TestConnectivity()) Then
                'drop fully qualified table location 
                If (tbl.Location.IndexOf(".") > 0) Then
                    tbl.Location = tbl.Location.Substring(tbl.Location.LastIndexOf(".") + 1)
                Else
                    tbl.Location = tbl.Location
                End If
            Else
                Return False
            End If
        Next
        Return True
    End Function

    'The Logon method iterates through all tables 
    Function Logon(ByVal cr As ReportDocument, ByVal server As String, ByVal db As String, ByVal id As String, ByVal pass As String) As Boolean
        Dim ci As New ConnectionInfo()
        Dim subObj As SubreportObject
        ci.ServerName = server
        ci.DatabaseName = db
        ci.UserID = id
        ci.Password = pass
        If Not (ApplyLogon(cr, ci)) Then
            Return False
        End If
        Dim obj As ReportObject
        For Each obj In cr.ReportDefinition.ReportObjects()
            If (obj.Kind = ReportObjectKind.SubreportObject) Then
                subObj = CType(obj, SubreportObject)
                If Not (ApplyLogon(cr.OpenSubreport(subObj.SubreportName), ci)) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Public Function chektb(ByVal dbx As String, ByVal tbxx As String) As Boolean
        Dim str01 As String
        str01 = "select table_name FROM information_schema.tables WHERE TABLE_NAME='" & tbxx & "'"
        '  cn2.Close()
        opencn2(dbx)
        fillReader2(str01)
        If dr2.HasRows Then
            dr2.Close()
            chektb = True
        Else
            chektb = False
        End If
        cn2.Close()
        Return chektb
    End Function

    Public Function SetReportPageSize(ByVal mPaperSize As String, ByVal PaperOrientation As Integer, ByVal crx As Object, ByVal FRXX As Form) As Object
        Dim ObjPrinterSetting As New System.Drawing.Printing.PrinterSettings

        'Dim printer As String
        'Dim bytInstalledPrinters As Byte
        'Dim bytCtr As Byte
        'Dim pd As PrintDocument

        'bytInstalledPrinters = pd.PrinterSettings.InstalledPrinters.Count

        'For bytCtr = 0 To bytInstalledPrinters
        '    MessageBox.Show(pd.PrinterSettings.InstalledPrinters.Item(bytCtr))
        'Next

        Dim PkSize As New System.Drawing.Printing.PaperSize
        Dim printDocument1 = New System.Drawing.Printing.PrintDocument()
        Dim StrdPrinter As String = printDocument1.PrinterSettings.PrinterName

        ObjPrinterSetting.PrinterName = StrdPrinter

        PkSize = Nothing
        For i As Integer = 0 To ObjPrinterSetting.PaperSizes.Count - 1
            If ObjPrinterSetting.PaperSizes.Item(i).PaperName = mPaperSize.Trim Then
                PkSize = ObjPrinterSetting.PaperSizes.Item(i)
                Exit For
            End If
        Next
        If PkSize IsNot Nothing Then
        Else
            Dim PD As New PrintDialog
            Dim IX As Boolean = False
            Dim IIX As Integer = 0
            Dim COUNT01 As Integer
            COUNT01 = PD.PrinterSettings.InstalledPrinters.Count()
            Do While IX = False
                If IIX > COUNT01 Then
                    IX = True
                End If
                PD.ShowDialog(FRXX)
                ObjPrinterSetting.PrinterName = PD.PrinterSettings.PrinterName()
                StrdPrinter = ObjPrinterSetting.PrinterName
                For i As Integer = 0 To ObjPrinterSetting.PaperSizes.Count - 1
                    If ObjPrinterSetting.PaperSizes.Item(i).PaperName = mPaperSize.Trim Then
                        PkSize = ObjPrinterSetting.PaperSizes.Item(i)

                        IX = True
                        Exit For
                    Else
                        PkSize = Nothing
                    End If
                Next
                IIX = IIX + 1
            Loop
            '            MsgBox("Create Paper Size " & mPaperSize, MsgBoxStyle.Information, DEVLOP01)
        End If
        crx.PrintOptions.PrinterName = StrdPrinter
        crx.PrintOptions.PaperSize = CType(PkSize.RawKind, CrystalDecisions.Shared.PaperSize)
        crx.PrintOptions.PaperOrientation = IIf(PaperOrientation = 1, CrystalDecisions.Shared.PaperOrientation.Portrait, CrystalDecisions.Shared.PaperOrientation.Landscape)
        Return crx
    End Function

    Public Sub createtabel(ByVal COxxAB As String)

        Set_Table_Variable(CommMastxx, COxxAB)

        Dim Str01 As String

        Str01 = "CREATE TABLE " & SYSMST & " ([ShipingAdd] [nchar](1) NOT NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [DraftVou] [nchar](1) NOT NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [ChallInfo] [nchar](1) NOT NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [CashJv] [nchar](1) NOT NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [BankJv] [nchar](1) NOT NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [Adjusted] [nchar](1) NOT NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [SalesRound] [nchar](1) NOT NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [PurchRound] [nchar](1) NOT NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [SodaPurch] [nchar](1) NOT NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [BankEntrySM] [nchar](1) NOT NULL DEFAULT (N'S'),"
        Str01 = Str01 & " [CashEntrySM] [nchar](1) NOT NULL DEFAULT (N'S'),"
        Str01 = Str01 & " [SpecIssueRec] [nchar](1) NOT NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [OnLineBillInfo] [nchar](1) NOT NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [SchemeMstEnt] [nchar](1) NOT NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [MultiItmMstEnt] [nchar](1) NOT NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [LrDetail] [nchar](1) NOT NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [SaleRateTiger] [nchar](1) NOT NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [SaleBillRpt] [nchar](1) NOT NULL DEFAULT (N'M'),"
        Str01 = Str01 & " [SaleDiscount] [nchAr](1) NOT NULL DEFAULT(N'N'),"
        Str01 = Str01 & " [SaleFromChallan] [nchAr](1) NOT NULL DEFAULT(N'N'),"
        Str01 = Str01 & " [CalPackAsItMst] [nchar](1)  NULL DEFAULT (N'N'),"
        Str01 = Str01 & " [EditByVouNo] [nchar](1) NOT NULL  DEFAULT (N'N'),"
        Str01 = Str01 & " [salesgroup] [nchar](3) NOT NULL  DEFAULT ('041'),"
        Str01 = Str01 & " [CLOSINGSTOCK] [nchar](1) NOT NULL  DEFAULT (N'D'),"
        Str01 = Str01 & " [CLSTOCKONPACKQTY] [nchar](1) NOT NULL  DEFAULT (N'P')"
        Str01 = Str01 & ") ON [PRIMARY]"
        CommExe(Str01)
        cn.Close()

        '***********

        Str01 = " 	CREATE TABLE [dbo].[" & TRMST & "](" & _
                " 		[YEARNO] [int] NOT NULL," & _
                " 		[CONTRACODE] [int] NOT NULL," & _
                " 		[contrasubcode] [int] NOT NULL DEFAULT ((0))," & _
                " 		[RPTYPE] [nvarchar](2) NOT NULL," & _
                " 		[VNO] [numeric](10, 0) NOT NULL," & _
                " 		[seqno] [smallint] NOT NULL," & _
                " 		[CRDB] [smallint] NOT NULL," & _
                " 		[BILLNOA] [nvarchar](2) NULL," & _
                " 		[BILLDATE] [datetime] NULL," & _
                " 		[ACCODE] [int] NOT NULL  DEFAULT ((0))," & _
                " 		[subcode] [int] NOT NULL  DEFAULT ((0))," & _
                " 		[BRKCODE] [nvarchar](6) NULL," & _
                " 		[YEAR] [nvarchar](9) NOT NULL," & _
                " 		[RG23NO] [int] NULL," & _
                " 		[COMPANY] [real] NULL," & _
                " 		[CASH] [numeric](18, 2) NOT NULL   DEFAULT ((0))," & _
                " 		[TRSF] [numeric](18, 2) NOT NULL  DEFAULT ((0))," & _
                " 		[BANK] [numeric](18, 2) NOT NULL  DEFAULT ((0))," & _
                " 		[CREDIT] [numeric](18, 2) NOT NULL  DEFAULT ((0))," & _
                " 		[DEBIT] [numeric](18, 2) NOT NULL   DEFAULT ((0))," & _
                " 		[AlCredit] [numeric](18, 2) NULL," & _
                " 		[AlDebit] [numeric](18, 2) NULL," & _
                " 		[TRNTYPE] [smallint] NOT NULL," & _
                " 		[SCYPO_TYPE] [nvarchar](1) NULL," & _
                " 		[TQ] [smallint] NULL," & _
                " 		[DESCRIPTION] [nvarchar](100) NULL," & _
                " 		[DES1] [nvarchar](100) NULL," & _
                " 		[DES2] [nvarchar](100) NULL," & _
                " 		[DES3] [nvarchar](100) NULL," & _
                " 		[DES4] [nvarchar](100) NULL," & _
                " 		[DUEDATE] [datetime] NULL," & _
                " 		[DAYS] [real] NULL," & _
                " 		[PAYMENT] [numeric](18, 2) NULL," & _
                " 		[PAID] [nvarchar](1) NULL," & _
                " 		[RRNO] [float] NULL," & _
                " 		[TRANSPT] [nvarchar](15) NULL," & _
                " 		[BANKTHRU] [nvarchar](50) NULL," & _
                " 		[CHALLANNO] [nvarchar](15) NULL," & _
                " 		[DELCODE] [nvarchar](6) NULL," & _
                " 		[CHEQUENO] [nvarchar](15) NULL," & _
                " 		[CLGDATE] [datetime] NULL," & _
                " 		[REMARK] [nvarchar](50) NULL," & _
                " 		[TYPE] [nvarchar](4) NULL," & _
                " 		[ENTRYBY] [nvarchar](6) NULL," & _
                " 		[ENTRYDATE] [datetime] NULL," & _
                " 		[ENTRYTIME] [datetime] NULL," & _
                " 		[EDITBY] [nvarchar](6) NULL," & _
                " 		[ETDATE] [datetime] NULL," & _
                " 		[UNO] [int] NULL," & _
                " 		[STATUS] [nvarchar](3) NULL," & _
                " 		[BOOKCODE] [int] NULL," & _
                " 		[TDS] [nvarchar](3) NULL," & _
                " 		[pbillno] [nvarchar](10) NULL," & _
                " 		[AUDITDATE] [datetime] NULL," & _
                " 		[AUDITBY] [nchar](10) NULL," & _
                " 		[PETACODE] [int] NULL," & _
                " 		[MEMNO] [int] NOT NULL  DEFAULT ((0))," & _
                " 		[REFCODE] [int] NULL," & _
                " 		[REFVNO] [numeric](10, 0) NULL," & _
                " 		[REFBOOKCODE] [int] NULL," & _
                " 		[CHQDATE] [datetime] NULL," & _
                " 		[MemName] [nvarchar](50) NULL," & _
                " 		[UNIQNO] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL," & _
                " 		[SubCodeYn] [nvarchar](1) NULL," & _
                " 		[LrFrom] [nvarchar](20) NULL," & _
                " 		[LrTo] [nvarchar](20) NULL," & _
                " 		[VatAmount] [numeric](10, 2) NULL," & _
                " 		[AdvAmt] [numeric](10, 2) NULL," & _
                " 		[Point] [numeric](10, 2) NULL," & _
                " 		[BookSubCode] [int] NULL," & _
                " 		[SaleType] [varchar](3) NULL," & _
                " 		[BRKAMT] [numeric](18, 2) NULL," & _
                " 		[CFORM] [varchar](3) NULL," & _
                " 		[RATE] [numeric](18, 2) NULL," & _
                " 		[IntCre] [numeric](10, 2) NULL," & _
                " 			[IntDeb] [numeric](10, 2) NULL," & _
                " 			[Frcd] [int] NULL" & _
                " 		) ON [PRIMARY]"
        CommExe(Str01)
        cn.Close()

        Str01 = "CREATE TABLE [" & CRMST & "](" & _
                   "[BYEARNO] [int] NOT NULL," & _
                   "[BCONTRACODE] [int] NOT NULL," & _
                   "[BRPTYPE] [nvarchar](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," & _
                   "[BVNO] [numeric](10, 0) NOT NULL," & _
                   "[Bseqno] [smallint] NOT NULL," & _
                   "[RYEARNO] [int] NOT NULL," & _
                   "[RCONTRACODE] [int] NOT NULL," & _
                   "[RRPTYPE] [nvarchar](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," & _
                   "[RVNO] [numeric](10, 0) NOT NULL," & _
                   "[Rseqno] [smallint] NOT NULL," & _
                   "[UniqueNo] [int] IDENTITY(1,1) NOT NULL," & _
                   "[AMOUNT] [numeric](18, 2) NOT NULL) ON [PRIMARY]"
        CommExe(Str01)
        cn.Close()

        '***********
        Str01 = "CREATE TABLE [" & BIMST & "](" & _
                " 		[yearno] [nvarchar](2) NULL," & _
                " 		[YEAR] [nvarchar](9) NULL," & _
                " 		[RG23NO] [int] NULL," & _
                " 		[BILLNO] [numeric](10, 0) NULL," & _
                " 		[BILLNOA] [nvarchar](2) NULL," & _
                " 		[BILLDATE] [datetime] NULL," & _
                " 		[ACCODE] [int] NOT NULL DEFAULT ((0))," & _
                " 		[subcode] [int] NOT NULL DEFAULT ((0))," & _
                " 		[BRKCODE] [nvarchar](6) NULL," & _
                " 		[BOOKCODE] [int] NOT NULL DEFAULT ((0))," & _
                " 		[BOOKSUBCODE] [int] NOT NULL DEFAULT ((0))," & _
                " 		[MEMNO] [int] NOT NULL DEFAULT ((0))," & _
                " 		[contrasubcode] [int] NOT NULL DEFAULT ((0))," & _
                " 		[SEQNO] [smallint] NULL," & _
                " 		[ITEMCODE] [int] NULL," & _
                " 		[crpack] [numeric](12, 3) NULL DEFAULT ((0))," & _
                " 		[drPACK] [numeric](12, 3) NULL DEFAULT ((0))," & _
                " 		[crqty] [numeric](12, 3) NULL DEFAULT ((0))," & _
                " 		[drqty] [numeric](12, 3) NULL DEFAULT ((0))," & _
                " 		[RATE] [numeric](8, 2) NULL DEFAULT ((0))," & _
                " 		[tRATE] [numeric](8, 2) NULL DEFAULT ((0))," & _
                " 		[labcrqty] [float] NOT NULL DEFAULT ((0))," & _
                " 		[labcrpack] [float] NOT NULL DEFAULT ((0))," & _
                " 		[labdrpack] [float] NOT NULL DEFAULT ((0))," & _
                " 		[labdrqty] [float] NOT NULL DEFAULT ((0))," & _
                " 		[WEIGHT] [float] NOT NULL DEFAULT ((0))," & _
                " 		[credit] [numeric](12, 2) NULL DEFAULT ((0))," & _
                " 		[debit] [numeric](12, 2) NULL DEFAULT ((0))," & _
                " 		[Disrate] [numeric](12, 3) NULL DEFAULT ((0))," & _
                " 		[Discount] [numeric](12, 2) NULL DEFAULT ((0))," & _
                " 		[AMOUNT] [numeric](12, 2) NULL DEFAULT ((0))," & _
                " 		[vatrate] [float] NOT NULL DEFAULT ((0))," & _
                " 		[vatamount] [numeric](12, 2) NULL DEFAULT ((0))," & _
                " 		[advvat] [float] NOT NULL DEFAULT ((0))," & _
                " 		[advamt] [numeric](12, 2) NULL DEFAULT ((0))," & _
                " 		[gamount] [numeric](12, 2) NULL DEFAULT ((0))," & _
                " 		[TRNTYPE] [tinyint] NULL," & _
                " 		[SCYPO_TYPE] [nvarchar](1) NULL," & _
                " 		[BATCHNO] [nvarchar](30) NULL," & _
                " 		[BATCHNO1] [nvarchar](30) NULL," & _
                " 		[BATCHNO2] [nvarchar](30) NULL," & _
                " 		[BATCHNO3] [nvarchar](30) NULL," & _
                " 		[BATCHNO4] [nvarchar](30) NULL," & _
                " 		[DELCODE] [nvarchar](6) NULL," & _
                " 		[ENTRYBY] [nvarchar](6) NULL," & _
                " 		[ENTRYDATE] [datetime] NULL," & _
                " 		[ENTRYTIME] [datetime] NULL," & _
                " 		[EDITBY] [nvarchar](6) NULL," & _
                " 		[UNIQNO] [int] IDENTITY(1,1) NOT NULL," & _
                " 		[no] [nvarchar](10) NULL," & _
                " 		[rptype] [nvarchar](2) NULL," & _
                " 		[seqno1] [smallint] NULL," & _
                " 		[Nuno] [int] NOT NULL," & _
                " 		[AUDITDATE] [datetime] NULL," & _
                " 		[AUDITBY] [nchar](10) NULL," & _
                " 		[Refid] [int] NOT NULL," & _
                " 		[pvno] [nvarchar](10) NULL," & _
                " 		[point] [float] NOT NULL DEFAULT ((0))," & _
                " 		[scheme] [nvarchar](1) NULL," & _
                " 		[SchItem] [int] NULL," & _
                " 		[ItemName] [nvarchar](60) NULL," & _
                " 		[Description] [nvarchar](max) NULL," & _
                " 		[SodaNo] [numeric](10, 0) NULL," & _
                " 		[SodaType] [nvarchar](10) NULL," & _
                " 		[SodaYear] [nvarchar](2) NULL," & _
                " 		[SaleWidth] [numeric](18, 4) NULL," & _
                " 		[SalesLength] [numeric](18, 4) NULL," & _
                " 		[SalesQty] [numeric](18, 4) NULL," & _
                " 		[ActWidth] [numeric](18, 4) NULL," & _
                " 		[ActLength] [numeric](18, 4) NULL," & _
                " 		[ActQty] [numeric](18, 4) NULL," & _
                " 		[RefAcCode] [numeric](10, 2) NULL," & _
                " 		[RefSubCode] [numeric](10, 2) NULL," & _
                " 		[SALETYPE] [varchar](3) NULL," & _
                " 		[Frcd] [int] NULL" & _
                " 	) ON [PRIMARY]"
        CommExe(Str01)
        cn.Close()

        '****************

        Str01 = "CREATE TABLE [dbo].[" & SodaMSt & "](" & _
                "[YearNo] [nvarchar](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," & _
                "[Year] [nvarchar](9) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," & _
                "[SodaType] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," & _
                "[SodaNo] [numeric](10, 0) NOT NULL," & _
                "[SeqNo] [smallint] NOT NULL," & _
                "[SodaDate] [datetime] NOT NULL," & _
                "[AcCode] [int] NOT NULL," & _
                "[ItemCode] [int] NOT NULL," & _
                "[Pack] [float] NULL DEFAULT ((0))," & _
                "[Quantity] [float] NULL DEFAULT ((0))," & _
                "[Rate] [float] NULL DEFAULT ((0))," & _
                "[UniqNo] [int] IDENTITY(1,1) NOT NULL) ON [PRIMARY]"
        CommExe(Str01)
        cn.Close()

        '***********

        Str01 = "CREATE VIEW " & SBalMst & " As SELECT B.ItemCode AS Ic, SUM(B.CrQty) AS cr," & _
                "SUM(B.DrQty) AS dr,Sum(B.CrQty+B.DrQty) As Quantity,Sum(B.CrPack) As CP," & _
                "Sum(B.DrPack) As Dp,Sum(B.CrPack+B.DrPack) As Pack,isnull(B.SodaYear,'') As Syr," & _
                "Isnull(B.SodaType,'') As STy, isnull(B.SodaNo,0) As SNo FROM " & _
                BIMST & " As B Group By SodaYear,SodaType,SodaNo,ItemCode"
        CommExe(Str01)
        cn.Close()


        '***********

        Str01 = "CREATE TABLE [" & FMMST & "]([ACCODE] [int] NOT NULL,[SUBCODE] [int] NOT NULL,[NAME] [nvarchar](50) NULL,"
        Str01 = Str01 & "[OPNBAL] [float] NOT NULL DEFAULT ((0)),[TCREDIT] [float] NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[TDEBIT] [float] NOT NULL DEFAULT ((0)),[CLOBAL] [float] NOT NULL DEFAULT ((0)),"
        Str01 = Str01 & "[LASTDATE] [datetime] NULL,[GCODE] [nvarchar](3) NULL,[PLYN] [nvarchar](1) NULL,"
        Str01 = Str01 & "[PLACE] [nvarchar](20) NULL,[PAGE] [real] NULL,[BOOKBROK] [nvarchar](1) NULL,"
        Str01 = Str01 & "[TRNTYPE] [real] NULL,[PLACYN] [nvarchar](1) NULL,[ENTRYBY] [nvarchar](6) NULL,"
        Str01 = Str01 & "[ENTRYDATE] [datetime] NULL,[ENTRYTIME] [datetime] NULL,[EDITBY] [nvarchar](6) NULL,"
        Str01 = Str01 & "[UNIQNO] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,[RG23YN] [nvarchar](1) NULL,"
        Str01 = Str01 & "[TAXYN] [nvarchar](1) NULL,[VATINCL] [nvarchar](1) NULL"
        Str01 = Str01 & ") ON [PRIMARY]"
        CommExe(Str01)
        cn.Close()

        Str01 = "ALTER TABLE [" & SodaMSt & "]  WITH CHECK ADD  CONSTRAINT [SodaIt" & COxxAB & "] " & _
                "FOREIGN KEY([ItemCode]) REFERENCES[" & ITMST & "]([itemcode])"
        CommExe(Str01)
        cn.Close()

        '****index*** 

        Str01 = "CREATE UNIQUE INDEX TRPRIMARY ON " & TRMST & " (YEARNO,CONTRACODE,RPTYPE,VNO,SEQNO,CRDB,accode)"
        CommExe(Str01)
        cn.Close()

        Str01 = "CREATE UNIQUE INDEX SOPRIMARY ON " & SodaMSt & " (YEARNO,SODATYPE,SODANO,SEQNO)"
        CommExe(Str01)
        cn.Close()


        ' ************** CREATE VIEW

        Str01 = "CREATE VIEW " & BALMST & " AS SELECT ACCODE AS ac, SUM(credit) AS cr, SUM(debit) AS dr,"
        Str01 = Str01 & " SUM(credit-debit) AS bal FROM " & TRMST & " where rptype <> 'BO' and RPTYPE <> 'SP' "
        Str01 = Str01 & "GROUP BY accode"
        CommExe(Str01)
        cn.Close()

        Str01 = "CREATE VIEW " & GBALMST & " AS select g.code,g.name,sum(t.credit) as cr,sum(t.debit) as dr," & _
                "SUM(T.CREDIT-T.DEBIT) AS BAL from " & GRMST & " as g,ACMASTER as a," & TRMST & " as t where " & _
                "g.code=a.gcode and a.accode=t.accode and t.credit+t.debit <> 0 and t.rptype <>'BO' " & _
                "and t.RPTYPE <> 'SP' group by g.code,g.name"
        CommExe(Str01)
        cn.Close()

        Str01 = "Create Function " & itemBalFunc & " (@St_Date smallDatetime,@En_Date smallDatetime) " & _
        "RETURNS TABLE AS Return select *,cast (Opening / Weight As Int) As OpPack, " & _
        "Opening - (cast (Opening / Weight As Int)*Weight) As OpQty," & _
        "Cast(InWard / Weight As Int) As InPack, InWard - (cast (InWard / Weight As Int)*Weight) As InQty," & _
        "Cast(Total / Weight As Int) As TotPack, Total - (cast (Total / Weight As Int)*Weight) As TotQty," & _
        "Cast(OutWard / Weight As Int) As OutPack, Total - (cast (OutWard / Weight As Int)*Weight) As OutQty," & _
        "Cast(Closing / Weight As Int) As CloPack, Closing - (cast (Closing / Weight As Int)*Weight) As CloQty" & _
        " From (Select *,(Select name From " & ITGMST & " Where Code = GCode) AS GName," & _
        "IsNull((Select Sum(CrQty)-sum(DrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate < @St_Date),0) As Opening," & _
        "IsNull((Select Sum(CrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate >= @St_Date And BillDate <= @En_Date),0) As InWard," & _
        "IsNull((Select Sum(CrQty)-sum(DrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate < @St_Date),0) + " & _
        "IsNull((Select Sum(CrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate >= @St_Date And BillDate <= @En_Date),0) As Total," & _
        "IsNull((Select Sum(DrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate >= @St_Date And BillDate <= @En_Date),0) As OutWard," & _
        "IsNull((Select Sum(CrQty)-sum(DrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate < @St_Date),0) +" & _
        "IsNull((Select Sum(CrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate >= @St_Date And BillDate <= @En_Date),0) -" & _
        "IsNull((Select Sum(DrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate >= @St_Date And BillDate <= @En_Date),0) As Closing " & _
        "from " & ITMST & " As Q) As A"
        CommExe(Str01)

        Str01 = " Create Function " & itemBalDateFunc & " (@En_Date smallDatetime) " & _
                " RETURNS TABLE AS Return select *,cast (Opening / Weight As Int) As OpPack, " & _
                " Opening - (cast (Opening / Weight As Int)*Weight) As OpQty," & _
                " Cast(InWard / Weight As Int) As InPack, InWard - (cast (InWard / Weight As Int)*Weight) As InQty," & _
                " Cast(Total / Weight As Int) As TotPack, Total - (cast (Total / Weight As Int)*Weight) As TotQty," & _
                " Cast(OutWard / Weight As Int) As OutPack, Total - (cast (OutWard / Weight As Int)*Weight) As OutQty," & _
                " Cast(Closing / Weight As Int) As CloPack, Closing - (cast (Closing / Weight As Int)*Weight) As CloQty" & _
                "  From (Select *,(Select name From " & ITGMST & " Where Code = GCode) AS GName," & _
                " IsNull((Select Sum(CrQty)-sum(DrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate < @En_Date),0) As Opening," & _
                " IsNull((Select Sum(CrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate = @En_Date),0) As InWard," & _
                " IsNull((Select Sum(CrQty)-sum(DrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate < @En_Date),0) + " & _
                " IsNull((Select Sum(CrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate = @En_Date),0) As Total," & _
                " IsNull((Select Sum(DrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate = @En_Date),0) As OutWard," & _
                " IsNull((Select Sum(CrQty)-sum(DrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate < @En_Date),0) +" & _
                " IsNull((Select Sum(CrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate = @En_Date),0) -" & _
                " IsNull((Select Sum(DrQty) From " & BIMST & " Where ItemCode = Q.ItemCode And BillDate = @En_Date),0) As Closing " & _
                " from " & ITMST & " As Q) As A"
        CommExe(Str01)

        Str01 = " 		CREATE Function [dbo].[" & ITBAL & "] (@St_Date smallDatetime,@En_Date smallDatetime) " & _
                " 		RETURNS TABLE   " & _
                " 		AS   " & _
                " 		Return  " & _
                " 		  " & _
                " 		SELECT  IG.CODE AS IGCODE,IG.NAMEG AS IGNAME,B.PRATE,I.*,  " & _
                " 		  ISNULL(B.OPQTY,0) AS OPQTY,ISNULL(B.OPWEIGHT,0) AS OPWEIGHT,ISNULL(B.OPAMT,0) AS OPAMT,  " & _
                " 		  ISNULL(B.INQTY,0) AS INQTY,ISNULL(B.INWEIGHT,0) AS INWEIGHT,ISNULL(B.INAMT,0) AS INAMT,  " & _
                " 		  ISNULL(B.OUTQTY,0) AS OUTQTY,ISNULL(B.OUTWEIGHT,0) AS OUTWEIGHT,ISNULL(B.OUTAMT,0) AS OUTAMT,  " & _
                " 		  ISNULL(B.BALQTY,0) AS BALQTY,ISNULL(B.BALWEIGHT,0) AS BALWEIGHT, ISNULL(B.BALQTY,0)*ISNULL(B.PRATE,0) AS BALAMT  " & _
                " 		FROM " & ITMST & " AS I LEFT JOIN  " & _
                " 		 (SELECT ITEMCODE, PRATE,  " & _
                " 		  SUM(CASE WHEN B.BILLDATE < @St_Date THEN ISNULL(B.CRQTY,0) + ISNULL(B.DISRATE,0) - ISNULL(B.DRQTY,0) ELSE 0 END) OPQTY,  " & _
                " 		  SUM(CASE WHEN B.BILLDATE < @St_Date THEN ISNULL(B.CRPACK,0) - ISNULL(B.DRPACK,0) ELSE 0 END) OPWEIGHT,  " & _
                " 		  SUM(CASE WHEN B.BILLDATE < @St_Date THEN (ISNULL(B.CRQTY,0) + ISNULL(B.DISRATE,0) - ISNULL(B.DRQTY,0)) ELSE 0 END)* Q.PRATE AS OPAMT,  " & _
                " 		  " & _
                " 		  SUM(CASE WHEN B.BILLDATE BETWEEN @St_Date AND @En_Date THEN ISNULL(B.CRQTY,0) + ISNULL(B.DISRATE,0) ELSE 0 END) INQTY,  " & _
                " 		  SUM(CASE WHEN B.BILLDATE BETWEEN @St_Date AND @En_Date THEN ISNULL(B.CRPACK,0) ELSE 0 END) INWEIGHT,  " & _
                " 		  SUM(CASE WHEN B.BILLDATE BETWEEN @St_Date AND @En_Date THEN ISNULL(B.CREDIT,0)+ISNULL(B.DISCOUNT,0) ELSE 0 END) INAMT,  " & _
                " 		  " & _
                " 		  SUM(CASE WHEN B.BILLDATE BETWEEN @St_Date AND @En_Date THEN ISNULL(B.DRQTY,0) ELSE 0 END) OUTQTY,  " & _
                " 		  SUM(CASE WHEN B.BILLDATE BETWEEN @St_Date AND @En_Date THEN ISNULL(B.DRPACK,0) ELSE 0 END) OUTWEIGHT,  " & _
                " 		  SUM(CASE WHEN B.BILLDATE BETWEEN @St_Date AND @En_Date THEN ISNULL(B.DEBIT,0) ELSE 0 END) OUTAMT,  " & _
                " 		  " & _
                " 		  SUM(CASE WHEN B.BILLDATE <= @En_Date THEN ISNULL(B.CRQTY,0) + ISNULL(B.DISRATE,0) - ISNULL(B.DRQTY,0) ELSE 0 END) BALQTY,  " & _
                " 		  SUM(CASE WHEN B.BILLDATE <= @En_Date THEN ISNULL(B.CRPACK,0) - ISNULL(B.DRPACK,0) ELSE 0 END) BALWEIGHT,  " & _
                " 		  SUM(CASE WHEN B.BILLDATE <= @En_Date THEN (ISNULL(B.CRQTY,0) + ISNULL(B.DISRATE,0) - ISNULL(B.DRQTY,0)) ELSE 0 END) * Q.PRATE AS BALAMT  " & _
                " 		 FROM " & BIMST & " AS B   " & _
                " 		  INNER JOIN (SELECT Q.ITEMCODE AS CODE,   " & _
                " 					  CASE WHEN ROUND(ISNULL((SELECT TOP 1 B.CREDIT/nullif(Q.WEIGHT*B.CRQTY,0) FROM " & BIMST & " AS B   " & _
                " 					  WHERE B.BILLDATE <= @En_Date AND B.ITEMCODE = Q.ITEMCODE " & _
                " 					  AND CASE WHEN (Q.WEIGHT*B.CRQTY) = 0 THEN 0 ELSE B.CREDIT/nullif(Q.WEIGHT*B.CRQTY,0) END <> 0   " & _
                " 						 ORDER BY BILLDATE DESC),0),2) = 0   " & _
                " 		         THEN Q.PUR_RATE   " & _
                " 		       ELSE ROUND(ISNULL((SELECT TOP 1 B.CREDIT/nullif(Q.WEIGHT*B.CRQTY,0) FROM " & BIMST & " AS B WHERE B.BILLDATE <= @En_Date AND B.ITEMCODE = Q.ITEMCODE   " & _
                " 		         AND CASE WHEN (Q.WEIGHT*B.CRQTY) = 0 THEN 0 ELSE B.CREDIT/nullif(Q.WEIGHT*B.CRQTY,0) END <> 0 ORDER BY BILLDATE DESC),0),2) END AS PRATE  " & _
                " 		     FROM " & ITMST & " AS Q) AS Q ON B.ITEMCODE = Q.CODE  " & _
                " 		 WHERE ISNULL(CRQTY,0)+ISNULL(CREDIT,0)+ISNULL(DRQTY,0) <> 0  " & _
                " 		 AND B.BILLDATE <= @En_Date GROUP BY ITEMCODE, PRATE  " & _
                " 		) AS B ON B.ITEMCODE = I.ITEMCODE  " & _
                " 		 INNER JOIN " & ITGMST & " AS IG ON I.GCODE = IG.CODE"
        CommExe(Str01)

        Str01 = " 		CREATE Function [dbo].[" & ACBAL & "] (@Date smallDatetime)   " & _
                " 		RETURNS TABLE   " & _
                " 		AS   " & _
                " 		Return  " & _
                " 		SELECT AC.*,case when LastInt is not null then LastInt Else LoanDate End as LastInt," & _
                " 			isnull(B.IntCre,0) as IntCre,isnull(B.IntDeb,0) as IntDeb,isnull(B.Credit,0) as Credit,  " & _
                " 			isnull(B.Debit,0) as Debit,isnull(b.Bal,0) as Bal" & _
                " 		FROM " & MSMST & " AS AC" & _
                " 		 LEFT JOIN (   " & _
                " 		  SELECT ACCODE, SUBCODE, SUM(ISNULL(credit,0)) AS Credit, SUM(isnull(debit,0)) AS Debit,   " & _
                " 		      SUM(isnull(credit,0)-isnull(debit,0)) AS Bal,SUM(ISNULL(INTCRE,0)) AS IntCre,SUM(ISNULL(INTdeb,0)) AS IntDeb,  " & _
                " 		      MAX(CASE WHEN INTDEB <> 0 THEN BILLDATE ELSE NULL END) AS LastInt  " & _
                " 		  FROM " & TRMST & " WHERE RPTYPE <> 'BO' AND RPTYPE <> 'SP' AND BILLDATE <= @Date GROUP BY ACCODE,SUBCODE) AS B  " & _
                " 		   ON AC.ACCODE = B.ACCODE AND AC.SUBCODE = B.SUBCODE"
        CommExe(Str01)

        Str01 = " 		CREATE Function [dbo].[" & MEMBAL & "] (@Date smallDatetime)     " & _
                " 		RETURNS TABLE     " & _
                " 		AS     " & _
                " 		Return    " & _
                " 		SELECT M.*,B.Accode,isnull(B.IntCre,0) as IntCre,isnull(B.IntDeb,0) as IntDeb,isnull(B.Credit,0) as Credit,    " & _
                " 		 isnull(B.Debit,0) as Debit,isnull(b.Bal,0) as Bal" & _
                " 		FROM " & MMMST & " AS M  " & _
                " 		 LEFT JOIN (     " & _
                " 		  SELECT ACCODE, MemNo, SUM(ISNULL(credit,0)) AS Credit, SUM(isnull(debit,0)) AS Debit,     " & _
                " 		      SUM(isnull(credit,0)-isnull(debit,0)) AS Bal,SUM(ISNULL(INTCRE,0)) AS IntCre,SUM(ISNULL(INTdeb,0)) AS IntDeb  " & _
                " 		  FROM " & TRMST & " WHERE RPTYPE <> 'BO' AND RPTYPE <> 'SP' AND BILLDATE <= @Date GROUP BY ACCODE,MemNo) AS B  " & _
                " 		   ON M.MemNo = B.MemNo "
        CommExe(Str01)
        cn.Close()
    End Sub

    Public Sub Set_Table_Variable(ByVal commstxx As String, ByVal coabxx As String)
        If commstxx = "N" Then
            MSMST = "AC" + coabxx
            ITMST = "QU" + coabxx
            ITGMST = "ITG" + coabxx
            MMMST = "MM" + coabxx
            GRMST = "GR" + coabxx
            DSMST = "DE" + coabxx
            BOMST = "BO" + coabxx
            AIMST = "ACPT" + coabxx
            REMMST = "PTCD" + coabxx
            SCHMST = "SCH" + coabxx
            UNITMST = "UN" + coabxx
        Else
            MSMST = "ACMASTER"
            ITMST = "QUALITYMST"
            ITGMST = "ITGROUPMST"
            MMMST = "MemberMst"
            GRMST = "groupmst"
            DSMST = "DESCMST"
            YRMST = "YEARMST"
            BOMST = "boksetup"
            AIMST = "AcPeta"
            REMMST = "PETACODEMST"
            SCHMST = "schedulemst"
            UNITMST = "UNITMST"
        End If

        BIMST = "BI" + coabxx
        SodaMSt = "SODA" + coabxx
        SBalMst = "SBal" + coabxx
        TRMST = "TR" + coabxx
        FMMST = "FM" + coabxx
        PLMST = "PR" + coabxx
        CRMST = "CR" + coabxx
        STKMST = "STK" + coabxx
        BALMST = "BAL" + coabxx
        SYSMST = "Sys" + coabxx
        GBALMST = "GBAL" + coabxx
        itemBalFunc = "itemBal" + coabxx
        itemBalDateFunc = "itemBalDate" + coabxx
        ITBAL = "ITBAL" + coabxx
        ACBAL = "ACBAL" + coabxx
        MEMBAL = "MEMBAL" + coabxx
    End Sub

    Public Function Sales_Or_Purcase_OutStanding_Transfer(ByVal sp01 As String, ByVal NewCoAb As String, ByVal OldCoAb As String) As Boolean
        Dim BAL01 As Double, paid01 As Double
        Dim str01 As String = ""

        Set_Table_Variable(CommMastxx, OldCoAb)


        Dim crmstxx As String, trmstxx As String, grmstxx As String = ""
        Dim ii As Integer, cre01 As Double, deb01 As Double

        crmstxx = "CR" & NewCoAb
        trmstxx = "TR" & NewCoAb


        opencn(dbnam01)

        str01 = "DELETE FROM " & trmstxx & " WHERE TRNTYPE =0 AND RPTYPE ='SP' AND SCYPO_TYPE='" & sp01 & "'"
        CommExe(str01)
        str01 = "DELETE FROM " & crmstxx & " WHERE BRPTYPE ='SP' "
        CommExe(str01)
        str01 = "DELETE FROM " & crmstxx & " WHERE RRPTYPE ='SP' "
        CommExe(str01)

        str01 = "Select T.Yearno,T.ContraCode,T.RpType,T.SeqNo,T.Vno,T.Debit,t.credit,T.Paid,T.Year,"
        If sp01 = "S" Then
            str01 = str01 & "ISNULL((select sum(c.amount) from " & CRMST & " as c where c.bYearno=t.yearno "
            str01 = str01 & "and c.bContraCode=t.contracode and c.bRpType = t.rptype and "
            str01 = str01 & "c.bSeqNo = t.seqno and c.bVno = t.vno group by c.bYearno,c.bContraCode,"
            str01 = str01 & "c.bRpType,c.bSeqNo,c.bVno),0) AS PAIDAMT,"
        Else
            str01 = str01 & "ISNULL((select sum(c.amount) from " & CRMST & " as c where c.RYearno=t.yearno "
            str01 = str01 & "and c.RContraCode=t.contracode and c.RRpType = t.rptype and "
            str01 = str01 & "c.RSeqNo = t.seqno and c.RVno = t.vno group by c.RYearno,c.RContraCode,"
            str01 = str01 & "c.RRpType,c.RSeqNo,c.RVno),0) AS PAIDAMT,"
        End If
        str01 = str01 & "t.accode,T.BILLDATE,isnull(t.pbillno,t.vno)  as pbillno,t.totalamount,"
        str01 = str01 & "isnull(t.brkcode,'D0001') as brkcode,m.name"
        str01 = str01 & " From " & TRMST & " as t ," & MSMST & " as m where t.accode=m.accode and t.seqno =1 "

        If sp01 = "S" Then
            str01 = str01 & " and T.TRNTYPE IN (3,0) AND t.rptype <>'O' AND DEBIT <> 0"
        Else
            str01 = str01 & " and T.TRNTYPE IN (4,0) AND t.rptype <>'O' AND CREDIT <> 0"
        End If

        fillReader(str01)
        If dr.HasRows = True Then
            ii = 0
            Do While (dr.Read())
                If IsDBNull(dr.Item("PAIDAMT")) Then
                    paid01 = 0
                    BAL01 = Convert.ToDouble(dr.Item("DEBIT")) + Convert.ToDouble(dr.Item("CREDIT")) - 0
                Else
                    BAL01 = Convert.ToDouble(dr.Item("DEBIT")) + Convert.ToDouble(dr.Item("CREDIT")) - Convert.ToDouble(dr.Item("PAIDAMT"))
                    paid01 = Convert.ToDouble(dr.Item("PAIDAMT"))
                End If

                If BAL01 <> 0 Then
                    If sp01 = "S" Then
                        deb01 = BAL01
                        cre01 = 0
                    Else
                        deb01 = 0
                        cre01 = BAL01
                    End If
                    If Mid(Convert.ToString(dr.Item("name")), 1, 4) <> "CASH" Then
                        ii = ii + 1
                        str01 = "INSERT INTO " & trmstxx & " (YEARNO,CONTRACODE,RPTYPE,VNO,SEQNO,CRDB"
                        str01 = str01 & ",YEAR,BILLDATE, Accode, CREDIT,DEBIT,TRNTYPE,brkcode,SCYPO_TYPE)"
                        str01 = str01 & " VALUES(" & dr.Item("Yearno") & ","
                        str01 = str01 & dr.Item("contracode") & ",'SP',"
                        str01 = str01 & dr.Item("vno") & ","
                        str01 = str01 & "1,1,'" & dr.Item("Year") & "','"
                        str01 = str01 & Format(dr.Item("billdate"), "MM/dd/yyyy") & "',"
                        str01 = str01 & dr.Item("accode") & ","
                        str01 = str01 & cre01 & "," & deb01 & ",0,'"
                        str01 = str01 & dr.Item("brkcode") & "','" & sp01 & "')"
                        If CommExe(str01) <> 1 Then
                        End If
                        cn.Close()
                    End If
                End If
            Loop
        End If
        cn.Close()
        helpcn.Close()
        Return True
    End Function

    Public Function Opening_Stock_Transfer(ByVal NewCoAb As String, ByVal OldCoAb As String, ByVal STDT01 As Date) As Boolean

        STDT01 = DateAdd(DateInterval.Day, -1, STDT01)

        Dim MSMST01 As String = "ACMASTER"
        Dim ITMST01 As String = "QUALITYMST"
        Dim GRMST01 As String = "groupmst"
        Dim DSMST01 As String = "DESCMST"
        Dim BRMST01 As String = "brokermst"
        Dim YRMST01 As String = "YEARMST"
        Dim itgmst01 As String = "itgroupmst"
        Dim bgmst01 As String = "brgmst"
        Dim unmst01 As String = "unitmst"
        Dim BOMST01 As String = "boksetup"
        Dim AIMST01 As String = "AcItRate"
        Dim ITGMST101 As String = "ItemGroup"
        Dim PGMST01 As String = "PartyGroup"
        Dim REMMST01 As String = "Billremark"
        Dim SCHMST01 As String = "SchemeMst"
        Dim MITGMST01 As String = "MainItGroup"
        Dim MItgRel01 As String = "MainItgRel"

        If CommMastxx = "N" Then
            unmst01 = "un" + OldCoAb
            GRMST01 = "gr" + OldCoAb
            itgmst01 = "itg" + OldCoAb
            ITMST01 = "QU" + OldCoAb
            ITGMST101 = "ITM" + OldCoAb
            MITGMST01 = "MIG" + OldCoAb
            MItgRel01 = "MIGR" + OldCoAb
            MSMST01 = "AC" + OldCoAb
            bgmst01 = "brg" + OldCoAb
            BRMST01 = "br" + OldCoAb

            DSMST01 = "DE" + OldCoAb
            BOMST01 = "bo" + OldCoAb
            AIMST01 = "ACIT" + OldCoAb
            PGMST01 = "PG" + OldCoAb
            REMMST01 = "BIRE" + OldCoAb
            SCHMST01 = "SCH" + OldCoAb
        End If

        Dim sysmst01 As String = "sys" + OldCoAb
        Dim TRMST01 As String = "TR" + OldCoAb
        Dim BIMST01 As String = "BI" + OldCoAb
        Dim yrnoxx01 As Integer
        Dim YERXX01 As String

        Dim Str01 As String
        Str01 = "select * from COMST WHERE COABRV='" & NewCoAb & "'"
        opencn(dbnam01)
        fillReader(Str01)
        If dr.HasRows = True Then
            With dr
                dr.Read()
                If CommMastxx = "N" Then
                    If IIf(IsDBNull(dr.Item("COABRVP")), "", dr.Item("COABRVP")) <> OldCoAb Then
                        MsgBox("Opening Stock Transfer Not Posible", MsgBoxStyle.Information, DEVLOP01)
                        cn.Close()
                        Exit Function
                    End If
                End If
            End With
        End If
        cn.Close()

        Str01 = "SELECT * FROM COMST WHERE COABRV='" & OldCoAb & "'"
        opencn(dbnam01)
        fillReader(Str01)
        If dr.HasRows = True Then
            With dr
                dr.Read()
                yrnoxx01 = dr.Item("CCODE")
                YERXX01 = dr.Item("CCODE")
            End With
        End If
        cn.Close()

        Dim Deb01 As Double, Cre01 As Double, VNO01 As String = "1"
        opencn(dbnam01)

        Str01 = "DELETE FROM " & BIMST & " WHERE TRNTYPE =0 "
        CommExe(Str01)
        Dim QTY01C As Double = 0
        Dim PACK01C As Double = 0
        Dim QTY01D As Double = 0
        Dim PACK01D As Double = 0

        Str01 = "Select b.itemcode, SUM(b.crqty-b.drqty) AS OpQty, SUM(b.crPack-b.drPack) AS OpPack, "
        Str01 = Str01 & " SUM(b.CREDIT-B.DEBIT) AS AMT From " & BIMST01 & " as b "
        Str01 = Str01 & " group by  b.itemcode"

        Str01 = "Select b.itemcode, SUM(b.crqty-b.drqty) AS OpQty, SUM(b.crPack-b.drPack) AS OpPack, "
        Str01 = Str01 & "SUM(B.CREDIT-B.DEBIT) AS AMT "
        Str01 = Str01 & " From " & BIMST01 & " as b, " & ITMST01 & " as i, " & itgmst01 & " as Itg"
        Str01 = Str01 & " where b.itemcode=i.itemcode and itg.code = i.gcode"
        Str01 = Str01 & " GROUP BY B.ITEMCODE"

        fillReader(Str01)
        If dr.HasRows = True Then
            With dr
                Do While .Read
                    If Convert.ToDouble(dr.Item("OPQTY")) + dr.Item("OPPACK") <> 0 Then
                        If Convert.ToDouble(dr.Item("OPQTY")) < 0 Then
                            QTY01D = Convert.ToDouble(dr.Item("OPQTY")) * -1
                            QTY01C = 0
                        Else
                            QTY01C = Convert.ToDouble(dr.Item("OPQTY"))
                            QTY01D = 0
                        End If
                        If Convert.ToDouble(dr.Item("OPPACK")) < 0 Then
                            PACK01D = Convert.ToDouble(dr.Item("OPPACK")) * -1
                            PACK01C = 0
                        Else
                            PACK01C = Convert.ToDouble(dr.Item("OPPACK"))
                            PACK01D = 0
                        End If
                        If Convert.ToDouble(dr.Item("AMT")) < 0 Then
                            Deb01 = Convert.ToDouble(dr.Item("AMT")) * -1
                            Cre01 = 0
                        Else
                            Cre01 = Convert.ToDouble(dr.Item("AMT"))
                            Deb01 = 0
                        End If

                        Str01 = "Insert Into " & BIMST & " (yearno,year,BookCode,BillNo,ItemCode,crPack,drpack,CrQty,DrQty,Credit,Debit,RAte,TrnType,BillDAte,"
                        Str01 = Str01 & "NuNo,RefId, vatamount, advamt) Values(" & yrnoxx & ",'" & YERXX & "',999998,'" & VNO01 & "'," & dr.Item("ITEMCODE") & ","
                        Str01 = Str01 & PACK01C & "," & PACK01D & "," & QTY01C & "," & QTY01D & "," & Cre01 & "," & Deb01 & ",0,"
                        Str01 = Str01 & "'0','" & Format(STDT01, "MM/dd/yyyy") & "'," & VNO01 & "," & VNO01 & ",0,0)"
                        opencn1(dbnam01)
                        If CommExe1(Str01) <> 1 Then
                        End If
                        cn1.Dispose()
                        VNO01 = Val(VNO01) + 1
                    End If
                Loop
            End With
        End If
        cn.Close()
    End Function

    Public Function Opening_Master_Transfer(ByVal NewCoAb As String, ByVal OldCoAb As String, ByVal STDT01 As Date) As Boolean

        STDT01 = DateAdd(DateInterval.Day, -1, STDT01)

        Dim MSMST01 As String = "ACMASTER"
        Dim MMMST01 As String = "MemberMaster"
        Dim ITMST01 As String = "QUALITYMST"
        Dim GRMST01 As String = "groupmst"
        Dim DSMST01 As String = "DESCMST"
        Dim BRMST01 As String = "brokermst"
        Dim YRMST01 As String = "YEARMST"
        Dim itgmst01 As String = "itgroupmst"
        Dim bgmst01 As String = "brgmst"
        Dim unmst01 As String = "unitmst"
        Dim BOMST01 As String = "boksetup"
        Dim AIMST01 As String = "AcItRate"
        Dim ITGMST101 As String = "ItemGroup"
        Dim PGMST01 As String = "PartyGroup"
        Dim REMMST01 As String = "PETACODEMST"
        Dim SCHMST01 As String = "schedulemst"

        If CommMastxx = "N" Then
            unmst01 = "un" + OldCoAb
            GRMST01 = "gr" + OldCoAb
            itgmst01 = "itg" + OldCoAb
            ITMST01 = "QU" + OldCoAb
            ITGMST101 = "ITM" + OldCoAb
            MSMST01 = "AC" + OldCoAb

            bgmst01 = "brg" + OldCoAb
            BRMST01 = "br" + OldCoAb

            DSMST01 = "DE" + OldCoAb
            BOMST01 = "bo" + OldCoAb
            AIMST01 = "ACIT" + OldCoAb
            PGMST01 = "PG" + OldCoAb
            REMMST01 = "BIRE" + OldCoAb
            SCHMST01 = "SCH" + OldCoAb
        End If

        Dim sysmst01 As String = "sys" + OldCoAb
        Dim TRMST01 As String = "TR" + OldCoAb
        Dim ACBAL001 As String = "ACBAL" + OldCoAb
        Dim MEMBAL001 As String = "MEMBAL" + OldCoAb
        Dim yrnoxx01 As Integer
        Dim YERXX01 As String

        Dim str01 As String
        str01 = "select * from COMST WHERE COABRV='" & NewCoAb & "'"
        opencn(dbnam01)
        fillReader(str01)
        If dr.HasRows = True Then
            With dr
                dr.Read()
                If CommMastxx = "N" Then
                    If IIf(IsDBNull(dr.Item("COABRVP")), "", dr.Item("COABRVP")) <> OldCoAb Then
                        MsgBox("Opening Balnace Transfer Not Posible", MsgBoxStyle.Information, DEVLOP01)
                        cn.Close()
                        Exit Function
                    End If
                End If
            End With
        End If
        cn.Close()

        str01 = "select * from COMST WHERE COABRV='" & OldCoAb & "'"
        opencn(dbnam01)
        fillReader(str01)
        If dr.HasRows = True Then
            With dr
                dr.Read()
                yrnoxx01 = dr.Item("CCODE")
                YERXX01 = dr.Item("CCODE")
            End With
        End If
        cn.Close()

        Dim Deb01 As Double, Cre01 As Double, VNO01 As String = "1"
        opencn(dbnam01)

        str01 = "DELETE FROM " & TRMST & " WHERE TRNTYPE =0 AND RPTYPE ='O'"
        CommExe(str01)

        'For main ledger
        str01 = "Select t.accode,SUM(t.credit-t.debit) AS BL From " & TRMST01 & " as t, " & MSMST01 & " as"
        str01 = str01 & " a where t.ACCODE=a.accode and rptype <>'BO' and RPTYPE <> 'SP'"
        str01 = str01 & " and a.ptg='G' and isnull(a.SubLedgerType,'N') not in ('S','M')  group by t.accode"
        fillReader(str01)
        If dr.HasRows = True Then
            With dr
                Do While .Read
                    If Convert.ToDouble(dr.Item("BL")) < 0 Then
                        Deb01 = Convert.ToDouble(dr.Item("BL")) * -1
                        Cre01 = 0
                    Else
                        Deb01 = 0
                        Cre01 = Convert.ToDouble(dr.Item("BL"))
                    End If

                    str01 = "insert into " & TRMST & " (yearno,year,contracode,rptype,vno,seqno,crdb," & _
                            "AcCode,credit,debit,Trntype,billdate)" & _
                            "Values(" & yrnoxx & ",'" & YERXX & "',999999,'O','" & VNO01 & "',0,'1'," & _
                            dr.Item("aCCODE") & "," & Cre01 & "," & Deb01 & ",0," & _
                            "'" & Format(STDT01, "MM/dd/yyyy") & "')"
                    If CommExe1(str01) <> 1 Then
                    End If
                    cn1.Close()
                    VNO01 = Val(VNO01) + 1
                Loop
            End With
        End If
        cn.Dispose()

        'For Subledger
        str01 = "insert into " & TRMST & " (yearno,year,contracode,rptype,vno,seqno,crdb," & _
                            "AcCode,credit,debit,Trntype,billdate,subcode)" & _
                 "select '" & yrnoxx & "','" & YERXX & "',999999,'O',row_number() over(partition by accode order by Subcode) as Vno,0,'1',accode ," & _
                            " case when bal >=0 then bal else 0 end credit,case when bal < 0 then bal*-1 else 0 end Debit,0," & _
                            "'" & Format(STDT01, "MM/dd/yyyy") & "' as billdate,subcode " & _
                " from " & ACBAL001 & "('" & Format(STDT01, "MM/dd/yyyy") & "') as a " & _
                " where isnull(a.bal,0) <> 0 and a.accode in " & _
                "           (select accode from " & MSMST & " where isnull(subcode,0) = 0 and isnull(SubLedgerType,'') = 'S' )"
        CommExe1(str01)
        cn.Dispose()

        'For Member ledger
        str01 = "insert into " & TRMST & " (yearno,year,contracode,rptype,vno,seqno,crdb," & _
                            "AcCode,credit,debit,Trntype,billdate,subcode,MemNo)" & _
                 "select '" & yrnoxx & "','" & YERXX & "',999999,'O',row_number() over(partition by accode order by memno) as Vno,0,'1',accode," & _
                            " case when bal >=0 then bal else 0 end credit,case when bal < 0 then bal*-1 else 0 end Debit,0," & _
                            "'" & Format(STDT01, "MM/dd/yyyy") & "' as billdate,0 as subcode, A.MemNo " & _
                " from " & MEMBAL001 & "('" & Format(STDT01, "MM/dd/yyyy") & "') as a " & _
                " where isnull(a.bal,0) <> 0 and a.accode in " & _
                "           (select accode from " & MSMST & " where isnull(subcode,0) = 0 and isnull(SubLedgerType,'') = 'M' )"
        CommExe1(str01)
        cn.Dispose()
    End Function

    Public Function Get_ColumnList(ByVal Tblxx As String, ByVal Dbxx As String) As String
        Dim str01 As String = ""
        Dim str02 As String = ""
        Dim Get_cn As SqlClient.SqlConnection
        Dim Get_cm As SqlClient.SqlCommand
        Dim Get_dr As SqlClient.SqlDataReader

        If stringtype = "SQL" Then
            If Modetype = "WIN" Then
                str01 = "Data Source=" & server01 & ";Initial Catalog=" & Dbxx & ";Integrated Security=True"
            Else
                str01 = "Data Source=" & server01 & ";Initial Catalog=" & Dbxx & ";User ID=" & USERXX & "; pwd=" & passxx
            End If
        ElseIf stringtype = "EXP" Then
            If Modetype = "WIN" Then
                str01 = "Data Source=" & server01 & ";AttachDbFilename='" & Dbxx & "';Integrated Security=True"
            Else
                str01 = "Data Source=" & server01 & ";AttachDbFilename='" & Dbxx & "';User ID=" & USERXX & "; pwd=" & passxx
            End If
        End If
        Get_cn = New SqlClient.SqlConnection(str01)
        str02 = "select column_name FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='" & Tblxx & "'"
        If Get_cn.State = ConnectionState.Closed Then
            Get_cn.Open()
        End If
        Get_cm = New SqlClient.SqlCommand(str02, Get_cn)
        Get_dr = Get_cm.ExecuteReader()
        If Get_dr.HasRows Then
            str01 = ""
            Dim i As Integer = 1
            Do While Get_dr.Read
                If Get_dr.Item("column_name").ToString.ToUpper <> "UNIQNO" And Get_dr.Item("column_name").ToString.ToUpper <> "UNIQUE" Then
                    If i <> 1 Then
                        str01 = str01 & ","
                    End If
                    str01 = str01 & Get_dr.Item("column_name")
                    i = i + 1
                End If
            Loop
        End If
        Get_cn.Close()
        Return str01
    End Function

    Public Function Get_GujName(ByVal txtxx As String) As String
        Dim dbnmxx As String = "Account"
        Get_GujName = ""
        Dim EXT01 As Boolean = True
        Dim m As Integer, LN01 As Integer, I As Integer
        Dim str04(100) As String, str02 As String = txtxx
        Dim str03 As String = ""
        m = 1
        For I = 1 To 100
            str04(I) = ""
        Next
        Do While Len(Trim(str02)) <> 0
            str04(m) = ""
            LN01 = Len(Trim(str02))
            EXT01 = True
            For I = 1 To LN01
                If Mid(str02, I, 1) = " " Or Mid(str02, I, 1) = "," Then
                    If Mid(str02, I, 1) = "," Then
                        m = m + 1
                        str04(m) = str04(m) + Mid(str02, I, 1)
                    End If
                    str02 = Mid(str02, I + 1, LN01)
                    EXT01 = False
                    Exit For
                End If
                str04(m) = str04(m) + Mid(str02, I, 1)
            Next
            If EXT01 = True Then
                Exit Do
            End If
            m = m + 1
        Loop

        Dim str01 As String
        For I = 1 To m
            str02 = ""
            If Len(Trim(str04(I))) <> 0 Then
                str01 = "select * from nammst where name_e='" & str04(I) & "' and name_g <> ''"
                opencn(dbnmxx)
                cn.Open()
                fillReader(str01)
                If dr.HasRows = False Then
                    str02 = inputj(str04(I))
                    str01 = "insert into nammst(name_e,name_g) values(@name_e,@name_g)"

                    If stringtype = "SQL" Then
                        If Modetype = "WIN" Then
                            str03 = "Data Source=" & server01 & ";Initial Catalog=" & dbnmxx & ";Integrated Security=True"
                        Else
                            str03 = "Data Source=" & server01 & ";Initial Catalog=" & dbnmxx & ";User ID=" & USERXX & "; pwd=" & passxx
                        End If
                    ElseIf stringtype = "EXP" Then
                        If Modetype = "WIN" Then
                            str03 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnmxx & "';Integrated Security=True"
                        Else
                            str03 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnmxx & "';User ID=" & USERXX & "; pwd=" & passxx
                        End If
                    End If
                    If str02.ToString.Trim.Length <> 0 Then
                        cn2 = New SqlClient.SqlConnection(str03)
                        If cn2.State = ConnectionState.Closed Then
                            cn2.Open()
                        Else
                            cn2.Close()
                            cn2.Open()
                        End If
                        cm2 = New SqlClient.SqlCommand(str01, cn2)
                        cm2.Parameters.Add("@name_e", SqlDbType.Char, 50).Value = str04(I)
                        cm2.Parameters.Add("@name_g", SqlDbType.Char, 50).Value = str02
                        cm2.ExecuteNonQuery()
                        cn2.Dispose()
                    End If
                Else
                    dr.Read()
                    str02 = dr.Item("name_g")
                End If
                Get_GujName = Get_GujName & " " & Trim(str02)
            End If
        Next
    End Function

    Public Function inputj(ByVal say01 As String) As String
        InputText.Label1.Text = say01
        InputText.ShowDialog()
        InputText.Close()
        inputj = FLDXX
    End Function

    Function FindTrntype(ByVal vAcCode As Double) As Integer
        Dim trnTyp01 As Integer
        opencn1(dbnam01)
        fillReader1("Select isnull(TrnType,0) as TrnType from " & MSMST & " where AcCode=  " & vAcCode & " ")
        If dr1.HasRows = True Then
            While dr1.Read
                trnTyp01 = Convert.ToInt16(dr1.Item("TrnType"))
            End While
        End If
        dr1.Close()
        cn1.Close()
        Return trnTyp01
    End Function

    Public Function SalesBill_Print(ByVal Bokxx As String, ByVal Contxx As Integer, ByVal billnoxx As Integer, ByVal BillType As String, Optional ByVal linexx As Integer = 27, _
                                    Optional ByVal BillNoa As String = "", Optional ByVal BokSubxx As Integer = 0) As Boolean
        Dim Trn01 As Integer = 3
        Dim Rpt01 As String = "S"
        Dim Str01 As String = ""
        Dim i As Integer = 0

        opencn(dbnam01)
        openreport(REP00)

        CommandReport("DELETE FROM SBILLRPT")
        helpcn.Dispose()
        Str01 = " insert into SbillRpt(BillNo, BillNoa, BDate, Remark, SeqNo," & _
                " Itemcode, ItemName,  Qty, Rate, Amount, " & _
                " VatRate, vatamount, AdvVat, AdvAmt, tRate, mrp, " & _
                " BatchNo, " & _
                " AcCode, Name, Add1, Add2, Add3, Add4,  " & _
                " stNo, cstno,  Des,  BookCode, BookName, YearNo, Point, SCYPO_TYPE, gAmount,cahllanno) "
        Str01 &= " Select t.Vno, t.BillNoa, t.BillDate, t.Remark, b.SEQNO, " & _
                " b.ITEMCODE, it.nameg as ItemName, b.DRQTY,  b.Rate, b.DEBIT, b.VATRATE, " & _
                " b.VATAMOUNT,  b.ADVVAT, b.ADVAMT, b.trate,  it.mrp, b.BATCHNO,  " & _
                " CASE WHEN B.MEMNO <> 0 THEN B.MEMNO WHEN ISNULL(B.FRCD,0) <> 0 THEN B.FRCD ELSE T.SUBCODE END AS MEMNO , " & _
                " case WHEN T.MEMNO <> 0 THEN (SELECT A1.MEMNAMEG + CASE WHEN ISNULL(D.NAMEG,'') <> '' THEN ' (' + D.NAMEG + ')' ELSE '' END FROM " & dbnam01 & "..MEMBERMST AS A1 LEFT JOIN " & dbnam01 & "..DEPTMST AS D ON A1.UNIT = D.CODE " & _
                " WHERE A1.MEMNO = T.MEMNO) WHEN ISNULL(T.FRCD,0) <> 0 THEN ISNULL(T.DES2,'') WHEN len(isnull(T.DES4,'')) = 0 THEN A.NAMEG  ELSE T.DES4 END  AS NAME," & _
                "  case when t.billnoa = 20 then t.des3 else A.Add1 end Add1, A.Add2, A.Add3, case when isnull(t.des4,'') <> '' then t.des4 else A.Add4 end add4, a.St_No, a.Cst_No, (t.Description+t.Des1) as des," & _
                " t.BookCode, (select nameg from " & dbnam01 & ".dbo." & MSMST & " where accode = t.bookcode and subcode = t.booksubcode) AS BNAME," & _
                " t.YearNo, t.Point, T.SALETYPE, b.Amount,B.rg23no " & _
                " from " & dbnam01 & ".dbo." & TRMST & " as t," & _
                " " & dbnam01 & ".dbo." & BIMST & " As b,  " & _
                " " & dbnam01 & ".dbo." & ITMST & "  As it,  " & _
                " " & dbnam01 & ".dbo." & MSMST & " as a" & _
                " WHERE T.YEARNO = " & Val(Contxx) & " " & _
                " AND T.BOOKCODE = " & Bokxx & " AND T.BOOKSUBCODE = " & BokSubxx & _
                " And t.Rptype = '" & Rpt01 & "'" & _
                " And t.vno = " & Val(billnoxx) & "" & _
                " And t.Seqno = 1  " & _
                " And t.Crdb = 1  " & _
                " And t.BILLNOA = '" & BillNoa & "'  AND b.ItemCode = it.ItemCode " & _
                " and t.Yearno = b.yearno " & _
                " And t.bookcode = b.bookcode and t.booksubcode = b.booksubcode " & _
                " And t.Rptype = b.rptype " & _
                " and t.vno = b.billno " & _
                " and t.billnoa = b.billnoa " & _
                " And t.Trntype = " & Trn01 & "" & _
                " and t.accode = a.accode and t.subcode = a.subcode " & _
                " order by  b.Uniqno, b.SeqNo  "
        openreport(REP00)
        CommandReport(Str01)
        Dim ii As Integer = 0
        Str01 = "SELECT * FROM SBILLRPT"
        fillReportrs(Str01)
        ii = helprs.Tables(0).Rows.Count + 1
        If ii >= 0 Then
            SalesBill_Print = True
        End If

        Str01 = "SELECT * FROM SBILLRPT WHERE BATCHNO <> ''"
        fillReportrs(Str01)
        ii = ii + helprs.Tables(0).Rows.Count + IIf(helprs.Tables(0).Rows.Count = 0, 0, 1)

        For i = ii To linexx
            SalesBill_Print = True
            Str01 = " insert into SbillRpt(BillNo, BillNoa, BDate, remark, " & _
                    " AcCode, Name, Add1, Add2, Add3, Add4, " & _
                    " stno, cstNo, Des, BookCode, BookName, YearNo, Point, SCYPO_TYPE,SeqNo) "
            Str01 = Str01 & " Select t.Vno, t.BillNoa, t.BillDate, t.Remark,  " & _
                    " t.Accode, case len(isnull(T.DES4,''))  when 0 then A.NAME  else T.DES4 end  as name, " & _
                    " A.Add1, A.Add2, A.Add3, A.Add4, ISNULL(a.St_No,''),ISNULL( a.Cst_No,''), (t.Description+t.Des1) as des," & _
                    " t.BookCode, " & _
                    " (select nameg from " & dbnam01 & ".dbo." & MSMST & " where accode = t.bookcode and subcode = t.booksubcode) as bname, " & _
                    " t.YearNo, t.Point, t.SCYPO_TYPE, " & i & _
                    " from " & dbnam01 & ".dbo." & TRMST & " as t," & _
                    " " & dbnam01 & ".dbo." & MSMST & " as a" & _
                    " Where t.Yearno  = " & Val(Contxx) & "" & _
                    " And t.bookcode = " & Bokxx & " and t.booksubcode = " & BokSubxx & _
                    " And t.Rptype= '" & Rpt01 & "'" & _
                    " And t.vno = " & Val(billnoxx) & "" & _
                    " And t.BILLNOA = '" & BillNoa & "'" & _
                    " and A.AcCode = t.AcCode and t.subcode = a.subcode   " & _
                    " and t.Seqno = 1 and crdb = 1 " & _
                    " And t.Trntype = " & Trn01 & ""
            CommandReport(Str01)
        Next

        Dim totamt As Double = 0
        Str01 = "SELECT ISNULL(SUM(AMOUNT),0) AS AMT FROM SBILLRPT "
        fillhelpdr(Str01)
        If helpdr.HasRows = True Then
            helpdr.Read()
            totamt = Convert.ToDouble(helpdr.Item("Amt"))
        End If
        helpdr.Close()
        helpcn.Close()

        Dim totBal01 As String = 0
        If BillType = "Credit" Then
            Str01 = "SELECT ACCODE FROM SBILLRPT "
            fillhelpdr(Str01)
            If helpdr.HasRows = True Then
                helpdr.Read()
                totBal01 = GetBal(Convert.ToDouble(helpdr.Item("accode")))
            End If
            helpdr.Close()
            helpcn.Close()
        End If
        Str01 = "update sbillRpt set wamt = '" & atowg(totamt) & "', Balance = '" & totBal01 & "'"
        CommandReport(Str01)
    End Function

    Public Sub SBillLoadPara(ByVal CSxx As Object, ByVal Headxx As String, ByVal Bokxx As String, ByVal printcopy As Integer, Optional ByVal ShowAndPrint As Boolean = False, Optional ByVal ThermalYN As Boolean = False)
        Dim Str01 As String
        param1Fileds.Clear()

        Str01 = "SELECT * FROM SBILLRPT"
        fillReportrs(Str01)
        CSxx.SetDataSource(helprs.Tables(0))
        CSxx.Refresh()

        If ShowAndPrint = False Then
            param1Range.Value = conmxx
            param2Range.Value = add4xx
            param3Range.Value = Bokxx
            param4Range.Value = "xelt ltk. ( mte.yumt.xe ) & " + cstxx
            param5Range.Value = "PHONE # " + phonxx
            param6Range.Value = "xelt ltk. ( B.yumt.xe ) & " + gstxx
            param7Range.Value = Headxx

            CSxx.ParameterFields("P1").CurrentValues.Add(param1Range)
            CSxx.ParameterFields("pa1").CurrentValues.Add(param2Range)
            CSxx.ParameterFields("P2").CurrentValues.Add(param3Range)
            CSxx.ParameterFields("P4").CurrentValues.Add(param4Range)
            CSxx.ParameterFields("P5").CurrentValues.Add(param5Range)
            CSxx.ParameterFields("P3").CurrentValues.Add(param6Range)
            CSxx.ParameterFields("P6").CurrentValues.Add(param7Range)
            If ThermalYN = True Then
                If CSxx.GetType.Name = "HclSalesBillRptGuj" Then
                    DirectCast(CSxx, HclSalesBillRptGuj).PrintOptions.PrinterName = "VENDOR THERMAL PRINTER"
                End If
            End If
            CSxx.PrintToPrinter(printcopy, True, 0, 0)
        Else
            Dim RptView As New crr

            SetReportPageSize("A5", 2, CSxx, CaseSalesBill)
            RptView.PageName = "A5"
            RptView.PageOriant = 2

            param1Field.ParameterFieldName = "P1"
            param1Range.Value = conmxx
            param1Field.CurrentValues.Add(param1Range)
            param1Fileds.Add(param1Field)

            param2Field.ParameterFieldName = "Pa1"
            param2Range.Value = add4xx
            param2Field.CurrentValues.Add(param2Range)
            param1Fileds.Add(param2Field)

            param3Field.ParameterFieldName = "P2"
            param3Range.Value = Bokxx
            param3Field.CurrentValues.Add(param3Range)
            param1Fileds.Add(param3Field)

            param4Field.ParameterFieldName = "P4"
            param4Range.Value = "xelt ltk. ( mte.yumt.xe ) & " + cstxx
            param4Field.CurrentValues.Add(param4Range)
            param1Fileds.Add(param4Field)

            param5Field.ParameterFieldName = "P5"
            param5Range.Value = "PHONE # " + phonxx
            param5Field.CurrentValues.Add(param5Range)
            param1Fileds.Add(param5Field)

            param6Field.ParameterFieldName = "P3"
            param6Range.Value = "xelt ltk. ( B.yumt.xe ) & " + gstxx
            param6Field.CurrentValues.Add(param6Range)
            param1Fileds.Add(param6Field)

            param7Field.ParameterFieldName = "P6"
            param7Range.Value = Headxx
            param7Field.CurrentValues.Add(param7Range)
            param1Fileds.Add(param7Field)
            RptView.crv1.ParameterFieldInfo = param1Fileds

            RptView.crv1.ReportSource = CSxx
            RptView.crv1.Refresh()
            RptView.ShowDialog()
        End If
    End Sub

    Public Function GetMstValue(ByVal GetValue As String, ByVal TableName As String, ByVal WhereCode As String, ByVal dbnamxx As String) As String
        GetMstValue = ""
        Dim cnCode As New SqlClient.SqlConnection
        Dim cmCode As New SqlClient.SqlCommand
        Dim drCode As SqlClient.SqlDataReader
        Dim Str01 As String = ""
        Try
            If stringtype = "SQL" Then
                If Modetype = "WIN" Then
                    Str01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnamxx & ";Integrated Security=True"
                Else
                    Str01 = "Data Source=" & server01 & ";Initial Catalog=" & dbnamxx & ";User ID=" & USERXX & "; pwd=" & passxx
                End If
            ElseIf stringtype = "EXP" Then
                If Modetype = "WIN" Then
                    Str01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnamxx & ";Integrated Security=True"
                Else
                    Str01 = "Data Source=" & server01 & ";AttachDbFilename='" & dbnamxx & "';User ID=" & USERXX & "; pwd=" & passxx
                End If
            End If
            cnCode = New SqlClient.SqlConnection(Str01)
            cnCode.Open()

            Str01 = "Select " & GetValue & " From " & TableName & " where " & WhereCode
            cmCode = New SqlClient.SqlCommand(Str01, cnCode)
            drCode = cmCode.ExecuteReader()

            Dim tValue As String = ""
            If drCode.HasRows Then
                drCode.Read()
                tValue = drCode.Item(0)
            End If
            drCode.Close()
            cnCode.Dispose()
            GetMstValue = tValue
            Return GetMstValue
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, DEVLOP01)
        End Try
        Return GetMstValue
    End Function

    Public Function atowg(ByVal b As Double) As String
        Dim A(99) As String, wrd As String

        A(1) = "yuf"
        A(2) = "ctu"
        A(3) = "*tKt"
        A(4) = "atth"
        A(5) = "vttkat"
        A(6) = "A"
        A(7) = "mtt@t"
        A(8) = "ytkX"
        A(9) = "ltJt"
        A(10) = "D mt"
        A(11) = "ydtegtth"
        A(12) = "ctth"
        A(13) = "@tuh"
        A(14) = "attiD"
        A(15) = "vtkD h"
        A(16) = "mttuG"
        A(17) = "mtãh"
        A(18) = "yZth"
        A(19) = "ytudtKtemt"
        A(20) = "Jtemt"
        A(21) = "yufJtemt"
        A(22) = "cttJtemt"
        A(23) = "*tuJtemt"
        A(24) = "attuJtemt"
        A(25) = "vtaatemt"
        A(26) = "AJJtemt"
        A(27) = "mtãtJtemt"
        A(28) = "y ¸tJtemt"
        A(29) = "ytudtl*temt"
        A(30) = "*temt"
        A(31) = "yuf*temt"
        A(32) = "ct*temt"
        A(33) = "@tu*temt"
        A(34) = "attu*temt"
        A(35) = "vttk*temt"
        A(36) = "A*temt"
        A(37) = "mttz*temt"
        A(38) = "ytz*temt"
        A(39) = "ytudtKtattjtemt"
        A(40) = "attjtemt"
        A(41) = "yuf@ttjtemt"
        A(42) = "ctu@ttjtemt"
        A(43) = "@tu@ttjtemt"
        A(44) = "atwbJttjtemt"
        A(45) = "vtemt@ttjtemt"
        A(46) = "Au@ttjtemt"
        A(47) = "mtwz@ttjtemt"
        A(48) = "Wz@ttjtemt"
        A(49) = "ytudtKtvtaattmt"
        A(50) = "vtaattmt"
        A(51) = "yu²tJtlt"
        A(52) = "ccttJtlt"
        A(53) = "*tuvvtlt"
        A(54) = "attuvvtlt"
        A(55) = "vtkattJtlt"
        A(56) = "Avvtlt"
        A(57) = "mtãtJtlt"
        A(58) = "y¸tJtlt"
        A(59) = "ytudtKtmttkX"
        A(60) = "mttkX"
        A(61) = "yufmtX"
        A(62) = "cttkmtX"
        A(63) = "*tumtX"
        A(64) = "attumtX"
        A(65) = "vttkmtX"
        A(66) = "AtkmtX"
        A(67) = "mtzmtX"
        A(68) = "yzmtX"
        A(69) = "ytudtKgttumteãuh"
        A(70) = "mteãuh"
        A(71) = "Eftu@tuh"
        A(72) = "cttu@tuh"
        A(73) = "@ttu@tuh"
        A(74) = "atwbttu@tuh"
        A(75) = "vtkattu@tuh"
        A(76) = "Atu@tuh"
        A(77) = "mte@ttu@tuh"
        A(78) = "E¸tu@tuh"
        A(79) = "ytudtKgttyukmte"
        A(80) = "yumte"
        A(81) = "yufgttmte"
        A(82) = "cgttmte"
        A(83) = "@gttkmte"
        A(84) = "attugttpmte"
        A(85) = "vtkagttmte"
        A(86) = "Agttkmte"
        A(87) = "mt@gttkmte"
        A(88) = "yXgttkmte"
        A(89) = "ltuJgttmte"
        A(90) = "ltuJtw"
        A(91) = "yuftKtw"
        A(92) = "cttKtw"
        A(93) = "*ttKtw"
        A(94) = "attuhtKtw"
        A(95) = "vtkattKtw"
        A(96) = "Alltw"
        A(97) = "mtãtKtwk"
        A(98) = "y¸tKtwk"
        A(99) = "ltJttKtwk"

        Dim b99 As Double = 0, vb As String = ""
        Dim b2 As Double = 0, b1 As Double = 0, b3 As Double = 0
        wrd = ""
        b99 = b
        If b99 > 999999999.99 Then
            b1 = Int(b99 / 1000000000)
            b2 = b1
            wrd = wrd + A(b2)
            b99 = b99 - b1 * 1000000000
            wrd = wrd + " ycts "
            atowg = wrd
        End If
        If b99 > 9999999.99 Then
            b1 = Int(b99 / 10000000)
            b2 = b1
            wrd = wrd + A(b2)
            b99 = b99 - b1 * 10000000
            wrd = wrd + " fhtuz "
        End If
        If b99 > 99999.99 Then
            b1 = Int(b99 / 100000)
            b2 = b1
            wrd = wrd + A(b2)
            b99 = b99 - b1 * 100000
            wrd = wrd + " jttFt "
        End If

        If b99 > 999.99 Then
            b1 = Int(b99 / 1000)
            b2 = b1
            wrd = wrd + A(b2)
            b99 = b99 - b1 * 1000
            wrd = wrd + " nSh "
        End If
        If b99 > 99 Then
            b1 = Int(b99 / 100)
            b2 = b1
            If b2 = 2 Then
                wrd = wrd + "ctmttu "
            Else
                wrd = wrd + A(b2)
            End If
            b99 = b99 - b1 * 100
            wrd = wrd + "mttu "
        End If
        If b99 > 0.99 Then
            b1 = Int(b99)
            b2 = b1
            wrd = wrd + A(b2)
            b99 = b99 - b1 * 1
            wrd = wrd + ""
        End If

        If b99 > 0 Then
            If Len(Trim(wrd)) <> 0 Then
                wrd = wrd + " yltu "
            End If
            b1 = b99 * 100 + 0.005
            b2 = b1
            wrd = wrd + " vtimtt "
            vb = "A" + Trim(LTrim(Str(b2)))
            wrd = wrd + A(b2)
        End If
        atowg = wrd + " vtwht."
    End Function

    Public Function Int_Day2Day(ByVal AcCode01 As Integer, ByVal SubCode01 As Integer, ByVal Rate01 As Double, ByVal StartDate01 As DateTime, ByVal EndDate01 As DateTime) As Double
        Dim Str01 As String
        Dim Balance01 As Double = 0, Int01 As Double = 0, Dt001, Dt002 As Date, Day01 As Integer = 0
        Dt001 = StartDate01
        Dt002 = StartDate01
        Str01 = " SELECT BILLDATE FROM " & dbnam01 & ".dbo." & TRMST & " WHERE ACCODE = " & AcCode01 & " AND SUBCODE = " & SubCode01 & _
                " AND BILLDATE BETWEEN '" & Format(StartDate01, "MM/dd/yyyy") & "' and '" & Format(EndDate01, "MM/dd/yyyy") & "' " & _
                " GROUP BY BILLDATE "
        opencn2(dbnam01)
        cn2.Open()
        fillReader2(Str01)
        If dr2.HasRows = True Then
            While dr2.Read()
                Dt001 = Dt002
                Dt002 = CDate(dr2.Item("BILLDATE"))
                Day01 = DateDiff(DateInterval.Day, Dt001, Dt002)
                Balance01 = GetMstValue("bal*-1", ACBAL & "('" & Format(Dt002.AddDays(-1), "MM/dd/yyyy") & "')", " ACCODE = " & AcCode01 & " AND SUBCODE = " & SubCode01, dbnam01)
                Int01 += Math.Round((((Balance01 * Rate01 / 100.0) / 365.0) * Day01), 0)
            End While
        End If
        dr2.Close() : cn2.Dispose()

        Dt001 = Dt002
        Dt002 = EndDate01
        Day01 = DateDiff(DateInterval.Day, Dt001, Dt002)
        Balance01 = GetMstValue("BAL*-1", ACBAL & "('" & Format(Dt002.AddDays(-1), "MM/dd/yyyy") & "')", " ACCODE = " & AcCode01 & " AND SUBCODE = " & SubCode01, dbnam01)
        Int01 += Math.Round((((Balance01 * Rate01 / 100.0) / 365.0) * Day01), 0)

        Return Math.Round(Int01, 0)
    End Function

    Public Function Int_Day2Day_Member(ByVal AcCode01 As Integer, ByVal SubCode01 As Integer, ByVal Rate01 As Double, ByVal StartDate01 As DateTime, ByVal EndDate01 As DateTime) As Double
        Dim Str01 As String
        Dim Balance01 As Double = 0, Int01 As Double = 0, Dt001, Dt002 As Date, Day01 As Integer = 0
        Dt001 = StartDate01
        Dt002 = StartDate01
        Str01 = " SELECT BILLDATE FROM " & dbnam01 & ".dbo." & TRMST & " WHERE ACCODE = " & AcCode01 & " AND MemNo = " & SubCode01 & _
                " AND BILLDATE BETWEEN '" & Format(StartDate01, "MM/dd/yyyy") & "' and '" & Format(EndDate01, "MM/dd/yyyy") & "' " & _
                " GROUP BY BILLDATE "
        opencn2(dbnam01)
        cn2.Open()
        fillReader2(Str01)
        If dr2.HasRows = True Then
            While dr2.Read()
                Dt001 = Dt002
                Dt002 = CDate(dr2.Item("BILLDATE"))
                Day01 = DateDiff(DateInterval.Day, Dt001, Dt002)
                Balance01 = Val(GetMstValue("bal", MEMBAL & "('" & Format(Dt002.AddDays(-1), "MM/dd/yyyy") & "')", " ACCODE = " & AcCode01 & " AND MemNo = " & SubCode01, dbnam01))
                Int01 += Math.Round((((Balance01 * Rate01 / 100.0) / 365.0) * Day01), 0)
            End While
        End If
        dr2.Close() : cn2.Dispose()

        Dt001 = Dt002
        Dt002 = EndDate01
        Day01 = DateDiff(DateInterval.Day, Dt001, Dt002)
        Balance01 = Val(GetMstValue("BAL", MEMBAL & "('" & Format(Dt002.AddDays(-1), "MM/dd/yyyy") & "')", " ACCODE = " & AcCode01 & " AND MemNo = " & SubCode01, dbnam01))
        Int01 += Math.Round((((Balance01 * Rate01 / 100.0) / 365.0) * Day01), 0)

        Return Math.Round(Int01, 0)
    End Function

    Function SetRadio(ByVal R As System.Windows.Forms.GroupBox)
        For Each C As Object In R.Controls
            If TypeOf C Is System.Windows.Forms.RadioButton Then
                If DirectCast(C, System.Windows.Forms.RadioButton).Checked = True Then
                    DirectCast(C, System.Windows.Forms.RadioButton).ForeColor = Color.Red
                Else
                    DirectCast(C, System.Windows.Forms.RadioButton).ForeColor = Color.Black
                End If
            End If
        Next
    End Function

    Public Function Int_Day2Day_Old(ByVal AcCode01 As Integer, ByVal SubCode01 As Integer, ByVal Rate01 As Double, ByVal StartDate01 As DateTime, ByVal EndDate01 As DateTime) As Double
        Dim ADINT01 As Double = 0
        Dim ADINT02 As Double = 0
        Dim ADINT03 As Double = 0
        Dim Str01 As String

        Dim rtint01 As Double = 8
        Dim DHPAMT01 As Double = 0

        rtint01 = Rate01

        Dim OPBAL01 As Double = 0
        Dim DHIAMT01 As Double = 0
        Dim OPINT01 As Double = 0
        Dim SDT001 As Date

        SDT001 = StartDate01
        Dim OPDAT01x As Date = DateAdd(DateInterval.Day, -1, StartDate01)
        OPBAL01 = 0

        'Str01 = " SELECT * FROM ACBAL('" & Format(Date.Now.Date, "MM/dd/yyyy") & "') " & _
        '        " where AcCode = " & AcCode01 & " and SubCode = " & SubCode01
        'opencn2(dbnam01)
        'cn2.Open()
        'fillReader2(Str01)
        'If dr2.HasRows = True Then
        '    dr2.Read()
        '    If StartDate01 < dr2.Item("LoanDate") Then
        '        OPDAT01x = Convert.ToDateTime(Dr3.Item("LoanDate"))
        '        Str01 = " SELECT OPNBAL FROM acbalfunc('" & Format(OPDAT01x, "MM/dd/yyyy") & "') " & _
        '                " where Code = '" & Code01 & "' and folio = " & Folio01 & " and ledger = " & Ledger01
        '        FillReader3(Str01, dbname)
        '        If Dr3.HasRows = True Then
        '            Dr3.Read()
        '            OPBAL01 = Dr3.Item("OPNBAL")
        '            If OPBAL01 <> 0 Then
        '                SDT001 = OPDAT01x
        '            End If
        '        End If
        '        Dr3.Close() : Cn3.Close()

        '    End If
        'End If
        'Dr3.Close() : Cn3.Close()

        Str01 = " SELECT * FROM " & ACBAL & "('" & Format(DateAdd(DateInterval.Day, -1, StartDate01), "MM/dd/yyyy") & "') " & _
                " where AcCode = " & AcCode01 & " and SubCode = " & SubCode01
        opencn2(dbnam01)
        cn2.Open()
        fillReader2(Str01)
        If dr2.HasRows = True Then
            dr2.Read()
            OPBAL01 = OPBAL01 + dr2.Item("BAL")
        End If
        dr2.Close() : cn2.Close()

        OPBAL01 = IIf(OPBAL01 < 0, OPBAL01 * -1, OPBAL01)

        Dim DHIREC As Double = 0
        Dim DHIINT As Double = 0
        Dim OPBAL01x As Double = DHPAMT01
        Dim OPINT01x As Double = DHIAMT01
        ADINT03 = 0
        Dim DY01I As Integer

        rtint01 = Rate01
        DHPAMT01 = OPBAL01

        Str01 = " SELECT BILLDATE AS DATE,SUM(ISNULL(CREDIT,0)) AS CREDIT,SUM(ISNULL(DEBIT,0)) AS DEBIT " & _
                " FROM " & TRMST & " where ACCODE = " & AcCode01 & " AND SUBCODE = " & SubCode01 & _
                " AND BILLDATE BETWEEN '" & Format(StartDate01, "MM/dd/yyyy") & "' AND '" & Format(EndDate01, "MM/dd/yyyy") & "'" & _
                " GROUP BY BILLDATE ORDER BY BILLDATE"
        opencn2(dbnam01)
        cn2.Open()
        fillReader2(Str01)
        If dr2.HasRows = False Then
            DHIREC = 0
            DHIINT = 0
            DY01I = DateDiff(DateInterval.Day, SDT001, EndDate01) + 1
            ADINT01 = OPBAL01 * Rate01 * DY01I / 36500
            ADINT03 = ADINT01
        Else
            Dim IX As Integer = 0
            Dim DTX02 As Date
            Do While dr2.Read()
                DTX02 = dr2.Item("DATE")
                If IX = 0 And OPBAL01 = 0 Then
                    SDT001 = dr2.Item("DATE")
                    IX = 1
                End If

                DY01I = DateDiff(DateInterval.Day, SDT001, DTX02)

                SDT001 = DTX02
                ADINT01 = DHPAMT01 * rtint01 * DY01I / 36500
                ADINT03 = ADINT03 + ADINT01 + ADINT02

                DHPAMT01 = DHPAMT01 + dr2.Item("CREDIT") - dr2.Item("DEBIT")
            Loop

            DTX02 = EndDate01

            DY01I = DateDiff(DateInterval.Day, SDT001, DTX02) + 1

            ADINT01 = DHPAMT01 * rtint01 * DY01I / 36500
            ADINT03 = ADINT03 + ADINT01 + ADINT02
        End If
        dr2.Close() : cn2.Dispose()
        Return Math.Round(ADINT03, 0)
    End Function

#Region "SUGAR CONNCECTION"

    Public Function FillReader_Sug(ByVal Str As String, Optional ByVal dbnamxx As String = "") As SqlClient.SqlDataReader
        Try
            If dbnamxx = "" Then
                opencn_Sug(MASTER01)
            ElseIf dbnamxx <> "" Then
                opencn_Sug(dbnamxx)
            End If
            If cn_Sug.State = ConnectionState.Closed Then
                cn_Sug.Open()
            End If
            cm = New SqlClient.SqlCommand(Str, cn_Sug)
            cm.CommandTimeout = 450000
            dr = cm.ExecuteReader()
            Return dr
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function opencn_Sug(ByVal dbnmxx_Sug As String)
        Dim STR01 As String = ""

        If stringtype = "SQL" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & Server01_Sug & ";Initial Catalog=" & dbnmxx_Sug & ";Integrated Security=True"
            Else
                STR01 = "Data Source=" & Server01_Sug & ";Initial Catalog=" & dbnmxx_Sug & ";User ID=" & USERXX & "; pwd=" & Passxx_Sug
            End If
        ElseIf stringtype = "EXP" Then
            If Modetype = "WIN" Then
                STR01 = "Data Source=" & Server01_Sug & ";AttachDbFilename='" & dbnmxx_Sug & "';Integrated Security=True"
            Else
                STR01 = "Data Source=" & Server01_Sug & ";AttachDbFilename='" & dbnmxx_Sug & "';User ID=" & USERXX & "; pwd=" & Passxx_Sug
            End If
        End If
        cn_Sug = New SqlClient.SqlConnection(STR01)
        Return cn_Sug
    End Function
#End Region

End Module