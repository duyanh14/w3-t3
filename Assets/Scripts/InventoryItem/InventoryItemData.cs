using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "New Inventory Item")]
public class InventoryItemData  : ScriptableObject
{
    public int id;
    public string name;
    public int quantity;
    public Sprite image;

    public InventoryItemData Clone()
    {
        return (InventoryItemData) MemberwiseClone();
    }
}
