using System.Collections;
using UnityEngine;

public class PitbullChaser : MonoBehaviour
{
   public Rigidbody rig;
   public Transform playerTrans;
    //Dists are essentially min and max pitches
   public float chaseForce, maxDist, minDist;
   public float minPitch, maxPitch;

   public AudioSource controlledAudioSource;
   void Update()
    {
        // Handle Pitch
        var distanceFromPlayer =  Mathf.InverseLerp(maxDist, minDist, Vector3.Distance(transform.position, playerTrans.position));
        controlledAudioSource.pitch = Mathf.Lerp(minPitch, maxPitch, distanceFromPlayer);
    }



   IEnumerator ChasePlayer()
    {
        while (true)
        {
            rig.AddForce((this.transform.position - playerTrans.position) * chaseForce);
            yield return new WaitForSeconds(0.1f);
        }
    }

    
}
