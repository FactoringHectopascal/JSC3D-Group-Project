using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ComboItemTest : Item
{
    public ComboItemTest()
    {
        itemName = "Combo Item";
        description = "Item used for testing the item combination system";
        isConsumable = false;
        isCombinable = true;
        itemCombinationName = "Combo Item 2";
        itemToGive = new TestKey();
    }
}
