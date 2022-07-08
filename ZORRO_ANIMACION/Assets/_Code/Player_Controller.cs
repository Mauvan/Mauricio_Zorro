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

    private void Update()
    {
        CheckInput();
        Debug.Log(_characterController.velocity.magnitude);
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _characterController.Move(Vector3.right * _Speed * Time.deltaTime);
            _playerAnimator.SetBool("Walking_right", true);
            _playerAnimator.SetBool("Idle", false);
        }
        else
        {
            _playerAnimator.SetBool("Walking_right", false);
            _playerAnimator.SetBool("Idle", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _characterController.Move(Vector3.left * _Speed * Time.deltaTime);
        }

        if(_characterController.velocity.magnitude < 0.1f)
        {
            
        }
    }
}
