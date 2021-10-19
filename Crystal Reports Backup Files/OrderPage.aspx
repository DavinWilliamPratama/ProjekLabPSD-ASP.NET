<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="ProjekLab.Views.OrderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Order Page</h3>
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

    <h4>Choose Date</h4>
    <div>
        <asp:ScriptManager ID="scriptManager1" runat="server" />
        <asp:UpdatePanel ID="updDate" runat="server" >
            <ContentTemplate>
                <asp:Calendar ID="calDate" runat="server" OnSelectionChanged="calDate_SelectionChanged"></asp:Calendar>
                <div>
                    <asp:label text="Date and time chosen: " ID="lblDate" runat="server" />
                    <br />
                    <asp:Label Text="" ID="lblDatePick" runat="server" />
                    <br />
                    <asp:label text="Enter Quantity: " ID="lblQty" runat="server" />
                    <br />
                    <asp:TextBox ID="txtQty" TextMode="Number" runat="server" />
                    <br />
                    <br />
                </div>
                <div>
                    <asp:GridView ID="gvSchedule" runat="server" AutoGenerateColumns="false"  OnRowCommand="gvSchedule_RowCommand1" OnRowDataBound="gvSchedule_RowDataBound" >
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="No." />
                            <asp:BoundField DataField="Time" HeaderText="Time" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <br />
                                    <asp:Button Text="Order" CommandName="btnOrder" ID="btnOrder" runat="server" CommandArgument='<%# Eval("Id") %>' />
                                </ItemTemplate>                
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="gvSchedule" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
                

    <asp:Label Text="" ID="lblError" runat="server" />
    

   

</asp:Content>
