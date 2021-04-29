﻿Public Class Offerta
    Public Property B1SOCMDB() As String
    Public Property B1CENMDB() As String
    Public Property B1CENTRO() As String
    Public Property B1IDOFF() As Integer
    Public Property B1AAOFF() As Integer
    Public Property B1PROGR() As Integer
    Public Property B1DTOFF() As Date
    Public Property B1CODIMP() As Integer
    Public Property B1CODORIG() As String
    Public Property B1RIFORDCL() As String
    Public Property B1GGVAL() As Integer
    Public Property B1DTINILAV() As String
    Public Property B1DTCONSP() As String
    Public Property B1CODPAG() As String
    Public Property B1COMMENTO() As String
    Public Property B1STATOFF() As String
    Public Property B1DTACC() As Date
    Public Property B1CODIVA() As String
    Public Property B1CODOCC() As String
    Public Property B1CODAGE() As String
    Public Property B1IDBUO() As Integer
    Public Property B1FINALITA() As String
    Public Property B1DASPED() As String
    Public Property B1CODDIZ() As String
    Public Property B1LISTMAN() As String
    Public Property B1STSCNTA() As String
    Public Property B1APPLGARA() As Integer
    Public Property B1CODCAMP() As String
    Public Property B1ESPLACC() As String
    Public Property B1INDSPED1() As String
    Public Property B1INDSPED2() As String
    Public Property B1INDSPED3() As String
    Public Property B1TOTDOC() As Integer
    Public Property B1TOTDOCNS() As Integer
    Public Property B1TOTDOCAC() As Integer
    Public Property B1TOTDOCVA() As Integer
    Public Property B1CODCOMM() As String
    Public Property B1CODSERV() As String
    Public Property B1SOCESEC() As String
    Public Property B1PERCK2() As Integer
    Public Property B1NOTAFATT() As String
    Public Property B1IMPFATT() As Integer
    Public Property B1FLPASSAS() As Integer
    Public Property B1BLOCCATO() As String
    Public Property B1CODAUT() As String
    Public Property B1DESAUT() As String
    Public Property B1DTAUTR() As Date
    Public Property B1DTAUTSI() As Date
    Public Property B1DTAUTNO() As Date
    Public Property B1CODZONAG() As String
    Public Property B1FLMDOCEN() As Integer
    Public Property B1PRVCEN() As String
    Public Property B1PRVSOC() As String
    Public Property B1PRVAADOC() As Integer
    Public Property B1PRVPRDOC() As String
    Public Property B1NOTAST1() As String
    Public Property B1DTAUTIMR() As String
    Public Property B1DTAUTIMS() As String
    Public Property B1DTAUTIMN() As String
    Public Property B1IMPAUT() As Integer
    Public Property B1RISORSA() As String
    Public Property B1CODCOTT() As String
    Public Property B1FLDTFINL() As String
    Public Property B1ANTICPER() As Integer
    Public Property B1ANTICVAL() As Integer
    Public Property B1FLRITACC() As Integer
    Public Property B1FLSUPBAR() As Integer
    Public Property B1FLBENSIG() As Integer
    Public Property B1FLGSCOFI() As String
    Public Property B1PERCSCON() As Integer
    Public Property B1PERCFIN() As Integer
    Public Property B1FLGONERI() As String
    Public Property B1PERCONER() As Integer
    Public Property TIPOIMP() As String
    Public Property Dettaglio() As List(Of OffertaDett)
    'Public Property Agente() As Agente
    Public Property Cliente() As elencoClienti
    Public Property Contratto() As elencoListaContratti
    Public Property Impianto() As elencoImpianti
    Public Property Err As Errore
End Class
