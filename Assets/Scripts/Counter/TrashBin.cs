using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrashBin : BaseCounter
{
    public static event EventHandler OnAnyObjTrash;
    public override void Interact(Player player)
    {
       if(player.HasKitchenObj()){
        player.GetKitchenObj().DestroyObj();
        OnAnyObjTrash?.Invoke(this,EventArgs.Empty);
       }
    }
}
