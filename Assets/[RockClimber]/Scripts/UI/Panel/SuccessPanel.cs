using System.Collections;
using System.Collections.Generic;
using CustomEventSystem;
using UnityEngine;

public class SuccessPanel : PanelBase
{
    private void OnEnable()
    {
        Events.OnSuccess.AddListener(ShowPanel);
    }

    private void OnDisable()
    {
        Events.OnSuccess.RemoveListener(ShowPanel);
    }
}
