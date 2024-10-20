using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear : MonoBehaviour
{
    public int wpnum;
    public int nextmapnum;
    public float sizechange=1;
    //public static Transform a;

    private void Awake()
    {
       // a = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //ground01.Instance.change(nextmapnum);
            updown_wall.ming.changeround();
            gameObject.SetActive(false);
            //plscalemanager.plsc.scchange(sizechange);
            //player_move.plcam.root.transform.localScale = Vector3.one*sizechange;
            //Destroy(gameObject);
        }
    }
}
