<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="ItayProject.WebPages.registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/styles.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="registration-form">
                <h1>Join FitHubOnline</h1>
            <p>Create your account and start your fitness journey.</p>
            <div action="index.aspx">
                <div class="input-container">
                    <input id="firstName" type="text" placeholder="First Name" runat="server" />
                    <input id="lastName" type="text" placeholder="Last Name" runat="server">
                </div>
                <div class="input-container">
                    <input id="email" type="email" placeholder="Email" runat="server">
                    <input id="phone" type="tel" placeholder="Phone" runat="server">
                </div>
                <div class="input-container">
                    <input id="userName" type="text" placeholder="Username" runat="server" />
                    <input id="password" type="password" placeholder="password" runat="server">
                </div>
                <div class="input-container">
                    <label for="gender">Gender:</label>
                    <select id="gender" name="gender">
                        <option value="male">Male</option>
                        <option value="female">Female</option>
                        <option value="other">Other</option>
                    </select>
                </div>
                <input class="cta-button" type="submit" name="submit" id="submit" onclick="validateForm()" runat="server" OnServerClick="Submit_Click" />
                <div class="red" runat="server" id="message">

                </div>
            </div>
        </div>
</asp:Content>
