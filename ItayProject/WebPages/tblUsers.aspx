<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="tblUsers.aspx.cs" Inherits="ItayProject.WebPages.tblUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        Enter Text to search name:
        <input type="text" name="filter" id="filter" />
            <br /> <br />
            <input type="button" name="btnFilter" id="btnFilter" runat="server" onserverclick="Click_Filter" />
            <br /> <br />
        Delete:
        <input type="button" name="btnDelete" runat="server" onserverclick="Delete" />
        </div>
    <div runat="server" id="tableDiv">
    </div>
</asp:Content>
