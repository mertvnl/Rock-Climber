using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IButton
{
    Button Button { get; } 

    void OnClick();
}
