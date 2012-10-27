Imports System.Data
Imports System.Data.SqlClient

Public Class LogError


#Region "Propiedades"
    Private _usuario As String
    Private _fechaHora As DateTime
    Private _metodoFuncionClase As String
    Private _mensajeError As String
    Private _tipo As Integer
    Private _id As Integer
#End Region

    Property usuario() As String
        Get
            Return Me._usuario
        End Get
        Set(ByVal usuario As String)
            Me._usuario = usuario
        End Set
    End Property

    Property fechaHora() As DateTime
        Get
            Return Me._fechaHora
        End Get
        Set(ByVal fechaHora As DateTime)
            Me._fechaHora = fechaHora
        End Set
    End Property

    Property metodoFuncionClase() As String
        Get
            Return Me._metodoFuncionClase
        End Get
        Set(ByVal metodoFuncionClase As String)
            Me._metodoFuncionClase = metodoFuncionClase
        End Set
    End Property

    Property mensajeError() As String
        Get
            Return Me._mensajeError
        End Get
        Set(ByVal mensajeError As String)
            Me._mensajeError = mensajeError
        End Set
    End Property

    Property tipo() As Integer
        Get
            Return Me._tipo
        End Get
        Set(ByVal tipo As Integer)
            Me._tipo = tipo
        End Set
    End Property

    Property id() As Integer
        Get
            Return Me._id
        End Get
        Set(ByVal id As Integer)
            Me._id = id
        End Set
    End Property

#Region "Constructores"

    Sub New()

    End Sub

    Sub New(ByVal id As Integer) 'CONTRUCTOR CON UN UNICO PARAMETRO
        Try
            internalLoad(id)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

#Region "Metodos"

    Protected Sub internalLoad(ByVal login As String)
        Dim sql As String
        sql = "select * from LogError where id=@id"
        Dim parId As New SqlParameter("@id", ValidatorHelper.ValidarSqlParameter("id", id, False, 8))
        Try
            Dim cadena As String = ConfigurationManager.AppSettings("cadenaConexion")
            Dim objDS = SqlHelper.ExecuteDataset(cadena, Data.CommandType.Text, sql, parId)
            If objDS.Tables(0).Rows.Count > 0 Then
                Dim fila As DataRow = objDS.Tables(0).Rows(0)
                If Not IsDBNull(fila("usuario")) Then Me._usuario = fila("usuario").ToString
                If Not IsDBNull(fila("fechaHora")) Then Me._fechaHora = fila("fechaHora").ToString
                If Not IsDBNull(fila("metodoFuncionclase")) Then Me._metodoFuncionClase = fila("metodoFuncionClase").ToString
                If Not IsDBNull(fila("mensajeError")) Then Me._mensajeError = fila("MensajeError").ToString
                If Not IsDBNull(fila("tipo")) Then Me._tipo = fila("tipo").ToString
                If Not IsDBNull(fila("id")) Then Me._id = fila("id").ToString
            Else
                Throw New Exception("Identificador de la Consulta no encontrado.")
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Public Sub Insertar_Log()

        Dim sql As String
        sql = "insert into logs (usuario, fechaHora, metodoFuncionClase, mensajeError, tipo) values (@usuario, @fechaHora, @metodoFuncionClase, @mensajeError, @tipo)"

        Dim parUsuario As New SqlParameter("@usuario", ValidatorHelper.ValidarSqlParameter("logs.usuario", Me._usuario, False, 8))
        Dim parFechaHora As New SqlParameter("@fechaHora", ValidatorHelper.ValidarSqlParameter("logs.fechaHora", Me._fechaHora, False, 8))
        Dim parMetodoFuncionClase As New SqlParameter("@metodoFuncionClase", ValidatorHelper.ValidarSqlParameter("logs.metodoFuncionClase", Me._metodoFuncionClase, False, 200))
        Dim parMensajeError As New SqlParameter("@mensajeError", ValidatorHelper.ValidarSqlParameter("logs.mensajeError", Me._mensajeError, False, 200))
        Dim parTipo As New SqlParameter("@tipo", ValidatorHelper.ValidarSqlParameter("logs.tipo", Me._tipo, False, 50))

        Try
            Dim cadena As String = ConfigurationManager.AppSettings("cadenaConexion")
            Dim objDS = SqlHelper.ExecuteDataset(cadena, Data.CommandType.Text, sql, parUsuario, parFechaHora, parMetodoFuncionClase, parMensajeError, parTipo)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region

End Class
