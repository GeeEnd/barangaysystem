Imports MySql.Data.MySqlClient
Public Class notes
    Dim conn As New MySqlConnection("server=127.0.0.1; user=root; password =; database=brgy;port=3306;")

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        addfornote()
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Label10.Text = Me.DataGridView2.SelectedCells(2).Value.ToString
        Label11.Text = Me.DataGridView2.SelectedCells(1).Value.ToString
        Label12.Text = Me.DataGridView2.SelectedCells(3).Value.ToString
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub

    Private Sub notes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Dim conn As New MySqlConnection("server=127.0.0.1; user=root; password =; database=brgy;port=3306;")
        conn.Open()
        Dim sql As String = "SELECT id as ID, Subject as SUBJECT, Note_Date as DATE, Content as CONTENT from tblnote where Note_Date LIKE '%" & TextBox3.Text & "%'"
        Dim da As New MySqlDataAdapter(sql, conn)
        Dim dt As New DataTable("notes")

        DataGridView2.DataSource = dt
        da.Fill(dt)

        conn.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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
                    Dim str1 As String = "DELETE FROM tblnote where id= '" & Me.DataGridView2.SelectedCells(0).Value.ToString & "'"
                    Dim cmd1 As New MySqlCommand(str1, conn)
                    conn.Open()
                    cmd1.ExecuteNonQuery()
                    conn.Close()
                   
                Catch ex As Exception
                    ex.ToString()
                End Try
                fill4()

            End If
        End If
    End Sub

    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel4.Paint

    End Sub
End Class