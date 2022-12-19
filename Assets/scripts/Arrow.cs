using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name== "cat")
        {
            Destroy(gameObject);
        }
        if (collision.name == "addScore")
        {
            Destroy(gameObject);
            GameManager.GetComponent<GameManager>().addScore();
        }

    }
}
