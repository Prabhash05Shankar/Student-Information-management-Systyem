Imports System.Data
Imports System.Data.SqlClient
Public Class Form7
    Dim job As String
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim sdr As SqlDataReader
    Dim sda As SqlDataAdapter
    Dim dt As DataTable
    Dim i As Integer

    Private Sub lod()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = True
        DateTimePicker1.ResetText()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        Label23.Visible = False
        Label24.Visible = False
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lod()
        bindgrid()
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

    Private Sub bindgrid()
        con = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("Select * from Teacher", con)
        sda = New SqlDataAdapter(cmd)
        dt = New DataTable()
        sda.Fill(dt)
        DataGridView1.DataSource = dt
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.SelectedIndex = -1 Or TextBox5.Text = "" Or ComboBox2.SelectedIndex = -1 Or TextBox6.Text = "" Or TextBox9.Text = "") Then
            MessageBox.Show("Please enter all the details.")
        Else
            con = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            cmd = New SqlCommand("Select * from Teacher where Id='" + TextBox1.Text + "'", con)
            sdr = cmd.ExecuteReader
            If sdr.Read() Then
                MessageBox.Show("Deatils with Id=" & TextBox1.Text & " already availabel in databse", "Invalid ID")
            Else
                con.Close()
                con.Open()
                cmd = New SqlCommand("Insert into Teacher values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + DateTimePicker1.Value + "','" + ComboBox1.SelectedItem + "','" + TextBox5.Text + "','" + ComboBox2.SelectedItem + "','" + job + "','" + TextBox6.Text + "','" + TextBox9.Text + "')", con)
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MessageBox.Show("Details added to the database.", "Sucessfully Added")
                Else
                    MessageBox.Show("Error")
                End If
                bindgrid()
                lod()
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        lod()
        bindgrid()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        job = "Part-Time"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        job = "Full-Time"
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim c As Integer
        c = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(0, c).Value
        TextBox2.Text = DataGridView1.Item(1, c).Value
        TextBox3.Text = DataGridView1.Item(2, c).Value
        TextBox4.Text = DataGridView1.Item(3, c).Value
        DateTimePicker1.Value = DataGridView1.Item(4, c).Value
        ComboBox1.SelectedItem = DataGridView1.Item(5, c).Value
        TextBox5.Text = DataGridView1.Item(6, c).Value
        ComboBox2.SelectedItem = DataGridView1.Item(7, c).Value
        TextBox6.Text = DataGridView1.Item(9, c).Value
        TextBox9.Text = DataGridView1.Item(10, c).Value
        Dim j As String = DataGridView1.Item(8, c).Value
        If j = "Part-Time" Then
            RadioButton1.Checked = True
            RadioButton2.Checked = False
        Else
            RadioButton1.Checked = False
            RadioButton2.Checked = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.SelectedIndex = -1 Or TextBox5.Text = "" Or ComboBox2.SelectedIndex = -1 Or TextBox6.Text = "" Or TextBox9.Text = "") Then
            MessageBox.Show("Please enter all the details.")
        Else
            con = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            cmd = New SqlCommand("Select * from Teacher where Id='" + TextBox1.Text + "'", con)
            sdr = cmd.ExecuteReader
            If sdr.Read() Then
                con.Close()
                con.Open()
                cmd = New SqlCommand("update Teacher set Name='" + TextBox2.Text + "',Email='" + TextBox3.Text + "',PhNo='" + TextBox4.Text + "',Dob='" + DateTimePicker1.Value + "',Gender='" + ComboBox1.SelectedItem + "',Address='" + TextBox5.Text + "',Dep='" + ComboBox2.SelectedItem + "',JobStatus='" + job + "',Qualification='" + TextBox6.Text + "',SubAssign='" + TextBox9.Text + "' where Id='" + TextBox1.Text + "'", con)
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MessageBox.Show("Data updated.")
                Else
                    MessageBox.Show("Error!")
                End If
                lod()
                bindgrid()
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please enter the Teacher Id.")
        Else
            Dim r As DialogResult
            r = MessageBox.Show("Delete Teacher Id" & TextBox1.Text & " from the database?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If r = DialogResult.Yes Then
                con = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
                con.Open()
                cmd = New SqlCommand("Select * from Teacher where Id='" + TextBox1.Text + "'", con)
                sdr = cmd.ExecuteReader
                If sdr.Read() Then
                    con.Close()
                    con.Open()
                    cmd = New SqlCommand("Delete from Teacher where Id='" + TextBox1.Text + "'", con)
                    i = cmd.ExecuteNonQuery
                    If i > 0 Then
                        MessageBox.Show("Data deleted", "Deleted")
                    End If
                    lod()
                    bindgrid()
                Else
                    MessageBox.Show("No data found in database with teacher Id=" & TextBox1.Text & "")
                End If
                con.Close()
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox7.Text = "" Then
            MessageBox.Show("Please enter teacher Id.")
        Else
            con = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            cmd = New SqlCommand("Select * from Teacher where Id='" + TextBox7.Text + "'", con)
            sda = New SqlDataAdapter(cmd)
            dt = New DataTable()
            sda.Fill(dt)
            If dt.Rows.Count > 0 Then
                DataGridView1.DataSource = dt
            Else
                MessageBox.Show("No data found with Id=" & TextBox7.Text & "", "Inforamtion")
            End If
            con.Close()
        End If
    End Sub

    Private Sub TextBox7_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyUp
        If TextBox7.Text = "" Then
            lod()
            bindgrid()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If TextBox8.Text = "" Then
            MessageBox.Show("Please enter teacher Name.")
        Else
            con = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            cmd = New SqlCommand("Select * from Teacher where Name like '%" & TextBox8.Text & "%'", con)
            sda = New SqlDataAdapter(cmd)
            dt = New DataTable()
            sda.Fill(dt)
            If dt.Rows.Count > 0 Then
                DataGridView1.DataSource = dt
            Else
                MessageBox.Show("No data found with Teacher Name like " & TextBox8.Text & "")
            End If
            con.Close()
        End If
    End Sub

    Private Sub TextBox8_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyUp
        If TextBox8.Text = "" Then
            lod()
            bindgrid()
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

    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox2.MouseHover
        Label27.Visible = True
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        Label27.Visible = False
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub Form7_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form4.Show()
    End Sub
End Class