using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Board
{

    private ReactiveCollection<TetriminoType> _boardArray = new ReactiveCollection<TetriminoType>(new TetriminoType[200]);
    public IReadOnlyReactiveCollection<TetriminoType> BoardArray => _boardArray;
    private ReactiveCollection<bool> _isControllableArray = new ReactiveCollection<bool>(new bool[200]);
    public IReadOnlyReactiveCollection<bool> IsControllableArray => _isControllableArray;

    public void ChangeControllable(int index, bool value)
    {
        _isControllableArray[index] = value;
    }

    public void ChangeSquare(int index, TetriminoType type)
    {
        _boardArray[index] = type;
    }

    public void Reset()
    {
        for (int i = 0; i < _boardArray.Count; i++)
        {
            _boardArray[i] = TetriminoType.Void;
        }
    }

    public TetriminoType[] GetArray()
    {
        TetriminoType[] board = new TetriminoType[_boardArray.Count];
        
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = _boardArray[i];
        }

        return board;
    }
}
