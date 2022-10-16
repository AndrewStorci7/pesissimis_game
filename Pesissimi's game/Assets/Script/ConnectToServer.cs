using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Photon.Pun;

namespace Com.AnDr3wS7oRc1.Pesissimisgame {
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {
        // Start is called before the first frame update
        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        private void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }

        private void OnJoinedLobby()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
