using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
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





}// class
