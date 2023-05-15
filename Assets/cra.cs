using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cra : MonoBehaviour
{
    
    private Transform player;

    private Camera mainCamera;
    private float screenHalfWidthInWorldUnits;

    public string targetTag;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("playerMain").transform;
        mainCamera = Camera.main;

        float screenHeightInWorldUnits = mainCamera.orthographicSize * 2;
        screenHalfWidthInWorldUnits = screenHeightInWorldUnits * mainCamera.aspect / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = player.transform.position.x;
        transform.position = pos;

        GameObject[] targets = GameObject.FindGameObjectsWithTag("tien");

        // Destroy targets that are outside of the camera's view
        foreach (GameObject target in targets)
        {
            float targetHalfWidth = target.transform.localScale.x / 2;
            float targetXPosition = target.transform.position.x;

            float leftEdgeOfTarget = targetXPosition - targetHalfWidth;
            float rightEdgeOfTarget = targetXPosition + targetHalfWidth;

            float leftEdgeOfScreen = mainCamera.transform.position.x - screenHalfWidthInWorldUnits;
            float rightEdgeOfScreen = mainCamera.transform.position.x + screenHalfWidthInWorldUnits;

            if (rightEdgeOfTarget < leftEdgeOfScreen || leftEdgeOfTarget > rightEdgeOfScreen)
            {
                Destroy(target);
            }
        }
    }
}

