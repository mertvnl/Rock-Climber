using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    private void Start()
    {
        //normally we would get the saved level index to load latest level but this prototype has 1 level
        int lastLevelIndex = 1;
        SceneManager.LoadSceneAsync(lastLevelIndex, LoadSceneMode.Additive);

        Destroy(this);
    }
}
