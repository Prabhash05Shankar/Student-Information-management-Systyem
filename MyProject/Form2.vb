Imports System.Data
Imports System.Data.SqlClient
Public Class Form2
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            Panel2.Visible = True
        Else
            Panel2.Visible = False
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            Panel1.Visible = True
        Else
            Panel1.Visible = False
        End If
    End Sub
    Private Sub defult_lod()
        RadioButton4.Checked = False
        RadioButton3.Checked = True

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        defult_lod()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (RadioButton3.Checked = True And RadioButton4.Checked = False) Then

            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("update Admin set Password='" + TextBox3.Text + "' where Id='" + TextBox1.Text + "' and Seca='" + TextBox2.Text + "'", con)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                MessageBox.Show("Password updated", "Information")
            Else
                MessageBox.Show("Invalid ID or Security details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            con.Close()

        ElseIf (RadioButton3.Checked = False And RadioButton4.Checked = True) Then

            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHASH\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("update Student set Password='" + TextBox9.Text + "' where RegNo='" + TextBox12.Text + "' and Sa='" + TextBox7.Text + "'", con)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                MessageBox.Show("Password updated", "Information")
            Else
                MessageBox.Show("Invalid Registration number or Security details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            con.Close()

        Else
            MessageBox.Show("Please select one of the option", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        clr()
    End Sub
    Private Sub clr()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox7.Clear()
        TextBox12.Clear()
        TextBox9.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.Show()
    End Sub
End Class