using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int _complexity;

    public int Complexity
    {
        get
        {
            return _complexity;
        }
    }
}
