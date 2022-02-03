Imports Telerik.WinControls.UI

Public Class FrmDizionario
    Public Sint, Voc, Sottovoc As String
    Public diz As Dizionario
    Private icons As String
    Private sottovoce As String
    Public Sub New(tempdiz As Dizionario)

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        diz = tempdiz
        icons = ChrW(&HE11A)

        For i As Integer = 0 To Me.stepProgress.Steps.Count - 1
            Dim [step] As StepProgressItem = Me.stepProgress.Steps(i)
            [step].Tag = Me.RadPageView1.Pages(i)
            [step].StepIndicator.Text = $"{i + 1}"
            [step].StepIndicator.CustomFont = "Roboto"
            [step].StepIndicator.CustomFontSize = 8
        Next

        AddHandler Me.stepProgress.CurrentChanged, AddressOf Me.stepProgress_CurrentStepChanged
        Me.MoveNext()
        Me.cardVoci.CardViewElement.DrawBorder = False
    End Sub

    Private Sub stepProgress_CurrentStepChanged(ByVal sender As Object, ByVal e As EventArgs)
        If Me.stepProgress.Current Is Nothing Then
            Return
        End If
        Me.RadPageView1.SelectedPage = CType(Me.stepProgress.Current.Tag, RadPageViewPage)
    End Sub

    Public Sub Load() Handles MyBase.Load
        cardSintetici.DataSource = diz.Categorie.First.Tipologie.First.Sintetici
        'FormatSintetici()
    End Sub

    Private Sub cmdNext_Click(sender As Object, e As EventArgs) Handles cmdNext.Click
        Me.MoveNext()
    End Sub

    Private Sub MoveNext()
        If Me.stepProgress.CompleteNext() Then
            cmdBack.Text = "INDIETRO"
            cmdNext.Visible = stepProgress.Current.IsLast()
            Dim index As Integer = Me.stepProgress.Steps.IndexOf(Me.stepProgress.Current)
            Me.stepProgress.Current.StepIndicator.Text = icons
            Me.stepProgress.Current.StepIndicator.CustomFont = "WebComponentsIcons"
            Me.stepProgress.Current.StepIndicator.CustomFontSize = 12
        End If
    End Sub

    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click
        If Me.stepProgress.Current.IsFirst Then
            Me.Close()
        Else
            Me.MovePrevious()
        End If
    End Sub

    Private Sub MovePrevious()
        If Me.stepProgress.CompletePrevious() Then
            Dim [next] As StepProgressItem = Me.stepProgress.Current.[Next]

            If [next] IsNot Nothing Then
                [next].StepIndicator.Text = $"{Me.stepProgress.Steps.IndexOf([next]) + 1}"
                [next].StepIndicator.CustomFont = "Roboto"
                [next].StepIndicator.CustomFontSize = 8
            End If
            If stepProgress.Current.IsFirst Then
                cmdBack.Text = "ANNULLA"
            End If
        End If
    End Sub

    Private Sub cardView_ItemMouseClick(sender As Object, e As ListViewItemEventArgs) Handles cardSintetici.ItemMouseClick
        Dim sin As Sintetico = e.Item.DataBoundItem
        Sint = sin.Codice
        txtSin.Text = Sint
        txtSin.ReadOnly = True
        Voc = ""
        Sottovoc = ""
        cardVoci.DataSource = sin.Voci
        MoveNext()
    End Sub

    Private Sub cardSotto_ItemMouseClick(sender As Object, e As ListViewItemEventArgs) Handles cardSotto.ItemMouseClick
        Dim sotto As Sottovoce = e.Item.DataBoundItem
        Sottovoc = sotto.Codice
        cmdNext.Visible = True
        cmdNext.Text = "FINE"
        txtSot.Text = Sottovoc
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If sender.text <> "" Then
            Dim card As RadCardView
            If stepProgress.Current.Name = "selectSint" Then
                card = cardSintetici
            ElseIf stepProgress.Current.Name = "selectVoce" Then
                card = cardVoci
            Else
                card = cardSotto
            End If
            card.FilterDescriptors.Add(New Telerik.WinControls.Data.FilterDescriptor("Descrizione", Telerik.WinControls.Data.FilterOperator.Contains, sender.text))
        End If
    End Sub

    Private Sub cardVoci_ItemMouseClick(sender As Object, e As ListViewItemEventArgs) Handles cardVoci.ItemMouseClick
        Dim voc As Voce = e.Item.DataBoundItem
        Me.Voc = voc.Codice
        Sottovoc = ""
        cardSotto.DataSource = voc.SottoVoci
        txtVoc.Text = Me.Voc
        txtVoc.ReadOnly = True
        MoveNext()
    End Sub

    Private Sub cardSintetici_CardViewItemFormatting(sender As Object, e As CardViewItemFormattingEventArgs) Handles cardSintetici.CardViewItemFormatting, cardVoci.CardViewItemFormatting, cardSotto.CardViewItemFormatting
        Dim cardItem As CardViewItem = TryCast(e.Item, CardViewItem)
        If cardItem IsNot Nothing Then
            If cardItem.FieldName = "Image" Then
                cardItem.EditorItem.DrawText = False
                Dim image__1 As Image = Image.FromFile(Application.StartupPath & "\Image\lift.jpg")
                cardItem.EditorItem.Image = image__1
                cardItem.EditorItem.ImageLayout = ImageLayout.Stretch
                cardItem.EditorItem.NotifyParentOnMouseInput = False
                cardItem.EditorItem.ShouldHandleMouseInput = False
                cardItem.Padding = New Padding(-5, -5, -5, 0)
                Return
            ElseIf cardItem.FieldName = "Codice" Then
                'cardItem.EditorItem.Text = "codice"
                cardItem.EditorItem.Font = New Font(cardItem.EditorItem.Font, FontStyle.Bold)
            ElseIf cardItem.FieldName = "Descrizione" OrElse cardItem.FieldName = "" Then
                cardItem.TextWrap = True
                cardItem.EditorItem.TextWrap = True
                'cardItem.EditorItem.Text = "Descrizione"
            End If

            ' Font selectedItemFont = this.fontConverter.ConvertFromString(this.radBrowseEditorFont.Value) as Font;
            ' if (selectedItemFont != cardItem.Font)
            '  {
            ' Font itemFont = new Font(cardItem.Font.FontFamily, cardItem.Font.Size, FontStyle.Bold);
            Dim editorFont As New Font(cardItem.Font.FontFamily, cardItem.Font.Size, FontStyle.Regular)

            ' cardItem.Font = itemFont;
            '  }
            cardItem.EditorItem.Font = editorFont
        End If
    End Sub
End Class
