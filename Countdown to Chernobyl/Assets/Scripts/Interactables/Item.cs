using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    public Sprite icon;
    public string itemName;
    public string description;
    public bool isConsumable;

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
}
