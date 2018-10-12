Imports System.Data.SqlClient
Public Class Form1
    Dim bentuk As String

    Private Sub ListView()
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        LV1.View = View.Details
        LV1.Columns.Add("No", 50)
        LV1.Columns.Add("Nama Pelaksana", 150)
        LV1.Columns.Add("Bidang", 100)
        LV1.Columns.Add("Jml Permintaan", 150)
        LV1.Columns.Add("Bentuk Dana", 100)
        LV1.Columns.Add("Keperluan", 200)

        Try
            Call OpenKoneksi()
            Dim query_id As String = "select * from Pengajuan"
            cmd = New SqlCommand(query_id, conn)
            dr = cmd.ExecuteReader
            Do While dr.Read
                LV1.Items.Add(dr("idPengajuan"))
                LV1.Items(LV1.Items.Count - 1).SubItems.Add(dr("NamaPegajuan"))
                LV1.Items(LV1.Items.Count - 1).SubItems.Add(dr("Bidang"))
                LV1.Items(LV1.Items.Count - 1).SubItems.Add(dr("JmlPermintaan"))
                LV1.Items(LV1.Items.Count - 1).SubItems.Add(dr("BentukDana"))
                LV1.Items(LV1.Items.Count - 1).SubItems.Add(dr("Keperluan"))
            Loop
            dr.Close()
            Call CloseKoneksi()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Bersih()
        TbNmaPelak.Text = ""
        CbBidang.Text = ""
        TbJmlPermintaan.Text = ""
        TBkeperluan.Text = ""
        RBcek.Checked = False
        RBgiro.Checked = False
        RbTunai.Checked = False
        tbid.Text = ""
        BtSave.Text = "Add"

    End Sub
    Private Sub Btapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btapus.Click
        Dim id As String
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        If MsgBox("Apakah Anda Yakin Ingin Menghapusnya?", vbYesNo) = MsgBoxResult.Yes Then

            id = LV1.SelectedItems(0).Text
            Call OpenKoneksi()
            Dim query As String = "Delete from Pengajuan Where IdPengajuan='" + id + "'"

            cmd = New SqlCommand(query, conn)
            dr = cmd.ExecuteReader
            Bersih()
            dr.Close()
            Call CloseKoneksi()

            LV1.Clear()
            ListView()
            
        End If
    End Sub

    Private Sub Form1_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call ListView()
        tbid.Visible = False
    End Sub

    Private Sub BtSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim uid As String
        Dim query As String = ""
        Dim tanggal As String = FormatDateTime(Now, DateFormat.ShortDate)
        If BtSave.Text = "Add" Then
           

            Call OpenKoneksi()
            Dim query_id As String = "select MAX(IdPengajuan)+1 AS MXID from Pengajuan"
            cmd = New SqlCommand(query_id, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            uid = dr("MXID")
            dr.Close()


            If RBcek.Checked = True Then
                bentuk = RBcek.Text
            ElseIf RbTunai.Checked = True Then
                bentuk = RbTunai.Text
            ElseIf RBgiro.Checked = True Then
                bentuk = RBgiro.Text
            End If

            query = "Insert into Pengajuan (IdPengajuan,NamaPegajuan,Bidang,JmlPermintaan,BentukDana,Keperluan,Tanggal) Values(" & uid & ",'" & TbNmaPelak.Text & "','" & CbBidang.Text & "','" & TbJmlPermintaan.Text & "','" & bentuk & "','" & TBkeperluan.Text & "','" & tanggal & "')"
            MsgBox("Selamat '" + TbNmaPelak.Text + "' Telah Berhasil Di Simpan Yeourobun")
            

        ElseIf BtSave.Text = "Update" Then
            Call OpenKoneksi()
            If RBcek.Checked = True Then
                bentuk = RBcek.Text
            ElseIf RbTunai.Checked = True Then
                bentuk = RbTunai.Text
            ElseIf RBgiro.Checked = True Then
                bentuk = RBgiro.Text
            End If
            query = "Update Pengajuan Set NamaPegajuan='" & TbNmaPelak.Text & "',Bidang='" & CbBidang.Text & "',JmlPermintaan='" & TbJmlPermintaan.Text & "',BentukDana='" & bentuk & "',Keperluan='" & TBkeperluan.Text & "'Where IdPengajuan='" & tbid.Text & "'"
            MsgBox("Selamat '" + TbNmaPelak.Text + "' Telah Berhasil Di Update Yeourobun")
        End If

        cmd = New SqlCommand(query, conn)
        dr = cmd.ExecuteReader
        dr.Close()


        Call CloseKoneksi()

        Bersih()
        LV1.Clear()
        ListView()

    End Sub

    Private Sub btedit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btedit.Click
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim query As String
        Dim id As String
        Try
            id = LV1.SelectedItems(0).Text
            Call OpenKoneksi()
            query = "Select * from Pengajuan Where IdPengajuan='" + id + "'"

            If bentuk = RbTunai.Text Then
                RbTunai.Checked = True
            ElseIf bentuk = RBcek.Text Then
                RBcek.Checked = True
            ElseIf bentuk = RBgiro.Text Then
                RBgiro.Checked = True
            End If
            cmd = New SqlCommand(query, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            TbNmaPelak.Text = dr("NamaPegajuan")
            CbBidang.Text = dr("Bidang")
            TbJmlPermintaan.Text = dr("JmlPermintaan")
            bentuk = dr("BentukDana")
            TBkeperluan.Text = dr("Keperluan")
            tbid.Text = dr("IdPengajuan")
            BtSave.Text = "Update"
            dr.Close()
            Call CloseKoneksi()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close.Click
        Bersih()
    End Sub
End Class
