Public Class ModificarUsuarios
    Inherits System.Web.UI.Page

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModificar.Click
        Dim usuario As Usuarios = New Usuarios()

        If txtLogin.Text = "" Or txtPassword.Text = "" Or txtNombre.Text = "" Or txtApellido.Text = "" Or txtDni.Text = "" Or txtTelefono.Text = "" Or txtRepPass.Text = "" Then
            MsgBox("Falta de rellenar")
        ElseIf txtPassword.Text <> txtRepPass.Text Then
            MsgBox("El campo password y repetir password no son iguales")
        Else
            usuario.login = txtLogin.Text
            usuario.password = txtPassword.Text
            usuario.nombre = txtNombre.Text
            usuario.apellido = txtApellido.Text
            usuario.dni = txtDni.Text
            usuario.telefono = txtTelefono.Text
            ' usuario.bloqueado = ddBloqueado.SelectedIndex
            ' usuario.administrador = ddAdministrador.SelectedIndex

            usuario.Modificar_Usuario()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        

        If Not Page.IsPostBack Then
            If Session("usuario") Is Nothing Or Session("usuario") = "" Then
                Response.Redirect("index.aspx")
            Else
                Dim user As Usuarios = New Usuarios()
                user = Session("DatosUsuario")
                txtLogin.Text = user.login
                txtPassword.Text = user.password
                txtNombre.Text = user.nombre
                txtApellido.Text = user.apellido
                txtDni.Text = user.dni
                txtTelefono.Text = user.telefono
                txtLogin.Enabled = False
                txtRepPass.Text = user.password
                ddlBloqueado.SelectedIndex = user.bloqueado
                ddlAdministrador.SelectedIndex = user.administrador
                CType(Page.Master.FindControl("lblcerrarsesion"), Label).Visible = True
                CType(Page.Master.FindControl("lblcerrarsesion"), Label).Text = "Bienvenid@ " + Session("usuario").ToString

                'pongo visible controles solo para admin
                Dim usuario As Usuarios = New Usuarios()
                usuario = Session("miUsuario")
                If usuario.administrador Then
                    lblAdministrador.Visible = True
                    lblBloqueado.Visible = True
                    ddlBloqueado.Visible = True
                    ddlAdministrador.Visible = True
                End If
            End If
        End If
    End Sub


    Sub actualizarCombo()
        Dim a As String = ""
    End Sub
End Class