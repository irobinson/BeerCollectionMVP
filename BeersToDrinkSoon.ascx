<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BeersToDrinkSoon.ascx.cs" Inherits="BeerCollection.ViewBeersToDrinkSoon" %>

<% if (Model.HasBeers) { %>

    <asp:Repeater DataSource='<%# Model.BeerCollection %>' runat="server">
    <HeaderTemplate>
        <p>You should probably drink these soon!</p>
    </HeaderTemplate>
        <ItemTemplate>
            <p class="beers-soon">
                Name: <span class="name"><%# DataBinder.Eval(Container.DataItem,"Name") %></span><br />
                ABV: <span class="abv"><%# DataBinder.Eval(Container.DataItem, "AlcoholPercentageByVolume")%></span><br />
                Drink By: <span class="drinkby"><%# String.Format("{0:MM/dd/yyyy}", DataBinder.Eval(Container.DataItem, "DrinkBy")) %></span>
            </p>
        </ItemTemplate>
    </asp:Repeater>

<% } else { %>

    <p>No beers in your collection really need to be consumed. Take this opportunity to sober up.</p>

<% } %>