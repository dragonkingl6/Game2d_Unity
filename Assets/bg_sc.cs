using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_sc : MonoBehaviour
{
    // Start is called before the first frame update
    public float sped = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * sped, 0f);
    }
}
