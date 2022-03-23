using System.Collections;
using System.Collections.Generic;
using CustomEventSystem;
using UnityEngine;

public class FailPanel : PanelBase
{
    private void OnEnable()
    {
        Events.OnFail.AddListener(ShowPanel);
    }

    private void OnDisable()
    {
        Events.OnFail.RemoveListener(ShowPanel);
    }
}
