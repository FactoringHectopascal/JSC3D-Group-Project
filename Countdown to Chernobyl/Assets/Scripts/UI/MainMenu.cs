using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        // Ensure the cursor is visible for menu navigation
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Function to start the game when the button is clicked
    public void StartGame()
    {
        SceneManager.LoadScene("Countdown To Chernobyl"); // Replace "GameLevel" with your actual game scene name
    }

    // Function to quit the game when the button is clicked
    public void ExitGame()
    {
        Application.Quit();
    }
}
