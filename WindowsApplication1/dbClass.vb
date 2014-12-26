Imports MySql.Data.MySqlClient
Imports System.Data.Common
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class dbClass
    Private dbType As DbProviderType = DbProviderType.MySQL
    Private conn As Common.DbConnection
    Private tr As Common.DbTransaction
    
    Public Enum DbProviderType
        SqlServer = 1
        OleDb
        ODBC
        MySQL
    End Enum

    Private Function connect() As DbConnection
        Dim objDbProviderFactory As DbProviderFactory = Nothing
        If dbType = DbProviderType.MySQL Then
            objDbProviderFactory = MySqlClientFactory.Instance
        ElseIf dbType = DbProviderType.ODBC Then
            objDbProviderFactory = OdbcFactory.Instance
        ElseIf dbType = DbProviderType.OleDb Then
            objDbProviderFactory = OleDbFactory.Instance
        ElseIf dbType = DbProviderType.SqlServer Then
            objDbProviderFactory = SqlClientFactory.Instance
        End If
        conn = objDbProviderFactory.CreateConnection
        conn.ConnectionString = My.Settings.ConnectionString
        conn.Open()
        Return conn
    End Function

    Public Function doQuery(ByVal sql As String, Optional ByVal params As Dictionary(Of String, Object) = Nothing) As DataTable
        Dim command As DbCommand
        If conn Is Nothing Then
            conn = connect()
        End If
        command = conn.CreateCommand
        command.CommandText = sql
        If (Not params Is Nothing) Then
            For Each key As String In params.Keys
                Dim p As DbParameter = command.CreateParameter()
                p.ParameterName = key
                p.Value = params(key)
                command.Parameters.Add(p)
            Next
        End If
        Dim dt As New DataTable
        dt.Load(command.ExecuteReader())
        If tr Is Nothing Then
            conn.Close()
            conn = Nothing
        End If
        Return dt
    End Function

    Public Function execMe(sql As String, Optional ByVal params As Dictionary(Of String, Object) = Nothing) As Integer
        Dim command As DbCommand
        If conn Is Nothing Then
            conn = connect()
        End If
        command = conn.CreateCommand
        command.CommandText = sql
        If (Not params Is Nothing) Then
            For Each key As String In params.Keys
                Dim p As DbParameter = command.CreateParameter()
                p.ParameterName = key
                p.Value = params(key)
                command.Parameters.Add(p)
            Next

        End If

        Dim i = command.ExecuteNonQuery()

        If tr Is Nothing Then
            conn.Close()
            conn = Nothing
        End If
        Return i
    End Function

    Public Sub beginTrans()
        conn = connect()
        tr = conn.BeginTransaction()
    End Sub
    Public Sub commitTrans()
        tr.Commit()
        conn.Close()
        tr = Nothing
        conn = Nothing
    End Sub
    Public Sub rollBackTrans()
        tr.Rollback()
        conn.Close()
        tr = Nothing
        conn = Nothing
    End Sub

End Class
