using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{

    public Item equippedItem;
    public Item itemToCombine;

    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        
            items.Add(item);
            Debug.Log($"Picked up {item.GetName()}");
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
                if(!GetComponent<Interaction>().talking)
                GetComponent<Interaction>().StartCoroutine(GetComponent<Interaction>().TypewriterEffect("These items don't go together."));
                ClearItems();
            }
        }
        else
        {
            if(!GetComponent<Interaction>().talking)
            GetComponent<Interaction>().StartCoroutine(GetComponent<Interaction>().TypewriterEffect("I can't combine this."));
            ClearItems();
        }
    }

    public bool HasItem(string itemName)
    {
        foreach (Item item in items)
        {
            if (item.GetName() == itemName)
            {
                return true;
            }
        }
        return false;
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

    public void Inspect()
    {
        if(equippedItem != null & itemToCombine == null && GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().difficulty == 1 && GetComponent<Interaction>().talking == false)
        GetComponent<Interaction>().StartCoroutine(GetComponent<Interaction>().TypewriterEffect(equippedItem.OnInspectEasy()));
        else if (equippedItem != null & itemToCombine == null && GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().difficulty == 2 && GetComponent<Interaction>().talking == false)
            GetComponent<Interaction>().StartCoroutine(GetComponent<Interaction>().TypewriterEffect(equippedItem.OnInspectMed()));
        else if (equippedItem != null & itemToCombine == null && GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().difficulty == 3 && GetComponent<Interaction>().talking == false)
            GetComponent<Interaction>().StartCoroutine(GetComponent<Interaction>().TypewriterEffect(equippedItem.OnInspectHard()));
    }
}
