using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Board
{

    private ReactiveCollection<TetriminoType> _boardArray = new ReactiveCollection<TetriminoType>(new TetriminoType[200]);
    public IReadOnlyReactiveCollection<TetriminoType> BoardArray => _boardArray;

    public void ChangeSquare(int index, TetriminoType type)
    {
        _boardArray[index] = type;
    }

    public void Reset()
    {
        //ReactiveCollectionの長さを取る方法が不明
        for (int i = 0; i < 200; i++)
        {
            _boardArray[i] = TetriminoType.Void;
        }
    }
}
