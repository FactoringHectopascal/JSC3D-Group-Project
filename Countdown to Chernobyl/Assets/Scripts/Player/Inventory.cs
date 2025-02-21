using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public Item equippedItem;
    public Item itemToCombine;

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
        if (equippedItem != null && equippedItem.CheckCombinable() && itemToCombine != null)
        {
            if (itemToCombine.GetName() == equippedItem.ItemNeeded())
            {
                AddItem(equippedItem.ItemResult());
                equippedItem.ItemResult().OnCombine();
                RemoveItem(itemToCombine);
                RemoveItem(equippedItem);
            }
            else
            {
                Debug.Log("You can't combine these!");
                ClearItems();
            }
        }
        else
        {
            Debug.Log("Can't combine like this!");
            ClearItems();
        }
    }

    public void ClearItems()
    {
        equippedItem = null;
        itemToCombine = null;
    }

    public void EquipItem(Item item)
    {
        equippedItem = item;
    }

    public void SelectItem(Item item)
    {
        itemToCombine = item;
    }

    private void Update()
    {
        if (!items.Contains(equippedItem))
            equippedItem = null;
        if (!items.Contains(itemToCombine))
            itemToCombine = null;
    }
}
