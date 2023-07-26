using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiScript : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public float ZombieSpeed = 0.5f;

    private Animator _zombieAnimator;

    void Start()
    {
        _zombieAnimator = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        ZombieController();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _zombieAnimator.SetBool("Attack", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _zombieAnimator.SetBool("Attack", false);
        }
    }

    private void ZombieController()
    {
        gameObject.transform.LookAt(_player.transform.position);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _player.transform.position, ZombieSpeed * Time.deltaTime);
    }
}
