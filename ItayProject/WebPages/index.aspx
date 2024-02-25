<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ItayProject.WebPages.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero">
            <h1>Welcome to FitHubOnline</h1>
            <p>Your Gateway to a Healthy Lifestyle</p>
            <a href="registration.aspx" class="cta-button">Get Started</a>
     </div>
</asp:Content>
