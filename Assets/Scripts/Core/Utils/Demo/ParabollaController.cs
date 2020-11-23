using System.Collections;
using System.Collections.Generic;
using CoreGame.Math;
using UnityEngine;

namespace CoreGame.Utils.Demo
{
    public class ParabollaController : MonoBehaviour
    {
        public float ANIMATION_DURATION = 2.0f;
        public float FRAMES_PER_SECOND = 30.0f;
        public Transform one;
        public Transform two;
        public float Height;

        void OnDrawGizmos()
        {
            if (one != null && two != null)
            {
                Gizmos.color = Color.yellow;
                Vector3[] points = ParabollaMath.parabolicMovement(transform.position, transform.position, ANIMATION_DURATION, FRAMES_PER_SECOND, Height);
                foreach (Vector3 point in points)
                {
                    Gizmos.DrawSphere(point, .1f);
                }
            }
        }
    }
}