using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float lerpSpeed;

    Vector3 tempPosition;
    [SerializeField]
    float minX, minY, maxX, maxY;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }
        tempPosition = player.position;
        tempPosition.z = -10;

        if (player.position.x < minX)
        {
            tempPosition.x = minX;
        }
        if (player.position.y < minY)
        {
            tempPosition.y = minY;
        }
        if (player.position.x > maxX)
        {
            tempPosition.x = maxX;
        }
        if (player.position.y > maxY)
        {
            tempPosition.y = maxY;
        }
        transform.position = Vector3.Lerp(transform.position, tempPosition, lerpSpeed * Time.deltaTime);
    }

    //***********************************  Old camera Script ************************************************//
    /*
    private Transform player;

    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // LateUpdate is called every time the calculation on update is finished
    void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y;

        if(tempPos.x < minX)
        {
            tempPos.x = minX;
        }
        if(tempPos.y > maxX)
        {
            tempPos.y = maxX;
        }



        transform.position = tempPos;



    }
    */




}// class
