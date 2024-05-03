using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridLayoutSize : MonoBehaviour
{
    [SerializeField] GridLayoutGroup _gridLayoutGroup;

    void Update()
    {
        if (Screen.width > Screen.height)
        {
            // Landscape mode
            _gridLayoutGroup.cellSize = new Vector2(1500f, 1500f);
        }
        else
        {
            // Portrait Mode
            _gridLayoutGroup.cellSize = new Vector2(440f, 440f);
        }
    }
}
