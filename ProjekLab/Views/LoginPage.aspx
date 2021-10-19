<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ProjekLab.Views.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Login Page</h3>
    <div>
        <asp:Label Text="Username"  runat="server" />
        <br />
        <asp:TextBox runat="server" ID="txtUsername" />
    </div>
    <div>
        <asp:Label Text="Password"  runat="server" />
        <br />
        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" />
    </div>
    <div>
        <asp:CheckBox Text="RememberMe" ID="chkRemember" runat="server" />
    </div>
    <div>
        <asp:Label Text="" ID="lblError" runat="server" />
    </div>
    <div>
        <asp:Button Text="Login" ID="btnLogin" runat="server" OnClick="btnLogin_Click" />
    </div>
</asp:Content>
