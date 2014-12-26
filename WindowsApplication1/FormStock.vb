Public Class FormStock
    Dim mdt As DataTable



    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim params As New Dictionary(Of String, Object)
        params.Add("stock_name", "%" & txtSearch.Text & "%")
        mdt = dbModule.doQuery("select * from test_stock where stock_name like @stock_name")
        DataGridView1.DataSource = mdt
        DataGridView1.Columns("stock_id").Visible = False
    End Sub


    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        DataGridView1.CurrentCell.Style.BackColor = Color.AliceBlue
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim params As New Dictionary(Of String, Object)
        Dim dt As DataTable = mdt.GetChanges(DataRowState.Added)
        If Not dt Is Nothing Then
            For Each row As DataRow In dt.Rows
                params.Clear()
                params.Add("stock_name", row("stock_name"))
                dbModule.execMe("insert into test_stock(stock_name) values(@stock_name)")
            Next

        End If
        dt = mdt.GetChanges(DataRowState.Modified)
        If Not dt Is Nothing Then
            For Each row As DataRow In dt.Rows
                params.Clear()
                params.Add("stock_name", row("stock_name"))
                params.Add("stock_id", row("stock_id"))
                dbModule.execMe("update test_stock set stock_name=@stock_name where stock_id=@stock_id")
            Next

        End If
        dt = mdt.GetChanges(DataRowState.Deleted)
        If Not dt Is Nothing Then
            For Each row As DataRow In dt.Rows
                params.Clear()
                params.Add("stock_id", row("stock_id", DataRowVersion.Original))
                dbModule.execMe("delete from test_stock where stock_id=@stock_id")
            Next

        End If
        mdt.AcceptChanges()


    End Sub
End Class