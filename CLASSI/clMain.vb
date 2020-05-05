Imports Telerik.WinControls.UI.Localization
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Namespace ItalianProvider
Public Class ItalianGridViewLocalizationProvider
        Inherits RadGridLocalizationProvider

        Public Overrides Function GetLocalizedString(ByVal id As String) As String
            Select Case id
                Case RadGridStringId.FilterFunctionBetween
                    Return "Compreso tra"
                Case RadGridStringId.FilterFunctionContains
                    Return "Contiene"
                Case RadGridStringId.FilterFunctionDoesNotContain
                    Return "Non contiene"
                Case RadGridStringId.FilterFunctionEndsWith
                    Return "Finisce per"
                Case RadGridStringId.FilterFunctionEqualTo
                    Return "Uguale"
                Case RadGridStringId.FilterFunctionGreaterThan
                    Return "Più grande di"
                Case RadGridStringId.FilterFunctionGreaterThanOrEqualTo
                    Return "Più grande o uguale a"
                Case RadGridStringId.FilterFunctionIsEmpty
                    Return "E' vuoto"
                Case RadGridStringId.FilterFunctionIsNull
                    Return "E' nullo"
                Case RadGridStringId.FilterFunctionLessThan
                    Return "Minore di"
                Case RadGridStringId.FilterFunctionLessThanOrEqualTo
                    Return "Minore o uguale a"
                Case RadGridStringId.FilterFunctionNoFilter
                    Return "Nessun filtro"
                Case RadGridStringId.FilterFunctionNotBetween
                    Return "Non compreso tra"
                Case RadGridStringId.FilterFunctionNotEqualTo
                    Return "Non uguale a"
                Case RadGridStringId.FilterFunctionNotIsEmpty
                    Return "Non è vuoto"
                Case RadGridStringId.FilterFunctionNotIsNull
                    Return "Non è nullo"
                Case RadGridStringId.FilterFunctionStartsWith
                    Return "Inizia per"
                Case RadGridStringId.FilterFunctionCustom
                    Return "Personalizzato"
                Case RadGridStringId.CustomFilterMenuItem
                    Return "Personalizzato"
                Case RadGridStringId.CustomFilterDialogCaption
                    Return "Impostazioni filtro personalizzate"
                Case RadGridStringId.CustomFilterDialogLabel
                    Return "Mostra righe dove:"
                Case RadGridStringId.CustomFilterDialogRbAnd
                    Return "AND"
                Case RadGridStringId.CustomFilterDialogRbOr
                    Return "OR"
                Case RadGridStringId.CustomFilterDialogBtnOk
                    Return "OK"
                Case RadGridStringId.ConditionalFormattingBtnOK
                    Return "OK"
                Case RadGridStringId.ExpressionFormOKButton
                    Return "OK"
                Case RadGridStringId.FilterMenuButtonOK
                    Return "OK"
                Case RadGridStringId.CustomFilterDialogBtnCancel
                    Return "Annulla"
                Case RadGridStringId.DeleteRowMenuItem
                    Return "Cancella riga"
                Case RadGridStringId.SortAscendingMenuItem
                    Return "Ordinamento crescente"
                Case RadGridStringId.SortDescendingMenuItem
                    Return "Ordinamento discendente"
                Case RadGridStringId.ClearSortingMenuItem
                    Return "Annulla ordinamento"
                Case RadGridStringId.ConditionalFormattingMenuItem
                    Return "Formattazione condizionale"
                Case RadGridStringId.GroupByThisColumnMenuItem
                    Return "Raggruppa su questa colonna"
                Case RadGridStringId.UngroupThisColumn
                    Return "Annulla ragruppamento sulla colonna"
                Case RadGridStringId.ColumnChooserMenuItem
                    Return "Selezione colonne"
                Case RadGridStringId.HideMenuItem
                    Return "Nascondi colonna"
                Case RadGridStringId.UnpinMenuItem
                    Return "Sblocca colonna"
                Case RadGridStringId.PinMenuItem
                    Return "Blocca colonna"
                Case RadGridStringId.BestFitMenuItem
                    Return "Miglior dimensione"
                Case RadGridStringId.PasteMenuItem
                    Return "Incolla"
                Case RadGridStringId.EditMenuItem
                    Return "Modifica"
                Case RadGridStringId.ClearValueMenuItem
                    Return "Annulla valore"
                Case RadGridStringId.CopyMenuItem
                    Return "Copia"
                Case RadGridStringId.AddNewRowString
                    Return "Cliccare qui per aggiungere una nuova riga"
                Case RadGridStringId.ConditionalFormattingCaption
                    Return "Gestione regole per la formattazione condizionale"
                Case RadGridStringId.ConditionalFormattingLblColumn
                    Return "Formatta solo le celle con"
                Case RadGridStringId.ConditionalFormattingLblName
                    Return "Nome regola:"
                Case RadGridStringId.ConditionalFormattingLblType
                    Return "Valore cella:"
                Case RadGridStringId.ConditionalFormattingLblValue1
                    Return "Valore 1:"
                Case RadGridStringId.ConditionalFormattingLblValue2
                    Return "Valore 2:"
                Case RadGridStringId.ConditionalFormattingGrpConditions
                    Return "Regole"
                Case RadGridStringId.ConditionalFormattingGrpProperties
                    Return "Proprietà regola"
                Case RadGridStringId.ConditionalFormattingChkApplyToRow
                    Return "Applica questa regola all'intera riga"
                Case RadGridStringId.ConditionalFormattingBtnAdd
                    Return "Nuova regola"
                Case RadGridStringId.ConditionalFormattingBtnRemove
                    Return "Rimuovi regola"
                Case RadGridStringId.ConditionalFormattingBtnOK
                    Return "OK"
                Case RadGridStringId.ConditionalFormattingBtnCancel
                    Return "Annulla"
                Case RadGridStringId.ConditionalFormattingBtnApply
                    Return "Applica"
                Case RadGridStringId.ConditionalFormattingRuleAppliesOn
                    Return "La regola si applica su:"
                Case RadGridStringId.ConditionalFormattingChooseOne
                    Return "[Scegliere una condizione]"
                Case RadGridStringId.ConditionalFormattingEqualsTo
                    Return "uguale a [Valore 1]"
                Case RadGridStringId.ConditionalFormattingIsNotEqualTo
                    Return "non è uguale a [Valore 1]"
                Case RadGridStringId.ConditionalFormattingStartsWith
                    Return "inizia con [Valore 1]"
                Case RadGridStringId.ConditionalFormattingEndsWith
                    Return "finisce con [Valore 1]"
                Case RadGridStringId.ConditionalFormattingContains
                    Return "contiene [Valore 1]"
                Case RadGridStringId.ConditionalFormattingDoesNotContain
                    Return "non contiene [Valore 1]"
                Case RadGridStringId.ConditionalFormattingIsGreaterThan
                    Return "è più grande di [Valore 1]"
                Case RadGridStringId.ConditionalFormattingIsGreaterThanOrEqual
                    Return "è più grande o uguale a [Valore 1]"
                Case RadGridStringId.ConditionalFormattingIsLessThan
                    Return "è minore di [Valore 1]"
                Case RadGridStringId.ConditionalFormattingIsLessThanOrEqual
                    Return "è minore o uguale a [Valore 1]"
                Case RadGridStringId.ConditionalFormattingIsBetween
                    Return "è compreso tra [Valore 1] e [Valore 2]"
                Case RadGridStringId.ConditionalFormattingIsNotBetween
                    Return "non è compreso tra [Valore 1] e [Valore 2]"
                Case RadGridStringId.ColumnChooserFormCaption
                    Return "Selezione colonne"
                Case RadGridStringId.ColumnChooserFormMessage
                    Return "Trascinare qui l'intestazione di una colonna" & vbLf & "della griglia per nasconderla alla vista."
                Case RadGridStringId.GroupingPanelDefaultMessage
                    Return "Trascinare qui una colonna per raggruppare sulla colonna."
                Case RadGridStringId.NoDataText
                    Return "Nessun dato da visualizzare"
                Case RadGridStringId.FilterMenuSelectionAll
                    Return "Seleziona tutto"
                Case RadGridStringId.FilterMenuSelectionNull
                    Return "Nullo"
                Case RadGridStringId.FilterMenuSelectionNotNull
                    Return "Non nullo"
                Case RadGridStringId.FilterMenuSelectionAllSearched
                    Return "Cerca"
                Case RadGridStringId.FilterMenuSearchBoxText
                    Return "Cerca"
                Case RadGridStringId.FilterMenuButtonCancel
                    Return "Annulla"
                Case RadGridStringId.PinAtRightMenuItem
                    Return "Blocca a destra"
                Case RadGridStringId.PinAtLeftMenuItem
                    Return "Blocca a sinistra"
                Case RadGridStringId.PinAtTopMenuItem
                    Return "Blocca in alto"
                Case RadGridStringId.PinAtBottomMenuItem
                    Return "Blocca in basso"
                Case RadGridStringId.UnpinRowMenuItem
                    Return "Sblocca"
                Case RadGridStringId.FilterMenuClearFilters
                    Return "Rimuovi filtri"
                Case RadGridStringId.FilterMenuAvailableFilters
                    Return "Filtri disponibili"
                Case RadGridStringId.SearchRowMatchCase
                    Return "Distingui Maiuscole/Minuscole"
                Case RadGridStringId.FilterFunctionDuringLast7days
                    Return "Ultimi 7 giorni"
                Case RadGridStringId.FilterFunctionToday
                    Return "Oggi"
                Case RadGridStringId.FilterFunctionYesterday
                    Return "Ieri"
                Case RadGridStringId.FilterFunctionSelectedDates
                    Return "Filtro per date specifiche"

                Case Else
                    Dim aa As String = ""
            End Select

            'System.Diagnostics.Debug.WriteLine(Convert.ToString("GRIDVIEW:") & id)
            Return String.Empty
        End Function
    End Class

    Public Class ItalianSchedulerViewLocalizationProvider
        Inherits RadSchedulerLocalizationProvider

        Public Overrides Function GetLocalizedString(ByVal id As String) As String
            Select Case id
            '======= RAD SCHEDULER ===============
                Case RadSchedulerStringId.NextAppointment
                    Return "Prossimo appuntamento"
                Case RadSchedulerStringId.PreviousAppointment
                    Return "Precedente appuntamento"
                Case RadSchedulerStringId.AppointmentDialogTitle
                    Return "Modifica appuntamento"
                Case RadSchedulerStringId.AppointmentDialogSubject
                    Return "Descrizione"
                Case RadSchedulerStringId.AppointmentDialogLocation
                    Return "Luogo"
                Case RadSchedulerStringId.AppointmentDialogBackground
                    Return "Tipologia"
                Case RadSchedulerStringId.AppointmentDialogStartTime
                    Return "Data/Ora inizio"
                Case RadSchedulerStringId.AppointmentDialogEndTime
                    Return "Data/Ora fine"
                Case RadSchedulerStringId.AppointmentDialogAllDay
                    Return "Giornaliero"
                Case RadSchedulerStringId.AppointmentDialogResource
                    Return "Risorsa"
                Case RadSchedulerStringId.AppointmentDialogStatus
                    Return "Stato"
                Case RadSchedulerStringId.AppointmentDialogOK
                    Return "OK"
                Case RadSchedulerStringId.AppointmentDialogCancel
                    Return "Annulla"
                Case RadSchedulerStringId.AppointmentDialogDelete
                    Return "Cancella"
                Case RadSchedulerStringId.AppointmentDialogRecurrence
                    Return "Ricorrenza"
                Case RadSchedulerStringId.OpenRecurringDialogTitle
                    Return "Apri azione ricorrente"
                Case RadSchedulerStringId.OpenRecurringDialogOK
                    Return "OK"
                Case RadSchedulerStringId.OpenRecurringDialogCancel
                    Return "Annulla"
                Case RadSchedulerStringId.OpenRecurringDialogLabel
                    Return "appuntamento ricorrente. Si desidera aprire solo questa ricorrenza o tutta la serie?"

                Case RadSchedulerStringId.OpenRecurringDialogRadioOccurrence
                    Return "Apri questa ricorrenza."
                Case RadSchedulerStringId.OpenRecurringDialogRadioSeries
                    Return "Apri tutta la serie."
                Case RadSchedulerStringId.RecurrenceDialogTitle
                    Return "Modifica ricorrenza"
                Case RadSchedulerStringId.RecurrenceDialogAppointmentTimeGroup
                    Return "Durata appuntamento"
                Case RadSchedulerStringId.RecurrenceDialogDuration
                    Return "Durata"
                Case RadSchedulerStringId.RecurrenceDialogAppointmentEnd
                    Return "Fine"
                Case RadSchedulerStringId.RecurrenceDialogAppointmentStart
                    Return "Inizio"
                Case RadSchedulerStringId.RecurrenceDialogRecurrenceGroup
                    Return "Modello ricorrenza"
                Case RadSchedulerStringId.RecurrenceDialogRangeGroup
                    Return "Periodo di ricorrenza"
                Case RadSchedulerStringId.RecurrenceDialogOccurrences
                    Return "ripetizioni"
                Case RadSchedulerStringId.RecurrenceDialogRecurrenceStart
                    Return "Inizio"
                Case RadSchedulerStringId.RecurrenceDialogYearly
                    Return "Settimanale"
                Case RadSchedulerStringId.RecurrenceDialogMonthly
                    Return "Mensile"
                Case RadSchedulerStringId.RecurrenceDialogWeekly
                    Return "Settimanale"
                Case RadSchedulerStringId.RecurrenceDialogDaily
                    Return "Giornaliero"
                Case RadSchedulerStringId.RecurrenceDialogEndBy
                    Return "Fine entro"
                Case RadSchedulerStringId.RecurrenceDialogEndAfter
                    Return "Fine dopo"
                Case RadSchedulerStringId.RecurrenceDialogNoEndDate
                    Return "Nessuna data finale"
                Case RadSchedulerStringId.RecurrenceDialogOK
                    Return "OK"
                Case RadSchedulerStringId.RecurrenceDialogCancel
                    Return "Annulla"
                Case RadSchedulerStringId.RecurrenceDialogRemoveRecurrence
                    Return "Remuovi ricorrenza"
                Case RadSchedulerStringId.DailyRecurrenceEveryDay
                    Return "Ogni"
                Case RadSchedulerStringId.DailyRecurrenceEveryWeekday
                    Return "Ogni giorno della settimana"
                Case RadSchedulerStringId.DailyRecurrenceDays
                    Return "giorno(i)"
                Case RadSchedulerStringId.WeeklyRecurrenceRecurEvery
                    Return "Ripeti ogni"
                Case RadSchedulerStringId.WeeklyRecurrenceWeeksOn
                    Return "settimana(e) su"
                Case RadSchedulerStringId.WeeklyRecurrenceSunday
                    Return "Domenica"
                Case RadSchedulerStringId.WeeklyRecurrenceMonday
                    Return "Lunedì"
                Case RadSchedulerStringId.WeeklyRecurrenceTuesday
                    Return "Martedì"
                Case RadSchedulerStringId.WeeklyRecurrenceWednesday
                    Return "Mercoledì"
                Case RadSchedulerStringId.WeeklyRecurrenceThursday
                    Return "Giovedì"
                Case RadSchedulerStringId.WeeklyRecurrenceFriday
                    Return "Venerdì"
                Case RadSchedulerStringId.WeeklyRecurrenceSaturday
                    Return "Sabato"
                Case RadSchedulerStringId.WeeklyRecurrenceDay
                    Return "Giorno"
                Case RadSchedulerStringId.WeeklyRecurrenceWeekday
                    Return "feriale"
                Case RadSchedulerStringId.WeeklyRecurrenceWeekendDay
                    Return "festivo"
                Case RadSchedulerStringId.MonthlyRecurrenceDay
                    Return "Giorno"
                Case RadSchedulerStringId.MonthlyRecurrenceWeek
                    Return "Il"
                Case RadSchedulerStringId.MonthlyRecurrenceDayOfMonth
                    Return "di ogni"
                Case RadSchedulerStringId.MonthlyRecurrenceMonths
                    Return "mese(i)"
                Case RadSchedulerStringId.MonthlyRecurrenceWeekOfMonth
                    Return "di ogni"
                Case RadSchedulerStringId.MonthlyRecurrenceFirst
                    Return "primo"
                Case RadSchedulerStringId.MonthlyRecurrenceSecond
                    Return "secondo"
                Case RadSchedulerStringId.MonthlyRecurrenceThird
                    Return "terzo"
                Case RadSchedulerStringId.MonthlyRecurrenceFourth
                    Return "quarto"
                Case RadSchedulerStringId.MonthlyRecurrenceLast
                    Return "Ultimo"
                Case RadSchedulerStringId.YearlyRecurrenceDayOfMonth
                    Return "Ogni"
                Case RadSchedulerStringId.YearlyRecurrenceWeekOfMonth
                    Return "Il"
                Case RadSchedulerStringId.YearlyRecurrenceOfMonth
                    Return "di"
                Case RadSchedulerStringId.YearlyRecurrenceJanuary
                    Return "Gennaio"
                Case RadSchedulerStringId.YearlyRecurrenceFebruary
                    Return "Febbraio"
                Case RadSchedulerStringId.YearlyRecurrenceMarch
                    Return "Marzo"
                Case RadSchedulerStringId.YearlyRecurrenceApril
                    Return "Aprile"
                Case RadSchedulerStringId.YearlyRecurrenceMay
                    Return "Maggio"
                Case RadSchedulerStringId.YearlyRecurrenceJune
                    Return "Giugno"
                Case RadSchedulerStringId.YearlyRecurrenceJuly
                    Return "Luglio"
                Case RadSchedulerStringId.YearlyRecurrenceAugust
                    Return "Agosto"
                Case RadSchedulerStringId.YearlyRecurrenceSeptember
                    Return "Settembre"
                Case RadSchedulerStringId.YearlyRecurrenceOctober
                    Return "Ottobre"
                Case RadSchedulerStringId.YearlyRecurrenceNovember
                    Return "Novembre"
                Case RadSchedulerStringId.YearlyRecurrenceDecember
                    Return "Dicembre"
                Case RadSchedulerStringId.BackgroundNone
                    Return "Nessuno"
                Case RadSchedulerStringId.BackgroundImportant
                    Return "Importante"
                Case RadSchedulerStringId.BackgroundBusiness
                    Return "Lavoro"
                Case RadSchedulerStringId.BackgroundPersonal
                    Return "Personale"
                Case RadSchedulerStringId.BackgroundVacation
                    Return "Vacanza"
                Case RadSchedulerStringId.BackgroundMustAttend
                    Return "Obbligo presenza"
                Case RadSchedulerStringId.BackgroundTravelRequired
                    Return "Viggio richiesto"
                Case RadSchedulerStringId.BackgroundNeedsPreparation
                    Return "Preparazione necessaria"
                Case RadSchedulerStringId.BackgroundBirthday
                    Return "Compleanno"
                Case RadSchedulerStringId.BackgroundAnniversary
                    Return "Anniversario"
                Case RadSchedulerStringId.BackgroundPhoneCall
                    Return "Telefonata"
                Case RadSchedulerStringId.StatusBusy
                    Return "Occupato"
                Case RadSchedulerStringId.StatusFree
                    Return "Libero"
                Case RadSchedulerStringId.StatusTentative
                    Return "Tentativo"
                Case RadSchedulerStringId.StatusUnavailable
                    Return "Indisponibile"
                Case RadSchedulerStringId.ContextMenuNewAppointment
                    Return "Nuovo appuntamento"
                Case RadSchedulerStringId.ContextMenuNewRecurringAppointment
                    Return "Nuovo appuntamento ripetuto"
                Case RadSchedulerStringId.ContextMenu60Minutes
                    Return "60 Minuti"
                Case RadSchedulerStringId.ContextMenu30Minutes
                    Return "30 Minuti"
                Case RadSchedulerStringId.ContextMenu15Minutes
                    Return "15 Minuti"
                Case RadSchedulerStringId.ContextMenu10Minutes
                    Return "10 Minuti"
                Case RadSchedulerStringId.ContextMenu6Minutes
                    Return "6 Minuti"
                Case RadSchedulerStringId.ContextMenu5Minutes
                    Return "5 Minuti"
                Case RadSchedulerStringId.ContextMenuNavigateToNextView
                    Return "Prossima vista"
                Case RadSchedulerStringId.ContextMenuNavigateToPreviousView
                    Return "Vista precedente"
            End Select

            Return String.Empty

        End Function


    End Class

    Public Class ItalianSchedulerNavigatorLocalizationProvider
        Inherits SchedulerNavigatorLocalizationProvider

        Public Overrides Function GetLocalizedString(ByVal id As String) As String
            Select Case id
            '======== NAVIGATION SCHEDULER ================
                Case SchedulerNavigatorStringId.DayViewButtonCaption
                Return "Vista per gioni"
                Case SchedulerNavigatorStringId.WeekViewButtonCaption
                    Return "Vista per settimane"
                Case SchedulerNavigatorStringId.MonthViewButtonCaption
                    Return "Vista per mesi"
                Case SchedulerNavigatorStringId.TimelineViewButtonCaption
                    Return "Timeline"
                Case SchedulerNavigatorStringId.ShowWeekendCheckboxCaption
                    Return "Visualizza settimane"
                Case SchedulerNavigatorStringId.TodayButtonCaptionToday
                    Return "Oggi"
                Case SchedulerNavigatorStringId.TodayButtonCaptionThisWeek
                    Return "Questa settimana"
                Case SchedulerNavigatorStringId.TodayButtonCaptionThisMonth
                    Return "Questo mese"
            End Select

            Return String.Empty
        End Function
    End Class

    Public Class ItalianMessageLocalizationProvider
    Inherits RadMessageLocalizationProvider

    Public Overloads Overrides Function GetLocalizedString(ByVal id As String) As String
        Select Case id
            Case RadMessageStringID.AbortButton
                Return "Annulla"
            Case RadMessageStringID.CancelButton
                Return "Cancella"
            Case RadMessageStringID.IgnoreButton
                Return "Ignora"
            Case RadMessageStringID.NoButton
                Return "No"
            Case RadMessageStringID.OKButton
                Return "OK"
            Case RadMessageStringID.RetryButton
                Return "Riprova"
            Case RadMessageStringID.YesButton
                Return "Si"
            Case Else
                Return MyBase.GetLocalizedString(id)
        End Select
        End Function
    End Class

    Public Class ItalianPdfViewerLocalizationProvider
        Inherits PdfViewerLocalizationProvider

        Public Overrides Function GetLocalizedString(ByVal id As String) As String

            Select Case id
                Case PdfViewerStringId.ContextMenuCopy
                    Return "&Copia"
                Case PdfViewerStringId.ContextMenuSelectAll
                    Return "Selezio&na tutto"
                Case PdfViewerStringId.ContextMenuDeselectAll
                    Return "&Deseleziona tutto"
                Case PdfViewerStringId.ContextMenuHand
                    Return "&Mano"
                Case PdfViewerStringId.ContextMenuSelection
                    Return "&Selezione"
                Case PdfViewerStringId.ContextMenuPreviousPage
                    Return "&Pagina Precedente"
                Case PdfViewerStringId.ContextMenuNextPage
                    Return "Pagina S&uccessiva"
                Case PdfViewerStringId.ContextMenuPrint
                    Return "&Stampa..."
                Case PdfViewerStringId.ContextMenuFind
                    Return "&Trova successivo"

                Case PdfViewerStringId.NavigatorOpenButton
                    Return "Apri"
                Case PdfViewerStringId.NavigatorPrintButton
                    Return "Stampa"

                Case PdfViewerStringId.NavigatorPreviousPageButton
                    Return "Pagina precedente"
                Case PdfViewerStringId.NavigatorNextPageButton
                    Return "Pagina successiva"
                Case PdfViewerStringId.NavigatorCurrentPageTextBox
                    Return "Pagina corrente"
                Case PdfViewerStringId.NavigatorTotalPagesLabel
                    Return "Totale pagina"

                Case PdfViewerStringId.NavigatorZoomInButton
                    Return "Zoom avanti"
                Case PdfViewerStringId.NavigatorZoomOutButton
                    Return "Zoom indietro"
                Case PdfViewerStringId.NavigatorZoomDropDown
                    Return "Zoom drop-down"

                Case PdfViewerStringId.NavigatorHandToolButton
                    Return "Mano"
                Case PdfViewerStringId.NavigatorSelectToolButton
                    Return "Selezione"

                Case PdfViewerStringId.NavigatorFindNextButton
                    Return "Trova succassivo"
                Case PdfViewerStringId.NavigatorFindPreviousButton
                    Return "Trova precedente"
                Case PdfViewerStringId.NavigatorSearchTextBox
                    Return "Trova"
                Case PdfViewerStringId.NavigatorSearchTextBoxNullText
                    Return "Trova"
                Case PdfViewerStringId.NavigatorFitToWidthButton
                    Return "Adatta le dimensioni alla larghezza della pagina"
                Case PdfViewerStringId.NavigatorFitToPageButton
                    Return "Adatta una pagina intera alla finestra"

                Case PdfViewerStringId.PrintPreviewButtonCancel
                    Return "Annulla"
                Case PdfViewerStringId.PrintPreviewButtonPrint
                    Return "Stampa"
                Case PdfViewerStringId.PrintPreviewButtonSettings
                    Return "Imposta Pagina"
                Case PdfViewerStringId.PrintPreviewButtonWatermark
                    Return "Filigrana"
                Case PdfViewerStringId.PrintPreviewFormTitle
                    Return "Anteprima di stampa"
                Case PdfViewerStringId.PrintPreviewGroupBoxSettings
                    Return "Impostazioni"
                Case PdfViewerStringId.PrintPreviewGroupBoxOrientation
                    Return "Orientamento"
                Case PdfViewerStringId.PrintPreviewGroupBoxPreview
                    Return "Anteprima"
                Case PdfViewerStringId.PrintPreviewRadioLandscape
                    Return "Orizzontale"
                Case PdfViewerStringId.PrintPreviewRadioPortrait
                    Return "Verticale"
                Case PdfViewerStringId.PrintPreviewLabelScale
                    Return "Scala {0}%"
                Case PdfViewerStringId.PrintPreviewLabelCurrentPage
                    Return "Pagina {0} di {1}"
                Case PdfViewerStringId.NavigatorDefaultStrip
                    Return "Default barra"

            End Select
            Return MyBase.GetLocalizedString(id)
        End Function
    End Class


End Namespace

