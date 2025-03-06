using System.Threading;
using UnityEngine;

public class Drawer : Object
{
    [SerializeField]
    bool locked;

    [SerializeField]
    bool monitorDrawer;


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
        if (GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screenClear == true || !locked && !monitorDrawer)
        {
            GetComponent<Animator>().Play("Pullout");
            isInteractableAgain = false;
        }    
        if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screenClear == true && monitorDrawer)
        {
            playerIntTextEasy = "Nice! I got it unlocked!";
            PlayerIntTextMedium = "Awesome! I got this unlocked!";
            PlayerIntTextHard = "Time to see what's in here.";
        }
    }

    public override void OnInspect()
    {
        if (GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screenClear == true && monitorDrawer)
        {
            easyThought = "I should definitely try the handle now that I've got that puzzle solved.";
            mediumThought = "I think I might be able to open it now.";
            hardThought = "Are you still locked? Better not be, if I solved that for nothing...";
        }
    }
}
