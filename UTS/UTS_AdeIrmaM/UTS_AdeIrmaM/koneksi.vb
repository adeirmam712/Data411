Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Module koneksi
    Public comSQL As New SqlClient.SqlCommand
    Public sql As String
    Public conn As New SqlConnection

    Public str As String = "Data Source=A06;" & _
                            "Initial Catalog=dbTransportation;" & _
                            "Persist Security Info=True;" & _
                            "UID=sa;PWD=admin"
    Public Sub OpenKoneksi()
        If conn.State = ConnectionState.Closed Then

            conn.ConnectionString = str

            Try
                conn.Open()
            Catch ex As Exception
                MsgBox("Koneksi Gagal: " & ex.ToString)
            End Try
        End If
    End Sub
    Public Sub CloseKoneksi()
        If conn.State = ConnectionState.Open Then
            Try
                conn.Close()
            Catch ex As Exception
                MsgBox("Erorr " & ex.ToString)
            End Try
        End If

    End Sub
End Module
