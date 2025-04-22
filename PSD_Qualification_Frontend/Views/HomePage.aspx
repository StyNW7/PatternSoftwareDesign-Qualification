<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Header.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="PSD_Qualification_Frontend.Views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Home Page</h1>

    <asp:GridView ID="GVMeow" runat="server" AutoGenerateColumns="False"
        OnRowDeleting="GVMeow_RowDeleting" OnRowEditing="GVMeow_RowEditing" OnRowCommand="GVMeow_RowCommand">

        <Columns>

            <asp:BoundField DataField="Id" HeaderText="Meow ID" SortExpression="Id" />
            <asp:BoundField DataField="Name" HeaderText="Meow Name" SortExpression="Name" />
            <asp:BoundField DataField="Skin" HeaderText="Meow Skin" SortExpression="Skin" />
            <asp:BoundField DataField="Age" HeaderText="Meow Age" SortExpression="Age" />
            <asp:BoundField DataField="Price" HeaderText="Meow Price" SortExpression="Price" />

            <asp:TemplateField HeaderText="Actions" Visible="false">

                <ItemTemplate>
                    <asp:Button ID="BtnEdit" runat="server" Text="Edit" UseSubmitBehavior="false" CommandName="Edit" />
                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" UseSubmitBehavior="false" CommandName="Delete" />
                </ItemTemplate>

            </asp:TemplateField>


            <asp:TemplateField HeaderText="Actions" Visible="false">
                <ItemTemplate>
                    <asp:Button ID="BtnBuy" runat="server" Text="Buy" UseSubmitBehavior="false" CommandName="Buy" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

    <asp:Panel ID="PanelInsert" runat="server" Visible="false">

        <h2>Insert Meow</h2>

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
            <asp:Button ID="BtnInsert" runat="server" Text="NewmeoW!" OnClick="BtnInsert_Click" />
        </div>

    </asp:Panel>

</asp:Content>
