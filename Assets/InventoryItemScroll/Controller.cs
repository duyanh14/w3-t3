using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine.UI;

public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
{

    public Canvas Canvas;
    
    public InventoryItems _InventoryItems;
    public EnhancedScroller scroller;
    public EnhancedScrollerCellView cellViewPrefab;

    public int numberOfCellsPerRow = 6;

    private List<InventoryItemData> InventoryItemDatas;
    
    private InventoryItemDisplay InventoryItemSelected = null;

    private InventoryItemDisplay InventoryItemDrag = null;
    private Vector3 InventoryItemDragDefaultPosition;
    private InventoryItemDisplay InventoryItemDrop = null;


    void Start()
    {
        scroller.Delegate = this;
    }
    
    void Update()
    {
        if (InventoryItemDrag == null)
        {
            return;
        }
        InventoryItemDrag.transform.position = Input.mousePosition;
    }

    public void setItemList(List<InventoryItemData> InventoryItemDatas)
    {
        this.InventoryItemDatas = InventoryItemDatas;
        LoadData();
    }

    private void LoadData(int jump=-1)
    {
        if ((jump == -1) || (jump > InventoryItemDatas.Count))
        {
            jump = InventoryItemDatas.Count;
        } 
        scroller.ReloadData();
        scroller.JumpToDataIndex(jump);
    }

    public int GetNumberOfCells(EnhancedScroller scroller)
    {
        return Mathf.CeilToInt((float) InventoryItemDatas.Count / (float) numberOfCellsPerRow);
    }

    public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        return 100f;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
    {
        CellView cellView = scroller.GetCellView(cellViewPrefab) as CellView;

        cellView.name = "Cell " + (dataIndex * numberOfCellsPerRow).ToString() + " to " +
                        ((dataIndex * numberOfCellsPerRow) + numberOfCellsPerRow - 1).ToString();

        List<InventoryItemDisplay> iid = cellView.SetData(ref InventoryItemDatas, dataIndex * numberOfCellsPerRow);
        foreach (InventoryItemDisplay item in iid)
        {
            item.OnItemBeginDrag += HandleBeginDrag;
            item.OnItemDroppedOn += HandleSwap;
            item.OnItemEndDrag += HandleEndDrag;
            item.OnItemClicked += HandleClick;
        }
        return cellView;
    }
    
    private void HandleBeginDrag(InventoryItemDisplay inventoryItemUI)
    {        
        int index = InventoryItemDatas.IndexOf(inventoryItemUI.item);
        if (index == -1)
            return;
        InventoryItemDrag = inventoryItemUI;
        InventoryItemDragDefaultPosition = inventoryItemUI.transform.position;
        inventoryItemUI.GetComponent<Graphic>().color = new Color32(255,255,255,160);
    }   
    
    private void HandleSwap(InventoryItemDisplay inventoryItemUI)
    {
        int index = InventoryItemDatas.IndexOf(inventoryItemUI.item);
        if (index == -1)
            return;
        InventoryItemDrop = inventoryItemUI;
    }
    
    private void HandleEndDrag(InventoryItemDisplay inventoryItemUI)
    {
        int index = InventoryItemDatas.IndexOf(inventoryItemUI.item);
        if (index == -1)
            return;
        Swap();
        ResetDraggedItem();
        if (InventoryItemSelected == inventoryItemUI)
        {
            inventoryItemUI.GetComponent<Graphic>().color = Color.red;
        }
        else
        {
            inventoryItemUI.GetComponent<Graphic>().color = Color.white;
        }
    }
    
    private void Swap()
    {
        // Debug.Log("drag " +dragIndex);
        // Debug.Log("drop " +dropIndex);
        //
        InventoryItemDrag.transform.position = InventoryItemDrop.transform.position;
        InventoryItemDrop.transform.position = InventoryItemDragDefaultPosition;
        
        // InventoryItemDisplay drag = InventoryItemDrag;
        // InventoryItemDrag = InventoryItemDrop;
        // InventoryItemDrop = drag;
    }
    
    private void ResetDraggedItem()
    {
        InventoryItemDrag = null;
        InventoryItemDrag = null;
    }
    
    private void HandleClick(InventoryItemDisplay inventoryItemUI)
    {
        int index = InventoryItemDatas.IndexOf(inventoryItemUI.item);
        if (index == -1)
            return;
        if (InventoryItemSelected)
        {
            InventoryItemSelected.GetComponent<Graphic>().color = Color.white;
        }
        InventoryItemSelected = inventoryItemUI;
        InventoryItemSelected.GetComponent<Graphic>().color = Color.red;
    }
    
    public int deleteItem()
    {
        int index = InventoryItemDatas.IndexOf(InventoryItemSelected.item);
        if (InventoryItemSelected == null || index == -1)
        {
            return -1;
        }
        InventoryItemDatas.RemoveAt(index);
        
        Destroy(InventoryItemSelected.gameObject);
        InventoryItemSelected = null;
        
        LoadData(index - 1);
        
        return index;
    }
}