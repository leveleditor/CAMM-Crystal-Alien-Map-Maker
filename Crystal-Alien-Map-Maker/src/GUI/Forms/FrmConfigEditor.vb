Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

Public Class FrmConfigEditor
    Private saved As Boolean

    Private Sub FrmConfigEditor_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Reload configuration data.
        LoadAssets()
        If Not LoadConfig() Then
            MsgBox("Configuration Editor could not open: Could not reload the configuration data.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Me.Close()
        End If

        saved = True

        pnlTiles.Controls.Clear()
        pnlBuildings.Controls.Clear()
        pnlUnits.Controls.Clear()

        'Add Tiles to editor.
        For Each td As TileDef In TileDefs
            Dim tEntry As TileEntry = New TileEntry(td.TileId, td.IsPassable, td.IsMinerals, td.ImageUrl)
            AddHandler tEntry.BtnNewClicked, AddressOf tileEntry_btnNew_Clicked
            AddHandler tEntry.BtnRemoveClicked, AddressOf tileEntry_btnRemove_Clicked
            AddHandler tEntry.BtnBrowseClicked, AddressOf tileEntry_btnBrowse_Clicked
            AddHandler tEntry.TxtImageUrlMouseEntered, AddressOf tileEntry_txtImageUrl_MouseEnter
            AddHandler tEntry.TxtImageUrlMouseLeft, AddressOf tileEntry_txtImageUrl_MouseLeave
            pnlTiles.Controls.Add(tEntry)
        Next

        'Add Buildings to editor.
        For Each bd As BuildingDef In BuildingDefs
            Dim bEntry As BuildingEntry = New BuildingEntry(bd.BuildingId, bd.BuildingW, bd.BuildingH, bd.Team, bd.OffsetY, bd.FullImageUrl, bd.ShadowImageUrl)
            AddHandler bEntry.BtnNewClicked, AddressOf buildingEntry_btnNew_Clicked
            AddHandler bEntry.BtnRemoveClicked, AddressOf buildingEntry_btnRemove_Clicked
            AddHandler bEntry.BtnBrowseFullImageClicked, AddressOf BuildingEntryBtnBrowseFullImageClicked
            AddHandler bEntry.BtnBrowseShadowImageClicked, AddressOf BuildingEntryBtnBrowseShadowImageClicked
            AddHandler bEntry.TxtFullImageUrlMouseEntered, AddressOf BuildingEntryTxtFullImageUrlMouseEnter
            AddHandler bEntry.TxtFullImageUrlMouseLeft, AddressOf BuildingEntryTxtFullImageUrlMouseLeave
            AddHandler bEntry.TxtShadowImageUrlMouseEntered, AddressOf BuildingEntryTxtShadowImageUrlMouseEnter
            AddHandler bEntry.TxtShadowImageUrlMouseLeft, AddressOf BuildingEntryTxtShadowImageUrlMouseLeave
            pnlBuildings.Controls.Add(bEntry)
        Next

        'Add Units to editor.
        For Each ud As UnitDef In UnitDefs
            Dim uEntry As UnitEntry = New UnitEntry(ud.UnitId, ud.Team, ud.Altitude, ud.IsPickup, ud.OffsetY, ud.FullImageUrl, ud.ShadowImageUrl)
            AddHandler uEntry.BtnNewClicked, AddressOf unitEntry_btnNew_Clicked
            AddHandler uEntry.BtnRemoveClicked, AddressOf unitEntry_btnRemove_Clicked
            AddHandler uEntry.BtnBrowseFullImageClicked, AddressOf UnitEntryBtnBrowseFullImageClicked
            AddHandler uEntry.BtnBrowseShadowImageClicked, AddressOf UnitEntryBtnBrowseShadowImageClicked
            AddHandler uEntry.TxtFullImageUrlMouseEntered, AddressOf UnitEntryTxtFullImageUrlMouseEnter
            AddHandler uEntry.TxtFullImageUrlMouseLeft, AddressOf UnitEntryTxtFullImageUrlMouseLeave
            AddHandler uEntry.TxtShadowImageUrlMouseEntered, AddressOf UnitEntryTxtShadowImageUrlMouseEnter
            AddHandler uEntry.TxtShadowImageUrlMouseLeft, AddressOf UnitEntryTxtShadowImageUrlMouseLeave
            Me.pnlUnits.Controls.Add(uEntry)
        Next

        ReorderTileEntries()
        ReorderBuildingEntries()
        ReorderUnitEntries()
    End Sub

    Private Sub FrmConfigEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim msgResult As DialogResult = DialogResult.None
        Dim doReload As Boolean = False
        If Not saved Then
            msgResult = MsgBox("Do you want to save all changes you've made?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
        End If

        If msgResult = DialogResult.Yes Then
            SaveAll()
            doReload = True
        ElseIf msgResult <> DialogResult.No And msgResult <> DialogResult.None Then
            e.Cancel = True
        End If

        If doReload And Not e.Cancel Then
            'Reload configuration data.
            LoadAssets()
            If Not LoadConfig() Then
                MsgBox("Configuration Editor could not reload the configuration data." + vbNewLine + "You may need to fix this manually and restart the program.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ReorderTileEntries()
        pnlTiles.SuspendLayout()
        tabTiles.SuspendLayout()
        For i As Integer = 0 To pnlTiles.Controls.Count - 1
            pnlTiles.Controls(i).Location = New Point(pnlTiles.AutoScrollPosition.X + 3, pnlTiles.AutoScrollPosition.Y + (i * 31) + 3)
            pnlTiles.Controls(i).PerformLayout()
        Next
        pnlTiles.ResumeLayout()
        tabTiles.ResumeLayout()
        pnlTiles.PerformLayout()
        tabTiles.PerformLayout()
        pnlTiles.PerformLayout()
        tabTiles.PerformLayout()
    End Sub

    Private Sub ReorderBuildingEntries()
        pnlBuildings.SuspendLayout()
        tabBuildings.SuspendLayout()
        For i As Integer = 0 To pnlBuildings.Controls.Count - 1
            pnlBuildings.Controls(i).Location = New Point(pnlBuildings.AutoScrollPosition.X + 3, pnlBuildings.AutoScrollPosition.Y + (i * 31) + 3)
            pnlBuildings.Controls(i).PerformLayout()
        Next
        pnlBuildings.ResumeLayout()
        tabBuildings.ResumeLayout()
        pnlBuildings.PerformLayout()
        tabBuildings.PerformLayout()
        pnlBuildings.PerformLayout()
        tabBuildings.PerformLayout()
    End Sub

    Private Sub ReorderUnitEntries()
        pnlUnits.SuspendLayout()
        tabUnits.SuspendLayout()
        For i As Integer = 0 To pnlUnits.Controls.Count - 1
            pnlUnits.Controls(i).Location = New Point(pnlUnits.AutoScrollPosition.X + 3, pnlUnits.AutoScrollPosition.Y + (i * 31) + 3)
            pnlUnits.Controls(i).PerformLayout()
        Next
        pnlUnits.ResumeLayout()
        tabUnits.ResumeLayout()
        pnlUnits.PerformLayout()
        tabUnits.PerformLayout()
        pnlUnits.PerformLayout()
        tabUnits.PerformLayout()
    End Sub

    Private Sub tileEntry_btnNew_Clicked(sender As TileEntry, e As EventArgs)
        pnlTiles.SuspendLayout()
        Dim tEntry As TileEntry = New TileEntry() With {.Location = New Point(pnlTiles.AutoScrollPosition.X + 3, pnlTiles.AutoScrollPosition.Y + 3)}
        AddHandler tEntry.BtnNewClicked, AddressOf tileEntry_btnNew_Clicked
        AddHandler tEntry.BtnRemoveClicked, AddressOf tileEntry_btnRemove_Clicked
        AddHandler tEntry.BtnBrowseClicked, AddressOf tileEntry_btnBrowse_Clicked
        AddHandler tEntry.TxtImageUrlMouseEntered, AddressOf tileEntry_txtImageUrl_MouseEnter
        AddHandler tEntry.TxtImageUrlMouseLeft, AddressOf tileEntry_txtImageUrl_MouseLeave
        pnlTiles.Controls.Add(tEntry)
        ReorderTileEntries()
        saved = False
    End Sub

    Private Sub tileEntry_btnRemove_Clicked(sender As TileEntry, e As EventArgs)
        pnlTiles.SuspendLayout()
        pnlTiles.Controls.Remove(sender)
        sender.Dispose()
        ReorderTileEntries()
        saved = False
    End Sub

    Private Sub tileEntry_btnBrowse_Clicked(sender As TileEntry, e As EventArgs)
        If My.Computer.FileSystem.FileExists(DataPath + "/" + sender.ImageUrl) Then
            openImage.InitialDirectory = New Uri(DataPath + "/" + sender.ImageUrl).ToString().Replace(My.Computer.FileSystem.GetFileInfo(DataPath + "/" + sender.ImageUrl).Name, "")
            openImage.FileName = My.Computer.FileSystem.GetFileInfo(DataPath + "/" + sender.ImageUrl).Name
        Else
            openImage.InitialDirectory = New Uri(DataPath + "/Tiles").ToString()
            openImage.FileName = ""
        End If
        If openImage.ShowDialog(Me) = DialogResult.OK Then
            Dim test1 As Uri = New Uri(DataPath + "/")
            Dim test2 As Uri = New Uri(openImage.FileName)
            Dim test3 As Uri = test1.MakeRelativeUri(test2)
            sender.ImageUrl = Uri.UnescapeDataString(test3.ToString())
            saved = False
        End If
    End Sub

    Private Sub tileEntry_txtImageUrl_MouseEnter(sender As TileEntry, e As EventArgs)
        Try
            picPreview.Image = Image.FromFile(DataPath + "/" + sender.ImageUrl)
        Catch ex As Exception
            picPreview.Image = Nothing
        End Try
        picPreview.Show()
    End Sub

    Private Sub tileEntry_txtImageUrl_MouseLeave(sender As TileEntry, e As EventArgs)
        picPreview.Image = Nothing
        picPreview.Hide()
    End Sub

    Private Sub buildingEntry_btnNew_Clicked(sender As BuildingEntry, e As EventArgs)
        pnlBuildings.SuspendLayout()
        Dim bEntry As BuildingEntry = New BuildingEntry() With {.Location = New Point(pnlBuildings.AutoScrollPosition.X + 3, pnlBuildings.AutoScrollPosition.Y + 3)}
        AddHandler bEntry.BtnNewClicked, AddressOf buildingEntry_btnNew_Clicked
        AddHandler bEntry.BtnRemoveClicked, AddressOf buildingEntry_btnRemove_Clicked
        AddHandler bEntry.BtnBrowseFullImageClicked, AddressOf BuildingEntryBtnBrowseFullImageClicked
        AddHandler bEntry.BtnBrowseShadowImageClicked, AddressOf BuildingEntryBtnBrowseShadowImageClicked
        AddHandler bEntry.TxtFullImageUrlMouseEntered, AddressOf BuildingEntryTxtFullImageUrlMouseEnter
        AddHandler bEntry.TxtFullImageUrlMouseLeft, AddressOf BuildingEntryTxtFullImageUrlMouseLeave
        AddHandler bEntry.TxtShadowImageUrlMouseEntered, AddressOf BuildingEntryTxtShadowImageUrlMouseEnter
        AddHandler bEntry.TxtShadowImageUrlMouseLeft, AddressOf BuildingEntryTxtShadowImageUrlMouseLeave
        pnlBuildings.Controls.Add(bEntry)
        ReorderBuildingEntries()
        saved = False
    End Sub

    Private Sub buildingEntry_btnRemove_Clicked(sender As BuildingEntry, e As EventArgs)
        pnlBuildings.SuspendLayout()
        pnlBuildings.Controls.Remove(sender)
        sender.Dispose()
        ReorderBuildingEntries()
        saved = False
    End Sub

    Private Sub BuildingEntryBtnBrowseFullImageClicked(sender As BuildingEntry, e As EventArgs)
        If My.Computer.FileSystem.FileExists(DataPath + "/" + sender.FullImageUrl) Then
            openImage.InitialDirectory = New Uri(DataPath + "/" + sender.FullImageUrl).ToString().Replace(My.Computer.FileSystem.GetFileInfo(DataPath + "/" + sender.FullImageUrl).Name, "")
            openImage.FileName = My.Computer.FileSystem.GetFileInfo(DataPath + "/" + sender.FullImageUrl).Name
        Else
            openImage.InitialDirectory = New Uri(DataPath + "/Buildings").ToString()
            openImage.FileName = ""
        End If
        If openImage.ShowDialog(Me) = DialogResult.OK Then
            Dim test1 As Uri = New Uri(DataPath + "/")
            Dim test2 As Uri = New Uri(openImage.FileName)
            Dim test3 As Uri = test1.MakeRelativeUri(test2)
            sender.FullImageUrl = Uri.UnescapeDataString(test3.ToString())
            saved = False
        End If
    End Sub

    Private Sub BuildingEntryBtnBrowseShadowImageClicked(sender As BuildingEntry, e As EventArgs)
        If My.Computer.FileSystem.FileExists(DataPath + "/" + sender.ShadowImageUrl) Then
            openImage.InitialDirectory = New Uri(DataPath + "/" + sender.ShadowImageUrl).ToString().Replace(My.Computer.FileSystem.GetFileInfo(DataPath + "/" + sender.ShadowImageUrl).Name, "")
            openImage.FileName = My.Computer.FileSystem.GetFileInfo(DataPath + "/" + sender.ShadowImageUrl).Name
        Else
            openImage.InitialDirectory = New Uri(DataPath + "/Buildings").ToString()
            openImage.FileName = ""
        End If
        If openImage.ShowDialog(Me) = DialogResult.OK Then
            Dim test1 As Uri = New Uri(DataPath + "/")
            Dim test2 As Uri = New Uri(openImage.FileName)
            Dim test3 As Uri = test1.MakeRelativeUri(test2)
            sender.ShadowImageUrl = Uri.UnescapeDataString(test3.ToString())
            saved = False
        End If
    End Sub

    Private Sub BuildingEntryTxtFullImageUrlMouseEnter(sender As BuildingEntry, e As EventArgs)
        Try
            picPreview.Image = Image.FromFile(DataPath + "/" + sender.FullImageUrl)
        Catch ex As Exception
            picPreview.Image = Nothing
        End Try
        picPreview.Show()
    End Sub

    Private Sub BuildingEntryTxtFullImageUrlMouseLeave(sender As BuildingEntry, e As EventArgs)
        picPreview.Image = Nothing
        picPreview.Hide()
    End Sub

    Private Sub BuildingEntryTxtShadowImageUrlMouseEnter(sender As BuildingEntry, e As EventArgs)
        Try
            picPreview.Image = Image.FromFile(DataPath + "/" + sender.ShadowImageUrl)
        Catch ex As Exception
            picPreview.Image = Nothing
        End Try
        picPreview.Show()
    End Sub

    Private Sub BuildingEntryTxtShadowImageUrlMouseLeave(sender As BuildingEntry, e As EventArgs)
        picPreview.Image = Nothing
        picPreview.Hide()
    End Sub

    Private Sub unitEntry_btnNew_Clicked(sender As UnitEntry, e As EventArgs)
        pnlUnits.SuspendLayout()
        Dim uEntry As UnitEntry = New UnitEntry() With {.Location = New Point(pnlUnits.AutoScrollPosition.X + 3, pnlUnits.AutoScrollPosition.Y + 3)}
        AddHandler uEntry.BtnNewClicked, AddressOf unitEntry_btnNew_Clicked
        AddHandler uEntry.BtnRemoveClicked, AddressOf unitEntry_btnRemove_Clicked
        AddHandler uEntry.BtnBrowseFullImageClicked, AddressOf UnitEntryBtnBrowseFullImageClicked
        AddHandler uEntry.BtnBrowseShadowImageClicked, AddressOf UnitEntryBtnBrowseShadowImageClicked
        AddHandler uEntry.TxtFullImageUrlMouseEntered, AddressOf UnitEntryTxtFullImageUrlMouseEnter
        AddHandler uEntry.TxtFullImageUrlMouseLeft, AddressOf UnitEntryTxtFullImageUrlMouseLeave
        AddHandler uEntry.TxtShadowImageUrlMouseEntered, AddressOf UnitEntryTxtShadowImageUrlMouseEnter
        AddHandler uEntry.TxtShadowImageUrlMouseLeft, AddressOf UnitEntryTxtShadowImageUrlMouseLeave
        pnlUnits.Controls.Add(uEntry)
        ReorderUnitEntries()
        saved = False
    End Sub

    Private Sub unitEntry_btnRemove_Clicked(sender As UnitEntry, e As EventArgs)
        pnlUnits.SuspendLayout()
        pnlUnits.Controls.Remove(sender)
        sender.Dispose()
        ReorderUnitEntries()
        saved = False
    End Sub

    Private Sub UnitEntryBtnBrowseFullImageClicked(sender As UnitEntry, e As EventArgs)
        If My.Computer.FileSystem.FileExists(DataPath + "/" + sender.FullImageUrl) Then
            openImage.InitialDirectory = New Uri(DataPath + "/" + sender.FullImageUrl).ToString().Replace(My.Computer.FileSystem.GetFileInfo(DataPath + "/" + sender.FullImageUrl).Name, "")
            openImage.FileName = My.Computer.FileSystem.GetFileInfo(DataPath + "/" + sender.FullImageUrl).Name
        Else
            openImage.InitialDirectory = New Uri(DataPath + "/Units").ToString()
            openImage.FileName = ""
        End If
        If openImage.ShowDialog(Me) = DialogResult.OK Then
            Dim test1 As Uri = New Uri(DataPath + "/")
            Dim test2 As Uri = New Uri(openImage.FileName)
            Dim test3 As Uri = test1.MakeRelativeUri(test2)
            sender.FullImageUrl = Uri.UnescapeDataString(test3.ToString())
            saved = False
        End If
    End Sub

    Private Sub UnitEntryBtnBrowseShadowImageClicked(sender As UnitEntry, e As EventArgs)
        If My.Computer.FileSystem.FileExists(DataPath + "/" + sender.ShadowImageUrl) Then
            openImage.InitialDirectory = New Uri(DataPath + "/" + sender.ShadowImageUrl).ToString().Replace(My.Computer.FileSystem.GetFileInfo(DataPath + "/" + sender.ShadowImageUrl).Name, "")
            openImage.FileName = My.Computer.FileSystem.GetFileInfo(DataPath + "/" + sender.ShadowImageUrl).Name
        Else
            openImage.InitialDirectory = New Uri(DataPath + "/Units").ToString()
            openImage.FileName = ""
        End If
        If openImage.ShowDialog(Me) = DialogResult.OK Then
            Dim test1 As Uri = New Uri(DataPath + "/")
            Dim test2 As Uri = New Uri(openImage.FileName)
            Dim test3 As Uri = test1.MakeRelativeUri(test2)
            sender.ShadowImageUrl = Uri.UnescapeDataString(test3.ToString())
            saved = False
        End If
    End Sub

    Private Sub UnitEntryTxtFullImageUrlMouseEnter(sender As UnitEntry, e As EventArgs)
        Try
            picPreview.Image = Image.FromFile(DataPath + "/" + sender.FullImageUrl)
        Catch ex As Exception
            picPreview.Image = Nothing
        End Try
        picPreview.Show()
    End Sub

    Private Sub UnitEntryTxtFullImageUrlMouseLeave(sender As UnitEntry, e As EventArgs)
        picPreview.Image = Nothing
        picPreview.Hide()
    End Sub

    Private Sub UnitEntryTxtShadowImageUrlMouseEnter(sender As UnitEntry, e As EventArgs)
        Try
            picPreview.Image = Image.FromFile(DataPath + "/" + sender.ShadowImageUrl)
        Catch ex As Exception
            picPreview.Image = Nothing
        End Try
        picPreview.Show()
    End Sub

    Private Sub UnitEntryTxtShadowImageUrlMouseLeave(sender As UnitEntry, e As EventArgs)
        picPreview.Image = Nothing
        picPreview.Hide()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSaveAll_Click(sender As Object, e As EventArgs) Handles btnSaveAll.Click
        SaveAll()
        lblSaved.Show()
    End Sub

    Private Sub SaveAll()
        Dim tileData As New List(Of TileDefData)(From t As TileEntry In pnlTiles.Controls Select New TileDefData() With
        {
            .Id = t.TileId,
            .IsPassable = t.IsPassable,
            .IsMinerals = t.IsMinerals,
            .ImageUrl = t.ImageUrl
        })

        Dim buildingData As New List(Of BuildingDefData)(From b As BuildingEntry In pnlBuildings.Controls Select New BuildingDefData() With
        {
            .Id = b.BuildingId,
            .Width = b.BuildingW,
            .Height = b.BuildingH,
            .Team = CInt(b.Team),
            .OffsetY = b.OffsetY,
            .ImageUrl = b.FullImageUrl,
            .ShadowImageUrl = b.ShadowImageUrl
        })

        Dim unitData As New List(Of UnitDefData)(From u As UnitEntry In pnlUnits.Controls Select New UnitDefData() With
        {
            .Id = u.UnitId,
            .Team = CInt(u.Team),
            .Altitude = u.Altitude,
            .IsPickup = u.IsPickup,
            .OffsetY = u.OffsetY,
            .ImageUrl = u.FullImageUrl,
            .ShadowImageUrl = u.ShadowImageUrl
        })

        Dim configData As New ConfigData() With {
            .Format = ConfigFormat,
            .TileAscii = AsciiLookup,
            .Tiles = tileData,
            .Buildings = buildingData,
            .Units = unitData
        }

        File.WriteAllText(ConfigFile, JsonConvert.SerializeObject(configData, Formatting.Indented), Encoding.UTF8)

        saved = True
    End Sub

End Class
