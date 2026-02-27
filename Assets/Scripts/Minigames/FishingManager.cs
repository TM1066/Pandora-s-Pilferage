using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

[Serializable]
public class Fish
{
    public string name;
    public string foodWorth;
    public Sprite sprite;    
}


public class FishingManager : MonoBehaviour
{
    Fish fishThere = null;
    bool reeled;

    public FishingSpot currentFishingSpot;
    public Animator fishAnimator;
    public SpriteRenderer fishRenderer;
    public TextMeshProUGUI fishNameText;
    public float fishCheckDelay = 1;
    public float fishChance = 0.25f;

    public void TryReelFish()
    {
        if (fishThere != null && !reeled)
        {
            ReelInFish();    
        }
        else
        {
            
        }
    }

    public void ReelInFish()
    {
        fishAnimator.SetTrigger("Reel");
    }


    void OnEnable()
    {
        StartCoroutine(CheckForFish());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator CheckForFish()
    {
        while (true)
        {
            if (UnityEngine.Random.Range(0f,1f) < fishChance)
            {
                fishThere = ScriptUtils.GetRandomFromList(currentFishingSpot.possibleFish);
                fishRenderer.sprite = fishThere.sprite;
                fishNameText.text = fishThere.name;
            }
            else fishThere = null;

            yield return new WaitForSeconds(fishCheckDelay);
        }
    }
}