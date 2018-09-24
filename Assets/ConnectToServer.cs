using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ConnectToServer : Photon.PunBehaviour
    {

        #region Public Variables
        [Tooltip("The Name of the room you want to create. Other clients can join by using this name")]
        public string roomName = "GhostBusters";

        [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
        public byte maxPlayersPerRoom = 4;

        [Tooltip("Level of detail for Log entries you receive from Photon.PunBehaviour")]
        public PhotonLogLevel logLevel = PhotonLogLevel.ErrorsOnly;

        [Tooltip("Defines if the room is listed in the lobby. If not, it is also not joined randomly")]
        public bool roomIsVisible = true;

        #endregion

        #region Private Variables
        private string userId;

        #endregion

        #region MonoBehaviour CallBacks

        void Start()
        {
            PhotonNetwork.logLevel = logLevel;
            userId = Random.Range(1000, 9999).ToString();
            PhotonNetwork.AuthValues = new AuthenticationValues(userId);
            PhotonNetwork.ConnectUsingSettings("v1.0");
        }


        private void OnGUI()
        {
            GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
        }

        #endregion

        #region Photon.PunBehaviour CallBacks

        public override void OnJoinedLobby()
        {
            Debug.Log("Joined Lobby");
            RoomOptions roomOptions = new RoomOptions() { IsVisible = roomIsVisible, MaxPlayers = maxPlayersPerRoom };
            PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Joined room: " + roomName);
        }

        public override void OnDisconnectedFromPhoton()
        {
            Debug.Log("Disconneced from Photon: " + userId);

            //if (PhotonNetwork.isMasterClient)
            //{
            //    for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
            //    {
            //        PhotonNetwork.playerList[i].SetCustomProperties(table);
            //    }
            //}

        }




        #endregion
    }

