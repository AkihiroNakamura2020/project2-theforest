using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsyncTest : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("CountIterator");
    }

    IEnumerator CountIterator()
    {
        LogOutput("---Start---");
        for (var i = 0; i < 10; ++i)
        {
            yield return new WaitForSeconds(1);
            LogOutput($"Count:{i}");
        }
        LogOutput("---End---");

    }
    private void LogOutput(string message)
    {
        Debug.Log(DateTime.Now.ToString("yyyy/MM/dd") + "\t" + message);
    }
}