using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float moveX, moveY;
    [SerializeField][Range(0f, 30f)] float moveSpeed = 20f;
    [SerializeField] float Yval;
    [SerializeField] float Xval;

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        if(transform.position.x > Xval)
        {
            if(moveX < 0)
                transform.position = new Vector3(transform.position.x + moveX, transform.position.y);
        }
        if(transform.position.x < -Xval)
        {
            if (moveX > 0)
                transform.position = new Vector3(transform.position.x + moveX, transform.position.y);
        }
        if (transform.position.y > Yval)
        {
            if (moveY < 0)
                transform.position = new Vector3(transform.position.x, transform.position.y + moveY);
        }
        if (transform.position.y < -Yval)
        {
            if (moveY > 0)
                transform.position = new Vector3(transform.position.x, transform.position.y + moveY);
        }
    }
}
