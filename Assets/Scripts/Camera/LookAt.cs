using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private enum Mode{
LookAt,
LookAtInverted,
CameraForWard,
CameraForWardInvert,
    }
    [SerializeField] private Mode mode;
    private void LateUpdate(){
        switch(mode){
            case Mode.LookAt:
                    transform.LookAt(Camera.main.transform);
        break;
        case Mode.LookAtInverted:
        Vector3 difFCamera=transform.position-Camera.main.transform.position;
        transform.LookAt(transform.position+difFCamera);
        break;
        case Mode.CameraForWard:
        transform.forward=Camera.main.transform.forward;
        break;
        case Mode.CameraForWardInvert:
        transform.forward=-Camera.main.transform.forward;
        break;
        }

    }
}

