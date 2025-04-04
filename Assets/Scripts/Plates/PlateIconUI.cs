using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconUI : MonoBehaviour
{
    [SerializeField]private Transform iconTemplate;
   [SerializeField] private PlateKObj plateKObj;
   private void Awake(){
    iconTemplate.gameObject.SetActive(false);
   }
   private void Start(){
plateKObj.OnIngredientAdded+=PlateKObj_OnIngrdient;
   }

    private void PlateKObj_OnIngrdient(object sender, PlateKObj.OnIngredientAddedEventArgs e)
    {
        UpdateVisula(); }
    private void UpdateVisula(){
        foreach(Transform child in transform){
           if(child==iconTemplate)continue;
            Destroy(child.gameObject);
        }
foreach(KitchenObjects kitchenObjects in plateKObj.GetKitchenObjectsList()){
   Transform iconTrans= Instantiate(iconTemplate,transform);
   iconTemplate.gameObject.SetActive(true);
iconTrans.GetComponent<PlateIconSingleUi>().SetKObjs(kitchenObjects);
}
    } 

}
