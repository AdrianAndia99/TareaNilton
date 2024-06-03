using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory/Item")]
public class SOitem : ScriptableObject
{
    public Sprite itemImage;
    public float duration;
    public string effect;

    public void ActivateEffect()
    {
        Debug.Log("Efecto activado: " + effect);
    }
}