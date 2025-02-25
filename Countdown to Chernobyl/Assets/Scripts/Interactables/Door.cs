using UnityEngine;

public class Door : Object
{
    public Door()
    {
        easyThought = "Huh, a door. I think this needs a key. The doorknob is shaped like a capsule..";
        mediumThought = "A door. I think it needs some sort of key.";
        hardThought = "Just a door.";
        objName = "Test Door";
        playerIntTextEasy = "Still a door, shocking. I need that capsule key!";
        PlayerIntTextMedium = "Still a door, still in need of a key. Don't worry!";
        PlayerIntTextHard = "Still a door, still locked.";
    }

    public override void OnInteract()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().equippedItem != null && GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().equippedItem.GetName() == "Test Key")
        {
            Item item = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().GetItem("Test Key");
            playerIntTextEasy = "Easy!";
            PlayerIntTextMedium = "How did I unlock it using a key when there's no knob?";
            PlayerIntTextHard = "There it goes.";
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().RemoveItem(item);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().GetItem("Test Key") != null)
        {
            easyThought = "I think I can use that key I found here.";
            mediumThought = "I might be able to unlock this now.";
            hardThought = "Does this key go here?";
        }
    }
}
