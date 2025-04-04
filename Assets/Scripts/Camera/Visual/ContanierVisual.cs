using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContanierVisual : MonoBehaviour
{[SerializeField] private ContainerCounter containerCounter;
private const String OPEN_CLOSE="OpenClose";
     private Animator animator;
private void Awake(){
    animator=GetComponent<Animator>();
}
private void Start(){
    containerCounter.OnPlayerHoldObj+=ContainerCounter_OnPlayerHold;
}

    private void ContainerCounter_OnPlayerHold(object sender, EventArgs e)
    {
       animator.SetTrigger(OPEN_CLOSE);
    }
}
