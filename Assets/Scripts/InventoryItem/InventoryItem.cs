using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Inventory Item")]
public class InventoryItem : ScriptableObject
{
    public int id;
    public string name;
    public int quantity;
    public Sprite image;
}
