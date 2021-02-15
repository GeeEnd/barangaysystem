Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms

Module Module1

    Dim conn As New MySqlConnection("server=127.0.0.1; user=root; password =; database=brgy;port=3306;")
    ''//////////SEARCH RISEDENCE\\\\\\\\\\\\''
    Sub search()
        If Main.txtsearch.Text = "" Then
            fill2()
        ElseIf Main.csearch.Text = "LAST NAME" Then
            Dim conn As New MySqlConnection("server=127.0.0.1; user=root; password =; database=brgy;port=3306;")
            conn.Open()
            Dim sql As String = "SELECT fname as FIRSTNAME, lname as LASTNAME, mname as MIDDLENAME,purok as PUROK,barangay as BARANGAY,city as CITY,province as PROVINCE,sex as SEX,age as AGE,occupation as OCCUPATION,email as EMAIL,mobile as MOBILE, status as STATUS, remarks as REMARKS from tblresidence where lname LIKE '%" & Main.txtsearch.Text & "%'"
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable("users")

            Main.DataGridView1.DataSource = dt
            da.Fill(dt)

            conn.Close()
        ElseIf Main.csearch.Text = "FIRST NAME" Then
            Dim conn As New MySqlConnection("server=127.0.0.1; user=root; password =; database=brgy;port=3306;")
            conn.Open()
            Dim sql As String = "SELECT fname as FIRSTNAME, lname as LASTNAME, mname as MIDDLENAME,purok as PUROK,barangay as BARANGAY,city as CITY,province as PROVINCE,sex as SEX,age as AGE,occupation as OCCUPATION,email as EMAIL,mobile as MOBILE, status as STATUS, remarks as REMARKS from tblresidence where fname LIKE '%" & Main.txtsearch.Text & "%' "
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable("users")

            Main.DataGridView1.DataSource = dt
            da.Fill(dt)

            conn.Close()


        End If
    End Sub

    Sub fill()

        Dim conn As New MySqlConnection("server=127.0.0.1; user=root; password =; database=brgy;port=3306;")
        conn.Open()
        Dim sql As String = "SELECT fname as FIRSTNAME, lname as LASTNAME, mname as MIDDLENAME, status as STATUS from tblresidence "
        Dim da As New MySqlDataAdapter(sql, conn)
        Dim dt As New DataTable("users")

        ' Form1.DataGridView1.DataSource = dt
        da.Fill(dt)

        conn.Close()
    End Sub
    ''//////////TABLE RESIDENCE FILL\\\\\\\\\\\\''
    Sub fill2()

        Dim conn As New MySqlConnection("server=127.0.0.1; user=root; password =; database=brgy;port=3306;")
        conn.Open()
        Dim sql As String = "SELECT id as NO, fname as FIRSTNAME, lname as LASTNAME, mname as MIDDLE,purok as PUROK,barangay as BARANGAY,city as CITY,province as PROVINCE,sex as SEX,age as AGE,occupation as OCCUPATION,email as EMAIL,mobile as MOBILE, status as STATUS, remarks as REMARKS from tblresidence ORDER by lname ASC"
        Dim da As New MySqlDataAdapter(sql, conn)
        Dim dt As New DataTable("users")

        Main.DataGridView1.DataSource = dt
        da.Fill(dt)

        conn.Close()
    End Sub
    ''//////////TABLE INDIVIDUAL FILL\\\\\\\\\\\\''
    Sub fill3()

        Dim conn As New MySqlConnection("server=127.0.0.1; user=root; password =; database=brgy;port=3306;")
        conn.Open()
        Dim sql As String = "SELECT id as ID, fullname as FULLNAME, address as ADDRESS,bdate as BIRTHDATE, bplace as BIRTHPLACE,sex as SEX,status as CIVILSTATUS,citizenship as CITIZENSHIP,occupation as OCCUPATION from tblindividual "
        Dim da As New MySqlDataAdapter(sql, conn)
        Dim dt As New DataTable("users")

        Clearances.DataGridView1.DataSource = dt
        da.Fill(dt)

        conn.Close()
    End Sub
    ''//////////TABLE NOTE FILL\\\\\\\\\\\\''
    Sub fill4()

        Dim conn As New MySqlConnection("server=127.0.0.1; user=root; password =; database=brgy;port=3306;")
        conn.Open()
        Dim sql As String = "SELECT id as ID, Subject as SUBJECT, Note_Date as DATE, Content as CONTENT from tblnote "
        Dim da As New MySqlDataAdapter(sql, conn)
        Dim dt As New DataTable("notes")

        notes.DataGridView2.DataSource = dt
        da.Fill(dt)

        conn.Close()
    End Sub
    ''//////////TABLE CLEARANCE FILL\\\\\\\\\\\\''
    Sub fill5()

        Dim conn As New MySqlConnection("server=127.0.0.1; user=root; password =; database=brgy;port=3306;")
        conn.Open()
        Dim sql As String = "SELECT id as ID, fullname as FULLNAME, address as ADDRESS,status as STATUS,bdate as BIRTHDATE,issued as ISSUEDDATE, purpose as PURPOSE from tblclearance"
        Dim da As New MySqlDataAdapter(sql, conn)
        Dim dt As New DataTable("clearance")

        applyclearance.DataGridView2.DataSource = dt
        da.Fill(dt)

        conn.Close()
    End Sub
    ''//////////TABLE BUSINES FILL\\\\\\\\\\\\''
    Sub fill6()

        Dim conn As New MySqlConnection("server=127.0.0.1; user=root; password =; database=brgy;port=3306;")
        conn.Open()
        Dim sql As String = "SELECT id as ID, name as FULLNAME, address as ADDRESS,citizenship as CITIZENSHIP,location as LOCATION,bname as BUSINESSNAME,bkind as BUSINESSKIND, bnature as BUSINESSNATURE,certificate as RESIDENTCERTIFICATE,issueddate as ISSUEDDATE, issuedplace as ISSUEDPLACE,orno as ORNo, issueddateor as ISSUEDDATE,issuedplaceor as ISSUEDPLACE,tin as TIN,BSIssuedDate as CLEARANCEISSUED from tblbusiness"
        Dim da As New MySqlDataAdapter(sql, conn)
        Dim dt As New DataTable("clearance")

        business.DataGridView2.DataSource = dt
        da.Fill(dt)

        conn.Close()
    End Sub
    ''//////////TABLE BLOTTER FILL\\\\\\\\\\\\''
    Sub fill7()

        Dim conn As New MySqlConnection("server=127.0.0.1; user=root; password =; database=brgy;port=3306;")
        conn.Open()
        Dim sql As String = "SELECT id as ID, complainant as COMPLAINANT, suspect as SUSPECT,crime as CRIMECOMMITED, dateofcrime as CRIMEDATE,issueddate as ISSUEDDATE, statement as STATEMENT, officer as OFFICER from tblbloter"
        Dim da As New MySqlDataAdapter(sql, conn)
        Dim dt As New DataTable("blotter")

        blotter.DataGridView1.DataSource = dt
        da.Fill(dt)

        conn.Close()
    End Sub
    ''//////////ADD FOR RESIDENCE\\\\\\\\\\\\''
    Sub add()

        If insert.txtfname.Text = "" Or insert.txtlname.Text = "" Or insert.txtmname.Text = "" Or insert.cpurok.Text = "" Or insert.cbarangay.Text = "" Or insert.ccity.Text = "" Or insert.cprovince.Text = "" Or insert.csex.Text = "" Or insert.csex.Text = "" Or insert.nage.Text = "" Or insert.txtocc.Text = "" Or insert.txtnum.Text = "" Then
            insert.Label16.Show()
        Else
            Dim cmd As New MySqlCommand
            Dim da As New MySqlDataAdapter

            Dim publictable As New DataTable

            Using sqlCommand As New MySqlCommand()
                With sqlCommand
                    .CommandText = "INSERT INTO tblresidence (fname,lname,mname,purok,barangay,city,province,sex,age,occupation,email,mobile,status,remarks) values (@f,@l,@m,@p,@b,@c,@pr,@s,@a,@o,@ma,@n,@st,@remar)"

                    .Connection = conn
                    .CommandType = CommandType.Text

                    .Parameters.AddWithValue("@f", insert.txtfname.Text)
                    .Parameters.AddWithValue("@l", insert.txtlname.Text)
                    .Parameters.AddWithValue("@m", insert.txtmname.Text)
                    .Parameters.AddWithValue("@p", insert.cpurok.Text)
                    .Parameters.AddWithValue("@b", insert.cbarangay.Text)
                    .Parameters.AddWithValue("@c", insert.ccity.Text)
                    .Parameters.AddWithValue("@pr", insert.cprovince.Text)
                    .Parameters.AddWithValue("@s", insert.csex.Text)
                    .Parameters.AddWithValue("@a", insert.nage.Text)
                    .Parameters.AddWithValue("@o", insert.txtocc.Text)
                    .Parameters.AddWithValue("@ma", insert.txtmail.Text)
                    .Parameters.AddWithValue("@n", insert.txtnum.Text)
                    .Parameters.AddWithValue("@st", insert.cstat.Text)
                    .Parameters.AddWithValue("@remar", insert.txtremark.Text)
                    MsgBox("DATA HAS BEEN ADDED!", vbInformation, "SAVE")
                End With
                Try
                    conn.Open()
                    sqlCommand.ExecuteNonQuery()

                Catch ex As MySqlException
                    MsgBox(ex.Message.ToString)


                Finally
                    conn.Close()
                    fill2()
                    fill()
                    insert.Button3.Show()
                    insert.Close()
                End Try
            End Using

            Return
        End If
    End Sub
    ''//////////ADD FOR INDIVIDUAL\\\\\\\\\\\\''
    Sub addforclearance()
        If Clearances.TextBox1.Text = "" Or Clearances.TextBox2.Text = "" Or Clearances.TextBox3.Text = "" Or Clearances.TextBox4.Text = "" Or Clearances.TextBox5.Text = "" Or Clearances.TextBox6.Text = "" Or Clearances.TextBox7.Text = "" Or Clearances.TextBox8.Text = "" Then
            MessageBox.Show("Please Fill Up the Boxes", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim cmd As New MySqlCommand
            Dim da As New MySqlDataAdapter

            Dim publictable As New DataTable

            Using sqlCommand As New MySqlCommand()
                With sqlCommand
                    .CommandText = "INSERT INTO tblindividual (fullname,address,bdate,bplace,sex,status,citizenship,occupation) values (@f,@add,@bdate,@bplace,@sex,@stat,@citi,@occ)"

                    .Connection = conn
                    .CommandType = CommandType.Text

                    .Parameters.AddWithValue("@f", Clearances.TextBox1.Text)
                    .Parameters.AddWithValue("@add", Clearances.TextBox2.Text)
                    .Parameters.AddWithValue("@bdate", Clearances.TextBox3.Text)
                    .Parameters.AddWithValue("@bplace", Clearances.TextBox4.Text)
                    .Parameters.AddWithValue("@sex", Clearances.TextBox5.Text)
                    .Parameters.AddWithValue("@stat", Clearances.TextBox6.Text)
                    .Parameters.AddWithValue("@citi", Clearances.TextBox7.Text)
                    .Parameters.AddWithValue("@occ", Clearances.TextBox8.Text)
                    MsgBox("DATA HAS BEEN ADDED!", vbInformation, "SAVE")
                End With
                Try
                    conn.Open()
                    sqlCommand.ExecuteNonQuery()

                Catch ex As MySqlException
                    MsgBox(ex.Message.ToString)


                Finally
                    conn.Close()
                    fill2()
                    fill()
                    insert.Button3.Show()
                End Try
            End Using

            Return
        End If
    End Sub
    ''//////////ADD FOR NOTE\\\\\\\\\\\\''
    Sub addfornote()

        If notes.TextBox1.Text = "" Or notes.TextBox2.Text = "" Or notes.RichTextBox1.Text = "" Then
            MessageBox.Show("Please Fill Up the Boxes", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim cmd As New MySqlCommand
            Dim da As New MySqlDataAdapter

            Dim publictable As New DataTable

            Using sqlCommand As New MySqlCommand()
                With sqlCommand
                    .CommandText = "INSERT INTO tblnote (Subject,Note_Date,Content) values (@sub,@datee,@content)"

                    .Connection = conn
                    .CommandType = CommandType.Text

                    .Parameters.AddWithValue("@sub", notes.TextBox2.Text)
                    .Parameters.AddWithValue("@datee", notes.TextBox1.Text)
                    .Parameters.AddWithValue("@content", notes.RichTextBox1.Text)

                    MsgBox("DATA HAS BEEN ADDED!", vbInformation, "SAVE")
                    notes.TextBox1.Text = Nothing
                    notes.TextBox2.Text = Nothing
                    notes.RichTextBox1.Text = Nothing

                End With
                Try
                    conn.Open()
                    sqlCommand.ExecuteNonQuery()

                Catch ex As MySqlException
                    MsgBox(ex.Message.ToString)


                Finally
                    conn.Close()
                    fill4()

                End Try
            End Using
        End If
        Return
    End Sub
    ''//////////ADD FOR CLEARANCE\\\\\\\\\\\\''
    Sub addforclr()
        If applyclearance.TextBox11.Text = "" Or applyclearance.TextBox13.Text = "" Or applyclearance.TextBox14.Text = "" Or applyclearance.TextBox15.Text = "" Or applyclearance.TextBox16.Text = "" Then
            MessageBox.Show("Please Fill Up the Boxes", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim cmd As New MySqlCommand
            Dim da As New MySqlDataAdapter

            Dim publictable As New DataTable

            Using sqlCommand As New MySqlCommand()
                With sqlCommand
                    .CommandText = "INSERT INTO tblclearance (fullname,address,status,bdate,issued,purpose) values (@f,@add,@stat,@bdate,@issued,@purp)"

                    .Connection = conn
                    .CommandType = CommandType.Text

                    .Parameters.AddWithValue("@f", applyclearance.TextBox16.Text)
                    .Parameters.AddWithValue("@add", applyclearance.TextBox15.Text)
                    .Parameters.AddWithValue("@stat", applyclearance.TextBox14.Text)
                    .Parameters.AddWithValue("@bdate", applyclearance.TextBox13.Text)
                    .Parameters.AddWithValue("@issued", business.Label2.Text)
                    .Parameters.AddWithValue("@purp", applyclearance.TextBox11.Text)

                    MsgBox("DATA HAS BEEN ADDED!", vbInformation, "SAVE")


                End With
                Try
                    conn.Open()
                    sqlCommand.ExecuteNonQuery()

                Catch ex As MySqlException
                    MsgBox(ex.Message.ToString)


                Finally
                    conn.Close()
                    fill5()

                End Try
            End Using

            Return
        End If
    End Sub
    ''//////////ADD FOR blotter\\\\\\\\\\\\''
    Sub addforblotter()

        If blotter.TextBox1.Text = "" Or blotter.TextBox2.Text = "" Or blotter.RichTextBox1.Text = "" Then
            MessageBox.Show("Please Fill Up the Boxes", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim cmd As New MySqlCommand
            Dim da As New MySqlDataAdapter

            Dim publictable As New DataTable

            Using sqlCommand As New MySqlCommand()
                With sqlCommand
                    .CommandText = "INSERT INTO tblbloter (complainant,suspect,crime,dateofcrime,issueddate,statement,officer) values (@com,@suspect,@comm,@crime,@content,@off,@issued)"

                    .Connection = conn
                    .CommandType = CommandType.Text

                    .Parameters.AddWithValue("@com", blotter.TextBox1.Text)
                    .Parameters.AddWithValue("@suspect", blotter.TextBox2.Text)
                    .Parameters.AddWithValue("@comm", blotter.TextBox6.Text)
                    .Parameters.AddWithValue("@crime", blotter.TextBox3.Text)
                    .Parameters.AddWithValue("@content", blotter.RichTextBox1.Text)
                    .Parameters.AddWithValue("@off", blotter.TextBox4.Text)
                    .Parameters.AddWithValue("@issued", blotter.TextBox5.Text)
                    MsgBox("DATA HAS BEEN ADDED!", vbInformation, "SAVE")
                    blotter.TextBox1.Text = Nothing
                    blotter.TextBox2.Text = Nothing
                    blotter.TextBox3.Text = Nothing
                    blotter.TextBox4.Text = Nothing
                    blotter.RichTextBox1.Text = Nothing

                End With
                Try
                    conn.Open()
                    sqlCommand.ExecuteNonQuery()

                Catch ex As MySqlException
                    MsgBox(ex.Message.ToString)


                Finally
                    conn.Close()
                    fill7()

                End Try
            End Using
        End If
        Return
    End Sub
    ''//////////ADD FOR BUSINES\\\\\\\\\\\\''
    Sub addforbusiness()

        If business.TextBox9.Text = "" Or business.TextBox10.Text = "" Or business.TextBox11.Text = "" Or business.TextBox12.Text = "" Or business.TextBox13.Text = "" Or business.TextBox14.Text = "" Or business.TextBox15.Text = "" Or business.TextBox16.Text = "" Or business.TextBox17.Text = "" Or business.TextBox18.Text = "" Or business.TextBox19.Text = "" Or business.TextBox20.Text = "" Or business.TextBox21.Text = "" Or business.TextBox22.Text = "" Then
            MessageBox.Show("Please Fill Up the Boxes", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim cmd As New MySqlCommand
            Dim da As New MySqlDataAdapter

            Dim publictable As New DataTable

            Using sqlCommand As New MySqlCommand()
                With sqlCommand
                    .CommandText = "INSERT INTO tblbusiness (name,address,citizenship,location,bname,bkind,bnature,certificate,issueddate,issuedplace,orno,issueddateor,issuedplaceor,tin,BSIssuedDate) values (@f,@l,@m,@p,@b,@c,@pr,@s,@a,@o,@ma,@n,@st,@r,@da)"

                    .Connection = conn
                    .CommandType = CommandType.Text

                    .Parameters.AddWithValue("@f", business.TextBox22.Text)
                    .Parameters.AddWithValue("@l", business.TextBox21.Text)
                    .Parameters.AddWithValue("@m", business.TextBox20.Text)
                    .Parameters.AddWithValue("@p", business.TextBox19.Text)
                    .Parameters.AddWithValue("@b", business.TextBox18.Text)
                    .Parameters.AddWithValue("@c", business.TextBox17.Text)
                    .Parameters.AddWithValue("@pr", business.TextBox16.Text)
                    .Parameters.AddWithValue("@s", business.TextBox15.Text)
                    .Parameters.AddWithValue("@a", business.TextBox14.Text)
                    .Parameters.AddWithValue("@o", business.TextBox13.Text)
                    .Parameters.AddWithValue("@ma", business.TextBox12.Text)
                    .Parameters.AddWithValue("@n", business.TextBox11.Text)
                    .Parameters.AddWithValue("@st", business.TextBox10.Text)
                    .Parameters.AddWithValue("@r", business.TextBox9.Text)
                    .Parameters.AddWithValue("@da", business.Label2.Text)
                    MsgBox("DATA HAS BEEN ADDED!", vbInformation, "SAVE")
                End With
                Try
                    conn.Open()
                    sqlCommand.ExecuteNonQuery()

                Catch ex As MySqlException
                    MsgBox(ex.Message.ToString)


                Finally
                    conn.Close()
                    fill6()

                End Try
            End Using

            Return
        End If
    End Sub
    ''//////////UPDATE\\\\\\\\\\\''
    Sub updates()
        Dim dr As New DialogResult
        dr = MessageBox.Show("Are you sure you want to Update?", "Change Details", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If dr = Windows.Forms.DialogResult.OK Then
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim st As String = "UPDATE tblresidence SET fname = '" & insert.txtfname.Text & "', lname = '" & insert.txtlname.Text & "',mname = '" & insert.txtmname.Text & "',purok = '" & insert.cpurok.Text & "', barangay = '" & insert.cbarangay.Text & "', city = '" & insert.ccity.Text & "', province = '" & insert.cprovince.Text & "' , sex= '" & insert.csex.Text & "', age= '" & insert.nage.Text & "', occupation= '" & insert.txtocc.Text & "', email= '" & insert.txtmail.Text & "', mobile= '" & insert.txtnum.Text & "', status= '" & insert.cstat.Text & "', remarks= '" & insert.txtremark.Text & "'  WHERE id = '" & Main.DataGridView1.SelectedCells(0).Value & "'"
            MessageBox.Show("Process Successful!", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim cmd As New MySqlCommand(st, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            fill()
            fill2()
        End If
    End Sub
    ''//////////DELETE\\\\\\\\\\\\''
    Sub del()
        Try
            Dim str1 As String = "DELETE FROM tblresidence where id= '" & Main.DataGridView1.SelectedCells(0).Value.ToString & "'"
            Dim cmd1 As New MySqlCommand(str1, conn)
            conn.Open()
            cmd1.ExecuteNonQuery()
            conn.Close()
            fill2()
            fill()
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub
    ''//////////LOAD REPORT FOR RESIDENCE\\\\\\\\\\\\''
    Sub loadreport()
        Dim rpDS As ReportDataSource
        report.ReportViewer1.RefreshReport()
        Try
            With report.ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Reports\Report1.rdlc"
                .DataSources.Clear()
            End With

            Dim ds As New DataSet1
            Dim da As New MySqlDataAdapter
            conn.Open()

            da.SelectCommand = New MySqlCommand("SELECT fname,lname,mname,barangay,city,province,sex,age,occupation,email,mobile,status from tblresidence ORDER by fname DESC", conn)
            da.Fill(ds.Tables("dtFILE"))
            conn.Close()

            rpDS = New ReportDataSource("DataSet1", ds.Tables("dtFILE"))
            report.ReportViewer1.LocalReport.DataSources.Add(rpDS)
            report.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            report.ReportViewer1.ZoomMode = ZoomMode.FullPage

            'report.ReportViewer1.ZoomPercent = 30
        Catch ex As Exception

        End Try
    End Sub
    ''//////////LOAD REPORT FOR BUSINESS\\\\\\\\\\\\''
    Sub loadreportforbusiness()
        Dim rpbusi As ReportDataSource
        Clearances.ReportViewer1.RefreshReport()
        Try
            With Clearances.ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Reports\businesspermit.rdlc"
                .DataSources.Clear()
            End With

            Dim ds As New DataSet1
            Dim da As New MySqlDataAdapter
            conn.Open()

            da.SelectCommand = New MySqlCommand("SELECT name, address,citizenship,location,bname,bkind,bnature,certificate,issueddate, issuedplace,orno, issueddateor,issuedplaceor,tin,BSIssuedDate from tblbusiness WHERE id = '" & business.DataGridView2.SelectedCells(0).Value & "'", conn)
            da.Fill(ds.Tables("dtBUSI"))
            conn.Close()

            rpbusi = New ReportDataSource("DataSet1", ds.Tables("dtBUSI"))
            Clearances.ReportViewer1.LocalReport.DataSources.Add(rpbusi)
            Clearances.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            Clearances.ReportViewer1.ZoomMode = ZoomMode.Percent
            Clearances.ReportViewer1.ZoomPercent = 50
        Catch ex As Exception

        End Try
    End Sub
    Sub loadreportforbusiness2()
        Dim rpbusi As ReportDataSource
        report.ReportViewer1.RefreshReport()
        Try
            With report.ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Reports\business2.rdlc"
                .DataSources.Clear()
            End With

            Dim ds As New DataSet1
            Dim da As New MySqlDataAdapter
            conn.Open()

            da.SelectCommand = New MySqlCommand("SELECT name, address,citizenship,location,bname,bkind,bnature,certificate,issueddate, issuedplace,orno, issueddateor,issuedplaceor,tin,BSIssuedDate from tblbusiness", conn)
            da.Fill(ds.Tables("dtBUSI"))
            conn.Close()

            rpbusi = New ReportDataSource("DataSet1", ds.Tables("dtBUSI"))
            report.ReportViewer1.LocalReport.DataSources.Add(rpbusi)
            report.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            report.ReportViewer1.ZoomMode = ZoomMode.FullPage
            report.ReportViewer1.ZoomPercent = 50
        Catch ex As Exception

        End Try
    End Sub
    ''//////////LOAD REPORT FOR INDIVIDUAL\\\\\\\\\\\\''
    Sub loadreport2()
        Dim rpind As ReportDataSource
        report.ReportViewer1.RefreshReport()
        Try
            With report.ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Reports\individual.rdlc"
                .DataSources.Clear()
            End With

            Dim ds As New DataSet1
            Dim da As New MySqlDataAdapter
            conn.Open()

            da.SelectCommand = New MySqlCommand("SELECT fullname,address,bdate,bplace,sex,status,citizenship,occupation from tblindividual", conn)
            da.Fill(ds.Tables("dtIND"))
            conn.Close()

            rpind = New ReportDataSource("DataSet1", ds.Tables("dtIND"))
            report.ReportViewer1.LocalReport.DataSources.Add(rpind)
            report.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            report.ReportViewer1.ZoomMode = ZoomMode.FullPage
            report.ReportViewer1.ZoomPercent = 30
        Catch ex As Exception

        End Try
    End Sub
    ''//////////LOAD REPORT FOR INVIVIDUAL\\\\\\\\\\\\''
    Sub loadreportindividual()
        Dim rpnew As ReportDataSource
        Clearances.ReportViewer1.RefreshReport()
        Try
            With Clearances.ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Reports\Report2.rdlc"
                .DataSources.Clear()
            End With

            Dim ds As New DataSet1
            Dim da As New MySqlDataAdapter
            conn.Open()

            da.SelectCommand = New MySqlCommand("SELECT fullname,address,bdate,bplace,sex,status,citizenship,occupation from tblindividual WHERE id = '" & Clearances.DataGridView1.SelectedCells(0).Value & "'", conn)
            da.Fill(ds.Tables("dtIND"))
            conn.Close()

            rpnew = New ReportDataSource("DataSet1", ds.Tables("dtIND"))
            Clearances.ReportViewer1.LocalReport.DataSources.Add(rpnew)
            Clearances.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            Clearances.ReportViewer1.ZoomMode = ZoomMode.Percent
            Clearances.ReportViewer1.ZoomPercent = 50
        Catch ex As Exception

        End Try
    End Sub
    ''//////////LOAD REPORT FOR CLEARANCE\\\\\\\\\\\\''
    Sub loadreportclearance()
        Dim rpnew As ReportDataSource
        Clearances.ReportViewer1.RefreshReport()
        Try
            With Clearances.ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Reports\clearance.rdlc"
                .DataSources.Clear()
            End With

            Dim ds As New DataSet1
            Dim da As New MySqlDataAdapter
            conn.Open()

            da.SelectCommand = New MySqlCommand("SELECT fullname,address,status,bdate,issued,purpose from tblclearance WHERE id = '" & applyclearance.DataGridView2.SelectedCells(0).Value & "'", conn)
            da.Fill(ds.Tables("dtCLR"))
            conn.Close()

            rpnew = New ReportDataSource("DataSet1", ds.Tables("dtCLR"))
            Clearances.ReportViewer1.LocalReport.DataSources.Add(rpnew)
            Clearances.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            Clearances.ReportViewer1.ZoomMode = ZoomMode.Percent
            Clearances.ReportViewer1.ZoomPercent = 50
        Catch ex As Exception

        End Try
    End Sub
    Sub loadreportclearance2()
        Dim rpnew As ReportDataSource
        report.ReportViewer1.RefreshReport()
        Try
            With report.ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Reports\clearance2.rdlc"
                .DataSources.Clear()
            End With

            Dim ds As New DataSet1
            Dim da As New MySqlDataAdapter
            conn.Open()

            da.SelectCommand = New MySqlCommand("SELECT fullname,address,status,bdate,issued,purpose from tblclearance ", conn)
            da.Fill(ds.Tables("dtCLR"))
            conn.Close()

            rpnew = New ReportDataSource("DataSet1", ds.Tables("dtCLR"))
            report.ReportViewer1.LocalReport.DataSources.Add(rpnew)
            report.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            report.ReportViewer1.ZoomMode = ZoomMode.FullPage
            report.ReportViewer1.ZoomPercent = 50
        Catch ex As Exception

        End Try
    End Sub
    ''//////////LOAD REPORT FOR INDIGENCY\\\\\\\\\\\\''
    Sub loadreportindigency()
        Dim rpnew As ReportDataSource
        Clearances.ReportViewer1.RefreshReport()
        Try
            With Clearances.ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Reports\indigency.rdlc"
                .DataSources.Clear()
            End With

            Dim ds As New DataSet1
            Dim da As New MySqlDataAdapter
            conn.Open()

            da.SelectCommand = New MySqlCommand("SELECT fullname,issued,purpose from tblclearance WHERE id = '" & applyclearance.DataGridView2.SelectedCells(0).Value & "'", conn)
            da.Fill(ds.Tables("dtINDIGENCY"))
            conn.Close()

            rpnew = New ReportDataSource("DataSet1", ds.Tables("dtINDIGENCY"))
            Clearances.ReportViewer1.LocalReport.DataSources.Add(rpnew)
            Clearances.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            Clearances.ReportViewer1.ZoomMode = ZoomMode.Percent
            Clearances.ReportViewer1.ZoomPercent = 50
        Catch ex As Exception

        End Try
    End Sub
    ''//////////LOAD REPORT FOR BLOTTER\\\\\\\\\\\\''
    Sub loadreportblotter()
        Dim rpind As ReportDataSource
        Clearances.ReportViewer1.RefreshReport()
        Try
            With Clearances.ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Reports\blotter.rdlc"
                .DataSources.Clear()
            End With

            Dim ds As New DataSet1
            Dim da As New MySqlDataAdapter
            conn.Open()

            da.SelectCommand = New MySqlCommand("SELECT * from tblbloter WHERE id = '" & blotter.DataGridView1.SelectedCells(0).Value & "'", conn)
            da.Fill(ds.Tables("dtBLOT"))
            conn.Close()

            rpind = New ReportDataSource("DataSet1", ds.Tables("dtBLOT"))
            Clearances.ReportViewer1.LocalReport.DataSources.Add(rpind)
            Clearances.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            Clearances.ReportViewer1.ZoomMode = ZoomMode.Percent
            Clearances.ReportViewer1.ZoomPercent = 50
        Catch ex As Exception

        End Try
    End Sub
    ''//////////LOAD REPORT FOR BLOTTER\\\\\\\\\\\\''
    Sub loadreportblotter2()
        Dim rpind As ReportDataSource
        report.ReportViewer1.RefreshReport()
        Try
            With report.ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Reports\blottersecond.rdlc"
                .DataSources.Clear()
            End With

            Dim ds As New DataSet1
            Dim da As New MySqlDataAdapter
            conn.Open()

            da.SelectCommand = New MySqlCommand("SELECT * from tblbloter ", conn)
            da.Fill(ds.Tables("dtBLOT"))
            conn.Close()

            rpind = New ReportDataSource("DataSet1", ds.Tables("dtBLOT"))
            report.ReportViewer1.LocalReport.DataSources.Add(rpind)
            report.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            report.ReportViewer1.ZoomMode = ZoomMode.FullPage
            report.ReportViewer1.ZoomPercent = 30
        Catch ex As Exception

        End Try
    End Sub

    ''//////////PARAMETERS PASSING\\\\\\\\\\\\''
    Sub reportclearance()
        Dim rpt As New ReportDataSource
        With report.ReportViewer1.LocalReport
            .ReportPath = Application.StartupPath & "\Reports\Report2.rdlc"
            .DataSources.Clear()
        End With
        Dim fname As New ReportParameter("fname", Clearances.TextBox1.Text)
        Dim add As New ReportParameter("add", Clearances.TextBox2.Text)
        Dim bdate As New ReportParameter("bdate", Clearances.TextBox3.Text)
        Dim bplace As New ReportParameter("bplace", Clearances.TextBox4.Text)
        Dim sex As New ReportParameter("sex", Clearances.TextBox5.Text)
        Dim cstatus As New ReportParameter("cstatus", Clearances.TextBox6.Text)
        Dim citizenship As New ReportParameter("citizenship", Clearances.TextBox7.Text)
        Dim occupation As New ReportParameter("occupation", Clearances.TextBox8.Text)

        Clearances.ReportViewer1.LocalReport.SetParameters(fname)
        Clearances.ReportViewer1.LocalReport.SetParameters(add)
        Clearances.ReportViewer1.LocalReport.SetParameters(bdate)
        Clearances.ReportViewer1.LocalReport.SetParameters(bplace)
        Clearances.ReportViewer1.LocalReport.SetParameters(sex)
        Clearances.ReportViewer1.LocalReport.SetParameters(cstatus)
        Clearances.ReportViewer1.LocalReport.SetParameters(citizenship)
        Clearances.ReportViewer1.LocalReport.SetParameters(occupation)

        ' rpt = New ReportDataSource("fname")
        'Clearances.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        'Clearances.ReportViewer1.LocalReport.DataSources.Add(rpt)
        Clearances.ReportViewer1.LocalReport.DataSources.Add(rpt)
        Clearances.ReportViewer1.ZoomMode = ZoomMode.Percent
        Clearances.ReportViewer1.ZoomPercent = 30

    End Sub

    Sub logout()
        Dim conn As New MySqlConnection("server=127.0.0.1; user=root;pass=;database=brgy")
        Dim cmd As New MySqlCommand
        Dim da As New MySqlDataAdapter
        Dim sql As String
        Dim maxrow As Integer
        sql = "SELECT * FROM tblforusers "
        maxrow = singleresult(sql)
        If maxrow > 0 Then

            ' txtpass.Clear()
            ' txtuname.Clear()
            
        Else
            MessageBox.Show("WRONG PASSWORD or PASSWORD or simple Your Account Doesn't Exist", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
End Module
