<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registation.aspx.cs" Inherits="FioreStore.Registation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>Registration form with Validation</center>

           
            <table>
                <tr>
                    <td>First Name</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                       <asp:RequiredFieldValidator ControlToValidate="TextBox1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="First name is empty "></asp:RequiredFieldValidator>                        
                    </td>
                </tr>	
                <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>                       
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last name is empty" ControlToValidate="TextBox2"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>Email Id</td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" TextMode="Email"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email Id" ControlToValidate="TextBox3"></asp:RegularExpressionValidator> </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Password is blank" ControlToValidate="TextBox4"></asp:RequiredFieldValidator></td>
                        
                       
                </tr>
                 <tr>
                    <td>Re-Type Password</td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Re-Type password is blank" ControlToValidate="TextBox7"></asp:RequiredFieldValidator></td>
                 
                </tr>
                    <tr>
                    <td>Age</td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter age" ControlToValidate="TextBox6"></asp:RequiredFieldValidator></td>
                </tr>
                    <tr>
                    <td>Mobile Number</td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Mobile Numer is empty" ControlToValidate="TextBox7"></asp:RequiredFieldValidator></td>
                </tr>
                
              <tr>
                 <td>User Id</td>
                  <td>
                      <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="User id is empty" ControlToValidate="TextBox8"></asp:RequiredFieldValidator></td>
              </tr>

                  <tr>
                 <td></td>
                  <td></td>
             </tr>


                  <tr>
                 <td></td>
                  <td>
                      <asp:Button ID="Button1" runat="server" Text="Login" /></td>
             </tr>




            </table>

        </div>
    </form>
</body>
</html>
