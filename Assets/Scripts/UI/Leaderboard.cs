using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI leaderboardText;

    public int entries;

    string targetString;

    void Start()
    {
        for (int i = 0; i < entries; i++)
        {
            targetString += $"{GetRandomName()}: {Random.Range(5, 125)}\n";
        }
    }


    void Update()
    {
        leaderboardText.text = $"Pandora: {GameVariables.playerScore}\n" + targetString;
    }

    string GetRandomName()
    {
        List<string> names = new()
        {
            "Sarah",
            "Elle",
            "Zeus",
            "Steven",
            "Stewie",
            "Petah",
            "Peter",
            "Lois",
            "Brian",
            "Meg",
            "Chris",
            "Quagmire",
            "Cleveland",
            "The Chicken",
            "Stew man",
            "The Dog",
            "Pitbull",
            "Vinnie",
            "The Dawg",
            "Fancy Petah",
            "Alcoholic Lois",
            "Emily (Paris)",
            "Emily (America)",
            "67",
            "Camilla",
            "Petah 2",
            "Pedro Pascal",
            "Tracer",
            "Pharah",
            "Bastion",
            "Widowmaker",
            "Sea of Thieves",
            "No on I know fucking plays it, anyway isn't it awesome how you can run anywhere whenever? Well I had one mate that was really good with accents",
            "Obama",
            "God",
            "Not God",
            "When we ran into another crew, well he'd just start",
            "Mr World Wide",
            "My issue with sea of thieves is that there's not cute characters, I spent so much time just randomising",
            "Do this one as, haha, taylor stop typing out what we're saying",
            "Taylor this is confidential, these aren't usernames, pick up the pace",
            "Hi my name is Taylor and I'm real good at coding",
            "I killed a man a few years LOL",
            "Apple Fritter",
            "I am unemployed",
            "I am available for work",
            "Abbie",
            "Bread",
            "Mary Jane"       
            };

        return ScriptUtils.GetRandomFromList(names);
    }
}
