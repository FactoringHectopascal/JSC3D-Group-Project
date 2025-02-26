using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : Object
{
    public Keypad()
    {
        easyThought = "It looks like I can put in a code here to unlock something.";
        mediumThought = "It looks like I can enter in a code here.";
        hardThought = "I think this is a keypad.. Hm.. What do keypads need again?";
        objName = "Keypad";
        playerIntTextEasy = "Time to enter in that code!";
        PlayerIntTextMedium = "Pushing buttons! Awesome!";
        PlayerIntTextHard = "Aghh.... How do I even USE this thing?";
    }

    public string code; // can randomly generate this for replayability
    public Canvas keypad;
    public TMP_InputField inputField;

    public override void OnInteract()
    {
        keypad.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().usingThing = true;
    }

    public void CodeCheck()
    {
        if (inputField.text == code && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("You did it!");
            ResetCursor();
            keypad.enabled = false;
            isInteractableAgain = false;
            GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().usingThing = false;
            playerIntTextEasy = "Aha! Get unlocked!";
            PlayerIntTextMedium = "That was nothin'";
            PlayerIntTextHard = "Got it open..";
        }
        else if (inputField.text != code && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Incorrect Buzzer");
            ResetCursor();
            inputField.text = "";
            keypad.enabled = false;
            GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().usingThing = false;
            playerIntTextEasy = "Gotta find a code somewhere.";
            PlayerIntTextMedium = "Hmm... I need to find something to unlock this with.";
            PlayerIntTextHard = "Upsetting, to say the least.";
        }
    }

    private void Update()
    {
        CodeCheck();
        RangeCheck();
        VisionCheck();
    }

    public void RangeCheck()
    {
        float distance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);

        if (distance > 4)
        {
            keypad.enabled = false;
            GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().usingThing = false;
            ResetCursor();
        }
    }

    public void VisionCheck()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);
        if (Physics.Raycast(ray, out hit, 90) && hit.collider.gameObject != this.gameObject)
        {
            keypad.enabled = false;
            ResetCursor();
            GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().usingThing = false;
        }

    }

    public void ResetCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
