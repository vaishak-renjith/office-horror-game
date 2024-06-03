using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Job : MonoBehaviour
{
    public string sceneName;

    public void loadJob()
    {
        SceneManager.LoadScene(sceneName);
    }
}
