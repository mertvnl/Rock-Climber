using System.Collections;
using System.Collections.Generic;
using CustomEventSystem;
using UnityEngine;

public class JumpableRock : MonoBehaviour
{
    [SerializeField] private Color32 defaultColor;
    [SerializeField] private Color32 lastColor;

    private const float Z_OFFSET = 0.2f;

    private void Awake()
    {
        RockManager.Instance.AddRock(this);
    }

    private void OnMouseDown()
    {
        Events.OnRockClicked.Invoke(this);
    }

    public void UpdateColor(bool isLast = false)
    {
        if (isLast)
            GetComponentInChildren<Renderer>().material.color = lastColor;
        else
            GetComponentInChildren<Renderer>().material.color = defaultColor;
    }

    public Vector3 GetJumpPosition()
    {
        return transform.position + Vector3.back * Z_OFFSET;
    }
}
