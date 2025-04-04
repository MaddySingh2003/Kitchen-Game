using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressbarUI : MonoBehaviour
{
   [SerializeField] private Image barImage;
   [SerializeField] private GameObject HasProgressGameObj;
    private ICProgress hasProgress;
   private void Start(){
    hasProgress=HasProgressGameObj.GetComponent<ICProgress>();
    if(hasProgress==null){
      Debug.LogError("GObj"+HasProgressGameObj+"not done!");
    }
    hasProgress.OnProgressChange+=HasProgress_OnProgress;
    barImage.fillAmount=0f;
    Hide();
   }

    private void HasProgress_OnProgress(object sender, ICProgress.OnProgressChangeEventArgs e)
    {
       barImage.fillAmount=e.progressNormalized;
       if(e.progressNormalized==0f|| e.progressNormalized==1f){
         Hide();
       }else{
         Show();
       }
    }
    private void Show(){
gameObject.SetActive(true);
    }
    private void Hide(){
gameObject.SetActive(false);
    }
}
