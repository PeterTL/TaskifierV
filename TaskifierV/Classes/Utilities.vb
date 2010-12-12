Imports System.Data.Linq.SqlClient
Imports System.IO.File

Public Class Utility

    'Deletes the modified version and restores a backup
    'Not sure if this is clever because of Git..
    Public Sub RebuildSampleDatabase()
        'File to be deletet
        Dim modiDb As String = "Data/TaskifierDB.sdf"
        Dim origDb As String = "Data/TaskifierDB.sdf.bak"

        'Check if modified file is present
        If Exists(modiDb) Then
            'Delete modified file
            Delete(modiDb)

            'Restore original file version
            If Exists(origDb) Then
                Copy(origDb, modiDb)
            End If
        End If
    End Sub

End Class
