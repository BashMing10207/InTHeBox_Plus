using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPARTICLETRIGGER : MonoBehaviour
{
    public float distance=6;
    public ParticleSystem ps;
    GameObject[] fires;
    // Start is called before the first frame update
    void Start()
    {
        fires = GameObject.FindGameObjectsWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleTrigger()
    {
        
        //Get all particles that entered a box collider
        List<ParticleSystem.Particle> enteredParticles = new List<ParticleSystem.Particle>();
        int enterCount = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, enteredParticles);

        //Get all fires
        

        foreach (ParticleSystem.Particle particle in enteredParticles)
        {
            for (int i = 0; i < fires.Length; i++)
            {
                if (Vector3.Distance(fires[i].transform.position,particle.position) <= distance)
                {
                    fires[i].GetComponent<magnet01>().damage(-1);
                }
            }
        }
    }
}
