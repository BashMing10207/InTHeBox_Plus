using UnityEngine;

public class pool : MonoBehaviour
{
    public static Transform bullet_am2, ex_am2;
    public bool isboom;
    // Start is called before the first frame update

    // Update is called once per frame
    public void destroy(Transform tr)
    {
        transform.parent = null;
        transform.parent = pool_mana.¾Ö¹Ì;
        gameObject.SetActive(false);

    }
}

