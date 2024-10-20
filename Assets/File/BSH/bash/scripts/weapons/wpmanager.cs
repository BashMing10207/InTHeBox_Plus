using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wpmanager : MonoBehaviour
{
    public GameObject[] thrown_weapon;
    public GameObject[] enabled_weapon;
    public Transform pos;
    public GameObject breakarm,weaponsholder;
    public Animator anim,ani_this;
    public bool throwable,left;
    bool havew= false;



    private void Update()
    {
        //if (throwable)
        if(havew)
        {
            if (left)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    breakarm.SetActive(true);
                    throws();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    breakarm.SetActive(true);
                    throws();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        havew = false;
        for (int i = 0; i < enabled_weapon.Length; i++)
        {
            if (enabled_weapon[i].activeInHierarchy)
            {
                havew = true; break;
            }
        }
    }

    public void throws()
    {
        for (int i = 0; i <= enabled_weapon.Length; i++)
        {
            if (enabled_weapon[i].activeInHierarchy)
            {
                enabled_weapon[i].SetActive(false);
                thrown_weapon[i].SetActive(true);
                //Instantiate(thrown_weapon[i], pos.position, pos.rotation);
                break;
            }
        }
        weaponsholder.SetActive(true);

    }
    public bool get(int index)
    {
        for (int i = 0; i < enabled_weapon.Length; i++)
        {
            if (enabled_weapon[i].activeInHierarchy)
            {
                return false;
            }
        }
        enabled_weapon[index].SetActive(true);
        weaponsholder.SetActive(false);
        return true;
        //anim = enabled_weapon[index].GetComponent<Animator>();
    }
}
