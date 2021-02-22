Public Class elencoListaContratti
    Inherits elencoClienti

    Dim r_IDT08 As String
    Dim r_NUT08 As String
    Dim r_DAX08 As String
    Dim r_ORA08 As String
    Dim r_ATX08 As String
    Dim r_CTNRC As String
    Dim r_CTSOC As String
    Dim r_CTCLI As String
    Dim r_CTDTE As Date
    Dim r_CTDTD As Date
    Dim r_CTDTS As Date
    Dim r_CTDCO As String
    Dim r_CTCAA As Double
    Dim r_CTCAAE As Double
    Dim r_CTTFA As String
    Dim r_CTFFA As String
    Dim r_CTRTA As String
    Dim r_CTCTR As String
    Dim r_CTPSM As Double
    Dim r_CTCMP As String
    Dim r_CTCIV As String
    Dim r_CTTPC As String
    Dim r_CTCPM As String
    Dim r_CTTPM As String
    Dim r_CTNIM As Integer
    Dim r_CTREP As String
    Dim r_CTCAR As Double
    Dim r_CTCARE As Double
    Dim r_CTRIF As String
    Dim r_CTIND As String
    Dim r_CTATI As String
    Dim r_CTGSM As Double
    Dim r_CTDTF As String
    Dim r_CTIMF As Double
    Dim r_CTIMFE As Double
    Dim r_CTENT As String
    Dim r_CTTIF As String
    Dim r_CTTFT As String
    Dim r_CTCLG As String
    Dim r_CTGRA As String
    Dim r_CTP95 As String
    Dim r_CTFEU As String
    Dim r_CTAGE As String
    Dim r_CTDCA As String
    Dim r_CTCN1 As String
    Dim r_CTCN2 As String
    Dim r_CTCA1 As String
    Dim r_CTRSF As String
    Dim r_CTMCO As String
    Dim r_CTTCO As String
    Dim r_CTFTC As String
    Dim r_CTCOM As String
    Dim r_CTDIF As String
    Dim r_CTGGF As String
    Dim r_CTFAC As String
    Dim r_CTINM As String
    Dim r_CTFCO As String
    Dim r_CTDTC As String
    Dim r_CTUTC As String
    Dim r_CCDTI As String
    Dim r_CPINT As String
    Dim r_DESTPCTR As String
    Dim r_CTNRCTS As String
    Dim r_IDACCORDO As String

    Public Property IDT08() As String
        Get
            Return r_IDT08
        End Get

        Set(ByVal Value As String)
            r_IDT08 = Value
        End Set
    End Property

    Public Property NUT08() As String
        Get
            Return r_NUT08
        End Get

        Set(ByVal Value As String)
            r_NUT08 = Value
        End Set
    End Property

    Public Property DAX08() As String
        Get
            Return r_DAX08
        End Get

        Set(ByVal Value As String)
            r_DAX08 = Value
        End Set
    End Property

    Public Property ORA08() As String
        Get
            Return r_ORA08
        End Get

        Set(ByVal Value As String)
            r_ORA08 = Value
        End Set
    End Property

    Public Property ATX08() As String
        Get
            Return r_ATX08
        End Get

        Set(ByVal Value As String)
            r_ATX08 = Value
        End Set
    End Property

    Public Property CTNRC() As String
        Get
            Return r_CTNRC
        End Get

        Set(ByVal Value As String)
            r_CTNRC = Value
        End Set
    End Property

    Public Property CTSOC() As String
        Get
            Return r_CTSOC
        End Get

        Set(ByVal Value As String)
            r_CTSOC = Value
        End Set
    End Property

    Public Property CTCLI() As String
        Get
            Return r_CTCLI
        End Get

        Set(ByVal Value As String)
            r_CTCLI = Value
        End Set
    End Property

    Public Property CTDTE() As Date
        Get
            Return r_CTDTE
        End Get

        Set(ByVal Value As Date)
            r_CTDTE = Value
        End Set
    End Property

    Public Property CTDTD() As Date
        Get
            Return r_CTDTD
        End Get

        Set(ByVal Value As Date)
            r_CTDTD = Value
        End Set
    End Property

    Public Property CTDTS() As Date
        Get
            Return r_CTDTS
        End Get

        Set(ByVal Value As Date)
            r_CTDTS = Value
        End Set
    End Property

    Public Property CTDCO() As String
        Get
            Return r_CTDCO
        End Get

        Set(ByVal Value As String)
            r_CTDCO = Value
        End Set
    End Property

    Public Property CTCAA() As Double
        Get
            Return r_CTCAA
        End Get

        Set(ByVal Value As Double)
            r_CTCAA = Value
        End Set
    End Property

    Public Property CTCAAE() As Double
        Get
            Return r_CTCAAE
        End Get

        Set(ByVal Value As Double)
            r_CTCAAE = Value
        End Set
    End Property

    Public Property CTTFA() As String
        Get
            Return r_CTTFA
        End Get

        Set(ByVal Value As String)
            r_CTTFA = Value
        End Set
    End Property

    Public Property CTFFA() As String
        Get
            Return r_CTFFA
        End Get

        Set(ByVal Value As String)
            r_CTFFA = Value
        End Set
    End Property

    Public Property CTRTA() As String
        Get
            Return r_CTRTA
        End Get

        Set(ByVal Value As String)
            r_CTRTA = Value
        End Set
    End Property

    Public Property CTCTR() As String
        Get
            Return r_CTCTR
        End Get

        Set(ByVal Value As String)
            r_CTCTR = Value
        End Set
    End Property

    Public Property CTPSM() As String
        Get
            Return r_CTPSM
        End Get

        Set(ByVal Value As String)
            r_CTPSM = Value
        End Set
    End Property

    Public Property CTCMP() As String
        Get
            Return r_CTCMP
        End Get

        Set(ByVal Value As String)
            r_CTCMP = Value
        End Set
    End Property

    Public Property CTCIV() As String
        Get
            Return r_CTCIV
        End Get

        Set(ByVal Value As String)
            r_CTCIV = Value
        End Set
    End Property

    Public Property CTTPC() As String
        Get
            Return r_CTTPC
        End Get

        Set(ByVal Value As String)
            r_CTTPC = Value
        End Set
    End Property

    Public Property CTCPM() As String
        Get
            Return r_CTCPM
        End Get

        Set(ByVal Value As String)
            r_CTCPM = Value
        End Set
    End Property

    Public Property CTTPM() As String
        Get
            Return r_CTTPM
        End Get

        Set(ByVal Value As String)
            r_CTTPM = Value
        End Set
    End Property

    Public Property CTNIM() As Integer
        Get
            Return r_CTNIM
        End Get

        Set(ByVal Value As Integer)
            r_CTNIM = Value
        End Set
    End Property

    Public Property CTREP() As String
        Get
            Return r_CTREP
        End Get

        Set(ByVal Value As String)
            r_CTREP = Value
        End Set
    End Property

    Public Property CTCAR() As Double
        Get
            Return r_CTCAR
        End Get

        Set(ByVal Value As Double)
            r_CTCAR = Value
        End Set
    End Property

    Public Property CTCARE() As Double
        Get
            Return r_CTCARE
        End Get

        Set(ByVal Value As Double)
            r_CTCARE = Value
        End Set
    End Property

    Public Property CTRIF() As String
        Get
            Return r_CTRIF
        End Get

        Set(ByVal Value As String)
            r_CTRIF = Value
        End Set
    End Property

    Public Property CTIND() As String
        Get
            Return r_CTIND
        End Get

        Set(ByVal Value As String)
            r_CTIND = Value
        End Set
    End Property

    Public Property CTATI() As String
        Get
            Return r_CTATI
        End Get

        Set(ByVal Value As String)
            r_CTATI = Value
        End Set
    End Property

    Public Property CTGSM() As Double
        Get
            Return r_CTGSM
        End Get

        Set(ByVal Value As Double)
            r_CTGSM = Value
        End Set
    End Property

    Public Property CTDTF() As String
        Get
            Return r_CTDTF
        End Get

        Set(ByVal Value As String)
            r_CTDTF = Value
        End Set
    End Property

    Public Property CTIMF() As Double
        Get
            Return r_CTIMF
        End Get

        Set(ByVal Value As Double)
            r_CTIMF = Value
        End Set
    End Property

    Public Property CTIMFE() As Double
        Get
            Return r_CTIMFE
        End Get

        Set(ByVal Value As Double)
            r_CTIMFE = Value
        End Set
    End Property

    Public Property CTENT() As String
        Get
            Return r_CTENT
        End Get

        Set(ByVal Value As String)
            r_CTENT = Value
        End Set
    End Property

    Public Property CTTIF() As String
        Get
            Return r_CTTIF
        End Get

        Set(ByVal Value As String)
            r_CTTIF = Value
        End Set
    End Property

    Public Property CTTFT() As String
        Get
            Return r_CTTFT
        End Get

        Set(ByVal Value As String)
            r_CTTFT = Value
        End Set
    End Property

    Public Property CTCLG() As String
        Get
            Return r_CTCLG
        End Get

        Set(ByVal Value As String)
            r_CTCLG = Value
        End Set
    End Property

    Public Property CTGRA() As String
        Get
            Return r_CTGRA
        End Get

        Set(ByVal Value As String)
            r_CTGRA = Value
        End Set
    End Property

    Public Property CTP95() As String
        Get
            Return r_CTP95
        End Get

        Set(ByVal Value As String)
            r_CTP95 = Value
        End Set
    End Property

    Public Property CTFEU() As String
        Get
            Return r_CTFEU
        End Get

        Set(ByVal Value As String)
            r_CTFEU = Value
        End Set
    End Property

    Public Property CTAGE() As String
        Get
            Return r_CTAGE
        End Get

        Set(ByVal Value As String)
            r_CTAGE = Value
        End Set
    End Property

    Public Property CTDCA() As String
        Get
            Return r_CTDCA
        End Get

        Set(ByVal Value As String)
            r_CTDCA = Value
        End Set
    End Property

    Public Property CTCN1() As String
        Get
            Return r_CTCN1
        End Get

        Set(ByVal Value As String)
            r_CTCN1 = Value
        End Set
    End Property

    Public Property CTCA1() As String
        Get
            Return r_CTCA1
        End Get

        Set(ByVal Value As String)
            r_CTCA1 = Value
        End Set
    End Property

    Public Property CTRSF() As String
        Get
            Return r_CTRSF
        End Get

        Set(ByVal Value As String)
            r_CTRSF = Value
        End Set
    End Property

    Public Property CTMCO() As String
        Get
            Return r_CTMCO
        End Get

        Set(ByVal Value As String)
            r_CTMCO = Value
        End Set
    End Property

    Public Property CTTCO() As String
        Get
            Return r_CTTCO
        End Get

        Set(ByVal Value As String)
            r_CTTCO = Value
        End Set
    End Property

    Public Property CTFTC() As String
        Get
            Return r_CTFTC
        End Get

        Set(ByVal Value As String)
            r_CTFTC = Value
        End Set
    End Property

    Public Property CTCOM() As String
        Get
            Return r_CTCOM
        End Get

        Set(ByVal Value As String)
            r_CTCOM = Value
        End Set
    End Property

    Public Property CTDIF() As String
        Get
            Return r_CTDIF
        End Get

        Set(ByVal Value As String)
            r_CTDIF = Value
        End Set
    End Property

    Public Property CTGGF() As String
        Get
            Return r_CTGGF
        End Get

        Set(ByVal Value As String)
            r_CTGGF = Value
        End Set
    End Property

    Public Property CTFAC() As String
        Get
            Return r_CTFAC
        End Get

        Set(ByVal Value As String)
            r_CTFAC = Value
        End Set
    End Property

    Public Property CTINM() As String
        Get
            Return r_CTINM
        End Get

        Set(ByVal Value As String)
            r_CTINM = Value
        End Set
    End Property

    Public Property CTFCO() As String
        Get
            Return r_CTFCO
        End Get

        Set(ByVal Value As String)
            r_CTFCO = Value
        End Set
    End Property

    Public Property CTDTC() As String
        Get
            Return r_CTDTC
        End Get

        Set(ByVal Value As String)
            r_CTDTC = Value
        End Set
    End Property

    Public Property CTUTC() As String
        Get
            Return r_CTUTC
        End Get

        Set(ByVal Value As String)
            r_CTUTC = Value
        End Set
    End Property

    Public Property CCDTI() As String
        Get
            Return r_CCDTI
        End Get

        Set(ByVal Value As String)
            r_CCDTI = Value
        End Set
    End Property

    Public Property CPINT() As String
        Get
            Return r_CPINT
        End Get

        Set(ByVal Value As String)
            r_CPINT = Value
        End Set
    End Property

    Public Property DESTPCTR() As String
        Get
            Return r_DESTPCTR
        End Get

        Set(ByVal Value As String)
            r_DESTPCTR = Value
        End Set
    End Property

    Public Property CTNRCTS() As String
        Get
            Return r_CTNRCTS
        End Get

        Set(ByVal Value As String)
            r_CTNRCTS = Value
        End Set
    End Property

    Public Property IDACCORDO() As String
        Get
            Return r_IDACCORDO
        End Get

        Set(ByVal Value As String)
            r_IDACCORDO = Value
        End Set
    End Property

End Class
