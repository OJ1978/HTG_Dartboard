Public Class clsDartboardEvents
    Inherits EventArgs

    Public Delegate Sub NoScore(ByVal sender As Object, ByVal e As clsDartboardEvents)
    Public Delegate Sub [Single](ByVal sender As Object, ByVal e As clsDartboardEvents)
    Public Delegate Sub [Double](ByVal sender As Object, ByVal e As clsDartboardEvents)
    Public Delegate Sub Triple(ByVal sender As Object, ByVal e As clsDartboardEvents)


    Private ReadOnly intScore As Integer
    Private ReadOnly strScore As String

    Private ReadOnly intThrow As Integer

    Public Sub New(ByVal iScore As Integer, ByVal sScore As String, ByVal iThrow As Integer)

        intScore = iScore
        strScore = sScore
        intThrow = iThrow

    End Sub

    Public ReadOnly Property Score As Integer

        Get

            Return intScore

        End Get

    End Property

    Public ReadOnly Property ScoreString As String

        Get

            Return strScore

        End Get

    End Property

    Public ReadOnly Property [Throw] As Integer

        Get

            Return intThrow

        End Get

    End Property

End Class
