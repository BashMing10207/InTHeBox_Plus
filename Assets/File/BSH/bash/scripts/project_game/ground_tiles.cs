
using UnityEngine;

public class ground_tiles : MonoBehaviour
{
    
    Vector3 temppos,targetpos;
    public float height = 0;
    public static Animator animator;
    
    public void Awake()
    {
        if(animator == null)
            animator = transform.parent.GetComponent<Animator>();

        temppos = transform.localScale ;
        targetpos = transform.localScale;
        //height = 0;
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Finish") && !animator.isActiveAndEnabled)
        {
            targetpos = new Vector3(10,temppos.y/height,10);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Finish") && !animator.isActiveAndEnabled)
        {
            targetpos = temppos;
        }
    }
    private void Update()
    {if(!animator.isActiveAndEnabled)
        transform.localScale = Vector3.Slerp(transform.localScale,targetpos, 0.1f);
        else
        {
            
        }
    }
}
