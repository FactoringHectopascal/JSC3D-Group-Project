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

    public override void OnEquip()
    {
            if(GameObject.FindGameObjectWithTag("Player").GetComponent<Interaction>().talking == false)
        GameObject.FindGameObjectWithTag("Player").GetComponent<Interaction>().StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<Interaction>().TypewriterEffect(description));
    }

    public override void OnCombine()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Interaction>().talking == false)
            GameObject.FindGameObjectWithTag("Player").GetComponent<Interaction>().StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<Interaction>().TypewriterEffect("Nice, fits perfect"));
    }
}

