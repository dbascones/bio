Public Class ListadoUsuarios
    Inherits System.Web.UI.Page

    Protected Sub Eliminar(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim valorLogin = DirectCast(sender, System.Web.UI.WebControls.LinkButton).CommandArgument
        Dim usuario As Usuarios = New Usuarios()
        usuario.login = valorLogin.ToString

        If usuario.Eliminar_Ususario() Then
            ListView1.DataBind()
        Else
            MsgBox("No se ha podido eliminar el usuario.")
        End If
    End Sub

    Protected Sub Modificar(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim valorLogin = DirectCast(sender, System.Web.UI.WebControls.LinkButton).CommandArgument
        Dim usuario As Usuarios = New Usuarios(valorLogin.ToString)
        Session("DatosUsuario") = usuario
        Response.Redirect("~/ModificarUsuarios.aspx")

    End Sub


    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
        If Len(txtBuscar.Text) > 0 Then
            Session("valor_Busqueda") = txtBuscar.Text.ToString
        Else
            Session("valor_Busqueda") = String.Empty
        End If
        ListView1.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("usuario") Is Nothing Or Session("usuario") = "" Then
                Response.Redirect("index.aspx")
            Else
                Session("valor_Busqueda") = String.Empty
                CType(Page.Master.FindControl("lblcerrarsesion"), Label).Visible = True
                CType(Page.Master.FindControl("lblcerrarsesion"), Label).Text = "Bienvenid@ " + Session("usuario").ToString
                ListView1.DataBind()
            End If
        End If
    End Sub

    Private Sub ListView1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles ListView1.ItemDataBound
        Dim usuario As Usuarios = New Usuarios()
        usuario = Session("miUsuario")
        Dim fila As ListViewDataItem = e.Item
        If usuario.administrador Then
            DirectCast(fila.FindControl("btnEdit"), LinkButton).Visible = True
            DirectCast(fila.FindControl("btnDelete"), LinkButton).Visible = True
        End If
    End Sub
End Class