using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pl_hp : hp
{
    public GameObject closeup;
    public GameObject closeupTwo;
    public AudioChorusFilter filter;
   public Animator scr;
   public static pl_hp inst;
    public Image bar;
    bool damageable = true;
    void Awake()
    {
        health = max;
        inst = this;
    }

    public override void damage(float damage)
    {
        if(damageable)
        {
            scr.SetTrigger("blood");
            if (health - damage <= 0)
            {
                health = 0;
                die();
            }
            else
            {
                health -= damage;
            }
            if (health > max)
            {
                health = max;
            }
            bar.fillAmount = (float)health / (float)max / 2f;
            damageable = false;
            Invoke(nameof(nogod), 0.1f);
        }
       
    }
    void nogod()
    {
        damageable = true;
    }

    public override void die()
    {
        timemana.slowtime = 0.01f;
        filter.enabled = true;
        closeup.SetActive(true);
        closeupTwo.SetActive(false);
        health = 0;
    }
}
