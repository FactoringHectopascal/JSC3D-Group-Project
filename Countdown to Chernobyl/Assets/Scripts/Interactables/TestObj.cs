using System;
using TMPro;
using UnityEngine;

public class TestObj : Object
{
    public TestObj()
    {
        easyThought = "This square looks awfully interactable, I wonder if it has to do with that door?";
        mediumThought = "I wonder if I can use this square for something? Actually, isn't it a cube?";
        hardThought = "Hmm.. A cube?";
        objName = "Interesting Cube";
        playerIntTextEasy = "Did this even do anything?";
        PlayerIntTextMedium = "Was this originally supposed to unlock something?";
        PlayerIntTextHard = "Why is this here?";
    }

    public override void OnInteract()
    {
        isInteractableAgain = false;
        GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().testDoorLock = false;
        easyThought = "Was this pointless?";
        mediumThought = "Absurd.";
        hardThought = "Stupid cube! Arghhh.. I'm so upset with you!";
    }
}
