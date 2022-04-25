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

        public static Vector3 LerpIgnoreZ(Vector3 obj, Vector3 target, float speed)
        {
            Vector3 first = new Vector3(obj.x, obj.y, obj.z);
            Vector3 second = new Vector3(target.x, target.y, obj.z);
            return (Vector3.Lerp(first,second,speed));

        }
    }

    public static class Axis
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
            Vector2 ret = new Vector2(0, 0);
            switch (UnityEngine.Random.Range(-1, 2))
            {
                case -1:
                    ret = new Vector2(-1, 0);
                    break;
                case 1:
                    ret = new Vector2(1, 0);
                    break;
                default:
                    switch(UnityEngine.Random.Range(-1, 2))
                    {
                        case -1:
                            ret = new Vector2(0, -1);
                            break;
                        case 1:
                            ret = new Vector2(0, 1);
                            break;
                        default:
                            ret = new Vector2(1, 0);
                            break;
                    }
                    break;
            }
            return (ret);
        }
        public static RaycastHit2D[] Takelook(Vector2 from, Vector3 to, float lenght)
        {
            return (Physics2D.RaycastAll(from, to, lenght));
        }
        public static Quaternion LookAt2D(Vector2 target)
        {
            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            return (Quaternion.AngleAxis(angle, Vector3.forward));
        }
        public static bool Touch(Vector2 pos, Vector2 to, string tag)
        {
            RaycastHit2D[] col = Physics2D.LinecastAll(pos, to);
            for (int i = 0; i < col.Length; i++)
            {
                if (col[i].collider.tag == tag)
                {
                    return (true);
                }
            }
            return (false);
        }
    }

    public static class Mth
    {
        public static float Loop(float now, float min, float max)
        {
            if(now > max)
            {
                return (min);
            }
            if(now < min)
            {
                return (max);
            }
            return (now);
        }

        public static bool isOutLoop(float now, float min, float max)
        {
            if (now > max || now < min)
            {
                return (true);
            }
            return (false);
        }
    }
}