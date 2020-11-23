using UnityEngine;

namespace CoreGame.Math
{
    public static class CMath
    {
        public static void LocalRotateTransformAxisY(Transform transform, Vector2 direction)
        {
            float angle = 90 - Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
        }

        public static void LocalRotateTransformAxisX(Transform transform, Vector2 direction)
        {
            float angle = 90 - Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(angle, 0, 0);
        }

        public static void LocalRotateTransformAxisZ(Transform transform, Vector2 direction)
        {
            float angle = 90 - Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }
}