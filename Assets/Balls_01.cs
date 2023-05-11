using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Audio;
//using UnityEngine.UI;
//using UnityEngine.Events;

public class Balls_01 : MonoBehaviour
{
  GameObject theBalls;

    GameObject thisBall;

  Control_Script_01 _control_Script;

  [SerializeField] int pad_Num;

    //bool onOff = false;

// light variables.
    Light myLight;

    AudioSource audio_Source;
	
	public AudioClip[] audioClips;

    bool sine_Bool;
    bool skip_Collision;

    int x;

    [System.Serializable] // Needed to see in Inspector.
    public class Row
        {   
            public float[] rowdata; // Array(s) containing flash timings.
        }

    public Row[] speech_Times; // Array containing rowdata arrays.
     
    //  To get a value from arrays:
    //  speech_Times[x].rowdata[y] 
    // Were x is an array 
    // y is the value in the array.
   



    void Start()
    {
        theBalls = GameObject.FindGameObjectWithTag("TheBalls");
        _control_Script = theBalls.GetComponent<Control_Script_01>();

        thisBall = this.gameObject;

        // light settings.
        myLight = GetComponent<Light>();

        audio_Source = GetComponent<AudioSource>();
        sine_Bool = false;
        skip_Collision = false;
		
		x = 0;
    }


 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(_control_Script.stop_Col == false && collision.gameObject.tag == "Ball")
        {
            _control_Script.onOff = true;
            // _control_Script.stop_Col = true;
                                            
                _control_Script.paddle.Add(thisBall);

                StartCoroutine(Start_Talk());                  
        }
    }



IEnumerator Start_Talk()
{
    yield return new WaitForSeconds(.01f);

    if(_control_Script.ball_Ran == thisBall)
            {
               // _control_Script.ball_Ran = null;
                StartCoroutine(Say_Lite());
				// _control_Script.ball_Ran = null;
            }
}





        IEnumerator Say_Lite()
        {
            if(!skip_Collision)
            {
                    skip_Collision = true;
                   
                    audio_Source.clip = audioClips[x];
					x++;
					if(x >= audioClips.Length)
					{ 
						x = 0;
					}
                    audio_Source.Play();


				for (int y = 0; y < speech_Times[x].rowdata.Length; y++)
				{
					float flash = speech_Times[x].rowdata[y];  
			
                        while (sine_Bool)
                        {
                            yield return null;
                        }

                        if (!sine_Bool)
                        {
                            StartCoroutine(Blink_Twice(flash, 1));
							sine_Bool = true;
                        }

                        yield return null;
						
						
                }

                 
			   if(audio_Source.isPlaying)
                 {
                    yield return null;
                 }

                yield return new WaitForSeconds(.3f);
              _control_Script.stop_Col = false;
			   skip_Collision = false;
				// _control_Script.onOff = false;
				//  skip_Collision = false;
			}
			
			
        }

    IEnumerator Blink_Twice(float Speed, float Amplitude)
    {
        

        float y = 0;
        float time = 0;

                while (y >= 0)
                {
                    float angle = time * Time.deltaTime * Mathf.PI / Speed;
                    y = Amplitude * (Mathf.Sin(angle));

                    myLight.intensity = y;
                    time += 1f;

                    yield return null;
                }

        
       // yield return new WaitForSeconds(1);
		sine_Bool = false;
        
    }

    }



