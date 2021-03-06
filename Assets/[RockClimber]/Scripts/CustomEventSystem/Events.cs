using System;
using UnityEngine;

namespace CustomEventSystem
{
    public static class Events
    {
        //Put your events here.
        public static readonly Event<JumpableRock> OnRockClicked = new Event<JumpableRock>();
        public static readonly Event OnObstacleCollision = new Event();
        public static readonly Event OnSuccess = new Event();
        public static readonly Event OnFail = new Event();
    }
}