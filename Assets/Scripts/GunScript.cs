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

    // переменные для очереди стрельбы
    private float _fireRate = 1f;
    private float _nextTimeToFire;
     


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= _nextTimeToFire)
        {
            Shoot();
            _nextTimeToFire = Time.time + _fireRate;
        }
    }

    void Shoot()
    {
        _shootEffect.Play();
        _shootAudio.Play();

        RaycastHit hit;

        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, _rayLength))
        {
            Debug.Log(hit.collider.gameObject.name);
            Target target = hit.transform.GetComponent<Target>();

            if(target != null)
            {
                target.TakeDamage(_damage);
            }

            ParticleSystem createHit = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(createHit.gameObject, 1f);
        }

    }

}
