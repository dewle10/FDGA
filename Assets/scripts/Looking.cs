using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : MonoBehaviour
{
    public Transform player;
    private float holdingCounter;
    [SerializeField] private float holdingTime;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float downDistance = 10f;
    [SerializeField] private float upDistance = 10f;
    private bool moved;
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            holdingCounter += Time.deltaTime;
            if(holdingCounter >= holdingTime)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y - downDistance, -10), moveSpeed * Time.deltaTime);
                moved = true;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            holdingCounter += Time.deltaTime;
            if (holdingCounter >= holdingTime)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y + upDistance, -10), moveSpeed * Time.deltaTime);
                moved = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            holdingCounter = 0;
            moved = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            holdingCounter = 0;
            moved = false;
        }

        if (!moved)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x , player.position.y, -10), moveSpeed * Time.deltaTime);
        }
    }
}
