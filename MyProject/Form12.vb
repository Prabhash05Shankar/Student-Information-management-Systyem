Imports System.Data
Imports System.Data.SqlClient
Public Class Form12
    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bindgrid()
        lod()
    End Sub

    Private Sub lod()
        Label27.Visible = False
        Label12.Visible = False
        LinkLabel1.Visible = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Clear()
        TextBox6.Visible = False
        TextBox7.Enabled = False
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox1.Enabled = False
        ComboBox3.SelectedIndex = -1
        Button1.Visible = True
        Button2.Visible = True
        Button3.Visible = False
        Panel2.Visible = True
        Panel3.Visible = False
        Panel4.Visible = False
        datalod()
    End Sub

    Private Sub bindgrid()
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select RegNo,Name,Email,Phno,Gender,Yoj,Address from Student where RegNo='" + Form1.TextBox1.Text + "'", con)
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
        ComboBox1.SelectedItem = DataGridView1.Item(4, 0).Value
        TextBox5.Text = DataGridView1.Item(5, 0).Value
        TextBox7.Text = DataGridView1.Item(6, 0).Value
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox6.Text = "" Then
            MessageBox.Show("Please enter the password.")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("update Student set Name='" + TextBox2.Text + "',Email='" + TextBox3.Text + "',PhNo='" + TextBox4.Text + "',Gender='" + ComboBox1.SelectedItem + "',Yoj='" + TextBox5.Text + "',Address='" + TextBox7.Text + "' where RegNo='" + TextBox1.Text + "' and Password='" + TextBox6.Text + "'", con)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                MessageBox.Show("Data Updated")
                bindgrid()
                lod()
            Else
                MessageBox.Show("Invalid Password")
                TextBox6.Clear()
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        lod()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        lod()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ComboBox3.SelectedIndex = -1 Or TextBox8.Text = "" Then
            MessageBox.Show("Please enter all the details.")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("select * from Student where Sq='" + ComboBox3.SelectedItem + "' and Sa='" + TextBox8.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            If sdr.Read() Then
                MessageBox.Show("Verification completed", "Information")
                Panel3.Visible = False
                Panel4.Visible = True
            Else
                MessageBox.Show("Invalid details", "Information")
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Then
            MessageBox.Show("Please enter all the details.")
        Else
            If TextBox9.Text = TextBox11.Text Then
                Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
                con.Open()
                Dim cmd As SqlCommand = New SqlCommand("update Student set Password = '" + TextBox9.Text + "' where RegNo='" + TextBox1.Text + "' and Password = '" + TextBox10.Text + "'", con)
                Dim i As Integer = cmd.ExecuteNonQuery()
                If i > 0 Then
                    MessageBox.Show("Password updated", "Information")
                    lod()
                    bindgrid()
                Else
                    MessageBox.Show("Incorrect Password")
                End If
                con.Close()
            Else
                MessageBox.Show("Password missmatch")
            End If
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Panel2.Visible = False
        Panel3.Visible = True
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Button1.Visible = True
        Button2.Visible = True
        lod()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Label12.Visible = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox7.Enabled = True
        TextBox6.Visible = True
        LinkLabel1.Visible = True
        Button3.Visible = True
        Button1.Visible = False
        Button2.Visible = False
        ComboBox1.Enabled = True
    End Sub

    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox2.MouseHover
        Label27.Visible = True
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        Label27.Visible = False
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

    Private Sub Form12_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form10.Show()
    End Sub
End Class