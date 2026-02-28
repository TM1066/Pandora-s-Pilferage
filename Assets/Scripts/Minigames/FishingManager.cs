using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Unity.VisualScripting;
using UnityEngine.VFX;

[Serializable]
public class Fish
{
    public string name;
    public int foodWorth;
    public GameObject fishSpawnPrefab;    

    public UnityEvent onCatch;
}


public class FishingManager : MonoBehaviour
{
    Fish fishThere = null;
    bool reeled;

    public FishingSpot currentFishingSpot;
    public Animator fishAnimator;
    //public SpriteRenderer fishRenderer;
    public TextMeshProUGUI fishNameText;
    public float fishCheckDelay = 1;
    public float fishChance = 0.25f;

    public GameObject fishRod, currentFishObject;
    public Transform fishSpawnTrans;
    public Animator fishRodAnimator;

    public VisualEffect splashesEffect;

    public Rigidbody playerRig;

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
        reeled = true;
        var fish = Instantiate(fishThere.fishSpawnPrefab, fishSpawnTrans);
        fish.transform.position = fishSpawnTrans.position;

        currentFishObject = fish;
        fishRodAnimator.SetTrigger("In");
    }


    void OnEnable()
    {
        GameVariables.playerFishing = true;

        fishRod.SetActive(true);
        //playerRig.isKinematic = true;
        splashesEffect.Stop();
        fishRodAnimator.SetTrigger("Out");


        StartCoroutine(CheckForFish());
    }

    void OnDisable()
    {
        GameVariables.playerFishing = false;

        StopAllCoroutines();
        //playerRig.isKinematic = false;
    }

    public void ExitFishing()
    {
        ScriptUtils.GivePlayerControl();
        fishRodAnimator.SetTrigger("In");

        Destroy(currentFishObject);

        fishRod.SetActive(false);

        this.transform.gameObject.SetActive(false);
    }

    public void Update()
    {
        // should be the bobber of the rod
        //Camera.main.transform.LookAt(fishSpawnTrans);
    }

    IEnumerator CheckForFish()
    {
        while (true)
        {

            if (reeled)
            {
                splashesEffect.Stop();
                yield return new WaitUntil(() => Input.anyKeyDown);
                reeled = false;
                Destroy(currentFishObject);

                if (GameVariables.cursesActive["Hunger"])
                {
                    GameVariables.playerHunger += fishThere.foodWorth;
                }

                fishThere = null;
                fishRodAnimator.SetTrigger("Out");
                yield return new WaitForSeconds(fishCheckDelay);
                continue;
            }

            if (UnityEngine.Random.Range(0f,1f) < fishChance)
            {
                fishThere = ScriptUtils.GetRandomFromList(currentFishingSpot.possibleFish);
                fishNameText.text = fishThere.name;
                splashesEffect.Play();
            }
            else fishThere = null;

            yield return new WaitForSeconds(fishCheckDelay);
        }
    }
}