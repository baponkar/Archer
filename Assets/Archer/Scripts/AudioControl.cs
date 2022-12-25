using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Baponkar.Archer
{
    public class AudioControl : MonoBehaviour
    {
        public AudioSource bow_load;
        public AudioSource bow_release;
        public AudioSource arrow_impact;
        public AudioSource breathing;
        public AudioSource land;

        public void PlayBreath()
        {
            breathing.Play();
        }
        public void StopBreath()
        {
            breathing.Stop();
        }

        public void PlayBowLoad()
        {
            bow_load.Play();
        }

        public void PlayBowRelease()
        {
            bow_release.Play();
        }
    
        public void PlayArrowImpact()
        {
            arrow_impact.Play();
        }

        public void PlayLand()
        {
            land.Play();
        }
    }
}
