using UnityEngine;

public class Drawer : Object
{
    public Drawer()
    {
        objName = "Drawer";
        easyThought = "A desk drawer, right now I can't seem to get it open. Maybe if I get these monitors right?";
        mediumThought = "A drawer. It appears to be locked, maybe it's part of a mechanism?";
        hardThought = "A pull-out drawer, I can't seem to pull-it-out though.";
        playerIntTextEasy = "HRAAAAAGHHHH!! Nope, won't budge.";
        PlayerIntTextMedium = "HNNNNGGGGGHHHH!!! Hah, nope. Not opening.";
        PlayerIntTextHard = "ARGHHHHHHH...!!! Stupid thing won't open!";
    }

    public override void OnInteract()
    {
        if (GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screenClear == true)
        {
            playerIntTextEasy = "Oh cool! Let's take a peek at what's in here.";
            PlayerIntTextMedium = "Here we go! Now let's see..";
            PlayerIntTextHard = "Nice! I got it open!";
            GetComponent<Animator>().Play("Pullout");
        }    
    }

    public override void OnInspect()
    {
        if (GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screenClear == true)
        {
            easyThought = "I should definitely try the handle now that I've got that puzzle solved.";
            mediumThought = "I think I might be able to open it now.";
            hardThought = "Are you still locked? Better not be, if I solved that for nothing...";
        }
    }
}
