using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    float moveX, moveY;
    public float moveSpeed;
    [SerializeField] float Yval;
    [SerializeField] float Xval;

    private void Update()
    {
        if(!gameObject.GetComponent<GameSetting>().die)
        {
            if (Input.GetKey(KeyCode.W))
                transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
            if (Input.GetKey(KeyCode.S))
                transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
        else
        {
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
            Yval = 100;
            if (transform.position.y < -12)
            {
                //SceneManager.LoadScene();
            }
        }
        transform.position = new Vector3(transform.position.x + moveX, transform.position.y + moveY);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-Xval,Xval),Mathf.Clamp(transform.position.y,-Yval,Yval));
    }
}
