Imports MySql.Data.MySqlClient
Public Class Form1
    Public conn As New MySqlConnection("Server=localhost; User Id=root1; Password=''; Database=db_vbcrud1")
    Public adapter As New MySqlDataAdapter
    Public command As New MySqlCommand
    Dim ds As DataSet

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetRecords()
    End Sub

    Public Sub GetRecords()
        ds = New DataSet
        adapter = New MySqlDataAdapter("select * from tbl_names", conn)
        adapter.Fill(ds, "tbl_names")

        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "tbl_names"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ds = New DataSet
        adapter = New MySqlDataAdapter("insert into tbl_names (firstname) VALUES ('" & TextBox1.Text & "')", conn)
        adapter.Fill(ds, "tbl_names")

        TextBox1.Clear()
        Label2.Text = ""
        GetRecords()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Label2.Text = DataGridView1.Item(0, i).Value
        TextBox1.Text = DataGridView1.Item(1, i).Value
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ds = New DataSet
        adapter = New MySqlDataAdapter("update tbl_names set firstname = '" & TextBox1.Text & "' where id = " & Label2.Text, conn)
        adapter.Fill(ds, "tbl_names")

        TextBox1.Clear()
        Label2.Text = ""
        GetRecords()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        ds = New DataSet
        adapter = New MySqlDataAdapter("delete from tbl_names where id = " & DataGridView1.Item(0, i).Value, conn)
        adapter.Fill(ds, "tbl_names")

        GetRecords()
    End Sub
End Class
