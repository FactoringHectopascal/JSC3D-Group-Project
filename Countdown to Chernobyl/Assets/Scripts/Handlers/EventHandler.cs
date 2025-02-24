using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public bool testDoorLock = true; // for testing a door
    public bool usingThing; // handles the player use state

    public bool screen1;
    public bool screen2;   
    public bool screen3;
    public bool screenClear;

    public bool isOpen = false;
    [SerializeField]
    public int difficulty;

    private void Update()
    {
        if (screen1 && screen2 && screen3)
            screenClear = true;
        if (screenClear)
            Debug.Log("Solved!");

        if(Input.GetKeyDown(KeyCode.G) && !isOpen)
            isOpen = true;
        else if(Input.GetKeyDown(KeyCode.G) && isOpen)
            isOpen = false;
        
    }

    private void Start()
    {
        isOpen = false;
        usingThing = false;
    }
}
