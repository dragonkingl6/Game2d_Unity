using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vahcmaQuaiVat : MonoBehaviour
{
    private Rigidbody2D em;
    public bool checkDay;
    // Start is called before the first frame update
    void Start()
    {
        em = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveY = 0f;
        if (checkDay)
        {
            moveY = -1.5f;
        }
        else
        {
            moveY = 1.5f;
        }
        em.velocity = new Vector2(x:0, transform.localScale.y)*moveY;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "co")
        {
            checkDay = false;
        }
        if (collision.gameObject.tag == "tran")
        {
            checkDay = true;
        }
    }
}
