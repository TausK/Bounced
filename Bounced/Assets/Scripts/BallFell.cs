using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFell : MonoBehaviour
{
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.transform.position = collision.transform.GetComponent<BallMove>().ballOrigin;
        }
    }
}
