Public Class Form2



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim Form1 As New Form1


        'Form1.WebBrowser1.Url = New Uri(TextBox1.Text)

        If Not String.IsNullOrEmpty(Me.TextBox1.Text) Then
            If TextBox1.Text.Contains("http://") Then
                Form1.WebBrowser1.Navigate(New Uri(Me.TextBox1.Text))
                Form1.WebBrowser1.Url = (New Uri(Me.TextBox1.Text))
                Me.Close()

            Else : TextBox1.Text = "http://" & TextBox1.Text.Trim
                Form1.WebBrowser1.Navigate(New Uri(Me.TextBox1.Text))
                Form1.WebBrowser1.Url = (New Uri(Me.TextBox1.Text))
                Me.Close()


                'ElseIf TextBox1.Text = "http://" & TextBox1.Text.Trim & ".com" & ".br" Then
                'Me.WebBrowser1.Navigate(New Uri(Me.TextBox1.Text))

                'btnVoltar.IsEnabled = True
                'btnAvancar.IsEnabled = False 
                'Else : TextBox1.Text = "http://" & TextBox1.Text.Trim & ".com"
                'Me.WebBrowser1.Navigate(Me.TextBox1.Text)
            End If
        End If
        'Form1.WebBrowser1.Navigate(New Uri(Me.TextBox1.Text))


    End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'If RadioButton1.Checked Then
    ' Form1.BackColor = Color.Silver
    'End If
    'If RadioButton2.Checked Then
    '   Form1.BackColor = Color.DarkRed
    'End If
    'If RadioButton3.Checked Then
    '    Form1.BackColor = Color.Indigo
    'End If
    'If RadioButton4.Checked Then
    '    Form1.BackColor = Color.SeaGreen
    'End If
    'If RadioButton5.Checked Then
    '   Form1.BackColor = Color.Goldenrod
    'End If
    'End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If RadioButton1.Checked Then
            Form1.BackColor = Color.Silver
        End If
        If RadioButton2.Checked Then
            Form1.BackColor = Color.DarkRed
        End If
        If RadioButton3.Checked Then
            Form1.BackColor = Color.Indigo
        End If
        If RadioButton4.Checked Then
            Form1.BackColor = Color.SeaGreen
        End If
        If RadioButton5.Checked Then
            Form1.BackColor = Color.Goldenrod
        End If
    End Sub

End Class