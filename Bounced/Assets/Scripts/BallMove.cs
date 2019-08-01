using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMove : MonoBehaviour
{
    [SerializeField]
    GameObject block;
    private Rigidbody2D rb2d;
    [SerializeField]
    private float deltaX, deltaY;
    [SerializeField]
    private Transform origin;

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
                    //Set touch position to the position of the block. 
                    deltaY = touchPos.y - transform.position.y;
                    break;

                case TouchPhase.Moved:
                    rb2d.MovePosition(new Vector2(0, touchPos.y - deltaY));
                    break;

                case TouchPhase.Ended:
                    block.transform.position = origin.position;
                    rb2d.velocity = Vector2.zero;

                    break;
            }

        }
    }
}
