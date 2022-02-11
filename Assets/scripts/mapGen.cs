using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGen : MonoBehaviour
{
    public Vector2 cord;

    [SerializeField] private List<Texture2D> maps;
    [SerializeField] private GameObject Owall, Oruby, Oenemy, Ocoin, OghostWall, OBuff;
    [SerializeField] private int buffChance;

    private Color wall, ruby, enemy, coin, ghostWall;
    private Vector3 ob;

    void Start()
    {
        int number = Random.Range(0, maps.Count);
        Texture2D curentMap = maps[number];
        wall = curentMap.GetPixel(0,0);
        ruby = curentMap.GetPixel(1,0);
        enemy = curentMap.GetPixel(2,0);
        coin = curentMap.GetPixel(3,0);
        ghostWall = curentMap.GetPixel(4,0);
        StartCoroutine(Generate(curentMap));
        ob = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z) - new Vector3(1,1);
    }

    private IEnumerator Generate(Texture2D curentMap)
    {
        yield return new WaitForEndOfFrame();
        for (int x = 0; x < 15; x++)
        {
            for (int y = 1; y < 16; y++)
            {
                if (curentMap.GetPixel(x, y) == wall)
                {
                    Instantiate(Owall, ob + new Vector3(x+1,y,0), Quaternion.identity, gameObject.transform);
                }
                if (curentMap.GetPixel(x, y) == ruby)
                {
                    Instantiate(Oruby, ob + new Vector3(x+1, y, 0), Quaternion.identity, gameObject.transform);
                }
                if (curentMap.GetPixel(x, y) == enemy)
                {
                    Instantiate(Oenemy, ob + new Vector3(x+1, y, 0), Quaternion.identity, gameObject.transform);
                }
                if (curentMap.GetPixel(x, y) == coin)
                {
                    int rand = Random.Range(0, 500);
                    if (rand < buffChance)
                    {
                        Instantiate(OBuff, ob + new Vector3(x + 1, y, 0), Quaternion.identity, gameObject.transform);
                    }
                    else
                    {
                        Instantiate(Ocoin, ob + new Vector3(x + 1, y, 0), Quaternion.identity, gameObject.transform);
                    }
                }
                if (curentMap.GetPixel(x, y) == ghostWall)
                {
                    Instantiate(OghostWall, ob + new Vector3(x+1, y, 0), Quaternion.identity, gameObject.transform);
                }
            }
        }
    }

    public void GenNull()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Generate(maps[4]);
    }

    public void Des()
    {
        Destroy(gameObject);
    }

}
