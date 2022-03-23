using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public void FinishStage(bool isSuccess, float delay = 0f)
    {
        StartCoroutine(FinishStageCo(isSuccess, delay));
    }

    public IEnumerator FinishStageCo(bool isSuccess, float delay = 0f)
    {
        LevelManager.Instance.OnLevelFinish.Invoke();

        if (isSuccess)
        {
            LevelManager.Instance.OnLevelSuccess.Invoke();
            yield return new WaitForSeconds(delay);
            LevelManager.Instance.RestartLevel();
        }
        else
        {
            LevelManager.Instance.OnLevelFail.Invoke();
            yield return new WaitForSeconds(delay);
            LevelManager.Instance.RestartLevel();
        }
    }
}
