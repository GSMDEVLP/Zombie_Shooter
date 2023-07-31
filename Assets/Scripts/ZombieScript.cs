using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    [SerializeField] private ZombiesWavesScript _zombiesWavesScript;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ammoBox;
    public float ZombieSpeed = 0.5f;
    private int _health = 100;

    [SerializeField] private List<Rigidbody> _listRigidbodies = new List<Rigidbody>();

    private Animator _zombieAnimator;
    private AnimatorStateInfo _zombieStateInfo;
        
    void Start()
    {
        _zombiesWavesScript = FindAnyObjectByType<ZombiesWavesScript>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _ammoBox = GameObject.FindGameObjectWithTag("AmmoBox");
        _zombieAnimator = gameObject.GetComponent<Animator>();
        RigidbodyIsKinematicOn();
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        _health = 100;
        ZombieSpeed = 0.5f;
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

            collision.gameObject.GetComponent<PlayerHealthScript>().TakePlayerDamage(10);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _zombieAnimator.SetBool("Attack", false);
        }
    }


    void RigidbodyIsKinematicOn()
    {
        _zombieAnimator.enabled = true;
        for (int countHips = 0; countHips < _listRigidbodies.Count; countHips++)
        {
            _listRigidbodies[countHips].isKinematic = true;
        }
    }
    
    void RigidbodyIsKinematicOff()
    {
        _zombieAnimator.enabled = false;
        for (int countHips = 0; countHips < _listRigidbodies.Count; countHips++)
        {
            _listRigidbodies[countHips].isKinematic = false;
        }
    }
    private void ZombieController()
    {        
        _zombieStateInfo = _zombieAnimator.GetCurrentAnimatorStateInfo(0);

        if (_health > 0)
        {
            if (_zombieStateInfo.IsName("Zombie Attack") || _zombieStateInfo.IsName("Zombie Hit"))
            {
                ZombieSpeed = 0f;
            }
            else
            {
                ZombieSpeed = 0.5f;
                gameObject.transform.LookAt(_player.transform.position);
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _player.transform.position, ZombieSpeed * Time.deltaTime);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        int chanñe;
        int probability = 5;
        _health -= damage;
        _zombieAnimator.SetTrigger("Hit");

        if (_health<= 0)
        {
            RigidbodyIsKinematicOff();
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            chanñe = Random.Range(0, 11);
            if(chanñe > probability)
                Instantiate(_ammoBox.gameObject, 
                    new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.2f , gameObject.transform.position.z), 
                    Quaternion.Euler(-90,0,0));
            _zombiesWavesScript._zombieKillsOnWave++;
        }
    }
}
