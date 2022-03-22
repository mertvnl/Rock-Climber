using System.Collections;
using System.Collections.Generic;
using CustomEventSystem;
using UnityEngine;

public class JumpableRock : MonoBehaviour
{
    private const float Z_OFFSET = 0.2f;

    private void OnMouseDown()
    {
        Events.OnRockClicked.Invoke(transform.position + Vector3.back * Z_OFFSET);
    }
}
