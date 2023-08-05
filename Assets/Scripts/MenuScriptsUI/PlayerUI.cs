using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private Animator _playerAnimator;
    private bool _nextAnim = false;
    private float _speed = 1f;
    private float mov = 50;
    public ZombieUI _zombieUI;

    public GameObject Gun;


    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        
    }
    void Update()
    {
        if (!_nextAnim)
            MovePLayer();
        if(!_zombieUI._aliveZombie)
        {
            _playerAnimator.SetInteger("Move", 0);
            StartCoroutine(PlayAnimations());
        }
    }

    IEnumerator PlayAnimations()
    {
        while (true)
        {
            // ¬ключаем первую анимацию
            _playerAnimator.SetInteger("AnimationIndex", 1);
            yield return new WaitForSeconds(10f); // ∆дем 2 секунды

            // ¬ключаем вторую анимацию
            _playerAnimator.SetInteger("AnimationIndex", 2);
            yield return new WaitForSeconds(10f); // ∆дем 2 секунды

            // ¬ключаем третью анимацию
            _playerAnimator.SetInteger("AnimationIndex", 3);
            yield return new WaitForSeconds(10f); // ∆дем 2 секунды
        }

    }
    private void MovePLayer()
    {
        _playerAnimator.SetInteger("Move", 1);
        Vector3 movement = new Vector3(0, 0, -mov) * _speed * Time.deltaTime;
        gameObject.transform.Translate(movement);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NextAnimation")
        {
            _playerAnimator.SetInteger("Move", 0);
            Gun.GetComponent<GunUI>().enabled = true;
           _nextAnim = true;            
        }
    }

}
