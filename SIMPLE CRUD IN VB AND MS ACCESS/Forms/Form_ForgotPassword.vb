﻿Imports System.Data.OleDb
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Configuration
Public Class Form_ForgotPassword ' Created by: Joshua C. Magoliman
    Private Sub Form_ForgotPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Focus()
        txtUsername.MaxLength = 12
        txtSecretAnswer.MaxLength = 12
    End Sub
    Private Sub Form_ForgotPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnShowPassword.PerformClick()
        End If
    End Sub
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        txtUsername.Text = ""
        cmbboxSecretQuestion.Text = ""
        txtSecretAnswer.Text = ""
        txtShowPassword.Text = ""
        Form_Login.txtUsername.Text = ""
        Form_Login.txtPassword.Text = ""
        Form_Login.Show()
        Form_Login.txtUsername.Focus()
        Me.Hide()
    End Sub
    Private Sub btnShowPassword_Click(sender As Object, e As EventArgs) Handles btnShowPassword.Click
        If txtUsername.Text = "" And cmbboxSecretQuestion.Text = "" And txtSecretAnswer.Text = "" Then
            MsgBox("Fill up account details", MsgBoxStyle.Critical, "ATTENTION")
        ElseIf txtUsername.Text = "" Then
            MsgBox("No Username Found!", MsgBoxStyle.Critical, "ATTENTION")
        ElseIf cmbboxSecretQuestion.Text = "" Then
            MsgBox("No Secret Question Found!", MsgBoxStyle.Critical, "ATTENTION")
        ElseIf txtSecretAnswer.Text = "" Then
            MsgBox("No Secret Answer Found!", MsgBoxStyle.Critical, "ATTENTION")
        Else
            Try
                con.Open()
                cmd = New OleDbCommand("SELECT [password] FROM [tbl_Users] WHERE [username]=@username AND StrComp(secret_question,@secretquestion,0) = 0 AND StrComp(secret_answer,@secretanswer,0) = 0;", con)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add(New OleDbParameter("@username", txtUsername.Text))
                cmd.Parameters.Add(New OleDbParameter("@secretquestion", cmbboxSecretQuestion.Text))
                cmd.Parameters.Add(New OleDbParameter("@secretanswer", txtSecretAnswer.Text))
                dr = cmd.ExecuteReader()
                If dr.Read Then
                    txtShowPassword.Text = dr("password").ToString
                    txtShowPassword.Enabled = True
                Else
                    MsgBox("Your details was invalid!", MsgBoxStyle.Critical, "Error")
                    txtShowPassword.Enabled = False
                    txtShowPassword.Clear()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            Finally
                con.Close()
            End Try
        End If
    End Sub
    Private Sub chckboxSecretAnswer_CheckedChanged(sender As Object, e As EventArgs) Handles chckboxSecretAnswer.CheckedChanged
        If chckboxSecretAnswer.Checked = False Then
            txtSecretAnswer.UseSystemPasswordChar = True
        Else
            txtSecretAnswer.UseSystemPasswordChar = False
        End If
        lblUsername.Focus()
    End Sub
    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        con.Open()
        cmd = New OleDbCommand("SELECT * FROM [tbl_Users] WHERE [username]=@username ", con)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add(New OleDbParameter("@username", txtUsername.Text))
        dr = cmd.ExecuteReader()
        If dr.Read Then
            cmbboxSecretQuestion.Text = dr("secret_question").ToString
        Else
            cmbboxSecretQuestion.Text = ""
        End If
        con.Close()
    End Sub
    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtSecretAnswer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSecretAnswer.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class