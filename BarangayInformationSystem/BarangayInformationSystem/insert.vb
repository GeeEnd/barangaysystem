Public Class insert

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        updates()

        Button1.Show()
        Me.Close()
        Main.Button8.Enabled = True
        Main.Button9.Enabled = True
        Main.Button10.Enabled = True

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        add()
        Main.Button8.Enabled = True
        Main.Button9.Enabled = True
        Main.Button10.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Main.Button8.Enabled = True
        Main.Button9.Enabled = True
        Main.Button10.Enabled = True
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label16.Hide()
    End Sub
End Class