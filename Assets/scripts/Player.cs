using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rig2D;
    Animator an;
    GameObject GameManager;
    public float jumpForce=680.0f;
    public float walkForce =30.0f;
    public float Maxswalkpeed =2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            an.SetTrigger("jump");
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
        if(key!=0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        if(rig2D.velocity.y==0)
        {
            an.speed = speedx / 2f;
        }
        else 
        {
            an.speed = 1.0f;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="flag")
        {
            SceneManager.LoadScene("GameClear");
        }
        if (collision.tag == "arrow")
        {
            GameManager.GetComponent<GameManager>().DecreaseHp();
        }
        if (collision.name == "GameOver")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
