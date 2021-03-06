<p>$if(user)$$user.DisplayName$'s$else$The$endif$ Beer Collection</p>
<table class="beer-collection">
  <thead>
    <tr>
      <th>Beer Name</th>
      <th>Style</th>
      <th>Brewery</th>
      <th>Description</th>
      <th>ABV</th>
      <th>Drink By</th>
      <th>Picture</th>
    </tr>
  </thead>
  <tbody>  
    $beer:{ b |
    <tr>
      <td>$b.Name$</td>
      <td>$b.Style$</td>
      <td>$b.Brewery$</td>
      <td>$b.Description$</td>
      <td>$b.AlcoholPercentageByVolume$</td>
      <td class="date">$b.DrinkBy;format="MMM dd, yyyy"$</td>
      <td>
        $link(href={#$b.Picture$},title="$b.Name$",text="View")$
      </td>
    </tr>
    }$
  </tbody>
  <tfoot>
    <tr>
      <td colspan="7">* $user.FirstName$ has only been drinking beer since $user.Membership.CreatedDate;format="MMM dd, yyyy"$!</td>
    </tr>
  </tfoot>
</table>