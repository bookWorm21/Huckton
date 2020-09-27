using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private string _name;

    [SerializeField] private TMP_Text _pointLabel;
    [SerializeField] private TMP_Text _nameLabel;

    private Transform[] _points;

    public int Points { get; private set; }

    public string Name
    {
        get
        {
            return _name;
        }
        private set
        {

        }
    }
            
    public event UnityAction<int> EndMoved;

    private void Start()
    {
        _nameLabel.text = _name;
    }

    public void InitPlayer(Transform[] points)
    {
        _points = points;
    }

    public void StartMove(int deltaIndex)
    {
        _mover.InitMoving(deltaIndex, _points);
    }

    public void AddPoint(int points)
    {
        Points += points;
        _pointLabel.text = Points.ToString();
    }

    private void OnEnable()
    {
        _mover.EndMoved += OnMoveEnd;
    }

    private void OnDisable()
    {
        _mover.EndMoved -= OnMoveEnd;
    }

    private void OnMoveEnd(int index)
    {
        EndMoved?.Invoke(index);
    }
}
