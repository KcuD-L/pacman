using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UC2D;

public class Watcher : MonoBehaviour
{
    [SerializeField] int speed;
    private Vector2 dir, pos, off;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Watch();
        pos = transform.position;
        rb.velocity = dir * speed;
    }

    private void Watch()
    {
        See(Axis.Takelook(pos, Vector2.up, 8), Vector2.up);
        See(Axis.Takelook(pos, Vector2.down, 8), Vector2.down);
        See(Axis.Takelook(pos, Vector2.left, 8), Vector2.left);
        See(Axis.Takelook(pos, Vector2.right, 8), Vector2.right);
    }

    private void See(RaycastHit2D[] hit, Vector2 d)
    {
        bool[] minOff = Vector.Compare(pos, Vector.Round(pos) - off);
        bool[] maxOff = Vector.Compare(Vector.Round(pos) + off, pos);
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.tag == "Player")
            {
                bool isWall = Axis.Touch(pos, d, "Wall");
                if (!isWall && minOff[0] && minOff[1] && maxOff[0] && maxOff[1] && dir != d)
                {
                    dir = d;
                    transform.localRotation = Quaternion.AngleAxis(Axis.LookAt2D(d), Vector3.forward);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Wall" || col.collider.tag == "EWall" || col.collider.tag == "Enemy")
        {
            dir = new Vector2(0, 0);
            transform.position = Vector.Round(transform.position);
        }
    }

}
