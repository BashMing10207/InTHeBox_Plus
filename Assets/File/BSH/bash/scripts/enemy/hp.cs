using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{   
    public float health,max =2;
    private void Awake()
    {
        health =  max;
    }
    public virtual void damage(float damage)
    {
        
        if (health - damage <= 0)
        {
            die();
        }
        else
        {
            health -= damage;
        }
        if(health > max) 
        {
            health = max;
        }
    }
    public virtual void die()
    {

    }
}
