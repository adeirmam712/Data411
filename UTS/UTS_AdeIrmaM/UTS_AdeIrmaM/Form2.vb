Imports System.Data.SqlClient
Public Class Form2
    Dim cmd_gl As SqlCommand
    Dim dr_gl As SqlDataReader
    Dim query_gl As String

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call OpenKoneksi()
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim strsql As String


        Try
            strsql = "select * from Transport"
            cmd = New SqlCommand(strsql, conn)
            dr = cmd.ExecuteReader
            CBtrans.Items.Clear()
            Do While dr.Read
                CBtrans.Items.Add(dr("Transport"))
            Loop
            Call CloseKoneksi()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        tampilkan()
        tbid.Visible = False
        TBother.Visible = False


    End Sub

    Private Sub BTsend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTsend.Click
        Dim query As String
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim uid As String

        Try
            Call OpenKoneksi()
            Dim query_id As String = "SELECT MAX(RequestId)+1 AS MXID FROM Transportation"
            cmd = New SqlCommand(query_id, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            uid = dr("MXID")
            dr.Close()

            If TBother.Text = "Other               " Then
                query = "INSERT INTO Transportation(RequestId,NameRequestor,RequestorId,Unit,DateIssue,UnitDestination,acRegis,Transportation,Phone,Instruction) VALUES (" & uid & ",'" & TBname.Text & "','" & TBidnum.Text & "','" & TBunit.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & TBto.Text & "','" & TBac.Text & "','" & TBother.Text & "','" & TBephp.Text & "','" & TBinst.Text & "')"
            Else

                query = "INSERT INTO Transportation(RequestId,NameRequestor,RequestorId,Unit,DateIssue,UnitDestination,acRegis,Transportation,Phone,Instruction) VALUES (" & uid & ",'" & TBname.Text & "','" & TBidnum.Text & "','" & TBunit.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & TBto.Text & "','" & TBac.Text & "','" & CBtrans.Text & "','" & TBephp.Text & "','" & TBinst.Text & "')"
            End If
            cmd = New SqlCommand(query, conn)
            dr = cmd.ExecuteReader
            dr.Close()

            MsgBox("REQUEST DATA '" + TBname.Text + "' ALREADY SAVED ")
            LV1.Clear()
            tampilkan()
            Call CloseKoneksi()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub bersih()
        tbname.Text = ""
        tbid.Text = ""
        tbunit.Text = ""
        tbTo.Text = ""
        TBac.Text = ""
        CBtrans.Text = ""
        TBephp.Text = ""
        TBinst.Text = ""
    End Sub
    Private Sub tampilkan()
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Lv1.View = View.Details
        Lv1.Columns.Add("NO", 50)
        Lv1.Columns.Add("Name of Requestor", 300)
        Lv1.Columns.Add("Unit From", 150)
        Lv1.Columns.Add("Unit To", 150)
        Lv1.Columns.Add("Request Date", 200)
        Lv1.Columns.Add("Transportation", 150)

        Try
            Call OpenKoneksi()
            Dim query_id As String = "select * from Transportation"
            cmd = New SqlCommand(query_id, conn)
            dr = cmd.ExecuteReader

            Do While dr.Read
                LV1.Items.Add(dr("RequestId"))
                LV1.Items(LV1.Items.Count - 1).SubItems.Add(dr("NameRequestor"))
                LV1.Items(LV1.Items.Count - 1).SubItems.Add(dr("Unit"))
                LV1.Items(LV1.Items.Count - 1).SubItems.Add(dr("UnitDestination"))
                LV1.Items(LV1.Items.Count - 1).SubItems.Add(dr("DateIssue"))
                LV1.Items(LV1.Items.Count - 1).SubItems.Add(dr("Transportation"))
            Loop
            dr.Close()
            Call CloseKoneksi()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BTedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTedit.Click
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim requestId As String

        Try
            requestId = LV1.SelectedItems(0).Text
            Call OpenKoneksi()
            Dim query As String = "select * from Transportation where RequestId='" + requestId + "'"

            cmd = New SqlCommand(query, conn)
            dr = cmd.ExecuteReader

            dr.Read()
            tbid.Text = dr("RequestId")
            TBname.Text = dr("NameRequestor")
            TBidnum.Text = dr("RequestorId")
            TBunit.Text = dr("Unit")
            TBto.Text = dr("UnitDestination")
            TBac.Text = dr("acRegis")
            CBtrans.Text = dr("Transportation")
            TBephp.Text = dr("Phone")
            TBinst.Text = dr("Instruction")
            dr.Close()
            Call CloseKoneksi()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Lv1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LV1.SelectedIndexChanged
        btedit.Enabled = True

    End Sub

    Private Sub BTdelet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTdelet.Click
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim requestId As String

        Try
            requestId = LV1.SelectedItems(0).Text
            Call OpenKoneksi()
            Dim query As String = "delete from Transportation where RequestId='" + requestId + "'"
            cmd = New SqlCommand(query, conn)
            dr = cmd.ExecuteReader
            Call CloseKoneksi()
            dr.Close()
            MsgBox("sudah dihapus")
            LV1.Clear()
            tampilkan()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BTupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTupdate.Click
        Try
            Call OpenKoneksi()
            query_gl = "UPDATE Transportation SET NameRequestor = '" & TBname.Text & "',RequestorId = '" & TBidnum.Text & "',Unit ='" & TBunit.Text & "',UnitDestination = '" & TBto.Text & "',acRegis = '" & TBac.Text & "',Transportation = '" & CBtrans.Text & "',phone = '" & TBephp.Text & "',Instruction = '" & TBinst.Text & "' WHERE RequestId = '" & tbid.Text & "'"
            cmd_gl = New SqlCommand(query_gl, conn)
            dr_gl = cmd_gl.ExecuteReader
            dr_gl.Close()
            Call CloseKoneksi()
            bersih()
            LV1.Clear()
            tampilkan()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CBtrans_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBtrans.SelectedIndexChanged
        If CBtrans.Text = "Other               " Then
            TBother.Visible = True
        Else
            TBother.Visible = False
        End If
    End Sub
End Class