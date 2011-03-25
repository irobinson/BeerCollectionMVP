<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BeersToDrinkSoonSettings.ascx.cs" Inherits="BeerCollection.BeersToDrinkSoonSettings" %>
<script src="/DesktopModules/BeerCollection/Resources/js/codemirror/codemirror.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/DesktopModules/BeerCollection/Resources/css/linenumbers.css" />
<asp:TextBox runat="server" TextMode="MultiLine" ID="TemplateTextBox" />
<script type="text/javascript">
    var editor = CodeMirror.fromTextArea('<%= TemplateTextBox.ClientID %>', {
        height: 'dynamic',
        width: "700px",
        parserfile: "parsexml.js",
        stylesheet: "/DesktopModules/BeerCollection/Resources/css/xmlcolors.css",
        path: "/DesktopModules/BeerCollection/Resources/js/codemirror/",
        lineNumbers: true
    });

    $(document).ready(function () {
        $('a.CommandButton').click(function (e) {
            editor.save();
        });
    });

</script>
<p></p>
<p>Data from both the collection of beer and that of the current user are available for use through tokens. Here are some examples of how you can use it.</p>
<p>To show the list of beers you can do the following:</p>
<p>To define the start of the list do the following:<strong>$beer:{ b |</strong><br />
You can show any beer data in here by using a token. For example <strong>$b.Name$</strong><br />
To close the list, use <strong>}$</strong>.
</p>
<strong>Beer (in the collection)</strong>
<ul>
    <li>$b.BeerId$</li>
    <li>$b.Name$</li>
    <li>$b.Description$</li>
    <li>$b.Picture$</li>
    <li>$b.AlcoholPercentageByVolume$</li>
    <li>$b.DrinkBy$</li>
    <li>$b.IsConsumed$</li>
</ul>

<strong>User (The current user)</strong>
<ul>
    <li>$BeerId$</li>
    <li>$Name$</li>
    <li>$Description$</li>
    <li>$Picture$</li>
    <li>$AlcoholPercentageByVolume$</li>
    <li>$DrinkBy$</li>
    <li>$IsConsumed$</li>
</ul>