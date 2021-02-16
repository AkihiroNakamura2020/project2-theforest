using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourではなくMonoBehaviourPunCallbacksを継承して、Photonのコールバックを受け取れるようにする
public class SampleScene1125 : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();

        Debug.Log("0000");

        //OnJoinedRoom()から移動

        // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する
        var v = new Vector3(Random.Range(-3f, 3f), 0.5f,Random.Range(1f, 2f));
        //var v = new Vector3(3f,10f,0);

        //PhotonNetwork.Instantiate("GamePlayer", v, Quaternion.identity);

        GameObject Prefab = PhotonNetwork.Instantiate("GamePlayer1", v, Quaternion.identity);
        Debug.Log("Quaternion.identity" + Quaternion.identity);
        //Prefab.transform.SetParent(this.transform, false);

        //GameObject Prefab = Instantiate(playerprefab);
        //Prefab.transform.SetParent(this.transform, false);


        //GameObject ui_clone = PhotonNetwork.Instantiate("Inventory", v, Quaternion.identity);
        //GameObject canvas = GameObject.Find("Canvas");
        //canvasの子に指定
        //ui_clone.transform.SetParent(canvas.transform, false);


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

        //PhotonNetwork.IsMessageQueueRunning = true;

        /*

        // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する
        var v = new Vector3(Random.Range(-3f, 3f), Random.Range(1f, 2f));

        PhotonNetwork.Instantiate("GamePlayer", v, Quaternion.identity);

        GameObject ui_clone = PhotonNetwork.Instantiate("Inventory", v, Quaternion.identity);

        GameObject canvas = GameObject.Find("Canvas");

        //canvasの子に指定
        ui_clone.transform.SetParent(canvas.transform, false);
        */
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