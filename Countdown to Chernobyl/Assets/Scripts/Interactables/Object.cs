using TMPro;
using UnityEngine;

public class Object : MonoBehaviour
{

    public string easyThought;
    public string mediumThought;
    public string hardThought;
    public string objName;
    public string playerIntTextEasy;
    public string PlayerIntTextMedium;
    public string PlayerIntTextHard; // I capitalized this wrong but if I corrected it, it would take several scripts down with it and I would have to hunt them
    public bool isInteractableAgain = true; // leave this to true, if you want an item to only be interactable once, turn it off in its oninteract() function
    public bool repeatDialogue = true; // same thing here
    public int interactionCount;
    public virtual void OnInteract()
    {
  
    }

    public virtual string OnThink()
    {
        if (GameObject.FindGameObjectWithTag("Difficulty Handler").GetComponent<DifficultyHandler>().difficulty == 1)
            return easyThought;
        if (GameObject.FindGameObjectWithTag("Difficulty Handler").GetComponent<DifficultyHandler>().difficulty == 2)
            return mediumThought;
        if (GameObject.FindGameObjectWithTag("Difficulty Handler").GetComponent<DifficultyHandler>().difficulty == 3)
            return hardThought;
        else return null;
    }

    public virtual string OnInteractText()
    {
        interactionCount++;
        if (GameObject.FindGameObjectWithTag("Difficulty Handler").GetComponent<DifficultyHandler>().difficulty == 1)
            return playerIntTextEasy;
        if (GameObject.FindGameObjectWithTag("Difficulty Handler").GetComponent<DifficultyHandler>().difficulty == 2)
            return PlayerIntTextMedium;
        if (GameObject.FindGameObjectWithTag("Difficulty Handler").GetComponent<DifficultyHandler>().difficulty == 3)
            return PlayerIntTextHard;
        else return null;
    }
}

