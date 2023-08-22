using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager s_instance;
    static GameManager Instance { get { Init(); return s_instance; } }

    private void Awake()
    {
        Init();
    }

    private static void Init()
    {
        if (s_instance == null)
        {
            GameObject obj = GameObject.Find("@GameManagr");
            if (obj == null)
            {
                obj = new GameObject { name = "GameManagr" };
                obj.AddComponent<GameManager>();
            }
        }
    }
}
