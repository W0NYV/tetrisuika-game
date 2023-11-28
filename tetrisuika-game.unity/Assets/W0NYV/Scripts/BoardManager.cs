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

    public bool IsAnyMinoBelow()
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
        return BoardManagerUtility.AbstractIsControllableMino(_board, 0, 9, 1);
    }

    public bool IsControllableMinoAtLeftEnd()
    {
        return BoardManagerUtility.AbstractIsControllableMino(_board, 0, _board.BoardArray.Count, 10);
    }

    public bool IsControllableMinoAtRightEnd()
    {
        return BoardManagerUtility.AbstractIsControllableMino(_board, 9, _board.BoardArray.Count, 10);
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
            BoardManagerUtility.AbstractShift(_board, -10, i);
        }
    }

    public void LeftShift()
    {
        for (int i = 0; i < _board.BoardArray.Count; i++)
        {
            BoardManagerUtility.AbstractShift(_board, -1, i);
        }
    }

    public void RightShift()
    {
        for (int i = _board.BoardArray.Count - 1; i >= 0; i--)
        {
            BoardManagerUtility.AbstractShift(_board, 1, i);
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
