Public Class UsuariosHelper

    Public Shared Function listar_Usuarios(ByVal valor As String) As List(Of Usuarios)
        Dim sql As String
        Dim cadena As String = ConfigurationManager.AppSettings("cadenaConexion")

        sql = "select * from usuarios "
        Dim objDS As DataSet = New DataSet()
        Try
            If Len(valor) > 0 Then 'añadimos el filtro
                sql += "where login like '%" & valor & "%'"
            End If
            objDS = SqlHelper.ExecuteDataset(cadena, Data.CommandType.Text, sql)
            Dim lista_usuarios As List(Of Usuarios) = New List(Of Usuarios)
            If objDS.Tables(0).Rows.Count > 0 Then
                Dim fila_usuario As DataRow
                Dim i As Integer = 0
                For Each fila_usuario In objDS.Tables(0).Rows
                    lista_usuarios.Add(New Usuarios(objDS.Tables(0).Rows(i)("login").ToString))
                    'lista_usuarios.Add(New Usuarios(objDS.Tables(0).Rows(i)("login").ToString), objDS.Tables(0).Rows(i)("password").ToString, objDS.Tables(0).Rows(i)("nombre").ToString, objDS.Tables(0).Rows(i)("apellido").ToString, objDS.Tables(0).Rows(i)("dni").ToString, objDS.Tables(0).Rows(i)("telefono").ToString))
                    i += 1
                Next
                If Len(valor) > 0 Then
                    LogErrorHelper.escribir_log(HttpContext.Current.Session("usuario").ToString(), Date.Now(), "Función de buscar en clase usuario", "El usuario ha buscado un registro y lo ha encontrado", 3)
                End If
                Return lista_usuarios
            Else
                LogErrorHelper.escribir_log(HttpContext.Current.Session("usuario").ToString(), Date.Now(), "Función de buscar en clase usuario", "La función de busqueda no ha devuelto ningun registro.", 3)
            End If
        Catch ex As Exception
            LogErrorHelper.escribir_log(HttpContext.Current.Session("usuario").ToString(), Date.Now(), "Error: Función de buscar" + " *SQL: " + sql, "El usuario ha buscado en blanco", 1)
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
