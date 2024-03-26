Sub LerArquivosTexto()
    Dim pastaRaiz As String
    pastaRaiz = ThisWorkbook.Path  ' A pasta do arquivo Excel atual
    ProcessarPastas pastaRaiz
End Sub

Sub ProcessarPastas(ByVal caminhoPasta As String)
    Dim pasta As Object, arquivo As Object
    Dim fs As Object
    Set fs = CreateObject("Scripting.FileSystemObject")
    
    ' Processa todos os arquivos na pasta atual
    For Each arquivo In fs.GetFolder(caminhoPasta).Files
        If UCase(fs.GetExtensionName(arquivo.Name)) = "TXT" Then
            ProcessarArquivo arquivo.Path
        End If
    Next arquivo

    ' Recursivamente processa subpastas
    For Each pasta In fs.GetFolder(caminhoPasta).SubFolders
        ProcessarPastas pasta.Path
    Next pasta
End Sub

Sub ProcessarArquivo(ByVal caminhoArquivo As String)
    Dim arquivoTexto As Object
    Dim linhaTexto As String
    Dim fs As Object
    Set fs = CreateObject("Scripting.FileSystemObject")
    
    Set arquivoTexto = fs.OpenTextFile(caminhoArquivo, 1)  ' 1 = For Reading
    Do While Not arquivoTexto.AtEndOfStream
        linhaTexto = arquivoTexto.ReadLine
        ' Processa cada linha do arquivo aqui
        Debug.Print linhaTexto  ' Exemplo: imprime no console imediato
    Loop
    arquivoTexto.Close
End Sub
