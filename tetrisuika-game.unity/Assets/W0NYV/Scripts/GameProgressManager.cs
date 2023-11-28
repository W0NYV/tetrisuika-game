using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressManager : MonoBehaviour
{

    [SerializeField] private BoardManager _boardManager;
    private GameData _data = new GameData();

    private void CreateNextMino()
    {
        _boardManager.ClearControllableSquares();
        _boardManager.CreateControllableMino(); 
    }

    private void GameStart()
    {
        _boardManager.CreateControllableMino();
    }

    private void Update() {
        
        if(Input.GetKeyDown("space"))
        {   
            if(!_data.IsGameStarted)
            {
                _data.SetIsGameStarted(true);
                GameStart();
            }
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(_boardManager.IsControllableMinoAtBottom())
            {
                _boardManager.ClearLine();
                _boardManager.SortLine();
                CreateNextMino();
            }
            else
            {
                if(!_boardManager.IsAnyMinoBelow())
                {
                    _boardManager.DownShift();
                }
                else
                {
                    _boardManager.ClearLine();
                    _boardManager.SortLine();
                    CreateNextMino();
                }
            }

        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(_boardManager.IsControllableMinoAtBottom())
            {
                _boardManager.ClearLine();
                _boardManager.SortLine();
                CreateNextMino();
            }
            else
            {
                if(!_boardManager.IsAnyMinoAtLeft() && !_boardManager.IsControllableMinoAtLeftEnd())
                {
                    _boardManager.LeftShift();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(_boardManager.IsControllableMinoAtBottom())
            {
                _boardManager.ClearLine();
                _boardManager.SortLine();
                CreateNextMino();
            }
            else
            {
                if(!_boardManager.IsAnyMinoAtRight() && !_boardManager.IsControllableMinoAtRightEnd())
                {
                    _boardManager.RightShift();
                }
            }
        }

    }
}
