using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager s_instance;
    public static GameManager Instance { get { Init(); return s_instance; } }

    //GunManager _gunData = new GunManager();
    //public static GunManager GunInstance { get { return Instance._gunData; } }

    GunSetting _gunSetting = new GunSetting();
    public static GunSetting GunSettingInstance { get { return Instance._gunSetting; } }

    CSVReader _CSVInstance = new CSVReader();
    public static CSVReader CSVInstance { get { return Instance._CSVInstance; } }

    ObjectPooler _ObjectPooler = new ObjectPooler();
    public static ObjectPooler Pooler { get { return Instance._ObjectPooler; } }

    private void Awake()
    {
        Init();
    }

    private static void Init()
    {
        if (s_instance == null)
        {
            GameObject obj = GameObject.Find("@GameManager");
            if (obj == null)
            {
                obj = new GameObject { name = "@GameManager" };
                obj.AddComponent<GameManager>();
            }
        }
    }
}
