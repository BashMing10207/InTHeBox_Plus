using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enable_inst : MonoBehaviour
{
    public GameObject gameobj;
    private void OnEnable()
    {
        Instantiate(gameobj, transform.position, transform.rotation);
    }

}
