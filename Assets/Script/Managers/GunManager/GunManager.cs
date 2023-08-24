using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunManager : MonoBehaviour
{
    [SerializeField] private TextAsset _textAssetData;

    [System.Serializable]
    public class Gun
    {
        public string name;
        public int power;
        public int ammo;
        public int range;
    }
    [System.Serializable]
    public class GunList
    {
        public Gun[] Guns;
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
        ReadGunCsv();
    }
    private void ReadGunCsv()
    {
        string[] data = _textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 4 - 1;
        myGunList.Guns = new Gun[tableSize];
        for (int i = 0; i < tableSize; i++)
        {
            myGunList.Guns[i] = new Gun();
            myGunList.Guns[i].name = data[4 * (i + 1)];
            myGunList.Guns[i].power = int.Parse(data[4 * (i + 1) + 1]);
            myGunList.Guns[i].ammo = int.Parse(data[4 * (i + 1) + 2]);
            myGunList.Guns[i].range = int.Parse(data[4 * (i + 1) + 3]);
        }
    }
}
