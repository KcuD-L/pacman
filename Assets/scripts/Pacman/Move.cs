using UnityEngine;
using UC2D;

public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 2;
    [SerializeField] float offset = 0.1f;
    private Vector2 dir,pos,inp, next, off;

    private void Start()
    {
        off = new Vector2(offset, offset);
    }

    private void FixedUpdate()
    {
        pos = transform.position;
        if (Input.anyKey)
        {
            KeyPressed();
        }

        Repeat();

        rb.velocity = dir * speed;
    }

    private void KeyPressed()
    {
        bool[] minOff = Vector.Compare(pos, Vector.Round(pos) - off);
        bool[] maxOff = Vector.Compare(Vector.Round(pos) + off, pos);

        inp = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        inp = Axis.EquateTo4Axis(inp);
        if (inp != Vector2.zero)
        {
            bool isWall = Axis.Touch(pos, next, "Wall");
            if (!isWall && minOff[0] && minOff[1] && maxOff[0] && maxOff[1] && dir != inp)
            {
                transform.position = Vector.Round(transform.position);
                dir = inp;
                next = Vector2.zero;
                newAngle(Axis.LookAt2D(inp));
            }
            else
            {
                next = inp;
            }
        }
    }

    private void Repeat()
    {
        bool[] minOff = Vector.Compare(pos, Vector.Round(pos) - off);
        bool[] maxOff = Vector.Compare(Vector.Round(pos) + off, pos);
        bool isWall = Axis.Touch(pos, next, "Wall");
        if (!isWall && minOff[0] && minOff[1] && maxOff[0] && maxOff[1] && next != Vector2.zero)
        {
            dir = next;
            inp = next;
            newAngle(Axis.LookAt2D(next));
        }
    }


    private void newAngle(float angle)
    {
        transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos + inp / 5, pos + inp - inp / 10);
    }
}
