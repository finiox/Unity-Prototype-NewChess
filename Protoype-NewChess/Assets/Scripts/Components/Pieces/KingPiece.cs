using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class KingPiece : Piece
{
    public override ActionState CanDoAction(Vector3 pos, Piece other)
    {
        if (pos == CurrentGridPosition())
            return ActionState.Negative;

        if (InMovementRange(pos) && other == null)
            return ActionState.Walk;

        if (InAttackRange(pos) && other != null)
            return ActionState.Attack;

        return ActionState.Walk;
    }

    public override int GetAttackRange()
    {
        return 1;
    }

    public override int GetMovementRange()
    {
        return 1;
    }
}
