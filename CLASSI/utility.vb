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

End Class
