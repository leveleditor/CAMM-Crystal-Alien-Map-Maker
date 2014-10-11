Imports Nini.Ini
Imports Nini.Config
Public Class FRMTileData

    Dim TileDataFile As String = FRMEditor.TileDataFile
    Dim RelativeBasePath As String = "/../../Tile Data"
    Dim ANSI As String = ""
    Public Const TilesDatVersion As Integer = 4

    Private Sub FRMTileData_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown, Me.Load
        Dim reader As New IniReader(TileDataFile) With {.IgnoreComments = True, .AcceptCommentAfterKey = False}
        Dim source As New IniConfigSource(New IniDocument(reader))
        Dim config As IConfig = source.Configs.Item("CAMM")
        If config Is Nothing Or config.GetInt("vFormat", -1) < TilesDatVersion Then
            MsgBox("This 'Tiles.dat' file is invalid or outdated and cannot be used!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Me.Close()
        ElseIf config.GetInt("vFormat", -1) = TilesDatVersion Then
            config = source.Configs.Item("SPECIAL CHARACTERS LIST")
            TXTVar1.Text = config.GetString("Get File Name")
            TXTVar3.Text = config.GetString("INI Comment")
            TXTVar4.Text = config.GetString("Array Modifiers")
            TXTVar5.Text = config.GetString("Array Separator")

            config = source.Configs.Item("ANSI LOOKUP")
            TXTVar6.Text = config.GetString("Ansi Separator")
            ANSI = config.Get("Ansi Array")

            Me.PNLTerrain.Controls.Clear()
            Me.PNLBuildings.Controls.Clear()
            Me.PNLUnits.Controls.Clear()

            config = source.Configs.Item("DEFINE TERRAIN")
            For i As Integer = 0 To config.GetKeys().Length - 1
                If config.GetKeys(i) <> "-1" Then
                    Dim KeyArray As String() = config.Get(config.GetKeys(i)).Trim(TXTVar4.Text.ToCharArray).Split(New Char() {Char.Parse(TXTVar5.Text)}, StringSplitOptions.None)
                    Dim TerrainID As String = KeyArray(0)
                    Dim IsPassable As Boolean = CBool(KeyArray(1))
                    Dim IsMinerals As Boolean = CBool(KeyArray(2))
                    Dim ImageUrl As String = KeyArray(3)
                    Dim NewTerrainEntry As Entry_Terrain = New Entry_Terrain(TerrainID, IsPassable, IsMinerals, ImageUrl)
                    'NewTerrainEntry.Location = New Point(3, (i * 31) + 3)
                    AddHandler NewTerrainEntry.CMDNew_Clicked, AddressOf Entry_Terrain_CMDNew_Clicked
                    AddHandler NewTerrainEntry.CMDRemove_Clicked, AddressOf Entry_Terrain_CMDRemove_Clicked
                    AddHandler NewTerrainEntry.CMDBrowse_Clicked, AddressOf Entry_Terrain_CMDBrowse_Clicked
                    AddHandler NewTerrainEntry.TXTImageUrl_MouseEntered, AddressOf Entry_Terrain_TXTImageUrl_MouseEnter
                    AddHandler NewTerrainEntry.TXTImageUrl_MouseLeft, AddressOf Entry_Terrain_TXTImageUrl_MouseLeave
                    Me.PNLTerrain.Controls.Add(NewTerrainEntry)
                End If
            Next

            config = source.Configs.Item("DEFINE BUILDINGS")
            For i As Integer = 0 To config.GetKeys().Length - 1
                If config.GetKeys(i) <> "-1" Then
                    Dim KeyArray As String() = config.Get(config.GetKeys(i)).Trim(TXTVar4.Text.ToCharArray).Split(New Char() {Char.Parse(TXTVar5.Text)}, StringSplitOptions.None)
                    Dim ObjectID As String = KeyArray(0)
                    Dim Width As Integer = CInt(KeyArray(1))
                    Dim Height As Integer = CInt(KeyArray(2))
                    Dim Team As Integer = CInt(KeyArray(3))
                    Dim Angle As Single = CSng(KeyArray(4))
                    Dim Damage As Single = CSng(KeyArray(5))
                    Dim OffsetY As Integer = CInt(KeyArray(6))
                    Dim ImageUrl As String = KeyArray(7)
                    Dim NewObjectEntry As Entry_Object = New Entry_Object(ObjectID, Width, Height, Team, Angle, Damage, OffsetY, ImageUrl)
                    'NewObjectEntry.Location = New Point(3, (i * 31) + 3)
                    AddHandler NewObjectEntry.CMDNew_Clicked, AddressOf Entry_Building_CMDNew_Clicked
                    AddHandler NewObjectEntry.CMDRemove_Clicked, AddressOf Entry_Building_CMDRemove_Clicked
                    AddHandler NewObjectEntry.CMDBrowse_Clicked, AddressOf Entry_Building_CMDBrowse_Clicked
                    AddHandler NewObjectEntry.TXTImageUrl_MouseEntered, AddressOf Entry_Building_TXTImageUrl_MouseEnter
                    AddHandler NewObjectEntry.TXTImageUrl_MouseLeft, AddressOf Entry_Building_TXTImageUrl_MouseLeave
                    Me.PNLBuildings.Controls.Add(NewObjectEntry)
                End If
            Next

            config = source.Configs.Item("DEFINE UNITS")
            For i As Integer = 0 To config.GetKeys().Length - 1
                If config.GetKeys(i) <> "-1" Then
                    Dim KeyArray As String() = config.Get(config.GetKeys(i)).Trim(TXTVar4.Text.ToCharArray).Split(New Char() {Char.Parse(TXTVar5.Text)}, StringSplitOptions.None)
                    Dim ObjectID As String = KeyArray(0)
                    Dim Width As Integer = CInt(KeyArray(1))
                    Dim Height As Integer = CInt(KeyArray(2))
                    Dim Team As Integer = CInt(KeyArray(3))
                    Dim Angle As Single = CSng(KeyArray(4))
                    Dim Damage As Single = CSng(KeyArray(5))
                    Dim OffsetY As Integer = CInt(KeyArray(6))
                    Dim ImageUrl As String = KeyArray(7)
                    Dim NewObjectEntry As Entry_Object = New Entry_Object(ObjectID, Width, Height, Team, Angle, Damage, OffsetY, ImageUrl)
                    'NewObjectEntry.Location = New Point(3, (i * 31) + 3)
                    AddHandler NewObjectEntry.CMDNew_Clicked, AddressOf Entry_Unit_CMDNew_Clicked
                    AddHandler NewObjectEntry.CMDRemove_Clicked, AddressOf Entry_Unit_CMDRemove_Clicked
                    AddHandler NewObjectEntry.CMDBrowse_Clicked, AddressOf Entry_Unit_CMDBrowse_Clicked
                    AddHandler NewObjectEntry.TXTImageUrl_MouseEntered, AddressOf Entry_Unit_TXTImageUrl_MouseEnter
                    AddHandler NewObjectEntry.TXTImageUrl_MouseLeft, AddressOf Entry_Unit_TXTImageUrl_MouseLeave
                    Me.PNLUnits.Controls.Add(NewObjectEntry)
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
        PNLTerrain.SuspendLayout()
        TabTerrain.SuspendLayout()
        For i As Integer = 0 To PNLTerrain.Controls.Count - 1
            PNLTerrain.Controls(i).Location = New Point(PNLTerrain.AutoScrollPosition.X + 3, PNLTerrain.AutoScrollPosition.Y + (i * 31) + 3)
            PNLTerrain.Controls(i).PerformLayout()
        Next
        PNLTerrain.ResumeLayout()
        TabTerrain.ResumeLayout()
        PNLTerrain.PerformLayout()
        TabTerrain.PerformLayout()
        PNLTerrain.PerformLayout()
        TabTerrain.PerformLayout()
    End Sub

    Private Sub ReorderBuildingEntries()
        PNLBuildings.SuspendLayout()
        TabBuildings.SuspendLayout()
        For i As Integer = 0 To PNLBuildings.Controls.Count - 1
            PNLBuildings.Controls(i).Location = New Point(PNLBuildings.AutoScrollPosition.X + 3, PNLBuildings.AutoScrollPosition.Y + (i * 31) + 3)
            PNLBuildings.Controls(i).PerformLayout()
        Next
        PNLBuildings.ResumeLayout()
        TabBuildings.ResumeLayout()
        PNLBuildings.PerformLayout()
        TabBuildings.PerformLayout()
        PNLBuildings.PerformLayout()
        TabBuildings.PerformLayout()
    End Sub

    Private Sub ReorderUnitEntries()
        PNLUnits.SuspendLayout()
        TabUnits.SuspendLayout()
        For i As Integer = 0 To PNLUnits.Controls.Count - 1
            PNLUnits.Controls(i).Location = New Point(PNLUnits.AutoScrollPosition.X + 3, PNLUnits.AutoScrollPosition.Y + (i * 31) + 3)
            PNLUnits.Controls(i).PerformLayout()
        Next
        PNLUnits.ResumeLayout()
        TabUnits.ResumeLayout()
        PNLUnits.PerformLayout()
        TabUnits.PerformLayout()
        PNLUnits.PerformLayout()
        TabUnits.PerformLayout()
    End Sub

    Private Sub Entry_Terrain_CMDNew_Clicked(ByVal sender As Entry_Terrain, ByVal e As System.EventArgs)
        PNLTerrain.SuspendLayout()
        Dim NewTerrainEntry As Entry_Terrain = New Entry_Terrain() With {.TerrainID = TXTVar1.Text, .Location = New Point(PNLTerrain.AutoScrollPosition.X + 3, PNLTerrain.AutoScrollPosition.Y + 3)}
        AddHandler NewTerrainEntry.CMDNew_Clicked, AddressOf Entry_Terrain_CMDNew_Clicked
        AddHandler NewTerrainEntry.CMDRemove_Clicked, AddressOf Entry_Terrain_CMDRemove_Clicked
        AddHandler NewTerrainEntry.CMDBrowse_Clicked, AddressOf Entry_Terrain_CMDBrowse_Clicked
        AddHandler NewTerrainEntry.TXTImageUrl_MouseEntered, AddressOf Entry_Terrain_TXTImageUrl_MouseEnter
        AddHandler NewTerrainEntry.TXTImageUrl_MouseLeft, AddressOf Entry_Terrain_TXTImageUrl_MouseLeave
        PNLTerrain.Controls.Add(NewTerrainEntry)
        ReorderTerrainEntries()
    End Sub

    Private Sub Entry_Terrain_CMDRemove_Clicked(ByVal sender As Entry_Terrain, ByVal e As System.EventArgs)
        PNLTerrain.SuspendLayout()
        PNLTerrain.Controls.Remove(sender)
        sender.Dispose()
        ReorderTerrainEntries()
    End Sub

    Private Sub Entry_Terrain_CMDBrowse_Clicked(ByVal sender As Entry_Terrain, ByVal e As System.EventArgs)
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl) Then
            OpenImage.InitialDirectory = New Uri(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).ToString.Replace(My.Computer.FileSystem.GetFileInfo(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).Name, "")
            OpenImage.FileName = My.Computer.FileSystem.GetFileInfo(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).Name
        Else
            OpenImage.InitialDirectory = New Uri(My.Application.Info.DirectoryPath + "/../../Tile Data/Terrain").ToString
            OpenImage.FileName = ""
        End If
        If OpenImage.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim Test1 As Uri = New Uri(My.Application.Info.DirectoryPath + "/../../")
            Dim Test2 As Uri = New Uri(OpenImage.FileName)
            Dim Test3 As Uri = Test1.MakeRelativeUri(Test2)
            sender.ImageUrl = Uri.UnescapeDataString(Test3.ToString)
        End If
    End Sub

    Private Sub Entry_Terrain_TXTImageUrl_MouseEnter(ByVal sender As Entry_Terrain, ByVal e As System.EventArgs)
        Try
            PICPreview.Image = Image.FromFile(My.Application.Info.DirectoryPath + RelativeBasePath + "/../" + sender.ImageUrl)
        Catch ex As Exception
            PICPreview.Image = Nothing
        End Try
        PICPreview.Show()
    End Sub

    Private Sub Entry_Terrain_TXTImageUrl_MouseLeave(ByVal sender As Entry_Terrain, ByVal e As System.EventArgs)
        PICPreview.Image = Nothing
        PICPreview.Hide()
    End Sub

    Private Sub Entry_Building_CMDNew_Clicked(ByVal sender As Entry_Object, ByVal e As System.EventArgs)
        PNLBuildings.SuspendLayout()
        Dim NewObjectEntry As Entry_Object = New Entry_Object(TXTVar1.Text, 1, 1, 0, 0, 0, 0, "") With {.Location = New Point(PNLBuildings.AutoScrollPosition.X + 3, PNLBuildings.AutoScrollPosition.Y + 3)}
        AddHandler NewObjectEntry.CMDNew_Clicked, AddressOf Entry_Building_CMDNew_Clicked
        AddHandler NewObjectEntry.CMDRemove_Clicked, AddressOf Entry_Building_CMDRemove_Clicked
        AddHandler NewObjectEntry.CMDBrowse_Clicked, AddressOf Entry_Building_CMDBrowse_Clicked
        AddHandler NewObjectEntry.TXTImageUrl_MouseEntered, AddressOf Entry_Building_TXTImageUrl_MouseEnter
        AddHandler NewObjectEntry.TXTImageUrl_MouseLeft, AddressOf Entry_Building_TXTImageUrl_MouseLeave
        PNLBuildings.Controls.Add(NewObjectEntry)
        ReorderBuildingEntries()
    End Sub

    Private Sub Entry_Building_CMDRemove_Clicked(ByVal sender As Entry_Object, ByVal e As System.EventArgs)
        PNLBuildings.SuspendLayout()
        PNLBuildings.Controls.Remove(sender)
        sender.Dispose()
        ReorderBuildingEntries()
    End Sub

    Private Sub Entry_Building_CMDBrowse_Clicked(ByVal sender As Entry_Object, ByVal e As System.EventArgs)
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl) Then
            OpenImage.InitialDirectory = New Uri(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).ToString.Replace(My.Computer.FileSystem.GetFileInfo(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).Name, "")
            OpenImage.FileName = My.Computer.FileSystem.GetFileInfo(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).Name
        Else
            OpenImage.InitialDirectory = New Uri(My.Application.Info.DirectoryPath + "/../../Tile Data/Buildings").ToString
            OpenImage.FileName = ""
        End If
        If OpenImage.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim Test1 As Uri = New Uri(My.Application.Info.DirectoryPath + "/../../")
            Dim Test2 As Uri = New Uri(OpenImage.FileName)
            Dim Test3 As Uri = Test1.MakeRelativeUri(Test2)
            sender.ImageUrl = Uri.UnescapeDataString(Test3.ToString)
        End If
    End Sub

    Private Sub Entry_Building_TXTImageUrl_MouseEnter(ByVal sender As Entry_Object, ByVal e As System.EventArgs)
        Try
            PICPreview.Image = Image.FromFile(My.Application.Info.DirectoryPath + RelativeBasePath + "/../" + sender.ImageUrl)
        Catch ex As Exception
            PICPreview.Image = Nothing
        End Try
        PICPreview.Show()
    End Sub

    Private Sub Entry_Building_TXTImageUrl_MouseLeave(ByVal sender As Entry_Object, ByVal e As System.EventArgs)
        PICPreview.Image = Nothing
        PICPreview.Hide()
    End Sub

    Private Sub Entry_Unit_CMDNew_Clicked(ByVal sender As Entry_Object, ByVal e As System.EventArgs)
        PNLUnits.SuspendLayout()
        Dim NewObjectEntry As Entry_Object = New Entry_Object(TXTVar1.Text, 1, 1, 0, 0, 0, 0, "") With {.Location = New Point(PNLUnits.AutoScrollPosition.X + 3, PNLUnits.AutoScrollPosition.Y + 3)}
        AddHandler NewObjectEntry.CMDNew_Clicked, AddressOf Entry_Unit_CMDNew_Clicked
        AddHandler NewObjectEntry.CMDRemove_Clicked, AddressOf Entry_Unit_CMDRemove_Clicked
        AddHandler NewObjectEntry.CMDBrowse_Clicked, AddressOf Entry_Unit_CMDBrowse_Clicked
        AddHandler NewObjectEntry.TXTImageUrl_MouseEntered, AddressOf Entry_Unit_TXTImageUrl_MouseEnter
        AddHandler NewObjectEntry.TXTImageUrl_MouseLeft, AddressOf Entry_Unit_TXTImageUrl_MouseLeave
        PNLUnits.Controls.Add(NewObjectEntry)
        ReorderUnitEntries()
    End Sub

    Private Sub Entry_Unit_CMDRemove_Clicked(ByVal sender As Entry_Object, ByVal e As System.EventArgs)
        PNLUnits.SuspendLayout()
        PNLUnits.Controls.Remove(sender)
        sender.Dispose()
        ReorderUnitEntries()
    End Sub

    Private Sub Entry_Unit_CMDBrowse_Clicked(ByVal sender As Entry_Object, ByVal e As System.EventArgs)
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl) Then
            OpenImage.InitialDirectory = New Uri(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).ToString.Replace(My.Computer.FileSystem.GetFileInfo(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).Name, "")
            OpenImage.FileName = My.Computer.FileSystem.GetFileInfo(My.Application.Info.DirectoryPath + "/../../" & sender.ImageUrl).Name
        Else
            OpenImage.InitialDirectory = New Uri(My.Application.Info.DirectoryPath + "/../../Tile Data/Units").ToString
            OpenImage.FileName = ""
        End If
        If OpenImage.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim Test1 As Uri = New Uri(My.Application.Info.DirectoryPath + "/../../")
            Dim Test2 As Uri = New Uri(OpenImage.FileName)
            Dim Test3 As Uri = Test1.MakeRelativeUri(Test2)
            sender.ImageUrl = Uri.UnescapeDataString(Test3.ToString)
        End If
    End Sub

    Private Sub Entry_Unit_TXTImageUrl_MouseEnter(ByVal sender As Entry_Object, ByVal e As System.EventArgs)
        Try
            PICPreview.Image = Image.FromFile(My.Application.Info.DirectoryPath + RelativeBasePath + "/../" + sender.ImageUrl)
        Catch ex As Exception
            PICPreview.Image = Nothing
        End Try
        PICPreview.Show()
    End Sub

    Private Sub Entry_Unit_TXTImageUrl_MouseLeave(ByVal sender As Entry_Object, ByVal e As System.EventArgs)
        PICPreview.Image = Nothing
        PICPreview.Hide()
    End Sub

    Private Sub CMDClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDClose.Click
        Me.Close()
    End Sub

    Private Sub CMDSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSave.Click

        Dim SaveFileData As String = ""

        SaveFileData += _
            "[CAMM]" + vbNewLine + _
            "vFormat = " + TilesDatVersion.ToString + vbNewLine + vbNewLine

        SaveFileData += _
            "[SPECIAL CHARACTERS LIST]" + vbNewLine + _
            "Get File Name = """ + TXTVar1.Text + """" + vbNewLine + _
            "INI Comment = """ + TXTVar3.Text + """" + vbNewLine + _
            "Array Modifiers = """ + TXTVar4.Text + """" + vbNewLine + _
            "Array Separator = """ + TXTVar5.Text + """" + vbNewLine + _
            vbNewLine

        SaveFileData += _
            "[ANSI LOOKUP]" + vbNewLine + _
            "Ansi Separator = """ + TXTVar6.Text + """" + vbNewLine + _
            "Ansi Array = " + ANSI + vbNewLine + _
            vbNewLine

        SaveFileData += "[DEFINE TERRAIN]" + vbNewLine + _
            "; Terrain Definition Format:" + vbNewLine + _
            "; {str_ID|bool_IsPassable|bool_IsMinerals|url_Image}" + vbNewLine

        Dim TerrainNumber As Integer = 0
        For i As Integer = 0 To PNLTerrain.Controls.Count - 1
            Dim Temp As Entry_Terrain = PNLTerrain.Controls(i)
            SaveFileData += "Terrain" + TerrainNumber.ToString + " = {" + Temp.TerrainID + "|" + Temp.IsPassable.ToString + "|" + Temp.IsMinerals.ToString + "|" + Temp.ImageUrl + "}" + vbNewLine
            TerrainNumber += 1
        Next

        SaveFileData += vbNewLine + "[DEFINE BUILDINGS]" + vbNewLine + _
            "; Building Definition Format:" + vbNewLine + _
            "; {str_ID|i_Width|i_Height|i_Team|f_Angle|f_Damage|i_OffsetY|url_Image}" + vbNewLine

        Dim BuildingNumber As Integer = 0
        For i As Integer = 0 To PNLBuildings.Controls.Count - 1
            Dim Temp As Entry_Object = PNLBuildings.Controls(i)
            SaveFileData += "Building" + BuildingNumber.ToString + " = {" + Temp.ObjectID + "|" + Temp.ObjWidth.ToString + "|" + Temp.ObjHeight.ToString + "|" + Temp.Team.ToString + "|" + Temp.Angle.ToString + "|" + Temp.Damage.ToString + "|" + Temp.OffSetY.ToString + "|" + Temp.ImageUrl + "}" + vbNewLine
            BuildingNumber += 1
        Next

        SaveFileData += vbNewLine + "[DEFINE UNITS]" + vbNewLine + _
            "; Unit Definition Format:" + vbNewLine + _
            "; {str_ID|i_Width|i_Height|i_Team|f_Angle|f_Damage|i_OffsetY|url_Image}" + vbNewLine

        Dim UnitNumber As Integer = 0
        For i As Integer = 0 To PNLUnits.Controls.Count - 1
            Dim Temp As Entry_Object = PNLUnits.Controls(i)
            SaveFileData += "Unit" + UnitNumber.ToString + " = {" + Temp.ObjectID + "|" + Temp.ObjWidth.ToString + "|" + Temp.ObjHeight.ToString + "|" + Temp.Team.ToString + "|" + Temp.Angle.ToString + "|" + Temp.Damage.ToString + "|" + Temp.OffSetY.ToString + "|" + Temp.ImageUrl + "}" + vbNewLine
            UnitNumber += 1
        Next

        SaveFileData += vbNewLine + "; -= CAMM Crystal Alien Map Maker (c) 2014 Leveleditor6680 // Josh =-"

        My.Computer.FileSystem.WriteAllText(TileDataFile, SaveFileData, False, System.Text.Encoding.UTF8)

        LBLSaved.Show()
    End Sub
End Class