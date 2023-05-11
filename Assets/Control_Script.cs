using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Control_Script : MonoBehaviour
{
    public List<GameObject> paddle =  new List<GameObject>();

public GameObject ball_One;
public GameObject ball_Two;
public GameObject ball_Ran;


   public int randomNum;

   public int listPick;

    public int paddle_Num;

    public bool onOff;

    public bool stop_Col;


    // Start is called before the first frame update
    void Start()
    {
        onOff = false;
        stop_Col = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
            {
               // foreach (var card in paddle)
            }
       // Debug.Log(card);   

      // if(paddle.Count >= 2)
       //{
      //  onOff = true;
      //  Debug.Log("onOff three is  " + onOff);
      // }  

        if(onOff)
        {
          //  paddle.Add(ball_One);
          //  paddle.Add(ball_Two);
            stop_Col = true;
            onOff = false;
            listPick = Random.Range(0, paddle.Count);
            ball_Ran = paddle[listPick];

            Debug.Log("listPick is " + listPick);
            Debug.Log("ball_Ran is " + ball_Ran);

            paddle.Clear();
            Debug.Log("onOff one is  " + onOff);

        }



    }

/*
    public void pickPaddle()
    {
        
        listPick = paddle.Count;
                                                 Debug.Log("1 listPick is " + listPick);
        randomNum = Random.Range(0, listPick);
                                                    Debug.Log("2 First random is " + randomNum);
        paddle_Num = paddle[randomNum];
                                                         Debug.Log("3 paddle num is " + paddle_Num);

        // onOff = true;
        paddle.Clear();
        // paddle.RemoveAll(item => item >= 0);
        // paddle.RemoveRange ( 0 , paddle.Count() 
       
    }
    */
}
