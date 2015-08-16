Imports System.Text

Public Class FrmTileData
    Private Saved As Boolean

    Private Sub FrmTileData_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Reload configuration data.
        LoadAssets()
        If Not LoadConfig() Then
            MsgBox("Tile Data Editor could not open: Could not reload the configuration data.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Me.Close()
        End If

        Saved = True

        pnlTerrain.Controls.Clear()
        pnlBuildings.Controls.Clear()
        pnlUnits.Controls.Clear()

        'Add Tiles to editor.
        For Each td As TileDef In TileDefs
            Dim newTileEntry As TileEntry = New TileEntry(td.TileId, td.IsPassable, td.IsMinerals, td.ImageUrl)
            'NewTerrainEntry.Location = New Point(3, (i * 31) + 3)
            AddHandler newTileEntry.BtnNewClicked, AddressOf tileEntry_btnNew_Clicked
            AddHandler newTileEntry.BtnRemoveClicked, AddressOf tileEntry_btnRemove_Clicked
            AddHandler newTileEntry.BtnBrowseClicked, AddressOf tileEntry_btnBrowse_Clicked
            AddHandler newTileEntry.TxtImageUrlMouseEntered, AddressOf tileEntry_txtImageUrl_MouseEnter
            AddHandler newTileEntry.TxtImageUrlMouseLeft, AddressOf tileEntry_txtImageUrl_MouseLeave
            pnlTerrain.Controls.Add(newTileEntry)
        Next

        'Add Buildings to editor.
        For Each bd As BuildingDef In BuildingDefs
            Dim newObjectEntry As BuildingEntry = New BuildingEntry(bd.BuildingId, bd.BuildingW, bd.BuildingH, bd.Team, bd.OffsetY, bd.FullImageUrl, bd.ShadowImageUrl)
            'NewObjectEntry.Location = New Point(3, (i * 31) + 3)
            AddHandler newObjectEntry.BtnNewClicked, AddressOf buildingEntry_btnNew_Clicked
            AddHandler newObjectEntry.BtnRemoveClicked, AddressOf buildingEntry_btnRemove_Clicked
            AddHandler newObjectEntry.BtnBrowseFullImageClicked, AddressOf BuildingEntryBtnBrowseFullImageClicked
            AddHandler newObjectEntry.BtnBrowseShadowImageClicked, AddressOf BuildingEntryBtnBrowseShadowImageClicked
            AddHandler newObjectEntry.TxtFullImageUrlMouseEntered, AddressOf BuildingEntryTxtFullImageUrlMouseEnter
            AddHandler newObjectEntry.TxtFullImageUrlMouseLeft, AddressOf BuildingEntryTxtFullImageUrlMouseLeave
            AddHandler newObjectEntry.TxtShadowImageUrlMouseEntered, AddressOf BuildingEntryTxtShadowImageUrlMouseEnter
            AddHandler newObjectEntry.TxtShadowImageUrlMouseLeft, AddressOf BuildingEntryTxtShadowImageUrlMouseLeave
            pnlBuildings.Controls.Add(newObjectEntry)
        Next

        'Add Units to editor.
        For Each ud As UnitDef In UnitDefs
            Dim newObjectEntry As UnitEntry = New UnitEntry(ud.UnitId, ud.Team, ud.Altitude, ud.IsPickup, ud.OffsetY, ud.FullImageUrl, ud.ShadowImageUrl)
            'NewObjectEntry.Location = New Point(3, (i * 31) + 3)
            AddHandler newObjectEntry.BtnNewClicked, AddressOf unitEntry_btnNew_Clicked
            AddHandler newObjectEntry.BtnRemoveClicked, AddressOf unitEntry_btnRemove_Clicked
            AddHandler newObjectEntry.BtnBrowseFullImageClicked, AddressOf UnitEntryBtnBrowseFullImageClicked
            AddHandler newObjectEntry.BtnBrowseShadowImageClicked, AddressOf UnitEntryBtnBrowseShadowImageClicked
            AddHandler newObjectEntry.TxtFullImageUrlMouseEntered, AddressOf UnitEntryTxtFullImageUrlMouseEnter
            AddHandler newObjectEntry.TxtFullImageUrlMouseLeft, AddressOf UnitEntryTxtFullImageUrlMouseLeave
            AddHandler newObjectEntry.TxtShadowImageUrlMouseEntered, AddressOf UnitEntryTxtShadowImageUrlMouseEnter
            AddHandler newObjectEntry.TxtShadowImageUrlMouseLeft, AddressOf UnitEntryTxtShadowImageUrlMouseLeave
            Me.pnlUnits.Controls.Add(newObjectEntry)
        Next

        ReorderTerrainEntries()
        ReorderBuildingEntries()
        ReorderUnitEntries()
    End Sub

    Private Sub ReorderTerrainEntries()
        pnlTerrain.SuspendLayout()
        tabTiles.SuspendLayout()
        For i As Integer = 0 To pnlTerrain.Controls.Count - 1
            pnlTerrain.Controls(i).Location = New Point(pnlTerrain.AutoScrollPosition.X + 3, pnlTerrain.AutoScrollPosition.Y + (i * 31) + 3)
            pnlTerrain.Controls(i).PerformLayout()
        Next
        pnlTerrain.ResumeLayout()
        tabTiles.ResumeLayout()
        pnlTerrain.PerformLayout()
        tabTiles.PerformLayout()
        pnlTerrain.PerformLayout()
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
        pnlTerrain.SuspendLayout()
        Dim newTileEntry As TileEntry = New TileEntry() With {.Location = New Point(pnlTerrain.AutoScrollPosition.X + 3, pnlTerrain.AutoScrollPosition.Y + 3)}
        AddHandler newTileEntry.BtnNewClicked, AddressOf tileEntry_btnNew_Clicked
        AddHandler newTileEntry.BtnRemoveClicked, AddressOf tileEntry_btnRemove_Clicked
        AddHandler newTileEntry.BtnBrowseClicked, AddressOf tileEntry_btnBrowse_Clicked
        AddHandler newTileEntry.TxtImageUrlMouseEntered, AddressOf tileEntry_txtImageUrl_MouseEnter
        AddHandler newTileEntry.TxtImageUrlMouseLeft, AddressOf tileEntry_txtImageUrl_MouseLeave
        pnlTerrain.Controls.Add(newTileEntry)
        ReorderTerrainEntries()
        Saved = False
    End Sub

    Private Sub tileEntry_btnRemove_Clicked(sender As TileEntry, e As EventArgs)
        pnlTerrain.SuspendLayout()
        pnlTerrain.Controls.Remove(sender)
        sender.Dispose()
        ReorderTerrainEntries()
        Saved = False
    End Sub

    Private Sub tileEntry_btnBrowse_Clicked(sender As TileEntry, e As EventArgs)
        If My.Computer.FileSystem.FileExists(FullBasePath + "/" + sender.ImageUrl) Then
            openImage.InitialDirectory = New Uri(FullBasePath + "/" + sender.ImageUrl).ToString().Replace(My.Computer.FileSystem.GetFileInfo(FullBasePath + "/" + sender.ImageUrl).Name, "")
            openImage.FileName = My.Computer.FileSystem.GetFileInfo(FullBasePath + "/" + sender.ImageUrl).Name
        Else
            openImage.InitialDirectory = New Uri(FullBasePath + "/Tiles").ToString()
            openImage.FileName = ""
        End If
        If openImage.ShowDialog(Me) = DialogResult.OK Then
            Dim test1 As Uri = New Uri(FullBasePath + "/")
            Dim test2 As Uri = New Uri(openImage.FileName)
            Dim test3 As Uri = test1.MakeRelativeUri(test2)
            sender.ImageUrl = Uri.UnescapeDataString(test3.ToString())
            Saved = False
        End If
    End Sub

    Private Sub tileEntry_txtImageUrl_MouseEnter(sender As TileEntry, e As EventArgs)
        Try
            picPreview.Image = Image.FromFile(FullBasePath + "/" + sender.ImageUrl)
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
        Saved = False
    End Sub

    Private Sub buildingEntry_btnRemove_Clicked(sender As BuildingEntry, e As EventArgs)
        pnlBuildings.SuspendLayout()
        pnlBuildings.Controls.Remove(sender)
        sender.Dispose()
        ReorderBuildingEntries()
        Saved = False
    End Sub

    Private Sub BuildingEntryBtnBrowseFullImageClicked(sender As BuildingEntry, e As EventArgs)
        If My.Computer.FileSystem.FileExists(FullBasePath + "/" + sender.FullImageUrl) Then
            openImage.InitialDirectory = New Uri(FullBasePath + "/" + sender.FullImageUrl).ToString().Replace(My.Computer.FileSystem.GetFileInfo(FullBasePath + "/" + sender.FullImageUrl).Name, "")
            openImage.FileName = My.Computer.FileSystem.GetFileInfo(FullBasePath + "/" + sender.FullImageUrl).Name
        Else
            openImage.InitialDirectory = New Uri(FullBasePath + "/Buildings").ToString()
            openImage.FileName = ""
        End If
        If openImage.ShowDialog(Me) = DialogResult.OK Then
            Dim test1 As Uri = New Uri(FullBasePath + "/")
            Dim test2 As Uri = New Uri(openImage.FileName)
            Dim test3 As Uri = test1.MakeRelativeUri(test2)
            sender.FullImageUrl = Uri.UnescapeDataString(test3.ToString())
            Saved = False
        End If
    End Sub

    Private Sub BuildingEntryBtnBrowseShadowImageClicked(sender As BuildingEntry, e As EventArgs)
        If My.Computer.FileSystem.FileExists(FullBasePath + "/" + sender.ShadowImageUrl) Then
            openImage.InitialDirectory = New Uri(FullBasePath + "/" + sender.ShadowImageUrl).ToString().Replace(My.Computer.FileSystem.GetFileInfo(FullBasePath + "/" + sender.ShadowImageUrl).Name, "")
            openImage.FileName = My.Computer.FileSystem.GetFileInfo(FullBasePath + "/" + sender.ShadowImageUrl).Name
        Else
            openImage.InitialDirectory = New Uri(FullBasePath + "/Buildings").ToString()
            openImage.FileName = ""
        End If
        If openImage.ShowDialog(Me) = DialogResult.OK Then
            Dim test1 As Uri = New Uri(FullBasePath + "/")
            Dim test2 As Uri = New Uri(openImage.FileName)
            Dim test3 As Uri = test1.MakeRelativeUri(test2)
            sender.ShadowImageUrl = Uri.UnescapeDataString(test3.ToString())
            Saved = False
        End If
    End Sub

    Private Sub BuildingEntryTxtFullImageUrlMouseEnter(sender As BuildingEntry, e As EventArgs)
        Try
            picPreview.Image = Image.FromFile(FullBasePath + "/" + sender.FullImageUrl)
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
            picPreview.Image = Image.FromFile(FullBasePath + "/" + sender.ShadowImageUrl)
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
        Saved = False
    End Sub

    Private Sub unitEntry_btnRemove_Clicked(sender As UnitEntry, e As EventArgs)
        pnlUnits.SuspendLayout()
        pnlUnits.Controls.Remove(sender)
        sender.Dispose()
        ReorderUnitEntries()
        Saved = False
    End Sub

    Private Sub UnitEntryBtnBrowseFullImageClicked(sender As UnitEntry, e As EventArgs)
        If My.Computer.FileSystem.FileExists(FullBasePath + "/" + sender.FullImageUrl) Then
            openImage.InitialDirectory = New Uri(FullBasePath + "/" + sender.FullImageUrl).ToString().Replace(My.Computer.FileSystem.GetFileInfo(FullBasePath + "/" + sender.FullImageUrl).Name, "")
            openImage.FileName = My.Computer.FileSystem.GetFileInfo(FullBasePath + "/" + sender.FullImageUrl).Name
        Else
            openImage.InitialDirectory = New Uri(FullBasePath + "/Units").ToString()
            openImage.FileName = ""
        End If
        If openImage.ShowDialog(Me) = DialogResult.OK Then
            Dim test1 As Uri = New Uri(FullBasePath + "/")
            Dim test2 As Uri = New Uri(openImage.FileName)
            Dim test3 As Uri = test1.MakeRelativeUri(test2)
            sender.FullImageUrl = Uri.UnescapeDataString(test3.ToString())
            Saved = False
        End If
    End Sub

    Private Sub UnitEntryBtnBrowseShadowImageClicked(sender As UnitEntry, e As EventArgs)
        If My.Computer.FileSystem.FileExists(FullBasePath + "/" + sender.ShadowImageUrl) Then
            openImage.InitialDirectory = New Uri(FullBasePath + "/" + sender.ShadowImageUrl).ToString().Replace(My.Computer.FileSystem.GetFileInfo(FullBasePath + "/" + sender.ShadowImageUrl).Name, "")
            openImage.FileName = My.Computer.FileSystem.GetFileInfo(FullBasePath + "/" + sender.ShadowImageUrl).Name
        Else
            openImage.InitialDirectory = New Uri(FullBasePath + "/Units").ToString()
            openImage.FileName = ""
        End If
        If openImage.ShowDialog(Me) = DialogResult.OK Then
            Dim test1 As Uri = New Uri(FullBasePath + "/")
            Dim test2 As Uri = New Uri(openImage.FileName)
            Dim test3 As Uri = test1.MakeRelativeUri(test2)
            sender.ShadowImageUrl = Uri.UnescapeDataString(test3.ToString())
            Saved = False
        End If
    End Sub

    Private Sub UnitEntryTxtFullImageUrlMouseEnter(sender As UnitEntry, e As EventArgs)
        Try
            picPreview.Image = Image.FromFile(FullBasePath + "/" + sender.FullImageUrl)
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
            picPreview.Image = Image.FromFile(FullBasePath + "/" + sender.ShadowImageUrl)
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
        Dim msgResult As DialogResult = DialogResult.None
        If Not Saved Then
            msgResult = MsgBox("Do you want to save all changes you've made?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
        End If

        If msgResult <> MsgBoxResult.Cancel Then
            If msgResult = DialogResult.Yes Then
                SaveAll()
            End If
            Me.Close()
        End If
    End Sub

    Private Sub btnSaveAll_Click(sender As Object, e As EventArgs) Handles btnSaveAll.Click
        SaveAll()
        lblSaved.Show()
    End Sub

    Private Sub SaveAll()
        SaveConfig()
        SaveTiles()
        SaveBuildings()
        SaveUnits()
        Saved = True
    End Sub

    Private Sub SaveConfig()
        Dim ascii As String = IniArray(0)
        For Each c As Char In AsciiLookup
            ascii += AsciiSeparator(1) + c.ToString() + AsciiSeparator(0)
        Next
        ascii += IniArray(1)

        Dim data As String = GetIniFileHeader(ConfigFormat)

        data +=
            "[ASCII LOOKUP]" + vbNewLine +
            "Ascii Separator = """ + AsciiSeparator + """" + vbNewLine +
            "Ascii Array = " + ascii + vbNewLine

        data += GetIniFileFooter()
        My.Computer.FileSystem.WriteAllText(ConfigFile, data, False, Encoding.UTF8)
    End Sub

    Private Sub SaveTiles()
        Dim data As String = GetIniFileHeader(TerrainFormat)

        data +=
            "[DEFINE TERRAIN]" + vbNewLine +
            "; Terrain Definition Format:" + vbNewLine +
            "; {str_Id|bool_IsPassable|bool_IsMinerals|url_Image}" + vbNewLine

        For i As Integer = 0 To pnlTerrain.Controls.Count - 1
            Dim t As TileEntry = pnlTerrain.Controls(i)
            data += "Terrain" + i.ToString() + " = " + IniArray(0) + t.TileId + "|" + t.IsPassable.ToString() + "|" + t.IsMinerals.ToString() + "|" + t.ImageUrl + IniArray(1) + vbNewLine
        Next

        data += GetIniFileFooter()
        My.Computer.FileSystem.WriteAllText(TerrainFile, data, False, Encoding.ASCII)
    End Sub

    Private Sub SaveBuildings()
        Dim data As String = GetIniFileHeader(BuildingsFormat)

        data +=
            "[DEFINE BUILDINGS]" + vbNewLine +
            "; Building Definition Format:" + vbNewLine +
            "; {str_Id|i_Width|i_Height|i_Team|i_OffsetY|url_FullImage|url_ShadowImage}" + vbNewLine

        For i As Integer = 0 To pnlBuildings.Controls.Count - 1
            Dim b As BuildingEntry = pnlBuildings.Controls(i)
            data += "Building" + i.ToString() + " = " + IniArray(0) + b.BuildingId + "|" + b.BuildingW.ToString() + "|" + b.BuildingH.ToString() + "|" + CInt(b.Team).ToString() + "|" + b.OffsetY.ToString() + "|" + b.FullImageUrl + "|" + b.ShadowImageUrl + IniArray(1) + vbNewLine
        Next

        data += GetIniFileFooter()
        My.Computer.FileSystem.WriteAllText(BuildingsFile, data, False, Encoding.ASCII)
    End Sub

    Private Sub SaveUnits()
        Dim data As String = GetIniFileHeader(UnitsFormat)

        data +=
            "[DEFINE UNITS]" + vbNewLine +
            "; Unit Definition Format:" + vbNewLine +
            "; {str_Id|i_Team|i_Altitude|bool_IsPickup|i_OffsetY|url_FullImage|url_ShadowImage}" + vbNewLine

        For i As Integer = 0 To pnlUnits.Controls.Count - 1
            Dim u As UnitEntry = pnlUnits.Controls(i)
            data += "Unit" + i.ToString() + " = " + IniArray(0) + u.UnitId + "|" + CInt(u.Team).ToString() + "|" + u.Altitude.ToString() + "|" + u.IsPickup.ToString() + "|" + u.OffsetY.ToString() + "|" + u.FullImageUrl + "|" + u.ShadowImageUrl + IniArray(1) + vbNewLine
        Next

        data += GetIniFileFooter()
        My.Computer.FileSystem.WriteAllText(UnitsFile, data, False, Encoding.ASCII)
    End Sub

End Class
