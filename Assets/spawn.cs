using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public Transform player;
    public float cur = 0f;
    public float lit = 10f;
    public float spawnMap = 25f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.Spawn();
        this.GetDis();
    }
    public void Spawn()
    {
        if (this.cur < this.lit) return;
        Vector3 pos = transform.position;
        pos.x += this.spawnMap;
        transform.position = pos;
    }
    public void GetDis()
    {
        this.cur = this.player.position.x - transform.position.x;
    }
}
