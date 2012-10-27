Public Class InsertarUsuarios
    Inherits System.Web.UI.Page

    Protected Sub btnAñadir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAñadir.Click
        Dim usuario As Usuarios = New Usuarios()

        If txtLogin.Text = "" Or txtPassword.Text = "" Or txtNombre.Text = "" Or txtApellido.Text = "" Or txtDni.Text = "" Or txtTelefono.Text = "" Or txtRepPass.Text = "" Then
            MsgBox("Falta de rellenar")
        ElseIf txtPassword.Text <> txtRepPass.Text Then
            MsgBox("El campo password y repetir password no son iguales")
        Else
            usuario.nombre = txtNombre.Text
            usuario.apellido = txtApellido.Text
            usuario.telefono = txtTelefono.Text
            usuario.login = txtLogin.Text
            usuario.dni = txtDni.Text
            usuario.password = txtPassword.Text
            usuario.bloqueado = ddBloqueado.SelectedIndex
            usuario.administrador = ddAdministrador.SelectedIndex
            usuario.Insertar_Usuario()
            limpiarFormulario()
        End If
    End Sub

    Protected Sub limpiarFormulario()

        txtLogin.Text = ""
        txtPassword.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtDni.Text = ""
        txtTelefono.Text = ""
        txtRepPass.Text = ""

        txtLogin.Focus()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("usuario") Is Nothing Or Session("usuario") = "" Then
                Response.Redirect("index.aspx")
            Else
                CType(Page.Master.FindControl("lblcerrarsesion"), Label).Visible = True
                CType(Page.Master.FindControl("lblcerrarsesion"), Label).Text = "Bienvenid@ " + Session("usuario").ToString

                Dim usuario As Usuarios = New Usuarios()
                usuario = Session("miUsuario")
                If usuario.administrador Then
                    lblAdministrador.Visible = True
                    lblbloqueado.Visible = True
                    ddBloqueado.Visible = True
                    ddAdministrador.Visible = True
                End If
            End If
        End If
    End Sub
End Class