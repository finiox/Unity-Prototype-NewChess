using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ArcherPiece : Piece
{
    public override ActionState CanDoAction(Vector3 pos, Piece other)
    {
        if (pos == CurrentGridPosition())
            return ActionState.Negative;

        if (InMovementRange(pos) && other == null)
            return ActionState.Walk;

        // TODO: Check if other team
        if (InAttackRange(pos) && other != null)
            return ActionState.Attack;

        if (InAttackRange(pos) && GetDistance(CurrentGridPosition(), pos) > 1 && other == null)
            return ActionState.Range;

        return ActionState.Negative;
    }

    public override int GetAttackRange()
    {
        return 2;
    }

    public override int GetMovementRange()
    {
        return 1;
    }
}
