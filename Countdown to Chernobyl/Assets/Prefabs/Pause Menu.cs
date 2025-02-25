using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            Resume();
        }

    }

    public void Resume()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().RotationSpeed = 1;
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
        if (GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().usingThing != true || GameObject.FindGameObjectWithTag("Event Handler").GetComponent<EventHandler>().isOpen != true)
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().RotationSpeed = 0;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
        GetComponent<Canvas>().enabled = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
