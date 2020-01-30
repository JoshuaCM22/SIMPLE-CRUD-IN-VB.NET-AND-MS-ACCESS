Imports System.Configuration
Imports System.Data
Imports System.Data.OleDb

Public Module Objects ' Created by: Joshua C. Magoliman
    Public con As New OleDbConnection(ConfigurationManager.ConnectionStrings("DBCS").ConnectionString)
    Public cmd As OleDbCommand
    Public dr As OleDbDataReader

    Public da As OleDbDataAdapter
    Public dt As New DataTable
    Public ds As New DataSet()
End Module
