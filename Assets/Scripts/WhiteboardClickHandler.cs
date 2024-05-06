using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiteboardClickHandler : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Load the "GameModeSelect" scene
        SceneManager.LoadScene("GameModeSelect");

        // Make the cursor visible
        Cursor.visible = true;

        // Optionally, unlock the cursor
        Cursor.lockState = CursorLockMode.None;
    }
}