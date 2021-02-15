Imports MySql.Data.MySqlClient

Public Class Clearances

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.ReportViewer1.RefreshReport()
        Panel3.Hide()

        Me.ReportViewer1.RefreshReport()
        fill3()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        applyclearance.Show()
        Panel3.Hide()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        reportclearance()
        Panel3.Hide()
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        addforclearance()
        fill3()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        loadreportindividual()
        Panel3.Hide()
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Panel3.Show()

    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        applyclearance.Show()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        business.Show()
    End Sub


    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim conn As New MySqlConnection("server=127.0.0.1; user=root; password =; database=brgy;port=3306;")
        If Me.DataGridView1.RowCount = Nothing Then
            MessageBox.Show("No Data Found! Make sure there is atleast one data in the table!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim dr As New DialogResult
            dr = MessageBox.Show("Are you sure you want to permanently delete this file ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If dr = Windows.Forms.DialogResult.Cancel Then
                Me.Refresh()

                Exit Sub
            Else
                Try
                    Dim str1 As String = "DELETE FROM tblindividual where id= '" & Me.DataGridView1.SelectedCells(0).Value.ToString & "'"
                    Dim cmd1 As New MySqlCommand(str1, conn)
                    conn.Open()
                    cmd1.ExecuteNonQuery()
                    conn.Close()

                Catch ex As Exception
                    ex.ToString()
                End Try
                fill3()

            End If
        End If
    End Sub


    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        blotter.Show()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Panel3.Hide()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
       

    End Sub
End Class