Public Class CustomColorTable
    Inherits ProfessionalColorTable

    Public Overrides ReadOnly Property MenuStripGradientBegin As Color
        Get
            Return Color.FromArgb(100, Color.DarkGray)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuStripGradientEnd As Color
        Get
            Return Color.FromArgb(100, Color.DarkGray)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuBorder As Color
        Get
            Return Color.Black
        End Get
    End Property

    Public Overrides ReadOnly Property SeparatorDark As Color
        Get
            Return Color.Black
        End Get
    End Property

    Public Overrides ReadOnly Property SeparatorLight As Color
        Get
            Return Color.Transparent
        End Get
    End Property

    Public Overrides ReadOnly Property GripDark As Color
        Get
            Return Color.Black
        End Get
    End Property

    Public Overrides ReadOnly Property GripLight As Color
        Get
            Return Color.Transparent
        End Get
    End Property

    Public Overrides ReadOnly Property CheckBackground As Color
        Get
            Return Color.FromArgb(125, 125, 125)
        End Get
    End Property

    Public Overrides ReadOnly Property CheckSelectedBackground As Color
        Get
            Return Color.DarkGray
        End Get
    End Property

    Public Overrides ReadOnly Property CheckPressedBackground As Color
        Get
            Return Color.LightGreen
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonSelectedBorder As Color
        Get
            Return Color.Black
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientBegin As Color
        Get
            Return Color.Transparent
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientMiddle As Color
        Get
            Return Color.Transparent
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientEnd As Color
        Get
            Return Color.Transparent
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemBorder As Color
        Get
            Return Color.Transparent
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelected As Color
        Get
            Return Color.LightGray
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelectedGradientBegin As Color
        Get
            Return Color.FromArgb(200, 235, 235, 235)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelectedGradientEnd As Color
        Get
            Return Color.FromArgb(200, 235, 235, 235)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemPressedGradientBegin As Color
        Get
            Return Color.DarkGray
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemPressedGradientMiddle As Color
        Get
            Return Color.LightGray
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemPressedGradientEnd As Color
        Get
            Return Color.DarkGray
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripDropDownBackground As Color
        Get
            Return Color.White
        End Get
    End Property

    Public Overrides ReadOnly Property StatusStripGradientBegin As Color
        Get
            Return Color.FromArgb(100, Color.DarkGray)
        End Get
    End Property

    Public Overrides ReadOnly Property StatusStripGradientEnd As Color
        Get
            Return Color.FromArgb(100, Color.DarkGray)
        End Get
    End Property

End Class
