using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUI : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _zombie;
    [SerializeField] private AudioSource _shootPlay;
    [SerializeField] private ParticleSystem _hitEffect;
    //сделать эффект
    [SerializeField] private ParticleSystem _shootEffect;

    private int difference = 140;
    public ZombieUI Zombie;


    void Update()
    {
        
        if (_player.transform.position.z - _zombie.transform.position.z < difference && Zombie._aliveZombie)
        {
            Shoot();
        }
        
    }

    public void Shoot()
    {
        _shootPlay.Play();
        _shootEffect.Play();
        Zombie.TakeDamage();
    }
}
