using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public float levelStartDelay = 2f;
	public static GameManager instance = null;
	public Generator generator;
	public BoardManager boardScript;

    public GameObject levelText;
    private GameObject tempTextBox;
    public int Level = 0;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		generator = GetComponent<Generator> ();
		boardScript = GetComponent<BoardManager> ();
		InitGame ();

        DontDestroyOnLoad(gameObject);
    }

    public void displayText()
    {
        if(Level > 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Level"));
        }

        //Instantiates the Object
        tempTextBox = (GameObject)Instantiate(levelText, new Vector3(0, -4, 0), Quaternion.identity);

        //Grabs the TextMesh component from the game object
        TextMesh theText = tempTextBox.transform.GetComponent<TextMesh>();

        //Sets the text.
        theText.text = "Level: " + Level;
    }

	void InitGame ()
	{
		boardScript.SetupScene ();
        displayText();
	}

	// Update is called once per frame
	void Update () {

	}
}
