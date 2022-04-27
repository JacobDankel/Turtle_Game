using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    //public GameObject UIObject; // text 
    //public GameObject Door; // Door

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Door")) 
        {
            Debug.Log("HI");
            //UIObject.SetActive(true);
        }
    }
    // Start is called before the first frame update
    /*void Start()
    {
        UIObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            UIObject.SetActive(true);
        }    
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        UIObject.SetActive(false);
    }*/
}
