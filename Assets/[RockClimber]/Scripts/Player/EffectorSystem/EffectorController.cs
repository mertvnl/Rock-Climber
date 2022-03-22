using System.Collections;
using System.Collections.Generic;
using CustomEventSystem;
using DG.Tweening;
using UnityEngine;

public class EffectorController : MonoBehaviour
{
    [SerializeField] private float movementDuration;
    [SerializeField] private Ease movementEase;

    private Effector[] effectors;
    private Effector currentEffector;
    private int currentEffectorIndex;

    //After unparenting, we change the euler angles for cleaner look.

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
        currentEffectorIndex = -1;

        effectors = GetComponentsInChildren<Effector>();

        foreach (var effector in effectors)
        {
            effector.Initialise();
        }

        LoopBetweenHands();
    }

    private void LoopBetweenHands()
    {
        currentEffectorIndex++;

        if (currentEffectorIndex > effectors.Length - 1)
            currentEffectorIndex = 0;

        currentEffector = effectors[currentEffectorIndex];

        foreach (var effector in effectors)
        {
            effector.DisableEffector();
        }

        currentEffector.EnableEffector();
    }

    private void HandleMovement(Vector3 targetPosition)
    {
        //if target rock is below dont do anything
        if (targetPosition.y < transform.position.y)
            return;

        LoopBetweenHands();

        currentEffector.transform.DOMove(targetPosition, movementDuration).SetEase(movementEase);
    }
}
