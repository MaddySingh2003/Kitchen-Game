using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter{
    [SerializeField] private KitchenObjects kitchenObjects;

    public override void Interact(Player player)
    {
      if(HasKitchenObj()){
        if(player.HasKitchenObj()){
if(player.GetKitchenObj().TryGetPlate( out PlateKObj plateKObj)){

 if( plateKObj.TryAddIngredient(GetKitchenObj().GetKitchenObjects())){
  GetKitchenObj().DestroyObj();
}
}else{
  if(GetKitchenObj().TryGetPlate(out  plateKObj)){
  if ( plateKObj.TryAddIngredient(player.GetKitchenObj().GetKitchenObjects())){
      player.GetKitchenObj().DestroyObj();
  }  }
}
        }else{
            GetKitchenObj().SetKitchObjParent(player);
        }

      }else{
       if( player.HasKitchenObj()){
        player.GetKitchenObj().SetKitchObjParent(this);
       }
      }
    }
}

