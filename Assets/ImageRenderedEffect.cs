using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ImageRenderedEffect : MonoBehaviour
{
    public Material processingImageMaterial;

    void OnRenderImage(RenderTexture imageFromRenderedImage, RenderTexture imageDisplayedOnScreen)
    {
        if (processingImageMaterial != null)
            Graphics.Blit(imageFromRenderedImage, imageDisplayedOnScreen, processingImageMaterial);
    }
}
