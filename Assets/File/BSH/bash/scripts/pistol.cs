
using UnityEngine;

public class pistol : MonoBehaviour
{
    [SerializeField] bool left;
    public Animator pistolarm;
    public ParticleSystem par;
    public AudioSource aud;
    public AudioClip gunsound;
    // Update is called once per frame
    void Update()
    {
        if (left)
            pistolarm.SetBool("fire", Input.GetKey(KeyCode.Mouse0));
        else
            pistolarm.SetBool("fire", Input.GetKey(KeyCode.Mouse1));
    }
    public void firegun()
    {
        par.Play();
        aud.PlayOneShot(gunsound);
    }
}
