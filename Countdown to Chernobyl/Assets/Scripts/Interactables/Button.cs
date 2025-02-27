using UnityEngine;

public class Button1 : Object
{

    [SerializeField]
    Material materialRed;
    [SerializeField]
    Material materialGreen;
    public Button1()
    {
        easyThought = "Huh, a computer. If I click it I think the colors on the monitor change.";
        mediumThought = "A computer. I think pressing the keyboard does something here.";
        hardThought = "Computer with a keyboard, I wonder if this thing has internet. Agh! What am I doing?";
        objName = "Computer";
        playerIntTextEasy = "Click.";
        PlayerIntTextMedium = "How hard could pushing a button be?";
        PlayerIntTextHard = "Preeeeess....";
    }

    public override void OnInteract()
    {
        GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screen3 = true;
        GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screen1 = false;
        
        if (interactionCount > 1)
            repeatDialogue = false;
    }

    private void Update()
    {

    }
}
