using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneListManager : MonoBehaviour
{
	public GameObject gameObjects = default;

	public Queue<int> queue = new Queue<int>();
	public int dequeue ;

	//public static SceneListManager instance;


	private void Awake()
    {
		gameObjects.SetActive(true);
	}

    public void Onregister()
	{
		//　値を追加
		queue.Enqueue(1);
		queue.Enqueue(2);
		queue.Enqueue(3);

		Debug.Log("キューに登録されている数： " + queue.Count);
	}


	public void OnRemove()
    {
		gameObjects.SetActive(false);

		dequeue = queue.Peek();
		//dequeue = Dequeue()
		queue.Dequeue();
		Debug.Log("Dequeueした値: " + dequeue);

		string Scene = dequeue.ToString(); //scenes[1]

		SceneManager.LoadSceneAsync(Scene, LoadSceneMode.Additive);
		//SceneManager.LoadSceneAsync(Scene, LoadSceneMode.Single);

		Debug.Log("キューに登録されている数： " + queue.Count);
		
	}

	public void OnPlay()
	{
		gameObjects.SetActive(true);

	}
}
