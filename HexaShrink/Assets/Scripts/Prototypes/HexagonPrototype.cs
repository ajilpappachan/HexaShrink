using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonPrototype : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    float shrinkSpeed = 3.0f;

    GameControllerPrototype gamecontroller;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody.rotation = Random.Range(0.0f, 360.0f);
        transform.localScale = Vector3.one * 10.0f;
        gamecontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerPrototype>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        if (transform.localScale.x <= 0.05f)
        {
            Destroy(gameObject);
            gamecontroller.updateScore();
        }

        if (!gamecontroller.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
