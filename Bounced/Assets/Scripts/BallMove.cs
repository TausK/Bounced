using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            Debug.Log("Screen Touched");
            
        }
    }
}
