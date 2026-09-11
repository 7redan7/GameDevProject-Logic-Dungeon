using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private const int MainMenuBuildIndex = 0;
    public static void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning("SceneLoader: nessuna scena successiva in Build Settings.");
            return;
        }
        Load(nextSceneIndex);
    }

    public static void ReloadCurrentScene()
    {
        Load(SceneManager.GetActiveScene().buildIndex);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    private static void Load(int buildIndex)
    {
        if (buildIndex < 0)
        {
            Debug.LogWarning("SceneLoader: la scena attiva non e' in Build Settings.");
            return;
        }

        Time.timeScale = 1f;
        TruthTableMenu.GameIsPaused = false;
        SceneManager.LoadScene(buildIndex);
    }
}
