using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetriminoTable : MonoBehaviour
{
    private Dictionary<TetriminoType, TetriminoType[]> _table = new Dictionary<TetriminoType, TetriminoType[]>()
    {
        // {TetriminoType.Void, new Vector4(0f, 0f, 0f, 0.5f)},
        {
            TetriminoType.I, 
            new TetriminoType[] 
            {
                TetriminoType.I, TetriminoType.Void,
                TetriminoType.I, TetriminoType.Void,
                TetriminoType.I, TetriminoType.Void,
                TetriminoType.I, TetriminoType.Void,
            }
        },

        {
            TetriminoType.O, 
            new TetriminoType[] 
            {
                TetriminoType.O, TetriminoType.O,
                TetriminoType.O, TetriminoType.O,
                TetriminoType.Void, TetriminoType.Void,
                TetriminoType.Void, TetriminoType.Void
            }
        },

        {
            TetriminoType.S, 
            new TetriminoType[] 
            {
                TetriminoType.S, TetriminoType.Void,
                TetriminoType.S, TetriminoType.S,
                TetriminoType.Void, TetriminoType.S,
                TetriminoType.Void, TetriminoType.Void
            }
        },


        {
            TetriminoType.Z, 
            new TetriminoType[] 
            {
                TetriminoType.Void, TetriminoType.Z,
                TetriminoType.Z, TetriminoType.Z,
                TetriminoType.Z, TetriminoType.Void,
                TetriminoType.Void, TetriminoType.Void
            }
        },

        {
            TetriminoType.J, 
            new TetriminoType[] 
            {
                TetriminoType.Void, TetriminoType.J,
                TetriminoType.Void, TetriminoType.J,
                TetriminoType.J, TetriminoType.J,
                TetriminoType.Void, TetriminoType.Void
            }
        },

        {
            TetriminoType.L, 
            new TetriminoType[] 
            {
                TetriminoType.L, TetriminoType.Void,
                TetriminoType.L, TetriminoType.Void,
                TetriminoType.L, TetriminoType.L,
                TetriminoType.Void, TetriminoType.Void
            }
        },

        {
            TetriminoType.T, 
            new TetriminoType[] 
            {
                TetriminoType.T, TetriminoType.Void,
                TetriminoType.T, TetriminoType.T,
                TetriminoType.T, TetriminoType.Void,
                TetriminoType.Void, TetriminoType.Void
            }
        },
    };

    public Dictionary<TetriminoType, TetriminoType[]> Table { get => _table; }
}
