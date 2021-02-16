using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class photonCount : MonoBehaviourPunCallbacks
{
    [SerializeField]
    NumberProp numberProp;

    int lobbyPlayerMaxCount;

    SampleScene0126 sampleScene0126;

    int chara;

    [SerializeField]
    CharaUIchange2 charaUIchange2;

    public void BeforeCount()
    {
        photonView.RPC(nameof(LobbyCount), RpcTarget.AllViaServer, PhotonNetwork.LocalPlayer.UserId);
    }

    /*
    private void Start()
    {
        photonView.RPC(nameof(LobbyCount), RpcTarget.AllViaServer, PhotonNetwork.LocalPlayer.UserId);
    }
    */

    // [PunRPC]属性をつけると、RPCでの実行が有効になる
    [PunRPC]
    public void LobbyCount(string id)
    {
        lobbyPlayerMaxCount++;

        Debug.Log(lobbyPlayerMaxCount);
        Onflag(id);
    }


    public void Onflag(string id)
    {
        if (lobbyPlayerMaxCount == 1)
        {
            if (id == PhotonNetwork.LocalPlayer.UserId)
            {
                //numberProp = GameObject.FindWithTag("PlayerNumber").GetComponent<NumberProp>();
                numberProp.Humanon();

                // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する
                //var v1 = new Vector3(-2, 0.5f,-2);
                //GameObject Prefab = PhotonNetwork.Instantiate("GamePlayer1", v1, Quaternion.identity);

                Debug.Log("Charachois" + chara);

                if (chara == 1)
                {
                    var v1 = new Vector3(-2, 0.5f, -2);
                    GameObject Prefab = PhotonNetwork.Instantiate("Rabbit", v1, Quaternion.identity);
                }

                if (chara == 2)
                {
                    var v2 = new Vector3(2, 0.5f, 2);
                    GameObject Prefab = PhotonNetwork.Instantiate("Fox", v2, Quaternion.identity);
                }

                StartCoroutine("Turnoffhuman");
            }
            //flag = false;
        }

        if (lobbyPlayerMaxCount == 2)
        {
            if (id == PhotonNetwork.LocalPlayer.UserId)
            {
                //numberProp = GameObject.FindWithTag("PlayerNumber").GetComponent<NumberProp>();
                numberProp.Faceon();

                Debug.Log("Charachois" + chara);

                if (chara == 1)
                {
                    var v1 = new Vector3(-2, 0.5f, -2);
                    GameObject Prefab = PhotonNetwork.Instantiate("Rabbit", v1, Quaternion.identity);
                }

                if (chara == 2)
                {
                    var v2 = new Vector3(2, 0.5f, 2);
                    GameObject Prefab = PhotonNetwork.Instantiate("Fox", v2, Quaternion.identity);
                }

                StartCoroutine("Turnoffwolf");

                // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する
                //var v2 = new Vector3(2, 0.5f, 2);
                //GameObject Prefab = PhotonNetwork.Instantiate("GamePlayer1", v2, Quaternion.identity);
            }
            //flag = false;
        }

        if (lobbyPlayerMaxCount == 3)
        {
            if (id == PhotonNetwork.LocalPlayer.UserId)
            {
                //numberProp = GameObject.FindWithTag("PlayerNumber").GetComponent<NumberProp>();
                numberProp.Humanon();

                // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する
                var v3 = new Vector3(-2, 0.5f, 2);
                GameObject Prefab = PhotonNetwork.Instantiate("GamePlayer1", v3, Quaternion.identity);

                StartCoroutine("Turnoffhuman");
            }
            //flag = false;
        }

        if (lobbyPlayerMaxCount == 4)
        {
            if (id == PhotonNetwork.LocalPlayer.UserId)
            {
                //numberProp = GameObject.FindWithTag("PlayerNumber").GetComponent<NumberProp>();
                numberProp.Humanon();
                var v4 = new Vector3(2, 0.5f, -2);
                GameObject Prefab = PhotonNetwork.Instantiate("GamePlayer1", v4, Quaternion.identity);

                StartCoroutine("Turnoffhuman");
            }
            //flag = false;
        }
    }

    public void BeforeChararabbit()
    {
        photonView.RPC(nameof(Chararabbit), RpcTarget.AllViaServer, PhotonNetwork.LocalPlayer.UserId);
        Debug.Log("BeforeChararabbit");
    }

    // [PunRPC]属性をつけると、RPCでの実行が有効になる
    [PunRPC]
    public void Chararabbit(string id)
    {
        if (id == PhotonNetwork.LocalPlayer.UserId)
        {
            chara = 1;
            Debug.Log("rabbit");
        }
        
    }

    public void BeforeFox()
    {
        photonView.RPC(nameof(CharaFox), RpcTarget.AllViaServer, PhotonNetwork.LocalPlayer.UserId);
        Debug.Log("BeforeFox");
    }

    // [PunRPC]属性をつけると、RPCでの実行が有効になる
    [PunRPC]
    public void CharaFox(string id)
    {
        if (id == PhotonNetwork.LocalPlayer.UserId)
        {
            chara = 2;
            Debug.Log("Fox");
        }
    }

    IEnumerator Turnoffhuman()
    {
        yield return new WaitForSeconds(2);
        charaUIchange2.Humanoff();
    }

    IEnumerator Turnoffwolf()
    {
        yield return new WaitForSeconds(2);
        charaUIchange2.Wollfoff();
    }

    /*

    public void Chararabbit()
    {
        chara = 1;
        Debug.Log("rabbit");
    }

    public void CharaFox()
    {
        chara = 2;
        Debug.Log("Fox");

    }

    
    void Charachois()
    {
        Debug.Log("Charachois"+chara);

        if (chara == 1)
        {
            var v1 = new Vector3(-2, 0.5f, -2);
            GameObject Prefab = PhotonNetwork.Instantiate("Rabbit", v1, Quaternion.identity);
        }

        if (chara == 2)
        {
            var v2 = new Vector3(2, 0.5f, 2);
            GameObject Prefab = PhotonNetwork.Instantiate("Fox", v2, Quaternion.identity);
        }
    }
    */
}
