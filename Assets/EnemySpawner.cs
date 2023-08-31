using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate;
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private Transform[] _spawnPosition;

    private int _maxSpawn;

    private void Awake()
    {
        _maxSpawn = RandomValueSender(50);
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_spawnRate);
       

        while (_maxSpawn > 0)
        {
            yield return waitTime;
            int randPosition = RandomValueSender(10);
            Instantiate(_enemyPrefab[0], _spawnPosition[randPosition].transform.position, Quaternion.identity);
        }
    }
    private int RandomValueSender(int max)
    {
        int randValue = Random.Range(0, _spawnPosition.Length);

        return randValue;
    }
}
