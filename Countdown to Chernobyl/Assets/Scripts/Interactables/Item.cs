using UnityEngine;

public class Item
{
    [SerializeField]
    public Sprite icon;
    public string itemName;
    public string descriptionEasy;
    public string descriptionMedium;
    public string descriptionHard;
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

    public virtual void OnEquip()
    {

    }
    
    public virtual void OnCombine()
    {

    }

    public virtual string OnInspectEasy()
    {
        return descriptionEasy;
    }

    public virtual string OnInspectMed()
    {
        return descriptionMedium;
    }

    public virtual string OnInspectHard()
    {
        return descriptionHard;
    }
}
