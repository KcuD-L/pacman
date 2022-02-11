using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffCreator : MonoBehaviour
{
    [SerializeField] private List<GameObject> Buffs;

    private void Start()
    {
        Instantiate(Buffs[Random.Range(0, Buffs.Count)], transform.position, Quaternion.identity, gameObject.transform);
    }
}
