using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class KingPiece : Piece
{
    public override MovementType GetMovementState()
    {
        return MovementType.Far;
    }

    public override int GetAttackRange()
    {
        return 1;
    }

    public override int GetMovementRange()
    {
        return 1;
    }

    //
    // METHODS

    public override ActionState CanDoAction(Vector3 pos, Piece other)
    {
        if (pos == CurrentGridPosition())
            return ActionState.Negative;

        if (InMovementRange(pos) && other == null)
            return ActionState.Walk;

        if (InAttackRange(pos) && other != null)
            return ActionState.Attack;

        return ActionState.Negative;
    }

    public override ActionState DoAction(Vector3 pos, Piece other)
    {
        if (pos == CurrentGridPosition())
            return ActionState.Negative;

        if (InMovementRange(pos) && other == null)
        {
            MoveToPosition(pos);
            return ActionState.Walk;
        }

        // TODO: Check if other team
        if (InAttackRange(pos) && other != null)
        {
            other.Hit();
            return ActionState.Attack;
        }

        return ActionState.Negative;
    }

    public override void CheckActionOnPiece(Piece other)
    {
        return;
    }
}
