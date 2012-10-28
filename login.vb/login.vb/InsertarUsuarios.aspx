<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="InsertarUsuarios.aspx.vb" Inherits="login.vb.InsertarUsuarios" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
 
    <div>
    <br /><br />
    <table align="center" border="0">
        <tr>
            <td colspan="6" align="center">
                <asp:Label ID="Label1" runat="server" Text="NUEVO USUARIO" style="font-family:Verdana; font-weight:bold"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Login: " 
                    style="font-family:Verdana; font-size:small; font-weight:bold"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
            </td>
            <%--<td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLogin" ErrorMessage="Falta de rellenar"></asp:RequiredFieldValidator>
            </td>--%>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Password: " 
                    style="font-family:Verdana; font-size:small; font-weight:bold"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Repetir password: " style="font-family:Verdana; font-size:small; font-weight:bold"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRepPass" runat="server"></asp:TextBox>
            </td>
            <%--<td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Falta de rellenar"></asp:RequiredFieldValidator>
            </td>--%>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Nombre: " 
                    style="font-family:Verdana; font-size:small; font-weight:bold"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </td>
            <%--<td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNombre" ErrorMessage="Falta de rellenar"></asp:RequiredFieldValidator>
            </td>--%>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Apellidos: " 
                    style="font-family:Verdana; font-size:small; font-weight:bold"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label Visible="false" ID="lblAdministrador" runat="server" Text="Administrador: " style="font-family:Verdana; font-size:small; font-weight:bold"></asp:Label>
            </td>
            <td>
                <asp:DropDownList Visible="false" ID="ddAdministrador" runat="server">
                     <asp:ListItem>NO</asp:ListItem>
                     <asp:ListItem>SI</asp:ListItem>
                </asp:DropDownList>
            </td>
            <%--<td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtApellido" runat="server" ErrorMessage="Falta de rellenar"></asp:RequiredFieldValidator>
            </td>--%>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Dni: " 
                    style="font-family:Verdana; font-size:small; font-weight:bold"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
            </td>
            <%--<td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDni" ErrorMessage="Falta de rellenar"></asp:RequiredFieldValidator>
            </td>--%>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Teléfono: " 
                    style="font-family:Verdana; font-size:small; font-weight:bold"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            </td>
            <%--<td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="Solo puede contener números" ControlToValidate="txtTelefono" 
                    ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>--%>
            <td>
                <asp:Label Visible="false" ID="lblbloqueado" runat="server" Text="Bloqueado: " style="font-family:Verdana; font-size:small; font-weight:bold"></asp:Label>
            </td>
            <td>
                <asp:DropDownList Visible="false" ID="ddBloqueado" runat="server">
                     <asp:ListItem>NO</asp:ListItem>
                     <asp:ListItem>SI</asp:ListItem>       
                </asp:DropDownList>
            </td>
            <%--<td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Falta de rellenar"></asp:RequiredFieldValidator>
            </td>--%>
        </tr>
        <tr>
        <td></td><td></td><td></td>
         <td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="Solo puede contener números" ControlToValidate="txtTelefono" 
                    ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="6">
            <br />
                <asp:Button ID="btnAñadir" ToolTip="Añadir" runat="server" Text="Añadir" />
                &nbsp;&nbsp;
                <asp:Button ID="Button1" ToolTip="Volver" runat="server" Text="Volver" PostBackUrl="~/ListadoUsuarios.aspx" />
            <br />
            <br />
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    </div>

</asp:Content>
