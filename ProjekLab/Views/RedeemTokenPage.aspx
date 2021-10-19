<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="RedeemTokenPage.aspx.cs" Inherits="ProjekLab.Views.RedeemTokenPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Redeem Token</h3>
    
    <div>
        <asp:Label ID="lblRedeem" runat="server" Text="Redeem Token"></asp:Label>
        <br />
        <asp:TextBox ID="txtRedeem" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label Text="" ID="lblError" ForeColor="Red" runat="server" />
    </div>
    <div>
        <asp:Button Text="Submit" ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" />
    </div>
</asp:Content>
