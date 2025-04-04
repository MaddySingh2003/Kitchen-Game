using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private float footstepsTimer;
    private float footstepsTimerMAx=.1f;
  private Player player;
  private void  Awake(){
    player=GetComponent<Player>();
  }
  private void Update(){
    footstepsTimer-=Time.deltaTime;
    if(footstepsTimer<0f){
        footstepsTimer=footstepsTimerMAx;
      //  if(player.IsWalking()){
     float volume=1f;
        SoundManager.Instance.PalyFootStepsSound(player.transform.position,volume);
        }
  }
}
