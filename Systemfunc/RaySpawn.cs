using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySpawn : MonoBehaviour
{
    [SerializeField]
    GameObject Prefab;
    [SerializeField]
    float placementInterval = 1.0f;//間隔を開けるかどうか
    [SerializeField]
    float PPositionY = 1.5f;
    
    GameObject floorObj;
    Vector3 floorSize;
    Ray ray;
    RaycastHit rayCastHit;
    Vector3 rayPosition;
    List<Vector3> positions = new List<Vector3>();

    void Start()
    {
        floorObj = GameObject.FindGameObjectWithTag("Floor"); 

        GetFloorSize();//planeのサイズ取得
        SetSpawnPosition();//座標をローラー
        CreateP();

    }

    void GetFloorSize()
    {
        Renderer floorRenderer = floorObj.GetComponent<Renderer>();
        floorSize = new Vector3(floorRenderer.bounds.size.x, floorRenderer.bounds.size.y, floorRenderer.bounds.size.z);
    }

    //コイン生成位置を決定するメソッド
    //このスクリプトをアタッチしたゲームオブジェクトと床が両方とも原点にあることが前提
    void SetSpawnPosition()
    {
        //床の左上から決めていく
        float x = -floorSize.x / 2; //原点0から左右に分かれているので
        float z = -floorSize.z / 2;

        //縦方向のループ
        for (int i = 0; i < Mathf.RoundToInt(floorSize.z / placementInterval); i++)//Mathf.RoundToInt(数値),で数値を四捨五入しIntに合わせる
        {
            x = -floorSize.x / 2;

            for (int j = 0; j < Mathf.RoundToInt(floorSize.x / placementInterval); j++)
            {
                ray = new Ray(new Vector3(x, transform.position.y, z), transform.TransformDirection(Vector3.down));

                if (Physics.Raycast(ray, out rayCastHit, transform.position.y))
                {
                    //Rayが当たったのが床かGreenbox上なら、生成座標として登録
                    if (rayCastHit.collider.tag == "Green" || rayCastHit.collider.tag == "Floor")
                    {
                        positions.Add(rayCastHit.point);
                    }
                }

                x += placementInterval;
            }

            z += placementInterval;
        }

    }

    void CreateP()
    {
        foreach (Vector3 position in positions) //登録した各座標への生成
        {
            Instantiate(Prefab, new Vector3(position.x, position.y + PPositionY, position.z), Quaternion.Euler(0, 0, 0));
        }
    }
}

