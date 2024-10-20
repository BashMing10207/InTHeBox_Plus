using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updown_wall : MonoBehaviour
{
    Transform[,] walls = new Transform[16,16];
    float[,] targetpos=new float[16,16];
    public int round=0;
    public static updown_wall ming;
    public GameObject[] enemyarry;
    public Transform enemysp;
    public Animator ani;
    public GameObject endlevel;
    public float hightblok = 90, downblock = 45;

    private void Awake()
    {

        ming = this;
        for(int i = 0; i < 16; i++)
        {
            for(int j = 0; j < 16; j++)
            {
                //print(i * 16 + j);
                walls[i,j] = transform.GetChild(16*i+j);
                targetpos[i, j] = downblock;
            }
        }
        changeround();
        
    }

    public void enden()
    {
        endlevel.SetActive(true);
    }

    public void changeround()
    {
        ++round;
        if(round%3 != 0)
        {
            ani.SetTrigger("fuck");
        }

        ani.SetTrigger("next");
        for (int i = 0; i < round; i++)
        {
            for (int j = 0; j < round; j++)
            {
                targetpos[i, j] = hightblok;
            }
        }
        Invoke(nameof(delayensp), 0.3f);
    }
    void delayensp()
    {
       enemyarry[round - 1].SetActive(true);

    }

    private void FixedUpdate()
    {
        
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                walls[i, j].position = walls[i, j].position + Vector3.up * (Mathf.Lerp(walls[i, j].position.y,targetpos[i, j],0.1f) - walls[i, j].position.y);
            }
        }
    }
}
