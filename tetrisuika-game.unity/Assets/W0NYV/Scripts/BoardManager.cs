using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BoardManager : MonoBehaviour
{

    private BoardView _view;
    private Board _board = new Board();

    private void Awake() {
        TryGetComponent<BoardView>(out _view);
    }

    private void Start() {

        _board.BoardArray.ObserveReplace()
            .Subscribe(data =>
            {
                Debug.Log($"Replace : Index = {data.Index}, OldValue = {data.OldValue}, NewValue = {data.NewValue}");
            })
            .AddTo(this);
    }

    private void Update() {
        
        if(Input.GetKeyDown("space"))
        {
            _board.ChangeSquare(3, TetriminoType.O);
        }

    }
    
}
