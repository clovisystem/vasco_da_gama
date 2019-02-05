Imports System
Imports System.Object
Imports System.Windows.Forms.Control

Imports System.Windows.Forms.WebBrowser
Imports System.Windows.Forms.WebBrowserBase
Imports System.ComponentModel.Component

Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Text.RegularExpressions.MatchCollection

Imports System.Windows.Forms.AutoCompleteMode
Imports System.Data.OleDb
Imports System.Data
Imports System.Data.DataTableReader
Imports System.Windows.Forms.ListView






Public Class Form1


    Private Sub TextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.Focus()
        TextBox1.SelectAll()
        TextBox1.Select()
    End Sub

    Private Sub TextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.Focus()
        TextBox1.SelectAll()
        TextBox1.Select()
    End Sub

    'Private Sub TextBox1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'Me.TextBox1.Text = ""

    'End Sub
    Private wc As System.Net.WebClient
    Private Sub wc_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) 'Handles wc.DownloadFileCompleted


        'Código para iniciar o download e assinar os eventos:
        wc = New System.Net.WebClient()
        Dim uri As New Uri("http://")
        TabControl1.TabPages.Add(TabPage1)
        TabControl1.Visible = True



        wc.DownloadFileAsync(uri, "C:\Documents and Settings\All Users\Download")

        'Assina eventos
        AddHandler wc.DownloadProgressChanged, AddressOf Me.DownloadProgressChangedCallback
        AddHandler wc.DownloadFileCompleted, AddressOf Me.DownloadFileCompletedCallback

        'Note que com o método DownloadFileAsync() você deve passar o endereço do arquivo para um objeto Uri antes, o método não aceita o endereço diretamente no formato de string.

        'Finalmente os métodos dos eventos:
    End Sub
    Private Sub DownloadProgressChangedCallback(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs)
        ' Atualiza ProgressBar
        ProgressBar1.Value = e.ProgressPercentage
    End Sub
    Private Sub DownloadFileCompletedCallback(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        ' Remove eventos
        RemoveHandler wc.DownloadProgressChanged, AddressOf Me.DownloadProgressChangedCallback
        RemoveHandler wc.DownloadFileCompleted, AddressOf Me.DownloadFileCompletedCallback
        MessageBox.Show("Download completo.")
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)
        ProgressBar1.Value = 0
        Me.TextBox1.Text = WebBrowser1.Url.ToString()
    End Sub



    Private Sub ConfiguraçõesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguraçõesToolStripMenuItem.Click
        Form2.Show()

    End Sub


    Private Sub SairToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairToolStripMenuItem.Click
        Me.Close()
        End
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Form3.Show()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' LISTVIEW PREENCHIMENTO
        ListView1.BackColor = Color.Azure
        ListView1.ForeColor = Color.White

        Dim conexao As New OleDbConnection
        conexao.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0; data source=" & Application.StartupPath & "\VascoDaGama.mdb;"

        Dim daLinks = New OleDbDataAdapter("SELECT * FROM favoritos ORDER BY id DESC;", conexao)

        'Dim btnDeleta As New Button
        'btnDeleta.BackColor = Color.Red
        'btnDeleta.Image = Image.FromFile("Images/Deletar.png")

        Dim ds = New DataSet
        daLinks.Fill(ds, "Favoritos")
        For i = 0 To ds.Tables("Favoritos").Rows.Count - 1
          
            Dim item0 As ListViewItem = ListView1.Items.Add(ds.Tables("Favoritos").Rows(i)("url"), 0)
            'Dim item1 As ListViewItem = ListView1.Items.Add(ds.Tables("Favoritos").Rows(i)("id"), 1)
            item0.BackColor = Color.Aqua
            item0.Font = New Font("Tahoma", 13)

            Dim ImageList1 As New ImageList()

            ImageList1.Images.Add(Bitmap.FromFile(Application.StartupPath & "\Images\deletar.png"))
            ListView1.SmallImageList = ImageList1

           
        Next
        ' LISTVIEW PREENCHIMENTO





        Me.BackColor = Color.Navy
        WebBrowser1.ScriptErrorsSuppressed = 1
        TabPage1.BackColor = Color.Navy
        'TabPage.BorderColor = Color.Navy
        MenuStrip1.ForeColor = Color.White
        MenuStrip1.BackColor = Color.DarkBlue
        SairToolStripMenuItem.ForeColor = Color.White
        SairToolStripMenuItem.BackColor = Color.MidnightBlue
        ConfiguraçõesToolStripMenuItem.ForeColor = Color.White
        ConfiguraçõesToolStripMenuItem.BackColor = Color.MidnightBlue

        ToolStripMenuItem2.ForeColor = Color.White
        ToolStripMenuItem3.ForeColor = Color.White
        ToolStripMenuItem4.ForeColor = Color.White

        ToolStripMenuItem2.BackColor = Color.Transparent
        ToolStripMenuItem3.BackColor = Color.Transparent
        ToolStripMenuItem4.BackColor = Color.MidnightBlue

        'Me.FormBorderStyle = None


        'Me.TextBox1.Text = WebBrowser1.Url
        'Me.TextBox1.Text = CType(TabPage1.Select.Controls.Item(0), WebBrowser).LocationURL
        'Me.TextBox1.Text = e.Url.ToString
        If TextBox1.Text <> "" Or TextBox1.Text <> "Digite o endereço aqui..." Then
            'btnVoltar.IsPressed Or btnAvancar.IsPressed
            Button4.Enabled = True
            Button5.Enabled = True
        Else
            Button4.Enabled = False
            Button5.Enabled = False
        End If

        'Informamos o modo do Complemento
        TextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        'Informamos que a consulta será customizada
        TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
        'Criamos a lista que será consultada
        Dim lista As New AutoCompleteStringCollection
        lista.Add("google.com")
        lista.Add("facebook.com")
        lista.Add("yahoo.com")
        lista.Add("gmail.com")
        'Informamos a fonts customizada para a consulta
        TextBox1.AutoCompleteCustomSource = lista



        'Informamos o modo do Complemento
        'txtEndereco.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        'Informamos que a consulta será customizada
        'txtEndereco.AutoCompleteSource = AutoCompleteSource.CustomSource

        'Criamos a lista que será consultada
        'Dim lista As New AutoCompleteStringCollection
        'lista.Add("www.google.com")
        'lista.Add("www.facebook.com")
        'lista.Add("www.br.yahoo.com")
        'lista.Add("www.gmail.com")


        'txtEndereco.AutoCompleteCustomSource = lista

        'Form4.Visible = False

    End Sub

    Private Sub WebBrowser1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs)
        If e.CurrentProgress * 100 / e.MaximumProgress > 1 Then
            ProgressBar1.Value = e.CurrentProgress * 100 / e.MaximumProgress
        End If
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If e.KeyCode = Keys.Enter Then
        'Me.WebBrowser1.Navigate(TextBox1.Text)
        'If Not String.IsNullOrEmpty(Me.TextBox1.Text) Then
        'If TextBox1.Text.Contains("http://") Then
        'Me.WebBrowser1.Navigate(New Uri(Me.TextBox1.Text))

        'Else : TextBox1.Text = "http://" & TextBox1.Text.Trim
        'Me.WebBrowser1.Navigate(New Uri(Me.TextBox1.Text))


        'End If
        'End If
        'End If

    End Sub


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Dim texto As String = "."


        If Not TextBox1.Text.Contains(texto) Then
            Me.WebBrowser1.Navigate("https://www.google.com.br/search?q=" & TextBox1.Text)
        Else
            Me.WebBrowser1.Navigate(Me.TextBox1.Text.Trim)
        End If



        'End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try

            WebBrowser1.GoForward()

        Catch ex As Exception

            Beep()
            'MsgBox("Não Permitido!" & vbCrLf & ex.Message)
            MessageBox.Show("Não Permitido!" & vbCrLf & ex.Message)
            'Finally
            'MsgBox("Não Permitido!")
            'MessageBox.Show("Não Permitido!", "Vasco da Gama")

            'WebBrowser1.GoForward()

        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try

            WebBrowser1.GoBack()

        Catch ex As Exception

            Beep()
            'MsgBox("Não Permitido!" & vbCrLf & ex.Message)
            MessageBox.Show("Não Permitido!" & vbCrLf & ex.Message)
            'Finally
            'MsgBox("Não Permitido!")
            'MessageBox.Show("Não Permitido!", "Vasco da Gama")
            'WebBrowser1.GoBack()
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.WebBrowser1.Refresh()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.WebBrowser1.Navigate("http://www.google.com")
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim Form1 As New Form1
        'Form1.Show()

        Dim NovoControle As TabControl
        Dim NovaPagina As TabPage
        Dim Navegador As WebBrowser
        Dim BotaoExibe As New Button
        NovaPagina = Me.TabPage1
        NovoControle = Me.TabControl1
        Navegador = Me.WebBrowser1
        BotaoExibe.Text = "Nova guia"
        BotaoExibe.BackColor = Color.White
        BotaoExibe.Size = New Point(88, 24)
        BotaoExibe.Location = New Point(1238, 6)
        
        'NovaPagina.Size = New Point(1256, 856)
        'NovaPagina.Location = New Point(3, 3)

        'NovaPagina.Controls.Add(Navegador)
        'NovoControle.Controls.Add(NovaPagina)
        
        'Me.Controls.Add(NovoControle)
        Panel1.Controls.Add(BotaoExibe)
        AddHandler BotaoExibe.Click, AddressOf Botao_Exibe

    End Sub

    Sub Botao_Exibe(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim Form1 As New Form1
        Form1.Show()
    End Sub

    Sub BOTAO_ADD(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim form As New TabPage
        Dim net As New WebBrowser
        Dim menu As New MenuStrip
        Dim ToolStripMenuItem1 As New ToolStripMenuItem
        Dim ToolStripMenuItem2 As New ToolStripMenuItem
        Dim ConfiguraçõesToolStripMenuItem As New ToolStripMenuItem
        Dim SairToolStripMenuItem As New ToolStripMenuItem
        Dim ToolStripMenuItem4 As New ToolStripMenuItem
        Dim painel As New Panel
        Dim botao1 As New Button
        Dim botao2 As New Button
        Dim botao3 As New Button
        Dim botao4 As New Button
        Dim botao5 As New Button
        Dim botao6 As New Button
        Dim Caixa As New TextBox
        Dim BarraProgresso As New ProgressBar
        Dim form2 As New Form2
        Dim texto As New TextBox

        texto.Focus()
        texto.SelectAll()
        texto.Select()
        AddHandler texto.Click, AddressOf TEXTO_CLICK

        'net.ScriptErrorsSuppressed = 1
        'net.Location = New Point(3, 70)
        'net.Size = New Point(1250, 1050)
        'Net.Dock = DockStyle.Fill
        'painel.Location = New Point(3, 26)
        'painel.BackColor = Color.Black
        'painel.Size = New Point(1250, 46)


        botao1.Size = New Point(40, 30)
        botao1.Location = New Point(96, 3)
        botao1.BackgroundImage = Image.FromFile("D:\PROJETOS\SISTEMAS\VB.NET\Vasco Da Gama - NOVO - Com Guias\Vasco Da Gama\Images\adição.png")
        botao1.BackgroundImageLayout = ImageLayout.Stretch
        botao1.FlatStyle = FlatStyle.Standard
        botao1.BackColor = Color.LightGray
        AddHandler botao1.Click, AddressOf BOTAO_ADD

        botao2.Size = New Point(40, 30)
        botao2.Location = New Point(152, 3)
        botao2.BackgroundImage = Image.FromFile("D:\PROJETOS\SISTEMAS\VB.NET\Vasco Da Gama - NOVO - Com Guias\Vasco Da Gama\Images\home-57.png")
        botao2.BackgroundImageLayout = ImageLayout.Stretch
        botao2.FlatStyle = FlatStyle.Standard
        botao2.BackColor = Color.LightGray
        AddHandler botao2.Click, AddressOf BOTAO_INICIAL

        botao3.Size = New Point(40, 30)
        botao3.Location = New Point(208, 3)
        botao3.BackgroundImage = Image.FromFile("D:\PROJETOS\SISTEMAS\VB.NET\Vasco Da Gama - NOVO - Com Guias\Vasco Da Gama\Images\Botoes_51__refresh_48.png")
        botao3.BackgroundImageLayout = ImageLayout.Stretch
        botao3.FlatStyle = FlatStyle.Standard
        botao3.BackColor = Color.LightGray
        AddHandler botao3.Click, AddressOf BOTAO_ATUALIZAR

        botao4.Size = New Point(40, 30)
        botao4.Location = New Point(264, 3)
        botao4.BackgroundImage = Image.FromFile("D:\PROJETOS\SISTEMAS\VB.NET\Vasco Da Gama - NOVO - Com Guias\Vasco Da Gama\Images\setas_2551_Fleche_Gauche.png")
        botao4.BackgroundImageLayout = ImageLayout.Stretch
        botao4.FlatStyle = FlatStyle.Standard
        botao4.BackColor = Color.LightGray
        AddHandler botao4.Click, AddressOf BOTAO_VOLTAR

        botao5.Size = New Point(40, 30)
        botao5.Location = New Point(320, 3)
        botao5.BackgroundImage = Image.FromFile("D:\PROJETOS\SISTEMAS\VB.NET\Vasco Da Gama - NOVO - Com Guias\Vasco Da Gama\Images\setas_2555_Fleche_Droite.png")
        botao5.BackgroundImageLayout = ImageLayout.Stretch
        botao5.FlatStyle = FlatStyle.Standard
        botao5.BackColor = Color.LightGray
        AddHandler botao5.Click, AddressOf BOTAO_AVANCAR

        botao6.Size = New Point(40, 30)
        botao6.Location = New Point(376, 3)
        botao6.BackgroundImage = Image.FromFile("D:\PROJETOS\SISTEMAS\VB.NET\Vasco Da Gama - NOVO - Com Guias\Vasco Da Gama\Images\Botoes_Site_5739_Knob_Search.png")
        botao6.BackgroundImageLayout = ImageLayout.Stretch
        botao6.FlatStyle = FlatStyle.Standard
        botao6.BackColor = Color.LightGray


        Caixa.Location = New Point(426, 5)
        Caixa.BackColor = Color.White
        Caixa.Size = New Point(812, 26)
        Caixa.Multiline = True

        form.Size = New Point(1256, 856)
        form.Location = New Point(3, 3)
        form.BackColor = Color.Navy
        menu.Location = New Point(3, 3)
        menu.Size = New Point(1250, 23)
        menu.BackColor = Color.Transparent
        menu.ForeColor = Color.White
        menu.Dock = DockStyle.Top
        menu.Stretch = True
        menu.LayoutStyle = ToolStripLayoutStyle.Flow
        menu.Dock = DockStyle.Top


        menu.Location = New Point(3, 3)
        menu.Size = New Point(1250, 23)
        menu.BackColor = Color.Transparent
        menu.ForeColor = Color.White
        menu.Dock = DockStyle.Bottom
        menu.Stretch = True
        menu.LayoutStyle = ToolStripLayoutStyle.Flow
        menu.Dock = DockStyle.Bottom

        net.ScriptErrorsSuppressed = 1
        net.Location = New Point(3, 70)
        net.Size = New Point(1250, 718)
        net.Dock = DockStyle.Top
        net.Anchor = AnchorStyles.Top
        net.Navigate("http://www.google.com")
        'Net.Dock = DockStyle.Fill

        BarraProgresso.Location = New Point(3, 783)
        BarraProgresso.Size = New Point(1250, 10)
        BarraProgresso.Dock = DockStyle.Bottom
        'BarraProgresso.Anchor = AnchorStyles.None

        painel.Location = New Point(3, 26)
        painel.BackColor = Color.Black
        painel.Size = New Point(1250, 46)
        painel.Dock = DockStyle.Bottom

        'BarraProgresso.Location = New Point(3, 60)
        'BarraProgresso.Size = New Point(1250, 10)



        ToolStripMenuItem1.TextDirection = ToolStripTextDirection.Horizontal
        ToolStripMenuItem1.BackColor = Color.DarkBlue
        ToolStripMenuItem1.ForeColor = Color.White
        ToolStripMenuItem1.Text = "Arquivo"
        ToolStripMenuItem1.Size = New Point(61, 19)

        ToolStripMenuItem2.TextDirection = ToolStripTextDirection.Horizontal
        ToolStripMenuItem2.BackColor = Color.DarkBlue
        ToolStripMenuItem2.ForeColor = Color.White
        ToolStripMenuItem2.Text = "Sobre"
        ToolStripMenuItem2.Size = New Point(61, 19)
        'submenu2.Checked = form2.ShowDialog


        ConfiguraçõesToolStripMenuItem.TextDirection = ToolStripTextDirection.Horizontal
        ConfiguraçõesToolStripMenuItem.BackColor = Color.DarkBlue
        ConfiguraçõesToolStripMenuItem.ForeColor = Color.White
        ConfiguraçõesToolStripMenuItem.Text = "Configurações"
        ConfiguraçõesToolStripMenuItem.Size = New Point(61, 19)



        SairToolStripMenuItem.TextDirection = ToolStripTextDirection.Horizontal
        SairToolStripMenuItem.BackColor = Color.DarkBlue
        SairToolStripMenuItem.ForeColor = Color.White
        SairToolStripMenuItem.Text = "Sair"
        SairToolStripMenuItem.Size = New Point(61, 19)





        ToolStripMenuItem4.TextDirection = ToolStripTextDirection.Horizontal
        ToolStripMenuItem4.BackColor = Color.DarkBlue
        ToolStripMenuItem4.ForeColor = Color.White
        ToolStripMenuItem4.Text = "Versão"
        ToolStripMenuItem4.Size = New Point(61, 19)

        menu.Items.Add(ToolStripMenuItem1)
        menu.Items.Add(ToolStripMenuItem2)

        ToolStripMenuItem1.DropDownItems.Add(ConfiguraçõesToolStripMenuItem)
        ToolStripMenuItem1.DropDownItems.Add(SairToolStripMenuItem)
        ToolStripMenuItem2.DropDownItems.Add(ToolStripMenuItem4)

        form.Text = "+ Vasco da Gama"
        form.Name = "form1"


        form.Controls.Add(net)
        'menu.Controls.Add(submenu1)


        form.Controls.Add(painel)
        form.Controls.Add(menu)
        form.Controls.Add(BarraProgresso)

        painel.Dock = DockStyle.Top
        BarraProgresso.Dock = DockStyle.Bottom
        net.Dock = DockStyle.Fill
        'menu.Controls.Add(submenu1)
        'form.BorderStyle = BorderStyle.Fixed3D
        painel.Controls.Add(botao1)
        painel.Controls.Add(botao2)
        painel.Controls.Add(botao3)
        painel.Controls.Add(botao4)
        painel.Controls.Add(botao5)
        painel.Controls.Add(botao6)
        painel.Controls.Add(Caixa)
        painel.Controls.Add(BarraProgresso)
        'form.Controls.Add(BarraProgresso)
        form.Contains(painel)

        TabControl1.TabPages.Add(form)
        form.BringToFront()

        'TabControl1.SelectedIndex.add(form)
        TabControl1.Visible = True
        AddHandler BarraProgresso.VisibleChanged, AddressOf EVENTO_BARRAPROGRESSO

        'texto.Text = net.Url.ToString()

    End Sub




    Sub BOTAO_INICIAL(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim net As New WebBrowser
        net.Navigate("http://www.google.com")
    End Sub



    Sub BOTAO_ATUALIZAR(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim net As New WebBrowser
        net.Refresh()

    End Sub


    Sub BOTAO_VOLTAR(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim net As New WebBrowser
        net.GoBack()

    End Sub
    Sub BOTAO_AVANCAR(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim net As New WebBrowser
        net.GoForward()

    End Sub

    Sub NET_DOCUMENTCOMPLETE(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim net As New WebBrowser
        Dim Caixa As New TextBox

        Caixa.Text = Me.WebBrowser1.Url.ToString()
    End Sub


    Sub BOTAO_IR(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim net As New WebBrowser
        Dim texto As New TextBox
        If Not String.IsNullOrEmpty(texto.Text) Then
            If TextBox1.Text.Contains("http://") Then
                net.Navigate(New Uri(texto.Text))

            Else : TextBox1.Text = "http://" & TextBox1.Text.Trim
                net.Navigate(New Uri(texto.Text))


                'ElseIf TextBox1.Text = "http://" & TextBox1.Text.Trim & ".com" & ".br" Then
                'Me.WebBrowser1.Navigate(New Uri(Me.TextBox1.Text))

                'btnVoltar.IsEnabled = True
                'btnAvancar.IsEnabled = False 
                'Else : TextBox1.Text = "http://" & TextBox1.Text.Trim & ".com"
                'Me.WebBrowser1.Navigate(Me.TextBox1.Text)
            End If
        End If

    End Sub
    Sub TEXTO_CLICK(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.Focus()
        TextBox1.SelectAll()
        TextBox1.Select()
    End Sub

    Sub EVENTO_BARRAPROGRESSO(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs)
        Dim BarraProgresso As New ProgressBar
        If e.CurrentProgress * 100 / e.MaximumProgress > 1 Then
            BarraProgresso.Value = e.CurrentProgress * 100 / e.MaximumProgress
        End If
    End Sub



    'Dim submenuopcao1 As ToolStripMenuItem
    'Private Sub submenuopcao1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submenuopcao1.Click
    '   Form2.Show()

    'End Sub



    Private Sub WebBrowser1_FileDownload(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles WebBrowser1.FileDownload
        Dim form As New TabPage
        Dim Net As New WebBrowser
        Net.Size = New Point(974, 388)
        form.Size = New Point(500, 500)
        form.Location = New Point(500, 500)
        form.Text = "Nova Guia"
        form.Name = "form1"
        form.Controls.Add(Net)
        TabControl1.TabPages.Add(form)
        TabControl1.Visible = True
        'Me.Show()
        'SaveFileDialog1.ShowDialog()
        ' My.Computer.Network.DownloadFile("http://www.macoratti.net/index.html", "c:\pagina.html")


        'End Sub
        'Declare a SaveFileDialog to save the file
        'Private Sub WebBrowser1_FileDownload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebBrowser1.FileDownload
        'Dim saver As New SaveFileDialog
        'saver.InitialDirectory = Environment.SpecialFolder.MyDocuments
        'saver.Filter = "Executable Files(*.html)|.html"
        'If saver.ShowDialog = Windows.Forms.DialogResult.OK Then
        'My.Computer.Network.DownloadFile("http://www.macoratti.net/index.html", "c:\pagina.html")
        'Start the installer
        'Process.Start(saver.FileName)
        'Exit the program
        'End
        'End If
    End Sub


    Private Sub WebBrowser1_DocumentComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Me.TextBox1.Text = WebBrowser1.Url.ToString()
    End Sub


    Private Sub TextBox1_Enter_1(sender As Object, e As EventArgs) Handles TextBox1.Enter
        Dim texto As String = "."



        'If Not String.IsNullOrEmpty(Me.TextBox1.Text) Then
        'If Not Regex.IsMatch(TextBox1.Text, texto) Then
        If Not TextBox1.Text.Contains(texto) Then
            Me.WebBrowser1.Navigate("https://www.google.com.br/search?q=" & TextBox1.Text)
            'ElseIf TextBox1.Text.Contains("http://") Then
            'Me.WebBrowser1.Navigate(New Uri(Me.TextBox1.Text))

            'Else : TextBox1.Text = "http://" & TextBox1.Text.Trim
            'Me.WebBrowser1.Navigate(New Uri(Me.TextBox1.Text))
        Else : Me.WebBrowser1.Navigate(Me.TextBox1.Text.Trim)

        End If


    End Sub

    Private Sub Button7_MouseHover(sender As Object, e As EventArgs) Handles Button7.MouseHover
        Label1.Text = "Adicionar aos favoritos"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim inserir As String
        Dim conexao As New OleDbConnection

        conexao.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0; data source=" & Application.StartupPath & "\VascoDaGama.mdb;"
        inserir = "INSERT INTO favoritos (url,titulo) VALUES(@url,@titulo)"

        Dim comando As New OleDbCommand(inserir, conexao)


        Dim url As String = TextBox1.Text
        Dim urlSub As String = String.Empty

        Dim url1 As String() = url.Split(".")

        comando.Parameters.Add(New OleDbParameter("@url", TextBox1.Text))
        comando.Parameters.Add(New OleDbParameter("@titulo", url1(1)))

        conexao.Open()
        comando.ExecuteNonQuery()
        conexao.Close()





        Dim linhas As String = String.Empty
        Dim link As String = String.Empty
        'Dim conexao As New OleDbConnection

        conexao.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0; data source=" & Application.StartupPath & "\VascoDaGama.mdb;"
        linhas = "SELECT * FROM favoritos;"
        Dim comando1 As New OleDbCommand(linhas, conexao)

        conexao.Open()
        'Dim lerDados As OleDbDataReader

        'lerDados = comando.ExecuteReader()


        Dim dataAdapter1 As New OleDbDataAdapter(comando1)
        Dim dataTable1 As New DataTable()


        dataAdapter1.Fill(dataTable1)


        Dim i As Integer = 0
        ListView1.BackColor = Color.Aquamarine

        For i = 0 To dataTable1.Rows.Count - 1
            'For i = 0 To 50

            'link = "SELECT url FROM favoritos WHERE titulo LIKE %url%;"
            'Dim button1 As New Button
            ListView1.Items.Add(CStr(dataTable1.Rows(i)("url").ToString))

            'ListView1.Items.Add("titulo")

        Next i

        conexao.Close()

    End Sub

    Private Sub Button7_MouseUp(sender As Object, e As MouseEventArgs) Handles Button7.MouseUp
        Label1.Text = String.Empty
    End Sub

    Private Sub Button7_MouseLeave(sender As Object, e As EventArgs) Handles Button7.MouseLeave
        Label1.Text = String.Empty
    End Sub

    Private Sub Button8_MouseHover(sender As Object, e As EventArgs) Handles Button8.MouseHover
        Label1.Text = "Seus Favoritos"
    End Sub

    Private Sub Button8_MouseLeave(sender As Object, e As EventArgs) Handles Button8.MouseLeave
        Label1.Text = String.Empty
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ListView1.Visible = True



    End Sub

    Private Sub ListView1_MouseLeave(sender As Object, e As EventArgs) Handles ListView1.MouseLeave
        ListView1.Visible = False
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click


        For Each item As ListViewItem In ListView1.SelectedItems
            Me.WebBrowser1.Navigate(item.Text)
            Me.TextBox1.Text = item.Text

        Next
    End Sub


    'Private Sub ListView1_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles ListView1.DrawItem
    'Dim excluir As String
    'Dim conexao As New OleDbConnection

    'conexao.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0; data source=" & Application.StartupPath & "\VascoDaGama.mdb;"
    'excluir = "DELETE FROM favoritos WHERE url = " & ListView1.SelectedItems.ToString

    'Dim comando As New OleDbCommand(excluir, conexao)

    'conexao.Open()
    'comando.ExecuteNonQuery()
    'conexao.Close()
    'End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        'Dim conexao As New OleDbConnection()

        'Dim excluir As String

        'conexao.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0; data source=" & Application.StartupPath & "\VascoDaGama.mdb;"



        'For Each ListItem As ListViewItem In ListView1.Items



        'excluir = "DELETE FROM favoritos WHERE url=" & ListItem.Index

        'Dim comando2 As New OleDbCommand(excluir, conexao)
        'conexao.Open()
        'comando2.ExecuteNonQuery()
        'conexao.Close()
        'Next

        MsgBox("Estamos trabalhando com esse recurso", MsgBoxStyle.Information)

    End Sub
End Class