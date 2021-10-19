<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="TransactionPage.aspx.cs" Inherits="ProjekLab.Views.TransactionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Transaction</h3>
    <div>
        <asp:GridView ID="gvShowOrder" AutoGenerateColumns="False" runat="server" OnRowCommand="gvShowOrder_RowCommand" >
            <Columns>
                <asp:BoundField DataField="CreatedAt" HeaderText="PaymentDate" SortExpression="CreatedAt"/>
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Name" />
                <asp:BoundField DataField="ShowTime" HeaderText="Time" SortExpression="ShowTime" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="TotalPrice" HeaderText="TotalPrice" SortExpression="TotalPrice" />
                <asp:ButtonField ButtonType="Button" HeaderText="Action" Text="Select Transaction" CommandName="btnSelect" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
