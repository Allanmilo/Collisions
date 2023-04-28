using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Control_Script : MonoBehaviour
{
    public List<int> paddle =  new List<int>();

   public int randomNum;

    int listPick;

    public int paddle_Num;

    public bool onOff;


    // Start is called before the first frame update
    void Start()
    {
        onOff = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
            {
               // foreach (var card in paddle)
            }
       // Debug.Log(card);       
    }

    public void pickPaddle()
    {
        listPick = paddle.Count;
                Debug.Log("1 listPick is " + listPick);
        randomNum = Random.Range(0, listPick);
                Debug.Log("2 First random is " + randomNum);
        paddle_Num = paddle[randomNum];
                Debug.Log("3 paddle num is " + paddle_Num);
        // paddle.RemoveRange ( 0 , paddle.Count() 
       
    }
}
