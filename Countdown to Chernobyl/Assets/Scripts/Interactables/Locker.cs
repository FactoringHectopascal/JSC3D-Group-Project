using UnityEngine;

public class Locker : Object
{

    public bool locked;
    public Locker()
    {
        objName = "Locker";
        easyThought = "A locker, I wonder if my keycard is in there.";
        mediumThought = "A locker, it appears to be unlocked.";
        hardThought = "Wow! I've never seen a locker like this before. Not.";
        playerIntTextEasy = "I wonder...";
        PlayerIntTextMedium = "Definitely Unlocked.";
        PlayerIntTextHard = "This ones unlocked..";
    }

    public override void OnInteract()
    {
        if(!locked)
        {
            GetComponent<Animator>().Play("Open");
            if (interactionCount > 1)
            {
                playerIntTextEasy = "Well it's open.";
                PlayerIntTextMedium = "Whose locker is this anyway?";
                PlayerIntTextHard = "Wow. Did someone sneak my keycard?";
                easyThought = "Someone is definitely getting written up for leaving their locker open.";
                mediumThought = "Who put MY keycard in THEIR locker? It has MY name on it!";
                hardThought = "Very interesting, I'm going to chew someone out later.";
            }
        }
        
        
    }
}
