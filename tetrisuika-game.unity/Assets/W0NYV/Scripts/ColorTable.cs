using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTable
{
    private Dictionary<TetriminoType, Vector4> _table = new Dictionary<TetriminoType, Vector4>()
    {
        {TetriminoType.Void, new Vector4(0f, 0f, 0f, 0.5f)},
        {TetriminoType.I, new Vector4(0f, 1f, 1f, 1f)},
        {TetriminoType.O, new Vector4(1f, 1f, 0f, 1f)},
        {TetriminoType.S, new Vector4(0f, 1f, 0f, 1f)},
        {TetriminoType.Z, new Vector4(1f, 0f, 0f, 1f)},
        {TetriminoType.J, new Vector4(0f, 0f, 1f, 1f)},
        {TetriminoType.L, new Vector4(1f, 0.5f, 0f, 1f)},
        {TetriminoType.T, new Vector4(0.5f, 0f, 1f, 1f)}
    };

    public Dictionary<TetriminoType, Vector4> Table { get => _table; }
    
}
