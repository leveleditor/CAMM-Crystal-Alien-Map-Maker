Public Class RectangleBrushPreset

    Private ReadOnly _fileName As String
    Private ReadOnly _title As String
    Private ReadOnly _data As Integer()()
    Private ReadOnly _preview As Image
    Private Const ScaledTileSizeX As Integer = TileSizeX / 3
    Private Const ScaledTileSizeY As Integer = TileSizeY / 3

    Sub New(fileName As String, title As String, data As Integer()())
        Me._fileName = fileName
        Me._title = title
        Me._data = data
        Me._preview = New Bitmap(ScaledTileSizeX * 3, ScaledTileSizeY * 3)

        Dim g As Graphics = Graphics.FromImage(_preview)

        'Pre-render the preview image based on the tiles in the data.
        For x As Integer = 0 To 2
            For y As Integer = 0 To 2
                If _data(x)(y) <> -1 Then
                    g.DrawImage(TileImageLookup(_data(x)(y)), x * ScaledTileSizeX, y * ScaledTileSizeY, ScaledTileSizeX, ScaledTileSizeY)
                End If
            Next
        Next

        'Close the graphics.
        g.Flush()
        g.Dispose()
    End Sub

    Public ReadOnly Property FileName As String
        Get
            Return _fileName
        End Get
    End Property

    Public ReadOnly Property Title As String
        Get
            Return _title
        End Get
    End Property

    Public ReadOnly Property Data As Integer()()
        Get
            Return _data
        End Get
    End Property

    Public ReadOnly Property Preview As Image
        Get
            Return _preview
        End Get
    End Property

End Class