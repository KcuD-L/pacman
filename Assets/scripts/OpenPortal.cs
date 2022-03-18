using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPortal : MonoBehaviour
{
    [SerializeField] private Animator anim;


    private void Start()
    {
        PacmanContact.OnCollect += Open;
        Debug.Log("подписка");
        anim = GetComponent<Animator>();
    }

    private void Open()
    {
        Debug.Log("вмер");
        Desable();
        Destroy(gameObject);
        
        anim.SetBool("Active", true);
    }

    private void Desable()
    {
        PacmanContact.OnCollect -= Open;
    }
    
}
