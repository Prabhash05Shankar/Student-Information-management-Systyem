Imports System.Data
Imports System.Data.SqlClient
Public Class Form5
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bindgrid()
        datalod()
        deflod()
    End Sub
    Private Sub bindgrid()
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select Id,Name,Email,Pno from Admin where Id='" + Form1.TextBox1.Text + "'", con)
        cmd.CommandType = CommandType.Text
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)
        DataGridView1.DataSource = dt
        con.Close()
    End Sub
    Private Sub datalod()
        TextBox1.Text = DataGridView1.Item(0, 0).Value
        TextBox2.Text = DataGridView1.Item(1, 0).Value
        TextBox3.Text = DataGridView1.Item(2, 0).Value
        TextBox4.Text = DataGridView1.Item(3, 0).Value
    End Sub
    Private Sub deflod()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        Label9.Visible = False
        Label27.Visible = False
        TextBox5.Visible = False
        TextBox5.Clear()
        Button1.Visible = False
        Button2.Visible = True
        Button3.Visible = True
        LinkLabel2.Visible = True
        LinkLabel3.Visible = False
        Panel2.Visible = True
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel2.Visible = False
        Panel3.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox5.Text = "" Then
            MessageBox.Show("Please enter the password")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("update Admin set Name='" + TextBox2.Text + "',Email='" + TextBox3.Text + "',Pno='" + TextBox4.Text + "'where Id='" + TextBox1.Text + "' and Password='" + TextBox5.Text + "'", con)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                MessageBox.Show("Data updated")
                bindgrid()
                datalod()
                deflod()
            Else
                MessageBox.Show("Invalid password")
                TextBox5.Clear()
            End If
            con.Close()
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        Button1.Visible = True
        TextBox5.Visible = True
        Label9.Visible = True
        Button2.Visible = False
        Button3.Visible = False
        LinkLabel2.Visible = False
        LinkLabel3.Visible = True
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        bindgrid()
        datalod()
        deflod()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select * from Admin where Id='" + TextBox6.Text + "' and Password='" + TextBox7.Text + "'", con)
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        If (sdr.Read()) Then
            MessageBox.Show("Verification completed", "Information")
            Panel4.Visible = True
            Panel3.Visible = False
        Else
            MessageBox.Show("Invalid Id or Password", "Information")
        End If
        con.Close()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox8.Text = TextBox9.Text Then
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Update Admin set Password='" + TextBox8.Text + "' where Id='" + TextBox6.Text + "'", con)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MessageBox.Show("Password updated", "Information")
                deflod()
                datalod()
            Else
                MessageBox.Show("Error")
            End If
            con.Close()
        Else
            MessageBox.Show("Password missmatch", "Information")
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        datalod()
        deflod()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        datalod()
        deflod()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel5.Visible = True
        Panel2.Visible = False
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim r As DialogResult
        r = MessageBox.Show("Your account will be permanently deleted", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        If r = DialogResult.Cancel Then
            deflod()
            datalod()
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Delete from Admin where Id='" + TextBox11.Text + "' and Password='" + TextBox10.Text + "'", con)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                MessageBox.Show("Your Account has been Deleted. We hope to see you again." & ControlChars.NewLine & " " & ControlChars.NewLine & "All the best" & ControlChars.NewLine & "SSS team", "GoodBye", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Form1.Show()
                Me.Close()
            Else
                MessageBox.Show("Invalid Id or Password", "Error")
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        datalod()
        deflod()
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

    Private Sub Form5_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form4.Show()
    End Sub
End Class