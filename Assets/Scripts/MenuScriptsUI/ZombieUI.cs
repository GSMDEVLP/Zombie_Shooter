using System.Collections.Generic;
using UnityEngine;

public class ZombieUI : MonoBehaviour
{    
    [SerializeField] private GameObject _player;
    public float ZombieSpeed = 20f;
    public bool _aliveZombie = true;

    [SerializeField] private List<Rigidbody> _listRigidbodies = new List<Rigidbody>();

    private Animator _zombieAnimator;
    private AnimatorStateInfo _zombieStateInfo;

    void Start()
    {        
        _player = GameObject.FindGameObjectWithTag("Player");
        _zombieAnimator = gameObject.GetComponent<Animator>();
        RigidbodyIsKinematicOn();
    }
    // Update is called once per frame
    void Update()
    {
        ZombieController();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

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

        if (_zombieStateInfo.IsName("Zombie Attack") || _zombieStateInfo.IsName("Zombie Hit") || !_aliveZombie)
        {
            ZombieSpeed = 0f;
        }
        else
        {
            ZombieSpeed = 20f;
            gameObject.transform.LookAt(_player.transform.position);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _player.transform.position, ZombieSpeed * Time.deltaTime);
        }

    }


    public void TakeDamage()
    {
        _zombieAnimator.SetInteger("Dead", 1);              
        //gameObject.GetComponent<CapsuleCollider>().enabled = false;
        //RigidbodyIsKinematicOff();
        _aliveZombie = false;
        
        
    }
}
