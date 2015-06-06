Public Class RectangleBrushPreset

    Private ReadOnly _fileName As String
    Private ReadOnly _title As String
    Private ReadOnly _data As Integer()()

    Sub New(fileName As String, title As String, data As Integer()())
        Me._fileName = fileName
        Me._title = title
        Me._data = data
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

End Class