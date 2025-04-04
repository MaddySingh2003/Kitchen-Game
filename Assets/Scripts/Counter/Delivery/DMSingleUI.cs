using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DMSingleUI : MonoBehaviour
{
 [SerializeField] private TextMeshProUGUI  recipeNameText;
 [SerializeField] private Transform iconContainer;
 [SerializeField] private Transform iconTemp;
 private void Awake(){
    iconTemp.gameObject.SetActive(false );
 }
 public void setRecipeSo(RecipeSO recipeSO){

    recipeNameText.text=recipeSO.recipeName;
    foreach(Transform child in iconContainer)
    {
        if(child==iconTemp)continue;
        Destroy(child.gameObject);
    }


//     foreach(Transform child in iconContainer){
//         if(child==iconTemp)continue;
//         Destroy(child.gameObject);
//     }
     foreach(KitchenObjects  kitchenObjects in recipeSO.kitchenObjectsl){
       Transform iconTranf= Instantiate(iconTemp,iconContainer);
iconTranf.gameObject.SetActive(true);
 iconTranf.GetComponent<Image>().sprite=kitchenObjects.sprite;
               }
}
}
