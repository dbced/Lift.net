Public Class elencoAccordi
    Dim r_ID As Integer
    Dim r_TIPOACC As String
    Dim r_TIPOCTR As String
    Dim r_CDPRV As String
    Dim r_DTINIZ As Date
    Dim r_DTFINE As Date
    Dim r_CDSTIP As String
    Dim r_DESCR As String
    Dim r_CDSOC As String
    Dim r_CDCLI As String
    Dim r_FLRNTAC As String
    Dim r_FLRNPRG As String
    Dim r_NOTE As String
    Dim r_CIG As String
    Dim r_CUP As String
    Dim r_CDCLS As String
    Dim r_NRIMP As Integer
    Dim r_CDCOM As String
    Dim r_IDACCLI As String
    Dim r_CDTPFAT As String
    Dim r_CDPAG As String
    Dim r_PERCRT As Double
    Dim r_FLRTIVA As String
    Dim r_IMPORTO As Double
    Dim r_RASCL As String

    Dim r_listaPrestazioni As List(Of prestazioniAccordo)
    Dim r_listaTipoApplato As List(Of TipologiaAppalto)

    Public Property listaPrestazioni() As List(Of prestazioniAccordo)
        Get
            Return r_listaPrestazioni
        End Get

        Set(ByVal Value As List(Of prestazioniAccordo))
            r_listaPrestazioni = Value
        End Set
    End Property

    Public Property listaTipoApplato() As List(Of TipologiaAppalto)
        Get
            Return r_listaTipoApplato
        End Get

        Set(ByVal Value As List(Of TipologiaAppalto))
            r_listaTipoApplato = Value
        End Set
    End Property

    Public Property ID() As Integer
        Get
            Return r_ID
        End Get

        Set(ByVal Value As Integer)
            r_ID = Value
        End Set
    End Property


    Public Property TIPOACC() As String
        Get
            Return r_TIPOACC
        End Get

        Set(ByVal Value As String)
            r_TIPOACC = Value
        End Set
    End Property

    Public Property TIPOCTR() As String
        Get
            Return r_TIPOCTR
        End Get

        Set(ByVal Value As String)
            r_TIPOCTR = Value
        End Set
    End Property

    Public Property CDPRV() As String
        Get
            Return r_CDPRV
        End Get

        Set(ByVal Value As String)
            r_CDPRV = Value
        End Set
    End Property

    Public Property DTINIZ() As Date
        Get
            Return r_DTINIZ
        End Get

        Set(ByVal Value As Date)
            r_DTINIZ = Value
        End Set
    End Property

    Public Property DTFINE() As Date
        Get
            Return r_DTFINE
        End Get

        Set(ByVal Value As Date)
            r_DTFINE = Value
        End Set
    End Property

    Public Property CDSTIP() As String
        Get
            Return r_CDSTIP
        End Get

        Set(ByVal Value As String)
            r_CDSTIP = Value
        End Set
    End Property

    Public Property DESCR() As String
        Get
            Return r_DESCR
        End Get

        Set(ByVal Value As String)
            r_DESCR = Value
        End Set
    End Property

    Public Property CDSOC() As String
        Get
            Return r_CDSOC
        End Get

        Set(ByVal Value As String)
            r_CDSOC = Value
        End Set
    End Property

    Public Property CDCLI() As String
        Get
            Return r_CDCLI
        End Get

        Set(ByVal Value As String)
            r_CDCLI = Value
        End Set
    End Property

    Public Property FLRNTAC() As String
        Get
            Return r_FLRNTAC
        End Get

        Set(ByVal Value As String)
            r_FLRNTAC = Value
        End Set
    End Property

    Public Property FLRNPRG() As String
        Get
            Return r_FLRNPRG
        End Get

        Set(ByVal Value As String)
            r_FLRNPRG = Value
        End Set
    End Property

    Public Property NOTE() As String
        Get
            Return r_NOTE
        End Get

        Set(ByVal Value As String)
            r_NOTE = Value
        End Set
    End Property

    Public Property CIG() As String
        Get
            Return r_CIG
        End Get

        Set(ByVal Value As String)
            r_CIG = Value
        End Set
    End Property

    Public Property CUP() As String
        Get
            Return r_CUP
        End Get

        Set(ByVal Value As String)
            r_CUP = Value
        End Set
    End Property

    Public Property CDCLS() As String
        Get
            Return r_CDCLS
        End Get

        Set(ByVal Value As String)
            r_CDCLS = Value
        End Set
    End Property

    Public Property NRIMP() As Integer
        Get
            Return r_NRIMP
        End Get

        Set(ByVal Value As Integer)
            r_NRIMP = Value
        End Set
    End Property
    Public Property CDCOM() As String
        Get
            Return r_CDCOM
        End Get

        Set(ByVal Value As String)
            r_CDCOM = Value
        End Set
    End Property

    Public Property IDACCLI() As String
        Get
            Return r_IDACCLI
        End Get

        Set(ByVal Value As String)
            r_IDACCLI = Value
        End Set
    End Property

    Public Property CDTPFAT() As String
        Get
            Return r_CDTPFAT
        End Get

        Set(ByVal Value As String)
            r_CDTPFAT = Value
        End Set
    End Property

    Public Property CDPAG() As String
        Get
            Return r_CDPAG
        End Get

        Set(ByVal Value As String)
            r_CDPAG = Value
        End Set
    End Property

    Public Property PERCRT() As Double
        Get
            Return r_PERCRT
        End Get

        Set(ByVal Value As Double)
            r_PERCRT = Value
        End Set
    End Property

    Public Property FLRTIVA() As String
        Get
            Return r_FLRTIVA
        End Get

        Set(ByVal Value As String)
            r_FLRTIVA = Value
        End Set
    End Property

    Public Property IMPORTO() As Double
        Get
            Return r_IMPORTO
        End Get

        Set(ByVal Value As Double)
            r_IMPORTO = Value
        End Set
    End Property

    Public Property RASCL() As String
        Get
            Return r_RASCL
        End Get

        Set(ByVal Value As String)
            r_RASCL = Value
        End Set
    End Property

End Class

Public Class prestazioniAccordo
    Dim r_cdPrestazione As String
    Dim r_desPrestazione As String

    Public Property cdPrestazione() As String
        Get
            Return r_cdPrestazione
        End Get

        Set(ByVal Value As String)
            r_cdPrestazione = Value
        End Set
    End Property

    Public Property desPrestazione() As String
        Get
            Return r_desPrestazione
        End Get

        Set(ByVal Value As String)
            r_desPrestazione = Value
        End Set
    End Property

End Class

Public Class TipologiaAppalto
    Dim r_cdAppalto As String
    Dim r_desAppalto As String

    Public Property cdAppalto() As String
        Get
            Return r_cdAppalto
        End Get

        Set(ByVal Value As String)
            r_cdAppalto = Value
        End Set
    End Property

    Public Property desAppalto() As String
        Get
            Return r_desAppalto
        End Get

        Set(ByVal Value As String)
            r_desAppalto = Value
        End Set
    End Property

End Class
