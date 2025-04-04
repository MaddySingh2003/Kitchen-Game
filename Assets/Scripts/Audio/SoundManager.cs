//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityEngine.Playables;

public class SoundManager : MonoBehaviour

{
  public static SoundManager Instance {get;private set;}
[SerializeField] private AudioClipSo audioClipSo;
private void Awake(){
  Instance=this;
}
    private void Start(){
        DeliveryManager.Instance.OnRecipeSucess+=DM_OnRecipeSuss;
        DeliveryManager.Instance.OnRecipeFailed+=DM_OnRecipeFail;
        CuttingCounter.OnAnyC+=CutC_AnyCut;
        Player.Instance.OnPickSomething+=I_OnPicked;
      BaseCounter.OnAnyObjPlacedHere+=Bc_PLAcedHere;
      TrashBin.OnAnyObjTrash+=T_OnAny;
        
    }

    private void T_OnAny(object sender, System.EventArgs e)
    {
       TrashBin trashBin=sender as  TrashBin;
      PlaySound(audioClipSo.trash,trashBin.transform.position);
    }

    private void Bc_PLAcedHere(object sender, System.EventArgs e)
    {
      BaseCounter baseCounter=sender as  BaseCounter;
      PlaySound(audioClipSo.ObjDrop,baseCounter.transform.position);
    }

    private void I_OnPicked(object sender, System.EventArgs e)
    {
      PlaySound(audioClipSo.objPickUp,Player.Instance.transform.position);
    }

    private void CutC_AnyCut(object sender, System.EventArgs e)
    {CuttingCounter cuttingCounter=sender as CuttingCounter;
       PlaySound(audioClipSo.chop,cuttingCounter.transform.position);
    }

    private void DM_OnRecipeFail(object sender, System.EventArgs e)
    {
      DelivreyCounter delivreyCounter=DelivreyCounter.Instance;
      PlaySound(audioClipSo.deliveryFail,delivreyCounter.transform.position);
    }

    private void DM_OnRecipeSuss(object sender, System.EventArgs e)
    {
         DelivreyCounter delivreyCounter=DelivreyCounter.Instance;
     
       PlaySound(audioClipSo.deliverySucss,delivreyCounter.transform.position);
    }

  private void PlaySound(AudioClip[] audioClipArr,Vector3 position,float volume=1f){
        PlaySound(audioClipArr[Random.Range(0,audioClipArr.Length)],position,volume);
    
   }

    private void PlaySound(AudioClip audioClip,Vector3 position,float volume=1f){
    AudioSource.PlayClipAtPoint(audioClip,position,volume);
   }
   public void PalyFootStepsSound(Vector3 position,float volume){
    PlaySound(audioClipSo.footsteps,position,volume);
   }
}
