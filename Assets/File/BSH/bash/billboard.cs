using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player_move.plcam.position);
    }
}
