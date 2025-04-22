<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="PSD_Qualification_Frontend.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NewmeoW</title>
</head>
<body>
    <form id="form1" runat="server">
        
        <h1>Register Page</h1>

        <div>

            <asp:Label ID="LblEmail" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>

        </div>

        <div>

            <asp:Label ID="LblName" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>

        </div>

        <div>
            <asp:Label ID="LblPassword" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="LblError" runat="server" Text=" "></asp:Label>
        </div>

        <div>
            <asp:Button ID="BtnRegister" runat="server" Text="Register" OnClick="BtnRegister_Click" />
        </div>

        <div>
            <asp:LinkButton ID="LBLogin" runat="server" OnClick="LBLogin_Click">Already have an account? Login Here!</asp:LinkButton>
        </div>

    </form>
</body>
</html>
