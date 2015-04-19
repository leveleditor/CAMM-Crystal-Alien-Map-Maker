Imports System.Text
Imports Nini.Ini
Imports Nini.Config
Public Class FrmTileData

    Dim ascii As String = ""

    Private Sub FrmTileData_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim reader As New IniReader(TileDataFile) With {.IgnoreComments = True, .AcceptCommentAfterKey = False}
        Dim source As New IniConfigSource(New IniDocument(reader))
        Dim config As IConfig = source.Configs.Item("CAMM")
        If config Is Nothing Or config.GetInt("vFormat", -1) < TilesDatVersion Then
            MsgBox("This 'Tiles.dat' file is invalid or outdated and cannot be used!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Me.Close()
        ElseIf config.GetInt("vFormat", -1) = TilesDatVersion Then
            config = source.Configs.Item("ASCII LOOKUP")
            txtAsciiSeparator.Text = config.GetString("Ascii Separator")
            ascii = config.Get("Ascii Array")

            Me.pnlTerrain.Controls.Clear()
            Me.pnlBuildings.Controls.Clear()
            Me.pnlUnits.Controls.Clear()

            config = source.Configs.Item("DEFINE TERRAIN")
            For i As Integer = 0 To config.GetKeys().Length - 1
                If config.GetKeys(i) <> "-1" Then
                    Dim keyArray As String() = config.Get(config.GetKeys(i)).Trim(IniArray.ToCharArray()).Split(IniSeparator.ToCharArray(), StringSplitOptions.None)
                    Dim terrainId As String = keyArray(0)
                    Dim isPassable As Boolean = CBool(keyArray(1))
                    Dim isMinerals As Boolean = CBool(keyArray(2))
                    Dim imageUrl As String = keyArray(3)
                    Dim newTileEntry As TileEntry = New TileEntry(terrainId, isPassable, isMinerals, imageUrl)
                    'NewTerrainEntry.Location = New Point(3, (i * 31) + 3)
                    AddHandler newTileEntry.BtnNewClicked, AddressOf tileEntry_btnNew_Clicked
                    AddHandler newTileEntry.BtnRemoveClicked, AddressOf tileEntry_btnRemove_Clicked
                    AddHandler newTileEntry.BtnBrowseClicked, AddressOf tileEntry_btnBrowse_Clicked
                    AddHandler newTileEntry.TxtImageUrlMouseEntered, AddressOf tileEntry_txtImageUrl_MouseEnter
                    AddHandler newTileEntry.TxtImageUrlMouseLeft, AddressOf tileEntry_txtImageUrl_MouseLeave
                    Me.pnlTerrain.Controls.Add(newTileEntry)
                End If
            Next

            config = source.Configs.Item("DEFINE BUILDINGS")
            For i As Integer = 0 To config.GetKeys().Length - 1
                If config.GetKeys(i) <> "-1" Then
                    Dim keyArray As String() = config.Get(config.GetKeys(i)).Trim(IniArray.ToCharArray).Split(IniSeparator.ToCharArray(), StringSplitOptions.None)
                    Dim buildingId As String = keyArray(0)
                    Dim width As Integer = CInt(keyArray(1))
                    Dim height As Integer = CInt(keyArray(2))
                    Dim team As Team = CType(Integer.Parse(keyArray(3)), Team)
                    Dim angle As Single = CSng(keyArray(4))
                    Dim damage As Single = CSng(keyArray(5))
                    Dim offsetY As Integer = CInt(keyArray(6))
                    Dim imageUrl As String = keyArray(7)
                    Dim newObjectEntry As ObjectEntry = New ObjectEntry(buildingId, width, height, team, angle, damage, offsetY, imageUrl)
                    'NewObjectEntry.Location = New Point(3, (i * 31) + 3)
                    AddHandler newObjectEntry.BtnNewClicked, AddressOf buildingEntry_btnNew_Clicked
                    AddHandler newObjectEntry.BtnRemoveClicked, AddressOf buildingEntry_btnRemove_Clicked
                    AddHandler newObjectEntry.BtnBrowseClicked, AddressOf buildingEntry_btnBrowse_Clicked
                    AddHandler newObjectEntry.TxtImageUrlMouseEntered, AddressOf buildingEntry_txtImageUrl_MouseEnter
                    AddHandler newObjectEntry.TxtImageUrlMouseLeft, AddressOf buildingEntry_txtImageUrl_MouseLeave
                    Me.pnlBuildings.Controls.Add(newObjectEntry)
                End If
            Next

            config = source.Configs.Item("DEFINE UNITS")
            For i As Integer = 0 To config.GetKeys().Length - 1
                If config.GetKeys(i) <> "-1" Then
                    Dim keyArray As String() = config.Get(config.GetKeys(i)).Trim(IniArray.ToCharArray()).Split(IniSeparator.ToCharArray(), StringSplitOptions.None)
                    Dim unitId As String = keyArray(0)
                    Dim width As Integer = CInt(keyArray(1))
                    Dim height As Integer = CInt(keyArray(2))
                    Dim team As Team = CType(Integer.Parse(keyArray(3)), Team)
                    Dim angle As Single = CSng(keyArray(4))
                    Dim damage As Single = CSng(keyArray(5))
                    Dim offsetY As Integer = CInt(keyArray(6))
                    Dim imageUrl As String = keyArray(7)
                    Dim newObjectEntry As ObjectEntry = New ObjectEntry(unitId, width, height, team, angle, damage, offsetY, imageUrl)
                    'NewObjectEntry.Location = New Point(3, (i * 31) + 3)
                    AddHandler newObjectEntry.BtnNewClicked, AddressOf unitEntry_btnNew_Clicked
                    AddHandler newObjectEntry.BtnRemoveClicked, AddressOf unitEntry_btnRemove_Clicked
                    AddHandler newObjectEntry.BtnBrowseClicked, AddressOf unitEntry_btnBrowse_Clicked
                    AddHandler newObjectEntry.TxtImageUrlMouseEntered, AddressOf unitEntry_txtImageUrl_MouseEnter
                    AddHandler newObjectEntry.TxtImageUrlMouseLeft, AddressOf unitEntry_txtImageUrl_MouseLeave
                    Me.pnlUnits.Controls.Add(newObjectEntry)
                End If
            Next

            ReorderTerrainEntries()
            ReorderBuildingEntries()
            ReorderUnitEntries()
        ElseIf config.GetInt("vFormat", -1) > TilesDatVersion Then
            MsgBox("This 'Tiles.dat' file was created with a newer version of CAMM and cannot be used!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Me.Close()
        End If
    End Sub

    Private Sub ReorderTerrainEntries()
        pnlTerrain.SuspendLayout()
        tabTerrain.SuspendLayout()
        For i As Integer = 0 To pnlTerrain.Controls.Count - 1
            pnlTerrain.Controls(i).Location = New Point(pnlTerrain.AutoScrollPosition.X + 3, pnlTerrain.AutoScrollPosition.Y + (i * 31) + 3)
            pnlTerrain.Controls(i).PerformLayout()
        Next
        pnlTerrain.ResumeLayout()
        tabTerrain.ResumeLayout()
        pnlTerrain.PerformLayout()
        tabTerrain.PerformLayout()
        pnlTerrain.PerformLayout()
        tabTerrain.PerformLayout()
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
    End Sub

    Private Sub tileEntry_btnRemove_Clicked(sender As TileEntry, e As EventArgs)
        pnlTerrain.SuspendLayout()
        pnlTerrain.Controls.Remove(sender)
        sender.Dispose()
        ReorderTerrainEntries()
    End Sub

    Private Sub tileEntry_btnBrowse_Clicked(sender As TileEntry, e As EventArgs)
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl) Then
            openImage.InitialDirectory = New Uri(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).ToString.Replace(My.Computer.FileSystem.GetFileInfo(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).Name, "")
            openImage.FileName = My.Computer.FileSystem.GetFileInfo(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).Name
        Else
            openImage.InitialDirectory = New Uri(My.Application.Info.DirectoryPath + "/../../Tile Data/Terrain").ToString
            openImage.FileName = ""
        End If
        If openImage.ShowDialog(Me) = DialogResult.OK Then
            Dim test1 As Uri = New Uri(My.Application.Info.DirectoryPath + "/../../")
            Dim test2 As Uri = New Uri(openImage.FileName)
            Dim test3 As Uri = test1.MakeRelativeUri(test2)
            sender.ImageUrl = Uri.UnescapeDataString(test3.ToString)
        End If
    End Sub

    Private Sub tileEntry_txtImageUrl_MouseEnter(sender As TileEntry, e As EventArgs)
        Try
            picPreview.Image = Image.FromFile(My.Application.Info.DirectoryPath + DataPath + "/../" + sender.ImageUrl)
        Catch ex As Exception
            picPreview.Image = Nothing
        End Try
        picPreview.Show()
    End Sub

    Private Sub tileEntry_txtImageUrl_MouseLeave(sender As TileEntry, e As EventArgs)
        picPreview.Image = Nothing
        picPreview.Hide()
    End Sub

    Private Sub buildingEntry_btnNew_Clicked(sender As ObjectEntry, e As EventArgs)
        pnlBuildings.SuspendLayout()
        Dim newObjectEntry As ObjectEntry = New ObjectEntry(-1, 1, 1, 0, 0, 0, 0, "") With {.Location = New Point(pnlBuildings.AutoScrollPosition.X + 3, pnlBuildings.AutoScrollPosition.Y + 3)}
        AddHandler newObjectEntry.BtnNewClicked, AddressOf buildingEntry_btnNew_Clicked
        AddHandler newObjectEntry.BtnRemoveClicked, AddressOf buildingEntry_btnRemove_Clicked
        AddHandler newObjectEntry.BtnBrowseClicked, AddressOf buildingEntry_btnBrowse_Clicked
        AddHandler newObjectEntry.TxtImageUrlMouseEntered, AddressOf buildingEntry_txtImageUrl_MouseEnter
        AddHandler newObjectEntry.TxtImageUrlMouseLeft, AddressOf buildingEntry_txtImageUrl_MouseLeave
        pnlBuildings.Controls.Add(newObjectEntry)
        ReorderBuildingEntries()
    End Sub

    Private Sub buildingEntry_btnRemove_Clicked(sender As ObjectEntry, e As EventArgs)
        pnlBuildings.SuspendLayout()
        pnlBuildings.Controls.Remove(sender)
        sender.Dispose()
        ReorderBuildingEntries()
    End Sub

    Private Sub buildingEntry_btnBrowse_Clicked(sender As ObjectEntry, e As EventArgs)
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl) Then
            openImage.InitialDirectory = New Uri(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).ToString.Replace(My.Computer.FileSystem.GetFileInfo(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).Name, "")
            openImage.FileName = My.Computer.FileSystem.GetFileInfo(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).Name
        Else
            openImage.InitialDirectory = New Uri(My.Application.Info.DirectoryPath + "/../../Tile Data/Buildings").ToString
            openImage.FileName = ""
        End If
        If openImage.ShowDialog(Me) = DialogResult.OK Then
            Dim test1 As Uri = New Uri(My.Application.Info.DirectoryPath + "/../../")
            Dim test2 As Uri = New Uri(openImage.FileName)
            Dim test3 As Uri = test1.MakeRelativeUri(test2)
            sender.ImageUrl = Uri.UnescapeDataString(test3.ToString)
        End If
    End Sub

    Private Sub buildingEntry_txtImageUrl_MouseEnter(sender As ObjectEntry, e As EventArgs)
        Try
            picPreview.Image = Image.FromFile(My.Application.Info.DirectoryPath + DataPath + "/../" + sender.ImageUrl)
        Catch ex As Exception
            picPreview.Image = Nothing
        End Try
        picPreview.Show()
    End Sub

    Private Sub buildingEntry_txtImageUrl_MouseLeave(sender As ObjectEntry, e As EventArgs)
        picPreview.Image = Nothing
        picPreview.Hide()
    End Sub

    Private Sub unitEntry_btnNew_Clicked(sender As ObjectEntry, e As EventArgs)
        pnlUnits.SuspendLayout()
        Dim newObjectEntry As ObjectEntry = New ObjectEntry(-1, 1, 1, 0, 0, 0, 0, "") With {.Location = New Point(pnlUnits.AutoScrollPosition.X + 3, pnlUnits.AutoScrollPosition.Y + 3)}
        AddHandler newObjectEntry.BtnNewClicked, AddressOf unitEntry_btnNew_Clicked
        AddHandler newObjectEntry.BtnRemoveClicked, AddressOf unitEntry_btnRemove_Clicked
        AddHandler newObjectEntry.BtnBrowseClicked, AddressOf unitEntry_btnBrowse_Clicked
        AddHandler newObjectEntry.TxtImageUrlMouseEntered, AddressOf unitEntry_txtImageUrl_MouseEnter
        AddHandler newObjectEntry.TxtImageUrlMouseLeft, AddressOf unitEntry_txtImageUrl_MouseLeave
        pnlUnits.Controls.Add(newObjectEntry)
        ReorderUnitEntries()
    End Sub

    Private Sub unitEntry_btnRemove_Clicked(sender As ObjectEntry, e As EventArgs)
        pnlUnits.SuspendLayout()
        pnlUnits.Controls.Remove(sender)
        sender.Dispose()
        ReorderUnitEntries()
    End Sub

    Private Sub unitEntry_btnBrowse_Clicked(sender As ObjectEntry, e As EventArgs)
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl) Then
            openImage.InitialDirectory = New Uri(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).ToString.Replace(My.Computer.FileSystem.GetFileInfo(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).Name, "")
            openImage.FileName = My.Computer.FileSystem.GetFileInfo(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).Name
        Else
            openImage.InitialDirectory = New Uri(My.Application.Info.DirectoryPath + "/../../Tile Data/Units").ToString
            openImage.FileName = ""
        End If
        If openImage.ShowDialog(Me) = DialogResult.OK Then
            Dim test1 As Uri = New Uri(My.Application.Info.DirectoryPath + "/../../")
            Dim test2 As Uri = New Uri(openImage.FileName)
            Dim test3 As Uri = test1.MakeRelativeUri(test2)
            sender.ImageUrl = Uri.UnescapeDataString(test3.ToString)
        End If
    End Sub

    Private Sub unitEntry_txtImageUrl_MouseEnter(sender As ObjectEntry, e As EventArgs)
        Try
            picPreview.Image = Image.FromFile(My.Application.Info.DirectoryPath + DataPath + "/../" + sender.ImageUrl)
        Catch ex As Exception
            picPreview.Image = Nothing
        End Try
        picPreview.Show()
    End Sub

    Private Sub unitEntry_txtImageUrl_MouseLeave(sender As ObjectEntry, e As EventArgs)
        picPreview.Image = Nothing
        picPreview.Hide()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim saveFileData As String = ""

        saveFileData += _
            "[CAMM]" + vbNewLine + _
            "vFormat = " + TilesDatVersion.ToString + vbNewLine + _
            vbNewLine

        saveFileData += _
            "[ASCII LOOKUP]" + vbNewLine + _
            "Ascii Separator = """ + txtAsciiSeparator.Text + """" + vbNewLine + _
            "Ascii Array = " + ascii + vbNewLine + _
            vbNewLine

        saveFileData += "[DEFINE TERRAIN]" + vbNewLine + _
            "; Terrain Definition Format:" + vbNewLine + _
            "; {str_ID|bool_IsPassable|bool_IsMinerals|url_Image}" + vbNewLine

        Dim terrainNumber As Integer = 0
        For i As Integer = 0 To pnlTerrain.Controls.Count - 1
            Dim temp As TileEntry = pnlTerrain.Controls(i)
            saveFileData += "Terrain" + terrainNumber.ToString + " = {" + temp.TerrainId + "|" + temp.IsPassable.ToString + "|" + temp.IsMinerals.ToString + "|" + temp.ImageUrl + "}" + vbNewLine
            terrainNumber += 1
        Next

        saveFileData += vbNewLine + "[DEFINE BUILDINGS]" + vbNewLine + _
            "; Building Definition Format:" + vbNewLine + _
            "; {str_ID|i_Width|i_Height|i_Team|f_Angle|f_Damage|i_OffsetY|url_Image}" + vbNewLine

        Dim buildingNumber As Integer = 0
        For i As Integer = 0 To pnlBuildings.Controls.Count - 1
            Dim temp As ObjectEntry = pnlBuildings.Controls(i)
            saveFileData += "Building" + buildingNumber.ToString + " = {" + temp.ObjectId + "|" + temp.ObjWidth.ToString + "|" + temp.ObjHeight.ToString + "|" + CInt(temp.Team).ToString + "|" + temp.Angle.ToString + "|" + temp.Damage.ToString + "|" + temp.OffSetY.ToString + "|" + temp.ImageUrl + "}" + vbNewLine
            buildingNumber += 1
        Next

        saveFileData += vbNewLine + "[DEFINE UNITS]" + vbNewLine + _
            "; Unit Definition Format:" + vbNewLine + _
            "; {str_ID|i_Width|i_Height|i_Team|f_Angle|f_Damage|i_OffsetY|url_Image}" + vbNewLine

        Dim unitNumber As Integer = 0
        For i As Integer = 0 To pnlUnits.Controls.Count - 1
            Dim temp As ObjectEntry = pnlUnits.Controls(i)
            saveFileData += "Unit" + unitNumber.ToString + " = {" + temp.ObjectId + "|" + temp.ObjWidth.ToString + "|" + temp.ObjHeight.ToString + "|" + CInt(temp.Team).ToString + "|" + temp.Angle.ToString + "|" + temp.Damage.ToString + "|" + temp.OffSetY.ToString + "|" + temp.ImageUrl + "}" + vbNewLine
            unitNumber += 1
        Next

        saveFileData += vbNewLine + "; -= CAMM Crystal Alien Map Maker (c) 2015 Leveleditor6680 // Josh =-"

        My.Computer.FileSystem.WriteAllText(TileDataFile, saveFileData, False, Encoding.UTF8)

        lblSaved.Show()
    End Sub
End Class
