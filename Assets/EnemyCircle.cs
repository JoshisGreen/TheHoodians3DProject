using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircle : MonoBehaviour
{
    public Transform centerPoint;  
    public float radius = 3f;      
    public float speed = 50f;      
    public Vector3 axis = Vector3.up;

    private float angle = 0f;

    void Update()
    {
        if (centerPoint == null)
            return;

      
        angle += speed * Time.deltaTime;

       
        Quaternion rotation = Quaternion.AngleAxis(angle, axis.normalized);


        Vector3 offset = rotation * (Vector3.forward * radius);

        
        transform.position = centerPoint.position + offset;
    }
}
