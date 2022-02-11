using UnityEngine;
using UC2D;

public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 2;
    [SerializeField] float offset = 0.1f;
    private Vector2 dir,pos,inp, off, next;

    private void Start()
    {
        off = new Vector2(offset, offset);
        dir = new Vector2(1, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * speed;

        pos = transform.position;
        if (Input.anyKey)
        {
            Vector2 finp = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            finp = Axis.EquateTo4Axis(finp);            
            if (finp != Vector2.zero)
            {
                next = finp;
            }
        }
        Repeat();
    }

    private void Repeat()
    {
        bool[] minOff = Vector.Compare(pos, Vector.Round(pos) - off);
        bool[] maxOff = Vector.Compare(Vector.Round(pos) + off, pos);
        bool isWall = Axis.Touch(pos, pos + next, "Wall");
        if (minOff[0] && minOff[1] && maxOff[0] && maxOff[1] && !isWall)
        {
            dir = next;
            transform.localRotation = Axis.LookAt2D(next);
        }
    }
}
