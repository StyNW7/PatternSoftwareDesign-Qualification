<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Header.Master" AutoEventWireup="true" CodeBehind="UpdateMeowPage.aspx.cs" Inherits="PSD_Qualification_Frontend.Views.UpdateMeowPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Update Meow Page</h1>

    <div>

        <asp:Label ID="LblId" runat="server" Text="ID: "></asp:Label>
        <asp:TextBox ID="TxtId" runat="server" ReadOnly="true"></asp:TextBox>

    </div>

    <div>

        <asp:Label ID="LblName" runat="server" Text="Meow Name: "></asp:Label>
        <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>

    </div>

    <div>

        <asp:Label ID="LblSkin" runat="server" Text="Meow Skin: "></asp:Label>
        <asp:TextBox ID="TxtSkin" runat="server"></asp:TextBox>

    </div>

    <div>

        <asp:Label ID="LblAge" runat="server" Text="Meow Age: "></asp:Label>
        <asp:TextBox ID="TxtAge" runat="server"></asp:TextBox>

    </div>

    <div>

        <asp:Label ID="LblPrice" runat="server" Text="Meow Price: "></asp:Label>
        <asp:TextBox ID="TxtPrice" runat="server" TextMode="Number"></asp:TextBox>

    </div>

    <div>
        <asp:Button ID="BtnUpdate" runat="server" Text="Update Meow!"
            OnClick="BtnUpdate_Click" />
    </div>

</asp:Content>
