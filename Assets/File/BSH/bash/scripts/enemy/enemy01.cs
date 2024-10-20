using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy01 : hp
{
    public astar02 nav;
    public LayerMask la;
    RaycastHit hit;
    bool visiable;
    public Animator enani;
    public ParticleSystem bullet;
    public GameObject dieeffect;
    public AudioSource ensound;
    public AudioClip pain,gunsound,charge;
    public float distance = 18,speed=6;
    public bool melee,boom;
    public static int encount=0;

    private void OnEnable()
    {
        encount++; 
    }
    public override void damage(float damage)
    {
        ensound.PlayOneShot(pain);
        if (health - damage <= 0)
        {
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
    }
    private void OnDestroy()
    {
        --encount;
        if (encount == 0)
        {
            updown_wall.ming.ani.SetTrigger("next");
            updown_wall.ming.enden();
            //updown_wall.ming.changeround();
        }
    }

    public override void die()
    {
        Instantiate(dieeffect,transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        nav.speed = speed;
        enani.SetBool("at", false);
        if (Physics.Raycast(transform.position,player_move.plcam.position-transform.position,out hit,distance,la,QueryTriggerInteraction.Ignore))
        {
            if(hit.collider.CompareTag("Player"))
            {
                    nav.speed = 0.1f;
                enani.SetBool("at", true);
            }
        }
    }
    public void attack()
    {
        ensound.PlayOneShot(gunsound);
        if(melee)
        {

        }
        else if (boom)
        {
            Instantiate(dieeffect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            bullet.Play();
        }

    }
public void charging()
    {
        ensound.PlayOneShot(charge);
    }
}
