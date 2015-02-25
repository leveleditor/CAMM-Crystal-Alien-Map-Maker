Public Class Level

    Public Sub New()
        Map = New Map(Me)

        Team = Team.Astros
        CashPlayer = CashPlayerDefault
        CashEnemy = CashEnemyDefault

        IsTraining = IsTrainingDefault
        IsConflict = IsConflictDefault
        IsSpecialLevel = IsSpecialLevelDefault
        IsLastSpecialLevel = IsLastSpecialLevelDefault
        IsBonusLevel = IsBonusLevelDefault
    End Sub

    Public Map As Map

    Public Team As Team
    Public CashPlayer As Integer
    Public CashEnemy As Integer

    Public IsTraining As Boolean
    Public IsConflict As Boolean
    Public IsSpecialLevel As Boolean
    Public IsLastSpecialLevel As Boolean
    Public IsBonusLevel As Boolean

    Public Const CashPlayerDefault = 2000
    Public Const CashEnemyDefault = 20000
    Public Const IsTrainingDefault As Boolean = False
    Public Const IsConflictDefault As Boolean = False
    Public Const IsSpecialLevelDefault As Boolean = False
    Public Const IsLastSpecialLevelDefault As Boolean = False
    Public Const IsBonusLevelDefault As Boolean = True

    Public Function GetSaveData() As String
        Dim saveFileData As String = ""

        saveFileData += _
            "[CAMM]" + vbNewLine + _
            "vFormat = " + MapFormat.ToString + vbNewLine + _
            vbNewLine

        saveFileData += _
            "[Level]" + vbNewLine + _
            "Title = " + Map.MapTitle + vbNewLine + _
            "W = " + Map.SizeX.ToString + vbNewLine + _
            "H = " + Map.SizeY.ToString + vbNewLine + _
            "Team = " + CInt(Team).ToString + vbNewLine + _
            "CashPlayer = " + CashPlayer.ToString + vbNewLine + _
            "CashEnemy = " + CashEnemy.ToString + vbNewLine + _
            "isTraining = " + IsTraining.ToString + vbNewLine + _
            "isConflict = " + IsConflict.ToString + vbNewLine + _
            "isSpecialLevel = " + IsSpecialLevel.ToString + vbNewLine + _
            "isLastSpecialLevel = " + IsLastSpecialLevel.ToString + vbNewLine + _
            "isBonusLevel = " + IsBonusLevel.ToString + vbNewLine + _
            vbNewLine + _
            Map.GetSaveData()

        saveFileData += vbNewLine + "; -= Map Created Using CAMM Crystal Alien Map Maker =-"

        Return saveFileData
    End Function

End Class
