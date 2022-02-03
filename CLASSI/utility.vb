Imports System.Globalization

Public Class utility

    Public Function GetWeekOfYear(ByVal dateTime As DateTime) As Integer
        Dim culture = CultureInfo.CurrentUICulture
        Dim calendar = culture.Calendar
        Dim dateTimeFormat = culture.DateTimeFormat
        Return calendar.GetWeekOfYear(dateTime, dateTimeFormat.CalendarWeekRule, dateTimeFormat.FirstDayOfWeek)
    End Function

    Public Function verifica_giorno_di_festa(data As String) As Boolean
        Try
            Dim arrayFeste(12) As String
            arrayFeste(0) = "01/01"
            arrayFeste(1) = "06/01"
            arrayFeste(2) = "25/04"
            arrayFeste(3) = "01/05"
            arrayFeste(4) = "02/06"
            arrayFeste(5) = "015/08"
            arrayFeste(6) = "01/11"
            arrayFeste(7) = "08/12"
            arrayFeste(8) = "25/12"
            arrayFeste(9) = "26/12"

            Dim dataPasqua As String = EasterDay(Year(CDate(data)))
            If dataPasqua <> "" Then
                arrayFeste(10) = dataPasqua.Substring(0, 5)
                Dim ggAlbis As String = DateAdd("d", 1, CDate(dataPasqua))
                arrayFeste(11) = ggAlbis.Substring(0, 5)
            End If

            Dim indx As Integer = arrayFeste.ToList().IndexOf(data.Substring(0, 5))
            If indx >= 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function EasterDay(Y As Integer) As String
        Try
            Dim M As Integer, N As Integer, A As Integer, B As Integer, C As Integer, D As Integer, E As Integer
            Dim ED As String
            M = 24 : N = 5
            A = Y Mod 19
            B = Y Mod 4
            C = Y Mod 7
            D = (19 * A + M) Mod 30
            E = (2 * B + 4 * C + 6 * D + N) Mod 7
            ED = 22 + D + E
            If ED <= 31 Then
                ED = ED & "/03/" & Y
            Else
                ED = D + E - 9 & "/04/" & Y
            End If
            EasterDay = CDate(ED).ToString

        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function EncodeFile64(ByVal srcFile As String, Optional ByVal destfile As String = "") As String
        Dim srcBT As Byte()
        Dim dest As String

        Dim sr As New System.IO.FileStream(srcFile, System.IO.FileMode.Open)

        ReDim srcBT(sr.Length)

        sr.Read(srcBT, 0, sr.Length)

        sr.Close()

        dest = System.Convert.ToBase64String(srcBT)

        If destfile <> "" Then
            Dim sw As New System.IO.StreamWriter(destfile, False)
            sw.Write(dest)
            sw.Close()
        End If

        EncodeFile64 = dest

    End Function

    Public Function DecodeFile64_chilkat(ByVal srcFile As String, ByVal destFile As String) As String
        Try
            Dim pdfData2 As New Chilkat.BinData
            Dim crypt As New Chilkat.Global
            Dim success As Boolean = crypt.UnlockBundle("REDELB.CB4122020_MrstKzF4778M")
            If (success <> True) Then
                Return "ERRORE LICENZA"
                Exit Function
            End If

            pdfData2.AppendEncoded(srcFile, "base64")
            success = pdfData2.WriteFile(destFile)

            If (success <> True) Then
                Return "ERRORE CONVERSIONE FILE"
                Exit Function
            End If
            'Dim success As Boolean = crypt.UnlockComponent("REDELB.CB4122020_MrstKzF4778M")
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
End Class
