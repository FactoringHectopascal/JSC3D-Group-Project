using System;
using TMPro;
using UnityEngine;

public class TestObj : Item
{
    public TestObj()
    {
        easyThought = "Wow! This is a Test Object that is used for testing!";
        mediumThought = "This is an object I haven't seen before, I wonder if it has a use here?";
        hardThought = "What even is this thing?";
        objName = "Interesting Cube";
        playerIntTextEasy = "Did this thing just destroy that square?";
        PlayerIntTextMedium = "I feel like there's less shade here now.";
        PlayerIntTextHard = "What just happened?";
    }

    public override void OnInteract()
    {
        Debug.Log("Fine! If you want me to unlock that door so bad, then I will!");
        isInteractableAgain = false;
        GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().doorUnlocked = true;
        easyThought = "Oh sweet! Thanks for opening the door!";
        mediumThought = "That was a door?";
        hardThought = "Did this cube just say something?";
    }

}
