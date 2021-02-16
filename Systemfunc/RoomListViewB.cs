using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class RoomListViewB : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private InputfieldButton roomListEntryPrefab = default; // RoomListEntryのPrefabの参照

    private ScrollRect scrollRect;

    private Dictionary<string, InputfieldButton> activeEntries = new Dictionary<string, InputfieldButton>();
    private Stack<InputfieldButton> inactiveEntries = new Stack<InputfieldButton>();

    private void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    /*
    private void Update()
    {
        string ActiveList = "";

        foreach (string key in activeEntries.Keys)
        {
            ActiveList = ActiveList + "key=" + key + ",val=" + activeEntries[key] + "/";
            //ActiveList +にしたのは、後から追加していく文で表示させるため
        }

        Debug.Log("ActiveList:" + ActiveList);
    }
    */

    // ルームリストが更新された時に呼ばれるコールバック
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        Debug.Log("OnRoomListUpdate(List<RoomInfo> roomList)");

        
        foreach (var info in roomList)
        {
            InputfieldButton entry;
            if (activeEntries.TryGetValue(info.Name, out entry))
            {
                if (!info.RemovedFromList)
                {
                    // リスト要素を更新する
                    entry.Activate(info);
                }
                else
                {
                    // リスト要素を削除する
                    activeEntries.Remove(info.Name);
                    entry.Deactivate();
                    
                    inactiveEntries.Push(entry);　//Push：inactiveEntriesとしてデータ登録

                }
            }
            else if (!info.RemovedFromList)
            {
                ///*
                // リスト要素を追加する
                entry = (inactiveEntries.Count > 0)
                    ? inactiveEntries.Pop().SetAsLastSibling()　//Pop：inactiveEntriesからデータ取り出し
                    : Instantiate(roomListEntryPrefab, scrollRect.content);

                entry.Activate(info);
                activeEntries.Add(info.Name, entry);
                //*/

                
            }
        }
        
     }

    public void PushNewButton()
    {
        Instantiate(roomListEntryPrefab, scrollRect.content);
    }

 }