using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : Object
{

    bool usingThis = false;

    [SerializeField]
    int keypadNum;

    [SerializeField]
    int codeCount;

    bool unlocked = false;


    bool noMore = false;

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

        GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().usingThing = true;
        if (!unlocked)
        keypad.enabled = true;
        if(!unlocked)
        usingThis = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Using");
    }

    public void CodeCheck()
    {
        if (inputField.text == code && inputField.text.Length == codeCount && !noMore)
        {
            ResetCursor();
            keypad.enabled = false;
            unlocked = true;
            isInteractableAgain = false;
            playerIntTextEasy = "Aha! Get unlocked!";
            PlayerIntTextMedium = "That was nothin'";
            PlayerIntTextHard = "Got it open..";
            usingThis = false;
            if (keypadNum == 1)
                GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keypad1 = true;
            else if (keypadNum == 2)
            {
                GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keypad2 = true;

                Item _item = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().GetItem("First paper with shapes.");
                Item __item = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().GetItem("Second paper with shapes.");
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().RemoveItem(_item);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().RemoveItem(__item);
            }
            else if (keypadNum == 3)
                GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keypad3 = true;
            GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().usingThing = false;
            inputField.text = "";
            noMore = true;

        }
        else if (inputField.text != code && inputField.text != "" && inputField.text.Length == codeCount)
        {
            Debug.Log("Incorrect Buzzer");
            ResetCursor();
            inputField.text = "";
            keypad.enabled = false;
            usingThis = false;
            GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().usingThing = false;
            playerIntTextEasy = "Gotta find a code somewhere.";
            PlayerIntTextMedium = "Hmm... I need to find something to unlock this with.";
            PlayerIntTextHard = "Upsetting, to say the least.";
        }
    }

    private void Update()
    {
        VisionCheck();
        RangeCheck();
        CodeCheck();

        if (keypadNum == 1 && GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keypad1 == false)
        {
            isInteractableAgain = true;
            noMore = false;
        }
        else if (keypadNum == 2 && GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keypad2 == false)
        {
            isInteractableAgain = true;
            noMore = false;
        }
        else if (keypadNum == 3 && GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keypad3 == false)
        {
            isInteractableAgain = true;
            noMore = false;
        }
    }

    public void RangeCheck()
    {
        float distance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);

        if (distance > 4 && GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().usingThing && usingThis)
        {
            keypad.enabled = false;
            usingThis = false;
            ResetCursor();
            Debug.Log("Range");
            GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().usingThing = false;
        }
    }

    public void VisionCheck()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);
        if (Physics.Raycast(ray, out hit, 90) && hit.collider.gameObject != this.gameObject && GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().usingThing && usingThis)
        {
            keypad.enabled = false;
            usingThis = false;
            ResetCursor();
            Debug.Log("Vision");
            GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().usingThing = false;
        }
    }

    public void ResetCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
