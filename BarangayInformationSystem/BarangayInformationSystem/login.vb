Imports MySql.Data.MySqlClient
Public NotInheritable Class login

    Dim dt As New DataTable
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim conn As New MySqlConnection("server=127.0.0.1; user=root;pass=;database=brgy")
        Dim cmd As New MySqlCommand
        Dim da As New MySqlDataAdapter
        Dim sql As String
        Dim maxrow As Integer
        sql = "SELECT * FROM tblforusers WHERE username = '" & txtuname.Text & "' AND pass='" & txtpass.Text & "'"
        maxrow = singleresult(sql)
        If maxrow > 0 Then

            ' txtpass.Clear()
            ' txtuname.Clear()
            txtuname.Focus()
            Timer1.Start()
            Main.Label9.Text = txtuname.Text
        Else
            MessageBox.Show("WRONG PASSWORD or PASSWORD or simple Your Account Doesn't Exist", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtpass.Clear()
            txtuname.Clear()
        End If


    End Sub

    Private Function singleresult(ByVal sql As String) As Integer
        Dim conn As New MySqlConnection("server=127.0.0.1; user=root;pass=;database=brgy")
        Dim cmd As New MySqlCommand
        Dim da As New MySqlDataAdapter

        Dim maxrow As Integer

        Dim ds As DataSet
        Dim dt As New DataTable
        Try
            conn.Open()

            cmd = New MySqlCommand
            da = New MySqlDataAdapter
            dt = New DataTable

            With cmd
                .Connection = conn
                .CommandText = sql
            End With

            da.SelectCommand = cmd
            da.Fill(dt)

            maxrow = dt.Rows.Count

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()

        End Try

        Return maxrow
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Value += 10
        If ProgressBar1.Value = 100 Then

            Timer1.Dispose()

            Me.Hide()
            'MessageBox.Show("WELCOME  '" & txtuname.Text & "'", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Main.Show()

        End If
    End Sub

    Private Sub SplashScreen1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Label7.Visible = False
        Panel2.Hide()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Panel2.Show()
    End Sub



    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim conn As New MySqlConnection("server=127.0.0.1; user=root;pass=;database=brgy")
        If TextBox2.Text = "" Or TextBox1.Text = "" Then
            MessageBox.Show("Please Fill Up the Boxes", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim cmd As New MySqlCommand
            Dim da As New MySqlDataAdapter

            Dim publictable As New DataTable

            Using sqlCommand As New MySqlCommand()
                With sqlCommand
                    .CommandText = "INSERT INTO tblforusers (username,pass) values (@f,@l)"

                    .Connection = conn
                    .CommandType = CommandType.Text

                    .Parameters.AddWithValue("@f", TextBox2.Text)
                    .Parameters.AddWithValue("@l", TextBox1.Text)

                    MsgBox("DATA HAS BEEN ADDED!", vbInformation, "SAVE")
                    txtpass.Clear()
                    txtuname.Clear()
                End With
                Try
                    conn.Open()
                    sqlCommand.ExecuteNonQuery()

                Catch ex As MySqlException
                    MsgBox(ex.Message.ToString)


                Finally
                    conn.Close()

                End Try
            End Using

            Return
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        If TextBox1.Text = TextBox3.Text Then
            Label7.Show()
        Else
            Label7.Text = "PASSWORD MATCH"
            Label7.ForeColor = Color.Green
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Panel2.Hide()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar1.Click

    End Sub
End Class
