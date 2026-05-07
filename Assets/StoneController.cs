using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{
    public bool isHeld;
    public Transform holderPosition;
    public GMScript gm;
    


    // Start is called before the first frame update
    void Start()
    {


        holderPosition = GameObject.Find("PickUpHolder").transform;
        gm = GameObject.Find("GameManager").GetComponent<GMScript>();

    }



    // Update is called once per frame
    void Update()
    {
       

        if (isHeld)
        {
            transform.position = holderPosition.position;
        }

    }


    private void OnCollisionEnter(Collision collision)
    {



       

    }



}