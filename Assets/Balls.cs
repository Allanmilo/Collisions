using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Balls : MonoBehaviour
{
  GameObject theBalls;

  Control_Script _control_Script;

  [SerializeField] int pad_Num;

    // Start is called before the first frame update
    void Start()
    {
        theBalls = GameObject.FindGameObjectWithTag("TheBalls");
        _control_Script = theBalls.GetComponent<Control_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  //  If you need to find out which of your child colliders was involved in the collision, you can do it like so:
 
void OnCollisionEnter2D(Collision2D collision)
{
  if(collision.gameObject.tag == "Ball")
  {

    _control_Script.paddle.Add(pad_Num);

    // Collider2D myCollider = collision.GetContact(0).otherCollider;
    // Debug.Log("this col is " + myCollider);
    // Now do whatever you need with myCollider.
    // (If multiple colliders were involved in the collision, 
    // you can find them all by iterating through the contacts)
  }
}

}
