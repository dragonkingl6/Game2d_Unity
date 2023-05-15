using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class world : MonoBehaviour
{
    public float CloseDistanceFromPlayer;
    public GameObject[] GroundTile;//chua cac dia hinh
    public Transform Player;//nhan vat
    public float TileWidth;//do dai cua dia hinh
    public int n;//so luong dia hinh
    void Start()
    {
        SpawnTile(2);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnTile(int n)//hoan doi dia hinh
    {
        int i = 0;
        while (i < n)
        {
            int ran = Random.Range(0, n);//lay ngau nhien 1 chi so dia hinh
            Instantiate(GroundTile[ran], transform.position, Quaternion.identity);//tao dia hinh
            i++;
            transform.position += TileWidth * Vector3.right;//cap nhat vi tri moi
        }
    }
    private void FixedUpdate()
    {
        if (Vector3.Distance(Player.position, transform.position) <=
            CloseDistanceFromPlayer)
        {
            SpawnTile(2);
        }
    }
}