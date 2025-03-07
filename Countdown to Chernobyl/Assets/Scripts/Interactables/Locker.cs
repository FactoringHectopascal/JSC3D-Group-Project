
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
        {
            playerIntTextEasy = "Nice! I got it open. Let's see what's inside.";
            PlayerIntTextMedium = "Alright cool, time to see what's in here.";
            PlayerIntTextHard = "Sick! I got it open! Now let's see what's in here.";
            locked = false;
        }

        if(keyPuzzle &&  GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().HasItem("Grey Key"))
        {
            playerIntTextEasy = "Ah cool! I got it! Now I can pitch this key.";
            PlayerIntTextMedium = "Sweet! I found out where to use this key! Now I can toss it.";
            PlayerIntTextHard = "Heck yeah! Let's see what's in here and get going.";
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

    void Update()
    {
        if(keyPuzzle &&  GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().HasItem("Grey Key"))
        {
            playerIntTextEasy = "Nice! I got it open using the key. Now let's check what's in here.";
                PlayerIntTextMedium = "Awesome, the key was perfect for that lock! Now I can pitch it. Let's see what's in here.";
                PlayerIntTextHard = "Very cool, I got that locker open using the key that I smashed together. Let's see what's in her- oh yeah, I don't need this anymore.";
        }
    }
}
