using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonBase : MonoBehaviour, IButton
{
    private Button button;
    public Button Button { get { return button == null ? button = GetComponent<Button>() : button; } }

    public virtual void OnEnable()
    {
        Button.onClick.AddListener(OnClick);
    }

    public virtual void OnDisable()
    {
        Button.onClick.RemoveListener(OnClick);
    }

    public abstract void OnClick();
}
