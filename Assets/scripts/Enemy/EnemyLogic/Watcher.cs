using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UC2D;

public class Watcher : MonoBehaviour
{
    [SerializeField] int speed;
    private Vector2 dir;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Watch();
        rb.velocity = dir * speed;
    }

    private void Watch()
    {
        See(MainAxis.Takelook(gameObject.transform.position, Vector2.up, 8), Vector2.up);
        See(MainAxis.Takelook(gameObject.transform.position, Vector2.down, 8), Vector2.down);
        See(MainAxis.Takelook(gameObject.transform.position, Vector2.left, 8), Vector2.left);
        See(MainAxis.Takelook(gameObject.transform.position, Vector2.right, 8), Vector2.right);
    }

    private void See(RaycastHit2D[] hit, Vector2 d)
    {
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.tag == "Player")
            {
                dir = d;
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
