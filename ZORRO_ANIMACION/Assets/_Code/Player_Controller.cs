using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Animator _playerAnimator;

    [Header("Settings")]
    [SerializeField] private float _Speed;
    private bool _IsWalkingRight;
    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _IsWalkingRight = true;
            _characterController.Move(Vector3.right * _Speed * Time.deltaTime);
            _playerAnimator.SetBool("Walking_right", true);
            _playerAnimator.SetBool("Idle_rigth", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _IsWalkingRight = false;
            _characterController.Move(Vector3.left * _Speed * Time.deltaTime);
            _playerAnimator.SetBool("Idle_rigth", false);
            _playerAnimator.SetBool("Walking_left", true);
        }
        else
        {
            if(_IsWalkingRight ==true)
            {
                _playerAnimator.SetBool("Idle_rigth", true);
                _playerAnimator.SetBool("Idle_left", false);
                _playerAnimator.SetBool("Walking_left", false);
                _playerAnimator.SetBool("Walking_right", false);
            }else if(_IsWalkingRight == false)
            {
                _playerAnimator.SetBool("Idle_left", true);
                _playerAnimator.SetBool("Idle_rigth", false);
                _playerAnimator.SetBool("Walking_left", false);
                _playerAnimator.SetBool("Walking_right", false);
            }
        }





    }
}
