using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;
public class Interaction : MonoBehaviour {

    [SerializeField]
    TextMeshProUGUI InteractText;
    [SerializeField]
    public TextMeshProUGUI ThinkText;
    bool talking;
    string cantInteract = "No point in touching this anymore.";

    // it repeats the same text if the player interacts with something twice, may need to implement second dialogue function for multiple interaction

    void Update()
    {
            RaycastHit hit;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);
			if (Physics.Raycast(ray, out hit, 3) && hit.collider.tag == "Interactable")
            {
                InteractText.enabled = true;

            if (Input.GetKeyDown(KeyCode.E) && hit.collider.GetComponent<Item>().isInteractableAgain == true)
            {
                hit.collider.GetComponent<Item>().OnInteract();


                if (hit.collider.GetComponent<Item>().OnInteractText() != "" && talking == false)
                    StartCoroutine(TypewriterEffect(hit.collider.GetComponent<Item>().OnInteractText(), ThinkText));
            }
            else if (Input.GetKeyDown(KeyCode.E) && hit.collider.GetComponent<Item>().isInteractableAgain == false && talking == false)
                StartCoroutine(TypewriterEffect(cantInteract, ThinkText));

            if (Input.GetKeyDown(KeyCode.I) && talking == false)
                {
                    StartCoroutine(TypewriterEffect(hit.collider.GetComponent<Item>().OnThink(), ThinkText));
                    Debug.Log("Started!");
                }
    }
            else
            {
                InteractText.enabled = false;
            }
    }

    public IEnumerator TypewriterEffect(string text, TextMeshProUGUI tText)
    {
        talking = true;
        tText.enabled = true;

        foreach(char c in text)
        {
            tText.text = tText.text + c;
            yield return new WaitForSeconds(.03f);
        }
        yield return new WaitForSeconds(3);
        tText.text = "";
        tText.enabled = false;
        talking = false;
        StopCoroutine(TypewriterEffect(text, tText));
    }
}
