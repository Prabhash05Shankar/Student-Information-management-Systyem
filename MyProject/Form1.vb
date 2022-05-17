Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            Panel3.Visible = True
        Else
            Panel3.Visible = False
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            Panel4.Visible = True
        Else
            Panel4.Visible = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        def_lod()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (RadioButton1.Checked = True And RadioButton2.Checked = False) Then
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from Admin where Id='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader
            If (sdr.Read()) Then
                MessageBox.Show("Welcome, " & (sdr.GetValue("1").ToString) & " to SSS", "Welcome")
                Form3.Show()
                Me.Hide()
            Else
                MessageBox.Show("Invalid ID or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            con.Close()
        ElseIf (RadioButton1.Checked = False And RadioButton2.Checked = True) Then
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from Student where RegNo='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader
            If (sdr.Read()) Then
                MessageBox.Show("Welcome, " & (sdr.GetValue("1").ToString) & " to SSS", "Welcome")
                Form3.Show()
                Me.Hide()
            Else
                con.Close()
                con.Open()
                cmd = New SqlCommand("Select * from NewStudents where RegNo='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'", con)
                sdr = cmd.ExecuteReader
                If sdr.Read() Then
                    MessageBox.Show("Your account is still queued, Please wait for admin aprovel", "Login Failed")
                Else
                    con.Close()
                    con.Open()
                    cmd = New SqlCommand("Select * from LeftStudent where RegNo='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'", con)
                    sdr = cmd.ExecuteReader
                    If sdr.Read() Then
                        MessageBox.Show("You no longer have the access to this application.", "Sorry.")
                    Else
                        MessageBox.Show("Invalid ID or Password", "Login Failed")
                    End If
                End If
            End If
            con.Close()
        Else
            MessageBox.Show("Plese Select one option", "Error")
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form2.Show()
        Me.Hide()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub def_lod()
        RadioButton4.Checked = True
        RadioButton2.Checked = True
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
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        Label28.Visible = False
        Label34.Visible = False
        Label35.Visible = False
        Label36.Visible = False
        Label32.Visible = False
        Panel2.Visible = False
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        def_lod()
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim an As String = "0123456789"
            If Not an.Contains(e.KeyChar.ToString) Then
                MessageBox.Show("Please enter the numbers only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox1.SelectedIndex = -1 Or TextBox13.Text = "" Or TextBox14.Text = "") Then
            MessageBox.Show("Please enter all the details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from Admin where Id = '" + TextBox3.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader
            If (sdr.Read()) Then
                MessageBox.Show("Account alreay created with this ID", "Error")
            Else
                If Not TextBox17.Text = "SSO22\01" Then
                    MessageBox.Show("Enter right Security Key.")
                Else
                    con.Close()
                    con.Open()
                    cmd = New SqlCommand("insert into Admin values(@Id,@Name,@Password,@Secq,@Seca,@Email,@Pno)", con)
                    cmd.Parameters.AddWithValue("Id", TextBox3.Text)
                    cmd.Parameters.AddWithValue("Name", TextBox4.Text)
                    cmd.Parameters.AddWithValue("Password", TextBox5.Text)
                    cmd.Parameters.AddWithValue("Secq", ComboBox1.SelectedItem)
                    cmd.Parameters.AddWithValue("Seca", TextBox6.Text)
                    cmd.Parameters.AddWithValue("Email", TextBox13.Text)
                    cmd.Parameters.AddWithValue("Pno", TextBox14.Text)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    If (i > 0) Then
                        MessageBox.Show("Your Account created", "Welcome")
                    End If
                End If
            End If
            con.Close()
            def_lod()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            Label28.Visible = True
        Else
            Label28.Visible = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            Label1.Visible = True
        Else
            Label1.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (TextBox12.Text = "" Or TextBox11.Text = "" Or TextBox10.Text = "" Or ComboBox2.SelectedIndex = -1 Or TextBox8.Text = "" Or TextBox9.Text = "" Or ComboBox3.SelectedIndex = -1 Or TextBox7.Text = "" Or TextBox15.Text = "" Or TextBox16.Text = "") Then
            MessageBox.Show("Please enter all the detail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from Student where RegNo='" + TextBox12.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader
            If (sdr.Read()) Then
                MessageBox.Show("Account already have been Created with this Registration Number", "Error")
            Else
                con.Close()
                con.Open()
                cmd = New SqlCommand("Select * from NewStudents where RegNo='" + TextBox12.Text + "'", con)
                sdr = cmd.ExecuteReader
                If sdr.Read() Then
                    MessageBox.Show("Account Account already have been Created please wait for admin approvel", "Information")
                Else
                    con.Close()
                    con.Open()
                    cmd = New SqlCommand("Select * from LeftStudent where RegNo='" + TextBox12.Text + "'", con)
                    sdr = cmd.ExecuteReader
                    If sdr.Read() Then
                        MessageBox.Show("Account already have been Created with this Registration Number", "Error")
                    Else
                        con.Close()
                        con.Open()
                        cmd = New SqlCommand("insert into NewStudents values(@RegNo,@Name,@Email,@PhNo,@Course,@Gender,@Yoj,@Address,@Sq,@Sa,@Password)", con)
                        cmd.Parameters.AddWithValue("RegNo", TextBox12.Text)
                        cmd.Parameters.AddWithValue("Name", TextBox11.Text)
                        cmd.Parameters.AddWithValue("Email", TextBox10.Text)
                        cmd.Parameters.AddWithValue("PhNo", TextBox15.Text)
                        cmd.Parameters.AddWithValue("Course", ComboBox2.SelectedItem)
                        cmd.Parameters.AddWithValue("Gender", ComboBox4.SelectedItem)
                        cmd.Parameters.AddWithValue("Yoj", TextBox8.Text)
                        cmd.Parameters.AddWithValue("Address", TextBox16.Text)
                        cmd.Parameters.AddWithValue("Sq", ComboBox3.SelectedItem)
                        cmd.Parameters.AddWithValue("Sa", TextBox7.Text)
                        cmd.Parameters.AddWithValue("Password", TextBox9.Text)
                        Dim i As Integer = cmd.ExecuteNonQuery
                        If (i > 0) Then
                            MessageBox.Show("Your account has been queued, Please wait for admin response.", "Welcome")
                            def_lod()
                        End If
                    End If
                End If
            End If
            con.Close()
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to close the application", "Exit!", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If
    End Sub

    Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox14.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim an As String = "0123456789"
            If Not an.Contains(e.KeyChar.ToString) Then
                MessageBox.Show("Please enter the numbers only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox15.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim an As String = "0123456789"
            If Not an.Contains(e.KeyChar.ToString) Then
                MessageBox.Show("Please enter the numbers only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim ac As String = "abcdefghijklmnopqrstuvwxyz"
            If Not ac.Contains(e.KeyChar.ToString.ToLower) Then
                MessageBox.Show("Please enter the alphabets only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox13.KeyPress
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

    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox10.KeyPress
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

    Private Sub TextBox11_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles TextBox11.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim ac As String = "abcdefghijklmnopqrstuvwxyz"
            If Not ac.Contains(e.KeyChar.ToString.ToLower) Then
                MessageBox.Show("Please enter the alphabets only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Panel2.Visible = True
        Label32.Visible = True
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Panel2.Visible = False
        Label32.Visible = False
    End Sub

    Private Sub PictureBox3_MouseHover(sender As Object, e As EventArgs) Handles PictureBox3.MouseHover
        Label34.Visible = True
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave
        Label34.Visible = False
    End Sub

    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox2.MouseHover
        Label35.Visible = True
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        Label35.Visible = False
    End Sub

    Private Sub PictureBox5_MouseHover(sender As Object, e As EventArgs) Handles PictureBox5.MouseHover
        Label36.Visible = True
    End Sub

    Private Sub PictureBox5_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox5.MouseLeave
        Label36.Visible = False
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Form18.Show()
        Me.Hide()
    End Sub
End Class
