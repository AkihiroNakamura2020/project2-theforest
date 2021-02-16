using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rodcom : MonoBehaviour
{
    [SerializeField] private Transform p_pos;
    [SerializeField] private Collider m_Collider;

    public GameObject prefabrod;
    bool isntgameobj = true;


    public void GetPPos()
    {
        GameObject gameObj;

        if (isntgameobj)
        {
            gameObj = Instantiate(prefabrod) as GameObject;

            gameObj.transform.parent = p_pos;

            gameObj.transform.localPosition = new Vector3(0.7f, 0.3f, 0.3f);


            OnTriggerParent onflag = gameObj.GetComponent<OnTriggerParent>();

            onflag.FlagOn();

            m_Collider.enabled = false;

            Debug.Log("flag確認");

            isntgameobj = false;

        }

    }
}
