using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrototype : MonoBehaviour
{
    public float moveSpeed = 600.0f;

    float movement = 0;

    GameControllerPrototype gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerPrototype>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0)
            {
                movement = -1.0f;
            }

            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0)
            {
                movement = 1.0f;
            }
        }
        else
        {
            movement = 0.0f;
        }

        if (!gameController.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, -movement * Time.fixedDeltaTime * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.gameOver();
    }
}
