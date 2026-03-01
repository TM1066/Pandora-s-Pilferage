using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Unity.VisualScripting;
using UnityEngine.VFX;
using UnityEngine.UI;

[Serializable]
public class Fish
{
    public string name;
    [Range(-1f,1f)]
    public float foodWorth;
    public int scoreWorth;
    [Range(0,1f)]
    public float alcoholValue = 0;
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
    public TextMeshProUGUI caughtFishText;
    public float fishCheckDelay = 1;
    public float fishChance = 0.25f;

    public GameObject fishRod, currentFishObject;
    public Transform fishSpawnTrans;
    public Animator fishRodAnimator;

    public VisualEffect splashesEffect;

    public Rigidbody playerRig;

    public AudioSource hitmarkerAudio;
    public Image hitmarkerRenderer;

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

    IEnumerator HitMarker()
    {
        hitmarkerRenderer.enabled = true;
        hitmarkerAudio.Play();

        while (hitmarkerAudio.isPlaying) yield return null;

        hitmarkerRenderer.enabled = false;
        hitmarkerAudio.Stop();
    }

    public void ReelInFish()
    {
        StartCoroutine(HitMarker());

        reeled = true;
        splashesEffect.Stop();
        var fish = Instantiate(fishThere.fishSpawnPrefab, fishSpawnTrans);
        fish.transform.position = fishSpawnTrans.position;

        currentFishObject = fish;
        caughtFishText.text = $"Caught {fishThere.name}!";
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

        GameVariables.playerCanFish = false;
        FindAnyObjectByType<GameManager>().StartCoroutine(FishingCooldown());

        this.transform.gameObject.SetActive(false);
    }

    IEnumerator FishingCooldown()
    {
        yield return new WaitForSeconds(3);
        GameVariables.playerCanFish = true;
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
                //yield return new WaitUntil(() => Input.anyKeyDown);
                //yield return new WaitForSeconds(3);
                reeled = false;
                Destroy(currentFishObject);

                if (GameVariables.cursesActive["Hunger"])
                {
                    GameVariables.playerHunger = Mathf.Clamp01(GameVariables.playerHunger + fishThere.foodWorth);
                }
                if (GameVariables.cursesActive["Drunk"])
                {
                    GameVariables.playerDrunkenness = Mathf.Clamp01(GameVariables.playerDrunkenness + fishThere.alcoholValue);
                }

                GameVariables.playerScore += fishThere.scoreWorth;
                fishThere = null;
                fishRodAnimator.SetTrigger("Out");
                caughtFishText.text = $"";
                yield return new WaitForSeconds(fishCheckDelay);
                continue;
            }

            if (UnityEngine.Random.Range(0f,1f) < fishChance)
            {
                fishThere = ScriptUtils.GetRandomFromList(currentFishingSpot.possibleFish);
                splashesEffect.Play();
            }
            else fishThere = null;

            yield return new WaitForSeconds(fishCheckDelay);
        }
    }
}