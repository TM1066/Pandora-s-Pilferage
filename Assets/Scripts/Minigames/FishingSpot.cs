using System.Collections.Generic;
using UnityEngine;

public class FishingSpot : AbstractInteractableObject
{

    public GameObject fishRod, fishingUI;
    public Animator fishRodAnimator;

    public Transform playerMoveToFish;

    public List<Fish> possibleFish = new();

    bool goneFishin = false;
    string originalName;
    public override void OnInteract()
    {
        base.OnInteract();

        goneFishin = true;
        FindAnyObjectByType<FishingManager>(FindObjectsInactive.Include).currentFishingSpot = this;
        fishingUI.SetActive(true);
        originalName = displayName;
        displayName = "";
        GameObject.Find("Player").transform.SetPositionAndRotation(playerMoveToFish.position, playerMoveToFish.rotation);


        ScriptUtils.TakePlayerControl();
    }

}
