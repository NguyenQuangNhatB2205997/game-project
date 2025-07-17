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

    // testing purpose only
    void TestSwitchState()
    {
        // example of switching game states
        if (Input.GetKeyDown(KeyCode.P))
        {
            currentGameState = GameState.Paused;
            Debug.Log("Game Paused");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            currentGameState = GameState.Gameplay;
            Debug.Log("Game Resumed");
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            currentGameState = GameState.GameOver;
            Debug.Log("Game Over");
        }
    }

    // method to pause the game
    public void PauseGame()
    {
        if (currentGameState != GameState.Paused)
        {
            previousGameState = currentGameState; 
            currentGameState = GameState.Paused;
            Time.timeScale = 0f; // pause the game
            Debug.Log("Game Paused");
        }

    
    }

    // method to resume the game
    public void ResumeGame()
    {
        if (currentGameState == GameState.Paused)
        {
            currentGameState = previousGameState; // switch back to the previous state
            Time.timeScale = 1f; // resume the game
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

}
