Public Class LogEntryData

    Private _Id
    Private _LogType
    Private _Name
    Private _Description
    Private _Priority
    Private _StartDate
    Private _EndDate
    Private _Active
    Private _InProgress
    Private _Finished

    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property

    Public Property LogType() As String
        Get
            Return _LogType
        End Get
        Set(ByVal value As String)
            _LogType = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Public Property Priority() As String
        Get
            Return _Priority
        End Get
        Set(ByVal value As String)
            _Priority = value
        End Set
    End Property

    Public Property StartDate() As Date
        Get
            Return _StartDate
        End Get
        Set(ByVal value As Date)
            _StartDate = value
        End Set
    End Property

    Public Property EndDate() As Date
        Get
            Return _EndDate
        End Get
        Set(ByVal value As Date)
            _EndDate = value
        End Set
    End Property

    Public Property Active() As String
        Get
            Return _Active
        End Get
        Set(ByVal value As String)
            _Active = value
        End Set
    End Property

    Public Property InProgress() As String
        Get
            Return _InProgress
        End Get
        Set(ByVal value As String)
            _InProgress = value
        End Set
    End Property

    Public Property Finished() As String
        Get
            Return _Finished
        End Get
        Set(ByVal value As String)
            _Finished = value
        End Set
    End Property

End Class

Public Class TagData

End Class
