using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakweapon : MonoBehaviour
{
    public AudioSource aud;
    public ParticleSystem par;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void particle()
    {
        pl_hp.inst.damage(-4);
        par.Play();
    }
    public void audioss(AudioClip a)
    {
        aud.PlayOneShot(a);
    }
    public void dis()
    {
        gameObject.SetActive(false);
    }
}
