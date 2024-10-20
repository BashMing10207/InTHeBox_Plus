
using UnityEngine;

public class kick : MonoBehaviour
{
    [SerializeField]
    private LayerMask la;
    [SerializeField]
    private Transform par;
    [SerializeField]
    private Animator kickanim;
    RaycastHit hit;
    Vector3 dir;
    public bool kicking,parryable;
    public Rigidbody ri;
    public float jump = 10,kickpower=0.7f,uppower = 10;
    float dx, dy;
    public AudioClip woo, dash,attack,attack2,robot;
    public AudioSource aud;
    public Light light;
    public GameObject dark;
    public ParticleSystem part_normal,part_parry;
    // Start is called before the first frame update
    void Start()
    {
      kicking = false;
    }
    public void at()
    {
        aud.PlayOneShot(woo);
        aud.PlayOneShot(robot);
        //if (Physics.CheckCapsule(par.position, par.position + (par.forward*(dy+1) + par.right*dx).normalized * 3, 0.5f, la))
            //ri.AddForce((par.forward * (dy + 1) + par.right * dx) * -jump + Vector3.up*2, ForceMode.Impulse);
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (!kickanim.GetCurrentAnimatorStateInfo(0).IsName("kick1"))
        {   dx = Input.GetAxisRaw("Horizontal");
            dy = Input.GetAxisRaw("Vertical");
            kickanim.SetFloat("x", dx);
            kickanim.SetFloat("z", dy);
            kicking = false;
        }
        else
        {
            kicking = true;
        }

        kickanim.SetBool("kick", Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftAlt));
    }

    private void OnTriggerEnter(Collider other)
    {if(!other.CompareTag("Player"))
        {
            timemana.stoptime = 0.1f;
            aud.PlayOneShot(dash);
            ri.AddForce((par.forward * (dy + 1) + par.right * dx).normalized * -jump + Vector3.up * uppower, ForceMode.Impulse);
            if (other.TryGetComponent<hp>(out hp obj))
            {
                if(parryable)
                {
                    kickanim.SetBool("parry", true);
                    //light.enabled = true;
                    dark.SetActive(true);
                    Invoke(nameof(timeslow), 0.01f);
                    part_parry.Play();
                    pl_hp.inst.damage(Random.Range(-0.1f, -1f));

                }
                else
                {
                    timemana.stoptime = 0.18f;
                }

                Invoke(nameof(lightoff), 0.2f);

                aud.PlayOneShot(attack);
                aud.PlayOneShot(attack2);
                obj.GetComponent<Rigidbody>().AddForce((par.forward * (dy + 1) + par.right * dx).normalized * jump + Vector3.up * uppower, ForceMode.Impulse);
                //obj.GetComponent<Rigidbody>().AddExplosionForce(jump * kickpower, transform.position, 5f, 2f, ForceMode.Impulse);
            }
            else
            {
                part_normal.Play();
            }
        }

    }

    void timeslow()
    {
        timemana.stoptime = 0.23f;
    }

    void lightoff()
    {
        kickanim.SetBool("parry", false);
        light.enabled = false;
        dark.SetActive(false);
    }
}
