<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="ListadoUsuarios.aspx.vb" Inherits="login.vb.ListadoUsuarios" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
<br />
    <div align="right">
    </div>
    <br />
    <div align="left">
         <asp:Label ID="lblBuscar" runat="server" Text="Búsqueda por login: "></asp:Label>
         <asp:TextBox  ID="txtBuscar" runat="server"></asp:TextBox>
         <asp:Button ID="btnBuscar" runat="server" ToolTip="Bucar" Text="Buscar" />
         <asp:Button ID="btnNuevoUsuario" runat="server" Text="Nuevo Usuario" 
                         PostBackUrl="~/InsertarUsuarios.aspx" ToolTip="Nuevo Usuario" />
    </div>
    <br /><br />
    <div align="center">
        <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" 
            style="margin-left: 0px">
          <%--  <AlternatingItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="loginLabel" runat="server" Text='<%# Eval("login") %>' />
                    </td>
                    <td>
                        <asp:Label ID="passwordLabel" runat="server" Text='<%# Eval("password") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nombreLabel" runat="server" Text='<%# Eval("nombre") %>' />
                    </td>
                    <td>
                        <asp:Label ID="apellidoLabel" runat="server" Text='<%# Eval("apellido") %>' />
                    </td>
                    <td>
                        <asp:Label ID="dniLabel" runat="server" Text='<%# Eval("dni") %>' />
                    </td>
                    <td>
                        <asp:Label ID="telefonoLabel" runat="server" Text='<%# Eval("telefono") %>' />
                    </td>
                     <td>
                        <asp:LinkButton ID="btnDelete" runat="server" OnClick="Eliminar" CommandArgument='<%#Eval("login")%>'>
                         <asp:Image ID="Image2" Width="10" ToolTip="Eliminar" runat="server" AlternateText="Entrar" ImageUrl="~/imagenes/delete.ico" ImageAlign="Middle" BorderStyle="None" />
                        </asp:LinkButton>
                    </td>
                     <td>
                        <asp:LinkButton ID="btnEdit" runat="server" OnClick="Modificar" CommandArgument='<%#Eval("login")%>'>
                         <asp:Image ID="Image3" Width="10" runat="server" ToolTip="Editar" AlternateText="Entrar" ImageUrl="~/imagenes/pencil.ico" ImageAlign="Middle" BorderStyle="None" />
                        </asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>--%>
            <%--<EditItemTemplate>
                <tr>
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                            Text="Actualizar" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                            Text="Cancelar" />
                    </td>
                    <td>
                        <asp:Label ID="loginLabel1" runat="server" Text='<%# Eval("login") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="passwordTextBox" runat="server" 
                            Text='<%# Bind("password") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="nombreTextBox" runat="server" Text='<%# Bind("nombre") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="apellidoTextBox" runat="server" 
                            Text='<%# Bind("apellido") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="dniTextBox" runat="server" Text='<%# Bind("dni") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="telefonoTextBox" runat="server" 
                            Text='<%# Bind("telefono") %>' />
                    </td>
                </tr>
            </EditItemTemplate>--%>
            <EmptyDataTemplate>
                <table id="Table1" runat="server">
                    <tr>
                        <td>
                            No se han devuelto datos.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
<%--            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                            Text="Insertar" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                            Text="Borrar" />
                    </td>
                    <td>
                        <asp:TextBox ID="loginTextBox" runat="server" Text='<%# Bind("login") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="passwordTextBox" runat="server" 
                            Text='<%# Bind("password") %>' />
                    </td>
                    <td >
                        <asp:TextBox ID="nombreTextBox" runat="server" Text='<%# Bind("nombre") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="apellidoTextBox" runat="server" 
                            Text='<%# Bind("apellido") %>' />
                    </td>
                    <td >
                        <asp:TextBox ID="dniTextBox" runat="server" Text='<%# Bind("dni") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="telefonoTextBox" runat="server" 
                            Text='<%# Bind("telefono") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>--%>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="loginLabel" runat="server" Text='<%# Eval("login") %>' />
                    </td>
                    <td>
                        <asp:Label ID="passwordLabel" runat="server" Text='<%# Eval("password") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nombreLabel" runat="server" Text='<%# Eval("nombre") %>' />
                    </td>
                    <td>
                        <asp:Label ID="apellidoLabel" runat="server" Text='<%# Eval("apellido") %>' />
                    </td>
                    <td>
                        <asp:Label ID="dniLabel" runat="server" Text='<%# Eval("dni") %>' />
                    </td>
                    <td>
                        <asp:Label ID="telefonoLabel" runat="server" Text='<%# Eval("telefono") %>' />
                    </td>
                     <td>
                        <asp:LinkButton Visible="false" ID="btnDelete" runat="server" OnClick="Eliminar" CommandArgument='<%#Eval("login")%>'>
                         <asp:Image ID="Image2" Width="10" ToolTip="Eliminar" runat="server" AlternateText="Eliminar" ImageUrl="~/imagenes/delete.ico" ImageAlign="Middle" BorderStyle="None" />
                         </asp:LinkButton>
                    </td>
                     <td>
                        <asp:LinkButton visible="false" ID="btnEdit" runat="server" OnClick="Modificar" CommandArgument='<%#Eval("login")%>'>
                         <asp:Image ID="Image3" Width="10" ToolTip="Editar" runat="server" AlternateText="Editar" ImageUrl="~/imagenes/pencil.ico" ImageAlign="Middle" BorderStyle="None" />
                        </asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table id="Table2" runat="server">
                    <tr id="Tr1" runat="server">
                        <td id="Td1" runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr id="Tr2" runat="server" style="">
                                    <th id="Th1" runat="server">
                                        login</th>
                                    <th id="Th2" runat="server">
                                        password</th>
                                    <th id="Th3" runat="server">
                                        nombre</th>
                                    <th id="Th4" runat="server">
                                        apellido</th>
                                    <th id="Th5" runat="server">
                                        dni</th>
                                    <th id="Th6" runat="server">
                                        telefono</th>
                                </tr>
                                <tr ID="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="Tr3" runat="server">
                        <td id="Td2" runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server" PageSize="5">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                        ShowNextPageButton="false" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                        ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="loginLabel" runat="server" Text='<%# Eval("login") %>' />
                    </td>
                    <td>
                        <asp:Label ID="passwordLabel" runat="server" Text='<%# Eval("password") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nombreLabel" runat="server" Text='<%# Eval("nombre") %>' />
                    </td>
                    <td>
                        <asp:Label ID="apellidoLabel" runat="server" Text='<%# Eval("apellido") %>' />
                    </td>
                    <td>
                        <asp:Label ID="dniLabel" runat="server" Text='<%# Eval("dni") %>' />
                    </td>
                    <td>
                        <asp:Label ID="telefonoLabel" runat="server" Text='<%# Eval("telefono") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="listar_Usuarios" TypeName="login.vb.UsuariosHelper">
            <SelectParameters>
                <asp:SessionParameter Name="valor" SessionField="valor_Busqueda" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:PRUEBAS2ConnectionString %>" 
            SelectCommand="SELECT * FROM [Usuarios]">
        </asp:SqlDataSource>--%>
        <br />
       <%-- <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:PRUEBAS2ConnectionString2 %>" 
        SelectCommand="SELECT * FROM [Usuarios]">
        </asp:ObjectDataSource>--%>
    </div>
</asp:Content>
