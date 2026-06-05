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

    public GameObject pickUpSound;

    public float sprintMultiplier = 1.8f;
    public float maxSprintTime = 1f;
    public float sprintCooldown = 5f;

    private float sprintTimer = 0f;
    private float cooldownTimer = 0f;
    private bool isSprinting = false;
    private bool isOnCooldown = false;

    public bool allCollected = false;

    public GameObject gameWinScreen;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        powerMeter.gameObject.SetActive(false);
        canWalk = true;

        allCollected = false;

        gameWinScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        float currentSpeed = speed;

      
        if (isOnCooldown)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= sprintCooldown)
            {
                isOnCooldown = false;
                cooldownTimer = 0f;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift) && !isOnCooldown && sprintTimer < maxSprintTime)
        {
            isSprinting = true;
            sprintTimer += Time.deltaTime;
            currentSpeed *= sprintMultiplier;
        }
        else
        {
            isSprinting = false;
        }

       
        if (sprintTimer >= maxSprintTime)
        {
            isOnCooldown = true;
        }

        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprintTimer = 0f;
        }

        moveDirection = new Vector3(x, 0, z).normalized;
        transform.Translate(currentSpeed * Time.deltaTime * moveDirection);

        
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

      
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!itemHeld)
            {
                if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out RaycastHit reach, 1.5f, interactMask))
                {
                    itemHeld = true;
                    currentItem = reach.collider.gameObject;
                    currentItem.GetComponent<StoneController>().isHeld = true;
                    currentItem.GetComponent<Rigidbody>().useGravity = false;
                }
            }
            else
            {
                itemHeld = false;
                currentItem.GetComponent<StoneController>().isHeld = false;
                currentItem.GetComponent<Rigidbody>().useGravity = true;
                currentItem = null;
            }
        }

        powerMeter.value = throwPower;

        if (Input.GetKeyDown(KeyCode.E) && itemHeld)
        {
            throwPower = 0;
            powerMeter.gameObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.E) && itemHeld)
        {
            throwPower = Mathf.PingPong(Time.time, 1);
        }

        if (Input.GetKeyUp(KeyCode.E) && itemHeld)
        {
            itemHeld = false;
            currentItem.GetComponent<StoneController>().isHeld = false;
            currentItem.GetComponent<Rigidbody>().useGravity = true;
            currentItem.GetComponent<Rigidbody>().AddForce(cameraPosition.forward * throwPower * throwMuiltiplier, ForceMode.Impulse);

            currentItem = null;
            powerMeter.gameObject.SetActive(false);
            throwPower = 0;
        }

        
        bool IsGrounded()
        {
            return Physics.Raycast(transform.position - new Vector3(0, .9f, 0), Vector3.down, out RaycastHit hit, .2f, groundMask);
        }
   
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water")
        {



            GetComponent<AudioSource>().Play();
            transform.position = respawnPoint.position;



        }

        if (collision.gameObject.tag == "Real Water")
        {



            GetComponent<AudioSource>().Play();
            transform.position = respawnPoint.position;



        }

        if (collision.gameObject.tag == "Part")
        {




            ScoreManager.instance.AddPart();
            Destroy(collision.gameObject);
            GameObject.Find("PickUpAudio").GetComponent<AudioSource>().Play();




        }


       if(collision.gameObject.tag == "Final Touch")
        {
            if (allCollected == true)
            {
                gameWinScreen.SetActive(true);
                GameObject.Find("Canvas").GetComponent<AudioSource>().Play();
                allCollected = false;
            }
        }
       

    }

}
