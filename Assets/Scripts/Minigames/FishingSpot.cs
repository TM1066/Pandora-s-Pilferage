using System.Collections.Generic;
using UnityEngine;

public class FishingSpot : AbstractInteractableObject
{

    public GameObject fishingUI;
    
    public Transform playerMoveToFish;

    public List<Fish> possibleFish = new();

    string originalName;

    void Start()
    {
        originalName = displayName;
    }
    public override void OnInteract()
    {
        base.OnInteract();

        if (!GameVariables.playerCanFish) return;

        FindAnyObjectByType<FishingManager>(FindObjectsInactive.Include).currentFishingSpot = this;
        fishingUI.SetActive(true);

        ScriptUtils.TakePlayerControl();
    }


    void Update()
    {
        if (GameVariables.playerCanMove) displayName = originalName;
        else displayName = "";
    }
}
