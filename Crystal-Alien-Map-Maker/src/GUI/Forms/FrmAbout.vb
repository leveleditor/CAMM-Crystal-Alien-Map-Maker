Imports System.IO
Imports Newtonsoft.Json

Public Class FrmAbout
    Private ReadOnly aboutMap As Map

    Private x As Integer
    Private y As Integer
    Private speed As Integer = 1

    Private Const creditsPaddingTopLeft As Integer = 96
    Private Const creditsPaddingBottomRight As Integer = 448
    Private Const creditsShadowSize As Integer = 2

    Private ReadOnly credits As Dictionary(Of String, String)
    Private ReadOnly totalCredits As Integer

    Private ReadOnly outlinePen As Pen
    Private ReadOnly creditsBrush As Brush
    Private ReadOnly creditsBrushShadow As Brush
    Private ReadOnly creditsFont As Font

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        Icon = My.Resources.Crystal

        Text = Text + " " + My.Application.Info.ProductName

        credits = New Dictionary(Of String, String) From {
            {"-= CREDITS =-", Environment.NewLine + "Thanks to everyone who posted ideas, reported bugs," + Environment.NewLine + "or contributed to the project, and everyone on the Mars Mission Wiki!"},
            {"Leveleditor6680", "  - CAMM Programmer, Flash Wrapper Programmer"},
            {"299792458, 4T2 Multimedia", "  - Developer/Programmer of CrystAlien Conflict"},
            {"ETXAlienRobot201", "  - Default Maps Export, Occasional Graphics Design," + Environment.NewLine + "  - Programmer, Helping with Flash Wrapper"},
            {"Mr.Mars.Mission, rennatnave101, and clawtankfan", "  - User Interface Concept Designs"},
            {"-= 3RD PARTY CODE =-", "- Json.NET by Newtonsoft" + Environment.NewLine + "- Nini by Brent Matzelle" + Environment.NewLine + "- .NET Framework by Microsoft"}
        }
        totalCredits = credits.Count()

        outlinePen = New Pen(Color.White, 3)
        creditsBrush = New SolidBrush(Color.White)
        creditsBrushShadow = New SolidBrush(Color.Black)
        creditsFont = New Font(Font.FontFamily, 13, FontStyle.Bold)

        aboutMap = New Map()

        Dim mapData As MapData? = Nothing
        Try
            'Attempt to load the map file as a JSON object.
            mapData = JsonConvert.DeserializeObject(Of MapData)(File.ReadAllText(AboutMenuMapPath))
            aboutMap.LoadMap(mapData)
        Catch ex As Exception
            'Loading failed, just make an empty map to show then.
            aboutMap.SetSize(20, 20)
        End Try

        Size = New Size((aboutMap.SizeX * TileSizeX) / 2, (aboutMap.SizeY * TileSizeY) / 2)
    End Sub

    Private Sub bgTimer_Tick(sender As Object, e As EventArgs) Handles bgTimer.Tick
        x += speed * 2
        y += speed

        If x >= (aboutMap.SizeX * TileSizeX) / 2 Or y >= (aboutMap.SizeY * TileSizeY) / 2 Then
            speed = -1
            bgTimer.Stop()
            pauseTimer.Start()
        ElseIf x <= 0 Or y <= 0 Then
            speed = 1
            bgTimer.Stop()
            pauseTimer.Start()
        End If

        Invalidate()
    End Sub

    Private Sub FrmAbout_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = e.Graphics

        g.TranslateTransform(-x, -y)
        aboutMap.Draw(g, False, False, False, False, False)

        Dim creditX As Integer = 0
        Dim creditY As Integer = 0
        Dim creditsCounter = 0
        For Each contributor As KeyValuePair(Of String, String) In credits
            creditX = creditsPaddingTopLeft + ((aboutMap.SizeX * TileSizeX - creditsPaddingBottomRight) / totalCredits) * creditsCounter
            creditY = creditsPaddingTopLeft + ((aboutMap.SizeY * TileSizeY - creditsPaddingBottomRight / 2) / totalCredits) * creditsCounter
            g.DrawString(contributor.Key + Environment.NewLine + contributor.Value, creditsFont, creditsBrushShadow, creditX + creditsShadowSize, creditY + creditsShadowSize)
            g.DrawString(contributor.Key + Environment.NewLine + contributor.Value, creditsFont, creditsBrush, creditX, creditY)
            creditsCounter += 1
        Next

        g.TranslateTransform(x, y)
        g.DrawRectangle(outlinePen, 1, 1, ClientSize.Width - outlinePen.Width, ClientSize.Height - outlinePen.Width)
    End Sub

    Private Sub pauseTimer_Tick(sender As Object, e As EventArgs) Handles pauseTimer.Tick
        pauseTimer.Stop()
        bgTimer.Start()
    End Sub
End Class