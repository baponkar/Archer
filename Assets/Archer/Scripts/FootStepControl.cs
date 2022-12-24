using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Baponkar.Archer
{
    public class FootStepControl : MonoBehaviour
    {
        public AudioSource[] footSteps;
        public AudioSource breathing;
        Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if(animator.GetFloat("xSpeed") == 0 && animator.GetFloat("ySpeed") == 0)
            {
                if(!breathing.isPlaying)
                    breathing.Play();
            }
            else
            {
                breathing.Stop();
            }
        }

        public void  PlayFootStep()
        {
            footSteps[Random.Range(0, footSteps.Length)].Play();
        }
    }
}
