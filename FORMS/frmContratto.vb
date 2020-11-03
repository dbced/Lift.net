Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class FrmContratto
    Private ws As New webServices
    Private schedaContratto As Threading.Tasks.Task(Of parmGetSchedaImpianto)

    Dim statoCaricaTipoContratti As Boolean
    Dim statoCaricaTipoPrestazione As Boolean
    Dim statoCaricaTipoFatturazione As Boolean
    Dim statoCaricaRivalutazione As Boolean
    Dim statoCaricaTipoManutenzione As Boolean
    Dim statoCaricaCliente9516 As Boolean

    Private idImpianto As String
    Dim azione As String
    Dim formInCaricamento As Boolean

    Public Sub New(codContratto As String, ByVal inAzione As String, Optional ByVal ElencoCentri As String = "", Optional ByVal inUser As String = "", Optional ByVal inRuolo As String = "", Optional ByVal inUserAS As String = "", Optional ByVal modifica As Boolean = True, Optional ByVal testo As String = "")
        InitializeComponent()
        WireEvents()

        idImpianto = codContratto
        azione = inAzione

        'ruolo = inRuolo
        'user = inUser
        'userAS = inUserAS
        'gElencoCentri = ElencoCentri
    End Sub

    Private Sub FrmContratto_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            cmdOkSearchCli.ThemeName = "buttonDFT"
            cmdOkSearchCliGes.ThemeName = "buttonDFT"
            cmdConferma.ThemeName = "buttonBLU"
            cmdAnnulla.ThemeName = "buttonDFT"
            cmdOkSearchCli.ThemeName = "buttonDFT"
            cmdOkSearchCliGes.ThemeName = "buttonDFT"

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            t1.Enabled = True
            formInCaricamento = True

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FrmImpianto_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try

            Me.gestisci_campi_form()

            If azione = "NUOVO" Then
                Me.azzera_campi_form()
                Me.carica_dati_liste()
            Else
                'Me.async_carica_scheda_impianto()
            End If

            'AddHandler cmbCategoriaImp.SelectedValueChanged, AddressOf cmbCategoriaImp_SelectedValueChanged

        Catch ex As Exception
            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False


        End Try

    End Sub
    Protected Sub WireEvents()
        'AddHandler grid.ViewCellFormatting, AddressOf gridFatt_ViewCellFormatting
        'AddHandler grid.ViewRowFormatting, AddressOf gridFatt_ViewRowFormatting
        'AddHandler grid.CellFormatting, AddressOf gridFatt_CellFormatting
        'AddHandler grid.ContextMenuOpening, AddressOf gridFatt_ContextMenuOpening
        'AddHandler grid.GroupSummaryEvaluate, AddressOf grid_GroupSummaryEvaluate
        'AddHandler grid.EditorRequired, AddressOf grid_EditorRequired

        'AddHandler gridAsset.ContextMenuOpening, AddressOf gridFatt_ContextMenuOpening
        'AddHandler gridAsset.ViewCellFormatting, AddressOf gridFatt_ViewCellFormatting
        'AddHandler gridAsset.CellFormatting, AddressOf gridFatt_CellFormatting
        'AddHandler gridAsset.ViewRowFormatting, AddressOf gridFatt_ViewRowFormatting
        'AddHandler gridAsset.CurrentRowChanged, AddressOf gridAsset_CurrentRowChanged

        'AddHandler gridTecAsset.ViewCellFormatting, AddressOf gridFatt_ViewCellFormatting
        'AddHandler gridTecAsset.ViewRowFormatting, AddressOf gridFatt_ViewRowFormatting
        'AddHandler gridTecAsset.CellFormatting, AddressOf gridFatt_CellFormatting
        'AddHandler gridTecAsset.ContextMenuOpening, AddressOf gridFatt_ContextMenuOpening
        'AddHandler gridTecAsset.GroupSummaryEvaluate, AddressOf grid_GroupSummaryEvaluate

        'AddHandler gridTpVis.CurrentRowChanged, AddressOf gridTpVis_CurrentRowChanged

        'AddHandler Me.gant.GanttViewElement.ItemEditing, AddressOf GanttViewElement_ItemEditing
        'AddHandler Me.gant.TextViewItemFormatting, AddressOf radGanttView_TextViewItemFormatting
        'AddHandler Me.gant.TextViewCellFormatting, AddressOf radGanttView_TextViewCellFormatting


    End Sub

    Private Sub carica_dati_liste()
        Try

            carica_combo_tabelle("TPC", cmbTipoContratto, "")
            carica_combo_tabelle("TMA", cmbPrestazioni, "")
            carica_combo_tabelle("TFA", cmbTipoFatt, "")
            carica_combo_tabelle("TRC", cmbRivalut, "")
            carica_combo_tabelle("PMA", cmbPianoManut, "")
            carica_combo_tabelle("P95", cmb9516, "")

            'carica_combo_tipo_impianto()
            'carica_combo_enti_ispettivi()
            'carica_combo_enti_collaudatori()
            'carica_combo_costruttori()
            'carica_combo_strade()
            'carica_combo_TipoImpianto()
            'carica_combo_TipoImp()
            'carica_combo_reperibilita()
            'carica_combo_callCenter()
            'carica_liste_elementi_dati_tecnici()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub gestisci_campi_form()
        Try
            Select Case azione
                Case "NUOVO"
                    txtCodice.ReadOnly = True
                    For Each pag As RadPageViewPage In RPcontainer.Pages
                        If pag.TabIndex <> 0 Then
                            pag.Item.Visibility = ElementVisibility.Collapsed
                        End If
                    Next
                Case "MODIFICA"
                    txtCodice.ReadOnly = True
                    cmbTipoContratto.ReadOnly = True

                    For Each pag As RadPageViewPage In RPcontainer.Pages
                        If pag.TabIndex = 4 Then
                            pag.Item.Visibility = ElementVisibility.Collapsed
                        Else
                            pag.Item.Visibility = ElementVisibility.Visible
                        End If

                    Next
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub carica_dati_form(dati As parmGetSchedaImpianto)
        Try
            txtCodice.Text = Format(Val(dati.AICIM), "0000000")
            txtCodCliente.Text = dati.AICLI
            'txtIndirizzo.Text = dati.AIIND
            'txtCap.Text = Format(Val(dati.AICAP), "00000")
            'txtCodAmm.Text = dati.AIAMM
            'txtProv.Text = dati.AISPR

            'txtDesCli.Text = dati.DESCLI
            'txtDesAmm.Text = dati.DESAMM
            'txtlocalita.Text = dati.AILOC

            'async_carica_griglia_asset_impianto()
            'async_carica_griglia_documenti(dati.AICIM, "", dati.AICLI)
            'async_carica_gantt_manutenzioni(dati.AICIM)
            'async_carica_grafico_manutenzioni(dati.AICIM)
            'async_carica_grafico_buoni(dati.AICIM)
            'async_carica_grafico_canoni(dati.AICIM)
            'async_carica_grafico_fatturato(dati.AICIM, "")
            'async_carica_grafico_chiamate(dati.AICIM)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub azzera_campi_form()
        Try
            'txtCodice.Text = ""
            'txtCodCliente.Text = ""
            'txtIndirizzo.Text = ""
            'txtCap.Text = ""
            'txtCodAmm.Text = ""
            'txtDesCli.Text = ""
            'txtDesAmm.Text = ""
            'txtlocalita.Text = ""
            'txtZonaRep.Text = ""
            'txtGestore.Text = ""
            'txtTelesoccorso.Text = ""
            'txtMatricola.Text = ""
            'txtScala.Text = ""
            'txtEdificio.Text = ""
            'txtInterno.Text = ""
            'txtDataNomina.Text = Nothing

            'cmbTecnico.SelectedIndex = -1
            'cmbZonaCentro.SelectedIndex = -1
            'cmbStrada.SelectedIndex = -1
            'cmbCategoriaImp.SelectedIndex = -1
            'cmbTipoContratto.SelectedIndex = -1
            'cmbTipoImp.SelectedIndex = -1
            'cmbReperib.SelectedIndex = -1
            'cmbCallCenter.SelectedIndex = -1
            'cmbEnteColl.SelectedIndex = -1
            'cmbEnteIsp.SelectedIndex = -1
            'cmbCostruttore.SelectedIndex = -1
            'cmbZona.SelectedIndex = -1

            'chkLineaNsCarico.Checked = CheckState.Unchecked
            'chkTag.Checked = CheckState.Unchecked

        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub carica_combo_tipo_impianto()
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("TPC", "")
            Await elementi

            Me.cmbTipoContratto.DataSource = elementi.Result
            Me.cmbTipoContratto.DisplayMember = "desElem"
            Me.cmbTipoContratto.ValueMember = "codElem"
            Me.cmbTipoContratto.SelectedIndex = -1

            If azione = "MODIFICA" Then
                cmbTipoContratto.SelectedValue = schedaContratto.Result.AICCI
            End If

            statoCaricaTipoContratti = True

        Catch ex As Exception
            statoCaricaTipoContratti = True
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_tabelle(codTab As String, combo As RadDropDownList, valoreIniziale As String)
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella(codTab, "")
            Await elementi

            combo.DataSource = elementi.Result
            combo.DisplayMember = "desElem"
            combo.ValueMember = "codElem"
            combo.SelectedIndex = -1

            If azione = "MODIFICA" Then
                combo.SelectedValue = valoreIniziale
            End If

            Select Case codTab
                Case "TPC"
                    statoCaricaTipoContratti = True
                Case "TMA"
                    statoCaricaTipoPrestazione = True
                Case "TFA"
                    statoCaricaTipoFatturazione = True
                Case "TRC"
                    statoCaricaRivalutazione = True
                Case "PMA"
                    statoCaricaTipoManutenzione = True
                Case "P95"
                    statoCaricaCliente9516 = True

            End Select



        Catch ex As Exception
            statoCaricaTipoContratti = True
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub
    Private Sub t1_Tick(sender As Object, e As EventArgs) Handles t1.Tick
        Try
            If statoCaricaTipoContratti = True Then

                wb.AssociatedControl = Nothing
                wb.StopWaiting()
                wb.Visible = False

                t1.Enabled = False
                formInCaricamento = False

            End If

        Catch ex As Exception

            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False
            t1.Enabled = False
        End Try
    End Sub
End Class
