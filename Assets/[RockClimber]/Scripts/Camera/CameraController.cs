using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private Vector3 followOffset;
    [SerializeField] private float followDamping;

    private void LateUpdate()
    {
        if (cameraTarget == null)
            return;

        transform.position = Vector3.Lerp(transform.position, cameraTarget.position + followOffset, Time.deltaTime * followDamping);
    }
}
