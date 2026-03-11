using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumberSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PickRandomNumber());
    }

    private System.Collections.IEnumerator PickRandomNumber()
    {
        while (true)
        {
            int number = Random.Range(1, 11); 
            Debug.Log("Picked: " + number);

            if (number == 2)
            {
                audioSource.Play();
            }

            yield return new WaitForSeconds(2f); 
        }
    }
}

