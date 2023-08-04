using System.Collections;
using UnityEngine;

public class SpawnZombiesScript : MonoBehaviour
{
    [SerializeField] private ZombiesWavesScript _zombiesWavesScript;
    [SerializeField] private GameObject _zombie;
    private float _spawnTime;
    private float _minSpawnTime = 0.5f;
    private float _maxSpawnTime = 2f;

    private Vector3 _spawnPlace;
    void Start()
    {
        _zombiesWavesScript = FindAnyObjectByType<ZombiesWavesScript>();
        StartCoroutine("WaitTimeForSpawn");
    }
    IEnumerator WaitTimeForSpawn()
    {
        while(true)
        {
            if(_zombiesWavesScript._zombiesCount.Length < _zombiesWavesScript._maxZombiesOnWave)
            {
                _spawnPlace = new Vector3(Random.Range(-10, 10), 10.4f, Random.Range(-28, 28));
                _spawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
                Instantiate(_zombie.gameObject, _spawnPlace, Quaternion.identity);                
                yield return new WaitForSeconds(_spawnTime);                
            }
            else
                yield return new WaitForSeconds(_spawnTime);
        }
    }
}
