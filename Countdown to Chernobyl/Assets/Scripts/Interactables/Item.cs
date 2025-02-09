using UnityEngine;

public class Item
{
    public Sprite icon;
    public string name;
    public string description;
    public bool isConsumable;

    public Sprite GetIcon()
    {
        return icon;
    }

    public string GetName()
    {
        return name;
    }

    public string GetDesc()
    {
        return description;
    }

    public bool CheckConsumable()
    {
        return isConsumable;
    }
}
