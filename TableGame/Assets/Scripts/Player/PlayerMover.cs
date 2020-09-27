using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceBeforeTarget;
    [SerializeField] private BlockContainer _container;

    private Animator _animator;

    private Transform[] _points;
    private int _neededIndex;
    private int _currentIndex = 0;

    private float _currentSpeed;
    private Vector3 _direction;
    private Vector3 _current;
    private int _index;

    private int _count;
    private bool _isMove = false;

    public event UnityAction<int> EndMoved;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void InitMoving(int deltaIndex, Transform[] points)
    {
        _isMove = true;
        _points = points;
        _count = _points.Length;
        _neededIndex = _currentIndex + deltaIndex;
        _currentSpeed = _speed;

        if(_neededIndex > _count - 1)
        {
            _neededIndex -= _count;
        }    

        Vector3 pos = _points[_currentIndex].position;
        pos.y = transform.position.y;
        transform.position = pos;

        int nextIndex;
        if(_currentIndex >= _count - 1)
        {
            nextIndex = 0;
        }
        else
        {
            nextIndex = _currentIndex + 1;
        }

        _current = _points[nextIndex].position;
        _current.y = transform.position.y;
        _index = _currentIndex;

        _animator.SetBool("isMove", true);
        Rotate();
    }

    private void Update()
    {
        if (_isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, _current, _currentSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _current) < _distanceBeforeTarget)
            {
                transform.position = _current;

                if (_index == _neededIndex)
                {
                    _animator.SetBool("isMove", false);
                    _currentSpeed = 0;
                    _currentIndex = _index;
                    EndMoved?.Invoke(_currentIndex);
                }
                else
                {
                    _animator.SetBool("isMove", true);
                }

                if (_index >= _count - 1)
                {
                    _index = 0;
                }
                else
                {
                    _index += 1;
                }

                _current = _points[_index].position;
                _current.y = transform.position.y;

                Rotate();
            }
            else
            { 
            }
        }
    }

    private void Rotate()
    {
        _direction = _current - transform.position;
        Vector3 rotation = Vector3.RotateTowards(transform.forward, _direction, 3f, 3f);
        if (rotation != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(rotation);
        }
    }
}
