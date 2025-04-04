using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CuttingCounter : BaseCounter,ICProgress
{
  public static event EventHandler OnAnyC;
    public event EventHandler<ICProgress.OnProgressChangeEventArgs> OnProgressChange;
   
    public event EventHandler OnCut;
    [SerializeField] private CuttingRecipeS[] cutReciprArry;
    private int cuttingProgress;
    public override void Interact(Player player)
    {
       
      if(HasKitchenObj()){
        if(player.HasKitchenObj()){if(player.GetKitchenObj().TryGetPlate( out PlateKObj plateKObj)){

 if( plateKObj.TryAddIngredient(GetKitchenObj().GetKitchenObjects())){
  GetKitchenObj().DestroyObj();
}}

        }else{
            GetKitchenObj().SetKitchObjParent(player);
        }

      }else{
       if( player.HasKitchenObj()){
        if(HasRecipeIn(player.GetKitchenObj().GetKitchenObjects())){
 player.GetKitchenObj().SetKitchObjParent(this);
 cuttingProgress=0;
  CuttingRecipeS cuttingRecipeS=GetCuttingRecipeW_In(GetKitchenObj().GetKitchenObjects());
 OnProgressChange?.Invoke(this,new ICProgress.OnProgressChangeEventArgs{
    progressNormalized=(float)cuttingProgress/cuttingRecipeS.cuttingProgressMax

 }) ;    }
       
       }
      }
 
    }
    public override void InteractAlt(Player player)
    {
        if(HasKitchenObj()&& HasRecipeIn(GetKitchenObj().GetKitchenObjects())){
           cuttingProgress++;
           OnCut?.Invoke(this,EventArgs.Empty);
           OnAnyC?.Invoke(this,EventArgs.Empty);
             CuttingRecipeS cuttingRecipeS=GetCuttingRecipeW_In(GetKitchenObj().GetKitchenObjects());
              OnProgressChange?.Invoke(this,new ICProgress.OnProgressChangeEventArgs{
    progressNormalized=(float)cuttingProgress/cuttingRecipeS.cuttingProgressMax

 }) ;
              if(cuttingProgress>=cuttingRecipeS.cuttingProgressMax){
 KitchenObjects outKitechenObjs=GetOutForIn(GetKitchenObj().GetKitchenObjects());
            GetKitchenObj().DestroyObj();
       KitchneObj.SpawnKitchenObj(outKitechenObjs,this);
              }
           
        }
    }
    private KitchenObjects GetOutForIn(KitchenObjects inKitchenObj){
     CuttingRecipeS cuttingRecipeS=GetCuttingRecipeW_In(inKitchenObj);
      if(cuttingRecipeS!=null){
        return cuttingRecipeS.output;
      }else{
        return null;
      }
    }
    private bool HasRecipeIn(KitchenObjects inKitchneObj){
          CuttingRecipeS cuttingRecipeS=GetCuttingRecipeW_In(inKitchneObj);
    return cuttingRecipeS!=null;
    }
    private CuttingRecipeS GetCuttingRecipeW_In(KitchenObjects inKitchenObjects){
foreach(CuttingRecipeS cuttingRecipeS in cutReciprArry){
            if(cuttingRecipeS.input==inKitchenObjects){
return cuttingRecipeS;
            }
        }
        return null;
    }
}
