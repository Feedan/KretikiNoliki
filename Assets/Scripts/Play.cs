using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public Canvas canvas;
    public static int chose;

    public void ChooseRole(int role)
    {
        chose = role;
        EnabledCanvas();
    }
    public void EnabledCanvas()
    {
        canvas.enabled = false;
    }
}

