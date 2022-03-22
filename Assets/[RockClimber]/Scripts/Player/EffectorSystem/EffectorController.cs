using System.Collections;
using System.Collections.Generic;
using CustomEventSystem;
using DG.Tweening;
using UnityEngine;

public class EffectorController : MonoBehaviour
{
    [SerializeField] EffectorData effectorData;

    private bool isControlable;
    private Effector[] effectors;
    private Effector currentEffector;
    private int currentEffectorIndex;

    private JumpableRock lastRock;

    private void OnEnable() 
    {
        Events.OnRockClicked.AddListener(HandleMovement);
        Events.OnObstacleCollision.AddListener(DetachHands);
    }

    private void OnDisable() 
    {
        Events.OnRockClicked.RemoveListener(HandleMovement);
        Events.OnObstacleCollision.RemoveListener(DetachHands);
    }

    private void Start()
    {
        Initialise();
    }

    private void Initialise()
    {
        isControlable = true;

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
        if (!isControlable)
            return;

        // Limit player to jump one by one
        if (!RockManager.Instance.CheckIfCanJump(targetRock, lastRock))
            return;

        LoopBetweenHands();

        currentEffector.transform.DOMove(targetRock.GetJumpPosition(), effectorData.MovementDuration).SetEase(effectorData.MovementEasing);

        lastRock = targetRock;
    }

    private void DetachHands()
    {
        if (!isControlable)
            return;

        isControlable = false;

        foreach (var effector in effectors)
        {
            effector.DisableEffector();
        }

        GameManager.Instance.FinishStage(false, 2f);
    }
}
