using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveGO : MonoBehaviour
{
    [SerializeField] string myScene = default;

    void Start()
    {
        Invoke("OnSceneMove", 2);
        Debug.Log(SceneManager.GetActiveScene().name);

        
        //Debug.Log(currentScene.name);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSceneMove()
    {

        //SceneListManager.instance.gameObjects.SetActive(true);
        SceneManager.UnloadSceneAsync(myScene);

        
        Scene scene = SceneManager.GetSceneByName("GameObjectMaster");
        
        foreach (var rootGameObject in scene.GetRootGameObjects())
        {
            SceneListManager gameManager = rootGameObject.GetComponent<SceneListManager>();

            if (gameManager != null)
            {
                gameManager.OnPlay();
            }
            
        }
            //SceneManager.LoadSceneAsync("GameObjectMaster",LoadSceneMode.Single);
            //SceneManager.LoadSceneAsync("GameObjectMaster", LoadSceneMode.Additive);
        
        }
}
