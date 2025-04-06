using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour,IKParent

{
   
   private static Player instance;
   public static Player Instance{
get; private set;
   }
   public event EventHandler OnPickSomething;
//    public static player  instanceField;
//    public static player GetInstanceField(){
//       return instanceField;
//    } 
//    public static void setInstanceField(player instanceField){
// player.instanceField=instanceField;   }
   public event EventHandler <OnSelectCouChangeEventArgs> OnSelectCouChange;
   public class OnSelectCouChangeEventArgs:  EventArgs{
      public BaseCounter selectedCounter;
   }
   [SerializeField] private float mSpeed=9f;
   [SerializeField] private GameIns gameInput;
   [SerializeField] private Transform KitchObjHOldPoint;
   [SerializeField] private LayerMask counterLayerM;
    private bool isWalking;
    private  Vector3 lastInterDir;
    private BaseCounter selectedCounter;
    private KitchneObj kitchneObj;
    private void Awake(){
      if(Instance!=null){
         Debug.LogError("More Than 1 Players!");
      }
      Instance=this;
    }
    private void Start(){
      gameInput.OnInteractAct+=GameIns_OnInteractAct;
      gameInput.OnInteractAltAct+=GameIns_OnInteracAlttAct;
    }

    private void GameIns_OnInteracAlttAct(object sender, EventArgs e)
    {if(!KGameManager.Instance.IsGamePlay())return;
       if(selectedCounter!=null){
         selectedCounter.InteractAlt(this);//
      }
    }

    private void GameIns_OnInteractAct(object sender, System.EventArgs e)
    {if(!KGameManager.Instance.IsGamePlay())return;
      if(selectedCounter!=null){
         selectedCounter.Interact(this);//
      }
     }

    private void Update()
    {
      HandelMovement();
      HandelInteractions();  }
 private void HandelInteractions(){
     Vector2 inputVector=gameInput.GetMoveVector();
     Vector3 movDir=new Vector3(inputVector.x,0f,inputVector.y);
     if(movDir!=Vector3.zero){
      lastInterDir=movDir;
     }
     
     float interactDis=2f;

    if( Physics.Raycast(transform.position,lastInterDir,out RaycastHit raycastHit,interactDis,counterLayerM)){
      
        if(raycastHit.transform.TryGetComponent(out BaseCounter baseCounter)){
        if(baseCounter != selectedCounter){
         setSelectedCounter(baseCounter);
          
        }
      
        }else{
        setSelectedCounter(null);
         
        }
   
    }else{
      setSelectedCounter(null);
    }
 }
 private void HandelMovement(){

       Vector2 inputVector=gameInput.GetMoveVector();
        
Vector3 movDir=new Vector3(inputVector.x,0f,inputVector.y);
float playerSize=0.5f;
float playerHeight=0.5f;
float moveDis=mSpeed*Time.deltaTime;
bool isMove=!Physics.CapsuleCast( transform.position,transform.position+Vector3.up*playerHeight,playerSize, movDir,moveDis);
if(!isMove){
Vector3 movDirX=new Vector3(movDir.x,0,0).normalized;
isMove=movDir.x!=0&&!Physics.CapsuleCast( transform.position,transform.position+Vector3.up*playerHeight,playerSize, movDirX,moveDis);
if(isMove){
   movDir=movDirX;
}else{   
Vector3 movDirZ=new Vector3(0,0,movDir.z).normalized;
isMove=movDir.z!=0&&!Physics.CapsuleCast( transform.position,transform.position+Vector3.up*playerHeight,playerSize, movDirZ,moveDis);
if(isMove){
   movDir=movDirZ;
}else{

}
}

}
if(isMove){
 transform.position+=movDir*moveDis;
}

float rSpeed=1f;

//isWalking=movDir !=Vector3.zero;
transform.forward=Vector3.Slerp(transform.forward,movDir,Time.deltaTime*rSpeed );

 }
 public bool IsWalking(){
       return isWalking;}
private void setSelectedCounter(BaseCounter selectedCounter){
this.selectedCounter=selectedCounter;
OnSelectCouChange?.Invoke(this,new OnSelectCouChangeEventArgs{
            selectedCounter=selectedCounter
          });
}
//  }
public Transform GetKitchenObjFollowTrans(){return KitchObjHOldPoint;}
public void  SetKitchenObj(KitchneObj kitchneObj){
    this.kitchneObj=kitchneObj;
    if(kitchneObj!=null){
      OnPickSomething?.Invoke(this,EventArgs.Empty);
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
