#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    public GameObject RockPrefab;

    [Header("Level Settings")]
    public int RockAmountToCreate = 5;
    public float RockGap = 2f;
    public float RockXOffset;

    public List<GameObject> InstantiatedRocks = new List<GameObject>();

    public void GenerateLevel()
    {
        ResetLevel();

        for (int i = 0; i < RockAmountToCreate; i++)
        {
            GameObject instance = PrefabUtility.InstantiatePrefab(RockPrefab, transform) as GameObject;
            instance.transform.position = new Vector3(Random.Range(-RockXOffset, RockXOffset), RockGap * i, 0);

            InstantiatedRocks.Add(instance);
        }
    }

    public void ResetLevel()
    {
        foreach (var go in InstantiatedRocks)
        {
            DestroyImmediate(go);
        }

        InstantiatedRocks.Clear();
    }

    private void OnValidate()
    {
        if (InstantiatedRocks.Count <= 0)
            return;

        for (int i = 0; i < InstantiatedRocks.Count; i++)
        {
            InstantiatedRocks[i].transform.position = new Vector3(InstantiatedRocks[i].transform.position.x, RockGap * i, InstantiatedRocks[i].transform.position.z);
        }
    }
}
#endif