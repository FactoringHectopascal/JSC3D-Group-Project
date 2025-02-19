using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class TestKey : Item
{
    public TestKey()
    {
        itemName = "Test Key";
        description = "Key used for testing/implementing an item system";
        isConsumable = true;
    }
}
