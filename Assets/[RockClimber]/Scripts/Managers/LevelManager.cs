using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [HideInInspector]
    public UnityEvent OnLevelFinish = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnLevelSuccess = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnLevelFail = new UnityEvent();

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
