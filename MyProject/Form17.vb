Imports System.Data
Imports System.Data.SqlClient
Public Class Form17
    Private Sub Form17_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datalod()
        Label27.Visible = False
    End Sub

    Private Sub datalod()
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select * from Student where RegNo='" + Form1.TextBox1.Text + "'", con)
        Dim sdr As SqlDataReader = cmd.ExecuteReader
        sdr.Read()
        Label9.Text = sdr.GetValue("0").ToString
        Label10.Text = sdr.GetValue("1").ToString
        Label11.Text = sdr.GetValue("2").ToString
        Label12.Text = sdr.GetValue("4").ToString
        con.Close()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Please select your semester.")
        Else
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select SubCod,Subject,MarksOb,FullMarks,Grade,Remarks from MarksEntry where RegNo='" + Label9.Text + "' and Semester='" + ComboBox1.SelectedItem + "'", con)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            sda.Fill(dt)
            DataGridView1.DataSource = dt
            con.Close()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        PrintPreviewDialog1.ShowDialog()
        PrintDocument1.Print()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
        e.Graphics.DrawString("Marks Sheet", New Font("Britannic", 25, FontStyle.Bold), Brushes.Black, New Point(300, 50))
        e.Graphics.DrawString("Name: " + Label10.Text, New Font("Britannic", 14, FontStyle.Regular), Brushes.Black, New Point(55, 150))
        e.Graphics.DrawString("Reg.No.: " + Label9.Text, New Font("Britannic", 14, FontStyle.Regular), Brushes.Black, New Point(550, 150))
        e.Graphics.DrawString("Email: " + Label11.Text, New Font("Britannic", 14, FontStyle.Regular), Brushes.Black, New Point(55, 180))
        e.Graphics.DrawString("Course: " + Label12.Text, New Font("Britannic", 14, FontStyle.Regular), Brushes.Black, New Point(550, 180))
        e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------", New Font("Britannic", 14, FontStyle.Regular), Brushes.Black, New Point(30, 200))
        e.Graphics.DrawString(DateTime.Now, New Font("Britannic", 18, FontStyle.Regular), Brushes.Black, New PointF(280, 100))
        DataGridView1.DrawToBitmap(bm, New Rectangle(30, 30, Me.DataGridView1.Width, Me.DataGridView1.Height))
        e.Graphics.DrawImage(bm, 30, 230)
    End Sub

    Private Sub Form17_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form10.Show()
    End Sub
End Class