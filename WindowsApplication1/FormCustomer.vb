Public Class FormCustomer
    Dim mdt As DataTable

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        params.Clear()
        params.Add("customer_name", "%" & txtSearch.Text & "%")
        mdt = dbModule.doQuery("select * from test_customer where customer_name like @customer_name")
        DataGridView1.DataSource = mdt
        DataGridView1.Columns("customer_id").Visible = False
    End Sub


    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        DataGridView1.CurrentCell.Style.BackColor = Color.AliceBlue
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dt As DataTable = mdt.GetChanges(DataRowState.Added)
        If Not dt Is Nothing Then
            For Each row As DataRow In dt.Rows
                params.Clear()
                params.Add("customer_name", row("customer_name"))
                dbModule.execMe("insert into test_customer(customer_name) values(@customer_name)")
            Next

        End If
        dt = mdt.GetChanges(DataRowState.Modified)
        If Not dt Is Nothing Then
            For Each row As DataRow In dt.Rows
                params.Clear()
                params.Add("customer_name", row("customer_name"))
                params.Add("customer_id", row("customer_id"))
                dbModule.execMe("update test_customer set customer_name=@customer_name where customer_id=@customer_id")
            Next

        End If
        dt = mdt.GetChanges(DataRowState.Deleted)
        If Not dt Is Nothing Then
            For Each row As DataRow In dt.Rows
                params.Clear()
                params.Add("customer_id", row("customer_id", DataRowVersion.Original))
                dbModule.execMe("delete from test_customer where customer_id=@customer_id")
            Next

        End If
        mdt.AcceptChanges()


    End Sub
End Class