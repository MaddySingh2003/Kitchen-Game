using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IKParent
{
  public static event EventHandler OnAnyObjPlacedHere;
    [SerializeField] private Transform counterTop;

   
    private KitchneObj kitchneObj;
  public  virtual  void Interact(Player player){
Debug.LogError("BaseCounte.Interact");
  }public  virtual  void InteractAlt(Player player){
//Debug.LogError("BaseCounte.Interact");
  }
              public Transform GetKitchenObjFollowTrans(){return counterTop;}
public void  SetKitchenObj(KitchneObj kitchneObj){
    this.kitchneObj=kitchneObj;
    if(kitchneObj!=null){
      OnAnyObjPlacedHere?.Invoke(this,EventArgs.Empty);
    }
}
public KitchneObj GetKitchenObj(){
return kitchneObj;
}
public void ClearKitchenobj(){
    kitchneObj=null;
}
public bool HasKitchenObj(){
    return kitchneObj!=null;
}
}
