using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fruit : MonoBehaviour
{
    private Collider2D coll;
    void Start()
    {
        coll= GetComponent<Collider2D>();
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("screenBounds"))
        {
            Destroy(transform.gameObject);
        }
        if (collision.gameObject.CompareTag("basket"))
        {
            if (gameObject.CompareTag("coin"))
            {
                GameManager.instance.addCollectedCoin();
            }
            else if (gameObject.CompareTag("timer_upgrade"))
            {
                GameManager.instance.IncereaseTime();
            }
            else
            {
                GameManager.instance.addCollectedFruit(1);
            }
           
            Destroy(transform.gameObject);
        }
    }

}
