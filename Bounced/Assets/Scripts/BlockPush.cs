using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BlockPush : MonoBehaviour
{
    #region Variables

    [SerializeField]
    GameObject block;
    private Rigidbody2D rb2d;
    [SerializeField]
    private float blockSpeedY;
   
    private float posY;
    [SerializeField]
    private Transform origin;
    #endregion
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        block = GameObject.FindGameObjectWithTag("DynoBlock");
    }

    // Start is called before the first frame update
    void Start()
    {
        origin.position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        TouchSetup();
    }

    void TouchSetup()
    {
        Debug.Log(origin.position);

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
                    //begin moving block down
                    rb2d.velocity = Vector2.down;
                    break;


                case TouchPhase.Ended:
                    rb2d.velocity = Vector2.up * blockSpeedY;
                    break;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            Destroy(gameObject);
        }
    }
}
