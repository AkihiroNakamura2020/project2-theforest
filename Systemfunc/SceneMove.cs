using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviourPunCallbacks
{
    // Awake
    private void Awake()
    {
        // シーンの自動同期: 無効
        PhotonNetwork.AutomaticallySyncScene = false;
    }


    // Start is called before the first frame update
    private void Start()
    {
        // Photonに接続
        Connect("1.0");
        Debug.Log("a" + PhotonNetwork.IsMessageQueueRunning);

    }


    // Connect //////////////////////////////////////////////////////////////////////////

    // Photonに接続する
    private void Connect(string gameVersion)
    {
        if (PhotonNetwork.IsConnected == false)
        {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }


    // ニックネームを付ける
    private void SetMyNickName(string nickName)
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.LocalPlayer.NickName = nickName;
        }
    }


    // マスターサーバーに接続した時
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");

        // ロビーに入る
        JoinLobby();
    }

    // Join Lobby ///////////////////////////////////////////////////////////////////////

    // ロビーに入る

    private void JoinLobby()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinLobby();
            Debug.Log("ロビーに入りました");
        }
    }


    // 部屋に入室した時
    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");



        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            Debug.Log("OnJoinedRoomCurrentRoom.PlayerCount");

            SceneManager.LoadSceneAsync("SampleScene3", LoadSceneMode.Single);

            PhotonNetwork.IsMessageQueueRunning = true;

        }
    }
    // Pun Callbacks ////////////////////////////////////////////////////////////////////

    // Photonに接続した時
    public override void OnConnected()
    {
        Debug.Log("OnConnected");

        // ニックネームを付ける
        SetMyNickName("Naki");
    }

    // Photonから切断された時
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("OnDisconnected");
    }

}
