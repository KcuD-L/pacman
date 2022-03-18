using UnityEngine;
using UC2D;

public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 2;
    [SerializeField] float offset = 0.1f;
    [SerializeField] GameObject map;
    private Vector2 dir,pos, off, next;
    public bool WallEater;
    public float speedBuf = 0f;

    private void Start()
    {
        off = new Vector2(offset, offset);
        dir = new Vector2(1, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * (speed + speedBuf);

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
        if (Mth.isOutLoop(transform.position.x, 0, 14) || Mth.isOutLoop(transform.position.y, 0, 14))
        {
            transform.position = new Vector3(Mth.Loop(transform.position.x, 0, 14), Mth.Loop(transform.position.y, 0, 14), 0);
            map.GetComponent<mapGen>().GenNull();
        }
    }

    private void Repeat()
    {
        bool[] minOff = Vector.Compare(pos, Vector.Round(pos) - off);
        bool[] maxOff = Vector.Compare(Vector.Round(pos) + off, pos);
        bool isWall = Axis.Touch(pos, pos + next, "Wall");
        if (minOff[0] && minOff[1] && maxOff[0] && maxOff[1])
        {
            if (!isWall || WallEater)
            {
                dir = next;
                transform.localRotation = Axis.LookAt2D(next);
            }
        }
    }
}
