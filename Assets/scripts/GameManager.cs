using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public float levelStartDelay = 2f;
	public static GameManager instance = null;
	public Generator generator;
	public BoardManager boardScript;

	public GameObject player;
    public int playerPosX;
	public int playerPosY;
	public GameObject playerObject;

    public GameObject levelText;
    private GameObject tempTextBox;

    public AudioClip stepBlip;

    public int Level = 1;

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

    public void displayText()
    {
        Destroy(tempTextBox);
        //Instantiates the Object
        tempTextBox = (GameObject)Instantiate(levelText, new Vector3(0, -4, 0), Quaternion.identity);

        //Grabs the TextMesh component from the game object
        TextMesh theText = tempTextBox.transform.GetComponent<TextMesh>();

        //Sets the text.
        theText.text = "Level: " + Level;
    }

	void OnLevelWasLoaded(int index){
		Level++;
        displayText();
        Debug.Log("OnLevelLoaded Level: " + Level);
    }

	void InitGame ()
	{
		boardScript.SetupScene ();
		playerObject = (GameObject) Instantiate(player, new Vector3(-8f, 0, 0), Quaternion.identity );
        playerPosX = -8;
		playerPosY = 0;
        displayText();
        Debug.Log("InitGame Level: " + Level);
    }

	public void MovePlayer(Vector3 dest)
	{
        SoundManager.instance.RandomizeSfx(stepBlip);
		playerObject.transform.position = dest + new Vector3(0f, .3f, 0f);
	}
			
	// Update is called once per frame
	void Update () {

	}
}
