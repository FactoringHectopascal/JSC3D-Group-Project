using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{

    public string easyThought;
    public string mediumThought;
    public string hardThought;
    public string objName;
    public string playerIntTextEasy;
    public string PlayerIntTextMedium;
    public string PlayerIntTextHard;
    public bool isInteractableAgain = true;

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
        if (GameObject.FindGameObjectWithTag("Difficulty Handler").GetComponent<DifficultyHandler>().difficulty == 1)
            return playerIntTextEasy;
        if (GameObject.FindGameObjectWithTag("Difficulty Handler").GetComponent<DifficultyHandler>().difficulty == 2)
            return PlayerIntTextMedium;
        if (GameObject.FindGameObjectWithTag("Difficulty Handler").GetComponent<DifficultyHandler>().difficulty == 3)
            return PlayerIntTextHard;
        else return null;
    }
}

