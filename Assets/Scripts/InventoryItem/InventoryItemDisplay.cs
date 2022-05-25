using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemDisplay : MonoBehaviour
{
    public InventoryItem item;

    public Image image;
    public TMP_Text quantity;

    void Start()
    {
        quantity.text = item.quantity.ToString();
        image.sprite = item.image;
    }
}
