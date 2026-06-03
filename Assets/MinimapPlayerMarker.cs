using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPlayerMarker : MonoBehaviour
{
    public RectTransform minimap;      
    public RectTransform marker;        
    public Transform player;

    public Vector2 worldMin = new Vector2(-287, -218);
    public Vector2 worldMax = new Vector2(9, 208);

    void Update()
    {
       
        float normalizedX = Mathf.InverseLerp(worldMin.x, worldMax.x, player.position.x);
        float normalizedY = Mathf.InverseLerp(worldMin.y, worldMax.y, player.position.z);

        float mapX = Mathf.Lerp(0, minimap.rect.width, normalizedX);
        float mapY = Mathf.Lerp(0, minimap.rect.height, normalizedY);

        marker.anchoredPosition = new Vector2(mapX, mapY);
    }
}

