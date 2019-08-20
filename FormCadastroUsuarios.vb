Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient

Public Class FormCadastroUsuarios
    Private dv As DataView
    Private cm As CurrencyManager
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub FormCadastroUsuarios_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{Tab}")
        End Select

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox16.Text = "" Then
            MessageBox.Show("Senha Não Pode Estar Vazia.", "Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        ElseIf TextBox17.Text = "" Then
            MessageBox.Show("Login Não Pode Estar Vazio.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        Else
            If Not VerificaExistenciaLogin() Then
                Return
            End If
            ' existencia da senha
            If Not VerificaExistenciaPassword() Then
                Return
            End If
            Dim ExecutaQuery As MySqlCommand
            Dim cmd As MySqlCommand = Conexao.CreateCommand
            Dim rs As MySqlDataReader
            Dim InstrucaoQuery As String = ""

            InstrucaoQuery = "Insert Into tbcadastrousuarios ("
            InstrucaoQuery += "Nome,"
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
            InstrucaoQuery += "login,"
            InstrucaoQuery += "senha)"
            InstrucaoQuery += " Values("
            InstrucaoQuery += "'" + TextBox1.Text + "',"
            InstrucaoQuery += "'" + TextBox2.Text + "',"
            InstrucaoQuery += "'" + TextBox3.Text + "',"
            InstrucaoQuery += "'" + TextBox4.Text + "',"
            InstrucaoQuery += "'" + TextBox5.Text + "',"
            InstrucaoQuery += "'" + TextBox6.Text + "',"
            InstrucaoQuery += "'" + TextBox7.Text + "',"
            InstrucaoQuery += "'" + ComboBox1.Text + "',"
            InstrucaoQuery += "'" + TextBox8.Text + "',"
            InstrucaoQuery += "'" + TextBox9.Text + "',"
            InstrucaoQuery += "'" + TextBox10.Text + "',"
            InstrucaoQuery += "'" + TextBox11.Text + "',"
            InstrucaoQuery += "'" + TextBox12.Text + "',"
            InstrucaoQuery += "'" + TextBox13.Text + "',"
            InstrucaoQuery += "'" + TextBox14.Text + "',"
            InstrucaoQuery += "'" + TextBox15.Text + "',"
            InstrucaoQuery += "'" + TextBox17.Text + "',"
            InstrucaoQuery += "'" + TextBox16.Text + "')"
            ExecutaQuery = New MySqlCommand(InstrucaoQuery, Conexao)
            rs = ExecutaQuery.ExecuteReader
            rs.Close()
        End If
    End Sub

    Public Function CarregaUsuarios() As Boolean
        Dim cSqlQuery As String = ""
        Dim Adaptador As New MySqlDataAdapter
        Dim ComandoSQL As New MySqlCommand
        cSqlQuery = "Select idTBCadastroUsuarios, Nome, Endereco, Complemento, Cep, Bairro, cidade, estado, cargo, cpf, rg, cnh, email, zap, login, senha From tbcadastrousuarios order by idTBCadastroUsuarios"
        If Not ConexaoGlobal() Then
            MessageBox.Show("Nao Esta Conectado")
        Else
            ' cria o DataAdapter e carrega os dados do cliente na tabela
            'Dim dv As DataView
            'Dim cm As CurrencyManager
            Dim da As New MySqlDataAdapter(cSqlQuery, Conexao)
            Dim dt As New DataTable
            Try
                da.Fill(dt)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            ' cria uma visao da visao padrao para a tabela
            dv = dt.DefaultView
            'ordena pelo codigo do cliente -CustomerID
            dv.Sort = "Login"
            ' vincula a visao ao grid
            FormUteis.DGVCadUsuarios.DataSource = dv
            ' obtem o CurrencyManager para o banco de dados
            cm = CType(FormUteis.DGVCadUsuarios.BindingContext(dv), CurrencyManager)
        End If
        Return True
    End Function

    Function VerificaExistenciaLogin() As Boolean
        Dim cSenhaConfere As String = ""
        Dim lVolta As Boolean = True
        Dim cmd As MySqlCommand = Conexao.CreateCommand
        If TextBox17.Text <> "" Then
            cmd.CommandText = "SELECT COUNT(*) FROM tbcadastrousuarios WHERE LOGIN  = '" & TextBox17.Text.ToUpper & "' Limit 1"
            If cmd.ExecuteScalar > 0 Then
                MessageBox.Show("Usuario Já Cadastrado.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lVolta = False
            End If
        End If
        Return lVolta
    End Function
    Function VerificaExistenciaPassword() As Boolean
        Dim cSenhaConfere As String = ""
        Dim lVolta As Boolean = True
        Dim cmd As MySqlCommand = Conexao.CreateCommand
        If TextBox16.Text <> "" Then
            ' localiza o cliente
            cmd.CommandText = "SELECT COUNT(*) FROM tbcadastrousuarios WHERE SENHA  = '" & TextBox16.Text.ToUpper & "' Limit 1"
            If cmd.ExecuteScalar > 0 Then
                MessageBox.Show("Senha Já Cadastrada.", "Senha", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lVolta = False
            End If
        End If
        Return lVolta
    End Function

    Private Sub FormCadastroUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregaUsuarios()
    End Sub
End Class