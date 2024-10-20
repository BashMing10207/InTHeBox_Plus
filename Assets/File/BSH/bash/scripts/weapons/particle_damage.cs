using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_damage : MonoBehaviour
{
    public float damage;
    public bool no_attack_en,no_attack_pl;
    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent<hp>(out hp ming))
        {
            ming.damage(damage);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<hp>(out hp ming))
        {
            if(no_attack_en && other.TryGetComponent<enemy01>(out enemy01 ming2))
            {
                return;
            }
            else
            if (no_attack_pl && other.TryGetComponent<pl_hp>(out pl_hp ming3))
            {
                return;
            }

            ming.damage(damage);
            

        }
    }
}
