<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="ProjekLab.Views.TransactionDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Transaction Detail</h3>
    <div>
        <asp:Label Text="txtShowName" ID="lblShowName" runat="server" />
        <br />
        <asp:Label Text="txtShowAvarageRating" ID="lblShowAvarageRating" runat="server" />
        <br />
        <asp:Label Text="txtShowDescription" ID="lblShowDescription" runat="server" />
        <br />
        <asp:Label Text="" ID="lblToken" runat="server" />
        <br />
    </div>
    <div>
        <asp:GridView ID="gvToken" runat="server" AutoGenerateColumns="false"   >
            <Columns>
                <asp:BoundField DataField="Token" HeaderText="Unused Token" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
     <div>
        <asp:GridView ID="gvToken2" runat="server" AutoGenerateColumns="false"   >
            <Columns>
                <asp:BoundField DataField="Token" HeaderText="Used Token" />
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:Label Text="" ID="lblerror" runat="server" />
    </div>

     
    <asp:Button Text="Cancel" ID="btnCancel" OnClick="btnCancel_Click" runat="server" />
    
</asp:Content>
