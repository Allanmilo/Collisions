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

  if(!_control_Script.onOff && collision.gameObject.tag == "Ball")
  {
            
    _control_Script.paddle.Add(pad_Num);
    _control_Script.Invoke("pickPaddle", .01f); // Assigns paddle number.
    Invoke("Pick_Paddle", .02f);
  }
}
   
    void Pick_Paddle()
    {  
       // yield return new WaitForSeconds(.02f);
        if (_control_Script.paddle_Num == pad_Num)
        {
            _control_Script.onOff = true;
            Debug.Log("4 random is " + _control_Script.randomNum);
            Debug.Log("5 This paddle is " + pad_Num);
           _control_Script.paddle.RemoveAll(item => item >= 0);

            Say_Lite();
        }
    }
        public async void Say_Lite()
        {
            int x = Random.Range(0, 2);

            audio_Source.clip = audioClips[x];
            audio_Source.Play();

            for (int y = 0; y < word_Arrays[x].Length; y++)
            {
                float flash = word_Arrays[x][y];

                while (sine_Bool)
                {
                    await Task.Yield();
                }

                if (!sine_Bool)
                {
                    StartCoroutine(Blink_Twice(flash, 1));
                }

                await Task.Yield();
            }

            await Task.Delay(500);
            skip_Collision = false;
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
                Debug.Log("light is " + myLight.intensity);
            time += 1f;

            yield return null;
        }

        sine_Bool = false;
        _control_Script.onOff = false;
        yield break;
    }
        // Collider2D myCollider = collision.GetContact(0).otherCollider;
        // Debug.Log("this col is " + myCollider);
        // Now do whatever you need with myCollider.
        // (If multiple colliders were involved in the collision, 
        // you can find them all by iterating through the contacts)

    }



