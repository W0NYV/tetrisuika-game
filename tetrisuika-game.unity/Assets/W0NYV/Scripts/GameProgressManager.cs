using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressManager : MonoBehaviour
{

    [SerializeField] private BoardManager _boardManager;

    private bool isGameStarted;

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
            if(!isGameStarted)
            {
                isGameStarted = true;
                GameStart();
            }
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(_boardManager.IsControllableMinoAtBottom())
            {
                CreateNextMino();
            }
            else
            {
                if(!_boardManager.IsAnyMinoAtBottom())
                {
                    _boardManager.DownShift();
                }
                else
                {
                    CreateNextMino();
                }
            }

        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(_boardManager.IsControllableMinoAtBottom())
            {
                CreateNextMino();
            }
            else
            {
                if(!_boardManager.IsAnyMinoAtLeft())
                {
                    _boardManager.LeftShift();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(_boardManager.IsControllableMinoAtBottom())
            {
                CreateNextMino();
            }
            else
            {
                if(!_boardManager.IsAnyMinoAtRight())
                {
                    _boardManager.RightShift();
                }
            }
        }

    }
}
