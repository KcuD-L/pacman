using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> EnemyList;

    void Start()
    {
        Instantiate(EnemyList[Random.Range(0, EnemyList.Count+1)], gameObject.transform);
    }

}
