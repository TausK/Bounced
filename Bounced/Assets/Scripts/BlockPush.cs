﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class BlockPush : MonoBehaviour
{
    #region Variables

    [SerializeField]
    GameObject block;
    private Rigidbody2D rb2d;
    [SerializeField]
    private float blockSpeedY;
    
    public float blockTime = 0.0f;
    [SerializeField]
    private float maxTime = 3.0f;

    public Text timeText;
    [SerializeField]
    private bool screenTouched;
    [SerializeField]
    private bool touchedBall;

    private Vector2 origin;
    #endregion
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        block = GameObject.FindGameObjectWithTag("DynoBlock");
    }

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        blockTime = 0;
        timeText.text = blockTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        TouchSetup();
        timeText.text = blockTime.ToString("0.0");
        
        if (screenTouched == true)
        {
            blockTime += Time.deltaTime;

        }

        if (touchedBall == true)
        {
            rb2d.velocity = Vector2.up * blockSpeedY;
            
        }
    }

    void TouchSetup()
    {


        //if screen touch is more than no touch then...
        if (Input.touchCount > 0)
        {
            //Retun touch count only as 1 touch
            Touch touch = Input.GetTouch(0);
            //set touch dependant on worldspace
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);


            //set switch statement
            //Set touch phase. What will happen upon touch?
            switch (touch.phase)
            {
                //first case/ First touch occurence
                case TouchPhase.Began:
                    screenTouched = true;
                    break;

                case TouchPhase.Ended:
                    touchedBall = true;
                    screenTouched = false;
                    break;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            // Destroy(gameObject);
            touchedBall = false;
            transform.position = origin;
            rb2d.velocity = Vector2.zero;
           
            //blockTime = 0;
        }
    }
}
