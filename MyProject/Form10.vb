Imports System.Data
Imports System.Data.SqlClient
Public Class Form10
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select * from Student where RegNo='" + Form1.TextBox1.Text + "'", con)
        Dim sdr As SqlDataReader = cmd.ExecuteReader
        sdr.Read()
        Label1.Text = "Welcome, " & sdr.GetValue("1").ToString
        con.Close()
    End Sub

    Private Sub ProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProfileToolStripMenuItem.Click
        Form12.Show()
        Me.Hide()
    End Sub

    Private Sub ExitToLoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToLoginToolStripMenuItem.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub ExitApplicationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitApplicationToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Form10_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to close the application", "Exit?", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If
    End Sub

    Private Sub TeachersDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeachersDetailsToolStripMenuItem.Click
        Form11.Show()
        Me.Hide()
    End Sub

    Private Sub SubjectsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubjectsToolStripMenuItem.Click
        Form13.Show()
        Me.Hide()
    End Sub

    Private Sub QueryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QueryToolStripMenuItem.Click
        Form14.Show()
        Me.Hide()
    End Sub

    Private Sub MarksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarksToolStripMenuItem.Click
        Form17.Show()
        Me.Hide()
    End Sub
End Class