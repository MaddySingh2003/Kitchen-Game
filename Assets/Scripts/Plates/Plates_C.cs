using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plates_C : BaseCounter{
    public event EventHandler OnPlatesSpaw;
    public event EventHandler OnPlatesRemove;
    [SerializeField] private KitchenObjects plateKitchenObjs;
    private float spawnPlateTmer;
    private float spawnPlateTmerMax=4f;
    private int plateSpawnAmt;
    private int plateSpawnAmtMax=4;
    private void Update(){
spawnPlateTmer+=Time.deltaTime;
if(spawnPlateTmer>spawnPlateTmerMax){
 spawnPlateTmer=0f;
 if(plateSpawnAmt<plateSpawnAmtMax){
    plateSpawnAmt++;
    OnPlatesSpaw?.Invoke(this,EventArgs.Empty);
 }
}
}
public override void Interact(Player player){
     if(!player.HasKitchenObj()){
if(plateSpawnAmt>0){
KitchneObj.SpawnKitchenObj(plateKitchenObjs,player);
OnPlatesRemove?.Invoke(this,EventArgs.Empty);
}
     }   
    }
    }

