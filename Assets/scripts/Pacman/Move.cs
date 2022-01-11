using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UC2D;

public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 2;
    private Vector2 dest = new Vector2(0,0);

    private void Start()
    {
        dest = transform.position;
    }
    private void FixedUpdate()
    {        
        bool valid(Vector2 dir)
        {
            bool isWall = false;
            Vector2 pos = transform.position;
            RaycastHit2D[] hit = Physics2D.LinecastAll(pos + dir, pos);
            for (int i=0; i < hit.Length; i++)
            {
                if(hit[i].collider.tag == "Wall")
                {
                    isWall = true;
                }
            }
            return (!isWall);
        }

        if ((Vector2)transform.position == dest)
        {
            if (Input.GetAxis("Horizontal") == 1f && valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
                newAngle(0);
            }
            if (Input.GetAxis("Horizontal") == -1f && valid(Vector2.left))
            {
                dest = (Vector2)transform.position + Vector2.left;
                newAngle(180);
            }
            if (Input.GetAxis("Vertical") == 1f && valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
                newAngle(90);
            }
            if (Input.GetAxis("Horizontal") == -1f && valid(Vector2.down))
            {
                dest = (Vector2)transform.position + Vector2.down;
                newAngle(-90);
            }
            Debug.Log("");
        }

        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        rb.MovePosition(p);
    }

    private void newAngle(int angle)
    {
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

}
