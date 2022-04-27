using UnityEngine;

using UC2D;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 2;

    [SerializeField] public Vector2 inp, targetPos;
    public bool WallEater;
    public float speedBuf = 0f;

    private void Start()
    {
        targetPos = (Vector2)transform.position;
    }

    public void Inp(Vector2 vec)
    {
        inp = vec;
    }

    private void FixedUpdate()
    {
        bool IsWall=false;
        
        transform.position = Vector2.MoveTowards((Vector2)transform.position, targetPos, (speed + speedBuf) * Time.deltaTime);

        Vector2 input = new Vector2(0,0);

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Axis.EquateTo4Axis(input);

        if(input != Vector2.zero)
        {
            inp = input;
        }

        RaycastHit2D[] col = Physics2D.LinecastAll(targetPos, targetPos + inp);
        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].collider.tag == "Wall" || col[i].collider.tag == "EWall")
            {
                IsWall = false;
            }
            else
            {
                IsWall = true;
            }
        }

        if (targetPos == (Vector2)transform.position)
        {
            if (IsWall || gameObject.GetComponent<PacmanContact>().GetWallBuff())
            {
                targetPos = Vector.Round((Vector2)transform.position + inp);
                if (inp == new Vector2(0, -1))
                {
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                }
                if (inp == new Vector2(0, 1))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                }
                if (inp == new Vector2(-1, 0))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                }
                if (inp == new Vector2(1, 0))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            return;
        }
        if (Mth.isOutLoop(transform.position.x, 0, 13.9f) || Mth.isOutLoop(transform.position.y, 0, 13.9f))
        {
            transform.position = new Vector2(Mth.Loop(transform.position.x, 0, 13.9f), Mth.Loop(transform.position.y, 0, 13.9f));
            targetPos = new Vector2(Mth.Loop(transform.position.x, 0, 13.9f), Mth.Loop(transform.position.y, 0, 13.9f));
        }
    }
}

