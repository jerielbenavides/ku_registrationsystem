Public Class Class_Object
    Private ReadOnly courseid As Integer
    Private ReadOnly coursecode As String
    Private ReadOnly coursename As String
    Private ReadOnly credits As Integer
    Private timein As TimeSpan
    Private timeout As TimeSpan
    Private ReadOnly instructor As String
    Private ReadOnly room As String
    Private ReadOnly delivery As String
    Private ReadOnly isMonday As Boolean
    Private ReadOnly isTuesday As Boolean
    Private ReadOnly isWednesday As Boolean
    Private ReadOnly isThursday As Boolean
    Private ReadOnly isFriday As Boolean
    Private ReadOnly isSaturday As Boolean
    Private ReadOnly isSunday As Boolean

    Public Sub New(c_id As Integer, c_code As String, c_name As String, t_in As TimeSpan,
                   t_out As TimeSpan, inst As String, _room As String, mode As String,
                   is_M As Boolean, is_T As Boolean, is_W As Boolean, is_R As Boolean,
                   is_F As Boolean, is_Sat As Boolean, is_Sun As Boolean, cr As Integer)
        courseid = c_id
        coursecode = c_code
        coursename = c_name
        timein = t_in
        timeout = t_out
        instructor = inst
        room = _room
        delivery = mode
        isMonday = is_M
        isTuesday = is_T
        isWednesday = is_W
        isThursday = is_R
        isFriday = is_F
        isSaturday = is_Sat
        isSunday = is_Sun
        credits = cr
    End Sub

    Public Function get_coursename() As String
        Return coursename
    End Function

    Public Function get_coursecode() As String
        Return coursecode
    End Function

    Public Function get_credits() As String
        Return credits
    End Function

    Public Function get_creditsint() As Integer
        Return credits
    End Function

    Public Function get_timein() As String
        Return timein.ToString()
    End Function

    Public Function get_timeout() As String
        Return timeout.ToString()
    End Function

    Public Function get_timeinAsTimeSpan() As TimeSpan
        Return timein
    End Function

    Public Function get_timeoutAsTimeSpan() As TimeSpan
        Return timeout
    End Function

    Public Function get_instructor() As String
        Return instructor
    End Function

    Public Function get_room() As String
        Return room
    End Function

    Public Function get_mode() As String
        Return delivery
    End Function

    Public Function get_courseid() As String
        Return courseid
    End Function

    Public Function get_days() As String
        Dim days = ""
        If isMonday Then
            days += "M "
        End If
        If isTuesday Then
            days += "T "
        End If
        If isWednesday Then
            days += " W "
        End If
        If isThursday Then
            days += "R "
        End If
        If isFriday Then
            days += "F "
        End If
        If isSaturday Then
            days += "S "
        End If
        If isSunday Then
            days += "D"
        End If
        Return days
    End Function
End Class
