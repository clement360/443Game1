using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public Generator generator;
	public BoardManager boardScript;

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
		generator.generateBlocks ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
