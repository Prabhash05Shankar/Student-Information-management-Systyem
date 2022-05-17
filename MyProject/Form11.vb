Imports System.Data
Imports System.Data.SqlClient
Public Class Form11
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

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
        Label23.Visible = False
        Label24.Visible = False
        Label27.Visible = False
        bindgrid()
    End Sub

    Private Sub bindgrid()
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select Id,Name,Email,PhNo,Dob,Gender,Address,JobStatus,Qualification,SubAssign from Teacher where Dep='" + Label18.Text + "'", con)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)
        DataGridView1.DataSource = dt
        con.Close()
    End Sub

    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox2.MouseHover
        Label27.Visible = True
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        Label27.Visible = False
    End Sub

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select * from Student where RegNo='" + Form1.TextBox1.Text + "'", con)
        Dim sdr As SqlDataReader = cmd.ExecuteReader
        sdr.Read()
        Label18.Text = sdr.GetValue("4").ToString
        con.Close()
        lod()
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
        TextBox6.Text = DataGridView1.Item(8, c).Value
        TextBox9.Text = DataGridView1.Item(9, c).Value
        Dim j As String = DataGridView1.Item(7, c).Value
        If j = "Part-Time" Then
            RadioButton1.Checked = True
            RadioButton2.Checked = False
        Else
            RadioButton1.Checked = False
            RadioButton2.Checked = True
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox7.Text = "" Then
            MessageBox.Show("Please enter subject name.")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from Teacher where SubAssign like '%" + TextBox7.Text + "%'", con)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            sda.Fill(dt)
            If dt.Rows.Count > 0 Then
                DataGridView1.DataSource = dt
            Else
                MessageBox.Show("No data found", "Inforamtion")
            End If
            con.Close()
        End If
    End Sub

    Private Sub TextBox7_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyUp
        If TextBox7.Text = "" Then
            lod()
        End If
    End Sub

    Private Sub Button7_MouseHover(sender As Object, e As EventArgs) Handles Button7.MouseHover
        Label23.Visible = True
    End Sub

    Private Sub Button7_MouseLeave(sender As Object, e As EventArgs) Handles Button7.MouseLeave
        Label23.Visible = False
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If TextBox8.Text = "" Then
            MessageBox.Show("Please enter teacher Name.")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from Teacher where Name like '%" & TextBox8.Text & "%'", con)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
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
        End If
    End Sub

    Private Sub Button8_MouseHover(sender As Object, e As EventArgs) Handles Button8.MouseHover
        Label24.Visible = True
    End Sub

    Private Sub Button8_MouseLeave(sender As Object, e As EventArgs) Handles Button8.MouseLeave
        Label24.Visible = False
    End Sub

    Private Sub Form11_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form10.Show()
    End Sub
End Class