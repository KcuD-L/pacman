using UnityEngine;
using UC2D;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 2;

    [SerializeField] private Vector2 inp, targetPos;
    public bool WallEater;
    public float speedBuf = 0f;

    private void Start()
    {
        targetPos = (Vector2)transform.position;
    }

    private void FixedUpdate()
    {
        bool IsWall=false;
        
        transform.position = Vector2.MoveTowards((Vector2)transform.position, targetPos, (speed + speedBuf) * Time.deltaTime);
        if (Input.anyKey)
        {
            inp = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            inp = Axis.EquateTo4Axis(inp);
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
            }
            return;
        }
        if (Mth.isOutLoop(transform.position.x, 0, 14) || Mth.isOutLoop(transform.position.y, 0, 14))
        {
            transform.position = new Vector2(Mth.Loop(transform.position.x, 0, 14), Mth.Loop(transform.position.y, 0, 14));
            targetPos = new Vector2(Mth.Loop(transform.position.x, 0, 14), Mth.Loop(transform.position.y, 0, 14));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)inp);
    }
}

