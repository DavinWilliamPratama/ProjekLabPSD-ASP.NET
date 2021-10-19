<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ProjekLab.Views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3> Home </h3>
    <div>
        <asp:GridView ID="gvShow" AutoGenerateColumns="False" runat="server" OnRowCommand="gvShow_RowCommand" >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="" SortExpression="Id"/>
                <asp:BoundField DataField="Name" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="User.Name" HeaderText="Seller" SortExpression="Seller" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:ButtonField ButtonType="Button" HeaderText="Action" Text="Show Detail" CommandName="btnDetail" />
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>