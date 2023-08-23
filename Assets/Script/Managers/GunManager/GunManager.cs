using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunManager : MonoBehaviour
{
    [SerializeField] private TextAsset _textAssetData;

    [System.Serializable]
    public class GunList
    {
        public Gun[] Guns;
        public string name;
        public int power;
        public int ammo;
        public int range;
    }

    public GunList myGunList = new GunList();
    private enum Guns
    {
        None,
        M1911,
        Thompson,
        HK416,
        Repeater,
    };

    private void Awake()
    {
        GameManager.CSVInstance.ReadGunCsv(_textAssetData, myGunList.name, myGunList.power, myGunList.ammo, myGunList.range);
    }
    
}
