using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu( menuName = "New Inventory Items")]
public class InventoryItems : ScriptableObject
{ 
    public InventoryItemData[] Items;
    
    public InventoryItemData GetItemAt(int itemIndex)
    {
        return Items[itemIndex];
    }
}

