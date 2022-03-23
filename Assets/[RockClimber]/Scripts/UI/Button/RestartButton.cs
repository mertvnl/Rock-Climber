using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : ButtonBase
{
    public override void OnClick()
    {
        GameManager.Instance.FinishStage(false, 2f);
    }
}
