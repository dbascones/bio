Public Class Site1
    Inherits System.Web.UI.MasterPage



    Protected Sub CerrarSesion()
        If Session("usuario") <> "" Or Not (Session("usuario") Is Nothing) Then
            LogErrorHelper.escribir_log(HttpContext.Current.Session("usuario").ToString(), Date.Now(), "Cerrar sesión en Webmaster", "El usuario ha cerrado sesión", 2)
            Session.Abandon()
            Response.Redirect("~/index.aspx")
        End If
    End Sub


   

End Class