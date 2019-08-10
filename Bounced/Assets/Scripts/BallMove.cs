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

    public BlockPush block;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //reference rigidbody component
        rb2d = GetComponent<Rigidbody2D>();
        block = GameObject.FindGameObjectWithTag("Block").GetComponent<BlockPush>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            if(block.blockTime <= 1.0f)
            {
                Debug.Log("over 1f");
                rb2d.AddForce(new Vector2(forceX, forceY + 1), ForceMode2D.Impulse);
            }
            else if(block.blockTime <= 1.5f)
            {
                Debug.Log("over 1.5f");
                rb2d.AddForce(new Vector2(forceX, forceY + 2), ForceMode2D.Impulse);
            }
            //else
            //{
            //    Debug.Log("No condition");
            //    rb2d.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
            //}
            //rb2d.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        }
    }
}
