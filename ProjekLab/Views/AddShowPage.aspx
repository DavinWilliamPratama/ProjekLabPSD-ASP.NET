<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="AddShowPage.aspx.cs" Inherits="ProjekLab.Views.AddShowPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Add Show Page</h3>
    <div>
        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblUrl" runat="server" Text="URL"></asp:Label>
        <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegexUrl" runat="server" ErrorMessage="Invalid URL!" ControlToValidate="txtUrl" ValidationExpression="^(((ht|f)tp(s?))\://)?(www.|[a-zA-Z].)[a-zA-Z0-9\-\.]+\.(com|edu|gov|mil|net|org|biz|info|name|museum|us|ca|uk|id)(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\;\?\'\\\+&amp;%\$#\=~_\-]+))*$"></asp:RegularExpressionValidator>
    </div>
    <div>
        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Button ID="btnInsert" OnClick="btnInsert_Click" runat="server" Text="Insert" />
    </div>

    <div>
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
