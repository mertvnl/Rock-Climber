using System.Collections;
using System.Collections.Generic;
using CustomEventSystem;
using UnityEngine;

public class ConfettiEffectController : MonoBehaviour
{
    [SerializeField] private GameObject successPrefab;

    private void OnEnable() 
    {
        Events.OnSuccess.AddListener(InstantiateParticle);
    }

    private void OnDisable() 
    {
        Events.OnSuccess.RemoveListener(InstantiateParticle);
    }

    private void InstantiateParticle()
    {
        GameObject go = Instantiate(successPrefab, transform.position, successPrefab.transform.rotation);
        go.transform.position = new Vector3(0, transform.position.y, -1f);
    }
}
