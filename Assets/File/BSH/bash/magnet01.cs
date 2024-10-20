using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet01 : MonoBehaviour
{
    public int helth = 10000;

    public void damage(int damage)
    {
        helth += damage;
        if(helth <= 0)
        {
            print("À¸¾Ç");
        }
    }    
}
