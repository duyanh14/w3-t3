using UnityEngine;
using UnityEngine.UI;
using EnhancedUI.EnhancedScroller;
using EnhancedUI;
using System;
using System.Collections.Generic;

public class CellView : EnhancedScrollerCellView
{
    public InventoryItemDisplay[] rowCellViews;

    public List<InventoryItemDisplay> SetData(ref List<InventoryItemData> data, int startingIndex)
    {
        List<InventoryItemDisplay> list = new List<InventoryItemDisplay>();
        for (var i = 0; i < rowCellViews.Length; i++)
        {
            if (startingIndex + i >= data.Count)
            {
                continue;
            }
            rowCellViews[i].setItem(data[startingIndex + i]);
            list.Add(rowCellViews[i]);
        }
        return list;
    }
}