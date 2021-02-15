Imports MySql.Data.MySqlClient
Public Class applyclearance

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        addforclr()
        fill5()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        loadreportclearance()
        Me.Hide()
    End Sub

    Private Sub Clearance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fill5()
        Me.WindowState = FormWindowState.Maximized
        business.Label2.Text = System.DateTime.Now.ToString("MMMM dd yyyy")

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        loadreportindigency()
        Me.Hide()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
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
                    Dim str1 As String = "DELETE FROM tblclearance where id= '" & Me.DataGridView2.SelectedCells(0).Value.ToString & "'"
                    Dim cmd1 As New MySqlCommand(str1, conn)
                    conn.Open()
                    cmd1.ExecuteNonQuery()
                    conn.Close()

                Catch ex As Exception
                    ex.ToString()
                End Try
                fill5()

            End If
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        With DataGridView2.CurrentRow
            TextBox16.Text = Me.DataGridView2.SelectedCells(1).Value.ToString
            TextBox15.Text = Me.DataGridView2.SelectedCells(2).Value.ToString
            TextBox14.Text = Me.DataGridView2.SelectedCells(3).Value.ToString
            TextBox13.Text = Me.DataGridView2.SelectedCells(4).Value.ToString
            TextBox11.Text = Me.DataGridView2.SelectedCells(6).Value.ToString

        End With
    End Sub
End Class