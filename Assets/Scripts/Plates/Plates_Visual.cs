using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plates_Visual : MonoBehaviour
{
 [SerializeField] private Transform counterTop;
  [SerializeField] private Transform platesPrefeb;
  private List<GameObject> platesObjList;
  [SerializeField] private Plates_C plates_C;
  private void Awake(){
    platesObjList=new List<GameObject>();
  }
  private void Start(){
plates_C.OnPlatesSpaw+=plates_C_OnPlateSpwaned;
plates_C.OnPlatesRemove+=plates_C_OnPlatesRemove;
  }

    private void plates_C_OnPlatesRemove(object sender, EventArgs e)
    {GameObject platerObj=platesObjList[platesObjList.Count-1];
    platesObjList.Remove(platerObj);
    Destroy(platerObj);
    }

    private void plates_C_OnPlateSpwaned(object sender, EventArgs e)
    {Transform platesTrans=Instantiate(platesPrefeb,counterTop);
    float platesOff=.1f;
   platesTrans.localPosition=new Vector3(0,platesOff*platesObjList.Count,0);
platesObjList.Add(platesTrans.gameObject);
    }
    
}
