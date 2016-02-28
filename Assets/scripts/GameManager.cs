using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public Generator generator;
	public BoardManager boardScript;

	public GameObject player;

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
		Instantiate(player, new Vector3(-8f, 0, 0), Quaternion.identity );
	}

	public void MovePlayer(Vector3 dest)
	{
		player.transform.position = dest;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
