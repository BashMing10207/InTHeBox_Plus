using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plscalemanager : MonoBehaviour
{
    public static plscalemanager plsc;
    public Transform weaponspar;
    private void Awake()
    {
        plsc = this;
    }
    public void scchange(float a)
    {
        transform.localScale = Vector3.one * a;
        weaponspar.localScale = Vector3.one * a;

    }
}
