Public Class FormSell
    Private mdt As DataTable
    Private mdtDetail As DataTable
    Private stocks As String()
    Private WithEvents t_stock_id As New TextBox
    Private sell_id As Integer

    Private Sub FormSell_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim mdtStock As DataTable = dbModule.doQuery("select stock_id, stock_name from test_stock order by stock_name")
            ReDim stocks(mdtStock.Rows.Count - 1)
            Dim i As Integer
            For Each row As DataRow In mdtStock.Rows
                stocks(i) = row("stock_name")
                i += 1
            Next
            
            Dim dt As DataTable = dbModule.doQuery("select * from test_customer order by customer_name")
            customer_id.DisplayMember = "customer_name"
            customer_id.ValueMember = "customer_id"
            customer_id.DataSource = dt
            newData()
            txtTotal.TextAlign = HorizontalAlignment.Right
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub bindAll(arr As String())
        For Each a As String In arr
            If TypeName(Me.Controls(a)) = "TextBox" Then
                Dim t As TextBox = CType(Me.Controls(a), TextBox)
                t.DataBindings.Clear()
                t.DataBindings.Add("Text", mdt, a)
            ElseIf TypeName(Me.Controls(a)) = "DateTimePicker" Then
                Dim t As DateTimePicker = CType(Me.Controls(a), DateTimePicker)
                t.DataBindings.Clear()
                t.DataBindings.Add("Value", mdt, a)
            ElseIf TypeName(Me.Controls(a)) = "ComboBox" Then
                Dim t As ComboBox = CType(Me.Controls(a), ComboBox)
                t.DataBindings.Clear()
                t.DataBindings.Add("SelectedValue", mdt, a)
            End If
        Next

    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        newData()
    End Sub
    Private Sub newData()
        Dim new_code As Integer
        Dim sql As String = ""
        sell_id = 0
        sql = "select max(sell_code) sell_code from test_sell"
        Dim dt As DataTable = dbModule.doQuery(sql)
        If IsDBNull(dt(0)(0)) Then
            new_code = 1
        Else
            new_code = dt(0)(0) + 1
        End If
        txtSearch.Text = new_code
        mdt = getSellBySellCode("")
        mdt.Rows.Add()
        mdt.Rows(0)("sell_code") = Format(new_code, "00000")
        mdt.Rows(0)("sell_date") = Now
        bind()

        showDetail()
        
    End Sub
    Private Function getDetail()
        Dim sql As String
        sql = "select a.sell_detail_id, b.stock_name, a.qty, a.price, a.qty*a.price total from test_sell_detail a"
        sql &= " left join test_stock b on b.stock_id=a.stock_id"
        sql &= " where a.sell_id=@sell_id"
        params.Clear()
        params.Add("sell_id", sell_id)
        Return dbModule.doQuery(sql)

    End Function
    Private Function getSellBySellCode(Optional ByVal sell_code As String = "-1")
        Dim sql As String
        sql = "select a.sell_id, a.sell_code, a.sell_date, a.customer_id from test_sell a"
        sql &= " where a.sell_code=@sell_code"
        params.Clear()
        params.Add("sell_code", sell_code)
        Return dbModule.doQuery(sql)

    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sql As String = ""
        Try
            dbModule.beginTrans()
            params.Clear()
            params.Add("customer_id", mdt(0)("customer_id"))
            params.Add("sell_code", mdt(0)("sell_code"))
            params.Add("sell_date", mdt(0)("sell_date"))
            params.Add("sell_id", sell_id)
            If sell_id = 0 Then
                sql = "insert into test_sell(sell_code, sell_date, customer_id) values(@sell_code, @sell_date, @customer_id)"
                sell_id = dbModule.execMe(sql)
                
            Else
                sql = "update test_sell set sell_code=@sell_code, sell_date=@sell_date, customer_id=@customer_id where sell_id=@sell_id"
                dbModule.execMe(sql)
            End If



            Dim dt As New DataTable
            dt = mdtDetail.GetChanges()
            If Not dt Is Nothing Then
                For Each row As DataRow In dt.Rows
                    If row.RowState <> DataRowState.Deleted Then
                        Dim stock_id As Integer
                        stock_id = getStockId(row("stock_name"))
                        If stock_id = 0 Then
                            Throw New Exception(row("stock_name") & " not exists")
                        End If
                        params.Clear()
                        params.Add("sell_id", sell_id)
                        params.Add("stock_id", stock_id)
                        params.Add("qty", row("qty"))
                        params.Add("price", row("price"))
                        params.Add("sell_detail_id", row("sell_detail_id"))
                        If row.RowState = DataRowState.Added Then
                            dbModule.execMe("insert into test_sell_detail(sell_id, stock_id, qty, price) values(@sell_id, @stock_id, @qty, @price)")
                        Else
                            dbModule.execMe("update test_sell_detail set stock_id=@stock_id, qty=@qty, price=@price where sell_detail_id=@sell_detail_id")
                        End If
                    Else
                        params.Clear()
                        params.Add("sell_detail_id", row("sell_detail_id", DataRowVersion.Original))
                        dbModule.execMe("delete from test_sell_detail where sell_detail_id=@sell_detail_id")
                    End If
                    
                Next
            End If
            
            dbModule.commitTrans()
            mdt.AcceptChanges()
            MsgBox("Success")
        Catch ex As Exception
            MsgBox(ex.Message)
            dbModule.rollBackTrans()
        End Try
            

    End Sub
    Private Function getStockId(ByVal stockName As String)
        params.Clear()
        params.Add("stock_name", stockName)
        Dim dt = dbModule.doQuery("select stock_id from test_stock where stock_name=@stock_name")
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0)

        End If
        Return 0
    End Function

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        countTotal()
    End Sub
    Private Sub countTotal()
        Dim total As Double = 0
        If DataGridView1.CurrentRow Is Nothing Then
            Return
        End If
        DataGridView1.CurrentRow.Cells("total").Value = 0
        If Not IsDBNull(DataGridView1.CurrentRow.Cells("qty").Value) And Not IsDBNull(DataGridView1.CurrentRow.Cells("price").Value) Then
            DataGridView1.CurrentRow.Cells("total").Value = DataGridView1.CurrentRow.Cells("qty").Value * DataGridView1.CurrentRow.Cells("price").Value
        End If
        For Each row As DataGridViewRow In DataGridView1.Rows
            total += row.Cells("total").Value
        Next
        txtTotal.Text = Format(total, "#,##0.00")
    End Sub
    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        Dim idx = DataGridView1.CurrentCell.ColumnIndex
        Dim controlName = DataGridView1.Columns(idx).DataPropertyName
        If controlName = "stock_name" Then
            t_stock_id = e.Control
            t_stock_id.AutoCompleteSource = AutoCompleteSource.CustomSource
            t_stock_id.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Dim source = New AutoCompleteStringCollection()
            source.AddRange(stocks)
            t_stock_id.AutoCompleteCustomSource = source
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search(Integer.Parse(txtSearch.Text))
    End Sub
    Private Sub search(ByVal i As Integer)
        txtSearch.Text = i
        mdt = getSellBySellCode(Format(i, "00000"))
        If mdt.Rows.Count = 0 Then
            newData()
        Else
            sell_id = mdt(0)("sell_id")
            bind()
            showDetail()
        End If
    End Sub
    Private Sub showDetail()
        mdtDetail = getDetail()
        DataGridView1.DataSource = mdtDetail
        DataGridView1.Columns("sell_detail_id").Visible = False

        formatGrid("qty", "Integer")
        formatGrid("price", "Decimal")
        formatGrid("total", "Decimal")
        DataGridView1.Columns("total").ReadOnly = True
        For Each col As DataGridViewColumn In DataGridView1.Columns
            col.HeaderText = properCase(col.HeaderText)
        Next
        countTotal()
    End Sub
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
    Private Sub bind()
        bindAll({"sell_code", "sell_date", "customer_id"})
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Dim i As Integer = Integer.Parse(txtSearch.Text)
        If i = 1 Then Return
        search(i - 1)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim i As Integer = Integer.Parse(txtSearch.Text)
        search(i + 1)
    End Sub

    Private Sub btnList_Click(sender As Object, e As EventArgs) Handles btnList.Click
        Dim f As New FormSellList
        f.showData()
        If f.ShowDialog = Windows.Forms.DialogResult.OK Then
            search(f.key)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            dbModule.beginTrans()
            params.Clear()
            params.Add("sell_id", sell_id)
            dbModule.execMe("delete from test_sell where sell_id=@sell_id")
            dbModule.execMe("delete from test_sell_detail where sell_id=@sell_id")
            dbModule.commitTrans()
            MsgBox("Success")
            search(sell_id - 1)
        Catch ex As Exception
            MsgBox(ex.Message)


        End Try
        
    End Sub
End Class