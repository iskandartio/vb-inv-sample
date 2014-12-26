Imports MySql.Data.MySqlClient
Imports System.Data.Common
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data.SqlClient


Module dbModule
    Public dbType As DbProviderType = DbProviderType.MySQL
    Public params As New Dictionary(Of String, Object)
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


        Dim conn As Common.DbConnection = objDbProviderFactory.CreateConnection
        conn.ConnectionString = My.Settings.ConnectionString
        conn.Open()

        Return conn
    End Function

    Public Function doQuery(ByVal sql As String) As DataTable
        Dim command As DbCommand
        Dim conn As DbConnection
        If Not tr Is Nothing Then
            conn = tr.Connection
            command = conn.CreateCommand
            command.Connection = tr.Connection
        Else
            conn = connect()
            command = conn.CreateCommand
        End If

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
        End If

        Return dt
    End Function

    Public Function execMe(sql As String) As Integer
        Dim command As DbCommand
        Dim conn As DbConnection
        If Not tr Is Nothing Then
            conn = tr.Connection
            command = conn.CreateCommand

        Else
            conn = connect()
            command = conn.CreateCommand
        End If
        command.CommandText = sql

        If Not tr Is Nothing Then
            command.Transaction = tr
        End If
        If (Not params Is Nothing) Then
            For Each key As String In params.Keys
                Dim p As DbParameter = command.CreateParameter()
                p.ParameterName = key
                p.Value = params(key)
                command.Parameters.Add(p)
            Next

        End If

        Dim i = command.ExecuteNonQuery()
        If sql.StartsWith("insert") Then
            sql = "select last_insert_id()"
            Dim dt2 As DataTable = dbModule.doQuery(sql)
            Return dt2(0)(0)

        End If
        If tr Is Nothing Then
            conn.Close()
        End If
        Return i
    End Function

    Public Sub beginTrans()
        Dim conn = connect()
        tr = conn.BeginTransaction()

    End Sub
    Public Sub commitTrans()
        tr.Commit()
        tr.Connection.Close()
        tr = Nothing
    End Sub
    Public Sub rollBackTrans()
        tr.Rollback()
        tr.Connection.Close()
        tr = Nothing
    End Sub

End Module
