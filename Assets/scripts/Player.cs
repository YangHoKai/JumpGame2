using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig2D;
    float jumpForce=680.0f;
    float walkForce=30.0f;
    float Maxswalkpeed=2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rig2D.AddForce(transform.up * jumpForce);
        }
        int key = 0;
        if (Input.GetKey(KeyCode.D)) key = 1;
        if (Input.GetKey(KeyCode.A)) key = -1;

        float speedx = Mathf.Abs(this.rig2D.velocity.x);
        if(speedx < this.Maxswalkpeed)
        {
            rig2D.AddForce(transform.right * key * walkForce);
        }



    }
}
