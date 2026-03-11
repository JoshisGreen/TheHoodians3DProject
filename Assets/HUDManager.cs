using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

   // public Text healthText;
    public Text timerText;
   // int health = 0;
    int timer = 0;
    public Text partText;
    int part = 0;
    public Transform respawnPoint;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        timer = 300;

        timerText.text = "Timer: "   + timer.ToString();
        //healthText.text = "Health: "  + health.ToString();
        partText.text = "Parts out of 12: " + part.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(part == 12)
        {
            GetComponent<AudioSource>().Play();
            part = 0;
        }
          
       if(timer == 0)
        {
           
            transform.position = respawnPoint.position;
            timer = 200;
            part = 0;

        }
    
    }

    //public void AddPoint()
   // {
     //   health += -1;
      //  healthText.text = "Health: " + health.ToString();
   // }

    public void AddTime()
    {
        timer += -1;
        timerText.text = "Timer: " + timer.ToString();
    }

    public void AddPart()
    {
        part += 2;
        partText.text = "Parts out of 12: " + part.ToString();
    }
}