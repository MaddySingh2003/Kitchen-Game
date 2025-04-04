using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKObj : KitchneObj
{[SerializeField] private List<KitchenObjects> validKitechenObjList;
public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
public class OnIngredientAddedEventArgs: EventArgs{
    public KitchenObjects kitchenObjects;
}
    private  List<KitchenObjects> kitchenObjectsList;
private void Awake(){
    kitchenObjectsList=new List<KitchenObjects>();
}
public bool TryAddIngredient (KitchenObjects kitchenObjects){
    if(!validKitechenObjList.Contains(kitchenObjects)){
        {return false;}
    }
    if(kitchenObjectsList.Contains(kitchenObjects)){
return false;
    }else{

kitchenObjectsList.Add(kitchenObjects);
OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs{
kitchenObjects=kitchenObjects
});
return true;
}}
public List<KitchenObjects> GetKitchenObjectsList(){
    return kitchenObjectsList;
}
}
