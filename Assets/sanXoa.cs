using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sanXoa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "thienThach")
        {
            Destroy(collision.gameObject);
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
