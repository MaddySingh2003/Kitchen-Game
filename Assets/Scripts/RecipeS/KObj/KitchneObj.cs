using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchneObj : MonoBehaviour
{
[SerializeField] private  KitchenObjects kitchenObjects;
private IKParent kitchenObjParent;
public KitchenObjects GetKitchenObjects(){
    return kitchenObjects
;}
public void SetKitchObjParent(IKParent kitchenObjParent){
    if(this.kitchenObjParent!=null){
        this.kitchenObjParent.ClearKitchenobj();
    }
this.kitchenObjParent=kitchenObjParent;
if(kitchenObjParent.HasKitchenObj()){
    Debug.Log("Has an Obj!");
}
kitchenObjParent.SetKitchenObj(this);
transform.parent=kitchenObjParent.GetKitchenObjFollowTrans();
transform.localPosition=Vector3.zero;
}
public IKParent GetKitchnObjParent(){
 return kitchenObjParent;   
}
public void DestroyObj(){
    kitchenObjParent.ClearKitchenobj();
    Destroy(gameObject);
}
public static KitchneObj SpawnKitchenObj(KitchenObjects kitchenObjects,IKParent kParent){
     Transform KitchenObjTrans= Instantiate(kitchenObjects.prefab);
     
      KitchneObj kitchneObj= KitchenObjTrans.GetComponent<KitchneObj>();
      kitchneObj.SetKitchObjParent(kParent);
      return kitchneObj;
}
public bool TryGetPlate(out PlateKObj plateKObj){
    if(this is PlateKObj){
        plateKObj=this as PlateKObj;
        return true;
    }else{
        plateKObj=null;
        return false;
    }
} 

}
