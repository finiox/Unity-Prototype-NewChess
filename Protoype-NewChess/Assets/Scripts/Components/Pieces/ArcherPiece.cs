using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ArcherPiece : Piece
{
    Vector3 _targetedPosition;

    public override MovementType GetMovementState()
    {
        return MovementType.Near;
    }

    public override int GetAttackRange()
    {
        return 2;
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

        // TODO: Check if other team
        if (InAttackRange(pos) && GetDistance(CurrentGridPosition(), pos) == 1 && other != null)
            return ActionState.Attack;

        if (InAttackRange(pos) && GetDistance(CurrentGridPosition(), pos) > 1 && other == null)
            return ActionState.Range;

        return ActionState.Negative;
    }

    public override ActionState DoAction(Vector3 pos, Piece other)
    {
        if (pos == CurrentGridPosition())
            return ActionState.Negative;

        if (InMovementRange(pos) && other == null)
        {
            MoveToPosition(pos);

            if (_targetedPosition != null)
            {
                // TODO: Fire arrow, reset targeted position
            }

            return ActionState.Walk;
        }

        // TODO: Check if other team
        if (InAttackRange(pos) && GetDistance(CurrentGridPosition(), pos) == 1 && other != null)
        {
            other.Hit();
            return ActionState.Attack;
        }

        if (InAttackRange(pos) && GetDistance(CurrentGridPosition(), pos) > 1 && other == null)
        {
            _targetedPosition = pos;
            Debug.Log(_targetedPosition);
            return ActionState.Range;
        }

        return ActionState.Negative;
    }

    public override void CheckActionOnPiece(Piece other)
    {
        if (other != null && _targetedPosition == other.CurrentGridPosition())
        {
            other.Hit();
            Debug.Log("targeted");
        }

        return;
    }
}
