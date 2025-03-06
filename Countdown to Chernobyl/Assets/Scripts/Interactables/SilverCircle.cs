using UnityEngine;

public class SilverCircle : Object
{

    public SilverCircle()
        {
        objName = "Silver Circle";
        easyThought = "A silver circle with black lines, and a very eye-catching red.";
        mediumThought = "A silver circle with black lines, and one red one.";
        hardThought = "A silver circle with some lines.";
        playerIntTextEasy = "I might be able to turn this one, but I don't want to try.";
        PlayerIntTextMedium = "This one is silver, maybe I should pack this one and the gold one?";
        PlayerIntTextHard = "I want to turn this wheel so bad.";
        }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationS == 1)
            GetComponent<Animator>().Play("Rotation1");
            if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationS == 2)
            GetComponent<Animator>().Play("Rotation2");
            if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationS == 3)
            GetComponent<Animator>().Play("Rotation3");
            if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationS == 4)
            GetComponent<Animator>().Play("Rotation4");
    }
}
