Imports MySql.Data.MySqlClient
Public Class report


    Dim conn As New MySqlConnection
    Dim cm As MySqlCommand

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With conn
            .ConnectionString = "server=localhost; user=root; password =; database=brgy;port=3306;"
        End With

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            loadreport()
        ElseIf RadioButton2.Checked = True Then
            loadreport2()
        ElseIf RadioButton3.Checked = True Then
            loadreportblotter2()
        ElseIf RadioButton4.Checked = True Then
            loadreportclearance2()
        ElseIf RadioButton5.Checked = True Then
            loadreportforbusiness2()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class