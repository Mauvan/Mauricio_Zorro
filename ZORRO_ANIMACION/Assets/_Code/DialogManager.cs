using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject _DialogCanvas;
    [SerializeField] private TextMeshProUGUI _TextMeshPro;
    [SerializeField] private Player_Controller _PlayerController;

    public void ShowText(string Dialog)
    {
        if (!_DialogCanvas.activeInHierarchy)
        {
            _DialogCanvas.SetActive(true);
            _TextMeshPro.text = Dialog;
            _PlayerController.CannotMove();
        }
    }

    public void CloseText()
    {
        _DialogCanvas.SetActive(false);
        _PlayerController.CanMove();
    }
}
