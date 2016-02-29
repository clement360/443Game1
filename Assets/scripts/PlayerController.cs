using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance = null;
	public bool touchingFinish;

	// Use this for initialization
	void Start () {
		touchingFinish = false;
		instance = this;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Finish") {
			Invoke ("Restart", (float)0.1);
		}
	}

	public void restartLevel(){
		Invoke ("Restart", (float)0.1);
	}

	private void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
