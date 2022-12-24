using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baponkar.Archer
{
    public class ArrowShoot : MonoBehaviour
    {
        float range = 1000f;
        public GameObject arrowPrefab;
        RaycastHit hit;
        public Transform arrowSpawnPosition;

        public GameObject handArrow;

        public AudioControl audioControl;
    
        void Start()
        {
        
        }

    
        public void Shoot()
        {
            handArrow.gameObject.SetActive(false);

            audioControl.PlayBowRelease();

            Vector2 ScreenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
            if(Physics.Raycast(ray, out hit, range))
            {
                GameObject arrow = GameObject.Instantiate(arrowPrefab, arrowSpawnPosition.transform.position, arrowSpawnPosition.transform.rotation) as GameObject;
                arrow.GetComponent<Arrow>().SetTarget(hit.point);
                audioControl.PlayArrowImpact();
            }
        }
    }
}
