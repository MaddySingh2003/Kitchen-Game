using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelivreyCounter : BaseCounter
{public static DelivreyCounter Instance{get;private set;}
private void Awake(){
  Instance=this;
}
  public override void  Interact(Player player){
if(player.HasKitchenObj()){
  if(player.GetKitchenObj().TryGetPlate(out PlateKObj plateKObj))
  { DeliveryManager.Instance.DeliverRecipe(plateKObj);
    player.GetKitchenObj().DestroyObj();
}
}
}
   
}
