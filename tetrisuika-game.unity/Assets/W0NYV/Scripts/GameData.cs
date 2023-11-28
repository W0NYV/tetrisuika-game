using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{

    private int _score;
    private bool _isGameStarted;
    public bool IsGameStarted { get => _isGameStarted; }

    public void SetIsGameStarted(bool value)
    {
        _isGameStarted = value;
    }
}
