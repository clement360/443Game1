using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public Generator generator;
	public BoardManager boardScript;

	public GameObject player;
    public int playerPosX;
	public int playerPosY;
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
        playerPosX = -8;
		playerPosY = 0;
	}

	public void MovePlayer(Vector3 dest)
	{
		playerObject.transform.position = dest + new Vector3(0f, .3f, 0f);
	}
			
	// Update is called once per frame
	void Update () {

	}
}
