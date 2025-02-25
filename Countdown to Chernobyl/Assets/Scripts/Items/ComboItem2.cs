using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ComboItem2 : Item
{
    public ComboItem2()
    {
        itemName = "Combo Item 2";
        description = "Item used for testing the item combination system, the second part to the whole.";
        isConsumable = false;
        isCombinable = true;
    }
}
