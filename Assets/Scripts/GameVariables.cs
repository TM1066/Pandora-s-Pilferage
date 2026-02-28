using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameVariables
{
    public static TimeSpan gameTimer = new TimeSpan(0, 3, 0);

    public static bool playerCanMove = true, playerCanLook = true, playerFishing = false;

    public static bool playerHasHunger = false, playerHasEnergy = false;
    public static int playerHunger = 100, playerEnergy = 100;
    
    public static float mouseSensitivityMulti = 1;

    public static Dictionary<string,bool> cursesActive = new()
    {
        {"Hunger", false},
        {"Tired", false},
        {"Bouncy",false}
    };
}
