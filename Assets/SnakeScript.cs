using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 moveDirection; 
    public LogicManagerScript logic;


    void Start()
    {
        // Start moving in the upward direction
        moveDirection = Vector3.forward; 
        transform.rotation = Quaternion.Euler(0, 0, 0);
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    void Update()
    {
        if (!logic.endGame)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && moveDirection != Vector3.back)
            {
                moveDirection = Vector3.forward; // Upward direction
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && moveDirection != Vector3.forward)
            {
                moveDirection = Vector3.back; // Downward direction
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && moveDirection != Vector3.right)
            {
                moveDirection = Vector3.left; // Left direction
                transform.rotation = Quaternion.Euler(0, 270, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && moveDirection != Vector3.left)
            {
                moveDirection = Vector3.right; // Right direction
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }

            // set the position
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        
    }
}