using System.Collections;
using System.Collections.Generic;
using CustomEventSystem;
using DG.Tweening;
using UnityEngine;

public class EffectorController : MonoBehaviour
{
    [SerializeField] private float movementDuration;
    [SerializeField] private Ease movementEase;

    //After unparenting, we change the euler angles for cleaner look.
    private Vector3 fixedEulerAngles = new Vector3(35, 120, -45);

    private void OnEnable() 
    {
        Events.OnRockClicked.AddListener(HandleMovement);
    }

    private void OnDisable() 
    {
        Events.OnRockClicked.RemoveListener(HandleMovement);
    }

    private void Awake()
    {
        Initialise();
    }

    private void Initialise()
    {
        transform.SetParent(null);
        transform.eulerAngles = fixedEulerAngles;
    }

    private void HandleMovement(Vector3 targetPosition)
    {
        //if target rock is below dont do anything
        if (targetPosition.y < transform.position.y)
            return;

        transform.DOMove(targetPosition, movementDuration).SetEase(movementEase);
    }
}
