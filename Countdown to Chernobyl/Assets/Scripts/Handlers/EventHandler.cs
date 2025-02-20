using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public bool testDoorLock = true; // for testing a door
    public bool usingThing; // handles the player use state

    public bool screen1;
    public bool screen2;   
    public bool screen3;
    public bool screenClear;

    private void Update()
    {
        if (screen1 && screen2 && screen3)
            screenClear = true;
        if (screenClear)
            Debug.Log("Solved!");
    }
}
