using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameVariables
{
    public static TimeSpan gameTimer = new TimeSpan(0, 3, 0);

    public static bool playerCanMove = true, playerCanLook = true, playerFishing = false, playerCanFish = true;

    public static bool playerHasHunger = false, playerHasEnergy = false;
    public static float playerHunger = 1, playerEnergy = 1, playerScore = 0, playerDrunkenness = 1;
    
    public static float mouseSensitivityMulti = 1;

    public static Dictionary<string,bool> cursesActive = new()
    {
        {"Hunger", false},
        {"Tired", false},
        {"Bouncy",false},
        {"Icy",false},
        {"Rage", false},
        {"Pitbull",false},
        {"Competition",false},
        {"Drunk",false},
        {"Hope",false}
    };
}
