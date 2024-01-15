using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSingleton : MonoBehaviour
{
    public static int dragon;
    public static int skill;
    public static int bullet;
    private static MainSingleton instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static MainSingleton Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    private void Update()
    {
        Debug.Log($"{dragon}, {skill}, {bullet}");
    }
}
