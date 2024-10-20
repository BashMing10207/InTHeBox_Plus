
using UnityEngine;
using UnityEngine.UI;


public class player_move : MonoBehaviour
{
    [SerializeField] private Rigidbody ri;
    [SerializeField] private float speed, runspeed, jump, mouse_sens,dash_speed,damp_sped;
    [SerializeField] private Transform cam, camera_obj, movdir, main_camera;
    [SerializeField] LayerMask la;
    public Animator cam_ani, kickanim;
    float rothor, rotver, lerp_hor, lerp_ver, anim_rot, cam_rotanisens;
    public bool tmp, kicking, walking;
    public float spring, damper, maxforce,dash_rate,dash_count,max_move_rot=4, bounce;
    Vector3 dampingdir,dampingdir2;
    RaycastHit hit;
    public static Transform plcam;
    public static Vector3 camview = Vector3.zero;
    

    public static player_move mingming;

    public Vector3 curvel;
    public AudioSource audiosource;
    public AudioClip audioClip;
    public AudioClip jumpAudioClip;
    public Image stemina;
    void Awake()
    {
        plcam = cam;
        Cursor.lockState = CursorLockMode.Locked;
        mingming = this;
    }

    // Update is called once per frame
    private void Update()
    {
        //rot
        rothor += Input.GetAxis("Mouse X") * mouse_sens * Time.deltaTime + bounce;
        rotver = Mathf.Clamp(rotver - Input.GetAxis("Mouse Y") * mouse_sens * Time.deltaTime, -89, 89);
        transform.rotation = Quaternion.Euler(0, rothor, 0);
        cam.localRotation = Quaternion.Euler(rotver, 0, 0); //  cam.rotation = Quaternion.Euler(rotver, rothor, 0);
        anim_rot = Mathf.Lerp(anim_rot, -Input.GetAxis("Mouse X")*max_move_rot, Time.deltaTime * 100);
        main_camera.localEulerAngles = new Vector3(0, 0, anim_rot);

        //cam
        camera_obj.position = cam.position;
        camera_obj.rotation = cam.rotation;

        if (Physics.CheckSphere(transform.position+Vector3.down*0.9f*transform.localScale.y,0.2f*transform.localScale.y,la))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ri.AddForce(Vector3.up * jump, ForceMode.Impulse);
                audiosource.PlayOneShot(jumpAudioClip);
            }
            tmp = true;
        }
        else
        {
            tmp = false;
           // ri.AddForce(-Vector3.up*5);
        }

        if (dash_count > 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                dash_rate = dash_speed;
                dash_count--;
                audiosource.PlayOneShot(audioClip);
            }
        }


    }
    void FixedUpdate()
    {
        if(bounce != 0)
        {
            bounce = Mathf.Lerp(bounce, 0, 0.5f);
        }

        if (dash_count < 3)
        {
            dash_count += Time.fixedDeltaTime;
            stemina.fillAmount = dash_count / 6;
        }

        if (Physics.Raycast(cam.position,cam.forward,out hit,2000,la))
        {
            camview = hit.point;
        }
        else
        {
            camview = cam.position + cam.forward * 55f;
        }
        kicking = !kickanim.GetCurrentAnimatorStateInfo(0).IsName("kick1");
        //ri.velocity = Vector3.Lerp(ri.velocity, (movdir.forward * Input.GetAxis("Vertical") + movdir.right *
        //Input.GetAxis("Horizontal")) * speed * runspeed + Vector3.up * (Vector3.Angle(hit.normal, transform.up) < 5 ? ri.velocity.y : -1)
        //, 0.7f);
        //mov
        if (tmp && kicking)
        {

            dampingdir = transform.InverseTransformDirection(ri.velocity);
            ri.AddForce((transform.forward * Input.GetAxis("Vertical") + transform.right *
                        Input.GetAxis("Horizontal")) * speed * runspeed - (ri.velocity/1.05f) + Vector3.up * ri.velocity.y,ForceMode.VelocityChange);
            curvel = ri.velocity;
        }
        else
        {
            //if (walking == false)
            {
                
                walking = true;
            }
            ri.AddForce((transform.forward * Input.GetAxis("Vertical") + transform.right *
           Input.GetAxis("Horizontal")) * speed * runspeed);
        }
        lerp_hor = Mathf.Lerp(lerp_hor, Input.GetAxis("Horizontal") * 2, 0.5f);
        lerp_ver = Mathf.Lerp(lerp_ver, Input.GetAxis("Vertical") * 2, 0.5f);
        cam_ani.SetFloat("movx", lerp_hor);
        cam_ani.SetFloat("movz", lerp_ver);

        if (dash_rate > 0)
        {
            ri.velocity = (transform.forward * Input.GetAxisRaw("Vertical") + transform.right *
            Input.GetAxisRaw("Horizontal")) * dash_rate;
            dash_rate -= Time.fixedDeltaTime * dash_speed * 5;
        }

    }
}

