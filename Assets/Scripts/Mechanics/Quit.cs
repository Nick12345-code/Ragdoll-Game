using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Backspace))
       {
            QuitGame();
       } 
    }

    public void QuitGame()
    {
        // quits game when built
        Application.Quit();
        // quits playmode in editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
