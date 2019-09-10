using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFell : MonoBehaviour
{
 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
           // col.transform.position = col.transform.GetComponent<BallMove>();
        }
    }
}
