using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameIns : MonoBehaviour
{
    public static GameIns Instance{get;private set;}
public event EventHandler  OnInteractAct;
public event EventHandler  OnInteractAltAct;
public event EventHandler OnpauseAction;

    private  PlayerAction playerActions;
    private void Awake(){
        Instance=this;
        playerActions=new PlayerAction();
        playerActions.Player.Enable();
        playerActions.Player.Interaction.performed+=Interact_performed;
        playerActions.Player.InteractAlt.performed+=InteractAlt_performed;
        playerActions.Player.Pause.performed+=Paused_perform;
    }

    private void Paused_perform(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
    OnpauseAction?.Invoke(this,EventArgs.Empty);
    }

    private void InteractAlt_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {OnInteractAltAct?.Invoke(this,EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAct?.Invoke(this,EventArgs.Empty);
    }

    public Vector2 GetMoveVector(){
 Vector2 inputVector=playerActions.Player.Move.ReadValue<Vector2>();
 
       
inputVector=inputVector.normalized;  
return inputVector;
}
}
