using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void SceneChange(string sceneName)
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }

}
