using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class KeycardDoor : Door
{

    public KeycardDoor()
    {
        objName = "Keycard Door";
        easyThought = "The only thing standing between me and the control room!";
        mediumThought = "The only thing standing between me and another day of work.";
        hardThought = "If I can't get this door open, I'm just going home.";
        playerIntTextEasy = "I can't punch through it..";
        PlayerIntTextMedium = "Should I try punching through it? Agh! No! What am I thinking?";
        PlayerIntTextHard = "I bet I could punch through this, but I'm saving my strength for the Kaiju I have to fight later.";
    }

    private void Update()
    {
        condition = GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keycardScanned;
        if (condition)
            GetComponent<Animator>().Play("DoorOpen");
        if (!condition)
            GetComponent<Animator>().Play("DoorClose");
    }
}
