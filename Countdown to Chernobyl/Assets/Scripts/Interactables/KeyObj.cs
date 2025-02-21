using UnityEngine;

public class KeyObj : Object
{
    public KeyObj()
    {
        easyThought = "I think I can combine these items to make a key.";
        mediumThought = "Do these things go together?";
        hardThought = "Hmm... What's the purpose of this?";
        objName = "Test Key";
        playerIntTextEasy = "I'll combine these and make a key.";
        PlayerIntTextMedium = "I wonder if I can put these together.";
        PlayerIntTextHard = "Might as well pocket it.";
    }

    public override void OnInteract()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddItem(new ComboItemTest());
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddItem(new ComboItem2());
        Destroy(gameObject);
    }
}


