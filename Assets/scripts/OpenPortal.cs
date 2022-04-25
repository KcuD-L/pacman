using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPortal : MonoBehaviour
{

    private void Start()
    {
        PacmanContact.OnCollect += Open;
    }

    private void Open()
    {
        Desable();
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
