using UnityEngine;
using UC2D;

public class Operator : MonoBehaviour
{
    [SerializeField] GameObject cam, player;
    [SerializeField] float speed;
    private void FixedUpdate()
    {
       cam.transform.position = Vector.LerpIgnoreZ(cam.transform.position, player.transform.position, speed*Time.deltaTime);
    }
}