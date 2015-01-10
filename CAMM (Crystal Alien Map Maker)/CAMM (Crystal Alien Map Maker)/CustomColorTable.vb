Public Class CustomColorTable
    Inherits ProfessionalColorTable

    Public Overrides ReadOnly Property MenuStripGradientBegin() As System.Drawing.Color
        Get
            Return Color.FromArgb(100, Color.DarkGray)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuStripGradientEnd() As System.Drawing.Color
        Get
            Return Color.FromArgb(100, Color.DarkGray)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuBorder() As System.Drawing.Color
        Get
            Return Color.Black
        End Get
    End Property

    Public Overrides ReadOnly Property SeparatorDark() As System.Drawing.Color
        Get
            Return Color.Black
        End Get
    End Property

    Public Overrides ReadOnly Property SeparatorLight() As System.Drawing.Color
        Get
            Return Color.Transparent
        End Get
    End Property

    Public Overrides ReadOnly Property GripDark() As System.Drawing.Color
        Get
            Return Color.Black
        End Get
    End Property

    Public Overrides ReadOnly Property GripLight() As System.Drawing.Color
        Get
            Return Color.Transparent
        End Get
    End Property

    Public Overrides ReadOnly Property CheckBackground() As System.Drawing.Color
        Get
            Return Color.FromArgb(125, 125, 125)
        End Get
    End Property

    Public Overrides ReadOnly Property CheckSelectedBackground() As System.Drawing.Color
        Get
            Return Color.DarkGray
        End Get
    End Property

    Public Overrides ReadOnly Property CheckPressedBackground() As System.Drawing.Color
        Get
            Return Color.LightGreen
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonSelectedBorder() As System.Drawing.Color
        Get
            Return Color.Black
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientBegin() As System.Drawing.Color
        Get
            Return Color.Transparent
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientMiddle() As System.Drawing.Color
        Get
            Return Color.Transparent
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientEnd() As System.Drawing.Color
        Get
            Return Color.Transparent
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemBorder() As System.Drawing.Color
        Get
            Return Color.Transparent
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelected() As System.Drawing.Color
        Get
            Return Color.LightGray
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelectedGradientBegin() As System.Drawing.Color
        Get
            Return Color.FromArgb(200, 235, 235, 235)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelectedGradientEnd() As System.Drawing.Color
        Get
            Return Color.FromArgb(200, 235, 235, 235)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemPressedGradientBegin() As System.Drawing.Color
        Get
            Return Color.DarkGray
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemPressedGradientMiddle() As System.Drawing.Color
        Get
            Return Color.LightGray
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemPressedGradientEnd() As System.Drawing.Color
        Get
            Return Color.DarkGray
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripDropDownBackground() As System.Drawing.Color
        Get
            Return Color.White
        End Get
    End Property

    Public Overrides ReadOnly Property StatusStripGradientBegin() As System.Drawing.Color
        Get
            Return Color.FromArgb(100, Color.DarkGray)
        End Get
    End Property

    Public Overrides ReadOnly Property StatusStripGradientEnd() As System.Drawing.Color
        Get
            Return Color.FromArgb(100, Color.DarkGray)
        End Get
    End Property

End Class
