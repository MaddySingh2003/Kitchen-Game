using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKParent 
{
   public Transform GetKitchenObjFollowTrans();
public void  SetKitchenObj(KitchneObj kitchneObj);
public KitchneObj GetKitchenObj();
public void ClearKitchenobj();
public bool HasKitchenObj();
}
