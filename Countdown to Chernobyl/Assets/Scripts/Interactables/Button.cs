using UnityEngine;

public class Button1 : Object
{
    public Button1()
    {
        easyThought = "A button, I think I can use this to interact with those screens.";
        mediumThought = "A button, I think pressing it does something.";
        hardThought = "Some kind of button.";
        objName = "Button";
        playerIntTextEasy = "Want some more!?";
        PlayerIntTextMedium = "Yah!";
        PlayerIntTextHard = "Preeeeess....";
    }

    public override void OnInteract()
    {
        GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screen3 = true;
        GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screen1 = false;
        if(interactionCount > 1)
            repeatDialogue = false;
    }
}
