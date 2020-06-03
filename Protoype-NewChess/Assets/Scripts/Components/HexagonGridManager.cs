using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HexagonGridManager : MonoBehaviour
{
    public float HorizontalDiameter { get; } = 3f;
    public float VerticalDiameter { get; } = 4f;

    [SerializeField] LayerMask fieldMask;
    [SerializeField] Transform selector;
    [SerializeField] Camera targetCamera;


    void Update()
    {
        if (selector)
        {
            Vector3 position = MouseLocationToVector();

            if (position == Vector3.zero)
            {
                selector.position = new Vector3(0, -1, 0);
                return;
            }

            position.x = Mathf.Round(position.x);
            position.y = 0;
            position.z = Mathf.Round(position.z);


            selector.position = position;
        }   
    }

    Vector3 WorldToGrid(Vector3 world)
    {
        float xCount = Mathf.Round(world.x / HorizontalDiameter);
        float yCount = Mathf.Round(world.y);
        float zCount = Mathf.Round(world.z / VerticalDiameter);

        Vector3 grid = new Vector3(
            xCount * HorizontalDiameter,
            yCount,
            zCount * VerticalDiameter
            );
        
        return grid;
    }

    Vector3 MouseLocationToVector()
    {
        RaycastHit info;
        Ray ray = targetCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out info, float.MaxValue, fieldMask))
        {
            return info.transform.position;
        }

        return Vector3.zero;
    }
}
