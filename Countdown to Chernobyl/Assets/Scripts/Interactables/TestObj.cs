using System;
using TMPro;
using UnityEngine;

public class TestObj : Item
{
    public TestObj()
    {
        easyThought = "This square looks awfully interactable, I wonder if it has to do with that door?";
        mediumThought = "I wonder if I can use this square for something? Actually, isn't it a cube?";
        hardThought = "Hmm.. A cube?";
        objName = "Interesting Cube";
        playerIntTextEasy = "Yes! I got that door unlocked!";
        PlayerIntTextMedium = "I think I just unlocked something.";
        PlayerIntTextHard = "I think I heard something click.";
    }

    public override void OnInteract()
    {
        isInteractableAgain = false;
        GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().testDoorLock = false;
        easyThought = "It seems like I got that door open!";
        mediumThought = "I think it unlocked something.";
        hardThought = "Was this a part of a mechanism?";
    }
}
