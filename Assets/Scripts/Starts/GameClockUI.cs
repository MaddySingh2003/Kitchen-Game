using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class GameClockUI : MonoBehaviour
{
 [SerializeField] private Image timerImage;
 private void Update(){
    timerImage.fillAmount=KGameManager.Instance.GetPlayingTimerN();
 }
}
