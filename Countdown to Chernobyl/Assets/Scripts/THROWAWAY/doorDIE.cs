using UnityEngine;

public class doorDIE : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().doorUnlocked == true)
                Destroy(gameObject);
    }
}
