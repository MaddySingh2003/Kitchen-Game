using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PlateIconSingleUi : MonoBehaviour
{[SerializeField] private Image image;
  public void SetKObjs(KitchenObjects kitchenObjects){
image.sprite=kitchenObjects.sprite;
  }
}
