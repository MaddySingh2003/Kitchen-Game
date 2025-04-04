using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameIns : MonoBehaviour
{
public event EventHandler  OnInteractAct;
public event EventHandler  OnInteractAltAct;

    private  PlayerAction playerActions;
    private void Awake(){
        playerActions=new PlayerAction();
        playerActions.Player.Enable();
        playerActions.Player.Interaction.performed+=Interact_performed;
        playerActions.Player.InteractAlt.performed+=InteractAlt_performed;
    }

    private void InteractAlt_performed(InputAction.CallbackContext context)
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
