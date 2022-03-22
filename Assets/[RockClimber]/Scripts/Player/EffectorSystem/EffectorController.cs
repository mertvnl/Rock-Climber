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

    private JumpableRock lastRock;

    private void OnEnable() 
    {
        Events.OnRockClicked.AddListener(HandleMovement);
    }

    private void OnDisable() 
    {
        Events.OnRockClicked.RemoveListener(HandleMovement);
    }

    private void Start()
    {
        Initialise();
    }

    private void Initialise()
    {
        currentEffectorIndex = -1;

        effectors = GetComponentsInChildren<Effector>();

        lastRock = RockManager.Instance.GetStartingRock();

        HandleMovement(lastRock);
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

    private void HandleMovement(JumpableRock targetRock)
    {
        // Limit player to jump one by one
        if (!RockManager.Instance.CheckIfCanJump(targetRock, lastRock))
            return;

        LoopBetweenHands();

        currentEffector.transform.DOMove(targetRock.GetJumpPosition(), movementDuration).SetEase(movementEase);

        lastRock = targetRock;
    }
}
