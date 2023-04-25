using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Control_Script : MonoBehaviour
{
    public List<GameObject> paddle =  new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
            {
                foreach (var card in paddle)
{
        Debug.Log(card);
        
            }
        
}
    }
}
