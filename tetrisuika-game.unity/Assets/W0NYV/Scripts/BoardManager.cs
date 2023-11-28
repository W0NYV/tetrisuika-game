using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BoardManager : MonoBehaviour
{

    private BoardView _view;
    private Board _board = new Board();
    private TetriminoTable _table = new TetriminoTable();

    public void ClearControllableSquares()
    {
        for(int i = 0; i < _board.BoardArray.Count; i++)
        {
            _board.ChangeControllable(i, false);
        }
    }

    public bool IsAnyMinoAtBottom()
    {
        for (int i = 0; i < _board.BoardArray.Count; i++)
        {
            if(_board.IsControllableArray[i])
            {
                if(_board.BoardArray[i - 10] != TetriminoType.Void && !_board.IsControllableArray[i - 10])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool IsAnyMinoAtLeft()
    {
        for (int i = 0; i < _board.BoardArray.Count; i++)
        {
            if(_board.IsControllableArray[i])
            {
                if(_board.BoardArray[i - 1] != TetriminoType.Void && !_board.IsControllableArray[i - 1])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool IsAnyMinoAtRight()
    {
        for (int i = _board.BoardArray.Count - 1; i >= 0; i--)
        {
            if(_board.IsControllableArray[i])
            {
                if(_board.BoardArray[i + 1] != TetriminoType.Void && !_board.IsControllableArray[i + 1])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool IsControllableMinoAtBottom()
    {
        for(int i = 0; i < 9; i++)
        {
            if(_board.IsControllableArray[i])
            {
                return true;
            }
            
        }

        return false;
    }

    public void CreateControllableMino()
    {

        int[] createMap = new int[8]
        {
            194, 195, 184, 185, 174, 175, 164, 165
        };

        TetriminoType mino = EnumUtility.GetRandomWithOutZero<TetriminoType>();        

        for (int i = 0; i < createMap.Length; i++)
        {
            _board.ChangeSquare(createMap[i], _table.Table[mino][i]);
            _board.ChangeControllable(createMap[i], _table.Table[mino][i] != TetriminoType.Void ? true : false);
        }
    }

    public void DownShift()
    {
        for (int i = 0; i < _board.BoardArray.Count; i++)
        {
            AbstractShift(-10, i);
        }
    }

    public void LeftShift()
    {
        for (int i = 0; i < _board.BoardArray.Count; i++)
        {
            AbstractShift(-1, i);
        }
    }

    public void RightShift()
    {
        for (int i = _board.BoardArray.Count - 1; i >= 0; i--)
        {
            AbstractShift(1, i);
        }
    }

    private void AbstractShift(int offset, int index)
    {
        if(_board.IsControllableArray[index])
        {
            _board.ChangeSquare(index + offset, _board.BoardArray[index]);
            _board.ChangeControllable(index + offset, true);

            _board.ChangeSquare(index, TetriminoType.Void);
            _board.ChangeControllable(index, false);
        }
    }

    private void Awake() {
        TryGetComponent<BoardView>(out _view);
    }

    private void Start() {

        _board.BoardArray.ObserveReplace()
            .Subscribe(data =>
            {
                // Debug.Log($"Replace : Index = {data.Index}, OldValue = {data.OldValue}, NewValue = {data.NewValue}");

                _view.SetBuffer(_board.GetArray());
            })
            .AddTo(this);
    }
}
