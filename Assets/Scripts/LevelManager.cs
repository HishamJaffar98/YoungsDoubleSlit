using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{

    static int currentLevelIndex;
    static int totalScenes = SceneManager.sceneCountInBuildSettings;

    private static int UpdateLevelIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public static IEnumerator LoadNextLevel()
    {
        currentLevelIndex = UpdateLevelIndex();
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene((currentLevelIndex+1)%totalScenes);
    }

    public static IEnumerator LoadPrevLevel()
    {
        currentLevelIndex = UpdateLevelIndex();
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(currentLevelIndex - 1);
    }

    public static IEnumerator QuitApplication()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Application.Quit();
    }
}
