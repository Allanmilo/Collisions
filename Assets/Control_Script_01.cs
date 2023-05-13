using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Control_Script_01 : MonoBehaviour
{
	
    public List<GameObject> paddle =  new List<GameObject>();

    public int randomNum;

    public int listPick;

    public int paddle_Num;

    public bool onOff;

    public bool stop_Col;

	public GameObject ball_Ran;
    GameObject next_Ball;

    int lastNumber;

    int maxAttempts;

    void Start()
    {
        onOff = false;
        stop_Col = false;
        maxAttempts = 50;
        
    }

    
	
    void Update()
    {
        
      if(paddle.Count >= 2 && onOff == true)
       { 
             stop_Col = true;
            onOff = false;

            
            listPick = Random.Range(0, paddle.Count);
	
                for(int i=0; listPick == lastNumber && i < maxAttempts; i++)
                {
                listPick = Random.Range(0, paddle.Count);
                }

            lastNumber = listPick;
                
            next_Ball = paddle[listPick];

                if(next_Ball != ball_Ran)
                {
                    ball_Ran = paddle[listPick];
                    next_Ball = ball_Ran;
                }
        }
            paddle.Clear();
    }

    

}
