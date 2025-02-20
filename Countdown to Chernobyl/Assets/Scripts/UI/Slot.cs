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

    private void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
        button = GetComponent<UnityEngine.UI.Button>();
    }

    private void Update()
    {
        if (inventory.items.Count != slotIndex && inventory.items.Count >= slotIndex) // why does this work??
        {
            item = inventory.items[slotIndex];
            image.enabled = true;
            button.enabled = true;
        }
        if (inventory.items.Contains(item) == false)
        {
            item = null;
            image.enabled = false;
            button.enabled = false;
        }
    }

    public void EquipItem()
    {
        inventory.EquipItem(item);
    }
}

