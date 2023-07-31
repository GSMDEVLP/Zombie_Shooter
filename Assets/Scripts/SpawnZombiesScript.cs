using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombiesScript : MonoBehaviour
{

    [SerializeField] private ZombiesWavesScript _zombiesWavesScript;
    [SerializeField] private GameObject _zombie;
    private float _spawnTime;
    private float _minSpawnTime = 5f;
    private float _maxSpawnTime = 15f;
    void Start()
    {
        _zombiesWavesScript = GameObject.FindAnyObjectByType<ZombiesWavesScript>();
        StartCoroutine("WaitTimeForSpawn");
    }

    IEnumerator WaitTimeForSpawn()
    {
        while(true)
        {
            if(_zombiesWavesScript._zombiesCount.Length < _zombiesWavesScript._maxZombiesOnWave)
            {
                Instantiate(_zombie.gameObject, gameObject.transform.position, Quaternion.identity);
                _spawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
                yield return new WaitForSeconds(_spawnTime);                
            }
            else
                yield return new WaitForSeconds(_spawnTime);
        }
    }
}
