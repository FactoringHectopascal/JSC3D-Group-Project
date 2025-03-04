using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvMenuBehavior : MonoBehaviour
{
    EventHandler eventH;
    GameObject eH;
    Image image;
    TextMeshProUGUI textMeshPro;

    void Start()
    {
        eH = GameObject.FindGameObjectWithTag("Event Handler");

        if (eH != null)
            eventH = eH.GetComponent<EventHandler>();
        else
            Debug.LogError("Event Handler GameObject not found! Make sure it exists and has the correct tag.");

        TryGetComponent(out image);
        TryGetComponent(out textMeshPro);
    }

    void Update() // ? Now properly recognized by Unity
    {
        if (eventH == null)
        {
            Debug.LogError("eventH is null! Check if the Event Handler GameObject exists and has the EventHandler script.");
            return;
        }

        if (image != null)
            image.enabled = eventH.isOpen;

        if (textMeshPro != null)
            textMeshPro.enabled = eventH.isOpen;
    }
}
