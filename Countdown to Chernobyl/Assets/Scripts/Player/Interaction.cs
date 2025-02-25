using System.Collections;
using UnityEngine;
using TMPro;
public class Interaction : MonoBehaviour {

    [SerializeField]
    TextMeshProUGUI InteractText;
    [SerializeField]
    public TextMeshProUGUI ThinkText;
    public bool talking;
    string cantInteract = "No point in touching this anymore.";

    // it repeats the same text if the player interacts with something twice, may need to implement second dialogue function for multiple interaction

    void Update()
    {
        RaycastInteract();
    }

    public IEnumerator TypewriterEffect(string text)
    {
        talking = true;
        ThinkText.enabled = true;

        foreach(char c in text)
        {
            ThinkText.text += c;
            yield return new WaitForSeconds(.03f);
        }
        yield return new WaitForSeconds(1.3f);
        ThinkText.text = "";
        ThinkText.enabled = false;
        talking = false;
        StopCoroutine(TypewriterEffect(text));
    }

    public void RaycastInteract()
    {
            RaycastHit hit;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);

			if (Physics.Raycast(ray, out hit, 3) && hit.collider.tag == "Interactable" && GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().usingThing == false)
            {
                InteractText.enabled = true;

            if (Input.GetKeyDown(KeyCode.E) && hit.collider.GetComponent<Object>().isInteractableAgain == true && talking == false) // can't interact with objects while talking, might come up with better solution later
            {
                hit.collider.GetComponent<Object>().OnInteract();

                if (hit.collider.GetComponent<Object>().repeatDialogue == true && hit.collider.GetComponent<Object>().OnInteractText() != "" && talking == false)
                    StartCoroutine(TypewriterEffect(hit.collider.GetComponent<Object>().OnInteractText()));
            }
            else if (Input.GetKeyDown(KeyCode.E) && hit.collider.GetComponent<Object>().isInteractableAgain == false && talking == false)
                    StartCoroutine(TypewriterEffect(cantInteract));

                if (Input.GetKeyDown(KeyCode.I) && talking == false)
                    {
                        StartCoroutine(TypewriterEffect(hit.collider.GetComponent<Object>().OnThink()));
                    }
            }
            else
            {
                InteractText.enabled = false;
            }
    }
}
