using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitbullChaser : MonoBehaviour
{
   public Rigidbody rig;
   public Transform playerTrans;
    //Dists are essentially min and max pitches
   public float chaseForce, maxDist, minDist;
   public float minPitch, maxPitch;

   public AudioSource controlledAudioSource;
   public AudioClip FIREBALLCLIP;
    void Start()
    {
        StartCoroutine(ChasePlayer());
    }

    void Update()
    {
        // Handle Pitch
        var distanceFromPlayer =  Mathf.InverseLerp(maxDist, minDist, Vector3.Distance(transform.position, playerTrans.position));
        controlledAudioSource.pitch = Mathf.Lerp(minPitch, maxPitch, distanceFromPlayer);

        this.transform.LookAt(playerTrans);

    }



   IEnumerator ChasePlayer()
    {
        while (true)
        {
            rig.AddForce((playerTrans.position - this.transform.position) * chaseForce);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
            controlledAudioSource.clip = FIREBALLCLIP;
            controlledAudioSource.Stop();
            controlledAudioSource.Play();

            FindAnyObjectByType<DeathScreen>(FindObjectsInactive.Include).Die(ScriptUtils.GetRandomFromList(new List<string>() {"Mr. WorldWide", "Mr. 305","PitBull","Bullpit","That guy from timber","A FIREBALL", "Armando Christian Perez","The Bald E"}));
        }
    }
}
