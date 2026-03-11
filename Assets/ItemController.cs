using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public bool isHeld;
    public Transform holderPosition;
    public GMScript gm;
    public float hiddenTimer;


    // Start is called before the first frame update
    void Start()
    {


        holderPosition = GameObject.Find("PickUpHolder").transform;
        gm = GameObject.Find("GameManager").GetComponent<GMScript>();

    }



    // Update is called once per frame
    void Update()
    {
        hiddenTimer += Time.deltaTime;

        if (isHeld)
        {
            transform.position = holderPosition.position;
        }

    }

}
   