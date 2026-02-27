using System;
using System.Collections.Generic;

public static class ScriptUtils
{
    public static void TakePlayerControl()
    {
        GameVariables.playerCanLook = false;
        GameVariables.playerCanMove = false;
    }

    public static void GivePlayerControl()
    {
        GameVariables.playerCanLook = true;
        GameVariables.playerCanMove = true;
    }

    public static T GetRandomFromList<T>(List<T> list)
    {
        Random rand = new Random();
        return list[rand.Next(0, list.Count)];
    }
}