using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UC2D;

public class worldGen : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private Vector2 PCord;
    [SerializeField] GameObject gen;
    private Vector2 pos;
    private GameObject[] maze;

    private void Update()
    {
        pos = transform.position;
        if(PCord.x * size < pos.x)
        {
            PCord += new Vector2(1,0);
        }
        if (PCord.x * size > pos.x)
        {
            PCord -= new Vector2(1, 0);
        }
        if (PCord.y * size < pos.y)
        {
            PCord += new Vector2(0, 1);
        }
        if (PCord.y * size > pos.y)
        {
            PCord -= new Vector2(0, 1);
        }
        MazeCheck();
        MazeControl();
    }
    private void MazeCheck()
    {
        maze = GameObject.FindGameObjectsWithTag("Maze");
        if(maze.Length == 0)
        {
            Vector3 mpos = new Vector3(size * PCord.x, size * PCord.y, 2);
            GameObject fm = Instantiate(gen, mpos, Quaternion.Euler(0,0,0));
            fm.GetComponent<mapGen>().GenNull();
            fm.GetComponent<mapGen>().cord = new Vector2(PCord.x, PCord.y);
        }
    }
    
    private void MazeControl()
    {
        bool u = false;
        bool d = false;
        bool l = false;
        bool r = false;
        bool lu = false;
        bool ru = false;
        bool ld = false;
        bool rd = false;

        for (int i = 0; i < maze.Length; i++)
        {

            if(maze[i].GetComponent<mapGen>().cord.x > PCord.x + 1 || maze[i].GetComponent<mapGen>().cord.x < PCord.x - 1 ||
               maze[i].GetComponent<mapGen>().cord.y > PCord.y + 1 || maze[i].GetComponent<mapGen>().cord.y < PCord.y - 1)
            {
                maze[i].GetComponent<mapGen>().Des();
            }

            if (maze[i].GetComponent<mapGen>().cord == new Vector2 (PCord.x, PCord.y + 1))
            {
                u = true;
            }
            if (maze[i].GetComponent<mapGen>().cord == new Vector2(PCord.x, PCord.y - 1))
            {
                d = true;
            }
            if (maze[i].GetComponent<mapGen>().cord == new Vector2(PCord.x - 1, PCord.y))
            {
                l = true;
            }
            if (maze[i].GetComponent<mapGen>().cord == new Vector2(PCord.x + 1, PCord.y))
            {
                r = true;
            }
            if (maze[i].GetComponent<mapGen>().cord == new Vector2(PCord.x - 1, PCord.y + 1))
            {
                lu = true;
            }
            if (maze[i].GetComponent<mapGen>().cord == new Vector2(PCord.x + 1, PCord.y - 1))
            {
                ru = true;
            }
            if (maze[i].GetComponent<mapGen>().cord == new Vector2(PCord.x - 1, PCord.y - 1))
            {
                ld = true;
            }
            if (maze[i].GetComponent<mapGen>().cord == new Vector2(PCord.x + 1, PCord.y - 1))
            {
                rd = true;
            }
        }
        if (!u)
        {
            CreateMap(new Vector2(PCord.x, PCord.y + 1));
        }
        if (!d)
        {
            CreateMap(new Vector2(PCord.x, PCord.y -1));
        }
        if (!l)
        {
            CreateMap(new Vector2(PCord.x - 1, PCord.y));
        }
        if (!r)
        {
            CreateMap(new Vector2(PCord.x + 1, PCord.y));
        }
        if (!lu)
        {
            CreateMap(new Vector2(PCord.x - 1, PCord.y + 1));
        }
        if (!ru)
        {
            CreateMap(new Vector2(PCord.x + 1, PCord.y + 1));
        }
        if (!ld)
        {
            CreateMap(new Vector2(PCord.x - 1, PCord.y - 1));
        }
        if (!rd)
        {
            CreateMap(new Vector2(PCord.x + 1, PCord.y - 1));
        }
    }

    private void CreateMap(Vector2 cord)
    {
        Vector3 mpos = new Vector3(cord.x * size, cord.y * size, 2);
        GameObject fm = Instantiate(gen, mpos, Quaternion.Euler(0, 0, 0));
        fm.GetComponent<mapGen>().cord = cord;
    }
}
