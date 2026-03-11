using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GMScript : MonoBehaviour
{
   
    public float timers;

//public bool isGameRunning;
   // public bool raceEnded;
    //public GameObject player;
   // public GameObject opponent;
   // public GameObject gamePanel;
//public TextMeshProUGUI gameText;

   /// public float opponentSpeed;
   //public Rigidbody opponentRB;

   // public bool playerWon;

    // Start is called before the first frame update
    void Start()
    {

       // isGameRunning = false;
       // raceEnded = false;
        //player = GameObject.Find("Player");
       // player.GetComponent<FirstPersonController>().enabled = false;
      ////  gamePanel = GameObject.Find("GamePanel");
       // gameText = GameObject.Find("GameText").GetComponent<TextMeshProUGUI>();
       // gameText.text = "Press Space to Start";
    }

    // Update is called once per frame
    void Update()
    {
        //f (!isGameRunning && !raceEnded)
//{
//if (Input.GetKeyDown(KeyCode.Space))
       //     {
        //        StartCoroutine(StartGame(3));
         //   }
      //  }




        timers += Time.deltaTime;
       


       
            if (timers >= 1)
            {
                ScoreManager.instance.AddTime();
            timers = 0;
               

            }
        





    }

   // public IEnumerator StartGame(int countdown)
   // {
//for (int i = countdown; i > 0; i--)
      //  {
//gameText.text = "Game Starting in: \n" + i + " seconds!";
//yield return new WaitForSeconds(1f);
      //  }

       // gameText.text = "Start!";
       // isGameRunning = true;
       // player.GetComponent<FirstPersonController>().enabled = true;

       // yield return new WaitForSeconds(2f);

       // gameText.text = "";
       // gamePanel.SetActive(false);
   // }


  //  private void OnTriggerEnter(Collider other)
    //{
      //  if (!raceEnded)
       // {
         //   switch (other.tag)
          //  {
            //    case "Player":
                 //   playerWon = true;

                //    gameText.text = "You Win! \n Congratulations!";
                 //   break;

               // case "Opponent":
              //      playerWon = false;
                //    gameText.text = "You lose.. \n Better Luck Next Race!";
                 //   break;


           // }
            //raceEnded = true;
           // isGameRunning = false;
            //player.GetComponent<FirstPersonController>().enabled = false;
           // gamePanel.SetActive(true);

       // }
    //}
}

