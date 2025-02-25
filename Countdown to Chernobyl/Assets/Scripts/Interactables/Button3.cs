using UnityEngine;

public class Button3 : Object
{
    public Button3()
    {
        easyThought = "A button, I think I can use this to interact with those screens.";
        mediumThought = "A button, I think pressing it does something.";
        hardThought = "Some kind of button.";
        objName = "Button";
        playerIntTextEasy = "You like that!?";
        PlayerIntTextMedium = "This button makes a satisfying noise when I click it.";
        PlayerIntTextHard = "Click....";
    }

    public override void OnInteract()
    {
        if (interactionCount > 1)
            repeatDialogue = false;
        GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screen1 = true;
    }
}