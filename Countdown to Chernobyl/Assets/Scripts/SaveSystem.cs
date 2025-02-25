using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{

    string keyWord = "123456789";
    GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Save();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Load();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Save()
    {
        SaveData myData = new SaveData();
        Inventory inventory = player.GetComponent<Inventory>();
        myData.x = transform.position.x;
        myData.y = transform.position.y;
        myData.z = transform.position.z;
        string myItemsString = JsonUtility.ToJson(inventory.items.ToString());
        string myDataString = JsonUtility.ToJson(myData);
        myDataString = EncryptDecryptData(myDataString);
        myItemsString = EncryptDecryptData(myDataString);

        string file = Application.persistentDataPath + "/" + gameObject.name + ".json";
        System.IO.File.WriteAllText(file, myDataString);
        File.WriteAllText(file, myItemsString);
        Debug.Log(file);
    }

    public void Load()
    {
        string file = Application.persistentDataPath + "/" + gameObject.name + ".json";
        if (File.Exists(file))
        {
            string jsonData = File.ReadAllText(file);
            jsonData = EncryptDecryptData(jsonData);
            Debug.Log(jsonData);
            SaveData myData = JsonUtility.FromJson<SaveData>(jsonData);
            transform.position = new Vector3(myData.x, myData.y, myData.z);
        }
    }

    public string EncryptDecryptData(string data)
    {
        string result = "";
        for (int i = 0; i < data.Length; i++)
        {
            result += (char)(data[i] ^ keyWord[i % keyWord.Length]);
        }
        Debug.Log(result);
        return result;
    }
}

[System.Serializable]
public class SaveData
{
    public float x;
    public float y;
    public float z;
}