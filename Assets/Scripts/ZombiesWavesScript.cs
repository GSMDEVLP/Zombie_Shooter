using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombiesWavesScript : MonoBehaviour
{
    public GameObject[] _zombiesCount;
    public int _maxZombiesOnWave = 10;
    public int _zombieKillsOnWave;
    public int WavesCount = 1; 
    [SerializeField] private Text _textWaves;

    void Update()
    {
        _textWaves.text = "Waves: " + WavesCount;
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
        WavesCount++;
        for (int countZombies = 0; countZombies < _zombiesCount.Length; countZombies++)
        {
            Destroy(_zombiesCount[countZombies].gameObject);
        }
    }
}
