using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Baponkar.Archer
{
    public class StringPull : MonoBehaviour
    {
        public GameObject BowString;
        public Transform stringIdlePos;
        public Transform stringPullPos;

        public AudioControl audioControl;

        void Start()
        {
            stringNotPull();
        }

  

        public void stringPull()
        {
            audioControl.PlayBowLoad();
            BowString.transform.localPosition = stringPullPos.transform.position;
            BowString.transform.SetParent(stringPullPos);
            BowString.transform.localPosition = Vector3.zero;
            BowString.transform.localRotation = Quaternion.identity;

        }

        public void stringNotPull()
        {
            BowString.transform.position = stringIdlePos.transform.position;
            BowString.transform.SetParent(stringIdlePos);
            BowString.transform.localPosition = Vector3.zero;
            BowString.transform.localRotation = Quaternion.identity;

        }
   
    }
}
