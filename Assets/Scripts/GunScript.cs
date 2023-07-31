using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private float _rayLength = 50f;
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField] private AudioSource _shootAudio;
    public Camera Camera;
    private float _damage = 10f;
    private int _zombieDamage = 50;

    // переменные для очереди стрельбы
    private float _fireRate = 1f;
    private float _nextTimeToFire;

    //кол-во патронов
    public int BagAmmo = 20;
    public int MaxAmmo = 10;
    public int CurrentAmmo;
    public float ReloadTime = 1.5f;
    private bool isReloading = false;

    void Start()
    {
        StartCoroutine(Reload());
    }

    void Update()
    {
        if (isReloading)
            return;

        if (CurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetMouseButtonDown(0) && Time.time >= _nextTimeToFire)
        {
            Shoot();
            _nextTimeToFire = Time.time + _fireRate;
        }
    }

    IEnumerator Reload()
    {
        if(BagAmmo > 0)
        { 
            isReloading = true;
            Debug.Log("Reloading...");
            yield return new WaitForSeconds(ReloadTime);
            CurrentAmmo = MaxAmmo;
            BagAmmo -= MaxAmmo;
            isReloading = false;
        }
        
    }

    void Shoot()
    {        
        CurrentAmmo--;
        _shootEffect.Play();
        _shootAudio.Play();

        RaycastHit hit;

        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, _rayLength))
        {
            //Debug.Log(hit.collider.gameObject.name);
            Target target = hit.transform.GetComponent<Target>();
            ZombieScript zombie = hit.transform.GetComponent<ZombieScript>();

            if(target != null)
            {
                target.TakeDamage(_damage);
            }
            
            if(zombie != null)
            {
                zombie.TakeDamage(_zombieDamage);
            }

            ParticleSystem createHit = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(createHit.gameObject, 1f);
        }

    }

}
