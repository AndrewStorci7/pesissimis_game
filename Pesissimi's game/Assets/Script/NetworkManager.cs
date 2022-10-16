using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Com.AnDr3wS7oRc1.Pesissimisgame {
    public class NetworkManager : MonoBehaviourPunCallbacks {
        string gameVersion = "1";
        public Transform spawnPoint;
        string IdRoom = "";

        void Awake() {
            PhotonNetwork.AutomaticallySyncScene = true;
        }
 
        void Start() {
            Connect();
        }

        public void Connect() {
            if (PhotonNetwork.IsConnected) {
                PhotonNetwork.JoinLobby();
            } else {
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
        }

        public override void OnConnectedToMaster() {
            Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnDisconnected(DisconnectCause cause) {
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        }
        public string RandomString() {
            int length = 5;

            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            System.Random random = new System.Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            
            return str_build.ToString();
        }

        public override void OnJoinRandomFailed(short returnCode, string message) {
            Debug.Log("Room join FAILED");
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsVisible = true;
            roomOptions.MaxPlayers = 20;
            IdRoom = RandomString();
            PhotonNetwork.CreateRoom(IdRoom, roomOptions, TypedLobby.Default);
            Debug.Log(IdRoom);
        }

        public override void OnJoinedRoom() {
            Debug.Log("Room joined successfully");
            PhotonNetwork.Instantiate("PF Main Camera", spawnPoint.position, spawnPoint.rotation, 0);
            PhotonNetwork.Instantiate("PF Player", spawnPoint.position, spawnPoint.rotation, 0);
        }
        void OnGUI()
        {
            GUI.Label(new Rect(10, 10, 100, 100), IdRoom);
        }
    }
}
