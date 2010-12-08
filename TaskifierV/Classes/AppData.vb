Public Class LogEntryData

    Private _id
    Private _logType
    Private _name
    Private _description
    Private _priority
    Private _startDate
    Private _endDate
    Private _active
    Private _inProgress
    Private _finished

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property LogType() As String
        Get
            Return _logType
        End Get
        Set(ByVal value As String)
            _logType = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property

    Public Property Priority() As String
        Get
            Return _priority
        End Get
        Set(ByVal value As String)
            _priority = value
        End Set
    End Property

    Public Property StartDate() As Date
        Get
            Return _startDate
        End Get
        Set(ByVal value As Date)
            _startDate = value
        End Set
    End Property

    Public Property EndDate() As Date
        Get
            Return _endDate
        End Get
        Set(ByVal value As Date)
            _endDate = value
        End Set
    End Property

    Public Property Active() As String
        Get
            Return _active
        End Get
        Set(ByVal value As String)
            _active = value
        End Set
    End Property

    Public Property InProgress() As String
        Get
            Return _inProgress
        End Get
        Set(ByVal value As String)
            _inProgress = value
        End Set
    End Property

    Public Property Finished() As String
        Get
            Return _finished
        End Get
        Set(ByVal value As String)
            _finished = value
        End Set
    End Property

End Class

Public Class TagData

End Class
