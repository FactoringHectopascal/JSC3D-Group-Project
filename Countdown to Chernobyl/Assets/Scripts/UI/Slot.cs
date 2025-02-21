using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Slot : MonoBehaviour
{
    [SerializeField]
    public Item item;
    public int slotIndex;
    UnityEngine.UI.Image image;
    GameObject player;
    Inventory inventory;
    UnityEngine.UI.Button button;
    bool disabled;
    GameObject eH;
    EventHandler eventH;

    private void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
        button = GetComponent<UnityEngine.UI.Button>();
        eH = GameObject.FindGameObjectWithTag("Event Handler");
        eventH = eH.GetComponent<EventHandler>();
    }

    private void Update()
    {
        OpenSlots();
        PopulateSlot();
    }

    public void EquipItem() // for the button
    {
        inventory.EquipItem(item);
    }

    public void OpenSlots()
    {
    if (!disabled && eventH.isOpen)
    {
            image.enabled = true;
            button.enabled = true;
            UnlockCursor();
    }
    else
    {
        if (image.enabled)
        {
            image.enabled = false;
            button.enabled = false;
            ResetCursor();
        }
    }

        if (disabled)
        {
        image.enabled = false;
        button.enabled = false;
        }
    }

   
    public void ResetCursor()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }

    public void PopulateSlot()
    {
        if (inventory.items == null || inventory.items.Count == 0) // if the inventory is empty or if the inventory is empty (lol)
        {
            item = null;
            disabled = true;
            return;
        }

        if (slotIndex < inventory.items.Count) // count doesn't return in zero index, so it will always be one higher than the slot index
        {
            item = inventory.items[slotIndex];
            disabled = false;
        }
        else // if theres no item there
        {
            item = null;
            disabled = true;
        }

        if (item != null && !inventory.items.Contains(item)) // if theres an item assigned here and its NOT in the inventory
        {
            item = null;
            disabled = true;
        }
    }
}


