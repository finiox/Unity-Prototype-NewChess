using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PositionUIBehaviour : MonoBehaviour
{
    [SerializeField] Text locationText;

    public void UpdateLocation(Vector2 pos)
    {
        locationText.text = string.Format("({0}, {1})", pos.x, pos.y);
    }
}
