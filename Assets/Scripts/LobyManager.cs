using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class LobyManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(1000, 9999);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom()
    {
        string NewRoomName = Random.Range(10000, 99999).ToString();
        PhotonNetwork.CreateRoom(NewRoomName, new Photon.Realtime.RoomOptions { IsVisible = true, IsOpen = true, MaxPlayers = 16, CleanupCacheOnLeave = false }, Photon.Realtime.TypedLobby.Default);
        Debug.Log("Create");
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Join");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("server started");
    }
    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("GameScene");
        }
    }
}
