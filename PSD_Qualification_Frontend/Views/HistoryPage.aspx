<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Header.Master" AutoEventWireup="true" CodeBehind="HistoryPage.aspx.cs" Inherits="PSD_Qualification_Frontend.Views.HistoryPage" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>History Page</h1>

    <%--<asp:GridView ID="GVTransactions" runat="server">
    </asp:GridView>--%>

    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />

    <hr />

    <asp:Label ID="TotalPriceLbl" runat="server" Text="Label"></asp:Label>

</asp:Content>
