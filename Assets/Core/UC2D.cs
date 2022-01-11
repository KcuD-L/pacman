using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UC2D
{
    public static class Vector2D
    {
        public static Vector3 IgnoreZ(Vector3 target, Vector3 original)
        {
            Vector3 flat = new Vector3(target.x, target.y, original.z);
            return (flat);
        }

        public static float GetAngle(Vector3 firstVector, Vector3 secondVector)
        {
            float aX = firstVector.x;
            float aY = firstVector.x;
            float aZ = firstVector.x;
            float bX = secondVector.x;
            float bY = secondVector.x;
            float bZ = secondVector.x;
            float firstStep = aX * bX + aY * bY + aZ * bZ;
            float secondStep = Mathf.Sqrt((aX * aX) + (aY * aY) + (aZ * aZ)) + Mathf.Sqrt((bX * bX) + (bY * bY) + (bZ * bZ));
            float cosAngle = Mathf.Cos((firstStep / secondStep));
            float angle = Mathf.Acos(cosAngle);
            return (angle);
        }
    }
}
