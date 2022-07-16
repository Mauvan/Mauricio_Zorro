using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private GameObject _leftCharacter;
    [SerializeField] private Animator _leftAnimator;
    [SerializeField] private GameObject _rightCharacter;
    [SerializeField] private Animator _rightAnimator;

    [Header("Settings")]
    [SerializeField] private float _Speed;

    private bool _IsWalkingRight = true;
    private void Start()
    {
        _rightCharacter.SetActive(true);
        _leftCharacter.SetActive(false);
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _IsWalkingRight = true;
            _rightCharacter.SetActive(true);
            _leftCharacter.SetActive(false);
            _characterController.Move(Vector3.right * _Speed * Time.deltaTime);
            _rightAnimator.SetBool("Walking_right", true);
            _rightAnimator.SetBool("Idle_rigth", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _IsWalkingRight = false;
            _leftCharacter.SetActive(true);
            _rightCharacter.SetActive(false);
            _characterController.Move(Vector3.left * _Speed * Time.deltaTime);
            _leftAnimator.SetBool("Walking_left", true);
            _leftAnimator.SetBool("Idle_left", false);
        } else
        {
            if(_IsWalkingRight ==true)
            {
                _rightAnimator.SetBool("Idle_rigth", true);
                _leftAnimator.SetBool("Idle_left", false);
                _leftAnimator.SetBool("Walking_left", false);
                _rightAnimator.SetBool("Walking_right", false);
            }else if(_IsWalkingRight == false)
            {
                _leftAnimator.SetBool("Idle_left", true);
                _rightAnimator.SetBool("Idle_rigth", false);
                _leftAnimator.SetBool("Walking_left", false);
                _rightAnimator.SetBool("Walking_right", false);
            }
        }
    }
}
