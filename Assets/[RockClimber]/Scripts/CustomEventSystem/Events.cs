using System;
using UnityEngine;

namespace CustomEventSystem
{
    public static class Events
    {
        //Put your events here.
        public static readonly Event<Vector3> OnRockClicked = new Event<Vector3>();
    }
}