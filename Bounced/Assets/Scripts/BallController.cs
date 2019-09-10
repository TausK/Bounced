using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ball
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BallController : MonoBehaviour
    {
        #region Variables

        private Vector3 ballPos; //Ball Position
        private Vector2 ballForce;  //Amount of force or power on the ball 
        public float ballPowerX; //Power within X
        public float ballPowerY; //Power within Y
        private Rigidbody2D rb2d;

        private Vector3 touchPos;

        public Text timerTxt;
        private float timer = 0;
        private float initialPower;
        public bool timeStart;

        #endregion

        // Start is called before the first frame update
        void Start()
        {

            //reference rigidbody component
            rb2d = GetComponent<Rigidbody2D>();


            timerTxt.text = timer.ToString("0.0");
        }

        private void Update()
        {
            if (timeStart == true)
            {
                timerTxt.text = timer.ToString("0.0");
                timer += Time.deltaTime;
            }

            initialPower = timer;
            #region Ball Forces V1
            //if (bController.ballMove == true)
            //{
            //    if (bController.timer >= 1.0f && bController.timer < 1.5f)
            //    {
            //        Debug.Log("2nd Charge");
            //        rb2d.AddForce(new Vector2(ballForceX, ballForceY + 1.0f), ForceMode2D.Impulse);
            //        bController.ballMove = false;
            //    }

            //    else if (bController.timer >= 1.5f && bController.timer < 2.0f)
            //    {
            //        Debug.Log("3rd Charge");
            //        rb2d.AddForce(new Vector2(ballForceX + 1.0f, ballForceY + 1.5f), ForceMode2D.Impulse);
            //        bController.ballMove = false;
            //    }

            //    else if (bController.timer >= 2.0f && bController.timer < 2.5f)
            //    {
            //        Debug.Log("4th Charge");
            //        rb2d.AddForce(new Vector2(ballForceX + 1.5f, ballForceY + 2.0f), ForceMode2D.Impulse);
            //        bController.ballMove = false;
            //    }

            //    else if (bController.timer >= 2.5f)
            //    {
            //        Debug.Log("5th Charge");
            //        rb2d.AddForce(new Vector2(ballForceX + 2.0f, ballForceY + 2.5f), ForceMode2D.Impulse);
            //        bController.ballMove = false;
            //    }

            //    else
            //    {
            //        Debug.Log("1st Charge");
            //        rb2d.AddForce(new Vector2(ballForceX, ballForceY + 0.5f), ForceMode2D.Impulse);
            //        bController.ballMove = false;

            //    }


            //}

            #endregion

            #region Ball Forces V2
            BallControl();
            #endregion
        }

        void BallControl()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                touchPos = Camera.main.WorldToScreenPoint(touch.position);

                //if screen is pressed and ball velocity is 0 in both x and y
                if (touch.phase == TouchPhase.Began && (rb2d.velocity.x == 0 && rb2d.velocity.y == 0))
                {
                    //Velocity of ball is created
                    ballForce = new Vector2(initialPower * ballPowerX, initialPower * ballPowerY);
                    
                    timeStart = true;

                }

                if (touch.phase == TouchPhase.Ended && (rb2d.velocity.x == 0 && rb2d.velocity.y == 0))
                {

                    rb2d.AddForce(new Vector2(ballForce.x, ballForce.y), ForceMode2D.Impulse);
                    //Activate ball velocity
                   // rb2d.velocity = new Vector2(ballForce.x, ballForce.y);
                    Debug.Log(rb2d.velocity);
                    timeStart = false;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Platform"))
            {
                timer = 0;
            }
        }

    }


}


