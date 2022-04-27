using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPortal : MonoBehaviour
{

    [SerializeField] private GameObject portal;

    private void Start()
    {
        PacmanContact.OnCollect += Open;
    }

    private void Open()
    {
        Instantiate(portal, transform.position, Quaternion.identity, transform.parent);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Desable();
    }

    private void OnDisable()
    {
        Desable();
    }

    private void Desable()
    {
        PacmanContact.OnCollect -= Open;
    }
    
}
