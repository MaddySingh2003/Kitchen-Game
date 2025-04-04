using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KGameManager : MonoBehaviour
{private enum State{
    waitingToStart,
    CountDownStart,
    GamePlaying,
    GmaeOver,
}
private State state;
private void Awake(){
    state=State.waitingToStart;
}
}
