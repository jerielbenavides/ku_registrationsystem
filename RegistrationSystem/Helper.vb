

Public Class Helper
    Public Shared error_message As String = ""
    Public Shared max_credit_number As Integer = 15
    'An "schedule problem" happens if a class is at the same time, the same days
    Public Shared Function check_scheduleproblem(_class As Class_Object, string_id As String,
                                                 strings_for_panels As List(Of String), _list As List(Of Class_Object)) _
        As Boolean
        Dim list_of_courses = get_list_of_selected_courses(strings_for_panels, _list)

        Dim problem_timeoverlap = False
        Dim courses_sameday As List(Of Class_Object) = check_days(_class, list_of_courses)

        If courses_sameday IsNot Nothing Then
            problem_timeoverlap = check_time(_class, courses_sameday)
        Else

        End If
        Return problem_timeoverlap
    End Function

    Private Shared Function check_time(_class As Class_Object, courses_sameday As List(Of Class_Object)) As Boolean
        Dim overlap = False
        For Each x In courses_sameday
            'a.start < b.end && b.start < a.end
            overlap = _class.get_timeinAsTimeSpan() < x.get_timeoutAsTimeSpan() And
                      x.get_timeinAsTimeSpan() < _class.get_timeoutAsTimeSpan()
            If overlap Then
                error_message = "The course " & x.get_coursename() & " is at the same time. Remove it first."
                GoTo end_of_for
            End If
        Next
end_of_for:
        Return overlap
    End Function

    Private Shared Function check_days(_class As Class_Object, list_of_courses As List(Of Class_Object)) _
        As List(Of Class_Object)
        Dim courses_sameday As List(Of Class_Object) = list_of_courses
        For Each x In list_of_courses.ToList()
            Dim days_match = False
            If _class.get_days().Contains("M") And x.get_days().Contains("M") Then
                days_match = True
            End If
            If _class.get_days().Contains("T") And x.get_days().Contains("T") Then
                days_match = True
            End If
            If _class.get_days().Contains("W") And x.get_days().Contains("W") Then
                days_match = True
            End If
            If _class.get_days().Contains("R") And x.get_days().Contains("R") Then
                days_match = True
            End If
            If _class.get_days().Contains("F") And x.get_days().Contains("F") Then
                days_match = True
            End If
            If _class.get_days().Contains("S") And x.get_days().Contains("S") Then
                days_match = True
            End If
            If _class.get_days().Contains("D") And x.get_days().Contains("D") Then
                days_match = True
            End If
            If days_match Then
            Else
                courses_sameday.RemoveAt(list_of_courses.IndexOf(x))
            End If
        Next
        Return courses_sameday
    End Function

    Public Shared Function get_list_of_selected_courses(stringsForPanels As List(Of String),
                                                         _list As List(Of Class_Object)) As IEnumerable
        Dim list_classes As New List(Of Class_Object)
        For value = 0 To (stringsForPanels.Count - 11) Step 11
            Dim y As Integer = value + 10
            Dim classObject As Class_Object = _list.Find(Function(p) p.get_courseid() = stringsForPanels(y))
            If classObject IsNot Nothing Then
                list_classes.Add(classObject)
            End If
        Next
        Return list_classes
    End Function


    Public Shared Function check_samecourses(_class As Class_Object, stringId As String,
                                             strings_for_panels As List(Of String)) As Boolean
        Dim found = False
        Dim counter = 0
        For Each _string In strings_for_panels
            If _class.get_coursename() = _string Then
                counter = counter + 1
            End If
        Next
        If counter > 0 Then
            found = True
            error_message = "You already added " & _class.get_coursename() & " at a different time."
            Return found
        Else
            Return found
        End If
    End Function

    Public Shared Function check_credits(classObject As Class_Object, stringId As String,
                                         stringsForPanels As List(Of String), classObjects As List(Of Class_Object)) _
        As Boolean
        Dim creditsproblems = False
        Dim list_of_courses As List(Of Class_Object) = get_list_of_selected_courses(stringsForPanels, classObjects)
        Dim credit_number = 0
        For Each _class In list_of_courses
            credit_number = credit_number + _class.get_creditsint()
        Next
        credit_number = credit_number + classObject.get_creditsint()
        If (credit_number > max_credit_number) Then
            error_message = "You would have " & credit_number & " credits if you add " + classObject.get_coursename() &
                            ". " &
                            "You need to be authorized by the Dean of Academics to do that."
            creditsproblems = True
        End If
        Return creditsproblems
    End Function
End Class
