
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngineInternal;

public class paint_render : MonoBehaviour
{
    //public Texture3D texture;
    //public RenderTexture tx2;
    //public Camera cam;
    //public Texture2D depthtx, colors;
    //public Image imim;
    //public RawImage img;
    //public Sprite ming;
    //public Material material;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    tx2 = new RenderTexture(320, 320, 64, RenderTextureFormat.Depth);
    //    depthtx = new Texture2D(tx2.width,tx2.height,TextureFormat.RFloat,false);
    //    //tx2.depth = 24;
    //   // tx2.enableRandomWrite = true;
    //    tx2.Create();
    //    cam.SetReplacementShader(Shader.Find("DepthOnly"), "RenderType");
    //    //depthtx.Reinitialize(tx2.width, tx2.height);
    //    depthtx = new Texture2D(tx2.width, tx2.height);
    //    cam.targetTexture = tx2;
    //    cam.Render();

    //}
    //private void OnRenderImage(RenderTexture source, RenderTexture destination)
    //{
    //    if (material != null && cam != null)
    //    {
    //        // Copy the depth texture from the depthCamera
    //        Graphics.Blit(cam.targetTexture, destination, material);
    //    }
    //    else
    //    {
    //        // If material or depthCamera is not set, just pass through the image
    //        Graphics.Blit(source, destination);
    //    }

    //}
    //// Update is called once per frame
    //void Update()
    //{

    //    RenderTexture.active = tx2;
    //    depthtx.ReadPixels(new Rect(0, 0, tx2.width, tx2.height), 0, 0);
    //    Graphics.Blit(depthtx, tx2);
    //    depthtx.Apply();
    //    RenderTexture.active = null;

    //    img.texture = depthtx;
    //    //ming = Sprite.Create(depthtx, new Rect(0, 0, depthtx.width, depthtx.height), new Vector2(0.5f, 0.5f));
    //    //imim.sprite = ming;
    //}

    public Shader replacementShader; // (optional) If you want to visualize the result on a material
    private Material material;
   public GameObject ming;
    Texture2D suck;
    public RawImage imim;
    RenderTexture activeRT;
    public RenderTexture tempRT;
    private void Start()
    {
        Camera.main.depthTextureMode = DepthTextureMode.Depth;

        // (optional) If you want to visualize the result on a material
        if (replacementShader != null)
        {
            material = new Material(replacementShader);
           ming.GetComponent<Renderer>().material = material;
        }
        RenderPipelineManager.endContextRendering += sex;

        activeRT = RenderTexture.active;

    }

    void OnDestroy()
    {
        RenderPipelineManager.endContextRendering -= sex;
    }

    void sex(ScriptableRenderContext context, List<Camera> cameras)
    {
        activeRT = RenderTexture.active;

        // Create a temporary RenderTexture
        tempRT = RenderTexture.GetTemporary(activeRT.width, activeRT.height,0,RenderTextureFormat.Default,RenderTextureReadWrite.Default, 1,RenderTextureMemoryless.None,VRTextureUsage.None,false);
        RenderTexture.active = tempRT;

        // Read the depth information into the temporary RenderTexture
        Graphics.Blit(suck, tempRT, material, -1);

        // Read the RenderTexture into a Texture2D
        Texture2D texture = new Texture2D(activeRT.width, activeRT.height);
        texture.ReadPixels(new Rect(0, 0, activeRT.width, activeRT.height), 0, 0);
        texture.Apply();

        // Now you have the depth information in the 'texture' variable
        // You can manipulate the data as needed

        // Clean up
        imim.texture = tempRT;
        RenderTexture.active = activeRT;
        RenderTexture.ReleaseTemporary(tempRT);
  
    }
    private void Update()
    {
       
    }
}
