using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelCompleteMenu : MonoBehaviour
{
    // You can link the buttons in the Unity Editor
    public GameObject classroomButton;
    public GameObject levelsButton;
    public GameObject nextLevelButton;

    void Start()
    {
        // Retrieve the previous scene name from PlayerPrefs
        string previousScene = PlayerPrefs.GetString("PreviousScene", "");
        Debug.Log("Previous Scene: " + previousScene);
    }

    public void OnClassroomButtonClick()
    {

        // Load the ClassroomScene
        SceneManager.LoadScene("ClassroomScene");
    }

    public void OnLevelsButtonClick()
    {
        // Retrieve the previous scene name from PlayerPrefs
        string previousScene = PlayerPrefs.GetString("PreviousScene", "");

        if (previousScene.StartsWith("SabiranjeL"))
        {
            // Previous scene was a Sabiranje level, go to SabiranjeLevels
            SceneManager.LoadScene("SabiranjeLevels");
        }
        else if (previousScene.StartsWith("OduzimanjeL"))
        {
            // Previous scene was an Oduzimanje level, go to OduzimanjeLevels
            SceneManager.LoadScene("OduzimanjeLevels");
        }
        // Add more conditions as needed for other scenes

        // Default case (if none of the above conditions are met)
        SceneManager.LoadScene("GameModeSelect");
    }

    public void OnNextLevelButtonClick()
    {
        // Retrieve the previous scene name from PlayerPrefs
        string previousScene = PlayerPrefs.GetString("PreviousScene", "");

        // Get the current level number from the active scene's name
        int currentLevelNumber = GetCurrentLevelNumber(previousScene);

        // Determine the next level scene name
        string nextLevelSceneName = "";

        if (previousScene.StartsWith("SabiranjeL"))
        {
            // Previous scene was a Sabiranje level
            nextLevelSceneName = "SabiranjeL" + (currentLevelNumber + 1);
        }
        else if (previousScene.StartsWith("OduzimanjeL"))
        {
            // Previous scene was an Oduzimanje level
            nextLevelSceneName = "OduzimanjeL" + (currentLevelNumber + 1);
        }
        // Add more conditions as needed for other scenes

        // Check if the next level exists
        if (SceneExists(nextLevelSceneName))
        {
            // Load the next level
            SceneManager.LoadScene(nextLevelSceneName);
        }
        else
        {
            // No more levels, go back to the appropriate levels scene
            if (previousScene.StartsWith("SabiranjeL"))
            {
                SceneManager.LoadScene("SabiranjeLevels");
            }
            else if (previousScene.StartsWith("OduzimanjeL"))
            {
                SceneManager.LoadScene("OduzimanjeLevels");
            }
            // Add more conditions as needed for other scenes
        }
    }

    // Helper method to get the current level number from the active scene's name
    // Helper method to get the current level number from the active scene's name
    private int GetCurrentLevelNumber(string sceneName)
    {
        Debug.Log("Previous Scene Name: " + sceneName);

        // Check if the scene name contains "SabiranjeL" or "OduzimanjeL"
        if (sceneName.StartsWith("SabiranjeL") || sceneName.StartsWith("OduzimanjeL"))
        {
            // Extract the level number string
            string levelNumberString = sceneName.Substring(sceneName.IndexOf('L') + 1);

            // Attempt to parse the level number
            if (int.TryParse(levelNumberString, out int levelNumber))
            {
                return levelNumber;
            }
            else
            {
                Debug.LogError("Failed to parse level number.");
            }
        }
        else
        {
            Debug.LogError("Previous scene name does not contain 'SabiranjeL' or 'OduzimanjeL'.");
        }

        return 0; // Default value or handle accordingly
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