using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{public event EventHandler OnPlayerHoldObj;
      [SerializeField] private KitchenObjects kitchenObjects;
 

   
   
            public override void Interact(Player player){
                if(!player.HasKitchenObj()){  
KitchneObj.SpawnKitchenObj(kitchenObjects,player);
          OnPlayerHoldObj?.Invoke(this,EventArgs.Empty);
            }
            }
        }
