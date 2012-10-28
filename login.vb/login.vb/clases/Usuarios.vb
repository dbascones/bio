Imports System.Data
Imports System.Data.SqlClient


Public Class Usuarios


#Region "Propiedades"
    Private _login As String
    Private _password As String
    Private _nombre As String
    Private _apellido As String
    Private _dni As String
    Private _telefono As String
    Private _bloqueado As String
    Private _administrador As String


    Property login() As String
        Get
            Return Me._login
        End Get
        Set(ByVal login As String)
            Me._login = login
        End Set
    End Property

    Property password() As String
        Get
            Return Me._password
        End Get
        Set(ByVal password As String)
            Me._password = password
        End Set
    End Property

    Property nombre() As String
        Get
            Return Me._nombre
        End Get
        Set(ByVal nombre As String)
            Me._nombre = nombre
        End Set
    End Property

    Property apellido() As String
        Get
            Return Me._apellido
        End Get
        Set(ByVal apellido As String)
            Me._apellido = apellido
        End Set
    End Property

    Property dni() As String
        Get
            Return Me._dni
        End Get
        Set(ByVal dni As String)
            Me._dni = dni
        End Set
    End Property

    Property telefono() As Integer
        Get
            Return Me._telefono
        End Get
        Set(ByVal telefono As Integer)
            Me._telefono = telefono
        End Set
    End Property

    Property bloqueado() As String
        Get
            Return Me._bloqueado
        End Get
        Set(ByVal bloqueado As String)
            Me._bloqueado = bloqueado
        End Set
    End Property

    Property administrador() As String
        Get
            Return Me._administrador
        End Get
        Set(ByVal administrador As String)
            Me._administrador = administrador
        End Set
    End Property

#End Region


#Region "Constructores"

    Sub New()
    End Sub

    Sub New(ByVal login As String) 'CONTRUCTOR CON UN UNICO PARAMETRO
        Try
            internalLoad(login)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

#End Region



#Region "Metodos"

    Protected Sub internalLoad(ByVal login As String)
        Dim sql As String
        sql = "select * from usuarios where login=@login"
        Dim parlogin As New SqlParameter("@login", ValidatorHelper.ValidarSqlParameter("login", login, False, 8))
        Try
            Dim cadena As String = ConfigurationManager.AppSettings("cadenaConexion")
            Dim objDS = SqlHelper.ExecuteDataset(cadena, Data.CommandType.Text, sql, parlogin)
            If objDS.Tables(0).Rows.Count > 0 Then
                Dim fila As DataRow = objDS.Tables(0).Rows(0)
                If Not IsDBNull(fila("login")) Then Me._login = fila("login").ToString
                If Not IsDBNull(fila("password")) Then Me._password = fila("password").ToString
                If Not IsDBNull(fila("nombre")) Then Me._nombre = fila("nombre").ToString
                If Not IsDBNull(fila("apellido")) Then Me._apellido = fila("apellido").ToString
                If Not IsDBNull(fila("dni")) Then Me._dni = fila("dni").ToString
                If Not IsDBNull(fila("telefono")) Then Me._telefono = fila("telefono").ToString
                If Not IsDBNull(fila("bloqueado")) Then Me._bloqueado = fila("bloqueado").ToString
                If Not IsDBNull(fila("administrador")) Then Me._administrador = fila("administrador").ToString
            Else
                Throw New Exception("Identificador de la Consulta no encontrado.")
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function Insertar_Usuario()

        Dim sql As String
        sql = "insert into usuarios (login, password, nombre, apellido, dni, telefono, bloqueado, administrador) values (@login, @password, @nombre, @apellido, @dni, @telefono, @bloqueado, @administrador)"

        Dim parLogin As New SqlParameter("@login", ValidatorHelper.ValidarSqlParameter("usuario.login", Me._login, False, 8))
        Dim parPassword As New SqlParameter("@password", ValidatorHelper.ValidarSqlParameter("usuario.password", Me._password, False, 8))
        Dim parNombre As New SqlParameter("@nombre", ValidatorHelper.ValidarSqlParameter("usuario.nombre", Me._nombre, False, 50))
        Dim parApellido As New SqlParameter("@apellido", ValidatorHelper.ValidarSqlParameter("usuario.apellido", Me._apellido, False, 50))
        Dim parDni As New SqlParameter("@dni", ValidatorHelper.ValidarSqlParameter("usuario.dni", Me._dni, False, 50))
        Dim parTelefono As New SqlParameter("@telefono", ValidatorHelper.ValidarSqlParameter("usuario.telefono", Me._telefono, False, 9))
        Dim parBloqueado As New SqlParameter("@bloqueado", ValidatorHelper.ValidarSqlParameter("usuario.bloqueado", Me._bloqueado, False, 2))
        Dim parAdministrador As New SqlParameter("@administrador", ValidatorHelper.ValidarSqlParameter("usuario.administrador", Me._administrador, False, 2))

        Try
            Dim cadena As String = ConfigurationManager.AppSettings("cadenaConexion")
            Dim objDS = SqlHelper.ExecuteDataset(cadena, Data.CommandType.Text, sql, parLogin, parPassword, parNombre, parApellido, parDni, parTelefono, parBloqueado, parAdministrador)
            LogErrorHelper.escribir_log(HttpContext.Current.Session("usuario").ToString(), Date.Now(), "Función de inserción en clase usuario", "El usuario ha introducido un nuevo registro", 3)
        Catch ex As Exception
            LogErrorHelper.escribir_log(HttpContext.Current.Session("usuario").ToString(), Date.Now(), "Error: Función de inserción en clase usuario.", "Error al introducir registro. Consulta: " + sql.ToString, 1)
            Return False
        End Try

        Return True
    End Function

    Public Function Eliminar_Ususario() As Boolean

        Dim sql As String
        sql = "delete from usuarios where login=@login"

        Dim parLogin As New SqlParameter("@login", ValidatorHelper.ValidarSqlParameter("usuario.login", Me._login, False, 8))

        Try
            Dim cadena As String = ConfigurationManager.AppSettings("cadenaConexion")
            Dim objDS = SqlHelper.ExecuteDataset(cadena, Data.CommandType.Text, sql, parLogin)
            LogErrorHelper.escribir_log(HttpContext.Current.Session("usuario").ToString, Date.Now(), "Función de eliminación en clase usuario", "El usuario ha eliminado un registro", 3)
        Catch ex As Exception
            LogErrorHelper.escribir_log(HttpContext.Current.Session("usuario").ToString, Date.Now(), "Error: Función de eliminación en clase usuario.", "Error al eliminar registro. Consulta: " + sql.ToString, 1)
            Return False
        End Try

        Return True
    End Function

    Public Function Modificar_Usuario()

        Dim sql As String

        sql = "update usuarios set login=@login, password = @password, nombre = @nombre, apellido = @apellido, dni = @dni, telefono, bloqueado=@bloqueado, administrador=@administrador = @telefono WHERE  login = @login "

        Dim parLogin As New SqlParameter("@login", ValidatorHelper.ValidarSqlParameter("usuario.login", Me._login, False, 8))
        Dim parPassword As New SqlParameter("@password", ValidatorHelper.ValidarSqlParameter("usuario.password", Me._password, False, 8))
        Dim parNombre As New SqlParameter("@nombre", ValidatorHelper.ValidarSqlParameter("usuario.nombre", Me._nombre, False, 50))
        Dim parApellido As New SqlParameter("@apellido", ValidatorHelper.ValidarSqlParameter("usuario.apellido", Me._apellido, False, 50))
        Dim parDni As New SqlParameter("@dni", ValidatorHelper.ValidarSqlParameter("usuario.dni", Me._dni, False, 50))
        Dim parTelefono As New SqlParameter("@telefono", ValidatorHelper.ValidarSqlParameter("usuario.telefono", Me._telefono, False, 9))
        Dim parBloqueado As New SqlParameter("@bloqueado", ValidatorHelper.ValidarSqlParameter("usuario.bloqueado", Me._bloqueado, False, 2))
        Dim parAdministrador As New SqlParameter("@administrador", ValidatorHelper.ValidarSqlParameter("usuario.administrador", Me._administrador, False, 2))

        Try
            Dim cadena As String = ConfigurationManager.AppSettings("cadenaConexion")
            Dim objDS = SqlHelper.ExecuteDataset(cadena, Data.CommandType.Text, sql, parLogin, parPassword, parNombre, parApellido, parDni, parTelefono, parBloqueado, parAdministrador)
            LogErrorHelper.escribir_log(HttpContext.Current.Session("usuario").ToString, Date.Now(), "Función de modificación en clase usuario", "El usuario ha modificado un registro", 3)
        Catch ex As Exception
            LogErrorHelper.escribir_log(HttpContext.Current.Session("usuario").ToString, Date.Now(), "Error: Función de modificación en clase usuario.", "Error al modificar registro. Consulta: " + sql.ToString, 1)
            Return False
        End Try

        Return True
    End Function

    Public Function Validar() As Boolean

        Dim sql As String

        sql = "select * from usuarios where login=@login and password=@password"

        Dim parLogin As New SqlParameter("@login", ValidatorHelper.ValidarSqlParameter("usuario.login", Me._login, False, 8))
        Dim parPassword As New SqlParameter("@password", ValidatorHelper.ValidarSqlParameter("usuario.password", Me._password, False, 8))

        Try
            Dim cadena As String = ConfigurationManager.AppSettings("cadenaConexion")
            Dim objDS = SqlHelper.ExecuteDataset(cadena, Data.CommandType.Text, sql, parLogin, parPassword)
            If objDS.Tables(0).Rows.Count > 0 Then
                LogErrorHelper.escribir_log(parLogin.Value.ToString, Date.Now(), "Función de validación en clase usuario.", "El usuario ha iniciado sesión", 3)
                Return True
            Else
                LogErrorHelper.escribir_log(parLogin.Value.ToString, Date.Now(), "Función de validación en clase usuario.", "Usuario no validado, inexistente o error de entrada de datos.", 2)
                Return False
            End If
        Catch ex As Exception
            LogErrorHelper.escribir_log(parLogin.Value.ToString, Date.Now(), "Error: Función de validación en clase usuario.", ex.Message + "Consulta: " + sql.ToString, 1)
            Return False
        End Try

    End Function

    Public Function bloquear_usuario() As Boolean

        Dim sql As String

        sql = "update usuarios set bloqueado=@bloqueado WHERE  login = @login "

        Dim parLogin As New SqlParameter("@login", ValidatorHelper.ValidarSqlParameter("usuario.login", Me._login, False, 8))
        Dim parBloqueado As New SqlParameter("@bloqueado", ValidatorHelper.ValidarSqlParameter("usuario.bloqueado", Me._bloqueado, False, 2))

        Try
            Dim cadena As String = ConfigurationManager.AppSettings("cadenaConexion")
            Dim objDS = SqlHelper.ExecuteDataset(cadena, Data.CommandType.Text, sql, parLogin, parBloqueado)
            LogErrorHelper.escribir_log(HttpContext.Current.Session("usuario").ToString, Date.Now(), "Usuario actualizado correctamente", "El usuario ha sido bloqueado", 3)
        Catch ex As Exception
            LogErrorHelper.escribir_log(HttpContext.Current.Session("usuario").ToString, Date.Now(), "Error: Función de modificación en clase usuario.", "Error al bloquear el usuario. Consulta: " + sql.ToString, 1)
            Return False
        End Try

        Return True
    End Function

    Public Function cambiar_administrador() As Boolean

        Dim sql As String

        sql = "update usuarios set administrador=@administrador WHERE  login = @login "

        Dim parLogin As New SqlParameter("@login", ValidatorHelper.ValidarSqlParameter("usuario.login", Me._login, False, 8))
        Dim parAdministrador As New SqlParameter("@administrador", ValidatorHelper.ValidarSqlParameter("usuario.administrador", Me._administrador, False, 2))

        Try
            Dim cadena As String = ConfigurationManager.AppSettings("cadenaConexion")
            Dim objDS = SqlHelper.ExecuteDataset(cadena, Data.CommandType.Text, sql, parLogin, parAdministrador)
            LogErrorHelper.escribir_log(HttpContext.Current.Session("usuario").ToString, Date.Now(), "Usuario actualizado correctamente", "El usuario ha modificado un registro", 3)
        Catch ex As Exception
            LogErrorHelper.escribir_log(HttpContext.Current.Session("usuario").ToString, Date.Now(), "Error: Usuario actualizado con error.", "Error al modificar registro. Consulta: " + sql.ToString, 1)
            Return False
        End Try

        Return True
    End Function
#End Region


End Class
