Public Class LogErrorHelper


    Public Shared Sub escribir_log(ByVal user As String, ByVal HoraFecha As DateTime, ByVal FuncionClaseMetodo As String,
                                   ByVal ErrorMensaje As String, ByVal TipoError As Integer)


        Dim datos As LogError = New LogError()
        datos.usuario = user
        datos.fechaHora = HoraFecha
        datos.metodoFuncionClase = FuncionClaseMetodo
        datos.mensajeError = ErrorMensaje
        datos.tipo = TipoError
        datos.Insertar_Log()
    End Sub
End Class
