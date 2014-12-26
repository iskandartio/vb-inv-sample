Imports System.Windows.Forms

Public Class MDIParent1

    
    Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem.Click
        FormCustomer.MdiParent = Me
        FormCustomer.Show()

    End Sub

    Private Sub StockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockToolStripMenuItem.Click
        FormStock.MdiParent = Me
        FormStock.Show()
    End Sub

    Private Sub SellToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SellToolStripMenuItem.Click
        Dim f As New FormSell
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub MDIParent1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "create table if not exists test_sell(sell_id int auto_increment primary key, sell_code varchar(50), sell_date datetime, customer_id int)"
        dbModule.execMe(sql)
        sql = "create table if not exists test_sell_detail(sell_detail_id int auto_increment primary key, sell_id int, stock_id int, qty int, price double)"
        dbModule.execMe(sql)
        dbModule.execMe("create table if not exists test_customer(customer_id int auto_increment primary key, customer_name varchar(50))")
        dbModule.execMe("create table if not exists test_stock(stock_id int auto_increment primary key, stock_name varchar(50))")
    End Sub
End Class
