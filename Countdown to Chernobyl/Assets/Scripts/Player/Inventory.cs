using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    Item equippedItem;
    Item itemToCombine;

    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        if (items.Count == 3)
            Debug.Log("You are carrying too much!");
        else
        {
            items.Add(item);
            Debug.Log($"Picked up {item.GetName()}");
        }
    }

    public Item GetItem(string itemName)
    {
        foreach(Item item in items)
        {
            if(item.GetName() == itemName)
            {
                return item;
            }
        }
        return null;
    }

    public void RemoveItem(Item item)
    {
        if(items.Contains(item))
        {
            items.Remove(item);
            Debug.Log($"Removed {item.GetName()}");
        }
    }

    public void CombineItems()
    {
        if(equippedItem.CheckCombinable())
        {
            if (itemToCombine.GetName() == equippedItem.ItemNeeded())
            {
                AddItem(equippedItem.ItemResult());
                RemoveItem(itemToCombine);
                RemoveItem(equippedItem);
            }
            else Debug.Log("You can't combine this!");
        }
        else Debug.Log("This item can't be used for combination!");
    }

    public void EquipItem(Item item)
    {
        item = equippedItem;
    }
}
