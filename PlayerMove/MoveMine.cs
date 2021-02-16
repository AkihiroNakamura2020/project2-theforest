using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using System.Collections.Generic;

// MonoBehaviourPunCallbacksを継承すると、photonViewプロパティが使えるようになる
public class MoveMine : MonoBehaviourPunCallbacks
{
    NumberProp numberProp;

    Getpnumber getpnumber;

    bool flag =true;

    int lobbyPlayerMaxCount;

    private const int _PLAYER_UPPER_LIMIT = 2;

    private void Update()
    {
        // 自身が生成したオブジェクトだけに移動処理を行う
        if (photonView.IsMine)
        {
            var dx = 0.1f * Input.GetAxis("Horizontal");
            var dy = 0.1f * Input.GetAxis("Vertical");
            transform.Translate(dx, 0, dy);
            /*
            if (flag)
            {
                getpnumber = GameObject.FindWithTag("PlayerNumber").GetComponent<Getpnumber>();
                getpnumber.GetpnumberOn();

                if (getpnumber.ransu == 0)
                {
                    numberProp = GameObject.FindWithTag("PlayerNumber").GetComponent<NumberProp>();
                    numberProp.Faceon();
                }

                flag = false;
            }
            */
        }
    }
    /*
    public void BeforeCount()
    {
        photonView.RPC(nameof(LobbyCount), RpcTarget.AllViaServer);
        LobbyCount();
    }

    // [PunRPC]属性をつけると、RPCでの実行が有効になる
    [PunRPC]
    public void LobbyCount()
    {
        lobbyPlayerMaxCount++;

        //PlayerPrefs.SetInt("Count", lobbyPlayerMaxCount);
        //PlayerPrefs.Save();

        Debug.Log(lobbyPlayerMaxCount);
        Onflag();
    }
    

    
    public void Onflag()
    {
        //numberProp = GameObject.FindWithTag("PlayerNumber").GetComponent<NumberProp>();
        //numberProp.LobbyCount();

        //int Mycount = PlayerPrefs.GetInt("Count", 0); 
        Debug.Log(lobbyPlayerMaxCount);

        if (lobbyPlayerMaxCount == 2)
        {
            if (photonView.IsMine)
            {
                numberProp = GameObject.FindWithTag("PlayerNumber").GetComponent<NumberProp>();
                numberProp.Faceon();
            }
                //flag = false;
        }
    }
    */


    /*
    public void SetMyCustomProperties()
    {
        Debug.Log("0");
        //自分のクライアントの同期オブジェクトにのみ
        if (photonView.IsMine)
        {
            Debug.Log("1");
            List<int> playerSetableCountList = new List<int>();

            //制限人数までの数字のリストを作成
            //例) 制限人数 = 4 の場合、{0,1,2,3}
            int count = 0;
            for (int i = 0; i < _PLAYER_UPPER_LIMIT; i++)
            {
                playerSetableCountList.Add(count);
                count++;
            }

            //他の全プレイヤー取得
            Player[] otherPlayers = PhotonNetwork.PlayerListOthers;

            Debug.Log("otherPlayers.Length" + otherPlayers.Length);
            //他のプレイヤーがいなければカスタムプロパティの値を"0"に設定
            if (otherPlayers.Length <= 0)
            {
                //ローカルのプレイヤーのカスタムプロパティを設定
                int playerAssignNum = otherPlayers.Length;
                PhotonNetwork.LocalPlayer.UpdatePlayerNum(playerAssignNum);
                Debug.Log("playerSetableCountList[0]" + playerSetableCountList[0]);
                return;
            }

            //他のプレイヤーのカスタムプロパティー取得してリスト作成
            List<int> playerAssignNums = new List<int>();
            for (int i = 0; i < otherPlayers.Length; i++)
            {
                playerAssignNums.Add(otherPlayers[i].GetPlayerNum());
            }
            Debug.Log("playerAssignNums" + playerAssignNums);

            //リスト同士を比較し、未使用の数字のリストを作成
            //例) 0,1にプレーヤーが存在する場合、返すリストは2,3
            playerSetableCountList.RemoveAll(playerAssignNums.Contains);

            //ローカルのプレイヤーのカスタムプロパティを設定
            //空いている場所のうち、一番若い数字の箇所を利用
            PhotonNetwork.LocalPlayer.UpdatePlayerNum(playerSetableCountList[0]);

            Debug.Log("playerSetableCountList[0]" + playerSetableCountList[0]);
        }
    }
    */
}
