Imports System.IO

Public Module Utils
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

    ''' <summary>
    ''' Draws grid lines on the specified graphics at the specified size.
    ''' </summary>
    ''' <param name="g">A reference to the graphics to draw onto.</param>
    ''' <param name="gridWidth">The width of the entire grid.</param>
    ''' <param name="gridHeight">The height of the entire grid.</param>
    ''' <param name="tileWidth">Optional width of each tile. Default is <code>TileSizeX</code>.</param>
    ''' <param name="tileHeight">Optional height of each tile. Default is <code>TileSizeY</code>.</param>
    Public Sub DrawGridLines(g As Graphics, gridWidth As Integer, gridHeight As Integer, Optional tileWidth As Integer = TileSizeX, Optional tileHeight As Integer = TileSizeY)
        For x As Integer = 0 To gridWidth Step tileWidth
            For y As Integer = 0 To gridHeight Step tileHeight
                If x > 0 And x < gridWidth Then
                    g.DrawLine(PenGrid, x, y, x, y + tileHeight)
                End If
                If y > 0 And y < gridHeight Then
                    g.DrawLine(PenGrid, x, y, x + tileWidth, y)
                End If
            Next y
        Next x
    End Sub

    ''' <summary>
    ''' Returns the distance between two points.
    ''' </summary>
    ''' <param name="x1">First point x position</param>
    ''' <param name="y1">First point y position</param>
    ''' <param name="x2">Second point x position</param>
    ''' <param name="y2">Second point y position</param>
    ''' <returns>The distance between the two points as a Double</returns>
    ''' <remarks>Useful for checking if the cursor is close to an object</remarks>
    Public Function GetRadialDistance(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer) As Double
        Return Math.Sqrt(((x1 - x2) ^ 2) + ((y1 - y2) ^ 2))
    End Function

    ''' <summary>
    ''' Forces a value to be no lower than min and no higher than max.
    ''' </summary>
    ''' <param name="value">The value to clamp</param>
    ''' <param name="min">The lowest possible value</param>
    ''' <param name="max">The highest possible value</param>
    ''' <returns></returns>
    Public Function Clamp(value As Single, min As Single, max As Single) As Single
        Return If(value < min, min, If(value > max, max, value))
    End Function

    ''' <summary>
    ''' Opens a link in the default web browser of the computer, and shows a waiting cursor on the form in case the browser is not responding.
    ''' </summary>
    ''' <param name="waitingForm">The form to show the waiting cursor on</param>
    ''' <param name="link">The link to open in the default web browser</param>
    Friend Sub OpenLinkInDefaultBrowser(waitingForm As Form, link As String)
        waitingForm.UseWaitCursor = True
        Try
            Diagnostics.Process.Start(link)
        Catch ex As Exception

        Finally
            waitingForm.UseWaitCursor = False
        End Try
    End Sub

End Module
