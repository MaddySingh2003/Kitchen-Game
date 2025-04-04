using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateComplete : MonoBehaviour
{
[SerializeField] private PlateKObj plateKObj;
[SerializeField] private List<KitchenObjects_GameObj> kitchenObjects_GameObjsList;
[Serializable] public struct KitchenObjects_GameObj{
    public KitchenObjects kitchenObjects;
    public GameObject gameObject;
}
private void Start(){
    plateKObj.OnIngredientAdded+=PlateKObj_OnAdded;
    foreach(KitchenObjects_GameObj kitchenObjects_GameObj in kitchenObjects_GameObjsList){
    kitchenObjects_GameObj.gameObject.SetActive(false);
}
}

    private void PlateKObj_OnAdded(object sender, PlateKObj.OnIngredientAddedEventArgs e)
    {
foreach(KitchenObjects_GameObj kitchenObjects_GameObj in kitchenObjects_GameObjsList){
    if(kitchenObjects_GameObj.kitchenObjects==e.kitchenObjects){
        kitchenObjects_GameObj.gameObject.SetActive(true);
    }
}
    }
}
