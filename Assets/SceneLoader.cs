using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Name of the scene to load
    [SerializeField] private string sceneName;

    // Load the specified scene
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is not set in the SceneLoader script.");
        }
    }

    // Quit the application
    public void QuitGame()
    {
        Debug.Log("QuitGame called");
        Application.Quit();

        // This only works in a built application. In the editor, we log for confirmation.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
