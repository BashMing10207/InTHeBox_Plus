using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_move : MonoBehaviour
{ public string fuck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

public void scene()
    {
        SceneManager.LoadScene(fuck);
    }
}
