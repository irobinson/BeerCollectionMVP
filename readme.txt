This is a sample application used to demonstrate concepts outlined in my presentation. Please review the slide deck PDF and also let me know if you would like to discuss. Find my contact info in the slide deck or ping me on twitter @irobinson.

Here are the web.config entries needed to wire up the HttpModule which registers our repository with the DNN IOC Container.

<system.webServer>
	<modules>
		<add name="BeerCollectionModule" type="BeerCollection.HttpModules.BeerCollectionModule, BeerCollection" preCondition="managedHandler" />
	</modules>
</system.webServer>

<system.web>
	<httpModules>
		<add name="BeerCollectionModule" type="BeerCollection.HttpModules.BeerCollectionModule, BeerCollection" />
	</httpModules>
</system.web>