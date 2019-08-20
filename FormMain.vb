Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Media
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Configuration
Imports System.Configuration.ConfigurationManager

Module VariasFuncoes
    Public cstringdeconexao As String
    Public cErroPublico As String
    Public cTabuada As String = "02|03|04|06|08|09|10|12|14|15|16|18|20|21|24|"
    Public Conexao As New MySqlConnection
    Public cAmostra As String = "Amos"
    Public aTBBakLigacaoCabeca As New List(Of Tuple(Of String, String, String, String, String))
    Public aDGVTB12AntesDepois As New List(Of Tuple(Of String, String, String, String, String, String, String))
    Public aDGVTBNDAntesDepois As New List(Of Tuple(Of String, String, String, String))
    Public aDGVTB12Futuro As New List(Of Tuple(Of String, String, String, String, String, String, String))
    Public aDGVTB12FuturoDetailP As New List(Of Tuple(Of String, String, String))
    Public aDGVTB12FuturoDetailS As New List(Of Tuple(Of String, String, String))
    Public aDGVTB12FuturoDetailR As New List(Of Tuple(Of String, String, String))
    Public aDGVTBProximos As New List(Of Tuple(Of String, String, String))
    Public aTBBakLigacaoCorpo As New List(Of Tuple(Of String, String))

    Public aDGVErrosComuns As New List(Of Tuple(Of String, String))
    Public aDGVTBComuns As New List(Of Tuple(Of String, String, String))
    Public aDGVTBAnal12 As New List(Of Tuple(Of String, String, String))
    Public aDGVTBAnalND As New List(Of Tuple(Of String, String, String))
    Public aDGVTBAnal12s As New List(Of Tuple(Of String, String, String))
    Public aDGVTBAnalNDs As New List(Of Tuple(Of String, String, String))
    Public aDGVIDPrimeiraParte As New List(Of Tuple(Of String, String, String))
    Public aDGVIDNaoDeram As New List(Of Tuple(Of String, String, String, String))
    Public aTBTotalNoAnt12eND As New List(Of Tuple(Of String, String, String))
    Public aTBTotalNoAnt12eNDConcs As New List(Of Tuple(Of String, String, String))
    Public aTBComparaND As New List(Of Tuple(Of String, String, String, String, String))
    Public aTBComparaNDx12 As New List(Of Tuple(Of String, String, String))
    Public aTBFuturoNaoDeram As New List(Of Tuple(Of String, String, String))
    Public aTBCalculaND12Pontos As New List(Of Tuple(Of String, String, String, String))
    Public aDGVPoeOrdem As New List(Of Tuple(Of String, String, String, String, String))
    Public aDGVAuxiliar As New List(Of Tuple(Of String, String, String, String))
    Public aDGVSaidasND As New List(Of Tuple(Of String, String, String, String))
    Public aDGVSaidas12 As New List(Of Tuple(Of String, String, String, String))
    Public aDataGridViewBasedeCalculoLink As New List(Of Tuple(Of String, String, String, String))
    Public aTBBasedeCalculo As New List(Of Tuple(Of String, String, String))
    Public aTBBasedeCalculoLink As New List(Of Tuple(Of String, String, String, String))
    Public aTBDiferencas As New List(Of Tuple(Of String, String, String, String))
    Public aTBDiferencasMasters As New List(Of Tuple(Of String, String, String, String))
    Public aTBDiferencasMasters12 As New List(Of Tuple(Of String, String, String, String))
    Public aDataGridViewTB12PontosLink As New List(Of Tuple(Of String, String, String, String))
    Public aDataGridViewDifNDLink As New List(Of Tuple(Of String, String))
    Public aDataGridViewDif12Link As New List(Of Tuple(Of String, String))
    Public aTBListaCalculoBolas As New List(Of Tuple(Of String))
    Public aTBSorteComplementar As New List(Of Tuple(Of String, Integer))
    Public aTBSorteComplementarNumeros As New List(Of Tuple(Of String))
    Public aDataGridViewTBnDiferencaGeradaLink As New List(Of Tuple(Of String, String))
    Public aDataGridViewTB12PontosGeradaLink As New List(Of Tuple(Of String, String))
    Public aDataGridView12PontosLink As New List(Of Tuple(Of String, String, String, String))
    Public aDataGridViewNaoDeramLink As New List(Of Tuple(Of String, String, String, String))
    Public aDataGridViewDataPrevisaoNDLink As New List(Of Tuple(Of String, String, String, String))
    Public aDataGridViewTBCopias12Link As New List(Of Tuple(Of String, String, String, String))
    Public aDataGridViewTBCopiasNDLink As New List(Of Tuple(Of String, String, String, String))
    Public aDataGridViewHerdeirosND As New List(Of Tuple(Of String, String, String, String))
    Public aDataGridViewHerdeiros12 As New List(Of Tuple(Of String, String, String, String))
    Public aDataPrevisaoND As New List(Of Tuple(Of String, String, String, String))
    Public aDataPrevisao12 As New List(Of Tuple(Of String, String, String, String))
    Public aDataPrevisaoNDNow As New List(Of Tuple(Of String, String, String, String))
    Public aDataPrevisao12Now As New List(Of Tuple(Of String, String, String, String))
    Public aTBConcursosReferencia As New List(Of Tuple(Of String, String, String, String, String))
    Public aTBConcursosReferencia11 As New List(Of Tuple(Of String, String, String, String, String))
    Public aCruzaTBNaoDeramGeradosXUltimoTextobolas As New List(Of Tuple(Of String, String, String, String))
    Public aCruzaTB12PontosGeradosXUltimoTextobolas As New List(Of Tuple(Of String, String, String, String))
    Public aTBMergeNDcom12FilhosGLink As New List(Of Tuple(Of String, String, String, String))
    Public aDGVMerge12NDFilhosLink As New List(Of Tuple(Of String, String, String, String, String))
    Public aCruza12xND As New List(Of Tuple(Of String, String, String, String))
    Public aTBMergeNDcom12Link As New List(Of Tuple(Of String, String))
    Public aBolinhasDeram As New List(Of Tuple(Of String, String))
    Public aBolinhasNaoDeram As New List(Of Tuple(Of String, String))
    Public aTBMenoresValoresLink As New List(Of Tuple(Of String, Integer))
    Public aDataGridViewTBBombaPrimeiraParteLink As New List(Of Tuple(Of String, String))
    Public aRoda01a25(,) As Integer = {{0, 0}}
    Public aRoda01a25_1(,) As Integer = {{0, 0}}
    Public aTBMergeNDcom12 As New List(Of Tuple(Of String, String, String, String, String, String, String))
    Public aDGVSaidas As New List(Of Tuple(Of String, String, String, String, String, String, String))
    Public aDGVSaidas2 As New List(Of Tuple(Of String, String, String, String))
    Public aTBMergeNDcom12Filhos As New List(Of Tuple(Of String, String, String, String))
    Public aTBTodosTB12Pontos As New List(Of Tuple(Of String, String))
    Public aDataGridViewErros As New List(Of Tuple(Of String, String, String, String))
    Public aDataGridViewErrosResumo As New List(Of Tuple(Of String, String))
    Public aDataGridViewAceitos As New List(Of Tuple(Of String, String, String))
    Public aTBTodos As Array
    Public aTBBolasBasedeCalculo As Array
    Public aDGVEntreBaseCalculo As New List(Of Tuple(Of String, String, String, String, String, String, String))
    Public aTBTotalnoAnt As New List(Of Tuple(Of String, String, String))
    Public aTBTotalnoAntReferidos As New List(Of Tuple(Of String, String, String))
    Public aTB12Segue42Atual As New List(Of Tuple(Of String, String, String, String, String, String))
    Public aTB12Segue45Atual As New List(Of Tuple(Of String, String, String, String, String, String))
    Public aTBNDSegue42Atual As New List(Of Tuple(Of String, String, String, String, String, String))
    Public aTBNDSegue45Atual As New List(Of Tuple(Of String, String, String, String, String, String))
    Public aTBSegueDeduzindoTodosAtual As New List(Of Tuple(Of String, String, String, String, String, String))

    Public Function ConexaoGlobal() As Boolean
        Dim Conectado As Boolean = True
        Try
            cstringdeconexao = ("server=localhost;user id=root;password=sistema;persistsecurityinfo=True;database=dbMAX")
            Conexao = New MySqlConnection(cstringdeconexao)
            Conexao.Open()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            Conectado = False
        End Try
        Return Conectado
    End Function
    Public Sub Desconectar()
        Conexao.Close()
    End Sub


End Module

Public Class FormMain
    Private dv As DataView
    Private cm As CurrencyManager
    Dim ContadorAguarde As Byte = 1
    Dim EstadoAguarde As Byte = 0

    Public Function EhPar(ByVal nVal As Integer) As Boolean
        Dim lVerdade As Boolean = False
        If nVal Mod 2 = 0 Then
            lVerdade = True
        End If
        Return lVerdade
    End Function
    Public Function EhPrimo(ByVal nVal As Integer) As Boolean
        Dim lVerdade As Boolean = True
        Dim n2 As Integer
        Dim nI As Integer
        Dim nJ As Integer
        n2 = Int(nVal / 2)
        For nI = 2 To n2
            For nJ = nI To n2
                If ((nI * nJ) = nVal) Then
                    lVerdade = False
                End If
            Next
        Next
        Return lVerdade
    End Function



    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not ConexaoGlobal() Then
            MessageBox.Show("Nao Esta Conectado, Entre em Contato com o Suporte")
        End If
        Dim cSqlQuery As String = ""
        Dim DadosLidos As MySqlDataReader
        Dim Adaptador As New MySqlDataAdapter
        Dim ComandoSQL As New MySqlCommand

        cSqlQuery = "Select idTBCadastroUsuarios, Nome, Endereco, Complemento, Cep, Bairro, cidade, estado, cargo, cpf, rg, cnh, email, zap, login, senha From tbcadastrousuarios order by idTBCadastroUsuarios"

        ComandoSQL.CommandText = cSqlQuery
        ComandoSQL.Connection = Conexao
        Adaptador.SelectCommand = ComandoSQL
        DadosLidos = ComandoSQL.ExecuteReader
        FormSenha.Hide()
        'FormLogin.Show()
        'FormSenha.Show()
        'Me.Hide()

        'Application.DoEvents()
        'Application.Exit() '.DoEvents()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FormMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormSenha.Close()
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVClientes.CellContentClick

    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ExecutaQuery As MySqlCommand
        Dim cmd As MySqlCommand = Conexao.CreateCommand
        Dim rs As MySqlDataReader
        Dim InstrucaoQuery As String = ""

        GroupBoxBotoesInclusaoClientes1.Visible = True
        GroupBoxBotoesManutencaoClientes1.Visible = False
        TextBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox1.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox1.Focus()


        'If Not ConexaoGlobal() Then
        '    MessageBox.Show("Nao Esta Conectado, Entre em Contato com o Suporte")
        'Else
        '    InstrucaoQuery = "Insert Into TBCadastroClientes ("
        '    InstrucaoQuery += "Nome,"
        '    InstrucaoQuery += "Sexo,"
        '    InstrucaoQuery += "Pessoa,"
        '    InstrucaoQuery += "Endereco,"
        '    InstrucaoQuery += "Complemento,"
        '    InstrucaoQuery += "numero,"
        '    InstrucaoQuery += "Bairro,"
        '    InstrucaoQuery += "Cep,"
        '    InstrucaoQuery += "cidade,"
        '    InstrucaoQuery += "estado,"
        '    InstrucaoQuery += "email,"
        '    InstrucaoQuery += "celular1,"
        '    InstrucaoQuery += "celular2,"
        '    InstrucaoQuery += "fixo,"
        '    InstrucaoQuery += "recados,"
        '    InstrucaoQuery += "rg,"
        '    InstrucaoQuery += "cpf,"
        '    InstrucaoQuery += "cnh,"
        '    InstrucaoQuery += "ie,"
        '    InstrucaoQuery += "cnpj)"
        '    InstrucaoQuery += " Values("
        '    InstrucaoQuery += "'" + TextBox1.Text + "',"
        '    InstrucaoQuery += "'" + ComboBox2.Text + "',"
        '    InstrucaoQuery += "'" + ComboBox3.Text + "',"
        '    InstrucaoQuery += "'" + TextBox2.Text + "',"
        '    InstrucaoQuery += "'" + TextBox3.Text + "',"
        '    InstrucaoQuery += "'" + TextBox4.Text + "',"
        '    InstrucaoQuery += "'" + TextBox5.Text + "',"
        '    InstrucaoQuery += "'" + TextBox6.Text + "',"
        '    InstrucaoQuery += "'" + TextBox7.Text + "',"
        '    InstrucaoQuery += "'" + ComboBox1.Text + "',"
        '    InstrucaoQuery += "'" + TextBox8.Text + "',"
        '    InstrucaoQuery += "'" + TextBox9.Text + "',"
        '    InstrucaoQuery += "'" + TextBox10.Text + "',"
        '    InstrucaoQuery += "'" + TextBox11.Text + "',"
        '    InstrucaoQuery += "'" + TextBox12.Text + "',"
        '    InstrucaoQuery += "'" + TextBox13.Text + "',"
        '    InstrucaoQuery += "'" + TextBox14.Text + "',"
        '    InstrucaoQuery += "'" + TextBox15.Text + "',"
        '    InstrucaoQuery += "'" + TextBox16.Text + "',"
        '    InstrucaoQuery += "'" + TextBox17.Text + "')"
        '    ExecutaQuery = New MySqlCommand(InstrucaoQuery, Conexao)
        '    rs = ExecutaQuery.ExecuteReader
        '    rs.Close()
        'End If
    End Sub

    Private Sub FormMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{Tab}")
        End Select

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ExecutaQuery As MySqlCommand
        Dim cmd As MySqlCommand = Conexao.CreateCommand
        Dim rs As MySqlDataReader
        Dim InstrucaoQuery As String = ""
        If Not ConexaoGlobal() Then
            MessageBox.Show("Nao Esta Conectado, Entre em Contato com o Suporte")
        Else
            InstrucaoQuery = "Insert Into TBCadastroClientes ("
            InstrucaoQuery += "Nome,"
            InstrucaoQuery += "Sexo,"
            InstrucaoQuery += "Pessoa,"
            InstrucaoQuery += "Endereco,"
            InstrucaoQuery += "Complemento,"
            InstrucaoQuery += "numero,"
            InstrucaoQuery += "Bairro,"
            InstrucaoQuery += "Cep,"
            InstrucaoQuery += "cidade,"
            InstrucaoQuery += "estado,"
            InstrucaoQuery += "email,"
            InstrucaoQuery += "celular1,"
            InstrucaoQuery += "celular2,"
            InstrucaoQuery += "fixo,"
            InstrucaoQuery += "recados,"
            InstrucaoQuery += "rg,"
            InstrucaoQuery += "cpf,"
            InstrucaoQuery += "cnh,"
            InstrucaoQuery += "ie,"
            InstrucaoQuery += "cnpj)"
            InstrucaoQuery += " Values("
            InstrucaoQuery += "'" + TextBox1.Text.ToUpper + "',"
            InstrucaoQuery += "'" + ComboBox2.Text.ToUpper + "',"
            InstrucaoQuery += "'" + ComboBox3.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox2.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox3.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox4.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox5.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox6.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox7.Text.ToUpper + "',"
            InstrucaoQuery += "'" + ComboBox1.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox8.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox9.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox10.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox11.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox12.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox13.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox14.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox15.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox16.Text.ToUpper + "',"
            InstrucaoQuery += "'" + TextBox17.Text.ToUpper + "')"
            ExecutaQuery = New MySqlCommand(InstrucaoQuery, Conexao)
            rs = ExecutaQuery.ExecuteReader
            rs.Close()
        End If
        GroupBoxBotoesInclusaoClientes1.Visible = False
        GroupBoxBotoesManutencaoClientes1.Visible = True
        F01CLI()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBoxBotoesInclusaoClientes1.Visible = False
        GroupBoxBotoesManutencaoClientes1.Visible = True
        F01CLI()
    End Sub

    Private Sub TabTodas_Enter(sender As Object, e As EventArgs) Handles TabTodas.Enter
        If TabTodas.SelectedTab.Text = "Clientes" Then
            ToolStripStatusLabel2.Text = "Clientes"
            F01CLI()
        ElseIf TabTodas.SelectedTab.Text = "Fornecedores" Then
            ToolStripStatusLabel2.Text = "Fornecedores"
        End If
    End Sub

    Private Sub TabTodas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabTodas.SelectedIndexChanged
        If TabTodas.SelectedTab.Text = "Clientes" Then
            ToolStripStatusLabel2.Text = "Usando Clientes"
        ElseIf TabTodas.SelectedTab.Text = "Fornecedores" Then
            ToolStripStatusLabel2.Text = "Usando Fornecedores"
        ElseIf TabTodas.SelectedTab.Text = "Receber" Then
            ToolStripStatusLabel2.Text = "Usando Receber"
        ElseIf TabTodas.SelectedTab.Text = "Pagar" Then
            ToolStripStatusLabel2.Text = "Usando Pagar"
        Else
            ToolStripStatusLabel2.Text = "Em Testes"
        End If
    End Sub
    Function F01CLI() As Boolean
        If Not ConexaoGlobal() Then
            MessageBox.Show("Nao Esta Conectado")
        Else
            Dim ExecutaQuery As MySqlCommand
            Dim cRegistrosLidos As MySqlDataReader
            Dim InstrucaoQuery As String = "Select idTBCadastroClientes,
                                            nome,
                                            Sexo,
                                            Pessoa, 
                                            Endereco,
                                            Complemento, 
                                            numero,
                                            Bairro,
                                            Cep,
                                            cidade,
                                            estado,
                                            email, 
                                            celular1,
                                            celular2,
                                            fixo,
                                            recados,
                                            rg,
                                            cpf,
                                            cnh,
                                            ie, 
                                            cnpj
                                            FROM TBCadastroClientes ORDER BY nome"
            ExecutaQuery = New MySqlCommand(InstrucaoQuery, Conexao)
            cRegistrosLidos = ExecutaQuery.ExecuteReader
            'Dim nReg As Integer = 0
            DGVClientes.Rows.Clear()
            While cRegistrosLidos.Read()
                DGVClientes.Rows.Add(cRegistrosLidos.Item(0).ToString.PadLeft(4, "0000"),
                                            cRegistrosLidos.Item(1),
                                            cRegistrosLidos.Item(2),
                                            cRegistrosLidos.Item(3),
                                            cRegistrosLidos.Item(4),
                                            cRegistrosLidos.Item(5),
                                            cRegistrosLidos.Item(6),
                                            cRegistrosLidos.Item(7),
                                            cRegistrosLidos.Item(8),
                                            cRegistrosLidos.Item(9),
                                            cRegistrosLidos.Item(10),
                                            cRegistrosLidos.Item(11),
                                            cRegistrosLidos.Item(12),
                                            cRegistrosLidos.Item(13),
                                            cRegistrosLidos.Item(14),
                                            cRegistrosLidos.Item(15),
                                            cRegistrosLidos.Item(16),
                                            cRegistrosLidos.Item(17),
                                            cRegistrosLidos.Item(18),
                                            cRegistrosLidos.Item(19),
                                            cRegistrosLidos.Item(20))
            End While
            cRegistrosLidos.Close()
            ExecutaQuery.Dispose()
            TextBox1.Text = DGVClientes.Rows(0).Cells(1).Value
            ComboBox2.Text = DGVClientes.Rows(0).Cells(2).Value
            ComboBox3.Text = DGVClientes.Rows(0).Cells(3).Value
            TextBox2.Text = DGVClientes.Rows(0).Cells(4).Value
            TextBox3.Text = DGVClientes.Rows(0).Cells(5).Value
            TextBox4.Text = DGVClientes.Rows(0).Cells(6).Value
            TextBox5.Text = DGVClientes.Rows(0).Cells(7).Value
            TextBox6.Text = DGVClientes.Rows(0).Cells(8).Value
            TextBox7.Text = DGVClientes.Rows(0).Cells(9).Value
            ComboBox1.Text = DGVClientes.Rows(0).Cells(10).Value
            TextBox8.Text = DGVClientes.Rows(0).Cells(11).Value
            TextBox9.Text = DGVClientes.Rows(0).Cells(12).Value
            TextBox10.Text = DGVClientes.Rows(0).Cells(13).Value
            TextBox11.Text = DGVClientes.Rows(0).Cells(14).Value
            TextBox12.Text = DGVClientes.Rows(0).Cells(15).Value
            TextBox13.Text = DGVClientes.Rows(0).Cells(16).Value
            TextBox14.Text = DGVClientes.Rows(0).Cells(17).Value
            TextBox15.Text = DGVClientes.Rows(0).Cells(18).Value
            TextBox16.Text = DGVClientes.Rows(0).Cells(19).Value
            TextBox17.Text = DGVClientes.Rows(0).Cells(20).Value
        End If
        Return True
    End Function

    Private Sub DGVClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVClientes.CellClick
        Dim i, j As Integer
        i = e.RowIndex
        j = e.ColumnIndex
        TextBox1.Text = DGVClientes.Rows(i).Cells(1).Value
        ComboBox2.Text = DGVClientes.Rows(i).Cells(2).Value
        ComboBox3.Text = DGVClientes.Rows(i).Cells(3).Value
        TextBox2.Text = DGVClientes.Rows(i).Cells(4).Value
        TextBox3.Text = DGVClientes.Rows(i).Cells(5).Value
        TextBox4.Text = DGVClientes.Rows(i).Cells(6).Value
        TextBox5.Text = DGVClientes.Rows(i).Cells(7).Value
        TextBox6.Text = DGVClientes.Rows(i).Cells(8).Value
        TextBox7.Text = DGVClientes.Rows(i).Cells(9).Value
        ComboBox1.Text = DGVClientes.Rows(i).Cells(10).Value
        TextBox8.Text = DGVClientes.Rows(i).Cells(11).Value
        TextBox9.Text = DGVClientes.Rows(i).Cells(12).Value
        TextBox10.Text = DGVClientes.Rows(i).Cells(13).Value
        TextBox11.Text = DGVClientes.Rows(i).Cells(14).Value
        TextBox12.Text = DGVClientes.Rows(i).Cells(15).Value
        TextBox13.Text = DGVClientes.Rows(i).Cells(16).Value
        TextBox14.Text = DGVClientes.Rows(i).Cells(17).Value
        TextBox15.Text = DGVClientes.Rows(i).Cells(18).Value
        TextBox16.Text = DGVClientes.Rows(i).Cells(19).Value
        TextBox17.Text = DGVClientes.Rows(i).Cells(20).Value


        'TextBox1.Text = DGVClientes.Item(i, 1).Value
        'ComboBox2.Text = DGVClientes.Item(i, 2).Value
        'ComboBox3.Text = DGVClientes.Item(i, 3).Value
        'TextBox2.Text = DGVClientes.Item(i, 4).Value
        'TextBox3.Text = DGVClientes.Item(i, 5).Value
        'TextBox4.Text = DGVClientes.Item(i, 6).Value
        'TextBox5.Text = DGVClientes.Item(i, 7).Value
        'TextBox6.Text = DGVClientes.Item(i, 8).Value
        'TextBox7.Text = DGVClientes.Item(i, 9).Value
        'ComboBox1.Text = DGVClientes.Item(i, 10).Value
        'TextBox8.Text = DGVClientes.Item(i, 11).Value
        'TextBox9.Text = DGVClientes.Item(i, 12).Value
        'TextBox10.Text = DGVClientes.Item(i, 13).Value
        'TextBox11.Text = DGVClientes.Item(i, 14).Value
        'TextBox12.Text = DGVClientes.Item(i, 15).Value
        'TextBox13.Text = DGVClientes.Item(i, 16).Value
        'TextBox14.Text = DGVClientes.Item(i, 17).Value
        'TextBox15.Text = DGVClientes.Item(i, 18).Value
        'TextBox16.Text = DGVClientes.Item(i, 19).Value
        'TextBox17.Text = DGVClientes.Item(i, 20).Value

    End Sub
End Class
