using UnityEngine;

public class KeyBow : Object
{

    public KeyBow()
    {
        isCollected = false;
    }

    public override void OnInteract()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddItem(new BowKey());
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
        if(!isCollected && !GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().HasItem("Bow of a Key"))
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
