<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="ReviewPage.aspx.cs" Inherits="ProjekLab.Views.ReviewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Review Page</h3>

     <div>
        <asp:Label Text="txtShowName" ID="lblShowName" runat="server" />
        <br />
        <asp:Label Text="txtSellerName" ID="lblSellerName" runat="server" />
        <br />
        <asp:Label Text="txtShowDescription" ID="lblShowDescription" runat="server" />
        <br />
    </div>
    <div>
        <asp:Label Text="Rating: " ID="lblRating" runat="server" />
        <br />
        <asp:TextBox runat="server" TextMode="Number" ID="txtRating" />
    </div>
    <div>
        <asp:Label Text="Description: " ID="lblDesc"  runat="server" />
        <br />
        <asp:TextBox ID="txtDesc" runat="server" />
    </div>
    <div>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
    </div>

    <div>
        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
        <br />
    </div>
    
    <div>
         <asp:Button ID="btnRate" OnClick="btnRate_Click" runat="server" Text="Rate" />
    </div>

</asp:Content>
