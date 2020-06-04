using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IPiece
{
    Vector3 CurrentGridPosition();

    ActionState CanDoAction(Vector3 pos, Piece other);

    ActionState DoAction(Vector3 pos, Piece other);

    MovementType GetMovementState();

    bool MoveToPosition(Vector3 pos);

    bool InAttackRange(Vector3 pos);

    bool InMovementRange(Vector3 pos);

    int GetAttackRange();

    int GetMovementRange();

    void CheckActionOnPiece(Piece other);

    void Hit();
}
