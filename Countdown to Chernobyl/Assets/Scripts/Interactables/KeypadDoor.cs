using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class KeypadDoor : Door
{
    [SerializeField]
    int keypadDoorNum;
    void Start()
    {
        
    }

    private void Update()
    {

        if (keypadDoorNum == 1)
            condition = GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keypad1;
        else if (keypadDoorNum == 2)
            condition = GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keypad2;
        else if (keypadDoorNum == 3)
            condition = GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keypad3;
        if (condition)
            GetComponent<Animator>().Play("DoorOpen");
    }
}
