using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
      [SerializeField] private GameObject[] visualGameObjArray;
     private   void Start()
    {Player.Instance.OnSelectCouChange+=Player_OnSelectCouChange;
        
    }

    private void Player_OnSelectCouChange(object sender, Player.OnSelectCouChangeEventArgs e)
    {
       if(e.selectedCounter==baseCounter){
Show();
       }else{
        Hide();
       }
    }

   private void Show(){
      foreach (GameObject visualGameobj in visualGameObjArray){
    visualGameobj.SetActive(true);
    }
   }
   private void Hide(){ foreach (GameObject visualGameobj in visualGameObjArray){
    visualGameobj.SetActive(false);
    }
   }

}
