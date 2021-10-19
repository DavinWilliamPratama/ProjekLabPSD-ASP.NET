<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="UpdateProfilePage.aspx.cs" Inherits="ProjekLab.Views.UpdateProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Update Profile</h3>
    <div>
        <asp:Label Text="txtUsername" ID="lblUsername" runat="server" />
        <br />
        <asp:Label Text="txtName" ID="lblNameOld" runat="server" />
        <br />
        <asp:Label Text="txtRole" ID="lblRole" runat="server" />
        <br />
    </div>
    <br />
    <div>
        <asp:Label Text="Name:" ID="lblName" runat="server" />
        <br />
        <asp:TextBox Id="txtName" runat="server" />
    </div>
    <br />
    <div>
        <asp:Label Text="Old Password:" ID="lblOldPassword" runat="server" />
        <br />
        <asp:TextBox ID="txtOldPassword" TextMode="Password" runat="server" />
        <br />
        <asp:Label Text="New Password:" ID="lblNewPassword" runat="server" />
        <br />
        <asp:TextBox ID="txtNewPassword" TextMode="Password" runat="server" />
        <br />
        <asp:Label Text="Confirm Password:" ID="lblConfirmPassword" runat="server" />
        <br />
        <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" />
    </div>
    <br />
    <div>
        <asp:Label Text="" ID="lblError" runat="server" />
    </div>
    <div>
        <asp:Button Text="Update Profile" ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" />
    </div>
</asp:Content>
