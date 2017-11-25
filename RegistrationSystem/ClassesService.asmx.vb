Imports System.ComponentModel
Imports System.Web.Services

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace := "http://tempuri.org/")> _
<WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)>
Public Class WebService1
    Inherits WebService
    Private _classes As List(Of Class_Object)

    Private ReadOnly Property Classes As List(Of Class_Object)
        Get
            If _classes Is Nothing Then

            End If
            Return _classes
        End Get
    End Property

    <WebMethod>
    Public Function GetClasses() As Class_Object()
        Return Classes.ToArray()
    End Function

    '<WebMethod>
    'Public Function Order(productsToBeOrdered As Dictionary(Of String, Integer)) As String
    '    ' total quantity of the products
    '    Dim totalQuantity As Integer = 0

    '    ' total price
    '    Dim totalPrice As Double = 0

    '    ' calculate total quantity and total price
    '    For Each productQuantity As KeyValuePair(Of String, Integer) In productsToBeOrdered
    '        For Each product As Product In Products
    '            If product.Id.ToString() = productQuantity.Key Then
    '                totalQuantity += productQuantity.Value
    '                totalPrice += (product.Price * productQuantity.Value)
    '                Exit For
    '            End If
    '        Next
    '    Next

    ' save to database or other work can be done here
    ' ......

    ' return a formated string
    'Return String.Format("You've ordered {0} product(s) and the total price is ${1}. Thank you!", totalQuantity, totalPrice)
    'End Function
End Class
