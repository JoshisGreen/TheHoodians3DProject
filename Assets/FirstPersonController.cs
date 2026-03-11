using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{
    public Vector3 moveDirection;
    public float speed;

    public LayerMask groundMask;

    public float jumpForce;
    public Rigidbody rb;
    public bool itemHeld;
    public GameObject currentItem;
    public Transform cameraPosition;
    public LayerMask interactMask;

    public float throwPower;
    public float throwMuiltiplier;
    public Slider powerMeter;

    public bool isGameOver;
    public Transform respawnPoint;
    public bool canWalk;
    public float deathTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //powerMeter.gameObject.SetActive(false);
        canWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");



        moveDirection = new Vector3(x, 0, z);
        transform.Translate(speed * Time.deltaTime * moveDirection);




        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//add an upward, instant force to the player , multiplied by the value of jumpforce
        }


        //if (Input.GetKeyDown(KeyCode.Q))
        //{
           // if (!itemHeld)
           // {

              //  if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out RaycastHit reach, 1.5f, interactMask))
               // {
                //    itemHeld = true;
                 //   currentItem = reach.collider.gameObject;
                  //  currentItem.GetComponent<ItemController>().isHeld = true;
                   // currentItem.GetComponent<Rigidbody>().useGravity = false;


              //  }
          //  }
           // else
          //  {
              //  itemHeld = false;
             //   currentItem.GetComponent<ItemController>().isHeld = false;
             //   currentItem.GetComponent<Rigidbody>().useGravity = true;
            //    currentItem = null;

           // }



            


          //  powerMeter.value = throwPower;
          //  if (Input.GetKeyDown(KeyCode.E) && itemHeld)
           // {
           //    throwPower = 0;
           //   powerMeter.gameObject.SetActive(true);
           //  }
          //  if (Input.GetKey(KeyCode.E) && itemHeld)
         //   {

         //   throwPower = Mathf.PingPong(Time.time, 1);
          //  }
           // if (Input.GetKeyUp(KeyCode.E) && itemHeld)
          //  {
          //   itemHeld = false;
          //   currentItem.GetComponent<ItemController>().isHeld = false;
          //  currentItem.GetComponent<Rigidbody>().AddForce(cameraPosition.forward * throwPower * throwMuiltiplier, ForceMode.Impulse);// adds insatnt force in direction cam is facing * by the values of throwmulti and throw power.
         //   currentItem = null;
         //    powerMeter.gameObject.SetActive(false);
         //   throwPower = 0;
          //  }



        //}

        bool IsGrounded()
        {
            if (Physics.Raycast(transform.position - new Vector3(0, .9f, 0), Vector3.down, out RaycastHit hit, .2f, groundMask))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water")
        {



            GetComponent<AudioSource>().Play();
            transform.position = respawnPoint.position;



        }

        if (collision.gameObject.tag == "Part")
        {




            ScoreManager.instance.AddPart();
            Destroy(collision.gameObject);



        }
    }

}
