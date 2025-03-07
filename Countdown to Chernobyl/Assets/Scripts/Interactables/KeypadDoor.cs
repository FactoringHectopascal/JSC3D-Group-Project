
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (condition && keypadDoorNum != 0)
            GetComponent<Animator>().Play("DoorOpen");
            if (!condition && keypadDoorNum != 0)
            GetComponent<Animator>().Play("DoorClose");
    }

    public override void OnInteract()
    {
        if(keypadDoorNum == 0)
            SceneManager.LoadScene("Win");
    }
}
