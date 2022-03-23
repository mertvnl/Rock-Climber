using System.Collections;
using System.Collections.Generic;
using CustomEventSystem;
using UnityEngine;

public class JumpableRock : MonoBehaviour
{
    [SerializeField] private RockData rockData;

    private const float Z_OFFSET = 0.2f;

    private void Awake()
    {
        if (Managers.Instance == null)
            return;

        RockManager.Instance.AddRock(this);
    }

    private void OnMouseDown()
    {
        Events.OnRockClicked.Invoke(this);
    }

    public void UpdateColor(bool isLast = false)
    {
        if (isLast)
            GetComponentInChildren<Renderer>().material.color = rockData.LastColor;
        else
            GetComponentInChildren<Renderer>().material.color = rockData.DefaultColor;
    }

    public Vector3 GetJumpPosition()
    {
        return transform.position + Vector3.back * Z_OFFSET;
    }
}
