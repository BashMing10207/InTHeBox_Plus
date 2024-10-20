using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool_mana : MonoBehaviour
{
    public GameObject bullet;
    public static pool_mana poolmom;
    public static Transform 애미;
    // Start is called before the first frame update
    void Awake()
    {
        if (poolmom == null)
            poolmom = GetComponent<pool_mana>();
        if(애미 == null)
            애미= transform;

        create(transform,Vector3.zero);
    }

    public void create(Transform tr,Vector3 look)
    {
        if (transform.childCount == 0)
        {
            Instantiate(bullet, transform);
        }
        Transform ch1 = transform.GetChild(0);
        ch1.parent = null;
        ch1.transform.position = tr.position;
        ch1.transform.LookAt(look);
        ch1.gameObject.SetActive(true);

    }
}