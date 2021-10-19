<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="ShowDetailPage.aspx.cs" Inherits="ProjekLab.Views.ShowDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3> Detail </h3>
    <div>
        <asp:Label Text="txtShowName" ID="txtShowName" runat="server" />
        <br />
        <asp:Label Text="txtShowPrice" ID="txtShowPrice" runat="server" />
        <br />
        <asp:Label Text="txtSellerName" ID="txtSellerName" runat="server" />
        <br />
        <asp:Label Text="txtShowDescription" ID="txtShowDescription" runat="server" />
        <br />
        <asp:Label Text="txtShowAvarageRating" ID="txtShowAvarageRating" runat="server" />
    </div>
    <br />
    <h3>Review</h3>
    <div>
        <asp:GridView ID="gvReview" AutoGenerateColumns="False" runat="server">
            <Columns>
                <asp:BoundField DataField="Rating" HeaderText="Rating" SortExpression="Rating" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <br />
        <asp:Button Text="Update Show" ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" />
        <asp:Button Text="Order Now" ID="btnOrder" OnClick="btnOrder_Click" runat="server" />
    </div>

</asp:Content>
