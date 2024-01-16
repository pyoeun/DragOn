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
        transform.position = new Vector3(transform.position.x + moveX, transform.position.y + moveY);
    }
}
