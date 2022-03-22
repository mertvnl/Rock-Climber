using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SawController : MonoBehaviour
{
    [Header("Dynamic Settings")]
    [SerializeField] private Transform moveTarget;
    [SerializeField] private Transform saw;
    [SerializeField] private float movementDuration;

    private Sequence seq;

    private void Start()
    {
        Animation();
    }

    private void Animation()
    {
        float initialX = saw.localPosition.x;

        seq = DOTween.Sequence();

        seq.SetLoops(-1);
        seq.Append(saw.DOLocalMoveX(moveTarget.localPosition.x, movementDuration / 2).SetEase(Ease.InOutSine));
        seq.Append(saw.DOLocalMoveX(initialX, movementDuration / 2).SetEase(Ease.InOutSine));
    }

    private void OnDestroy()
    {
        seq.Kill();
    }
}