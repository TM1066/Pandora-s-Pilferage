using System;
using UnityEngine;

public static class GameVariables
{
    public static TimeSpan gameTimer = new TimeSpan(0, 3, 0);

    public static bool playerCanMove = true, playerCanLook = true;
    
    public static float mouseSensitivityMulti = 1;
}
