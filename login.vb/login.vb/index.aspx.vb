Public Class index
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("usuario") <> "" Then
            Session.Abandon()
        End If
        If Not Page.IsPostBack Then
            Session("intentos") = 0
        End If
    End Sub

    Protected Sub boton_aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles boton_aceptar.Click

        Dim user As Usuarios = New Usuarios(txtNombre.Text.ToString)
        'user.login = txtNombre.Text
        'user.password = txtPwd.Text

        If Session("intentos") <= 2 Then
            If user.Validar() Then                
                lblError.Visible = False
                Session.Clear()
                Session("miUsuario") = user
                Response.Redirect("ListadoUsuarios.aspx", False)
                Session("usuario") = user.login
            Else
                Session("intentos") += 1
                lblError.Text = "Usuario o contraseña incorrecta. Te quedan " & 3 - Session("intentos") & " intentos."
                lblError.Visible = True
            End If
        Else
            txtNombre.Enabled = False
            txtPwd.Enabled = False
            boton_aceptar.Enabled = False
            lblError.Text = ("Cuenta bloqueada. Consulta con el administrador")

        End If
    End Sub

    Protected Sub pass(ByVal source As Object, ByVal args As ServerValidateEventArgs)
        If Len(args.Value) <= 8 Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub


End Class