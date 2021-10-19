<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="ManageShowPage.aspx.cs" Inherits="ProjekLab.Views.ManageShowPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Manage Product Page</h3>

    <div>
        <asp:GridView ID="gvProduct" runat="server"></asp:GridView>
    </div>

    <div>
        <asp:Label ID="lblID" Text="ID" runat="server" />
        <asp:TextBox ID="txtID" TextMode="Number" runat="server" />
    </div>

    <div>
        <asp:Label ID="lblName" Text="Name" runat="server" />
        <asp:TextBox ID="txtName" runat="server" />
    </div>

    <div>
        <asp:Label ID="lblPrice" Text="Price" runat="server" />
        <asp:TextBox ID="txtPrice" TextMode="Number" runat="server" />
    </div>

    <div>
        <asp:Label ID="lblDescription" Text="Description" runat="server" />
        <asp:TextBox ID="txtQty" TextMode="Multiline" runat="server" />
    </div>

    <div>
        <asp:Label ID="lblError" Text="" ForeColor="Red" runat="server" />
        <br />
        <asp:Button ID="btnInsert" Text="Insert" OnClick="btnInsert_Click" runat="server" />
        <asp:Button ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click" runat="server" />
        <asp:Button ID="btnDelete" Text="Delete" OnClick="btnDelete_Click" runat="server" />
        <br />
        <asp:LinkButton ID="linkHome" Text="Back to home page" OnClick="linkHome_Click" runat="server" />
    </div>
</asp:Content>
