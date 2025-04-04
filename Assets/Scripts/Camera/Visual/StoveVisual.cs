//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveVisual : MonoBehaviour
{
    [SerializeField]private StoveC stoveC;
[SerializeField] private GameObject stoveOnGameObj;
[SerializeField] private GameObject particalGameObj;
private void start(){
    StoveC.OnStateChange+=StoveC_OnChange;
}

    private void StoveC_OnChange(object sender, StoveC.OnStateChangeEventArgs e)
    {
 bool showVisual=e.state==StoveC.State.Frying||e.state==StoveC.State.Fried;
 stoveOnGameObj.SetActive(showVisual);
 particalGameObj.SetActive(showVisual);
    }
}
