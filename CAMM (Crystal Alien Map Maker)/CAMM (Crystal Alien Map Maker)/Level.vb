Public Class Level

    Public Sub New()
        Map = New Map()

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

End Class
