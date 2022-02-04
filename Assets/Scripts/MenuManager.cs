using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        OpenMenu();
    }
    public void OpenMenu()
    {
        _menu.SetActive(true);
    }
    public void OnRoleChoose(int role)
    {
        _gameManager.StartGame(role);
        _menu.SetActive(false);
    }
}
