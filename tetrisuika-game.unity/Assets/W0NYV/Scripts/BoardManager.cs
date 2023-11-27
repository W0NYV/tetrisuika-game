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
        for(int i = 0; i < 200; i++)
        {
            _board.ChangeControllable(i, false);
        }
    }

    public bool IsControllableSquareAtBottom()
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
        for (int i = 0; i < 200; i++)
        {
            if(_board.IsControllableArray[i])
            {

                Debug.Log(i);

                _board.ChangeSquare(i-10, _board.BoardArray[i]);
                _board.ChangeControllable(i-10, true);

                _board.ChangeSquare(i, TetriminoType.Void);
                _board.ChangeControllable(i, false);
            }
        }
    }

    public void LeftShift()
    {
        for (int i = 0; i < 200; i++)
        {
            if(_board.IsControllableArray[i])
            {
                _board.ChangeSquare(i-1, _board.BoardArray[i]);
                _board.ChangeControllable(i-1, true);

                _board.ChangeSquare(i, TetriminoType.Void);
                _board.ChangeControllable(i, false);
            }
        }
    }

    public void RightShift()
    {
        for (int i = 200 - 1; i >= 0; i--)
        {
            if(_board.IsControllableArray[i])
            {
                _board.ChangeSquare(i+1, _board.BoardArray[i]);
                _board.ChangeControllable(i+1, true);

                _board.ChangeSquare(i, TetriminoType.Void);
                _board.ChangeControllable(i, false);
            }
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
