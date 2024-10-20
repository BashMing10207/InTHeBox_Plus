using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timemana : MonoBehaviour
{
    public static float stoptime =1,slowtime = 1;

    private void Awake()
    {
        slowtime = 1;
    }

    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        
        if(stoptime > 0 )
        {
            Time.timeScale = 0.01f;
            stoptime -= Time.unscaledDeltaTime;
        }
        else
        {

                Time.fixedDeltaTime = 0.02f * (int)(slowtime * 10f) / 10;
                Time.timeScale = slowtime;

        }


    }
    
}
