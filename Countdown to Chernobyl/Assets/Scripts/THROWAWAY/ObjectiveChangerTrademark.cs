using TMPro;
using UnityEngine;

public class ObjectiveChangerTrademark : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().keycardScanned)
       {
            text.text = "Objective: Investigate the room.";
       } 
    }
}
