using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QueueSwitch : MonoBehaviour
{
    [SerializeField] private EndGameHundler _endGameHundler;

    [SerializeField] private BlockContainer _container;
    [SerializeField] private Player[] _players;
    [SerializeField] TMP_Text _playerName;
    [SerializeField] TMP_Text _diceValue;
    [SerializeField] QuestionInit _questionInit;

    [SerializeField] private int _pointsForWin;

    [SerializeField] private AudioSource _roliAudio;

    private Transform[] _points;
    private Block[] _blocks;

    private Player _currentPlayer;
    private int _currentIndex;
    private bool _isMove = false;

    private void Start()
    {
        var points = _container.GetBlocks();

        _blocks = points;
        _points = new Transform[points.Length];
        _currentPlayer = _players[0];
        _currentIndex = 0;

        for(int i = 0; i < _points.Length; i++)
        {
            _points[i] = points[i].transform;
        }  
        
        foreach(var player in _players)
        {
            player.InitPlayer(_points);
        }

        _playerName.text = _currentPlayer.Name;
    }

    public void RollDice()
    {
        if(_isMove == false)
        {
            _roliAudio.Play();
            StartCoroutine(SetRoleValueInLabel());
        }
    }

    private IEnumerator SetRoleValueInLabel()
    {
        yield return new WaitForSeconds(1.7f);

        int a = Random.Range(1, 7);
        int b = Random.Range(1, 7);
        _diceValue.text = (a + b).ToString();
        _isMove = true;
        _currentPlayer.StartMove(a + b);
    }

    private void OnEnable()
    {
        foreach(var player in _players)
        {
            player.EndMoved += ActivateQuestion;
        }
    }

    private void OnDisable()
    {
        foreach (var player in _players)
        {
            player.EndMoved -= ActivateQuestion;
        }
    }

    private void ActivateQuestion(int index)
    {
        int complexity = 0;

        if(index >= 0 && index <= (_blocks.Length - 1))
        {
            complexity = _blocks[index].Complexity;
        }

        if (complexity == 1)
        {
            _questionInit.ShowText(complexity);
        }
        else if(complexity == 2)
        {
            _questionInit.ShowText();
        }    
    }

    public void NextPlayerInQueue(int points)
    {
        _isMove = false;
        _currentPlayer.AddPoint(points);
        if (_currentPlayer.Points >= _pointsForWin)
        {
            _isMove = true;
            _endGameHundler.GameEnd(_currentPlayer.Name);
        }
        else
        {
            Debug.Log(points);

            if (_currentIndex >= _players.Length - 1)
            {
                _currentIndex = 0;
            }
            else
            {
                _currentIndex++;
            }

            _currentPlayer = _players[_currentIndex];
            _playerName.text = _currentPlayer.Name;
        }
    }
}
