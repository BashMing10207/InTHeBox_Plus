
using UnityEngine;

public class lerp_cam : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private float speed;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = cam.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, cam.rotation, Time.deltaTime * speed);
    }
}
