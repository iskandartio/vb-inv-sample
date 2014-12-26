Public Class FormSellList
    Public key As Integer
    Private Function properCase(ByVal s As String)
        Dim z() As String = s.Split("_")
        Dim r As String = ""
        For Each a As String In z
            If r <> "" Then
                r &= " "
            End If
            r &= a.Substring(0, 1).ToUpper() & a.Substring(1)
        Next
        Return r
    End Function
    Public Sub showData()
        Dim sql As String
        Dim filter As String = ""
        params.Clear()
        params.Add("start_date", start_date.Value)
        params.Add("end_date", end_date.Value)
        params.Add("customer_name", "%" & filterCustomer.Text & "%")

        params.Add("sell_date", start_date)
        sql = "select a.sell_id, a.sell_code, a.sell_date, b.customer_name, c.total from test_sell a left join test_customer b on a.customer_id=b.customer_id"
        sql &= " left join (select sell_id, sum(qty*price) total from test_sell_detail group by sell_id) c on c.sell_id=a.sell_id"
        sql &= " where a.sell_date between @start_date and @end_date and b.customer_name like @customer_name"
        sql &= " order by sell_code desc"
        DataGridView1.DataSource = dbModule.doQuery(sql)
        DataGridView1.ReadOnly = True
        formatGrid("sell_date", "Date")
        formatGrid("total", "Decimal")
        DataGridView1.Columns("sell_id").Visible = False
        For Each col As DataGridViewColumn In DataGridView1.Columns
            col.HeaderText = properCase(col.HeaderText)
        Next
    End Sub

    Private Sub formatGrid(ByVal col_name As String, ByVal type As String)
        If type = "Integer" Then
            DataGridView1.Columns(col_name).DefaultCellStyle.Format = "#,##0"
            DataGridView1.Columns(col_name).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(col_name).Width = 50
            Exit Sub
        End If
        If type = "Decimal" Then
            DataGridView1.Columns(col_name).DefaultCellStyle.Format = "#,##0.00"
            DataGridView1.Columns(col_name).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(col_name).Width = 100
            Exit Sub
        End If
        If type = "Date" Then
            DataGridView1.Columns(col_name).DefaultCellStyle.Format = "dd-MM-yyyy"
            DataGridView1.Columns(col_name).Width = 80
            Exit Sub
        End If

    End Sub
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        key = DataGridView1.Rows(e.RowIndex).Cells("sell_id").Value
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        showData()
    End Sub

End Class