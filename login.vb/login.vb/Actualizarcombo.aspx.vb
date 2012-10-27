Imports System.Data.SqlClient

Public Class Actualizarcombo
    Inherits System.Web.UI.Page

    Dim valorDdl As String = ""
    Dim valorTxt As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Dim valorDdl As String = Request.Form("valorActual")
        ' Dim valorTxt As String = Request.Form("valorLogin")

        valorDdl = Request.Form("valorActual")
        valorTxt = Request.Form("valorLogin")

        actualizarUsuario(valorDdl.ToString, valorTxt.ToString)

       
    End Sub

    Protected Sub actualizarUsuario(ByVal admin As String, ByVal login As String)
        Dim user As Usuarios = New Usuarios(valorTxt.ToString)
        user.administrador = valorDdl.ToString
        user.cambiar_administrador()

    End Sub
End Class