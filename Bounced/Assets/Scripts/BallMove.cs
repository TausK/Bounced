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

    public Vector2 ballOrigin;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //reference rigidbody component
        rb2d = GetComponent<Rigidbody2D>();
        block = GameObject.FindGameObjectWithTag("Block").GetComponent<BlockPush>();
        ballOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            #region Ball Force
            if (block.blockTime >= 1.0f &&  block.blockTime < 2.0f)
            {
                Debug.Log("Low Charge");
                rb2d.AddForce(new Vector2(forceX, forceY + 1.0f), ForceMode2D.Impulse);
            }
            else if (block.blockTime >= 2.0f && block.blockTime < 3.0f)
            {
                Debug.Log("Medium Charge");
                rb2d.AddForce(new Vector2(forceX + 1.0f, forceY + 1.5f), ForceMode2D.Impulse);
            }
            else if(block.blockTime >= 3.0f)
            {
                Debug.Log("Max Charge");
                rb2d.AddForce(new Vector2(forceX + 1.5f, forceY + 2.0f), ForceMode2D.Impulse);
            }
            else
            {
                Debug.Log("No Charge");
                rb2d.velocity = Vector2.zero;
            }
            #endregion
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            block.blockTime = 0;
        }
    }
}
