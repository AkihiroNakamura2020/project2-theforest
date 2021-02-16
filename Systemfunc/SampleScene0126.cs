using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourではなくMonoBehaviourPunCallbacksを継承して、Photonのコールバックを受け取れるようにする
public class SampleScene0126 : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();

        // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する
        //var v = new Vector3(Random.Range(-3f, 3f), 0.5f, Random.Range(1f, 2f));
        //GameObject Prefab = PhotonNetwork.Instantiate("GamePlayer1", v, Quaternion.identity);
    
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);

        Debug.Log("1111");
    }

    // マッチングが成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        Debug.Log("2222");

    }

    // 他プレイヤーが参加した時に呼ばれるコールバック
    public override void OnPlayerEnteredRoom(Player player)
    {
        Debug.Log(player.NickName + "が参加しました");
    }

    // 他プレイヤーが退出した時に呼ばれるコールバック
    public override void OnPlayerLeftRoom(Player player)
    {
        Debug.Log(player.NickName + "が退出しました");
    }
}