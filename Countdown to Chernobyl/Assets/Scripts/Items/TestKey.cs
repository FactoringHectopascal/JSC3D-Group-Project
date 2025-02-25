using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class TestKey : Item
{
    public TestKey()
    {
        icon = Resources.Load<Sprite>("Icons/Circle");
        itemName = "Test Key";
        descriptionEasy = "Key used for testing/implementing an item system, you can use it on the door.";
        descriptionMedium = "This is a key, that goes to a door.";
        descriptionHard = "A key";
        isConsumable = true;
    }

    public override void OnCombine()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Interaction>().talking == false)
            GameObject.FindGameObjectWithTag("Player").GetComponent<Interaction>().StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<Interaction>().TypewriterEffect("Wow! I made a key. That's so cool."));
    }
}

