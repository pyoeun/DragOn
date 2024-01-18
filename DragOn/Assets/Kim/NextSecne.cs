using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSecne : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void menututo()
    {
        SceneManager.LoadScene(5);
    }
    public void gametuto()
    {
        SceneManager.LoadScene(6);
    }
    public void gamestart()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
