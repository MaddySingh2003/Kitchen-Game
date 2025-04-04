using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveyManegerUI : MonoBehaviour
{
[SerializeField]  private Transform container;
[SerializeField] private Transform recipeTemp;
private void Awake(){
    recipeTemp.gameObject.SetActive(false);
}
private void Start(){
    DeliveryManager.Instance.OnRecipeSpawn+=DM_OnRecipeSpawn;
    DeliveryManager.Instance.OnRecipeComplete+=DM_OnRecipeComplete;
    UpdateVisual();
}

    private void DM_OnRecipeComplete(object sender, System.EventArgs e)
    {
      UpdateVisual();
    }

    private void DM_OnRecipeSpawn(object sender,System.EventArgs e)
    {
      UpdateVisual();}

    private void UpdateVisual(){
    foreach(Transform child in container){
        if(child==recipeTemp)continue;
        Destroy(child.gameObject);
    }
  foreach(RecipeSO recipeSO in  DeliveryManager.Instance.GetWaitingRecipeList()){
   Transform recipetrans= Instantiate(recipeTemp,container);
   recipetrans.gameObject.SetActive(true);
   recipetrans.GetComponent<DMSingleUI>().setRecipeSo(recipeSO);
  }
}
}
