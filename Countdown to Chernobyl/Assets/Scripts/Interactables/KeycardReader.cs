using Unity.VisualScripting;
using UnityEngine;

public class KeycardReader : Object
{
    public KeycardReader()
    {
        objName = "Keycard Reader";
        easyThought = "A keycard reader, I need to find my keycard to scan in.";
        mediumThought = "The keycard reader, I need my keycard to scan in.";
        hardThought = "The keycard reader, I need my keycard.";
        playerIntTextEasy = "I can't scan in without my keycard.";
        PlayerIntTextMedium = "Huh... I can't do anything with this!";
        PlayerIntTextHard = "What am I doing? I can't scan in with my bare hand.";
    }

    public override void OnInteract()
    {

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().equippedItem != null && GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().equippedItem.GetName() == "Keycard")
        { 
            interactionCount = 1000;
            playerIntTextEasy = "Nice!";
            PlayerIntTextMedium = "Finally..";
            PlayerIntTextHard = "Cool.";
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().RemoveItem(GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().GetItem("Keycard"));
            GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keycardScanned = true;
        }

        if (interactionCount >= 5 && !GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keycardScanned && !GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().HasItem("Keycard"))
            interactionCount = 5;

        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().HasItem("Keycard"))
        {
            interactionCount = 1000;
            playerIntTextEasy = "I have my keycard, I just need to use it. I should probably try pressing G and clicking the keycard icon, then interacting with the keycard reader.";
            PlayerIntTextMedium = "I need to equip my keycard, I should try pressing G and then clicking it. After that I should be all set to interact with the reader.";
            PlayerIntTextHard = "I need to press G and click my keycard to equip it so I can interact with the reader here.";
        }

        switch (interactionCount)
        {
            case 2:
                playerIntTextEasy = "I really need that keycard! What am I without it?";
                PlayerIntTextMedium = "I still can't do anything with this! My heart is hollow without my keycard..";
                PlayerIntTextHard = "Is there something wrong with me?";
                return;
            case 3:
                playerIntTextEasy = "I'm still useless! No man can bear the weight of this keycard-less existence!";
                PlayerIntTextMedium = "I said let's go! I can't do anything, it's killing me! I miss my keycard!";
                PlayerIntTextHard = "Did I hit my head or something? What am I still doing standing here?";
                return;
            case 4:
                playerIntTextEasy = "I've opened my soul up to the absurdity of the universe, I am fine living a meaningless existence. I find beauty in the disordered experience I live.";
                PlayerIntTextMedium = "I've come to accept that sometimes it's okay to sit around and soak in the atmosphere. It's just you and me keycard reader.";
                PlayerIntTextHard = "I think I need to go to the hospital.";
                return;
            case 5:
                playerIntTextEasy = "Okay, it's time to stop waxing philosophical and find my keycard!";
                PlayerIntTextMedium = "Now that I've become an exponent of Stoic philosophy, I need to go find my keycard. Or not. I'm fine with whatever.";
                PlayerIntTextHard = "Keycard.. Need.. Keycard..";
                return;
        }
    }

    public override void OnInspect()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().HasItem("Keycard"))
        {
            easyThought = "Now that I found my keycard, I can use it here.";
            mediumThought = "Now that I have my keycard, it's time to swipe in.";
            hardThought = "I've got my keycard right here! Let's go.";
        } 
    }

}
