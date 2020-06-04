using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour
{
    [SerializeField] Vector3 gridPosition = default;

    public Vector3 GetGridPosition()
    {
        return gridPosition;
    }

    public Vector3 GetWorldPosition()
    {
        Vector3 worldPos = transform.position;

        worldPos.x = Mathf.Round(worldPos.x);
        worldPos.y = 0;
        worldPos.z = Mathf.Round(worldPos.z);

        return worldPos;
    }
}
