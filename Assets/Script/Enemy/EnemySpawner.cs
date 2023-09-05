using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IObjectPool
{
    [SerializeField] private ObjectPooler _pooler;
    [SerializeField] private int _spawnRate;
    [SerializeField] private Transform[] _spawnPosition;
    [SerializeField] private int _maxSpawn;
    private int _currSpawn = 0;

    private void Start()
    {
        _maxSpawn = RandomValueSender(100);

    }
    private void Update()
    {
        if (_maxSpawn >= _currSpawn)
        {
            StartCoroutine(OnObjectSpawn());
            _currSpawn++;
        }
    }
    public IEnumerator OnObjectSpawn()
    {
        _spawnRate = RandomValueSender(30);


        yield return new WaitForSeconds(_spawnRate);
        int randPosition = RandomValueSender(_spawnPosition.Length);
        _pooler.SpawnFromPool("Enemy", _spawnPosition[randPosition].transform.position, Quaternion.identity);
    }
    private int RandomValueSender(int max)
    {
        int randValue = Random.Range(0, max);

        return randValue;
    }

}
