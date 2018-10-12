Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Module Module1
    Public comSQL As New SqlClient.SqlCommand
    Public sql As String
    Public conn As New SqlConnection

    Public str As String = "Data Source=DESKTOP-B5ISVH5;" & _
                            "Initial Catalog=dbPengajuan;" & _
                            "Persist Security Info=True;" & _
                            "UID=ade;PWD=admin"

    Public Sub OpenKoneksi()
        If conn.State = ConnectionState.Closed Then
            conn.ConnectionString = str
            Try
                conn.Open()
            Catch ex As Exception
                MsgBox("Koneksi Gagal Yeorubeoun!: " & ex.ToString)
            End Try
        End If
    End Sub

    Public Sub CloseKoneksi()
         If conn.State = ConnectionState.Open Then
            Try
                conn.Close()
            Catch ex As Exception
                MsgBox("Eror Yeorubeoun! " & ex.ToString)
            End Try
        End If
    End Sub
End Module
