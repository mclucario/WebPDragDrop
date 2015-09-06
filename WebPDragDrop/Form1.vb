Public Class Form1

    Dim webpFiles() As String
    Dim OFD As New OpenFileDialog

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        With OFD
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            .FilterIndex = 0
            .Filter = "WEBP files (*.webp)|*.webp"
            .Multiselect = True
        End With

    End Sub


    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop

        webpFiles = e.Data.GetData(DataFormats.FileDrop)

        For Each webpPath In webpFiles

            Try

                Process.Start(My.Application.Info.DirectoryPath + "\dwebp.exe", webpPath + " -o " + webpPath.Replace(".webp", ".png"))

            Catch ex As Exception

                MsgBox(ex.Message + vbNewLine + "(Have you put the application to the right folder?)", MsgBoxStyle.Critical, "Error")

            End Try

        Next

    End Sub

    Private Sub Form1_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If

    End Sub

End Class
