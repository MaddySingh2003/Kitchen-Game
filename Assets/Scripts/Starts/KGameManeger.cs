using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

//using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class KGameManager : MonoBehaviour
{public static KGameManager Instance {get;private set;}
public event EventHandler OnStateChange;
    private enum State{
    waitingToStart,
    CountDownStart,
    GamePlaying,
    GmaeOver,
}
private bool isPuse=false;
private State state;
private float waitingToStart=1f;
private float countDownStartTimer=3f;
private float gamePlayingTimer;
private float gamePlayingTimerMAx=360f;
private void Awake(){
    Instance=this;
    state=State.waitingToStart;
}
private void Start(){
    GameIns.Instance.OnpauseAction+=GM_PauseAction;
}

    private void GM_PauseAction(object sender, EventArgs e)
    {
        PauseGame();
    }

    private void  Update(){
    switch (state){
case State.waitingToStart:
waitingToStart-=Time.deltaTime;
if(waitingToStart<0f){
    state=State.CountDownStart;
    OnStateChange?.Invoke(this,EventArgs.Empty);
}
break;
case State.CountDownStart:
countDownStartTimer-=Time.deltaTime;
if(countDownStartTimer<0f){
    state=State.GamePlaying;
    gamePlayingTimer=gamePlayingTimerMAx;
     OnStateChange?.Invoke(this,EventArgs.Empty);
}
break;
case State.GamePlaying:
gamePlayingTimer-=Time.deltaTime;
if(gamePlayingTimer<0f){
    state=State.GmaeOver;
     OnStateChange?.Invoke(this,EventArgs.Empty);
}
break;
    case State.GmaeOver:

break;
    
    
    }
    Debug.Log(state);
}
public bool IsGamePlay(){
    return state==State.GamePlaying;
}
public bool IsCountDownStart(){
    return state==State.CountDownStart;
}
public float GetCountDownTimer(){
    return countDownStartTimer;
}
public bool IsGameOver(){
    return state==State.GmaeOver;
}
public float GetPlayingTimerN(){
    return 1- (gamePlayingTimer/gamePlayingTimerMAx);
}
private void PauseGame(){
    isPuse=!isPuse;
    if(isPuse){Time.timeScale=0.1f;}
    else{
        Time.timeScale=1f;
    }
}
}
