using UnityEngine;

public class GoldCircle : Object
{       
    public GoldCircle()
        {
        objName = "Gold Circle";
        easyThought = "A pure gold circle with lines, the red is especially prominent.";
        mediumThought = "A real gold circle with black lines, and a red one.";
        hardThought = "A golden circle with some lines.";
        playerIntTextEasy = "I can't turn it with my hands! I need to use the buttons over there.";
        PlayerIntTextMedium = "GRRRRRRAAAAAHHH..!! Hah.. Hah.. I can't turn it.";
        PlayerIntTextHard = "I'm not even gonna bother trying to turn this PURE GOLD circle.";
        }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationG == 1)
            GetComponent<Animator>().Play("Rotation1G");
            if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationG == 2)
            GetComponent<Animator>().Play("Rotation2G");
            if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationG == 3)
            GetComponent<Animator>().Play("Rotation3G");
            if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationG == 4)
            GetComponent<Animator>().Play("Rotation4G");
    }

}
