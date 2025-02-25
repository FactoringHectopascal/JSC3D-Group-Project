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
        playerIntTextEasy = "I need to find my keycard, I'm useless without it!";
        PlayerIntTextMedium = "Huh... I can't do anything with this!";
        PlayerIntTextHard = "What am I doing? I can't scan in with my bare hand.";
    }

    public override void OnInteract()
    {

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().items.Contains(new Keycard()))
        {
            interactionCount = 1000;
            playerIntTextEasy = "Nice! I finally swiped in. Time to get in there.";
            PlayerIntTextMedium = "Finally.. Now I can get to work!";
            PlayerIntTextHard = "Cool. I'm all set.";
            GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keycardScanned = true;
        }

        if (interactionCount >= 4 && !GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().items.Contains(new Keycard()))
            interactionCount = 4;

        switch (interactionCount)
        {
            case 1:
                playerIntTextEasy = "I wasn't lying, I'm nothing without my keycard.";
                PlayerIntTextMedium = "I still can't do anything with this! My heart is hollow without my keycard..";
                PlayerIntTextHard = "Is there something wrong with me?";
                return;
            case 2:
                playerIntTextEasy = "I'm still useless! No man can bear the weight of this keycard-less existence!";
                PlayerIntTextMedium = "I said let's go! I can't do anything, it's killing me! I miss my keycard!";
                PlayerIntTextHard = "Did I hit my head or something? What am I still doing standing here?";
                return;
            case 3:
                playerIntTextEasy = "I've opened my soul up to the absurdity of the universe, I am fine living a meaningless existence. I find beauty in the disordered experience I live.";
                PlayerIntTextMedium = "I've come to accept that sometimes it's okay to sit around and soak in the atmosphere. It's just you and me keycard reader.";
                PlayerIntTextHard = "I think I need to go to the hospital.";
                return;
            case 4:
                playerIntTextEasy = "Okay, I actually need to go find my keycard now. Thanks for the philosophical journey, I feel the urge to read \"The Stranger\" now.";
                PlayerIntTextMedium = "Now that I've become an exponent of Stoic philosophy, I need to go find my keycard. Or not. I'm fine with whatever.";
                PlayerIntTextHard = "Keycard.. Need.. Keycard..";
                return;
        }
    }

    public override void OnInspect()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().items.Contains(new Keycard()))
        {
            easyThought = "Now that I found my keycard, I can use it here.";
            mediumThought = "Now that I have my keycard, it's time to swipe in.";
            hardThought = "I've got my keycard right here! Let's go.";
        } 
    }

}
