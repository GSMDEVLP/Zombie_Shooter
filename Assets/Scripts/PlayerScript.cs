using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _sensitivity = 0.5f;
    [SerializeField] private GameObject _player;
    private float _horizontalMove;
    private float _verticalMove;
    private Animator _playerAnimator;
    private Vector2 _turn;


    void Start()
    {
        // запрещаем выходить курсору за рамки окна игры
        Cursor.lockState = CursorLockMode.Locked;
        _playerAnimator = _player.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        PlayerRotation();
        PlayerMove();
        AnimationController();
    }

    private void PlayerMove()
    {
        _horizontalMove = Input.GetAxis("Horizontal");
        _verticalMove = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(_horizontalMove, 0, _verticalMove) * _speed * Time.deltaTime;        
        _player.transform.Translate(movement);
    }

    private void PlayerRotation()
    {
        _turn.x += Input.GetAxis("Mouse X") * _sensitivity;
        _turn.y += Input.GetAxis("Mouse Y") * _sensitivity;
        _turn.y = Mathf.Clamp(_turn.y, -20, 20);

        transform.localRotation = Quaternion.Euler(-_turn.y, 0, 0);
        _player.transform.localRotation = Quaternion.Euler(0, _turn.x, 0);
    }

    private void AnimationController()
    {
        if (_verticalMove > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _playerAnimator.SetInteger("Move", 2);
                _speed = 6f;
            }
            else
            {
                _playerAnimator.SetInteger("Move", 1);
                _speed = 3f;
            }

        }
        else if (_verticalMove < 0)
        {
            _playerAnimator.SetInteger("Move", -1);
            _speed = 3f;
        }
        else
        {
            _playerAnimator.SetInteger("Move", 0);
            _speed = 1f;
        }
    }

}
