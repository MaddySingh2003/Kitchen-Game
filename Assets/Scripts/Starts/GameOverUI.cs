using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI recipesDeliveredText;
   private void Start(){
   KGameManager.Instance.OnStateChange+=KGameManager_OnStateChange;
    Hide();
}

    private void KGameManager_OnStateChange(object sender,System.EventArgs e)
    {
if(KGameManager.Instance.IsGameOver()){
    Show();
      recipesDeliveredText.text=DeliveryManager.Instance.GetSucessRecipeAmt().ToString();
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
