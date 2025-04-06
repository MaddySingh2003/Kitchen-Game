using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCDUi : MonoBehaviour
{[SerializeField] private TextMeshProUGUI countDownText;
private void Start(){
    KGameManager.Instance.OnStateChange+=KGameManager_OnStateChange;
    Hide();
}
private void Update(){
    countDownText.text=Mathf.Ceil(KGameManager.Instance.GetCountDownTimer()).ToString();
}

    private void KGameManager_OnStateChange(object sender, System.EventArgs e)
    {
if(KGameManager.Instance.IsCountDownStart()){
    Show();
}else{
    Hide();
}
    }
    private void Show(){
        gameObject.SetActive(true);
    }
    private void Hide(){
        gameObject.SetActive(false);
    }
}
