using UnityEngine;

public class Button2 : Object
{
    public Material[] material;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    public Button2()
    {
        easyThought = "A button, I think I can use this to interact with those screens.";
        mediumThought = "A button, I think pressing it does something.";
        hardThought = "Some kind of button.";
        objName = "Button";
        playerIntTextEasy = "Take that!";
        PlayerIntTextMedium = "Down we go.";
        PlayerIntTextHard = "Puuuuush.";
    }

    public override void OnInteract()
    {
        if (interactionCount > 1)
            repeatDialogue = false;
        GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screen1 = true;
        GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screen2 = true;
        GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screen3 = false;
    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screen2)
            rend.sharedMaterial = material[1];
                else rend.sharedMaterial = material[0];
    }
}
