Imports System.Data
Imports System.Data.SqlClient
Public Class Form4
    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select * from Admin where Id='" + Form1.TextBox1.Text + "'", con)
        Dim sdr As SqlDataReader = cmd.ExecuteReader
        sdr.Read()
        Label1.Text = "Welcome, " & sdr.GetValue("1").ToString
        con.Close()
    End Sub

    Private Sub ReturnToLoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToLoginToolStripMenuItem.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub ExitAplicationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitAplicationToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Form4_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to close the application", "Exit?", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If
    End Sub

    Private Sub StudentDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentDetailsToolStripMenuItem.Click
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub TeacherDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeacherDetailsToolStripMenuItem.Click
        Form7.Show()
        Me.Hide()
    End Sub

    Private Sub MarksEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarksEntryToolStripMenuItem.Click
        Form8.Show()
        Me.Hide()
    End Sub

    Private Sub StudentQueriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentQueriesToolStripMenuItem.Click
        Form15.Show()
        Me.Hide()
    End Sub

    Private Sub MarksEntryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MarksEntryToolStripMenuItem1.Click
        Form16.Show()
        Me.Hide()
    End Sub
End Class