Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Media
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Configuration
Imports System.Configuration.ConfigurationManager


Public Class FormSenha
    Private dv As DataView
    Private cm As CurrencyManager

    Private Sub FormSenha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not ConexaoGlobal() Then
            MessageBox.Show("Nao Esta Conectado, Entre em Contato com o Suporte")
        End If
        CarregaUsuarios()
        TextBoxUsuario.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If VerificaExistenciaUsuario() Then
            FormMain.ToolStripStatusLabel1.Text = "Usuário: " + TextBoxUsuario.Text.ToUpper
            FormMain.Show()
        Else
            Close()
        End If
        'FormMain.Close()
        'Me.Hide()
        'Me.Modal = Nothing '.Close()
        'FormSenha = Nothing
        'Me.Close()
    End Sub

    Public Function CarregaUsuarios() As Boolean
        Dim cSqlQuery As String = ""
        Dim DadosLidos As MySqlDataReader
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
    Function VerificaExistenciaUsuario() As Boolean
        Dim cSenhaConfere As String = ""
        Dim lVolta As Boolean = True
        If TextBoxUsuario.Text <> "" Then
            ' localiza o cliente
            Dim i As Integer = dv.Find(TextBoxUsuario.Text)
            If i < 0 Then
                ' nao foi localizado
                MessageBox.Show("Usuario Nao foi encontrado.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' reposiciona o registro no grid usando o CurrencyManager
                lVolta = False
            Else
                cm.Position = i
                cSenhaConfere = FormUteis.DGVCadUsuarios.Rows(i).Cells(15).Value
                If TextBoxSenha.Text.ToUpper <> cSenhaConfere.ToUpper Then
                    MessageBox.Show("Senha Inexistente.", "Password", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    'Me.Close()
                    lVolta = False
                End If
            End If
        Else
            MessageBox.Show("Usuario Não Pode Ser Vazio.", "Vazio", MessageBoxButtons.OK, MessageBoxIcon.Question)
            lVolta = False
            'Me.Close()
            'FormSenha.TextBoxUsuario.Focus()
            'Close()
        End If
        Return lVolta
    End Function
    Private Sub formsenha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{Tab}")
        End Select
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        FormCadastroUsuarios.ShowDialog()

        'FormCadastroUsuarios.Show()
        'FormCadastroUsuarios.MdiChildren()


    End Sub
End Class