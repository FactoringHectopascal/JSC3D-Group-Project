using UnityEngine;

public class Ruminol : Object
{
    public Ruminol()
    {
        objName = "Ruminol";
    }

    public override void OnInteract()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddItem(new RuminolBottle());
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.enabled = false;
            }

            GetComponent<BoxCollider>().enabled = false;
        isCollected = true;
    }

    void Update()
    {
        if(!isCollected && !GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().HasItem("Ruminol"))
        {
            MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.enabled = true;
            }

            GetComponent<BoxCollider>().enabled = true;
        }
    }
}
