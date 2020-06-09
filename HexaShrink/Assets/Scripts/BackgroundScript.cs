using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    GameControlerScript gameController;
    float backgroundSpeed = 30.0f;
    float backgroundScrollSpeed = 0.2f;

    bool movingLeft;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControlerScript>();
        movingLeft = randomBool();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.isPlaying)
        {
            transform.Rotate(Vector3.forward, -backgroundSpeed * Time.deltaTime);
        }
        else
        {
            if (transform.position.x <= -2.0f)
            {
                movingLeft = false;
            }
            else if (transform.position.x >= 2.0f)
            {
                movingLeft = true;
            }

            if (movingLeft)
            {
                transform.Translate(-backgroundScrollSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
            else
            {
                transform.Translate(backgroundScrollSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
    }

    bool randomBool()
    {
        if (Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }
}
