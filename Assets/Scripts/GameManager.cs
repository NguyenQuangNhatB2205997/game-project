using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    [Header("UI")]
    public GameObject pauseMenu; // reference to the pause menu UI

    void Awake()
    {
        DisablePauseMenu(); // ensure the pause menu is disabled at start
    }

    void Update()
    {
        switch (currentGameState)
        {
            case GameState.Gameplay:
                // handle gameplay logic
                break;
            case GameState.Paused:
                // handle paused logic
                break;
            case GameState.GameOver:
                // handle game over logic
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
            Debug.Log("Game Paused");
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
            Debug.Log("Game Resumed");
        }
    }

    // method to end the game
    public void EndGame()
    {
        currentGameState = GameState.GameOver;
        Time.timeScale = 0; // stop the game time
        Debug.Log("Game Over");
    }

    //
    // testing purposes only
    //
    void TestSwitchState()
    {
        // example of switching game states
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeState(GameState.Paused);
            Debug.Log("Game Paused");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeState(GameState.Gameplay);
            Debug.Log("Game Resumed");
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeState(GameState.GameOver);
            Debug.Log("Game Over");
        }
    }
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
    void DisablePauseMenu()
    {
        pauseMenu.SetActive(false); // deactivate the pause menu UI
    }
}
