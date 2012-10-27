Imports Microsoft.VisualBasic

Public Class ValidatorHelper

Public Shared Function ValidarSqlParameter(ByVal nombreObjetivo As String, ByVal objetivo As Object, ByVal Nulo As Boolean, Optional ByVal longitud As Integer = 0) As Object
Dim tipo As String = Convert.GetTypeCode(objetivo).ToString()
Select Case tipo
Case "String"
 If Nulo And IsNothing(objetivo) Then Return DBNull.Value
If (Not Nulo) And IsNothing(objetivo) Then Throw New Exception("El campo " + nombreObjetivo.ToUpper + " no admite valores nulos")
If objetivo.Length > longitud Then Throw New Exception("El campo " + nombreObjetivo.ToUpper + " ha de tener una longitud menor o igual de " + longitud.ToString())
Case "Int32"
If Nulo And objetivo = 0 Then Return DBNull.Value
 If (Not Nulo) And objetivo = 0 Then Throw New Exception("El campo " + nombreObjetivo.ToUpper + " no admite valores nulos")
 Case "Long"
If Nulo And objetivo = 0 Then Return DBNull.Value
If (Not Nulo) And objetivo = 0 Then Throw New Exception("El campo " + nombreObjetivo.ToUpper + " no admite valores nulos")
Case "DateTime"
If Nulo And objetivo = Date.MinValue Then Return DBNull.Value
If (Not Nulo) And objetivo = Date.MinValue Then Throw New Exception("El campo " + nombreObjetivo.ToUpper + " no admite valores nulos")
Case "Decimal"
If Nulo And objetivo = 0 Then Return DBNull.Value
If (Not Nulo) And objetivo = 0 Then Throw New Exception("El campo " + nombreObjetivo.ToUpper + " no admite valores nulos")
Case "Money"
If Nulo And objetivo = 0 Then Return DBNull.Value
If (Not Nulo) And objetivo = 0 Then Throw New Exception("El campo " + nombreObjetivo.ToUpper + " no admite valores nulos")
Case "Byte()"
If Nulo And objetivo = 0 Then Return DBNull.Value
If (Not Nulo) And objetivo = 0 Then Throw New Exception("El campo " + nombreObjetivo.ToUpper + " no admite valores nulos")
Case Else
If Nulo And IsNothing(objetivo) Then Return DBNull.Value
If (Not Nulo) And IsNothing(objetivo) Then Throw New Exception("El campo " + nombreObjetivo.ToUpper + " no admite valores nulos")
End Select
Return objetivo
End Function

End Class
