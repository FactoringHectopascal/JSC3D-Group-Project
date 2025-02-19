using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

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
}
