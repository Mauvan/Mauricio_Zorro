using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject _leftCharacter;
    [SerializeField] private Animator _leftAnimator;
    [SerializeField] private GameObject _rightCharacter;
    [SerializeField] private Animator _rightAnimator;

    [Header("Settings")]
    [SerializeField] private float _Speed;


    private Rigidbody2D _playerRigid;
    private bool _IsWalkingRight = true;
    private bool _CanMove = true;

    private void Start()
    {
        _playerRigid = this.GetComponent<Rigidbody2D>();
        _rightCharacter.SetActive(true);
        _leftCharacter.SetActive(false);
    }

    private void FixedUpdate()
    {
        GetInput();
    }

    private void GetInput()
    {
      if (Input.GetKey(KeyCode.D) && _CanMove) //Checks if the player is pressing the D key and moves the character to the right
        {
            _playerRigid.velocity = new Vector2(100f * _Speed * Time.deltaTime, 0);
            _IsWalkingRight = true;
            _rightCharacter.SetActive(true);
            _rightAnimator.SetBool("Walking_right", true);
            _rightAnimator.SetBool("Idle_right", false);
            _leftCharacter.SetActive(false);
            
        } else if (Input.GetKey(KeyCode.A) && _CanMove){ //Checks if the player is pressing the A key and moves the character to the left
            _playerRigid.velocity = new Vector2(100f * -_Speed * Time.deltaTime, 0);
            _IsWalkingRight = false;
            _leftCharacter.SetActive(true);
            _leftAnimator.SetBool("Walking_left", true);
            _leftAnimator.SetBool("Idle_left", false);
            _rightCharacter.SetActive(false);
            
        } else if (!Input.anyKey) //If no input is detected, check the last orientation and put the player in Idle animation
        {
            if(_IsWalkingRight)
            {
                _rightCharacter.SetActive(true);
                _rightAnimator.SetBool("Walking_right", false);
                _rightAnimator.SetBool("Idle_right", true);
                _leftCharacter.SetActive(false);
            }
            else if (!_IsWalkingRight)
            {
                _leftCharacter.SetActive(true);
                _leftAnimator.SetBool("Walking_left", false);
                _leftAnimator.SetBool("Idle_left", true);
                _rightCharacter.SetActive(false);
            }
        }
    }

    public void CanMove()
    {
        _CanMove = true;
    }

    public void CannotMove()
    {
        _CanMove = false;
    }
}
