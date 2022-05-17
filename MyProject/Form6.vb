Imports System.Data
Imports System.Data.SqlClient
Public Class Form6

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bindgrid1()
        bindgrid2()
        lod()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        lod()
    End Sub

    Private Sub lod()
        Label15.Visible = False
        Label16.Visible = False
        Label18.Visible = False
        Label17.Visible = False
        Label23.Visible = False
        Label24.Visible = False
        Label25.Visible = False
        Label26.Visible = False
        Label27.Visible = False
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        bindgrid1()
        bindgrid2()
    End Sub
    Private Sub bindgrid1()
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select RegNo,Name,Email,PhNo,Course,Gender,Yoj,Address from NewStudents", con)
        cmd.CommandType = CommandType.Text
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)
        DataGridView1.DataSource = dt
        con.Close()
    End Sub
    Private Sub bindgrid2()
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select RegNo,Name,Email,PhNo,Course,Gender,Yoj,Address from Student", con)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)
        DataGridView2.DataSource = dt
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" And ComboBox1.SelectedIndex = -1 And ComboBox2.SelectedIndex = -1 And TextBox5.Text = "" And TextBox6.Text = "") Then
            MessageBox.Show("Please enter all the details", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("select * from Student where RegNo='" + TextBox1.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader
            If (sdr.Read()) Then
                MessageBox.Show("Registraion Number already exits in the database", "Error")
            Else
                con.Close()
                con.Open()
                cmd = New SqlCommand("insert into Student select * from NewStudents where RegNo='" + TextBox1.Text + "'", con)
                Dim i As Integer = cmd.ExecuteNonQuery()
                If i > 0 Then
                    MessageBox.Show("Entry added", "Sucessful")
                    con.Close()
                    con.Open()
                    cmd = New SqlCommand("delete from NewStudents where RegNo='" + TextBox1.Text + "'", con)
                    cmd.ExecuteNonQuery()
                End If
            End If
            con.Close()
            lod()
            bindgrid1()
            bindgrid2()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Try
            TextBox1.Text = DataGridView1.Item(0, i).Value
            TextBox2.Text = DataGridView1.Item(1, i).Value
            TextBox3.Text = DataGridView1.Item(2, i).Value
            TextBox4.Text = DataGridView1.Item(3, i).Value
            ComboBox1.SelectedItem = DataGridView1.Item(4, i).Value
            ComboBox2.SelectedItem = DataGridView1.Item(5, i).Value
            TextBox5.Text = DataGridView1.Item(6, i).Value
            TextBox6.Text = DataGridView1.Item(7, i).Value
        Catch ex As Exception
            MsgBox("Sorry")
        End Try
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Dim i As Integer
        i = DataGridView2.CurrentRow.Index
        Try
            TextBox1.Text = DataGridView2.Item(0, i).Value
            TextBox2.Text = DataGridView2.Item(1, i).Value
            TextBox3.Text = DataGridView2.Item(2, i).Value
            TextBox4.Text = DataGridView2.Item(3, i).Value
            ComboBox1.SelectedItem = DataGridView2.Item(4, i).Value
            ComboBox2.SelectedItem = DataGridView2.Item(5, i).Value
            TextBox5.Text = DataGridView2.Item(6, i).Value
            TextBox6.Text = DataGridView2.Item(7, i).Value
        Catch ex As Exception
            MsgBox("Sorry")
        End Try
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Label15.Visible = True
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Label15.Visible = False
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Label16.Visible = True
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Label16.Visible = False
    End Sub

    Private Sub Button6_MouseHover(sender As Object, e As EventArgs) Handles Button6.MouseHover
        Label18.Visible = True
    End Sub

    Private Sub Button6_MouseLeave(sender As Object, e As EventArgs) Handles Button6.MouseLeave
        Label18.Visible = False
    End Sub

    Private Sub Button5_MouseHover(sender As Object, e As EventArgs) Handles Button5.MouseHover
        Label17.Visible = True
    End Sub

    Private Sub Button5_MouseLeave(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        Label17.Visible = False
    End Sub

    Private Sub Button7_MouseHover(sender As Object, e As EventArgs) Handles Button7.MouseHover
        Label23.Visible = True
    End Sub

    Private Sub Button7_MouseLeave(sender As Object, e As EventArgs) Handles Button7.MouseLeave
        Label23.Visible = False
    End Sub

    Private Sub Button8_MouseHover(sender As Object, e As EventArgs) Handles Button8.MouseHover
        Label24.Visible = True
    End Sub

    Private Sub Button8_MouseLeave(sender As Object, e As EventArgs) Handles Button8.MouseLeave
        Label24.Visible = False
    End Sub

    Private Sub Button9_MouseHover(sender As Object, e As EventArgs) Handles Button9.MouseHover
        Label25.Visible = True
    End Sub

    Private Sub Button9_MouseLeave(sender As Object, e As EventArgs) Handles Button9.MouseLeave
        Label25.Visible = False
    End Sub

    Private Sub Button10_MouseHover(sender As Object, e As EventArgs) Handles Button10.MouseHover
        Label26.Visible = True
    End Sub

    Private Sub Button10_MouseLeave(sender As Object, e As EventArgs) Handles Button10.MouseLeave
        Label26.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (TextBox1.Text = "") Then
            MessageBox.Show("Please enter the registration number", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from NewStudents where RegNo='" + TextBox1.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader
            If (sdr.Read()) Then
                Dim r As DialogResult
                r = MessageBox.Show("Delete " & (sdr.GetValue("0").ToString) & ", " & (sdr.GetValue("1").ToString) & " from database", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If r = DialogResult.Yes Then
                    con.Close()
                    con.Open()
                    cmd = New SqlCommand("delete from NewStudents where RegNo='" + TextBox1.Text + "'", con)
                    Dim i As Integer = cmd.ExecuteNonQuery
                    If i > 0 Then
                        MessageBox.Show("Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    lod()
                End If
            Else
                MessageBox.Show("Invalid registration number", "Information")
            End If
            con.Close()
            bindgrid1()
            bindgrid2()
            lod()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (TextBox1.Text = "") Then
            MessageBox.Show("Please enter the registration number", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from Student where RegNo='" + TextBox1.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader
            If (sdr.Read()) Then
                Dim r As DialogResult
                r = MessageBox.Show("Delete " & (sdr.GetValue("0").ToString) & ", " & (sdr.GetValue("1").ToString) & " from database", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If r = DialogResult.Yes Then
                    con.Close()
                    con.Open()
                    cmd = New SqlCommand("delete from Student where RegNo='" + TextBox1.Text + "'", con)
                    Dim i As Integer = cmd.ExecuteNonQuery
                    If i > 0 Then
                        MessageBox.Show("Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    lod()
                End If
            Else
                MessageBox.Show("Invalid registration number", "Information")
            End If
            con.Close()
            bindgrid1()
            bindgrid2()
            lod()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox8.Text = "" Then
            MessageBox.Show("Please enter the registration number", "Information")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select RegNo,Name,Email,PhNo,Course,Gender,Yoj,Address from NewStudents where RegNo='" + TextBox8.Text + "'", con)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            sda.Fill(dt)
            If dt.Rows.Count > 0 Then
                DataGridView1.DataSource = dt
            Else
                MessageBox.Show("No Student found in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If TextBox10.Text = "" Then
            MessageBox.Show("Please enter the registration number", "Information")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select RegNo,Name,Email,PhNo,Course,Gender,Yoj,Address from Student where RegNo='" + TextBox10.Text + "'", con)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            sda.Fill(dt)
            If dt.Rows.Count > 0 Then
                DataGridView2.DataSource = dt
            Else
                MessageBox.Show("No Student found in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If TextBox7.Text = "" Then
            MessageBox.Show("Please enter the Name of student", "Information")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select RegNo,Name,Email,PhNo,Course,Gender,Yoj,Address from NewStudents where Name like '%" & TextBox7.Text & "%'", con)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            sda.Fill(dt)
            If dt.Rows.Count > 0 Then
                DataGridView1.DataSource = dt
            Else
                MessageBox.Show("No Student found in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If TextBox9.Text = "" Then
            MessageBox.Show("Please enter the Name of student", "Information")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select RegNo,Name,Email,PhNo,Course,Gender,Yoj,Address from Student where Name like '%" & TextBox9.Text & "%'", con)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            sda.Fill(dt)
            If dt.Rows.Count > 0 Then
                DataGridView2.DataSource = dt
            Else
                MessageBox.Show("No Student found in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" And ComboBox1.SelectedIndex = -1 And ComboBox2.SelectedIndex = -1 And TextBox5.Text = "" And TextBox6.Text = "") Then
            MessageBox.Show("Please enter all the details", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("select * from NewStudents where RegNo='" + TextBox1.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader
            If sdr.Read() Then
                con.Close()
                con.Open()
                cmd = New SqlCommand("update NewStudents set Name='" + TextBox2.Text + "', Email='" + TextBox3.Text + "', PhNo='" + TextBox4.Text + "',Course='" + ComboBox1.SelectedItem + "',Gender='" + ComboBox2.SelectedItem + "',Yoj='" + TextBox5.Text + "',Address='" + TextBox6.Text + "' where RegNo='" + TextBox1.Text + "'", con)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    MessageBox.Show("Data updated in New Student database")
                    bindgrid1()
                End If
            Else
                MessageBox.Show("No student details found with Reg.No.=" & TextBox1.Text & " " & ControlChars.NewLine & "in New Student database.", "Error")
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If (TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" And ComboBox1.SelectedIndex = -1 And ComboBox2.SelectedIndex = -1 And TextBox5.Text = "" And TextBox6.Text = "") Then
            MessageBox.Show("Please enter all the details", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("select * from Student where RegNo='" + TextBox1.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader
            If sdr.Read() Then
                con.Close()
                con.Open()
                cmd = New SqlCommand("update Student set Name='" + TextBox2.Text + "', Email='" + TextBox3.Text + "', PhNo='" + TextBox4.Text + "',Course='" + ComboBox1.SelectedItem + "',Gender='" + ComboBox2.SelectedItem + "',Yoj='" + TextBox5.Text + "',Address='" + TextBox6.Text + "' where RegNo='" + TextBox1.Text + "'", con)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    MessageBox.Show("Data updated in Student database")
                    bindgrid2()
                End If
            Else
                MessageBox.Show("No student details found with Reg.No.=" & TextBox1.Text & " " & ControlChars.NewLine & "in Student database.", "Error")
            End If
            con.Close()
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim an As String = "0123456789"
            If Not an.Contains(e.KeyChar.ToString) Then
                MessageBox.Show("Please enter the numbers only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim an As String = "0123456789"
            If Not an.Contains(e.KeyChar.ToString) Then
                MessageBox.Show("Please enter the numbers only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim ac As String = "abcdefghijklmnopqrstuvwxyz"
            If Not ac.Contains(e.KeyChar.ToString.ToLower) Then
                MessageBox.Show("Please enter the alphabets only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim ac As String = "abcdefghijklmnopqrstuvwxyz"
            Dim an As String = "0123456789"
            Dim asc As String = "@."
            If Not ac.Contains(e.KeyChar.ToString.ToLower) And Not an.Contains(e.KeyChar.ToString) And Not asc.Contains(e.KeyChar.ToString) Then
                MessageBox.Show("Please enter valid email id", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If (TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" And ComboBox1.SelectedIndex = -1 And ComboBox2.SelectedIndex = -1 And TextBox5.Text = "" And TextBox6.Text = "") Then
            MessageBox.Show("Please enter all the details", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("select * from LeftStudent where RegNo='" + TextBox1.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader
            If sdr.Read() Then
                MessageBox.Show(TextBox1.Text & "'s data alredy in old student's database", "Inforamtion")
            Else
                con.Close()
                con.Open()
                cmd = New SqlCommand("select * from Student where RegNo='" + TextBox1.Text + "'", con)
                sdr = cmd.ExecuteReader
                If sdr.Read() Then
                    con.Close()
                    con.Open()
                    Dim r As DialogResult
                    r = MessageBox.Show("Move " & TextBox1.Text & " data to old student's database." & ControlChars.NewLine & "It will delete " & TextBox1.Text & " data from current student database.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    If r = DialogResult.OK Then
                        cmd = New SqlCommand("insert into LeftStudent select * from Student where RegNo='" + TextBox1.Text + "'", con)
                        Dim i As Integer = cmd.ExecuteNonQuery
                        If i > 0 Then
                            con.Close()
                            con.Open()
                            cmd = New SqlCommand("Delete From Student where RegNo='" + TextBox1.Text + "'", con)
                            Dim j As Integer = cmd.ExecuteNonQuery
                            If j > 0 Then
                                MessageBox.Show("Data moved to old student databse.")
                                bindgrid2()
                            End If
                        End If
                        End If
                Else
                    MessageBox.Show(TextBox1.Text & "'s data is not avialabel in current student's databse", "Inforamtion")
                End If
            End If
            con.Close()
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Form9.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox2.MouseHover
        Label27.Visible = True
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        Label27.Visible = False
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Form6_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form4.Show()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox6.Text = "" Or TextBox11.Text = "" Or TextBox12.Text = "" Or ComboBox1.SelectedIndex = -1 Or ComboBox2.SelectedIndex = -1 Or ComboBox3.SelectedIndex = -1 Then
            MessageBox.Show("Please enter al the details.")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from NewStudents where RegNo='" + TextBox1.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader
            If sdr.Read() Then
                MessageBox.Show("Data already exixts in new student database")
            Else
                con.Close()
                con.Open()
                cmd = New SqlCommand("insert into NewStudents values(@RegNo,@Name,@Email,@PhNo,@Course,@Gender,@Yoj,@Address,@Sq,@Sa,@Password)", con)
                cmd.Parameters.AddWithValue("RegNo", TextBox1.Text)
                cmd.Parameters.AddWithValue("Name", TextBox2.Text)
                cmd.Parameters.AddWithValue("Email", TextBox3.Text)
                cmd.Parameters.AddWithValue("PhNo", TextBox4.Text)
                cmd.Parameters.AddWithValue("Course", ComboBox1.SelectedItem)
                cmd.Parameters.AddWithValue("Gender", ComboBox2.SelectedItem)
                cmd.Parameters.AddWithValue("Yoj", TextBox5.Text)
                cmd.Parameters.AddWithValue("Address", TextBox6.Text)
                cmd.Parameters.AddWithValue("Sq", ComboBox3.SelectedItem)
                cmd.Parameters.AddWithValue("Sa", TextBox11.Text)
                cmd.Parameters.AddWithValue("Password", TextBox12.Text)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    MessageBox.Show("Details added to NewStudents")
                End If
                con.Close()
                lod()
                bindgrid1()
            End If
        End If
    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim ac As String = "abcdefghijklmnopqrstuvwxyz"
            If Not ac.Contains(e.KeyChar.ToString.ToLower) Then
                MessageBox.Show("Please enter the alphabets only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim ac As String = "abcdefghijklmnopqrstuvwxyz"
            If Not ac.Contains(e.KeyChar.ToString.ToLower) Then
                MessageBox.Show("Please enter the alphabets only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox8_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyUp
        If TextBox8.Text = "" Then
            lod()
        End If
    End Sub

    Private Sub TextBox7_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyUp
        If TextBox7.Text = "" Then
            lod()
        End If
    End Sub

    Private Sub TextBox10_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox10.KeyUp
        If TextBox10.Text = "" Then
            lod()
        End If
    End Sub

    Private Sub TextBox9_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox9.KeyUp
        If TextBox9.Text = "" Then
            lod()
        End If
    End Sub
End Class