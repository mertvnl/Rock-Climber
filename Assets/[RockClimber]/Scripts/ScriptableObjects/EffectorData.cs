using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectorData", menuName = "Data/EffectorData")]
public class EffectorData : ScriptableObject
{
    public float MovementDuration = 0.6f;
    public Ease MovementEasing = Ease.OutSine;
}
