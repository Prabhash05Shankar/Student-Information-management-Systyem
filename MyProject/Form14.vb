Imports System.Data
Imports System.Data.SqlClient
Public Class Form14
    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select * from Student where RegNo='" + Form1.TextBox1.Text + "'", con)
        Dim sdr As SqlDataReader = cmd.ExecuteReader
        sdr.Read()
        Label1.Text = sdr.GetValue("0").ToString
        con.Close()
        Label27.Visible = False
        bindgrid()
    End Sub

    Private Sub bindgrid()
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select * from Feed where RegNo='" + Label1.Text + "'", con)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)
        DataGridView1.DataSource = dt
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please enter your query.")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from Feed where RegNo='" + Label1.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            If sdr.Read() Then
                MessageBox.Show("You can raise one query at a time.")
            Else
                con.Close()
                con.Open()
                cmd = New SqlCommand("Insert into Feed values(@RegNo,@Query,@Reply)", con)
                cmd.Parameters.AddWithValue("RegNo", Label1.Text)
                cmd.Parameters.AddWithValue("Query", TextBox1.Text)
                cmd.Parameters.AddWithValue("Reply", TextBox2.Text)
                Dim i As Integer = cmd.ExecuteNonQuery()
                If i > 0 Then
                    MessageBox.Show("Your query has been raised." & ControlChars.NewLine & " Please wait for admin reply")
                    TextBox1.Clear()
                    bindgrid()
                End If
            End If
            con.Close()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox2.MouseHover
        Label27.Visible = True
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        Label27.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        bindgrid()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please select your query")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from Feed where RegNo='" + Label1.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader
            If sdr.Read() Then
                con.Close()
                con.Open()
                cmd = New SqlCommand("Delete from Feed where RegNo='" + Label1.Text + "'", con)
                Dim i As Integer = cmd.ExecuteNonQuery()
                If i > 0 Then
                    MessageBox.Show("Your Query has been deleted.")
                    bindgrid()
                Else
                    MessageBox.Show("Error")
                End If
            Else
                MessageBox.Show("No data found")
            End If
            con.Close()
            TextBox1.Clear()
            TextBox2.Clear()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim c As Integer
        c = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(1, c).Value
        TextBox2.Text = DataGridView1.Item(2, c).Value
    End Sub

    Private Sub Form14_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form10.Show()
    End Sub
End Class