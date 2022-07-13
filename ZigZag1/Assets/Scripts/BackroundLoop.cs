using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BackroundLoop : MonoBehaviour
{
    public static BackroundLoop instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
