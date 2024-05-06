using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeSelect : MonoBehaviour
{

    void Start()
    {
        
        // Make the cursor visible
        Cursor.visible = true;

        // Optionally, unlock the cursor
        Cursor.lockState = CursorLockMode.None;
    }
    public void SelectSabiranjeMode()
    {
        SceneManager.LoadScene("SabiranjeLevels");
    }

    public void SelectOduzimanjeMode()
    {
        SceneManager.LoadScene("OduzimanjeLevels");
    }
    public void SelectGreaterThanMode()
    {
        SceneManager.LoadScene("GreaterThanLevels");
    }
    public void SelectLessThanMode()
    {
        SceneManager.LoadScene("LessThanLevels");
    }

    public void BackToClassroom()
    {
        SceneManager.LoadScene("ClassroomScene");
    }
}
