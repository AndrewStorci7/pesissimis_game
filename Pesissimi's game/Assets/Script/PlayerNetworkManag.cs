using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using Photon.Pun;
using Photon.Realtime;

namespace Com.AnDr3wS7oRc1.Pesissimisgame {
    public class PlayerNetworkManag : MonoBehaviourPunCallbacks
    {
        public Camera mainCamera;
        public AudioListener audio;

        void Start()
        {
            if (photonView.IsMine)
            {
                mainCamera.enabled = true;
                audio.enabled = true;
                //GetComponent<ThirdPerson>()
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}