using UnityEngine;

public class BlueCircle : Object
{
    public BlueCircle()
        {
        objName = "Blue Circle";
        easyThought = "A bright blue circle, it has a big red line, and a few black ones.";
        mediumThought = "Just a blue circle with some black lines, and a red one!";
        hardThought = "A blue circle with some lines.";
        playerIntTextEasy = "Is this one plastic? Worthless!";
        PlayerIntTextMedium = "This circle is plastic! The other ones are actual gold and silver! What gives! Get some Tanzanite!";
        PlayerIntTextHard = "Ew. Plastic. I don't want microplastics in my blood right now.";
        }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationB == 1)
            GetComponent<Animator>().Play("Rotation1B");
            if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationB == 2)
            GetComponent<Animator>().Play("Rotation2B");
            if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationB == 3)
            GetComponent<Animator>().Play("Rotation3B");
            if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationB == 4)
            GetComponent<Animator>().Play("Rotation4B");
    }
}
