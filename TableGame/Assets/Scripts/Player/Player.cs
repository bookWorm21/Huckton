using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private string _name;

    private Transform[] _points;

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
            
    public event UnityAction EndMoved;

    public void InitPlayer(Transform[] points)
    {
        _points = points;
    }

    public void StartMove(int deltaIndex)
    {
        _mover.InitMoving(deltaIndex, _points);
    }

    private void OnEnable()
    {
        _mover.EndMoved += OnMoveEnd;
    }

    private void OnDisable()
    {
        _mover.EndMoved -= OnMoveEnd;
    }

    private void OnMoveEnd()
    {
        EndMoved?.Invoke();
    }
}
