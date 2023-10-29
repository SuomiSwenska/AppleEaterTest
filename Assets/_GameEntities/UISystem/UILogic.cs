using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILogic : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private TextMeshProUGUI _pointsTMP;
    [SerializeField] private GameObject _resultItemGO;
    [SerializeField] private TextMeshProUGUI _resultItem;

    private Gameplay _gameplay;

    private void Awake()
    {
        _gameplay = FindObjectOfType<Gameplay>();
    }

    private void Start()
    {
        StartPanelActivate();
    }

    private void OnEnable()
    {
        _gameplay.OnStartButtonDown += GamePanelActivate;
        _gameplay.OnPlayerDeath += StartPanelActivate;
        _gameplay.OnUpdateUIHealth += UpdateHealthbar;
        _gameplay.OnUpdateUIPoints += UpdatePoints;
    }

    private void OnDisable()
    {
        _gameplay.OnStartButtonDown -= GamePanelActivate;
        _gameplay.OnPlayerDeath -= StartPanelActivate;
        _gameplay.OnUpdateUIHealth -= UpdateHealthbar;
        _gameplay.OnUpdateUIPoints -= UpdatePoints;
    }

    private void GamePanelActivate()
    {
        _startPanel.SetActive(false);
        _gamePanel.SetActive(true);
        _pointsTMP.text = "0";
    }

    private void StartPanelActivate()
    {
        _startPanel.SetActive(true);
        _gamePanel.SetActive(false);
        ShowBestResult();
    }

    private void UpdateHealthbar(float health)
    {

    }

    private void UpdatePoints(int points)
    {
        _pointsTMP.text = points.ToString();
    }

    private void ShowBestResult()
    {
        _resultItem.gameObject.SetActive(true);
        _resultItem.text = "User Alex :  " + Saver.instance.GetBestResult();
    }
}
