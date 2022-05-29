using System;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Canvas : MonoBehaviour
{
    public Panel InventoryPanel;
    public Panel InventoryEquipPanel;

    public InventoryItems _InventoryItems;
    public InventoryItemDisplay _InventoryItem;

    private List<InventoryItemData> InventoryItemDatas;
    // private List<InventoryItemDisplay> InventoryItemDisplays = new List<InventoryItemDisplay>();

    private InventoryItemDisplay selectItem = null;
    private int dragIndex = -1;
    private Vector3 dragItemDefaultPosition;
    private int dropIndex = -1;

    public Controller InventoryItemScrollController;
    
    void Start()
    {
        InventoryItemDatas = new List<InventoryItemData>(_InventoryItems.Items);
        // foreach (InventoryItemData item in InventoryItemDatas)
        // {
        //     InventoryItemDisplays.Append(addItem(item));
        // }
        syncInventoryItemDatas();
    }
    
    private void syncInventoryItemDatas()
    {
        InventoryItemScrollController.setItemList(InventoryItemDatas);
    }
    
    public void addNewItem()
    {
        Random random = new Random();
        int index = random.Next(0, InventoryItemDatas.Count);
        InventoryItemData dataa = InventoryItemDatas[index].Clone();
        InventoryItemDatas.Add(dataa);
        syncInventoryItemDatas();
    }

    public void deleteItem()
    {
        int index = InventoryItemScrollController.deleteItem();
        if (index == -1)
        {
            return;
        }
        InventoryItemDatas.RemoveAt(index);
    }
    
    // private InventoryItemDisplay addItem(InventoryItemData item)
    // {
    //     InventoryItemDisplay p = Instantiate(_InventoryItem);
    //     p.GetComponent<InventoryItemDisplay>().item = item;
    //     p.transform.SetParent(InventoryPanel.transform);
    //         
    //     p.OnItemBeginDrag += HandleBeginDrag;
    //     p.OnItemDroppedOn += HandleSwap;
    //     p.OnItemEndDrag += HandleEndDrag;
    //     p.OnItemClicked += HandleClick;
    //
    //     return p;
    // }
    //
    // private void HandleClick(InventoryItemDisplay inventoryItemUI)
    // {
    //     int index = InventoryItemDisplays.IndexOf(inventoryItemUI);
    //     if (index == -1)
    //         return;
    //     if (selectItem)
    //     {
    //         selectItem.GetComponent<Graphic>().color = Color.white;
    //     }
    //     selectItem = inventoryItemUI;
    //     selectItem.GetComponent<Graphic>().color = Color.red;
    // }   
    //
    // private void HandleBeginDrag(InventoryItemDisplay inventoryItemUI)
    // {        
    //     int index = InventoryItemDisplays.IndexOf(inventoryItemUI);
    //     if (index == -1)
    //         return;
    //     dragIndex = index;
    //     dragItemDefaultPosition = inventoryItemUI.transform.position;
    //     inventoryItemUI.GetComponent<Graphic>().color = new Color32(255,255,255,160);
    // }   
    //
    // private void HandleSwap(InventoryItemDisplay inventoryItemUI)
    // {
    //     int index = InventoryItemDisplays.IndexOf(inventoryItemUI);
    //     if (index == -1)
    //         return;
    //     dropIndex = index;
    // }
    //
    // private void HandleEndDrag(InventoryItemDisplay inventoryItemUI)
    // {
    //     int index = InventoryItemDisplays.IndexOf(inventoryItemUI);
    //     if (index == -1)
    //         return;
    //     Swap();
    //     ResetDraggedItem();
    //     if (selectItem == inventoryItemUI)
    //     {
    //         inventoryItemUI.GetComponent<Graphic>().color = Color.red;
    //     }
    //     else
    //     {
    //         inventoryItemUI.GetComponent<Graphic>().color = Color.white;
    //     }
    // }
    //
    // private void Swap()
    // {
    //     Debug.Log("drag " +dragIndex);
    //     Debug.Log("drop " +dropIndex);
    //
    //     InventoryItemDisplays[dragIndex].transform.position = InventoryItemDisplays[dropIndex].transform.position;
    //     InventoryItemDisplays[dropIndex].transform.position = dragItemDefaultPosition;
    //     
    //     InventoryItemDisplay drag = InventoryItemDisplays[dragIndex];
    //     InventoryItemDisplays[dragIndex] = InventoryItemDisplays[dropIndex];
    //     InventoryItemDisplays[dropIndex] = drag;
    // }
    //
    // private void ResetDraggedItem()
    // {
    //     dragIndex = -1;
    //     dropIndex = -1;
    // }
    //
    // void Update()
    // {
    //     if (dragIndex == -1)
    //     {
    //         return;
    //     }
    //     InventoryItemDisplays[dragIndex].transform.position = Input.mousePosition;
    // }
}
