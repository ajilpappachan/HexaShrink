using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerScript : MonoBehaviour
{
    public float cameraSpeed = 30.0f;
    GameControlerScript gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControlerScript>();
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
