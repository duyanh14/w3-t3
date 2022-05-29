using System;
using EnhancedUI.EnhancedScroller;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class InventoryItemDisplay :  EnhancedScrollerCellView,  IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler, IPointerClickHandler
{
    public InventoryItemData item;

    public Image image;
    public TMP_Text quantity;

    public event Action<InventoryItemDisplay> OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag , OnItemClicked;

    void Start()
    {
        if (item)
        {
            setItem(item);
        }
    }

    public void setItem(InventoryItemData item)
    {
        if (item == null)
        {
            return;
        }
        this.item = item;
        quantity.text = item.quantity.ToString();
        image.sprite = item.image;
        GetComponent<Graphic>().color = Color.white;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        OnItemClicked.Invoke(this);  
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        OnItemBeginDrag.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        OnItemEndDrag.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(item.id);
        OnItemDroppedOn.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}
