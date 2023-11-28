using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoardManagerUtility
{

    public static bool AbstractIsControllableMino(Board board, int init, int max, int increaseValue)
    {
        for(int i = init; i < max; i += increaseValue)
        {
            if(board.IsControllableArray[i])
            {
                return true;
            }
            
        }

        return false;
    }

    public static void AbstractShift(Board board, int offset, int index)
    {

        board.ChangeSquare(index + offset, board.BoardArray[index]);
        board.ChangeControllable(index + offset, true);

        board.ChangeSquare(index, TetriminoType.Void);
        board.ChangeControllable(index, false);
        
    }
}
