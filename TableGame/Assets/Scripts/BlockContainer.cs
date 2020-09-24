using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockContainer : MonoBehaviour
{
    [SerializeField] private Block[] _blocks;

    public Block[] GetBlocks() //нельзя возвращать массив, переделать под инкапсуляцию
    {
        return _blocks;
    }
}
