using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameHundler : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TMP_Text _winnerName;

    public void GameEnd(string nameWinner)
    {
        _winnerName.text = nameWinner;
        _gameOverPanel.SetActive(true);
    }
}
