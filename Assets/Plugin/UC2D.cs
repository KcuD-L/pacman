using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UC2D
{
    public static class Vector
    {
        public static Vector3 IgnoreZ(Vector3 target, Vector3 original)
        {
            Vector3 flat = new Vector3(target.x, target.y, original.z);
            return (flat);
        }
        public static Vector3 IgnoreZ(Vector2 target, Vector3 original)
        {
            Vector3 flat = new Vector3(target.x, target.y, original.z);
            return (flat);
        }

        public static Vector3 AddZ(Vector3 original, Vector3 target)
        {
            Vector3 flat = new Vector3(original.x, original.y, target.z);
            return (flat);
        }
        public static Vector3 AddZ(Vector2 original, Vector3 target)
        {
            Vector3 flat = new Vector3(original.x, original.y, target.z);
            return (flat);
        }

        public static Vector3 Round(Vector3 target)
        {
            Vector3 done = new Vector3(Mathf.Round(target.x), Mathf.Round(target.y), Mathf.Round(target.z));
            return (done);
        }
        public static Vector2 Round(Vector2 target)
        {
            Vector3 done = new Vector3(Mathf.Round(target.x), Mathf.Round(target.y));
            return (done);
        }

        public static bool[] Compare(Vector3 first, Vector3 second)
        {
            bool[] com = new bool[] { false, false, false };
            if (first.x >= second.x)
            {
                com[0] = true;
            }
            if (first.y >= second.y)
            {
                com[1] = true;
            }
            if (first.z >= second.z)
            {
                com[2] = true;
            }
            return (com);
        }
        public static bool[] Compare(Vector2 first, Vector2 second)
        {
            bool[] com = new bool[] { false, false };
            if (first.x >= second.x)
            {
                com[0] = true;
            }
            if (first.y >= second.y)
            {
                com[1] = true;
            }
            return (com);
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

    public static class MainAxis
    {
        public static bool Compare4Axis(Vector2 input)
        {
            if (input == Vector2.down || input == Vector2.up || input == Vector2.left || input == Vector2.right)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        public static Vector2 EquateTo4Axis(Vector2 input)
        {
            Vector2 ret = new Vector2(0, 0);
            if (input.x < 0)
            {
                ret = new Vector2(-1, 0);
            }
            if (input.x > 0)
            {
                ret = new Vector2(1, 0);
            }
            if (input.y > 0)
            {
                ret = new Vector2(0, 1);
            }
            if (input.y < 0)
            {
                ret = new Vector2(0, -1);
            }
            return (ret);
        }
        public static Vector2 RandomAxis()
        {
            Vector2 ret = new Vector2(UnityEngine.Random.Range(-1, 2), UnityEngine.Random.Range(-1, 2));
            EquateTo4Axis(ret);
            return (ret);
        }
        public static RaycastHit2D[] Takelook(Vector2 from, Vector3 to, int lenght)
        {
            return (Physics2D.RaycastAll(from, to, lenght));
        }
    }
}