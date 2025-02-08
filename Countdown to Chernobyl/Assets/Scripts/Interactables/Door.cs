using UnityEngine;

public class Door : Item
{
    public Door()
    {
        easyThought = "Huh, a door. I think I need to interact with a square to get rid of it.";
        mediumThought = "A door. It doesn't seem to have a doorknob.";
        hardThought = "Just a door.";
        objName = "Test Door";
        playerIntTextEasy = "No dice. I think I need to interact with a square.";
        PlayerIntTextMedium = "Where do I even get started opening this? There's no knob!";
        PlayerIntTextHard = "Still a door, still locked.";
    }

    public override void OnInteract()
    {
        if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().testDoorLock == false)
        {
            playerIntTextEasy = "Nice! I got it open!";
            PlayerIntTextMedium = "So that's how a door without a knob works.";
            PlayerIntTextHard = "Interesting mechanism.";
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().testDoorLock == false)
        {
            easyThought = "This should be unlocked now!";
            mediumThought = "I think I can interact with this now.";
            hardThought = "Was this a part of the cube's mechanism?";
        }
    }
}
