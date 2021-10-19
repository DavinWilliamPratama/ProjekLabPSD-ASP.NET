<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="ProjekLab.Views.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Register Page</h3>

    <div>
        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
        <br />
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        
        <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
        <br />
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <br />
        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
        <br />
        <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
        <br />
    
        <asp:Label ID="lblRoles" runat="server" Text="Roles"></asp:Label>
        <br />
            <asp:DropDownList ID="ddlRole" runat="server">
                <asp:ListItem Text="Seller" />
                <asp:ListItem Text="Member" />
            </asp:DropDownList>
    </div>
    <div>
        <asp:Label Text="" ID="lblError" ForeColor="Red" runat="server" />
    </div>
    <div>
         <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
    </div>
</asp:Content>
