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

    public Gun SendGunsData(string GunName, ref Gun gun)
    {
        Debug.Log(GunName);
        Debug.Log(gun);
        int value = 0;
        switch (GunName)
        {
            case "M1911":
                value = 0;
                break;
            case "Thompson":
                value = 1;
                break;
            case "HK416":
                value = 2;
                break;
            case "Repeater":
                value = 3;
                break;
        }
        return gun = myGunList.Guns[value];
    }
}
