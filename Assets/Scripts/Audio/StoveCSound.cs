using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCSound : MonoBehaviour
{
    [SerializeField] private StoveC stoveC;
   private AudioSource audioSource;
   private void Awake(){
    audioSource=GetComponent<AudioSource>();
   }
   private void Start(){
    StoveC.OnStateChange+=Stove_OnChange;
   }

    private void Stove_OnChange(object sender, StoveC.OnStateChangeEventArgs e)
    {
        bool playSound=e.state==StoveC.State.Frying ||e.state== StoveC.State.Fried;
        if(playSound){
            audioSource.Play();
        }else{
            audioSource.Pause();
        }
     }
}
