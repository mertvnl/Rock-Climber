using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : PanelBase
{
    private void Awake()
    {
        ShowPanel();
    }

    private void OnEnable() 
    {
        if (Managers.Instance == null)
            return;

        LevelManager.Instance.OnLevelFinish.AddListener(HidePanel);
    }

    private void OnDisable() 
    {
        if (Managers.Instance == null)
            return;

        LevelManager.Instance.OnLevelFinish.RemoveListener(HidePanel);
    }
}
