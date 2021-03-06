﻿Imports System.Data.OleDb
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Data
Public Class Form_Students ' Created by: Joshua C. Magoliman
    Public Sub GetData()
        Objects.da = New OleDbDataAdapter()
        Objects.dt = New DataTable()
        Objects.ds = New DataSet()
        Try
            con.Open()
            da = New OleDbDataAdapter("vWGetAllStudents", con)
            da.SelectCommand.CommandType = CommandType.TableDirect
            da.Fill(ds)
            dgvStudents.DataSource = ds.Tables(0)
            dgvStudents.Columns(8).Visible = False
            dgvStudents.Columns(0).Width = 200
            dgvStudents.Columns(1).Width = 200
            dgvStudents.Columns(2).Width = 200
            dgvStudents.Columns(3).Width = 200
            dgvStudents.Columns(4).Width = 100
            dgvStudents.Columns(5).Width = 130
            dgvStudents.Columns(6).Width = 60
            dgvStudents.Columns(7).Width = 400
            da.Update(dt)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
            txtSearch.Text = ""
        End Try
        lblTotal.Text = "TOTAL ENTRY: " + dgvStudents.RowCount.ToString
    End Sub
    Private Sub Form_Students_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()
        cmbboxFilter.Text = "None"
    End Sub
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        cmbboxFilter.Text = "None"
        Form_Main.Show()
    End Sub
    Private Sub btnAddNewStudent_Click(sender As Object, e As EventArgs) Handles btnAddNewStudent.Click
        Form_AddNewStudent.Show()
        Form_AddNewStudent.txtLastName.Focus()
        Me.Hide()
    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Objects.da = New OleDbDataAdapter()
        Objects.dt = New DataTable()
        Objects.ds = New DataSet()
        If txtSearch.Text = "" Then
            GetData()
        ElseIf cmbboxFilter.Text = "Student ID" Then
            con.Open()
            da = New OleDbDataAdapter("spGetStudentByStudentId", con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@studentId", "%" & txtSearch.Text & "%")
            da.Fill(ds)
            dgvStudents.DataSource = ds.Tables(0)
            dgvStudents.Columns(8).Visible = False
            dgvStudents.Columns(0).Width = 200
            dgvStudents.Columns(1).Width = 200
            dgvStudents.Columns(2).Width = 200
            dgvStudents.Columns(3).Width = 200
            dgvStudents.Columns(4).Width = 100
            dgvStudents.Columns(5).Width = 130
            dgvStudents.Columns(6).Width = 60
            dgvStudents.Columns(7).Width = 400
        ElseIf cmbboxFilter.Text = "Last Name" Then
            con.Open()
            da = New OleDbDataAdapter("spGetStudentByLastName", con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@lastname", "%" & txtSearch.Text & "%")
            da.Fill(ds)
            dgvStudents.DataSource = ds.Tables(0)
            dgvStudents.Columns(8).Visible = False
            dgvStudents.Columns(0).Width = 200
            dgvStudents.Columns(1).Width = 200
            dgvStudents.Columns(2).Width = 200
            dgvStudents.Columns(3).Width = 200
            dgvStudents.Columns(4).Width = 100
            dgvStudents.Columns(5).Width = 130
            dgvStudents.Columns(6).Width = 60
            dgvStudents.Columns(7).Width = 400
        ElseIf cmbboxFilter.Text = "Given Name" Then
            con.Open()
            da = New OleDbDataAdapter("spGetStudentByGivenName", con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@givenname", "%" & txtSearch.Text & "%")
            da.Fill(ds)
            dgvStudents.DataSource = ds.Tables(0)
            dgvStudents.Columns(8).Visible = False
            dgvStudents.Columns(0).Width = 200
            dgvStudents.Columns(1).Width = 200
            dgvStudents.Columns(2).Width = 200
            dgvStudents.Columns(3).Width = 200
            dgvStudents.Columns(4).Width = 100
            dgvStudents.Columns(5).Width = 130
            dgvStudents.Columns(6).Width = 60
            dgvStudents.Columns(7).Width = 400
        ElseIf cmbboxFilter.Text = "Middle Name" Then
            con.Open()
            da = New OleDbDataAdapter("spGetStudentByMiddleName", con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@middlename", "%" & txtSearch.Text & "%")
            da.Fill(ds)
            dgvStudents.DataSource = ds.Tables(0)
            dgvStudents.Columns(8).Visible = False
            dgvStudents.Columns(0).Width = 200
            dgvStudents.Columns(1).Width = 200
            dgvStudents.Columns(2).Width = 200
            dgvStudents.Columns(3).Width = 200
            dgvStudents.Columns(4).Width = 100
            dgvStudents.Columns(5).Width = 130
            dgvStudents.Columns(6).Width = 60
            dgvStudents.Columns(7).Width = 400
        ElseIf cmbboxFilter.Text = "Gender" Then
            con.Open()
            da = New OleDbDataAdapter("spGetStudentByGender", con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@gender", txtSearch.Text & "%")
            da.Fill(ds)
            dgvStudents.DataSource = ds.Tables(0)
            dgvStudents.Columns(8).Visible = False
            dgvStudents.Columns(0).Width = 200
            dgvStudents.Columns(1).Width = 200
            dgvStudents.Columns(2).Width = 200
            dgvStudents.Columns(3).Width = 200
            dgvStudents.Columns(4).Width = 100
            dgvStudents.Columns(5).Width = 130
            dgvStudents.Columns(6).Width = 60
            dgvStudents.Columns(7).Width = 400
        ElseIf cmbboxFilter.Text = "Date of Birth" Then
            con.Open()
            da = New OleDbDataAdapter("spGetStudentByDateOfBirth", con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@dateofbirth", "%" & txtSearch.Text & "%")
            da.Fill(ds)
            dgvStudents.DataSource = ds.Tables(0)
            dgvStudents.Columns(8).Visible = False
            dgvStudents.Columns(0).Width = 200
            dgvStudents.Columns(1).Width = 200
            dgvStudents.Columns(2).Width = 200
            dgvStudents.Columns(3).Width = 200
            dgvStudents.Columns(4).Width = 100
            dgvStudents.Columns(5).Width = 130
            dgvStudents.Columns(6).Width = 60
            dgvStudents.Columns(7).Width = 400
        ElseIf cmbboxFilter.Text = "Age" Then
            con.Open()
            da = New OleDbDataAdapter("spGetStudentByAge", con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@age", "%" & txtSearch.Text & "%")
            da.Fill(ds)
            dgvStudents.DataSource = ds.Tables(0)
            dgvStudents.Columns(8).Visible = False
            dgvStudents.Columns(0).Width = 200
            dgvStudents.Columns(1).Width = 200
            dgvStudents.Columns(2).Width = 200
            dgvStudents.Columns(3).Width = 200
            dgvStudents.Columns(4).Width = 100
            dgvStudents.Columns(5).Width = 130
            dgvStudents.Columns(6).Width = 60
            dgvStudents.Columns(7).Width = 400
        ElseIf cmbboxFilter.Text = "Address" Then
            con.Open()
            da = New OleDbDataAdapter("spGetStudentByAddress", con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@address", "%" & txtSearch.Text & "%")
            da.Fill(ds)
            dgvStudents.DataSource = ds.Tables(0)
            dgvStudents.Columns(8).Visible = False
            dgvStudents.Columns(0).Width = 200
            dgvStudents.Columns(1).Width = 200
            dgvStudents.Columns(2).Width = 200
            dgvStudents.Columns(3).Width = 200
            dgvStudents.Columns(4).Width = 100
            dgvStudents.Columns(5).Width = 130
            dgvStudents.Columns(6).Width = 60
            dgvStudents.Columns(7).Width = 400
        End If
        con.Close()
        lblTotal.Text = "TOTAL ENTRY:" + dgvStudents.RowCount.ToString
    End Sub
    Private Sub cmbboxFilter_Leave(sender As Object, e As EventArgs) Handles cmbboxFilter.Leave
        If cmbboxFilter.Text = "" Then
            GetData()
            cmbboxFilter.Text = "None"
            txtSearch.Clear()
        End If
    End Sub
    Private Sub dgvStudents_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudents.CellClick
        con.Open()
        Dim row As DataGridViewRow = dgvStudents.CurrentRow
        Try
            Me.Enabled = False
            Form_Profile.Show()
            Form_Profile.lblTitle.Focus()
            btnBack.Visible = False
            Form_Profile.txtStudentId.Text = row.Cells(0).Value.ToString()
            Form_Profile.txtLastName.Text = row.Cells(1).Value.ToString()
            Form_Profile.txtGivenName.Text = row.Cells(2).Value.ToString()
            Form_Profile.txtMiddleName.Text = row.Cells(3).Value.ToString()
            Dim gettingGender As String
            gettingGender = row.Cells("Gender").Value.ToString
            If gettingGender = "Male" Then
                Form_Profile.radiobtnMale.Checked = True
            ElseIf gettingGender = "Female" Then
                Form_Profile.radiobtnFemale.Checked = True
            End If
            Form_Profile.dtpDateOfBirth.Value = row.Cells(5).Value.ToString()
            Form_Profile.txtAge.Text = row.Cells(6).Value.ToString()
            Form_Profile.txtAddress.Text = row.Cells(7).Value.ToString()
            Dim arrImage As Byte() = row.Cells("photo").Value
            Dim mstream As New MemoryStream(arrImage)
            Form_Profile.pictureboxProfile.Image = Image.FromStream(mstream)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        Dim stringHolder As String = cmbboxFilter.Text
        Select Case stringHolder
            Case "None"
                If Char.IsLetterOrDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case "Student ID"
                If Char.IsLetterOrDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case "Last Name"
                If Char.IsLetter(e.KeyChar) Or Char.IsControl(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case "Given Name"
                If Char.IsLetter(e.KeyChar) Or Char.IsControl(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case "Middle Name"
                If Char.IsLetter(e.KeyChar) Or Char.IsControl(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case "Gender"
                If Char.IsLetter(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case "Date of Birth"
                If Char.IsLetterOrDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case "Age"
                If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
        End Select
    End Sub
End Class
