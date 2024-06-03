using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Image itemImage;

    void Update()
    {
        if (inventory.currentItem != null)
        {
            itemImage.sprite = inventory.currentItem.itemImage;
            itemImage.enabled = true;
        }
        else
        {
            itemImage.enabled = false;
        }
    }
}
