$if(beers)$
<p>You should probably drink these soon!</p>
<ul class="beers-soon">
	$beers:{ b |
		<li>$b.Name$, (Drink by: $b.DrinkBy;format="MMM dd, yyyy"$)</li>
	}$
</ul>
$else$
<p>No beers in your collection really need to be consumed. Take this opportunity to sober up.</p>
$endif$