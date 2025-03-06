using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using StarterAssets;
using NUnit.Framework;

public class SaveSystem : MonoBehaviour
{
    public GameObject player;
    public Inventory playerInventory;  // Reference to the Inventory
    private string saveFileName = "saveData.json";
    private string encryptionKey = "ForYou"; // Encryption key

    FirstPersonController firstPersonController;

    // Start method to find the FirstPersonController (if using Unity's Standard Assets)
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = player.GetComponent<Inventory>();
        firstPersonController = player.GetComponent<FirstPersonController>();
    }

    // Ensure the directory exists before saving or loading the file
    private void EnsureDirectoryExists()
    {
        string directoryPath = Application.persistentDataPath;

        // Create directory if it doesn't exist
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            Debug.Log("Directory created: " + directoryPath);
        }
    }

    // Get the full path where the save file will be stored
    private string GetSaveFilePath()
    {
        string path = Path.Combine(Application.persistentDataPath, saveFileName);
        Debug.Log("Save file path: " + path);  // Debugging to ensure the correct path
        return path;
    }

    // Save game data including inventory and player position
    public void SaveGame()
    {
        // Ensure the directory exists before saving the file
        EnsureDirectoryExists();

         string filePath = GetSaveFilePath();
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("Existing save file deleted.");
        }

        // Temporarily disable the FirstPersonController to ensure the position is saved correctly
        if (firstPersonController != null)
        {
            firstPersonController.enabled = false;
        }

        SaveData data = new SaveData();

        EventHandler eventHandler = GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>();
    if (eventHandler != null)
    {
        data.screen1 = eventHandler.screen1;
        data.screen2 = eventHandler.screen2;
        data.screen3 = eventHandler.screen3;
        data.screenClear = eventHandler.screenClear;
        data.isOpen = eventHandler.isOpen;
        data.usingThing = eventHandler.usingThing;
        data.rotationG = eventHandler.rotationG;
        data.rotationB = eventHandler.rotationB;
        data.rotationS = eventHandler.rotationS;
        data.keypad1 = eventHandler.keypad1;
        data.keypad2 = eventHandler.keypad2;
        data.keypad3 = eventHandler.keypad3;
        data.keycardScanned = eventHandler.keycardScanned;
    }

        // Save player position
        data.playerPosition = player.transform.position;

        // Save inventory items as SerializableItems
        foreach (var item in playerInventory.items)
        {
            data.inventory.Add(new SerializableItem(item));
        }

        // Convert to JSON
        string json = JsonUtility.ToJson(data, true);

        // Encrypt the JSON data
        string encryptedJson = XOREncrypt(json, encryptionKey);

        // Save the encrypted data to a file
        File.WriteAllText(GetSaveFilePath(), encryptedJson);

        Debug.Log("Game Saved!");

        // Re-enable the FirstPersonController
        if (firstPersonController != null)
        {
            firstPersonController.enabled = true;
        }
    }

    // Load game data including inventory and player position
    public void LoadGame()
    {
        // Temporarily disable the FirstPersonController to prevent movement during loading
            if (firstPersonController != null)
            {
                firstPersonController.enabled = false;
            }

        string filePath = GetSaveFilePath();
        if (File.Exists(filePath))
        {
            Debug.Log("Save file found at: " + filePath);

            string encryptedJson = File.ReadAllText(filePath);

            // Decrypt the JSON data
            string json = XOREncrypt(encryptedJson, encryptionKey);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            
            // Load player position
            player.transform.position = data.playerPosition;

            // Load inventory items
            playerInventory.items.Clear(); // Clear existing items
            foreach (var itemData in data.inventory)
            {
                Item item = itemData.ToItem();  // Reconstruct the Item from SerializableItem
                playerInventory.AddItem(item);  // Add items back to the player's inventory
            }

            EventHandler eventHandler = GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>();
            if (eventHandler != null)
            {
                eventHandler.screen1 = data.screen1;
                eventHandler.screen2 = data.screen2;
                eventHandler.screen3 = data.screen3;
                eventHandler.screenClear = data.screenClear;
                eventHandler.isOpen = data.isOpen;
                eventHandler.usingThing = data.usingThing;
                eventHandler.rotationG = data.rotationG;
                eventHandler.rotationB = data.rotationB;
                eventHandler.rotationS = data.rotationS;
                eventHandler.keypad1 = data.keypad1;
                eventHandler.keypad2 = data.keypad2;
                eventHandler.keypad3 = data.keypad3;
                eventHandler.keycardScanned = data.keycardScanned;
            }

            Debug.Log("Game Loaded!");

            // Re-enable the FirstPersonController
            if (firstPersonController != null)
            {
                firstPersonController.enabled = true;
            }
        }
        else
        {
            Debug.LogWarning("Save file not found at: " + filePath);
        }
    }

    // Delete save data
    public void DeleteSave()
    {
        string filePath = GetSaveFilePath();
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("Save file deleted.");
        }
        else
        {
            Debug.LogWarning("Save file not found to delete at: " + filePath);
        }
    }

    // XOR encryption/decryption function
    private string XOREncrypt(string data, string key)
    {
        char[] result = new char[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            result[i] = (char)(data[i] ^ key[i % key.Length]);  // XOR each character
        }

        return new string(result);  // Convert the result back to a string
    }

    // Example usage (can be triggered in Unity Inspector or on key press)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // Save on pressing "S"
        {
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.L)) // Load on pressing "L"
        {
            LoadGame();
        }
        if (Input.GetKeyDown(KeyCode.M)) // Delete on pressing "D"
        {
            DeleteSave();
        }
    }
}


[System.Serializable]
public class SerializableItem
{
    public string itemName;
    public string descriptionEasy;
    public string descriptionMedium;
    public string descriptionHard;
    public bool isConsumable;
    public bool isCombinable;
    public string itemCombinationName;
    public string itemToGiveName;  // Name of the item to give when combined
    public string iconPath;  // Path to sprite (for example, texture path)

    // Constructor to create SerializableItem from an Item
    public SerializableItem(Item item)
    {
        itemName = item.itemName;
        descriptionEasy = item.descriptionEasy;
        descriptionMedium = item.descriptionMedium;
        descriptionHard = item.descriptionHard;
        isConsumable = item.isConsumable;
        isCombinable = item.isCombinable;
        itemCombinationName = item.itemCombinationName;
        itemToGiveName = item.itemToGive != null ? item.itemToGive.itemName : "";
        iconPath = item.icon != null ? item.icon.name : "";  // Saving the name or path of the icon
    }

    // Method to convert back into an Item
    public Item ToItem()
    {
        Item newItem = new Item
        {
            itemName = this.itemName,
            descriptionEasy = this.descriptionEasy,
            descriptionMedium = this.descriptionMedium,
            descriptionHard = this.descriptionHard,
            isConsumable = this.isConsumable,
            isCombinable = this.isCombinable,
            itemCombinationName = this.itemCombinationName,
            itemToGive = string.IsNullOrEmpty(this.itemToGiveName) ? null : new Item() { itemName = this.itemToGiveName }, // Here we can assume it is another item (or you could load it by name)
            icon = Resources.Load<Sprite>("Icons/" + this.iconPath)  // Assuming icon is stored in Resources/Icons folder
        };

        return newItem;
    }
}

[System.Serializable]
public class SaveData
{
    public Vector3 playerPosition;
    public List<SerializableItem> inventory = new List<SerializableItem>();  // List to store items
    public List<SerializableObject> sceneObjects = new List<SerializableObject>();

    public bool screen1;
    public bool screen2;
    public bool screen3;
    public bool screenClear;
    public bool isOpen;
    public bool usingThing;
    public int rotationG;
    public int rotationB;
    public int rotationS;
    public bool keypad1;
    public bool keypad2;
    public bool keypad3;
    public bool keycardScanned;

    // Constructor to initialize event state (if needed)
    public SaveData()
    {
        // Initialize with default values
        screen1 = false;
        screen2 = false;
        screen3 = false;
        screenClear = false;
        isOpen = false;
        usingThing = false;
        rotationG = 0;
        rotationB = 0;
        rotationS = 0;
        keypad1 = false;
        keypad2 = false;
        keypad3 = false;
        keycardScanned = false;
    }
}

[System.Serializable]
public class SerializableObject
{
    public string objName;
    public bool isInteractableAgain;
    public bool repeatDialogue;
    public int interactionCount;
    public int inspectionCount;
    public bool isCollected;  // Track whether the object has been collected

    // Constructor to initialize from the Object
    public SerializableObject(Object obj)
    {
        objName = obj.objName;
        isInteractableAgain = obj.isInteractableAgain;
        repeatDialogue = obj.repeatDialogue;
        interactionCount = obj.interactionCount;
        inspectionCount = obj.inspectionCount;
        isCollected = obj.isCollected;  // Save whether the object has been collected
    }
  }


