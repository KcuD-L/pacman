using UnityEngine;
using UC2D;

public class Operator : MonoBehaviour
{
    [SerializeField] GameObject cam, player;
    private void Update()
    {
        cam.transform.position = Vector2D.IgnoreZ(player.transform.position, cam.transform.position);
    }
}
