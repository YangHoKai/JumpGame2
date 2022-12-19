using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject Hp;
    public int hp = 10;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ArrowShot", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ArrowShot()
    {
        Instantiate(Arrow, new Vector3(Random.Range(-3, 3), 10, 0), Quaternion.identity);
    }
    public void DecreaseHp()
    {
        Hp.GetComponent<Image>().fillAmount -= 0.1f;
        hp -= 1;
        if(hp<=0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    
}
