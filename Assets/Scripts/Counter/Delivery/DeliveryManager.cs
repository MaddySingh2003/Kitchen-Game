using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance{get; private set;}
    public event EventHandler OnRecipeSpawn;
     public event EventHandler OnRecipeComplete;
     public event EventHandler OnRecipeSucess;
     public event EventHandler OnRecipeFailed;


   [SerializeField] private RecipeListSO recipeListSO;
    private List<RecipeSO> watingRecipeSOList;
    private float spawnRecipeTimerMAx=4f;
    private float spawnRecipeTimer;
    private int WaittingRecipesMax=4;
    private int sucessRecipeAmt;
    private void Awake(){
        Instance=this;
        watingRecipeSOList=new List<RecipeSO>();
    }
    public void DeliverRecipe(PlateKObj plateKObj){
for (int i=0;i<watingRecipeSOList.Count;i++){
RecipeSO waitingRecipes=watingRecipeSOList[i];
if(waitingRecipes.kitchenObjectsl.Count==plateKObj.GetKitchenObjectsList().Count){
    bool plateConterIsRecipe=true;
    foreach(KitchenObjects recipeKitchenObjects in waitingRecipes.kitchenObjectsl){
        bool iFound=false;
     foreach(KitchenObjects plateKitchenObjects in plateKObj.GetKitchenObjectsList()){
        if(plateKitchenObjects==recipeKitchenObjects){
              iFound=true;
              break;
        }
    } 
    if(!iFound){
plateConterIsRecipe=false;
    }  
    }if(plateConterIsRecipe){
       
        watingRecipeSOList.RemoveAt(i);
        OnRecipeComplete?.Invoke(this,EventArgs.Empty);
sucessRecipeAmt++;
        OnRecipeSucess?.Invoke(this,EventArgs.Empty);
        return;
    }
}
}
OnRecipeFailed?.Invoke(this,EventArgs.Empty);
    }
        private void Update(){
        spawnRecipeTimer-=Time.deltaTime;
        if(spawnRecipeTimer<=0f){
            spawnRecipeTimer=spawnRecipeTimerMAx;
            if(watingRecipeSOList.Count<WaittingRecipesMax){
           RecipeSO WaittingRecipes= recipeListSO.recipeSOList[UnityEngine.Random.Range(0,recipeListSO.recipeSOList.Count)];

           watingRecipeSOList.Add(WaittingRecipes);
           OnRecipeSpawn?.Invoke(this,EventArgs.Empty);
        }
        }
    }
    public List<RecipeSO> GetWaitingRecipeList(){
        return watingRecipeSOList;
    }
    public int GetSucessRecipeAmt(){
        return sucessRecipeAmt;
    }
}
