using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressManager : MonoBehaviour
{

    [SerializeField] private BoardManager _boardManager;

    private void Update() {
        
        if(Input.GetKeyDown("space"))
        {
            _boardManager.CreateControllableMino();
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            _boardManager.DownShift();

            if(_boardManager.IsControllableSquareAtBottom())
            {
                _boardManager.ClearControllableSquares();
                _boardManager.CreateControllableMino();
            }

        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _boardManager.LeftShift();

            if(_boardManager.IsControllableSquareAtBottom())
            {
                _boardManager.ClearControllableSquares();
                _boardManager.CreateControllableMino();
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            _boardManager.RightShift();

            if(_boardManager.IsControllableSquareAtBottom())
            {
                _boardManager.ClearControllableSquares();
                _boardManager.CreateControllableMino();
            }
        }

    }
}
