using UnityEngine;

public class KeycardObj : Object
{
    public KeycardObj()
    {
        objName = "Keycard";
        easyThought = "My keycard!";
        mediumThought = "It's my keycard! I missed you!";
        hardThought = "It's you! It's really you!";
        playerIntTextEasy = "I'll be taking this back.";
        PlayerIntTextMedium = "Taking what's rightfully mine.";
        PlayerIntTextHard = "I must've dropped it.";
    }

    public override void OnInteract()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddItem(new Keycard());
        isCollected = true;
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.enabled = false;
            }

            GetComponent<BoxCollider>().enabled = false;
    }

    void Update()
    {
        if(!GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keycardScanned && !GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().HasItem("Keycard"))
        {
            MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.enabled = true;
            }

            GetComponent<BoxCollider>().enabled = true;
            isCollected = true;
        }
    }
}

