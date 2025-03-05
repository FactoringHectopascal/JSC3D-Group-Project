using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvMenuBehavior : MonoBehaviour
{
    EventHandler eventH;
    GameObject eH;
    Image image;
    TMPro.TextMeshProUGUI textMeshPro;
    Button button;

    void Start()
    {
        eH = GameObject.FindGameObjectWithTag("Event Handler");
        eventH = eH.GetComponent<EventHandler>();
        TryGetComponent<Image>(out Image _Image);
        if (_Image != null)
            image = _Image;
        TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI _textMeshPro);
        if (_textMeshPro != null)
            textMeshPro = _textMeshPro;
        TryGetComponent<Button>(out Button _button);
        if(_button != null)
            button = _button;
            
    }

    // Update is called once per frame
    void Update()
    {
        if (eventH.isOpen && image != null)
        {
            image.enabled = true;
            

        }
        else if (!eventH.isOpen && image != null)
            image.enabled = false;
        if (eventH.isOpen && textMeshPro != null)
            textMeshPro.enabled = true;
        else if (!eventH.isOpen && textMeshPro != null)
            textMeshPro.enabled = false;
    }
}