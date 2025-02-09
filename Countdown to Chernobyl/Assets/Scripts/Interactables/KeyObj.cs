using UnityEngine;

public class KeyObj : Object
{
    public KeyObj()
    {
        easyThought = "A key! I think this might fit that door over there.";
        mediumThought = "A key. This looks like it might unlock something around here.";
        hardThought = "Nice, a key!";
        objName = "Test Key";
        playerIntTextEasy = "For me?";
        PlayerIntTextMedium = "I'll be taking that.";
        PlayerIntTextHard = "Might as well pocket it.";
    }

    public override void OnInteract()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddItem(new TestKey());
        Destroy(gameObject);
    }
}


