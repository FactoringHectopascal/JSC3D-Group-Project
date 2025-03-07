
using UnityEngine;

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
    [SerializeField]
    UnityEngine.UI.Image imageSelection;
    [SerializeField]
    UnityEngine.UI.Image icon;

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
        if(inventory.equippedItem == null && inventory.itemToCombine == null)
            imageSelection.enabled = false;

    }

    public void EquipItem() // for the button
    {
        if (inventory.equippedItem == null)
        {
            inventory.EquipItem(item);
            Debug.Log($"Selected item: {item.GetName()}");
            imageSelection.enabled = true;
            item.OnEquip();
        }
        else if (inventory.equippedItem != item && inventory.itemToCombine != item)
        {
            inventory.SelectItem(item);
            Debug.Log($"Selected item to combine: {item.GetName()}");
            imageSelection.enabled = true;
            item.OnEquip();
        }
    }

    public void OpenSlots()
    {
    if (!disabled && eventH.isOpen)
    {
            image.enabled = true;
            button.enabled = true;
            if(item != null)
            icon.enabled = true;
            UnlockCursor();
    }
    else
    {
        if (image.enabled)
        {
            icon.enabled = false;
            image.enabled = false;
            button.enabled = false;
            inventory.ClearItems();
            ResetCursor();
        }
    }

        if (disabled)
        {
            icon.enabled = false;
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
            icon.sprite = null;
            disabled = true;
            return;
        }

        if (slotIndex < inventory.items.Count) // count doesn't return in zero index, so it will always be one higher than the slot index
        {
            item = inventory.items[slotIndex];
            icon.sprite = item.GetIcon();
            disabled = false;
        }
        else // if theres no item there
        {
            item = null;
            icon.sprite = null;
            disabled = true;
        }

        if (item != null && !inventory.items.Contains(item)) // if theres an item assigned here and its NOT in the inventory
        {
            item = null;
            icon.sprite = null;
            disabled = true;
        }
    }

}


