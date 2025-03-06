using UnityEngine;

public class ShapePaperOBJ : Object
{

    public ShapePaperOBJ()
    {
        objName = "Shape Paper";
        easyThought = "A paper with some shapes on it, I could probably pick it up and press \"?\" in the item menu while I have it selected to examine it further.";
        mediumThought = "A sheet of paper, I should pick it up and press \"?\" in the item menu to inspect it.";
        hardThought = "A note, I bet I could examine this further in the item menu with \"?\"";
        playerIntTextEasy = "I'll be taking that.";
        PlayerIntTextMedium = "Thank youuuu...";
        PlayerIntTextHard = "Into my pocket you go!";
    }

    [SerializeField]
    int paperToGive;

    public override void OnInteract()
    {
        if(paperToGive == 1)
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddItem(new ShapePaper1());
            else if (paperToGive == 2)
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddItem(new ShapePaper2());
            else if (paperToGive == 3)
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddItem(new HexPaper());
            isCollected = true;
            MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.enabled = false;
            }
            GetComponent<BoxCollider>().enabled = false;

            if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keypad2 == false && !GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().HasItem("First paper with shapes.") && !GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().HasItem("Second paper with shapes."))
            {
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.enabled = true;
            }
                GetComponent<BoxCollider>().enabled = true;
                isCollected = false;
            }
    }
}
