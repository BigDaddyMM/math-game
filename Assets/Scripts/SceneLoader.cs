using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void UnloadScene(string sceneName)
    {
        // Check if the scene is loaded before trying to unload
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
        else
        {
            Debug.LogWarning($"Scene '{sceneName}' is not loaded.");
        }
    }
}