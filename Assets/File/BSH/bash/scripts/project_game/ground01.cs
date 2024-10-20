using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ground01 : MonoBehaviour
{
    public static ground01 Instance;
    public int max = 3;
    Transform player;
    Transform[,] blocks = new Transform[16,16];
    Vector3[,] blockstmp = new Vector3[16,16];
    Vector3[,] blockposs = new Vector3[16,16]; 
    public GameObject originblock;
    public Animator ani;
    public static Transform waltr;
    public static bool aniable;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

       // y = Random.Range(-1, 7);
       // player = player_move.plcam;
       //for(int i = 0; i < 16; i++)
       // {
       //     for(int j = 0; j < 16; j++)
       //     {
       //         y = Random.Range(y - 2, y + 2);
       //         y = Mathf.Clamp(y, -2, 7);
       //         blocks[i,j] = Instantiate(originblock, new Vector3(i * 10, y * 3, j * 10),transform.rotation).transform;
       //         blocks[i,j].parent = transform;
       //         //blocks[i, j].GetComponent<ground_tiles>().ming();
       //     }
       // }

       // for (int i = 0; i < 16; i++)
       // {
       //     for (int j = 0; j < 16; j++)
       //     {
       //         blockstmp[i, j] = blocks[i,j].position;
       //     }
       // }

    }

    public void change(int index)
    {

        ani.SetInteger("mapnum", index);
        ani.enabled = true;
        ani.SetTrigger("cum");
        Invoke(nameof(disable2), 0.91f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            change(Random.Range(0,max));

        }
    }
    public void disable()
    {
        //ani.enabled = false;
    }
    public void disable2()
    {
        ani.enabled = false;
    }
    // Update is called once per frame
    void FixedUpdate1()
    {
        blockposs = blockstmp;

        for (int i = (int)(player.position / 10).x -2; i < (int)(player.position /10).x +2; i++)
        {
            for (int j = (int)(player.position / 10).x - 2; j < (int)(player.position / 10).x + 2; j++)
            {
                if(i > 0 && j >0 && i < 16 && j < 16)
                blockposs[i, j] = new Vector3(blocks[i, j].position.x, 5, blocks[i, j].position.z);
            }
        }

        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                blocks[i,j].position = Vector3.Lerp(blocks[i,j].position,blockposs[i,j],0.4f);
            }
        }

    }
}
