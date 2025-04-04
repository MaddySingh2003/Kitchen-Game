using System;
using System.Collections;
using System.Collections.Generic;
//using OpenCover.Framework.Model;
using  static CuttingCounter;

//using System.Diagnostics;
using UnityEngine;

public class StoveC : BaseCounter,ICProgress
{ public event EventHandler<ICProgress.OnProgressChangeEventArgs> OnProgressChange;
  public static event  EventHandler<OnStateChangeEventArgs> OnStateChange;
  public class OnStateChangeEventArgs:EventArgs{
    public State state;
  }
    private FryingRecipe fryingRecipe;
   public enum  State{
      Idel,
      Frying,
      Fried,
      Burned,
    }
[SerializeField] private  FryingRecipe[] fringRecipesArr ;
[SerializeField] private  BurningR[] burningRArr ;
private BurningR burningR;
private State state;
private float fryingTimer;
private float burnigTimer;
private void Start(){
state=State.Idel;
}
private void Update(){
   if(HasKitchenObj()){
  switch(state){
case State.Idel:
break;
case State.Frying:

        fryingTimer+=Time.deltaTime;
        OnProgressChange?.Invoke(this,new ICProgress.OnProgressChangeEventArgs{
progressNormalized=fryingTimer/fryingRecipe.fryingTimeMax
});
      
        if(fryingTimer >fryingRecipe.fryingTimeMax){
       
          
            GetKitchenObj().DestroyObj();
            KitchneObj.SpawnKitchenObj(fryingRecipe.output,this);
           
            state=State.Fried;
            burnigTimer=0f;
             burningR=GetBurningW_In(GetKitchenObj().GetKitchenObjects());
             OnStateChange?.Invoke(this, new OnStateChangeEventArgs{
state=state
             });
        }
        
break;
case State.Fried:
 burnigTimer+=Time.deltaTime;
 OnProgressChange?.Invoke(this,new ICProgress.OnProgressChangeEventArgs{
progressNormalized=burnigTimer/burningR.burnigTimerMax
});
      
        if( burnigTimer >burningR.burnigTimerMax){
       
          
            GetKitchenObj().DestroyObj();
            KitchneObj.SpawnKitchenObj(burningR.output,this);
            state=State.Burned;
             OnStateChange?.Invoke(this, new OnStateChangeEventArgs{
state=state
             });
             OnProgressChange?.Invoke(this,new ICProgress.OnProgressChangeEventArgs{
progressNormalized=0f
});
        }
break;
case State.Burned:
break;
  }

   
    }
}
    public override void Interact(Player player)
    {
         
      if(HasKitchenObj()){
        if(player.HasKitchenObj()){
if(player.GetKitchenObj().TryGetPlate( out PlateKObj plateKObj)){

 if( plateKObj.TryAddIngredient(GetKitchenObj().GetKitchenObjects())){
  GetKitchenObj().DestroyObj(); 
  state=State.Idel; 
            OnStateChange?.Invoke(this, new OnStateChangeEventArgs{
state=state
             });OnProgressChange?.Invoke(this,new ICProgress.OnProgressChangeEventArgs{
progressNormalized=0f
});
}
}
        }else{
            GetKitchenObj().SetKitchObjParent(player);
            state=State.Idel; 
            OnStateChange?.Invoke(this, new OnStateChangeEventArgs{
state=state
             });OnProgressChange?.Invoke(this,new ICProgress.OnProgressChangeEventArgs{
progressNormalized=0f
});
        }

      }else{
       if( player.HasKitchenObj()){
        if(HasRecipeIn(player.GetKitchenObj().GetKitchenObjects())){
 player.GetKitchenObj().SetKitchObjParent(this);
    fryingRecipe=GetFryingRecipeW_In(GetKitchenObj().GetKitchenObjects());
    state=State.Frying;
    fryingTimer=0f; 
    OnStateChange?.Invoke(this, new OnStateChangeEventArgs{
state=state
             });
OnProgressChange?.Invoke(this,new ICProgress.OnProgressChangeEventArgs{
progressNormalized=fryingTimer/fryingRecipe.fryingTimeMax
});
  
    }
       
       }
      }
    }
      private KitchenObjects GetOutForIn(KitchenObjects inKitchenObj){
      FryingRecipe fryingRecipe=GetFryingRecipeW_In(inKitchenObj);
      if(fryingRecipe!=null){
        return fryingRecipe.output;
      }else{
        return null;
      }
    }
    private bool HasRecipeIn(KitchenObjects inKitchneObj){
           FryingRecipe fryingRecipe=GetFryingRecipeW_In(inKitchneObj);
    return fryingRecipe!=null;
    }
    private FryingRecipe GetFryingRecipeW_In(KitchenObjects inKitchenObjects){
foreach(FryingRecipe fryingRecipeS in fringRecipesArr){
            if(fryingRecipeS.input==inKitchenObjects){
return fryingRecipeS;
            }
        }
        return null;
    } 
    private BurningR GetBurningW_In(KitchenObjects inKitchenObjects){
foreach(BurningR burningRS in burningRArr ){
            if(burningRS.input==inKitchenObjects){
return burningRS;
            }
        }
        return null;
    }
}
