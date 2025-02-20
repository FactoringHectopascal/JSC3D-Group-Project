using UnityEngine;
using UnityEngine.UI;

public class Item
{
    [SerializeField]
    public Sprite icon;
    public string itemName;
    public string description;
    public bool isConsumable;
    public bool isCombinable;
    public string itemCombinationName;
    public Item itemToGive;

    public Sprite GetIcon()
    {
        return icon;
    }

    public string GetName()
    {
        return itemName;
    }

    public string GetDesc()
    {
        return description;
    }

    public bool CheckConsumable()
    {
        return isConsumable;
    }

    public bool CheckCombinable()
    {
        return isCombinable;
    }

    public string ItemNeeded()
    {
        return itemCombinationName;
    }

    public Item ItemResult()
    {
        return itemToGive;
    }
}
