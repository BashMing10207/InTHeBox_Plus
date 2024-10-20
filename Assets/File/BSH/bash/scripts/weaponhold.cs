using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponhold : MonoBehaviour
{
    public wpmanager wpmana;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<weapons>(out weapons wp))
        {
            if(wpmana.get(wp.weaponnum))
            wp.holded();
        }
    }
}
