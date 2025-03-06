using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public bool usingThing; // handles the player use state

    public bool screen1;
    public bool screen2;   
    public bool screen3;
    public bool screenClear;
    public bool controlRoomDrawerOpen;

    public int rotationG;
    public int rotationB;
    public int rotationS;

    public bool rotationPuzzle = false;

    public bool keypad1;
    public bool keypad2;
    public bool keypad3;

    public bool isOpen = false;
    [SerializeField]
    public int difficulty;

    public bool keycardScanned;

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
        

        if(rotationG > 3)
            rotationG = 0;
        if(rotationS > 3)
            rotationS = 0;
        if(rotationB > 3)
            rotationB = 0;

            if(rotationG == 2 && rotationS == 2 && rotationB == 3)
                rotationPuzzle = true;

    }

    private void Start()
    {
        isOpen = false;
        usingThing = false;
    }
}
