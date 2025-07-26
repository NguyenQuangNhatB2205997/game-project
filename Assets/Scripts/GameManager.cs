using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // public PlayerInput playerInput; // reference to the player input actions

    public static GameManager instance; // singleton instance of GameManager

    // define game states
    public enum GameState
    {
        Gameplay,
        Paused,
        GameOver
    }

    // store the current game state
    public GameState currentGameState;
    // store the previous game state
    public GameState previousGameState;

    public bool isGameOver = false; // flag to check if the game is over

    [Header("UI")]
    public GameObject pauseMenu; // reference to the pause menu UI
    public GameObject resultScreen; // reference to the game over UI

    [Header("Stopwatch")]
    public float timeLimit; // time limit in seconds
    float stopwatchTime; // time elapsed in the game
    public Text stopwatchDisplay; // reference to the UI text for displaying stopwatch time

    [Header("Result Screen Display")]
    public Text timeSurvived; // reference to the UI text for displaying time survived

    void Awake()
    {
        if (instance == null)
        {
            instance = this; // set the singleton instance
        }
        else if (instance != this)
        {
            Debug.LogWarning("Multiple GameManager instances found! Destroying duplicate.");
            Destroy(gameObject);
        }

        DisableScreens(); // ensure the pause menu is disabled at start

        // playerInput = new PlayerInput();
    }

    void Update()
    {
        switch (currentGameState)
        {
            case GameState.Gameplay:
                // handle gameplay logic
                CheckForPauseAndResume(); // check for pause/resume input
                UpdateStopwatch(); // update stopwatch time
                break;
            case GameState.Paused:
                // handle paused logic
                CheckForPauseAndResume(); // check for pause/resume input
                break;
            case GameState.GameOver:
                // handle game over logic
                if (!isGameOver)
                {
                    isGameOver = true; // set game over flag
                    Time.timeScale = 0; // stop the game time
                    DisplayResults(); // display results or end game UI
                    Debug.Log("Game Over");
                }
                break;
            default:
                Debug.LogError("Unknown game state: " + currentGameState);
                break;
        }
    }

    // define the method to change game states
    public void ChangeState(GameState newState)
    {
        currentGameState = newState; // change to the new state
    }

    // method to pause the game
    public void PauseGame()
    {
        if (currentGameState != GameState.Paused)
        {
            previousGameState = currentGameState; 
            ChangeState(GameState.Paused); // switch to paused state
            Time.timeScale = 0f; // pause the game
            pauseMenu.SetActive(true); // activate the pause menu UI
            // Debug.Log("Game Paused"); //testing purposes
        }
    }

    // method to resume the game
    public void ResumeGame()
    {
        if (currentGameState == GameState.Paused)
        {
            ChangeState(previousGameState); // switch back to previous state
            Time.timeScale = 1f; // resume the game
            pauseMenu.SetActive(false); // deactivate the pause menu UI
            // Debug.Log("Game Resumed"); //testing purposes
        }
    }

    // method to end the game
    public void EndGame()
    {
        currentGameState = GameState.GameOver;
        Time.timeScale = 0; // stop the game time
        Debug.Log("Game Over");
    }

    // method to disable the pause menu
    void DisableScreens()
    {
        pauseMenu.SetActive(false); // deactivate the pause menu UI
        resultScreen.SetActive(false); // deactivate the game over UI
    }

    // call this method when the player is defeated
    public void GameOver()
    {
        timeSurvived.text = stopwatchDisplay.text; // display the survived time
        ChangeState(GameState.GameOver);
        Debug.Log("Game Over!");
    }

    //
    void DisplayResults()
    {
        resultScreen.SetActive(true); // activate the game over UI
    }

    // update the stopwatch time
    // no need to create a separate bool variable
    // if switch to other states, the stopwatch will stop
    void UpdateStopwatch()
    {
        stopwatchTime += Time.deltaTime; // increment stopwatch time
        UpdateStopwatchDisplay(); // update the UI display
    }

    void UpdateStopwatchDisplay()
    {
        // format the stopwatch time to display minutes and seconds
        int minutes = Mathf.FloorToInt(stopwatchTime / 60);
        int seconds = Mathf.FloorToInt(stopwatchTime % 60);
        stopwatchDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //
    // testing purposes only
    //
    void CheckForPauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentGameState == GameState.Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
