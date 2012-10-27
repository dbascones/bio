<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="index.aspx.vb" Inherits="login.vb.index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  

   
    <br />
    <div>
    <table align="center" border="0" style="width: 208px; height: 91px;">
            <tr>
            <td  style="text-align: right">       
                <asp:Label ID="Label1" runat="server" Text="Usuario" 
                    style="font-weight: 700; font-family: Verdana; font-size: small"></asp:Label>                
           </td>
            <td>
                <table>
                <tr>
                   <td><asp:TextBox ID="txtNombre" runat="server" Width="80px"></asp:TextBox></td>
                  <td><asp:RequiredFieldValidator ID="vldUsuarioRequerido" runat="server" 
                        ControlToValidate="txtNombre" Display="Dynamic" 
                        ErrorMessage="Usuario en blanco. Debe introducir usuario" ForeColor="Red"></asp:RequiredFieldValidator></td>                                            
              </tr> 
                </table>
            </td> 
            </tr>                
            <tr>              
               <td style="text-align: right">
                    <asp:Label ID="Label2" runat="server" Text="Contraseña"                         
                        style="font-weight: 700; font-family: Verdana; font-size: small; text-align: left;"></asp:Label>
                </td>
                <td>
                    <table>
                    <tr>
                      <td><asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="80px"></asp:TextBox> </td>
                        <td><asp:RequiredFieldValidator ID="vldPwdRequerido" runat="server" 
                        ControlToValidate="txtPwd" ErrorMessage="Contraseña en blanco. Debe introducir contraseña" 
                                style="text-align: left" ForeColor="Red"></asp:RequiredFieldValidator></td>                                                       
                        <td> <asp:CustomValidator ID="CustomValidator1" runat="server" ForeColor="Red" ControlToValidate="txtPwd" OnServerValidate="pass" Display ="Dynamic" ErrorMessage="La contraseña debe de tener como máximo 8 caracteres."></asp:CustomValidator> </td>
                    </tr> 
                   </table> 
                 </td> 
            </tr> 
            <tr> 
               <td colspan="2"> <asp:LinkButton ID="boton_aceptar" runat="server">
                        <asp:Image ID="Image1" runat="server" ToolTip="Entrar" AlternateText="Entrar" ImageUrl="~/imagenes/accept.ico" ImageAlign="Middle" BorderStyle="None" />
                    </asp:LinkButton>
               </td> 
            </tr>
      </table>
   </div> 
   <table align="center">
    <tr> 
      <td> <asp:Label ID="lblError" runat="server" style="font-family: Verdana; font-weight: 700; font-size: x-small;" 
                        Font-Names="Verdana" ForeColor="Red" Visible="false"></asp:Label>
      </td>
    </tr> 
   </table>    
    
                         </asp:Content>
