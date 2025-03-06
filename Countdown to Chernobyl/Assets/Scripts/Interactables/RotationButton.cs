using UnityEngine;

public class RotationButton : Object
{
    public int assignedCircle;

    public override void OnInteract()
    {
            if(assignedCircle == 1)
            GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationG++;
            else if(assignedCircle == 2)
            GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationB++;
            else if(assignedCircle == 3)
            GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().rotationS++;
            repeatDialogue = false;
    }
}
