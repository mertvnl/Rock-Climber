using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : ButtonBase
{
    public override void OnClick()
    {
        GameManager.Instance.FinishStage(true, 2f);
    }
}
