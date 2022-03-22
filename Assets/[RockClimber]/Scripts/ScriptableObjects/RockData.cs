using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RockData", menuName = "Data/RockData")]
public class RockData : ScriptableObject
{
    public Color32 DefaultColor;
    public Color32 LastColor;
}
