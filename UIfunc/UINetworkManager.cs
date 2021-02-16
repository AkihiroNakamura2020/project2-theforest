using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// MonoBehaviourではなくMonoBehaviourPunCallbacksを継承して、Photonのコールバックを受け取れるようにする
public class UINetworkManager : MonoBehaviourPunCallbacks
{

    [SerializeField] GameObject player;
    [SerializeField] Text playerCountText = null;
    [SerializeField] GameObject joinButton = null;
    public static int initPosition = -1;
    public static byte lobbyPlayerMaxCount = 4;
    [SerializeField] Text lobbyPlayerMaxCountText;
    [SerializeField] GameObject debugPanel;

    [SerializeField] GameObject namePanel;
    /*
    public static NetworkManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/

    private void Start()
    {
        lobbyPlayerMaxCountText.text = lobbyPlayerMaxCount.ToString();
        playerCountText.text = "";
        joinButton.SetActive(false);
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        if (string.IsNullOrEmpty(PhotonNetwork.LocalPlayer.NickName) == false)
        {
            namePanel.SetActive(false);
        }
    }

    // ロビーに入った時
    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
        joinButton.SetActive(true);
    }

    public void OnJoinButton()
    {
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions() { MaxPlayers = lobbyPlayerMaxCount }, TypedLobby.Default);
        joinButton.SetActive(false);
    }

    // マッチングが成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        Debug.Log("入室");
        Debug.Log("現在のPlayer数:" + PhotonNetwork.CurrentRoom.PlayerCount);
        // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する
        // var v = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        // PhotonNetwork.Instantiate("GamePlayer", v, Quaternion.identity);
        // PhotonNetwork.
        initPosition = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        playerCountText.text = PhotonNetwork.CurrentRoom.PlayerCount + "/" + PhotonNetwork.CurrentRoom.MaxPlayers;
        CheckMatching(PhotonNetwork.CurrentRoom.PlayerCount, PhotonNetwork.CurrentRoom.MaxPlayers);
    }

    // 他プレイヤーが参加した時に呼ばれるコールバック
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        // newPlayer.UserId
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("誰かが入室");
        Debug.Log("現在のPlayer数:" + PhotonNetwork.CurrentRoom.PlayerCount);
        playerCountText.text = PhotonNetwork.CurrentRoom.PlayerCount + "/" + PhotonNetwork.CurrentRoom.MaxPlayers;
        CheckMatching(PhotonNetwork.CurrentRoom.PlayerCount, PhotonNetwork.CurrentRoom.MaxPlayers);
    }

    // 他プレイヤーが退出した時に呼ばれるコールバック
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        Debug.Log("誰かが退出");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("OnRoomListUpdate");
        foreach (var info in roomList)
        {
            joinButton.SetActive(info.IsOpen);
            // playerCountText.text = info.PlayerCount + "/" + info.MaxPlayers;
        }
    }

    void CheckMatching(int currentRoomCount, int max)
    {
        if (currentRoomCount == max)
        {
            PhotonNetwork.IsMessageQueueRunning = false;
            SceneManager.LoadScene("Game");
        }
    }

    // 部屋を削除する
    //

    public void RoomMaxPlayersCount(bool isUp)
    {
        if (isUp)
        {
            lobbyPlayerMaxCount++;
            if (lobbyPlayerMaxCount >= 4)
            {
                lobbyPlayerMaxCount = 4;
            }
        }
        else
        {
            lobbyPlayerMaxCount--;
            if (lobbyPlayerMaxCount < 1)
            {
                lobbyPlayerMaxCount = 1;
            }
        }
        lobbyPlayerMaxCountText.text = lobbyPlayerMaxCount.ToString();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.B))
        {
            if (debugPanel.activeSelf)
            {
                debugPanel.SetActive(false);
            }
            else
            {
                debugPanel.SetActive(true);
            }
        }
    }

    [SerializeField] InputField inputField = default;
    public void OnSubmitName()
    {
        if (inputField.text == "")
        {
            return;
        }
        Debug.Log("名前の決定" + inputField.text);
        PhotonNetwork.LocalPlayer.NickName = inputField.text;
        namePanel.SetActive(false);
    }
}
