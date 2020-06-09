using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPrototype : MonoBehaviour
{
    public float cameraSpeed = 30.0f;
    GameControllerPrototype gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerPrototype>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.isPlaying)
        {
            transform.Rotate(Vector3.forward, cameraSpeed * Time.deltaTime);
        }
    }
}
