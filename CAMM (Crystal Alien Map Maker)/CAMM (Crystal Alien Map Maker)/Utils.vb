Module Utils

    ''' <summary>
    ''' Rounds the specified coordinates to the nearest grid location.
    ''' </summary>
    ''' <param name="x">The x coordinate to round</param>
    ''' <param name="y">The y coordinate to round</param>
    ''' <remarks>Useful for getting the grid location of the cursor</remarks>
    Public Sub PointToGrid(ByRef x As Integer, ByRef y As Integer)
        Dim ix As Integer = (x - TileSizeX / 2) / TileSizeX
        Dim iy As Integer = (y - TileSizeY / 2) / TileSizeY
        x = ix * TileSizeX
        y = iy * TileSizeY
    End Sub

    ''' <summary>
    ''' Rounds the specified coordinates to the nearest grid location.
    ''' </summary>
    ''' <param name="point">The point containing the x and y coordinates to round</param>
    ''' <remarks>Useful for getting the grid location of the cursor</remarks>
    Public Sub PointToGrid(ByRef point As Point)
        PointToGrid(point.X, point.Y)
    End Sub

End Module
