Imports System.Data
Imports System.Data.SqlClient
Public Class Form8
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim sdr As SqlDataReader
    Dim sda As SqlDataAdapter
    Dim dt As DataTable
    Dim i As Integer

    Private Sub bindgrid()
        con = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("Select * from Subject", con)
        sda = New SqlDataAdapter(cmd)
        dt = New DataTable()
        sda.Fill(dt)
        DataGridView1.DataSource = dt
        con.Close()
    End Sub

    Private Sub lod()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        Label10.Visible = False
        Label23.Visible = False
        Label24.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.SelectedIndex = -1 Or ComboBox2.SelectedIndex = -1 Then
            MessageBox.Show("Please enter all the details.")
        Else
            con = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            cmd = New SqlCommand("Select * from Subject where SubCod='" + TextBox1.Text + "'", con)
            sdr = cmd.ExecuteReader
            If sdr.Read() Then
                MessageBox.Show("Data already entered with Subject Code: " & TextBox1.Text & ".")
            Else
                con.Close()
                con.Open()
                cmd = New SqlCommand("insert into Subject values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + ComboBox1.SelectedItem + "','" + ComboBox2.SelectedItem + "','" + TextBox3.Text + "')", con)
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MessageBox.Show("Entry Added to database.")
                Else
                    MessageBox.Show("Error")
                End If
                lod()
                bindgrid()
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.SelectedIndex = -1 Or ComboBox2.SelectedIndex = -1 Then
            MessageBox.Show("Please enter all the details.")
        Else
            con = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            cmd = New SqlCommand("Select * from Subject where SubCod='" + TextBox1.Text + "'", con)
            sdr = cmd.ExecuteReader
            If sdr.Read() Then
                con.Close()
                con.Open()
                cmd = New SqlCommand("update Subject set SubName='" + TextBox2.Text + "',Department='" + ComboBox1.SelectedItem + "',Semester='" + ComboBox2.SelectedItem + "',AssignTeacher='" + TextBox3.Text + "' where SubCod='" + TextBox1.Text + "'", con)
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MessageBox.Show("Data updated.")
                Else
                    MessageBox.Show("Error.")
                End If
                lod()
                bindgrid()
            End If
            con.Close()
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please enter the Subject code.")
        Else
            con = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            cmd = New SqlCommand("Select * from Subject where SubCod='" + TextBox1.Text + "'", con)
            sdr = cmd.ExecuteReader
            If sdr.Read() Then
                Dim r As DialogResult
                r = MessageBox.Show("Delete Subject Code:" & TextBox1.Text & " data from Database?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If r = DialogResult.Yes Then
                    con = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
                    con.Open()
                    cmd = New SqlCommand("delete from Subject where SubCod='" + TextBox1.Text + "'", con)
                    i = cmd.ExecuteNonQuery
                    If i > 0 Then
                        MessageBox.Show("Data Deleted.")
                    Else
                        MessageBox.Show("Error.")
                    End If
                    lod()
                    bindgrid()
                End If
            Else
                MessageBox.Show("Invalid SubCod:" & TextBox1.Text & ".")
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        lod()
        bindgrid()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim c As Integer
        c = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(0, c).Value
        TextBox2.Text = DataGridView1.Item(1, c).Value
        ComboBox1.SelectedItem = DataGridView1.Item(2, c).Value
        ComboBox2.SelectedItem = DataGridView1.Item(3, c).Value
        TextBox3.Text = DataGridView1.Item(4, c).Value
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bindgrid()
        lod()
    End Sub

    Private Sub Button8_MouseHover(sender As Object, e As EventArgs) Handles Button8.MouseHover
        Label23.Visible = True
    End Sub

    Private Sub Button8_MouseLeave(sender As Object, e As EventArgs) Handles Button8.MouseLeave
        Label23.Visible = False
    End Sub

    Private Sub Button7_MouseHover(sender As Object, e As EventArgs) Handles Button7.MouseHover
        Label24.Visible = True
    End Sub

    Private Sub Button7_MouseLeave(sender As Object, e As EventArgs) Handles Button7.MouseLeave
        Label24.Visible = False
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If TextBox8.Text = "" Then
            MessageBox.Show("Please enter the Subject Code.")
        Else
            con = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            cmd = New SqlCommand("Select * from Subject where SubCod='" + TextBox8.Text + "'", con)
            sda = New SqlDataAdapter(cmd)
            dt = New DataTable()
            sda.Fill(dt)
            If dt.Rows.Count > 0 Then
                DataGridView1.DataSource = dt
            Else
                MessageBox.Show("No Subject found in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox7.Text = "" Then
            MessageBox.Show("Please enter the Subject Name.")
        Else
            con = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            cmd = New SqlCommand("Select * from Subject where SubName like '%" & TextBox7.Text & "%'", con)
            sda = New SqlDataAdapter(cmd)
            dt = New DataTable()
            sda.Fill(dt)
            If dt.Rows.Count > 0 Then
                DataGridView1.DataSource = dt
            Else
                MessageBox.Show("No Subject found in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub TextBox8_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyUp
        If TextBox8.Text = "" Then
            lod()
            bindgrid()
        End If
    End Sub

    Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub PictureBox2_MouseHover_1(sender As Object, e As EventArgs) Handles PictureBox2.MouseHover
        Label10.Visible = True
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        Label10.Visible = False
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim ac As String = "abcdefghijklmnopqrstuvwxyz. "
            If Not ac.Contains(e.KeyChar.ToString.ToLower) Then
                MessageBox.Show("Please enter the alphabets only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Form8_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form4.Show()
    End Sub
End Class