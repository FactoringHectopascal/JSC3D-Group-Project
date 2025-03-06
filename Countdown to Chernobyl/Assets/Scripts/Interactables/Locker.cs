using UnityEngine;

public class Locker : Object
{

    public bool circlePuzzle;
    public bool keyPuzzle;

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

        if(circlePuzzle && GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationPuzzle)
            locked = false;

        if(keyPuzzle &&  GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().HasItem("Grey Key"))
        {
            Item _item = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().GetItem("Grey Key");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().RemoveItem(_item);
            locked = false;
        }

        if(!locked)
        {
            GetComponent<Animator>().Play("Open");
            if (interactionCount > 1)
            {
                playerIntTextEasy = "Well it's open.";
                PlayerIntTextMedium = "An open locker, good job me.";
                PlayerIntTextHard = "Wow. I really opened it didn't I?";
                easyThought = "I'm so cool, I got that locker open!";
                mediumThought = "That was nothin'!";
                hardThought = "Very interesting, I definitely knocked that one out of the park. I got that locker open all by myself!";
            }
        }
        
        
    }
}
