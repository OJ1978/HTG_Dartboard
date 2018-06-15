Imports HTG_Dartboard.clsDartboardEvents

Public Class ctlDartboard

    Private intThrow As Integer = 1
    Private intScore As Integer

    Private strScore As String

    Private blnNoScore As Boolean = False
    Private blnSingle As Boolean = False
    Private blnDouble As Boolean = False
    Private blnriple As Boolean = False

    Public Event eNoScore As NoScore
    Public Event eSingle As [Single]
    Public Event eDouble As [Double]
    Public Event eTriple As Triple

    Private Enum Ring

        None = 0
        [Single]
        [Double]
        Triple
        SingleBullsEye
        DoubleBullsEye

    End Enum

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

    Public Sub Reset()

        intThrow = 0

    End Sub

    Protected Overridable Sub OnNoScore(ByVal e As clsDartboardEvents)

        RaiseEvent eNoScore(Me, e)

    End Sub

    Protected Overridable Sub OnSingle(ByVal e As clsDartboardEvents)

        RaiseEvent eSingle(Me, e)

    End Sub

    Protected Overridable Sub OnDouble(ByVal e As clsDartboardEvents)

        RaiseEvent eDouble(Me, e)

    End Sub

    Protected Overridable Sub OnTriple(ByVal e As clsDartboardEvents)

        RaiseEvent eTriple(Me, e)

    End Sub

    Private Function GetScore(ByVal X As Integer, ByVal Y As Integer) As Integer

        Try

            Dim iScore As Integer = 0

            Dim dRadianCorner As Double = System.Math.Atan2(Y, X)
            Dim dDegCorner As Double = dRadianCorner * 180 / System.Math.PI

            Dim iCorner As Integer = CInt(dDegCorner)

            If iCorner < 0 Then

                iCorner = 180 + (iCorner + 180)

            End If

            Dim iNummer As Integer = GetNumberThrown(iCorner)

            Dim eRing As Ring = GetRing(X, Y)

            blnNoScore = False
            blnSingle = False
            blnDouble = False
            blnriple = False

            Select Case eRing

                Case Ring.None
                    strScore = "-"
                    iScore = 0
                    blnNoScore = True

                Case Ring.Single

                    strScore = "S" & iNummer.ToString()
                    iScore = iNummer
                    blnSingle = True

                Case Ring.Double

                    strScore = "D" & iNummer.ToString()
                    iScore = iNummer * 2
                    blnDouble = True

                Case Ring.Triple

                    strScore = "T" & iNummer.ToString()
                    iScore = iNummer * 3
                    blnriple = True

                Case Ring.SingleBullsEye

                    strScore = "SingleBull"
                    iScore = 25
                    blnSingle = True

                Case Ring.DoubleBullsEye

                    strScore = "DoubleBull"
                    iScore = 50
                    blnDouble = True

            End Select

            Return iScore

        Catch ex As Exception

            Throw ex

        End Try

    End Function

    Private Function GetNumberThrown(ByVal CornerDegree As Integer) As Integer

        Try

            If CornerDegree >= 63 Then Return 1
            If CornerDegree >= 297 Then Return 2
            If CornerDegree >= 261 Then Return 3
            If CornerDegree >= 27 Then Return 4
            If CornerDegree >= 99 Then Return 5
            If CornerDegree >= 351 Then Return 6
            If CornerDegree >= 225 Then Return 7
            If CornerDegree >= 189 Then Return 8
            If CornerDegree >= 135 Then Return 9
            If CornerDegree >= 333 Then Return 10
            If CornerDegree >= 171 Then Return 11
            If CornerDegree >= 117 Then Return 12
            If CornerDegree >= 9 Then Return 13
            If CornerDegree >= 153 Then Return 14
            If CornerDegree >= 315 Then Return 15
            If CornerDegree >= 207 Then Return 16
            If CornerDegree >= 279 Then Return 17
            If CornerDegree >= 45 Then Return 18
            If CornerDegree >= 243 Then Return 19
            If CornerDegree >= 81 Then Return 20

            Return 6

        Catch ex As Exception

            Throw ex

        End Try

    End Function

    Private Function GetRing(ByVal X As Integer, ByVal Y As Integer) As Ring

        Try

            Dim dblLength As Double = System.Math.Sqrt(X * X + Y * Y)

            Dim intLength As Integer = CInt(System.Math.Floor(dblLength))

            If intLength > 170 Then Return Ring.None
            If intLength >= 160 AndAlso intLength <= 170 Then Return Ring.Double
            If intLength >= 95 AndAlso intLength <= 105 Then Return Ring.Triple
            If intLength > 7 AndAlso intLength <= 15 Then Return Ring.SingleBullsEye
            If intLength <= 7 Then Return Ring.DoubleBullsEye

            Return Ring.Single

        Catch ex As Exception

            Throw ex

        End Try

    End Function

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp

        Try

            Dim X As Integer = (e.X)
            Dim Y As Integer = (e.Y)

            intScore = GetScore(X, Y)

            Dim bBrush As Brush = Brushes.Red
            Dim g As Graphics = PictureBox1.CreateGraphics()

            g.FillRectangle(bBrush, X, Y, 2, 2)

            Dim de As clsDartboardEvents = New clsDartboardEvents(intScore, strScore, intThrow)

            If blnNoScore Then OnNoScore(de)
            If blnDouble Then OnDouble(de)
            If blnriple Then OnTriple(de)
            If blnSingle Then OnSingle(de)

            intThrow += 1

            If intThrow = 4 Then

                intThrow = 1

            End If

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

End Class
