<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="UpdateShowPage.aspx.cs" Inherits="ProjekLab.Views.UpdateShowPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3> Update Show </h3>
    <div>
        <asp:Label Text="txtShowName" ID="txtShowName" runat="server" />
        <br />
        <asp:Label Text="txtShowPrice" ID="txtShowPrice" runat="server" />
        <br />
        <asp:Label Text="txtSellerName" ID="txtSellerName" runat="server" />
        <br />
        <asp:Label Text="txtShowDescription" ID="txtShowDescription" runat="server" />
        <br />
    </div>
    <br />
    <div>
        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
        <br />
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

    </div>
    <div>
        <asp:Label ID="lblUrl" runat="server" Text="URL"></asp:Label>
        <br />
        <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegexUrl" runat="server" ErrorMessage="Invalid URL!" ControlToValidate="txtUrl" ValidationExpression="^(((ht|f)tp(s?))\://)?(www.|[a-zA-Z].)[a-zA-Z0-9\-\.]+\.(com|edu|gov|mil|net|org|biz|info|name|museum|us|ca|uk|id|ac.id)(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\;\?\'\\\+&amp;%\$#\=~_\-]+))*$"></asp:RegularExpressionValidator>
    </div>

    <div>
        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
        <br />
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
        <br />
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <br />
        <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" Text="Update" />
    </div>

    
</asp:Content>
