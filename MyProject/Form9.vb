Imports System.Data
Imports System.Data.SqlClient
Public Class Form9

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lod()
        bindgrid()
    End Sub

    Private Sub lod()
        Label23.Visible = False
        Label24.Visible = False
        Label27.Visible = False
        Label6.Visible = False
        TextBox7.Clear()
        TextBox8.Clear()
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
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select RegNo,Name,Email,PhNo,Course,Gender,Yoj,Address from LeftStudent", con)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)
        DataGridView1.DataSource = dt
        con.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox8.Text = "" Then
            MessageBox.Show("Please enter the registration number", "Information")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select RegNo,Name,Email,PhNo,Course,Gender,Yoj,Address from LeftStudent where RegNo='" + TextBox8.Text + "'", con)
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

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If TextBox7.Text = "" Then
            MessageBox.Show("Please enter the Name", "Information")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select RegNo,Name,Email,PhNo,Course,Gender,Yoj,Address from LeftStudent where Name like '%" & TextBox7.Text & "%'", con)
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

    Private Sub TextBox8_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyUp
        If TextBox8.Text = "" Then
            bindgrid()
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

    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox2.MouseHover
        Label27.Visible = True
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        Label27.Visible = False
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        Label6.Visible = True
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        Label6.Visible = False
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox8.Text = "" Then
            MessageBox.Show("Please enter the Registraion Number")
        Else
            Dim r As DialogResult
            r = MessageBox.Show("Retrive Reg.No.= " & TextBox8.Text & " to current student database?", "Retrive data?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If r = DialogResult.Yes Then
                Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
                con.Open()
                Dim cmd As SqlCommand = New SqlCommand("select * from Student where RegNo='" + TextBox8.Text + "'", con)
                Dim sdr As SqlDataReader = cmd.ExecuteReader
                If (sdr.Read()) Then
                    MessageBox.Show("Registraion Number already exits in the database", "Error")
                Else
                    con.Close()
                    con.Open()
                    cmd = New SqlCommand("insert into Student select * from LeftStudent where RegNo='" + TextBox8.Text + "'", con)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    If i > 0 Then
                        MessageBox.Show("Entry added", "Sucessful")
                        con.Close()
                        con.Open()
                        cmd = New SqlCommand("delete from LeftStudent where RegNo='" + TextBox8.Text + "'", con)
                        cmd.ExecuteNonQuery()
                    End If
                End If
                con.Close()
                lod()
                bindgrid()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        lod()
        bindgrid()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim c As Integer
        c = DataGridView1.CurrentRow.Index
        TextBox7.Text = DataGridView1.Item(1, c).Value
        TextBox8.Text = DataGridView1.Item(0, c).Value
    End Sub

    Private Sub Form9_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form4.Show()
    End Sub
End Class