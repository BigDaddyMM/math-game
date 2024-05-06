using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GreaterThanLevels : MonoBehaviour
{
    public void LoadLevel(int levelNumber)
    {
        // Construct the scene name based on the level number
        string sceneName = "GreaterThanL" + levelNumber;

        // Check if the scene exists before loading
        if (SceneExists(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene does not exist: " + sceneName);
        }
    }

    public void LoadGamemode()
    {
        SceneManager.LoadScene("GameModeSelect");
    }

    // Helper method to check if a scene with a given name exists in the build settings
    private bool SceneExists(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneNameInBuildSettings = System.IO.Path.GetFileNameWithoutExtension(scenePath);

            if (sceneNameInBuildSettings == sceneName)
            {
                return true;
            }
        }

        return false;
    }
}
