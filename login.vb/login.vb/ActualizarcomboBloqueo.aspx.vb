Public Class ActualizarcomboBloqueo
    Inherits System.Web.UI.Page

    Dim valorDdl As String = ""
    Dim valorTxt As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        valorDdl = Request.Form("valorActual")
        valorTxt = Request.Form("valorLogin")

        actualizarUsuario(valorDdl.ToString, valorTxt.ToString)

    End Sub

    Protected Sub actualizarUsuario(ByVal admin As String, ByVal login As String)
        Dim user As Usuarios = New Usuarios(valorTxt.ToString)
        user.bloqueado = valorDdl.ToString
        user.bloquear_usuario()

    End Sub
End Class