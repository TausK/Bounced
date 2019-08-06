using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class BallMove : MonoBehaviour
{
    #region

    public float forceX;
    public float forceY;

    Rigidbody2D rb2d;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //reference rigidbody component
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            rb2d.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        }
    }
}
