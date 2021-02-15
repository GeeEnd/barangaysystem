Imports MySql.Data.MySqlClient
Public Class Main

    Dim conn As New MySqlConnection("server=127.0.0.1; user=root; password =; database=brgy;port=3306;")
    Dim r As New Random


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer3.Start()
        Timer1.Enabled = True
        Me.WindowState = FormWindowState.Maximized
        panelCon.Hide()
        fill2()
        conn.Open()
        fill4()
        'Timer3.Interval = 2000
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Label4.Left < 522 Then
            Label4.Left = Label4.Left + 10

        Else
            Timer1.Enabled = False
            Timer2.Enabled = True
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        If Label4.Left > 10 Then
            Label4.Left = Label4.Left - 10

        Else
            Timer2.Enabled = False
            Timer1.Enabled = True
        End If

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Label2.Text = "TIME & DATE " & DateString & " " & TimeString
        ' Dim i As Integer = +1
        'PictureBox2.Image = My.Resources.ResourceManager.GetObject("image" & r.Next(i, 4))
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCTRL.Click
        panelCon.Show()

        Timer3.Enabled = True


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHOME.Click
        panelCon.Hide()
        Timer3.Enabled = True

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        insert.Show()
        insert.Button3.Hide()
        Button8.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        search()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If Me.DataGridView1.RowCount = Nothing Then
            MessageBox.Show("No Data Found! Make sure there is atleast one data in the table!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim dr As New DialogResult
            dr = MessageBox.Show("Are you sure you want to permanently delete this file " & Me.DataGridView1.SelectedCells(1).Value.ToString + " " + DataGridView1.SelectedCells(2).Value.ToString & "?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If dr = Windows.Forms.DialogResult.Cancel Then
                Me.Refresh()

                Exit Sub
            Else
                del()
                fill()

            End If
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If Me.DataGridView1.RowCount = Nothing Then
            MessageBox.Show("No Data Found! Make sure there is atleast one data in the table", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            insert.Show()
            insert.txtfname.Text = Me.DataGridView1.SelectedCells(1).Value.ToString
            insert.txtlname.Text = Me.DataGridView1.SelectedCells(2).Value.ToString
            insert.txtmname.Text = Me.DataGridView1.SelectedCells(3).Value.ToString
            insert.cpurok.Text = Me.DataGridView1.SelectedCells(4).Value.ToString
            insert.cbarangay.Text = Me.DataGridView1.SelectedCells(5).Value.ToString
            insert.ccity.Text = Me.DataGridView1.SelectedCells(6).Value.ToString
            insert.cprovince.Text = Me.DataGridView1.SelectedCells(7).Value.ToString
            insert.csex.Text = Me.DataGridView1.SelectedCells(8).Value.ToString
            insert.nage.Text = Me.DataGridView1.SelectedCells(9).Value.ToString
            insert.txtocc.Text = Me.DataGridView1.SelectedCells(10).Value.ToString
            insert.txtmail.Text = Me.DataGridView1.SelectedCells(11).Value.ToString
            insert.txtnum.Text = Me.DataGridView1.SelectedCells(12).Value.ToString
            insert.cstat.Text = Me.DataGridView1.SelectedCells(13).Value.ToString
            insert.txtremark.Text = Me.DataGridView1.SelectedCells(14).Value.ToString
            insert.Button1.Hide()
            insert.Label15.Text = "UPDATE DATA"
            Button8.Enabled = False
            Button9.Enabled = False
            Button10.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRPT.Click
        report.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLEAR.Click
        Clearances.Show()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNOTE.Click
        notes.Show()
        fill4()
    End Sub

    Private Sub btnCONN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCONN.Click

        If conn.State = ConnectionState.Closed Then
            MessageBox.Show("Mysql Server and Database is not Initialized", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("You are Good to Go", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim portfolioPath As String = My.Application.Info.DirectoryPath
        FileCopy(Application.StartupPath & "\backup\BarangayInformationSystem2\BarangayInformationSystem.sln", Application.StartupPath & "\backup\BarangayInformationSystem2\BarangayInformationSystem.sln")
        MsgBox("Backup Successful")
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' With DataGridView1.CurrentRow
        'insert.txtfname.Text = .Cells(1).Value
        'insert.txtlname.Text = Me.DataGridView1.SelectedCells(2).Value.ToString
        'insert.txtmname.Text = Me.DataGridView1.SelectedCells(3).Value.ToString
        'insert.cpurok.Text = Me.DataGridView1.SelectedCells(4).Value.ToString
        'insert.cbarangay.Text = Me.DataGridView1.SelectedCells(5).Value.ToString
        'insert.ccity.Text = Me.DataGridView1.SelectedCells(6).Value.ToString
        'insert.cprovince.Text = Me.DataGridView1.SelectedCells(7).Value.ToString
        'insert.csex.Text = Me.DataGridView1.SelectedCells(8).Value.ToString
        'insert.nage.Text = Me.DataGridView1.SelectedCells(9).Value.ToString
        'insert.txtocc.Text = Me.DataGridView1.SelectedCells(10).Value.ToString
        'insert.txtmail.Text = Me.DataGridView1.SelectedCells(11).Value.ToString
        'insert.txtnum.Text = Me.DataGridView1.SelectedCells(12).Value.ToString
        'insert.cstat.Text = Me.DataGridView1.SelectedCells(13).Value.ToString
        'insert.txtremark.Text = Me.DataGridView1.SelectedCells(14).Value.ToString
        'End With
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim dr As New DialogResult
        dr = MessageBox.Show("Are you sure you want to logout? " & Label9.Text & " ", "Prompt", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If dr = Windows.Forms.DialogResult.OK Then
            Me.Close()
            login.Show()
            login.txtuname.Text = Nothing
            login.txtpass.Text = Nothing
            login.ProgressBar1.Value = 0
        End If

    End Sub
End Class
