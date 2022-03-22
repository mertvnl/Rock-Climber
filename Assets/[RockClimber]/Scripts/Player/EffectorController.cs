using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EffectorController : MonoBehaviour
{
    [SerializeField] private float movementDuration;
    [SerializeField] private Ease movementEase;

    private void OnEnable() 
    {

 
    }

    private void OnDisable() 
    { 


    }

    private void HandleMovement(Vector3 targetPosition)
    {
        //movement logic
        transform.DOMove(targetPosition, movementDuration).SetEase(movementEase);
    }
}
