using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
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

    private void ReadCsv()
    {
        string[] data = _textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 4 - 1;
        Debug.Log($"TableSize = {tableSize}");
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
    public void ReadGunCsv(TextAsset texData, string GunName, int Power, int Ammo, int Range)
    {
        string[] data = texData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 4 - 1;

        for (int i = 0; i < tableSize; i++)
        {
            myGunList.Guns[i] = new Gun();
            name = data[4 * (i + 1)];
            Power = int.Parse(data[4 * (i + 1) + 1]);
            Ammo = int.Parse(data[4 * (i + 1) + 1]);
            Range = int.Parse(data[4 * (i + 1) + 1]);
            Range = int.Parse(data[4 * (i + 1) + 1]);
        }
    }
    public void SendData()
    {
        for (int i = 0; i < myGunList.Guns.Length; i++)
        {

        }
    }
    private void Start()
    {
        ReadCsv();
    }
}
