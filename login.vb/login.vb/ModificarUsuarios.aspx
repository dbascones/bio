<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="ModificarUsuarios.aspx.vb" Inherits="login.vb.ModificarUsuarios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   <script language="javascript" type="text/javascript" src="js/jquery-1.6.4.js"></script>
   <script type="text/javascript">
   
      function actualizarCombo() {

          var valorActual = document.getElementById('<%= ddlAdministrador.ClientID %>').options[document.getElementById('<%= ddlAdministrador.ClientID %>').selectedIndex].value;
          var valorLogin = document.getElementById('<%=txtLogin.ClientID%>').value
      
       $.ajax({
               type: "POST",
               url: "Actualizarcombo.aspx",
               data: 'valorActual=' + valorActual + '&valorLogin=' + valorLogin,
               success: msg,
               error: msg2
           });
       }

       function msg() {
           var t = "Actualizado";
          // alert(t);
           var msg3 = t;
           // document.write("Actualizado");
       }

       function msg2() {
           var f = "Error";
          // alert(f);
           var msg3 = f;
          // document.write("Error");
       }

      // var res = msg;


       function actualizarComboBloqueo() {

           var valorActual = document.getElementById('<%= ddlBloqueado.ClientID %>').options[document.getElementById('<%= ddlBloqueado.ClientID %>').selectedIndex].value;
           var valorLogin = document.getElementById('<%=txtLogin.ClientID%>').value

           $.ajax({
               type: "POST",
               url: "ActualizarcomboBloqueo.aspx",
               data: 'valorActual=' + valorActual + '&valorLogin=' + valorLogin
          });
       }
   </script>

    <br />
    <div>
    <br /><br />
    <table align="center" border="0">
        <tr>
            <td colspan="6" align="center">
                <asp:Label ID="Label1" runat="server" Text="MODIFICAR USUARIO" style="font-family:Verdana; font-weight:bold"></asp:Label>
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
            <td style="width: 260px">
                <asp:TextBox ID="txtRepPass" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Nombre: " 
                    style="font-family:Verdana; font-size:small; font-weight:bold"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Apellidos: " 
                    style="font-family:Verdana; font-size:small; font-weight:bold"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label  ID="lblAdministrador" runat="server" Text="Administrador: " style="font-family:Verdana; font-size:small; font-weight:bold"></asp:Label>
            </td>
            <td>
             <asp:DropDownList ID="ddlAdministrador" runat="server" onChange="actualizarCombo()">
                    <asp:ListItem Text="NO" Value="0"></asp:ListItem>
                    <asp:ListItem Text="SI" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
         </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Dni: " 
                    style="font-family:Verdana; font-size:small; font-weight:bold"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Teléfono: " 
                    style="font-family:Verdana; font-size:small; font-weight:bold"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            </td>
            <%--<td>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo puede contener números" ControlToValidate="txtTelefono" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            </td>--%>
            <td>
                <asp:Label  ID="lblBloqueado" runat="server" Text="Bloqueado: " style="font-family:Verdana; font-size:small; font-weight:bold"></asp:Label>
            </td>
            <td style="width: 260px">
                <asp:DropDownList   ID="ddlBloqueado" runat="server" onChange="actualizarComboBloqueo()">
                    <asp:ListItem Text="NO" Value="0"></asp:ListItem>
                    <asp:ListItem Text="SI" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td></td><td></td><td></td>
            <td>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo puede contener números" ControlToValidate="txtTelefono" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="6">
            <br />
                <asp:Button ID="btnModificar" ToolTip="Modificar" runat="server" Text="Modificar" />
                <asp:Button ID="Button1" ToolTip="Volver" runat="server" Text="Volver" PostBackUrl="~/ListadoUsuarios.aspx" />
            <br />
            <br />
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
