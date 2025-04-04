using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingVisual : MonoBehaviour
{[SerializeField] private CuttingCounter cuttingCounter;
private const String CUT="Cut";
     private Animator animator;
private void Awake(){
    animator=GetComponent<Animator>();
}
private void Start(){
    cuttingCounter.OnCut+=CuttingCounter_OnCut;

}

    private void CuttingCounter_OnCut(object sender, EventArgs e)
    {
       animator.SetTrigger(CUT);
    }

   
}
