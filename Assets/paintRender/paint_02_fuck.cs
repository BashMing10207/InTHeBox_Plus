using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class paint_02_fuck : MonoBehaviour
{
    public Camera cam;
    public DepthTextureMode aa;
    public RenderTexture renderTexture;
    Texture2D tex;
    // Start is called before the first frame update
    void Start()
    {
        //cam.depthTextureMode = aa;
        tex = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    Color GetPixelColor(RenderTexture renderTexture, int x, int y)
    {

        
        RenderTexture.active = renderTexture;
        tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        tex.Apply();

        // �о�� Texture2D���� �ش� �ȼ��� ������ ������
        Color pixelColor = tex.GetPixel(x, y);
        
        return pixelColor;
    }
}

