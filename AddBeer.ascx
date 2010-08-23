<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddBeer.ascx.cs" Inherits="BeerCollection.AddBeer" %>

<div>Beer Name: <asp:TextBox runat="server" ID="BeerNameTextBox"></asp:TextBox></div>
<div>ABV: <asp:TextBox runat="server" ID="BeerAbvTextBox"></asp:TextBox></div>
<div>Description: <asp:TextBox runat="server" ID="BeerDescriptionTextBox"></asp:TextBox></div>

<p><asp:Button runat="server" ID="SubmitButton" Text="Submit" /></p>