<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BeerCollection.ascx.cs" Inherits="BeerCollection.ViewBeerCollection" %>

<asp:Repeater DataSource='<%# Model.BeerCollection %>' runat="server">
    <ItemTemplate>
        <div class="beer">
            <span class="name"><%# DataBinder.Eval(Container.DataItem,"Name") %></span>
            <span class="abv"><%# DataBinder.Eval(Container.DataItem, "AlcoholPercentageByVolume")%></span>
        </div>    
    </ItemTemplate>
</asp:Repeater>