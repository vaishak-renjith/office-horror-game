using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Stamp : MonoBehaviour
{
    public float moveSpeed;
    public float radius;
    private float angle;
    
    public GameObject stampMark;
    public GameObject paper;

    public Vector3 initPos;
    private Vector2 placedPos;
    public Transform correctPos;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float spriteHeight = spriteRenderer.bounds.size.y;
        transform.position = new Vector3(paper.transform.position.x, paper.transform.position.y + 2 * radius + spriteHeight/2, -1);
    }

    void Update()
    {
        angle += moveSpeed / (radius) * Time.deltaTime;
        transform.position = initPos + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), -1) * radius;
        if (Input.GetKeyDown(KeyCode.Space)) {
            placeMark();
        }
    }

    void placeMark()
    {
        //unparent mark
        stampMark.transform.parent = null;
        placedPos = stampMark.transform.position;
        grade();
    }

    void grade()
    {
        //(1 - player's distance / max distance allowed) * 100 = percent
        float maxDistanceAllowed = 2*radius;
        float playerDistance = Vector2.Distance(correctPos.position, placedPos);
        if (playerDistance >= maxDistanceAllowed) 
            Debug.Log("0");
        else
            Debug.Log(Mathf.Round((1-playerDistance/maxDistanceAllowed) * 100));
    }
}
