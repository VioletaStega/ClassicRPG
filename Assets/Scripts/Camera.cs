using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Transform playerPosition;

    public Vector2 limitSup,
                   limitInf;

    Vector2 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CameraLimit();
    }

    private void CameraLimit()
    {
        if (playerPosition.position.x < limitSup.x && playerPosition.position.x > limitInf.x)
        {
            cameraPosition.x = playerPosition.position.x;
        }

        if (playerPosition.position.y < limitSup.y && playerPosition.position.y > limitInf.y)
        {
            cameraPosition.y = playerPosition.position.y;
        }

        //Recolocar la cámara un por diez por detrás del player
        transform.position = (Vector3)cameraPosition + Vector3.back * 10;
    }
}
