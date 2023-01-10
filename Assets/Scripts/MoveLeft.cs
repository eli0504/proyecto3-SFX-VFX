using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30; //VARIABLE VELOCIDAD
    private PlayerController playerControllerScript;

    public float leftBound;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();

    }
    private void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        
       if (playerControllerScript.gameOver)
        {
           CancelInvoke("SpawnObstacle");
        }

       if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}
