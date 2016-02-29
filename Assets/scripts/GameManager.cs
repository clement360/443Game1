using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public Generator generator;
	public BoardManager boardScript;

	public GameObject player;
    public int playerPos;
	public GameObject playerObject;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		generator = GetComponent<Generator> ();
		boardScript = GetComponent<BoardManager> ();
		InitGame ();
	}

	void InitGame ()
	{
		boardScript.SetupScene ();
		playerObject = (GameObject) Instantiate(player, new Vector3(-8f, 0, 0), Quaternion.identity );
        playerPos = -8;
	}

	public void MovePlayer(Vector3 dest)
	{
		playerObject.transform.position = dest + new Vector3(0f, .3f, 0f);
	}
			
	// Update is called once per frame
	void Update () {

	}
}
