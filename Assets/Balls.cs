using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Audio;
//using UnityEngine.UI;
//using UnityEngine.Events;

public class Balls : MonoBehaviour
{
  GameObject theBalls;

    GameObject thisBall;

  Control_Script _control_Script;

  [SerializeField] int pad_Num;

    //bool onOff = false;

// light variables.
    Light myLight;

    AudioSource audio_Source;

    bool sine_Bool;
    bool skip_Collision;

    


    float[][] word_Arrays =
        {
            new float[] { .33f, .41f, .63f },
            new float[] { .33f, .41f, .63f },
            new float[] { .33f, .41f, .63f },
        };
    public AudioClip[] audioClips;







    // Start is called before the first frame update
    void Start()
    {
        theBalls = GameObject.FindGameObjectWithTag("TheBalls");
        _control_Script = theBalls.GetComponent<Control_Script>();

        thisBall = this.gameObject;

        // light settings.
        myLight = GetComponent<Light>();

        audio_Source = GetComponent<AudioSource>();
        sine_Bool = false;
        skip_Collision = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  //  If you need to find out which of your child colliders was involved in the collision, you can do it like so:
 
    void OnCollisionEnter2D(Collision2D collision)
    {

        if(_control_Script.stop_Col == false && collision.gameObject.tag == "Ball")
        {
            _control_Script.onOff = true;
                
                                            
                _control_Script.paddle.Add(thisBall);

                StartCoroutine(Start_Talk());

                   
        }
    }



IEnumerator Start_Talk()
{
    
    yield return new WaitForSeconds(.01f);

Debug.Log("passed ball tag  " + thisBall);
Debug.Log("passed  ball_ran " + _control_Script.ball_Ran);

    if(_control_Script.ball_Ran == thisBall)
            {
                Debug.Log("before coroutine ");
                Debug.Log("onOff two is  " + _control_Script.onOff);
                StartCoroutine(Say_Lite());
            }


}











/*
  if(!skip_Collision && !_control_Script.onOff && collision.gameObject.tag == "Ball")
  {
        
    _control_Script.paddle.Add(pad_Num);
    _control_Script.Invoke("pickPaddle", .01f); // Assigns paddle number.
   
        if(_control_Script.listPick != 0)
        { 
            Debug.Log("first count is " + _control_Script.paddle.Count);
            
            Invoke("Pick_Paddle", .02f);  
        }
    }
    */
  
    void Pick_Paddle()
    {  
        
       // yield return new WaitForSeconds(.02f);
        if (_control_Script.paddle_Num == pad_Num)
        {
           
            Debug.Log("4 random is " + _control_Script.randomNum);
            Debug.Log("5 This paddle is " + pad_Num);
           // spaddle.RemoveAll(item => item >= 0);_control_Script.paddle.RemoveAll(item => item >= 0);

                if (_control_Script.onOff == false)
                    {
                    _control_Script.onOff = true;
                    }

     skip_Collision = true;
            StartCoroutine(Say_Lite());
        }
    }



        IEnumerator Say_Lite()
        {
             if(!skip_Collision)
               {
                    //skip_Collision = true;
                    int x = Random.Range(0, 2);

                    audio_Source.clip = audioClips[x];
                    audio_Source.Play();

                    for (int y = 0; y < word_Arrays[x].Length; y++)
                    {
                        float flash = word_Arrays[x][y];

                        while (sine_Bool)
                        {
                            yield return null;
                        }

                        if (!sine_Bool)
                        {
                            StartCoroutine(Blink_Twice(flash, 1));
                        }

                        yield return null;
                    }

                 if(audio_Source.isPlaying)
                 {
                    yield return null;
                 }

                 //   yield return new WaitForSeconds(audioClips[x].length);
                  
               //yield return new WaitForSeconds(1.3f);

                _control_Script.stop_Col = false;
            //await Task.Delay(2000);
               // }
        }
        }

    IEnumerator Blink_Twice(float Speed, float Amplitude)
    {
        sine_Bool = true;

        float y = 0;
        float time = 0;

                while (y >= 0)
                {
                    float angle = time * Time.deltaTime * Mathf.PI / Speed;
                    y = Amplitude * (Mathf.Sin(angle));

                    myLight.intensity = y;
                    // Debug.Log("light is " + myLight.intensity);
                    time += 1f;

                    yield return null;
                }

        sine_Bool = false;
        // _control_Script.onOff = false;
        // yield break;
        yield return new WaitForSeconds(1);
         _control_Script.onOff = false;
         skip_Collision = false;
    }
        // Collider2D myCollider = collision.GetContact(0).otherCollider;
        // Debug.Log("this col is " + myCollider);
        // Now do whatever you need with myCollider.
        // (If multiple colliders were involved in the collision, 
        // you can find them all by iterating through the contacts)

    }



