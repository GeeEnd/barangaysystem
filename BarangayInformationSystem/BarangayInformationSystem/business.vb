Imports MySql.Data.MySqlClient
Public Class business

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        addforbusiness()
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fill6()
        Me.WindowState = FormWindowState.Maximized
        Label2.Text = System.DateTime.Now.ToString("MMMM dd yyyy")
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        loadreportforbusiness()
        Me.Hide()
    End Sub

    Private Sub Panel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim conn As New MySqlConnection("server=localhost; user=root; pass=; database=brgy; port =3306")
        If Me.DataGridView2.RowCount = Nothing Then
            MessageBox.Show("No Data Found! Make sure there is atleast one data in the table!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim dr As New DialogResult
            dr = MessageBox.Show("Are you sure you want to permanently delete this file ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If dr = Windows.Forms.DialogResult.Cancel Then
                Me.Refresh()

                Exit Sub
            Else
                Try
                    Dim str1 As String = "DELETE FROM tblbusiness where id= '" & Me.DataGridView2.SelectedCells(0).Value.ToString & "'"
                    Dim cmd1 As New MySqlCommand(str1, conn)
                    conn.Open()
                    cmd1.ExecuteNonQuery()
                    conn.Close()

                Catch ex As Exception
                    ex.ToString()
                End Try
                fill6()

            End If
        End If
    End Sub
End Class