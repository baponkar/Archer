using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baponkar.Archer
{
    public class Arrow : MonoBehaviour
    {
        public Vector3 m_target = Vector3.zero;
        public float speed = 100f;
        public float lifeTime = 5f;
        public AudioSource audio;
        bool played;
        float timer;

        private void Awake()
        {
            timer = lifeTime;
        }

        void Update()
        {
            if(m_target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, m_target, speed);
            }

        
            timer -= Time.deltaTime;
            SelfDestroy();
        }

        private void PlayImpact()
        {
            if (Vector3.Distance(transform.position, m_target) <= 0 && !played)
            {
                audio.Play();
                played = true;
            }
        }

        public void SetTarget(Vector3 target)
        {
            m_target = target;
        }

        public void SelfDestroy()
        {
           if(timer < 0f) 
            Destroy(gameObject);
        }
    }
}
