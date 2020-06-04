using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Piece : MonoBehaviour, IPiece
{
    public Vector3 StartPosition = default;
    Vector3 _currentPosition;

    void Awake()
    {
        _currentPosition = StartPosition;
    }

    public Vector3 CurrentGridPosition()
    {
        return _currentPosition;
    }

    public bool MoveToPosition(Vector3 pos)
    {
        if (!InMovementRange(pos))
            return false;

        _currentPosition = pos;

        return true;
    }

    public bool InAttackRange(Vector3 pos)
    {
        return GetDistance(_currentPosition, pos) <= GetAttackRange();
    }

    public bool InMovementRange(Vector3 pos)
    {
        if (GetMovementState() == MovementType.Near)
        {
            return GetDistance(_currentPosition, pos) <= GetMovementRange();
        }
        else if (GetMovementState() == MovementType.Far)
        {
            return (pos.x != _currentPosition.x && pos.y != _currentPosition.y && pos.z == _currentPosition.z)
                || (pos.x == _currentPosition.x && pos.y != _currentPosition.y && pos.z != _currentPosition.z)
                || (pos.x != _currentPosition.x && pos.y == _currentPosition.y && pos.z != _currentPosition.z);
        }

        return false;
    }

    public void Hit()
    {
        // TODO: Got hit, remove from board
        Debug.Log(name + " DIED");
    }

    public abstract MovementType GetMovementState();

    public abstract int GetAttackRange();

    public abstract int GetMovementRange();

    public abstract ActionState CanDoAction(Vector3 pos, Piece other);

    public abstract ActionState DoAction(Vector3 pos, Piece other);

    public abstract void CheckActionOnPiece(Piece other);

    protected float GetDistance(Vector3 a, Vector3 b)
    {
        return Mathf.Abs(Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) + Mathf.Abs(a.z - b.z)) / 2;
    }
}