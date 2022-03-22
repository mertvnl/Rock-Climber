using System.Collections;
using System.Collections.Generic;
using CustomEventSystem;
using UnityEngine; 

public class Ragdoll : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Obstacle obstacle = other.GetComponent<Obstacle>();

        if (obstacle != null)
        {
            Events.OnObstacleCollision.Invoke();
        }
    }
}
