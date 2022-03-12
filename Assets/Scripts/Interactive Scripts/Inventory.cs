using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void addItem(Item _item)
    {
        itemList.Add(_item);
        //Debug.Log(itemList.Count);
    }

    public void removeItem(string _itemName)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].itemName == _itemName)
            {
                itemList.RemoveAt(i);
                Debug.Log("number of items in inventory: " + itemList.Count);
                return;
            }
        }

    }

    public bool contains(Item _item)
    {
        return itemList.Contains(_item);
    }

    public bool exists(string _itemName)
    {
        return itemList.Exists(e => e.itemName == _itemName);
    }

    public void inventoryList()
    {
        foreach (var item in itemList)
        {
            Debug.Log("item: " + item.itemName);
        }
    }
}
