Imports System.Data
Imports System.Data.SqlClient
Public Class Form16
    Private Sub Form16_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lod()
        binddata()
        binddata2()
        binddata3()
    End Sub

    Private Sub lod()
        Label23.Visible = False
        Label9.Visible = False
        Label27.Visible = False
        Label18.Visible = False
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
    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim an As String = "0123456789"
            If Not an.Contains(e.KeyChar.ToString) Then
                MessageBox.Show("Please enter the numbers only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim an As String = "0123456789"
            If Not an.Contains(e.KeyChar.ToString) Then
                MessageBox.Show("Please enter the numbers only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button7_MouseHover(sender As Object, e As EventArgs) Handles Button7.MouseHover
        Label23.Visible = True
    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Label9.Visible = True
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Label9.Visible = False
    End Sub

    Private Sub Button7_MouseLeave(sender As Object, e As EventArgs) Handles Button7.MouseLeave
        Label23.Visible = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        If CheckBox1.Checked = True And CheckBox2.Checked = False Then
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from MarksEntry where RegNo='" + TextBox9.Text + "'", con)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            sda.Fill(dt)
            DataGridView3.DataSource = dt
            con.Close()
        ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True Then
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from MarksEntry where SubCod='" + TextBox10.Text + "'", con)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            sda.Fill(dt)
            DataGridView3.DataSource = dt
            con.Close()
        ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True Then
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from MarksEntry where RegNo='" + TextBox9.Text + "' and SubCod='" + TextBox10.Text + "'", con)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            sda.Fill(dt)
            DataGridView3.DataSource = dt
            con.Close()
        Else
            MessageBox.Show("Plese select one of the option.")
        End If
    End Sub

    Private Sub binddata3()
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select * from MarksEntry", con)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)
        DataGridView3.DataSource = dt
        con.Close()
    End Sub

    Private Sub binddata2()
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select RegNo,Name,Course,Gender,Yoj from Student", con)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)
        DataGridView2.DataSource = dt
        con.Close()
    End Sub

    Private Sub binddata()
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select SubCod,SubName,Department,Semester from Subject", con)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)
        DataGridView1.DataSource = dt
        con.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please enter the registraion number.")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select RegNo,Name,Course,Gender,Yoj from Student where RegNo='" + TextBox1.Text + "'", con)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("Please enter the subject name.")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select SubCod,SubName,Department,Semester from Subject where SubCod='" + TextBox2.Text + "'", con)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            sda.Fill(dt)
            If dt.Rows.Count > 0 Then
                DataGridView2.DataSource = dt
            Else
                MessageBox.Show("No Subject details found in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            con.Close()
        End If
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        If TextBox1.Text = "" Then
            binddata()
        End If
    End Sub

    Private Sub TextBox2_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyUp
        If TextBox2.Text = "" Then
            binddata2()
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Then
            MessageBox.Show("Please enter all the details.")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from MarksEntry where RegNo='" + TextBox3.Text + "' and SubCod='" + TextBox4.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader
            If sdr.Read() Then
                MessageBox.Show("Entry already exist in databse with Reg.No.: " & TextBox3.Text & " and Sub.Code: " & TextBox4.Text & ".", "Information")
            Else
                con.Close()
                con.Open()
                cmd = New SqlCommand("insert into MarksEntry values('" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox11.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox12.Text + "')", con)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    MessageBox.Show("Entry added")
                    binddata3()
                Else
                    MessageBox.Show("Error")
                End If
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Then
            MessageBox.Show("Please enter all the details.")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from MarksEntry where RegNo='" + TextBox3.Text + "' and SubCod='" + TextBox4.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader
            If sdr.Read() Then
                con.Close()
                con.Open()
                cmd = New SqlCommand("update MarksEntry set MarksOb='" + TextBox6.Text + "', FullMarks='" + TextBox7.Text + "', Grade='" + TextBox8.Text + "',Remarks='" + TextBox12.Text + "' where RegNo='" + TextBox3.Text + "' and SubCod='" + TextBox4.Text + "'", con)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    MessageBox.Show("Marks updated.")
                Else
                    MessageBox.Show("Error")
                End If
            Else
                MessageBox.Show("No marks details found with RegNo='" & TextBox3.Text & "' and Subject Code='" & TextBox4.Text & "'")
            End If
            con.Close()
            binddata3()
            lod()
        End If
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Label18.Visible = True
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Label18.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Please enter the registration number and subject code.")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from MarksEntry where RegNo='" + TextBox3.Text + "' and Subcod='" + TextBox4.Text + "'", con)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            If sdr.Read() Then
                con.Close()
                con.Open()
                cmd = New SqlCommand("delete from MarksEntry where RegNo='" + TextBox3.Text + "' and SubCod='" + TextBox4.Text + "'", con)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    MessageBox.Show("Marks Deleted.")
                    lod()
                    binddata3()
                Else
                    MessageBox.Show("Error")
                End If
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        lod()
        binddata()
        binddata2()
        binddata3()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim n As Integer = TextBox6.Text
        Dim m As Integer = TextBox7.Text
        If Not n < m Then
            MessageBox.Show("Marks obtain is greater then Full marks.", "Error")
        Else
            Dim m1 As Integer = TextBox6.Text
            Dim m2 As Integer = TextBox7.Text
            Dim g As Decimal = (m1 / m2) * 100
            Select Case g
                Case 96 To 100
                    TextBox8.Text = 10
                Case 91 To 95
                    TextBox8.Text = 9.5
                Case 86 To 90
                    TextBox8.Text = 9.0
                Case 81 To 85
                    TextBox8.Text = 8.5
                Case 76 To 80
                    TextBox8.Text = 8.0
                Case 71 To 75
                    TextBox8.Text = 7.5
                Case 66 To 70
                    TextBox8.Text = 7.0
                Case 61 To 65
                    TextBox8.Text = 6.5
                Case 56 To 60
                    TextBox8.Text = 6.0
                Case 51 To 55
                    TextBox8.Text = 5.5
                Case 46 To 50
                    TextBox8.Text = 5.0
                Case 41 To 45
                    TextBox8.Text = 4.5
                Case 40
                    TextBox8.Text = 4.0
                Case 0 To 40
                    TextBox8.Text = 0
            End Select
            If TextBox8.Text < 4 Then
                TextBox12.Text = "Fail"
            Else
                TextBox12.Text = "Pass"
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox4.Text = DataGridView1.Item(0, i).Value
        TextBox5.Text = DataGridView1.Item(1, i).Value
        TextBox11.Text = DataGridView1.Item(3, i).Value
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Dim i As Integer
        i = DataGridView2.CurrentRow.Index
        TextBox3.Text = DataGridView2.Item(0, i).Value
    End Sub

    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        Dim i As Integer
        i = DataGridView3.CurrentRow.Index
        TextBox3.Text = DataGridView3.Item(0, i).Value
        TextBox4.Text = DataGridView3.Item(1, i).Value
        TextBox5.Text = DataGridView3.Item(2, i).Value
        TextBox11.Text = DataGridView3.Item(3, i).Value
        TextBox6.Text = DataGridView3.Item(4, i).Value
        TextBox7.Text = DataGridView3.Item(5, i).Value
        TextBox8.Text = DataGridView3.Item(6, i).Value
        TextBox12.Text = DataGridView3.Item(7, i).Value
    End Sub

    Private Sub Form16_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form4.Show()
    End Sub
End Class