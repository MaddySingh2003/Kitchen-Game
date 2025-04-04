using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipe : ScriptableObject
{
public KitchenObjects input;
public KitchenObjects output;
public int fryingTimeMax;
}

