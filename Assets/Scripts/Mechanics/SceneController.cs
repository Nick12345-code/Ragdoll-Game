using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // loads the scene specified in the inspector
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
}
