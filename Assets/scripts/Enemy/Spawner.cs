using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> EnemyList;

    void Start()
    {
        Instantiate(EnemyList[Random.Range(0, EnemyList.Count)], transform.position, Quaternion.identity, gameObject.transform);
    }

}
