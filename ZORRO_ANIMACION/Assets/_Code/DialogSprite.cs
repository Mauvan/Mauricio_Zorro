using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogSprite : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private DialogManager _DialogManager;
    [SerializeField] private GameObject _ButtonPrompt;

    [Header("Settings")]
    [TextArea(5,20)]
    [SerializeField] private string _Dialog;

    [Header("Events")]
    [SerializeField] private bool _SendEvent = false;
    [SerializeField] private UnityEvent _specialEvent;
    public void SpecialEvent() => _specialEvent?.Invoke();

    private bool _IsPlayerClose = false;

    private void FixedUpdate()
    {
        if (_IsPlayerClose && Input.GetKeyDown(KeyCode.E))
        {
            _DialogManager.ShowText(_Dialog);
            if (_SendEvent) SpecialEvent();
        }          
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _IsPlayerClose = true;
            _ButtonPrompt.SetActive(true);
        }     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _IsPlayerClose = false;
            _ButtonPrompt.SetActive(false);
        }       
    }
}
