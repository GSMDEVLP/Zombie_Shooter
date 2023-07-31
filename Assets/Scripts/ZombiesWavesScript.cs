using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesWavesScript : MonoBehaviour
{
    public GameObject[] _zombiesCount;
    public int _maxZombiesOnWave = 10;
    public int _zombieKillsOnWave;

    void Update()
    {
        if (_zombieKillsOnWave >= _maxZombiesOnWave)
            ChangeWave();
        CountZombiesOfWave();
    }

    void CountZombiesOfWave()
    {
        _zombiesCount = GameObject.FindGameObjectsWithTag("Zombie");
    }

    void ChangeWave()
    {
        _maxZombiesOnWave++;
        _zombieKillsOnWave = 0;

        for (int countZombies = 0; countZombies < _zombiesCount.Length; countZombies++)
        {
            Destroy(_zombiesCount[countZombies].gameObject);
        }
    }
}
