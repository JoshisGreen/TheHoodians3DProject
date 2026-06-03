using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkerScript : MonoBehaviour
{
    public Transform player;          
    public float detectionRadius = 10f;
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f;

    public bool isStunned = false;
    private float stunTimer = 0f;

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

       
        if (distance <= detectionRadius)
        {
           
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

   
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Throwable"))
        {
            Stun(2f); 
        }
    }

    public void Stun(float duration)
    {
        isStunned = true;
        stunTimer = duration;
    }


}
