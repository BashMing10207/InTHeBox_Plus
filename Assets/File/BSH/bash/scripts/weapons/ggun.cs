using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ggun : MonoBehaviour
{
    public AudioClip audsource;
    public AudioSource aud;
    public ParticleSystem bullet;
    public Animator animator,camani;
    public int ammo,max;
    public bool left,shot;
    float speed = 1;
    public Rigidbody rb;
    public Transform bullets;
    Vector3 aaaa;

    private void Start()
    {
        camani = player_move.mingming.cam_ani;
    }

    private void OnEnable()
    {
        ammo = max;
    }

    private void Update()
    {if(!left)
        {
            animator.SetBool("at", Input.GetKey(KeyCode.Mouse0));
            if(Input.GetKeyDown(KeyCode.Q))
            {
                shot = !shot;
            }
        }
    else
        {
            animator.SetBool("at", Input.GetKey(KeyCode.Mouse1));
            if (Input.GetKeyDown(KeyCode.E))
            {
                shot= !shot;
            }
        }

        if(Input.GetKey(KeyCode.R))
        {
            animator.SetTrigger("reload");
        }

        //animator.SetBool("var",shot);

        if(shot)
        {
            speed = 99;
        }
        else
        {
            speed = 1;
        }

        //animator.SetFloat("speed", speed);

    }

    private void FixedUpdate()
    {
       bullet.transform.LookAt(player_move.camview);
    }

    public void skillcehck()
    {
        if(!shot)
        {
           // rb.AddForce(player_move.plcam.forward * 9000);
        }
    }

    public void attack()
    {
        if(ammo > 0)
        {
            player_move.mingming.bounce += left == true ? 1 : -1;
            bullet.Play();
            aud.PlayOneShot(audsource);
            bullets.GetChild(ammo - 1).gameObject.SetActive(false);
            //aud.PlayOneShot(a);
            ammo--;
        }
        if(ammo <= 0)
        {
            animator.SetTrigger("reload");
        }

    }
    public void reload()
    {
        ammo = max;
        for(int i = 0; i < bullets.childCount; i++)
        {
            bullets.GetChild(i).gameObject.SetActive(true);
        }

    }
    public void sound_make(AudioClip a)
    {
        aud.PlayOneShot(a);
    }
}
