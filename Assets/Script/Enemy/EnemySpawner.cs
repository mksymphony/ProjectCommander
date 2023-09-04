using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _spawnRate;
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private Transform[] _spawnPosition;

    [SerializeField] private int _maxSpawn;
    private int _currSpawn = 0;

    private void Awake()
    {
        _maxSpawn = RandomValueSender(100);

    }
    private void Update()
    {
        if (_maxSpawn >= _currSpawn)
        {
            StartCoroutine(SpawnEnemy());
            _currSpawn++;
        }
    }
    private IEnumerator SpawnEnemy()
    {
        _spawnRate = RandomValueSender(30);

        yield return new WaitForSeconds(_spawnRate);
        int randPosition = RandomValueSender(_spawnPosition.Length);
        Instantiate(_enemyPrefab[0], _spawnPosition[randPosition].transform.position, Quaternion.identity);
    }
    private int RandomValueSender(int max)
    {
        int randValue = Random.Range(0, max);

        return randValue;
    }
}
