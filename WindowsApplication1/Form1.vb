
Public Class Form1
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        dbModule.execMe("create table test(test_id int auto_increment primary key, test_code varchar(50), test_name varchar(50))")
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        params.Clear()
        params.Add("test_code", txtTestCode.Text)
        Dim dt As DataTable = dbModule.doQuery("select * from test")
        DataGridView1.DataSource = dt
    End Sub

    Private Sub btnSelectParam_Click(sender As Object, e As EventArgs) Handles btnSelectParam.Click
        Dim db As New dbClass

        params.Clear()
        params.Add("test_code", txtTestCode.Text)
        Dim dt As DataTable = dbModule.doQuery("select * from test where test_code=@test_code")
        DataGridView1.DataSource = dt
    End Sub

    Private Sub btnDropTableTest_Click(sender As Object, e As EventArgs) Handles btnDropTableTest.Click
        Dim db As New dbClass
        dbModule.execMe("drop table test")
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim db As New dbClass
        params.Clear()
        params.Add("test_code", txtInput.Text)
        params.Add("test_name", txtName.Text)
        dbModule.execMe("insert into test(test_code, test_name) values(@test_code, @test_name)")

    End Sub

    Private Sub btnInsertFail_Click(sender As Object, e As EventArgs) Handles btnInsertFail.Click
        Dim db As New dbClass
        params.Clear()
        dbModule.beginTrans()
        params.Add("test_code", txtInput1.Text)
        params.Add("test_name", txtName1.Text)
        dbModule.execMe("insert into test(test_code, test_name) values(@test_code, @test_name)")
        params.Clear()
        params.Add("test_code", txtInput2.Text)
        params.Add("test_name", txtName2.Text)
        dbModule.execMe("insert into test(test_code, test_name) values(@test_code, @test_name)")
        dbModule.rollBackTrans()
    End Sub

    Private Sub btnInsertTransaction_Click(sender As Object, e As EventArgs) Handles btnInsertTransaction.Click
        Dim db As New dbClass
        params.Clear()
        dbModule.beginTrans()
        params.Add("test_code", txtInput1.Text)
        params.Add("test_name", txtName1.Text)
        dbModule.execMe("insert into test(test_code, test_name) values(@test_code, @test_name)")
        params.Clear()
        params.Add("test_code", txtInput2.Text)
        params.Add("test_name", txtName2.Text)
        dbModule.execMe("insert into test(test_code, test_name) values(@test_code, @test_name)")
        dbModule.commitTrans()
    End Sub

    Private Sub btnTruncateTableTest_Click(sender As Object, e As EventArgs) Handles btnTruncateTableTest.Click
        Dim db As New dbClass
        dbModule.execMe("truncate table test")
    End Sub
End Class
