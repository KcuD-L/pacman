using UnityEngine;
using UC2D;

public class RandomDir : MonoBehaviour
{
    [SerializeField] private int speed;

    private Vector2 dir;
    private Rigidbody2D rb;

    private void Start()
    {
        dir = Axis.EquateTo4Axis(Axis.RandomAxis());
        if (dir == Vector2.zero)
        {
            dir = new Vector2(1, 0);
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.2f, 1f, 1f);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Wall" || col.collider.tag == "EWall" || col.collider.tag == "Enemy")
        {
            dir = Axis.EquateTo4Axis(Axis.RandomAxis());
            transform.position = Vector.Round(transform.position);
            if (dir == Vector2.zero)
            {
                dir = new Vector2(1, 0);
            }
        }
    }
}
