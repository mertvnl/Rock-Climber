using System.Collections;
using System.Collections.Generic;
using CustomEventSystem;
using UnityEngine;
using UnityEngine.Animations;

public class Effector : MonoBehaviour
{
    [SerializeField] private Transform effectorSource;

    private Rigidbody rigidbody;
    public Rigidbody Rigidbody { get { return rigidbody == null ? rigidbody = GetComponent<Rigidbody>() : rigidbody; } }

    public void EnableEffector()
    {
        transform.SetParent(null);
        RecreateJoint();
    }

    public void DisableEffector()
    {
        transform.SetParent(effectorSource);
        transform.localEulerAngles = Vector3.zero;
        transform.localPosition = Vector3.zero;
        DestroyJoint();
    }

    private void RecreateJoint()
    {
        DestroyJoint();

        effectorSource.gameObject.AddComponent<FixedJoint>().connectedBody = Rigidbody;
    }

    private void DestroyJoint()
    {
        FixedJoint joint = effectorSource.GetComponent<FixedJoint>();

        if (joint != null)
        {
            Destroy(joint);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        JumpableRock rock = other.GetComponent<JumpableRock>();

        if (rock != null)
        {
            if (rock == RockManager.Instance.GetLastRock())
                Events.OnSuccess.Invoke();
        }
    }
}
