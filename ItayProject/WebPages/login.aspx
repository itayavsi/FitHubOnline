<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ItayProject.WebPages.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../css/styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="registration-form">
                <h1>Join FitHubOnline</h1>
            <p>Login to your account and contiune your fitness journey.</p>
            <div action="index.aspx">
                <div class="input-container">
                    <input id="userName" type="text" placeholder="Username" runat="server">
                    <input id="password" type="text" placeholder="Password" runat="server">
                </div>
                <input class="cta-button" type="submit" name="submit" id="submit"  runat="server" OnServerClick="Submit_Click" />
            </div>
        <div class="red" runat="server" id="message" >

        </div>
     </div>
</asp:Content>
