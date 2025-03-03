using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public FirstPersonController playerController; // Assign in Inspector
    public EventHandler eventHandler; // Assign in Inspector

    void Start()
    {
        GetComponent<Canvas>().enabled = false;

        if (playerController == null)
        {
            Debug.LogError("Player Controller reference is missing in the PauseMenu script!");
        }
        if (eventHandler == null)
        {
            Debug.LogError("Event Handler reference is missing in the PauseMenu script!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
                Pause();
            else
                Resume();
        }
    }

    public void Resume()
    {
        if (playerController == null || eventHandler == null)
        {
            Debug.LogError("PlayerController or EventHandler is not assigned in the Inspector.");
            return;
        }

        playerController.RotationSpeed = 1;
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;

        if (!eventHandler.usingThing && !eventHandler.isOpen)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;
        }
    }

    public void Pause()
    {
        if (playerController == null)
        {
            Debug.LogError("PlayerController is missing.");
            return;
        }

        Time.timeScale = 0;
        playerController.RotationSpeed = 0;
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

