using UnityEngine;

public class Button3 : Object
{
    public Material[] material;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    public Button3()
    {
        easyThought = "A button, I think I can use this to interact with those screens.";
        mediumThought = "A button, I think pressing it does something.";
        hardThought = "Some kind of button.";
        objName = "Button";
        playerIntTextEasy = "You like that!?";
        PlayerIntTextMedium = "This button makes a satisfying noise when I click it.";
        PlayerIntTextHard = "Click....";
    }

    public override void OnInteract()
    {
        if (interactionCount > 1)
            repeatDialogue = false;
            if(!GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screenClear)
        GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screen1 = true;
        else isInteractableAgain = false;
    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().screen3)
            rend.sharedMaterial = material[1];
                else rend.sharedMaterial = material[0];
    }
}