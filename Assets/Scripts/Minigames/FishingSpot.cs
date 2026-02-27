using System.Collections.Generic;
using UnityEngine;

public class FishingSpot : AbstractInteractableObject
{

    public GameObject fishingUI;
    
    public Transform playerMoveToFish;

    public List<Fish> possibleFish = new();

    string originalName;
    public override void OnInteract()
    {
        base.OnInteract();

        if (GameVariables.playerFishing) return;

        FindAnyObjectByType<FishingManager>(FindObjectsInactive.Include).currentFishingSpot = this;
        fishingUI.SetActive(true);
        originalName = displayName;
        displayName = "";
        GameObject.Find("Player").transform.SetPositionAndRotation(playerMoveToFish.position, playerMoveToFish.rotation);


        ScriptUtils.TakePlayerControl();
    }

}
